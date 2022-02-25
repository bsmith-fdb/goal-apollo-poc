using System.Collections.Specialized;
using System.Diagnostics;
using FDB.Apollo.IPT.Client;
using Color = FDB.Apollo.IPT.Client.Color;

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

        public Color? MyLoadedItem { get; set; }

        public ColorEditForm()
        {
            InitializeComponent();
        }

        private async Task LoadColor(bool sourceWIP, long id, bool promptToSave = true)
        {
            if (promptToSave && !CheckUnsavedEdits())
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                UIEnabled = false;
                var sw = Stopwatch.StartNew();
                var locale = sourceWIP ? DbContextLocale.Working : DbContextLocale.Published;
                MyLoadedItem = await _iptClient.GetColorAsync(locale, id);
                Debug.Print($"Loaded Color ID={id} in {sw.ElapsedMilliseconds} ms");
                UpdateDisplay(MyLoadedItem);
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

        private void UpdateDisplay(Color color)
        {
            txtID.Text = color.Id.ToString();
            txtDesc.Text = color.Description;
            txtAbbrv.Text = color.Abbreviation;
            chkDoNotUse.Checked = color.DoNotUseInd;
            txtBasicColorID.Text = color.BasicColorID.ToString();
        }

        private Color UpdateObject()
        {
            var color = new Color();
            int id;

            if (int.TryParse(txtID.Text, out id))
            {
                color.Id = id;
            }
            else
            {
                color.Id = 0;
            }

            if (int.TryParse(txtBasicColorID.Text, out id))
            {
                color.BasicColorID = id;
            }
            else
            {
                //throw new Exception($"Basic Color ID must be a number");
                color.BasicColorID = 0;
            }

            color.Description = txtDesc.Text;
            color.Abbreviation = txtAbbrv.Text;
            color.DoNotUseInd = chkDoNotUse.Checked;

            return color;
        }

        private async void mnuFileOpen_Click(object sender, EventArgs e)
        {
            var dr = _colorSearchForm.ShowDialog();
            if (dr == DialogResult.OK && _colorSearchForm.ReturnValue is Color color)
            {
                await LoadColor(true, color.Id);
            }
        }

        private async void mnuMainToolsRefresh_Click(object sender, EventArgs e)
        {
            if (MyLoadedItem != null)
            {
                await LoadColor(MyLoadedItem.Audit.SourceWIP, MyLoadedItem.Id);
            }
        }

        private void mnuMainViewAudit_Click(object sender, EventArgs e)
        {
            if (MyLoadedItem != null)
            {
                var properties = MyLoadedItem.Audit.GetType().GetProperties()
                    .ToDictionary(k => k.Name, v => v.GetValue(MyLoadedItem.Audit)?.ToString() ?? string.Empty);

                using (var auditForm = new AuditForm())
                {
                    auditForm.Properties = properties;
                    auditForm.ShowDialog();
                }
            }
        }

        private void ColorEditForm_Load(object sender, EventArgs e)
        {
            
        }

        private async void mnuFileSave_Click(object sender, EventArgs e)
        {
            await SaveItem();
        }

        private async Task SaveItem()
        {
            try
            {
                var color = UpdateObject();

                if (color.Id == 0)
                {
                    long id = await _iptClient.CreateColorAsync(color);
                    await LoadColor(true, id, false);
                }
                else
                {
                    await _iptClient.UpdateColorAsync(color.Id, color);
                    await LoadColor(true, color.Id, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while attempting to save the item:{Environment.NewLine}{ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ObjectsEqual(Color a, Color b)
        {
            if (a == null && b == null)
                return true;

            if (a == null || b == null)
                return false;

            return a.Id == b.Id &&
                a.Description == b.Description &&
                a.Abbreviation == b.Abbreviation &&
                a.DoNotUseInd == b.DoNotUseInd &&
                a.BasicColorID == b.BasicColorID;
        }

        private bool CheckUnsavedEdits()
        {
            if (MyLoadedItem == null)
            {
                return true;
            }

            if (!ObjectsEqual(MyLoadedItem, UpdateObject()))
            {
                var dr = MessageBox.Show($"Unsaved edits will be lost. Continue?", "Unsaved Edits", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return dr == DialogResult.OK;
            }

            return true;
        }

        private void NewItem()
        {
            if (!CheckUnsavedEdits())
            {
                return;
            }

            ClearForm();

            MyLoadedItem = UpdateObject();

            txtID.Text = "NEW";

            txtDesc.Focus();
        }

        private void ClearForm()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    tb.Clear();
                }
                else if (ctrl is CheckBox cb)
                {
                    cb.Checked = false;
                }
            }
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            NewItem();
        }
    }
}