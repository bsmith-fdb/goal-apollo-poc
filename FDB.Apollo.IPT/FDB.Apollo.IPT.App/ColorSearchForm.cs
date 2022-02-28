using FDB.Apollo.IPT.Client;
using System.Diagnostics;
using Color = FDB.Apollo.IPT.Client.Color;

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

                Cursor = _uiEnabled ? Cursors.Default : Cursors.WaitCursor;

                this.Refresh();
            }
        }

        public Color? ReturnValue { get; set; }

        public ColorSearchForm()
        {
            InitializeComponent();
        }

        private async Task LoadAllColors()
        {
            try
            {
                UIEnabled = false;

                var sw = Stopwatch.StartNew();
                var locale = rdoWIP.Checked ? DbContextLocale.Working : DbContextLocale.Published;
                var colors = await _iptClient.GetColorsAsync(locale);
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
            }
        }

        private void PopulateGrid(ICollection<Color> colors)
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
                row.Cells[grdDataColLastModifyDate.Index].Value = color.Audit.LastModifyDate.ToLocalTime().ToString();
                row.Cells[grdDataColLastModifyUser.Index].Value = color.Audit.LastModifyUserID;
                row.Cells[grdDataColPublishDate.Index].Value = color.Audit.PublishedDate.ToLocalTime().ToString();
                row.Cells[grdDataColPublishUser.Index].Value = color.Audit.PublishedUserID;
                row.Cells[grdDataColWipStatus.Index].Value = color.Audit.WipStatus;
                row.Tag = color;
            }
        }

        private void UpdateRowCount()
        {
            lblTotalRowCount.Text = $"Row Count: {grdData.Rows.Count}";
        }

        private bool CloseWithSelectedRow()
        {
            if (grdData.SelectedRows.Count > 0)
            {
                var row = grdData.SelectedRows[0];
                this.ReturnValue = row.Tag as Color;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }

            return false;
        }

        #region Event handlers

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadAllColors();
        }

        private async void rdoWIP_CheckedChanged(object sender, EventArgs e)
        {
            await LoadAllColors();
        }

        private void grdColor_DoubleClick(object sender, EventArgs e)
        {
            CloseWithSelectedRow();
        }

        private void grdColor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateRowCount();
        }

        private void grdColor_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateRowCount();
        }

        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = CloseWithSelectedRow();
            }
        }

        private void ColorSearchForm_Shown(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.ReturnValue = null;
        }

        #endregion Event handlers
    }
}
