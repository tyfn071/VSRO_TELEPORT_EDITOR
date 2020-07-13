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

namespace VSRO_TELEPORT_EDITOR
{
    public partial class TeleportLinkForm : DevExpress.XtraEditors.XtraForm
    {
        public TeleportLinkForm()
        {
            InitializeComponent();
        }
        private async Task LoadGridLines()
        {
            _linkgrid.Columns.Add(new DataGridViewCheckBoxColumn { Name = "TService", HeaderText = "Active", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Owner", HeaderText = "Main Portal", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "OwnerName", HeaderText = "Name", Visible = true, ReadOnly = true });
            _linkgrid.Columns.Add(new DataGridViewComboBoxColumn { Name = "Target", HeaderText = "Target Portal", Visible = true, ReadOnly = false });
            _linkgrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TargetName", HeaderText = "Name", Visible = true, ReadOnly = true });
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

            _linkgrid.Columns[6].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[7].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[8].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

            _linkgrid.Columns[9].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[10].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[11].DefaultCellStyle.BackColor = Color.PaleGreen;

            _linkgrid.Columns[12].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[13].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[14].DefaultCellStyle.BackColor = Color.PaleGoldenrod;

            _linkgrid.Columns[15].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[16].DefaultCellStyle.BackColor = Color.PaleGreen;
            _linkgrid.Columns[17].DefaultCellStyle.BackColor = Color.PaleGreen;

            _linkgrid.Columns[18].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[19].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            _linkgrid.Columns[20].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
        }
        private void TeleportLinkForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(async () => await LoadGridLines());
        }
    }
}