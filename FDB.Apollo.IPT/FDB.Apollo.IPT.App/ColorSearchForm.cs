using FDB.Apollo.IPT.Client;
using System.Diagnostics;

namespace FDB.Apollo.IPT.App
{
    public partial class ColorSearchForm : Form
    {
        private readonly IPTClient _iptClient = MyIPTClient.IPTClient;

        private bool _uiEnabled;

        public bool UIEnabled
        {
            get { return _uiEnabled; }
            set
            {
                _uiEnabled = value;

                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Enabled = _uiEnabled;
                }
            }
        }

        public Client.Color? ReturnValue { get; set; }

        public ColorSearchForm()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadAllColors();
        }

        private async Task LoadAllColors()
        {
            try
            {
                UIEnabled = false;
                Cursor = Cursors.WaitCursor;

                var sw = Stopwatch.StartNew();
                var colors = await _iptClient.GetColorsAsync(Client.DbContextLocale.Working);
                Debug.Print($"Fetched all colors in {sw.ElapsedMilliseconds} ms");
                PopulateGrid(colors);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while attempting to load all Colors:{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UIEnabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void PopulateGrid(ICollection<Client.Color> colors)
        {
            grdData.Rows.Clear();

            foreach (var color in colors)
            {
                int rowID = grdData.Rows.Add();
                var row = grdData.Rows[rowID];
                row.Cells[grdDataColID.Index].Value = color.Id;
                row.Cells[grdDataColDesc.Index].Value = color.Description;
                row.Cells[grdDataColAbbrv.Index].Value = color.Abbreviation;
                row.Cells[grdDataColDoNotUse.Index].Value = color.DoNotUseInd;
                row.Cells[grdDataColBasicColorID.Index].Value = color.BasicColorID;
                row.Tag = color;
            }
        }

        private void grdColor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTotalRowCount.Text = $"Row Count: {grdData.Rows.Count}";
        }

        private void grdColor_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotalRowCount.Text = $"Row Count: {grdData.Rows.Count}";
        }



        private void ColorSearchForm_Shown(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.ReturnValue = null;
        }

        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = ExitWithSelectedRow();
            }
        }

        private void grdColor_DoubleClick(object sender, EventArgs e)
        {
            ExitWithSelectedRow();
        }

        private bool ExitWithSelectedRow()
        {
            if (grdData.SelectedRows.Count > 0)
            {
                var row = grdData.SelectedRows[0];
                this.ReturnValue = row.Tag as Client.Color;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }

            return false;
        }
    }
}
