using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
