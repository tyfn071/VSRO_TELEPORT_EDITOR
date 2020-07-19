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
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace VSRO_TELEPORT_EDITOR
{
    public partial class TeleportLinkForm : DevExpress.XtraEditors.XtraForm
    {
        public TeleportLinkForm()
        {
            InitializeComponent();
        }
        List<DataGridViewRow> RemovedRows = new List<DataGridViewRow>();
        public static string GetRestrictDesc(STeleportRestrict.RestrictType type)
        {
            string sonuc = "";

            switch (type)
            {
                case STeleportRestrict.RestrictType.None:
                    sonuc = "None";
                    break;
                case STeleportRestrict.RestrictType.BlockEnterThiefWithPet:
                    sonuc = "Block Enter to Thief Trade Pet";
                    break;
                case STeleportRestrict.RestrictType.BlockEnterWithJobPet:
                    sonuc = "Block Enter With Job Pet";
                    break;
                case STeleportRestrict.RestrictType.BlockEnterWithJobSuit:
                    sonuc = "Block Enter With Job Suit";
                    break;
                case STeleportRestrict.RestrictType.DeleteItemAfterEnter:
                    sonuc = "Delete Item After Enter";
                    break;
                case STeleportRestrict.RestrictType.LevelLimit:
                    sonuc = "Level Limit";
                    break;
                case STeleportRestrict.RestrictType.NeedItemToEnter:
                    sonuc = "Need Item to Enter";
                    break;
            }

            return sonuc;
        }
        public static STeleportRestrict.RestrictType GetRestrictType(string type)
        {
            STeleportRestrict.RestrictType sonuc = STeleportRestrict.RestrictType.None;

            switch (type)
            {
                case "None":
                    sonuc = STeleportRestrict.RestrictType.None;
                    break;
                case "Block Enter to Thief Trade Pet":
                    sonuc = STeleportRestrict.RestrictType.BlockEnterThiefWithPet;
                    break;
                case "Block Enter With Job Pet":
                    sonuc = STeleportRestrict.RestrictType.BlockEnterWithJobPet;
                    break;
                case "Block Enter With Job Suit":
                    sonuc = STeleportRestrict.RestrictType.BlockEnterWithJobSuit;
                    break;
                case "Delete Item After Enter":
                    sonuc = STeleportRestrict.RestrictType.DeleteItemAfterEnter;
                    break;
                case "Level Limit":
                    sonuc = STeleportRestrict.RestrictType.LevelLimit;
                    break;
                case "Need Item to Enter":
                    sonuc = STeleportRestrict.RestrictType.NeedItemToEnter;
                    break;
            }

            return sonuc;
        }
        private void LoadGridLinesAction()
        {
            _linkgrid.DefaultCellStyle.ForeColor = Color.Black;
            _linkgrid.Columns.Add(new DataGridViewCheckBoxColumn { Name = "TService", HeaderText = "Active", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Owner", HeaderText = "Main Portal", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Target", HeaderText = "Target Portal", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fee", HeaderText = "Fee", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Restrict_1", HeaderText = "Restrict-1", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data1_1", HeaderText = "Value 1", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data1_2", HeaderText = "Value 2", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Restrict_2", HeaderText = "Restrict-2", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data2_1", HeaderText = "Value 1", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data2_2", HeaderText = "Value 2", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Restrict_3", HeaderText = "Restrict-3", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data3_1", HeaderText = "Value 1", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data3_2", HeaderText = "Value 2", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Restrict_4", HeaderText = "Restrict-4", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data4_1", HeaderText = "Value 1", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data4_2", HeaderText = "Value 2", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Restrict_5", HeaderText = "Restrict-5", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data5_1", HeaderText = "Value 1", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Data5_2", HeaderText = "Value 2", Visible = true, ReadOnly = false });

            _linkgrid.Columns[4].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[5].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[6].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

            _linkgrid.Columns[7].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[8].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[9].DefaultCellStyle.BackColor = Color.PaleGreen;

            _linkgrid.Columns[10].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[11].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[12].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

            _linkgrid.Columns[13].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[14].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[15].DefaultCellStyle.BackColor = Color.PaleGreen;

            _linkgrid.Columns[16].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[17].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[18].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

            LoadLinks();
        }


        private async void LoadLinks()
        {
            List<CTeleportLink> linkList = await CTeleportLink.GetTeleportLinks();

            HashSet<string> tpCodeNames = await CTeleport.GetTeleportCodeNames();
            List<string> restrictList = new List<string>() { "None", "Level Limit", "Block Enter With Job Pet", "Need Item to Enter", "Delete Item After Enter", "Block Enter With Job Suit", "Block Enter to Thief Trade Pet" };
            Globals.SetDataGridComboBoxColumn(1, tpCodeNames.ToList(), _linkgrid);
            Globals.SetDataGridComboBoxColumn(2, tpCodeNames.ToList(), _linkgrid);

            Globals.SetDataGridComboBoxColumn(4, restrictList, _linkgrid);
            Globals.SetDataGridComboBoxColumn(7, restrictList, _linkgrid);
            Globals.SetDataGridComboBoxColumn(10, restrictList, _linkgrid);
            Globals.SetDataGridComboBoxColumn(13, restrictList, _linkgrid);
            Globals.SetDataGridComboBoxColumn(16, restrictList, _linkgrid);

            linkList.ForEach(link =>
            {
                
                int i = _linkgrid.Rows.Add(link.m_Service == 1, link.m_OwnerTeleport, link.m_TargetTeleport, link.m_Fee, GetRestrictDesc(link.Restrict1.m_RestrictType),
                        link.Restrict1.m_Data1, link.Restrict1.m_Data2, GetRestrictDesc(link.Restrict2.m_RestrictType), link.Restrict2.m_Data1, link.Restrict2.m_Data2, GetRestrictDesc(link.Restrict3.m_RestrictType),
                        link.Restrict3.m_Data1, link.Restrict3.m_Data2, GetRestrictDesc(link.Restrict4.m_RestrictType), link.Restrict4.m_Data1, link.Restrict4.m_Data2, GetRestrictDesc(link.Restrict5.m_RestrictType),
                        link.Restrict5.m_Data1, link.Restrict5.m_Data2);

                _linkgrid.Rows[i].Cells[1].ReadOnly = true;
                _linkgrid.Rows[i].Cells[2].ReadOnly = true;
                _linkgrid.Rows[i].Tag = link.m_Status;
            });
        }
        private void LoadGridLines()
        {
            
            if(_linkgrid.InvokeRequired)
                _linkgrid.BeginInvoke((Action)LoadGridLinesAction);
            else
                LoadGridLinesAction();           
        }
        private void TeleportLinkForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => LoadGridLines());
            
        }

        private void cSaveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to save changes to database?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                List<DataGridViewRow> rows = _linkgrid.Rows.Cast<DataGridViewRow>().ToList();
                _ = rows.Concat(RemovedRows).ToList();

                rows.ForEach(linkRow =>
                {

                    CTeleportLink link = new CTeleportLink();

                    link.m_Service = bool.Parse(linkRow.Cells[0].Value.ToString()) ? 1 : 0;
                    link.m_OwnerTeleport = linkRow.Cells[1].Value.ToString();
                    link.m_TargetTeleport = linkRow.Cells[2].Value.ToString();
                    link.m_Fee = Convert.ToInt32(linkRow.Cells[3].Value.ToString());
                    link.m_RestrictBindMethod = 0;
                    link.m_RunTimeTeleportMethod = 0;
                    link.m_ChectResult = 0;

                    link.Restrict1 = new STeleportRestrict(GetRestrictType(linkRow.Cells[4].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[5].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[6].Value.ToString()));
                    link.Restrict2 = new STeleportRestrict(GetRestrictType(linkRow.Cells[7].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[8].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[9].Value.ToString()));
                    link.Restrict3 = new STeleportRestrict(GetRestrictType(linkRow.Cells[10].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[11].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[12].Value.ToString()));
                    link.Restrict4 = new STeleportRestrict(GetRestrictType(linkRow.Cells[13].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[14].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[15].Value.ToString()));
                    link.Restrict5 = new STeleportRestrict(GetRestrictType(linkRow.Cells[16].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[17].Value.ToString()),
                        Convert.ToInt32(linkRow.Cells[18].Value.ToString()));

                    link.m_Status = (EditStatus)linkRow.Tag;

                    link.SaveToDatabase();

                    if ((EditStatus)linkRow.Tag != EditStatus.Removed)
                    {
                        linkRow.Cells[1].ReadOnly = true;
                        linkRow.Cells[2].ReadOnly = true;
                        linkRow.Tag = EditStatus.Notr;
                    }
                });

                RemovedRows.Clear();
                CTeleportBase.SaveToClient("teleportlink.txt");
                MessageBox.Show("Your changes is successfully saved!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



            
        }

        private void cAddButton_Click(object sender, EventArgs e)
        {
            int s = _linkgrid.Rows.Add();
            DataGridViewRow row = _linkgrid.Rows[s];

            row.Tag = EditStatus.New;
            row.Cells[0].Value = true;
            row.Cells[3].Value = 0;
            row.Cells[4].Value = "None";
            row.Cells[5].Value = 0;
            row.Cells[6].Value = 0;
            row.Cells[7].Value = "None";
            row.Cells[8].Value = 0;
            row.Cells[9].Value = 0;
            row.Cells[10].Value = "None";
            row.Cells[11].Value = 0;
            row.Cells[12].Value = 0;
            row.Cells[13].Value = "None";
            row.Cells[14].Value = 0;
            row.Cells[15].Value = 0;
            row.Cells[16].Value = "None";
            row.Cells[17].Value = 0;
            row.Cells[18].Value = 0;
            _linkgrid.FirstDisplayedScrollingRowIndex = _linkgrid.RowCount - 1;

        }

        private void cRemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to permamently delete selected rows?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in _linkgrid.SelectedRows)
                {
                    if ((EditStatus)row.Tag != EditStatus.New)
                    {
                        row.Tag = EditStatus.Removed;
                        RemovedRows.Add(row);
                    }
                    _linkgrid.Rows.Remove(row);
                }
            }
                
        }

        private void _linkgrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((EditStatus)_linkgrid.Rows[e.RowIndex].Tag != EditStatus.New)
                _linkgrid.Rows[e.RowIndex].Tag = EditStatus.Edited;
        }
    }
}