﻿namespace VSRO_TELEPORT_EDITOR
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cLogPanel = new DevExpress.XtraEditors.PanelControl();
            this.cLefPanel = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.cAddTeleportButton = new DevExpress.XtraEditors.SimpleButton();
            this.cMainPanel = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cLogPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLefPanel)).BeginInit();
            this.cLefPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cMainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // cLogPanel
            // 
            this.cLogPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cLogPanel.Location = new System.Drawing.Point(0, 509);
            this.cLogPanel.Name = "cLogPanel";
            this.cLogPanel.Size = new System.Drawing.Size(1077, 101);
            this.cLogPanel.TabIndex = 0;
            // 
            // cLefPanel
            // 
            this.cLefPanel.Controls.Add(this.simpleButton4);
            this.cLefPanel.Controls.Add(this.simpleButton3);
            this.cLefPanel.Controls.Add(this.simpleButton2);
            this.cLefPanel.Controls.Add(this.cAddTeleportButton);
            this.cLefPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.cLefPanel.Location = new System.Drawing.Point(0, 0);
            this.cLefPanel.Name = "cLefPanel";
            this.cLefPanel.Size = new System.Drawing.Size(179, 509);
            this.cLefPanel.TabIndex = 1;
            // 
            // simpleButton4
            // 
            this.simpleButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.simpleButton4.Location = new System.Drawing.Point(5, 330);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(168, 48);
            this.simpleButton4.TabIndex = 3;
            this.simpleButton4.Text = "Settings";
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(5, 266);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(168, 48);
            this.simpleButton3.TabIndex = 2;
            this.simpleButton3.Text = "Reverse Scroll Points";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(5, 203);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(168, 48);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Teleport Links";
            // 
            // cAddTeleportButton
            // 
            this.cAddTeleportButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.cAddTeleportButton.Location = new System.Drawing.Point(5, 140);
            this.cAddTeleportButton.Name = "cAddTeleportButton";
            this.cAddTeleportButton.Size = new System.Drawing.Size(168, 48);
            this.cAddTeleportButton.TabIndex = 0;
            this.cAddTeleportButton.Text = "Add-Edit Teleport";
            this.cAddTeleportButton.Click += new System.EventHandler(this.cAddTeleportButton_Click);
            // 
            // cMainPanel
            // 
            this.cMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cMainPanel.Location = new System.Drawing.Point(179, 0);
            this.cMainPanel.Name = "cMainPanel";
            this.cMainPanel.Size = new System.Drawing.Size(898, 509);
            this.cMainPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 610);
            this.Controls.Add(this.cMainPanel);
            this.Controls.Add(this.cLefPanel);
            this.Controls.Add(this.cLogPanel);
            this.Name = "MainForm";
            this.Text = "Vsro Teleport Editor v1.0";
            ((System.ComponentModel.ISupportInitialize)(this.cLogPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLefPanel)).EndInit();
            this.cLefPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cMainPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl cLogPanel;
        private DevExpress.XtraEditors.PanelControl cLefPanel;
        private DevExpress.XtraEditors.PanelControl cMainPanel;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton cAddTeleportButton;
    }
}
