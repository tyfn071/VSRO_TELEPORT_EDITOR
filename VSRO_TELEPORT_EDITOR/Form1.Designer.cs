namespace VSRO_TELEPORT_EDITOR
{
    partial class Form1
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
            this.cLogPanel = new DevExpress.XtraEditors.PanelControl();
            this.cLefPanel = new DevExpress.XtraEditors.PanelControl();
            this.cMainPanel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cLogPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLefPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // cLogPanel
            // 
            this.cLogPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cLogPanel.Location = new System.Drawing.Point(0, 458);
            this.cLogPanel.Name = "cLogPanel";
            this.cLogPanel.Size = new System.Drawing.Size(1065, 153);
            this.cLogPanel.TabIndex = 0;
            // 
            // cLefPanel
            // 
            this.cLefPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.cLefPanel.Location = new System.Drawing.Point(0, 0);
            this.cLefPanel.Name = "cLefPanel";
            this.cLefPanel.Size = new System.Drawing.Size(257, 458);
            this.cLefPanel.TabIndex = 1;
            // 
            // cMainPanel
            // 
            this.cMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cMainPanel.Location = new System.Drawing.Point(257, 0);
            this.cMainPanel.Name = "cMainPanel";
            this.cMainPanel.Size = new System.Drawing.Size(808, 458);
            this.cMainPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 611);
            this.Controls.Add(this.cMainPanel);
            this.Controls.Add(this.cLefPanel);
            this.Controls.Add(this.cLogPanel);
            this.Name = "Form1";
            this.Text = "Vsro Teleport Editor v1.0";
            ((System.ComponentModel.ISupportInitialize)(this.cLogPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLefPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cMainPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl cLogPanel;
        private DevExpress.XtraEditors.PanelControl cLefPanel;
        private DevExpress.XtraEditors.PanelControl cMainPanel;
    }
}

