using System.Diagnostics;
using FDB.Apollo.IPT.Client;

namespace FDB.Apollo.IPT.App
{
    public partial class ColorEditForm : Form
    {
        private readonly IPTClient _iptClient = MyIPTClient.IPTClient;
        private readonly ColorSearchForm _colorSearchForm = new ColorSearchForm();

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

        public ColorEditForm()
        {
            InitializeComponent();
        }

        private async Task LoadColor(DbContextLocale locale, long id)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                UIEnabled = false;
                var sw = Stopwatch.StartNew();
                var color = await _iptClient.GetColorAsync(locale, id);
                Debug.Print($"Loaded Color ID={id} in {sw.ElapsedMilliseconds} ms");
                UpdateDisplay(color);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while attempting to load Color ID={id}{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                UIEnabled = true;
            }
        }

        private void UpdateDisplay(Client.Color color)
        {
            txtID.Text = color.Id.ToString();
            txtDesc.Text = color.Description;
            txtAbbrv.Text = color.Abbreviation;
            chkDoNotUse.Checked = color.DoNotUseInd;
            txtBasicColorID.Text = color.BasicColorID.ToString();
        }

        private async void mnuFileOpen_Click(object sender, EventArgs e)
        {
            var dr = _colorSearchForm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var color = _colorSearchForm.ReturnValue;
                await LoadColor(DbContextLocale.Working, color.Id);
            }
        }
    }
}