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
using DevExpress.Utils.Extensions;

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
            HashSet<string> codenames = await CTeleport.GetTeleportCodeNames();
            codenames.ForEach(codename =>
            {

                if (cPortalList.InvokeRequired)
                    cPortalList.BeginInvoke((Action)(() => cPortalList.Items.Add(codename)));
                else
                    cPortalList.Items.Add(codename);
            });            
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
            cWorldList.SelectedItem = Globals.GameWorldList[SelectedTeleport.m_GenWorldID];
            cGenAreaRadius.Text = SelectedTeleport.m_GenAreaRadius.ToString();

        }

        private void TeleportForm_Load(object sender, EventArgs e)
        {
            Globals.GameWorldList.ForEach(gw => cWorldList.Properties.Items.Add(gw.Value));
            Task.Factory.StartNew(async () => await GetTeleportCodeNames());
            ChangeStatus(false);
        }



        private void cSaveButton_Click(object sender, EventArgs e)
        {

            if (cCodeName128.Text.Length > 0 &&
                cWorldList.SelectedIndex > -1 &&
                cRegionID.Text.Length > 0 &&
                cPosX.Text.Length > 0 &&
                cPosY.Text.Length > 0 &&
                cPosZ.Text.Length > 0 &&
                cGenAreaRadius.Text.Length > 0 &&
                cBindInteractionMask.Text.Length > 0 &&
                cFixedService.Text.Length > 0)
            {
                if (MessageBox.Show("Are you sure that you want to save changes to database?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SelectedTeleport.m_Status == EditStatus.New)
                    {

                        if (CTeleport.IsExistsTeleport(cCodeName128.Text))
                        {
                            MessageBox.Show("A Teleport already exists with that codename, try again!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }

                    SelectedTeleport.m_Service = cService.Checked ? 1 : 0;
                    SelectedTeleport.m_CodeName128 = cCodeName128.Text.Trim();
                    SelectedTeleport.m_AssocRefObjCodeName = cAssocObjectName.Text.Length > 0 ? cAssocObjectName.Text : "xxx";
                    SelectedTeleport.m_ZoneName128 = cZoneName128.Text.Length > 0 ? cZoneName128.Text : "xxx";
                    SelectedTeleport.m_GenWorldID = (short)Globals.GameWorldIDList[cWorldList.SelectedItem.ToString()];
                    SelectedTeleport.m_GenRegionID = Convert.ToInt16(cRegionID.Text);
                    SelectedTeleport.m_GenPos_X = Convert.ToInt16(cPosX.Text);
                    SelectedTeleport.m_GenPos_Y = Convert.ToInt16(cPosY.Text);
                    SelectedTeleport.m_GenPos_Z = Convert.ToInt16(cPosZ.Text);
                    SelectedTeleport.m_GenAreaRadius = Convert.ToInt16(cGenAreaRadius.Text);
                    SelectedTeleport.m_BindInteractionMask = Convert.ToByte(cBindInteractionMask.Text);
                    SelectedTeleport.m_FixedService = Convert.ToByte(cFixedService.Text);
                    SelectedTeleport.m_CanBeResurrectPos = cCanBeReturnPoint.Checked;
                    SelectedTeleport.m_CanBeGotoResurrectPos = cCanGoResurrectPoint.Checked;

                    if (SelectedTeleport.m_Status != EditStatus.New)
                        SelectedTeleport.m_Status = EditStatus.Edited;

                    SelectedTeleport.SaveToDatabase();
                    CTeleportBase.SaveToClient("teleportdata.txt");
                    MessageBox.Show("Your changes is successfully saved!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("All fields cannot be empty!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void ChangeStatus(bool s)
        {
            cDetailLayoutPanel.Enabled = s;
            cCancelButton.Enabled = s;
            cNewPortalButton.Enabled = !s;
            cRemoveButton.Enabled = SelectedTeleport.m_Status != EditStatus.New;
            cPortalList.Enabled = !s;

        }
        private void ClearControls()
        {
            cService.Checked = false;
            cID.Text = string.Empty;
            cCodeName128.Text = string.Empty;
            cAssocObjectName.Text = string.Empty;
            cZoneName128.Text = string.Empty;
            cWorldList.Text = string.Empty;
            cRegionID.Text = string.Empty;
            cPosX.Text = string.Empty;
            cPosY.Text = string.Empty;
            cPosZ.Text = string.Empty;
            cBindInteractionMask.Text = "1";
            cFixedService.Text = "0";
            cCanBeReturnPoint.Checked = false;
            cGenAreaRadius.Text = string.Empty;
            cCanGoResurrectPoint.Checked = false;
        }
        private void cPortalList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(cPortalList.SelectedIndex>-1)
            {
                SelectedTeleport = new CTeleport(cPortalList.SelectedItem.ToString());
                ParseSelectedTeleport();
                ChangeStatus(true);
            }
        }

        private void cCancelButton_Click(object sender, EventArgs e)
        {
            ClearControls();
            ChangeStatus(false);
        }

        private void cNewPortalButton_Click(object sender, EventArgs e)
        {
            SelectedTeleport = new CTeleport(EditStatus.New);
            ClearControls();
            ChangeStatus(true);
            cService.Checked = true;
            cCodeName128.Text = "GATE_";
        }

        private void cRemoveButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Are you sure that you want to permamently delete {cCodeName128.Text} portal?","WARNING!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                SelectedTeleport.m_Status = EditStatus.Removed;
                SelectedTeleport.SaveToDatabase();
                ClearControls();
                cPortalList.Items.Remove(SelectedTeleport.m_CodeName128);
                ChangeStatus(false);
            }
        }
    }
}