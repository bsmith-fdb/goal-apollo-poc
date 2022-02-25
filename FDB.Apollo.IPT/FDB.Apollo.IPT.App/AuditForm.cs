using System.Collections.Specialized;

namespace FDB.Apollo.IPT.App
{
    public partial class AuditForm : Form
    {
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

        public AuditForm()
        {
            InitializeComponent();
        }

        private void PopulateGrid()
        {
            grdAudit.Rows.Clear();

            foreach (var prop in Properties)
            {
                int rowID = grdAudit.Rows.Add(prop.Key, prop.Value);
            }

            grdAudit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AuditForm_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
