using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace VSRO_TELEPORT_EDITOR
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.DBUserID!=string.Empty)
            {
                cSqlServerName.Text = Properties.Settings.Default.SQLServer;
                cDatabaseName.Text = Properties.Settings.Default.DatabaseName;
                cUserID.Text = Properties.Settings.Default.DBUserID;
                cPassword.Text = Properties.Settings.Default.DBPassword;
            }
        }

        private void cSaveButton_Click(object sender, EventArgs e)
        {
            bool rStart = Properties.Settings.Default.DBUserID == string.Empty;
            string conString= $"Data Source={cSqlServerName.Text}; Initial Catalog={cDatabaseName.Text}; User Id={cUserID.Text}; Password={cPassword.Text}";
            using (var conn = new SqlConnection(conString))
            {
                try
                {
                    conn.Open();
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"An error occurred when database connection!\n[{ex.Message}]", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
               
            }

            Properties.Settings.Default.SQLServer = cSqlServerName.Text;
            Properties.Settings.Default.DatabaseName = cDatabaseName.Text;
            Properties.Settings.Default.DBUserID = cUserID.Text;
            Properties.Settings.Default.DBPassword = cPassword.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            MessageBox.Show("Your database informations has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (rStart)
            {
                Application.Restart();
                Environment.Exit(0);
            }

        }
    }
}