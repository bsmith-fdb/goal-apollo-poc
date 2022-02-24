using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDB.Apollo.IPT.App
{
    public partial class ApiPrompt : Form
    {
        public string ReturnValue { get; private set; } = string.Empty;

        public ApiPrompt()
        {
            InitializeComponent();
        }

        private void lstSelect_DoubleClick(object sender, EventArgs e)
        {
            if (lstSelect.SelectedItem is string url)
            {
                this.ReturnValue = url;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ApiPrompt_Load(object sender, EventArgs e)
        {
            lstSelect.Items.Clear();
            lstSelect.Items.Add(Resources.ApiHostUrlAzure);
            lstSelect.Items.Add(Resources.ApiHostUrlLocalhost);
        }
    }
}
