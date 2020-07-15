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
            Globals.s_SqlConnectionString= "Data Source=TAYFUNOSMAN; Initial Catalog=SRO_VT_SHARD; User Id=tyfn071; Password=1119007";
            Globals.LoadGameWorlds();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenForm(new TeleportLinkForm());
        }

        private void cGitHubHyperLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/tyfn071");
        }
    }
}
