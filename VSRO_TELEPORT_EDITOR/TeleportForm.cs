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
using DevExpress.Utils.DirectXPaint;
using System.IO;
using System.Data.SqlClient;
using DevExpress.XtraPrinting.Native;

namespace VSRO_TELEPORT_EDITOR
{
    public partial class TeleportForm : DevExpress.XtraEditors.XtraForm
    {
        public TeleportForm()
        {
            InitializeComponent();
        }

        CTeleport SelectedTeleport = new CTeleport();

        private async Task GetTeleportCodeNames()
        {
            using(SqlConnection conn=new SqlConnection(Globals.s_SqlConnectionString))
            {
                conn.Open();
                using(SqlCommand command=new SqlCommand("select LTRIM(RTRIM(CodeName128)) from _RefTeleport order by ID",conn))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {

                            HashSet<string> codenames = new HashSet<string>();
                            while (reader.Read())
                                codenames.Add(reader.GetString(0));

                            codenames.ForEach(codename =>
                            {

                                if (cPortalList.InvokeRequired)
                                    cPortalList.BeginInvoke((Action)(() => cPortalList.Items.Add(codename)));
                                else
                                    cPortalList.Items.Add(codename);
                            });
                                                    
                                
                        }
                    }                    
                }
            }
        }
        private void ParseSelectedTeleport()
        {
            cService.Checked = SelectedTeleport.m_Service == 1;
            cID.Text = SelectedTeleport.m_ID.ToString();
            cCodeName128.Text = SelectedTeleport.m_CodeName128;
            cAssocObjectName.Text = SelectedTeleport.m_AssocRefObjCodeName;
            cZoneName128.Text = SelectedTeleport.m_ZoneName128;
            cRegionID.Text = SelectedTeleport.m_GenRegionID.ToString();
            cPosX.Text = SelectedTeleport.m_GenPos_X.ToString();
            cPosY.Text = SelectedTeleport.m_GenPos_Y.ToString();
            cPosZ.Text = SelectedTeleport.m_GenPos_Z.ToString();
            cBindInteractionMask.Text = SelectedTeleport.m_BindInteractionMask.ToString();
            cFixedService.Text = SelectedTeleport.m_FixedService.ToString();
            cCanBeReturnPoint.Checked = SelectedTeleport.m_CanBeResurrectPos;
            cCanGoResurrectPoint.Checked = SelectedTeleport.m_CanBeGotoResurrectPos;

        }

        private void TeleportForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(async () => await GetTeleportCodeNames());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void cSaveButton_Click(object sender, EventArgs e)
        {

        }

        private void cPortalList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(cPortalList.SelectedIndex>-1)
            {
                SelectedTeleport = new CTeleport(cPortalList.SelectedItem.ToString());
                ParseSelectedTeleport();
            }
        }
    }
}