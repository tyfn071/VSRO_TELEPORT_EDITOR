using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace VSRO_TELEPORT_EDITOR
{
    public partial class OptTeleportForm : XtraForm
    {
        public OptTeleportForm()
        {
            InitializeComponent();
        }

        private void cSaveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to save changes to database?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<DataGridViewRow> rows = cTpGrid.Rows.Cast<DataGridViewRow>().ToList();
                _ = rows.Concat(RemovedRows).ToList();

                rows.ForEach(row =>
                {
                    COptionalTeleport tp = new COptionalTeleport();

                    tp.m_Service = bool.Parse(row.Cells[0].Value.ToString()) ? (byte)1 : (byte)0;
                    tp.m_ID = Convert.ToInt32(row.Cells[1].Value);
                    tp.m_ObjName128 = row.Cells[2].Value.ToString();
                    tp.m_ZoneName128 = row.Cells[3].Value.ToString();
                    tp.m_GenRegionID = Convert.ToInt16(row.Cells[4].Value);
                    tp.m_GenPos_X = Convert.ToInt16(row.Cells[5].Value);
                    tp.m_GenPos_Y = Convert.ToInt16(row.Cells[6].Value);
                    tp.m_GenPos_Z = Convert.ToInt16(row.Cells[7].Value);
                    tp.m_GenWorldID = (short)Globals.GameWorldIDList[row.Cells[8].Value.ToString()];
                    tp.m_RegionIDGroup = Convert.ToInt32(row.Cells[9].Value);
                    tp.m_MapPoint = bool.Parse(row.Cells[10].Value.ToString()) ? (byte)1 : (byte)0;
                    tp.m_LevelMin = Convert.ToInt16(row.Cells[11].Value);
                    tp.m_LevelMax = Convert.ToInt16(row.Cells[12].Value);
                    tp.m_Status = (EditStatus)row.Tag;

                    if (tp.m_Status == EditStatus.New)
                        tp.m_ID = row.Index;

                    tp.SaveToDatabase();

                    if ((EditStatus)row.Tag != EditStatus.Removed)
                    {
                        row.Tag = EditStatus.Notr;
                        row.Cells[1].Value = tp.m_ID;
                    }
                        

                });
                RemovedRows.Clear();
                CTeleportBase.SaveToClient("refoptionalteleport.txt");
                MessageBox.Show("Your changes is successfully saved!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                

            
        }

        private void AddRowToGrid(COptionalTeleport tp)
        {
            int idx = cTpGrid.Rows.Add();
            DataGridViewRow row = cTpGrid.Rows[idx];
            row.Cells[0].Value = tp.m_Service == 1;
            row.Cells[1].Value = tp.m_ID;
            row.Cells[2].Value = tp.m_ObjName128;
            row.Cells[3].Value = tp.m_ZoneName128;
            row.Cells[4].Value = tp.m_GenRegionID;
            row.Cells[5].Value = tp.m_GenPos_X;
            row.Cells[6].Value = tp.m_GenPos_Y;
            row.Cells[7].Value = tp.m_GenPos_Z;
            row.Cells[8].Value = Globals.GameWorldList[tp.m_GenWorldID];
            row.Cells[9].Value = tp.m_RegionIDGroup;
            row.Cells[10].Value = tp.m_MapPoint == 1;
            row.Cells[11].Value = tp.m_LevelMin;
            row.Cells[12].Value = tp.m_LevelMax;
            row.Tag = tp.m_Status;
        }
        private async void LoadTeleports()
        {
            List<COptionalTeleport> tpList = await COptionalTeleport.GetCOptionalTeleports();

            tpList.ForEach(tp =>
            {
                if (cTpGrid.InvokeRequired)
                    cTpGrid.BeginInvoke((Action)(() => AddRowToGrid(tp)));
                else
                    AddRowToGrid(tp);
            });
        }
        private void OptTeleportForm_Load(object sender, EventArgs e)
        {
            cTpGrid.DefaultCellStyle.ForeColor = Color.Black;
            Globals.SetDataGridComboBoxColumn(8, (from i in Globals.GameWorldList select i.Value).ToList(), cTpGrid);
            Task.Factory.StartNew(() =>LoadTeleports());
        }

        private void cAddButton_Click(object sender, EventArgs e)
        {
            int idx = cTpGrid.Rows.Add();
            DataGridViewRow row = cTpGrid.Rows[idx];
            row.Tag = EditStatus.New;
            row.Cells[0].Value = true;
            row.Cells[8].Value = "INS_DEFAULT";
            row.Cells[11].Value = 0;
            row.Cells[12].Value = 0;
            cTpGrid.FirstDisplayedScrollingRowIndex = cTpGrid.RowCount - 1;
        }
        List<DataGridViewRow> RemovedRows = new List<DataGridViewRow>();
        private void cRemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to permamently delete selected rows?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in cTpGrid.SelectedRows)
                {
                    if ((EditStatus)row.Tag != EditStatus.New)
                    {
                        row.Tag = EditStatus.Removed;
                        RemovedRows.Add(row);
                    }
                    cTpGrid.Rows.Remove(row);
                }
            }
        }

        private void cTpGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((EditStatus)cTpGrid.Rows[e.RowIndex].Tag != EditStatus.New)
                cTpGrid.Rows[e.RowIndex].Tag = EditStatus.Edited;
        }
    }
}