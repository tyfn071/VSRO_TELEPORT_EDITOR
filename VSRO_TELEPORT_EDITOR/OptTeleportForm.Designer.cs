namespace VSRO_TELEPORT_EDITOR
{
    partial class OptTeleportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptTeleportForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.cTpGrid = new System.Windows.Forms.DataGridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cSaveButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cAddButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cRemoveButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Service = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjName128 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZoneCodename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pos_X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pos_Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pos_Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorldID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RegionIDGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MapPoint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LevelMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cRemoveButton);
            this.layoutControl1.Controls.Add(this.cAddButton);
            this.layoutControl1.Controls.Add(this.cSaveButton);
            this.layoutControl1.Controls.Add(this.cTpGrid);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(898, 569);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(898, 569);
            this.Root.TextVisible = false;
            // 
            // cTpGrid
            // 
            this.cTpGrid.AllowUserToAddRows = false;
            this.cTpGrid.AllowUserToDeleteRows = false;
            this.cTpGrid.AllowUserToResizeColumns = false;
            this.cTpGrid.AllowUserToResizeRows = false;
            this.cTpGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.cTpGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cTpGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.cTpGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cTpGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Service,
            this.ID,
            this.ObjName128,
            this.ZoneName,
            this.ZoneCodename,
            this.RegionID,
            this.Pos_X,
            this.Pos_Y,
            this.Pos_Z,
            this.WorldID,
            this.RegionIDGroup,
            this.MapPoint,
            this.LevelMin,
            this.LevelMax});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cTpGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.cTpGrid.Location = new System.Drawing.Point(12, 12);
            this.cTpGrid.Name = "cTpGrid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cTpGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.cTpGrid.Size = new System.Drawing.Size(874, 505);
            this.cTpGrid.TabIndex = 6;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cTpGrid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(878, 509);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // cSaveButton
            // 
            this.cSaveButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.cSaveButton.Location = new System.Drawing.Point(12, 521);
            this.cSaveButton.Name = "cSaveButton";
            this.cSaveButton.Size = new System.Drawing.Size(208, 36);
            this.cSaveButton.StyleController = this.layoutControl1;
            this.cSaveButton.TabIndex = 7;
            this.cSaveButton.Text = "Save Changes";
            this.cSaveButton.Click += new System.EventHandler(this.cSaveButton_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cSaveButton;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 509);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(212, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // cAddButton
            // 
            this.cAddButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.cAddButton.Location = new System.Drawing.Point(713, 521);
            this.cAddButton.Name = "cAddButton";
            this.cAddButton.Size = new System.Drawing.Size(73, 36);
            this.cAddButton.StyleController = this.layoutControl1;
            this.cAddButton.TabIndex = 8;
            this.cAddButton.Text = "Add";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cAddButton;
            this.layoutControlItem3.Location = new System.Drawing.Point(701, 509);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(77, 40);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // cRemoveButton
            // 
            this.cRemoveButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.cRemoveButton.Location = new System.Drawing.Point(790, 521);
            this.cRemoveButton.Name = "cRemoveButton";
            this.cRemoveButton.Size = new System.Drawing.Size(96, 36);
            this.cRemoveButton.StyleController = this.layoutControl1;
            this.cRemoveButton.TabIndex = 9;
            this.cRemoveButton.Text = "Remove";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cRemoveButton;
            this.layoutControlItem4.Location = new System.Drawing.Point(778, 509);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(100, 40);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(212, 509);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(489, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Service
            // 
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            this.Service.Width = 49;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // ObjName128
            // 
            this.ObjName128.HeaderText = "ObjName";
            this.ObjName128.Name = "ObjName128";
            this.ObjName128.Width = 76;
            // 
            // ZoneName
            // 
            this.ZoneName.HeaderText = "Zone Name";
            this.ZoneName.Name = "ZoneName";
            this.ZoneName.ReadOnly = true;
            this.ZoneName.Width = 88;
            // 
            // ZoneCodename
            // 
            this.ZoneCodename.HeaderText = "Zone Codename";
            this.ZoneCodename.Name = "ZoneCodename";
            this.ZoneCodename.Width = 102;
            // 
            // RegionID
            // 
            this.RegionID.HeaderText = "Region ID";
            this.RegionID.Name = "RegionID";
            this.RegionID.Width = 74;
            // 
            // Pos_X
            // 
            this.Pos_X.HeaderText = "X";
            this.Pos_X.Name = "Pos_X";
            this.Pos_X.Width = 39;
            // 
            // Pos_Y
            // 
            this.Pos_Y.HeaderText = "Y";
            this.Pos_Y.Name = "Pos_Y";
            this.Pos_Y.Width = 39;
            // 
            // Pos_Z
            // 
            this.Pos_Z.HeaderText = "Z";
            this.Pos_Z.Name = "Pos_Z";
            this.Pos_Z.Width = 39;
            // 
            // WorldID
            // 
            this.WorldID.HeaderText = "World ID";
            this.WorldID.Name = "WorldID";
            this.WorldID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WorldID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WorldID.Width = 69;
            // 
            // RegionIDGroup
            // 
            this.RegionIDGroup.HeaderText = "Region Group";
            this.RegionIDGroup.Name = "RegionIDGroup";
            this.RegionIDGroup.Width = 90;
            // 
            // MapPoint
            // 
            this.MapPoint.HeaderText = "Map Point";
            this.MapPoint.Name = "MapPoint";
            this.MapPoint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MapPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MapPoint.Width = 74;
            // 
            // LevelMin
            // 
            this.LevelMin.HeaderText = "Min Level";
            this.LevelMin.Name = "LevelMin";
            this.LevelMin.Width = 72;
            // 
            // LevelMax
            // 
            this.LevelMax.HeaderText = "Max Level";
            this.LevelMax.Name = "LevelMax";
            this.LevelMax.Width = 75;
            // 
            // OptTeleportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 569);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptTeleportForm";
            this.Text = "Reverse Scroll Points";
            this.Load += new System.EventHandler(this.OptTeleportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cTpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton cRemoveButton;
        private DevExpress.XtraEditors.SimpleButton cAddButton;
        private DevExpress.XtraEditors.SimpleButton cSaveButton;
        private System.Windows.Forms.DataGridView cTpGrid;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjName128;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZoneName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZoneCodename;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos_X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos_Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pos_Z;
        private System.Windows.Forms.DataGridViewComboBoxColumn WorldID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionIDGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MapPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelMax;
    }
}