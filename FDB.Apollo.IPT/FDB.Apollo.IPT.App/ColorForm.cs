using System.Diagnostics;
using FDB.Apollo.IPT.Client;

namespace FDB.Apollo.IPT.App
{
    public partial class ColorForm : Form
    {
        private readonly IPTClient m_iptClient = new IPTClient("https://apollo-poc-webapp-qm.azurewebsites.net/", new HttpClient());

        public ColorForm()
        {
            InitializeComponent();
        }

        private async void ColorForm_Load(object sender, EventArgs e)
        {
            try
            {
                var sw = Stopwatch.StartNew();

                var colors = await m_iptClient.GetColorsAsync(DbContextLocale.Working);

                MessageBox.Show($"Fetched {colors.Count} records in {sw.ElapsedMilliseconds} ms", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while attempting to fetch all colors:{Environment.NewLine}{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}