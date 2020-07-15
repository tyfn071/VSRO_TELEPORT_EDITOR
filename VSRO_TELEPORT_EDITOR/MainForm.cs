using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VSRO_TELEPORT_EDITOR
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public void OpenForm(XtraForm form)
        {

            cMainPanel.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            form.Dock = DockStyle.Fill;
            cMainPanel.Controls.Add(form);
            Text = "Vsro Teleport Editor v1.0 - " + form.Text;
            form.Show();


        }
        private void cAddTeleportButton_Click(object sender, EventArgs e)
        {
            OpenForm(new TeleportForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DBUserID != string.Empty)
            {
                Globals.s_SqlConnectionString = $"Data Source={Properties.Settings.Default.SQLServer}; Initial Catalog={Properties.Settings.Default.DatabaseName}; User Id={Properties.Settings.Default.DBUserID}; Password={Properties.Settings.Default.DBPassword}";
                Globals.LoadGameWorlds();
            }      
            else
            {
                cAddTeleportButton.Enabled = false;
                cTeleportLinkButton.Enabled = false;
                cOptionalTeleportButton.Enabled = false;
                OpenForm(new SettingsForm());
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenForm(new TeleportLinkForm());
        }

        private void cGitHubHyperLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/tyfn071");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            OpenForm(new SettingsForm());
        }

        private void cOptionalTeleportButton_Click(object sender, EventArgs e)
        {
            OpenForm(new OptTeleportForm());
        }
    }
}
