namespace DVLD
{
    partial class frmLicensesHistory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicensesHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.dgvLDLS = new System.Windows.Forms.DataGridView();
            this.cmsManageLDL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInternational = new System.Windows.Forms.TabPage();
            this.dgvI_Licenses = new System.Windows.Forms.DataGridView();
            this.cmsManageIDL = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowILicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.uctrlPersonalDetails1 = new DVLD.uctrlPersonalDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tb.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLS)).BeginInit();
            this.cmsManageLDL.SuspendLayout();
            this.tbInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvI_Licenses)).BeginInit();
            this.cmsManageIDL.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(611, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Licenses History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 289);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 276);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tb
            // 
            this.tb.Controls.Add(this.tpLocal);
            this.tb.Controls.Add(this.tbInternational);
            this.tb.Location = new System.Drawing.Point(12, 592);
            this.tb.Name = "tb";
            this.tb.SelectedIndex = 0;
            this.tb.Size = new System.Drawing.Size(1484, 202);
            this.tb.TabIndex = 3;
            // 
            // tpLocal
            // 
            this.tpLocal.BackColor = System.Drawing.Color.White;
            this.tpLocal.Controls.Add(this.dgvLDLS);
            this.tpLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpLocal.Location = new System.Drawing.Point(4, 25);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1476, 173);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            // 
            // dgvLDLS
            // 
            this.dgvLDLS.AllowUserToAddRows = false;
            this.dgvLDLS.AllowUserToDeleteRows = false;
            this.dgvLDLS.AllowUserToOrderColumns = true;
            this.dgvLDLS.BackgroundColor = System.Drawing.Color.White;
            this.dgvLDLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLS.ContextMenuStrip = this.cmsManageLDL;
            this.dgvLDLS.Location = new System.Drawing.Point(6, 8);
            this.dgvLDLS.MultiSelect = false;
            this.dgvLDLS.Name = "dgvLDLS";
            this.dgvLDLS.ReadOnly = true;
            this.dgvLDLS.RowHeadersWidth = 51;
            this.dgvLDLS.RowTemplate.Height = 24;
            this.dgvLDLS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLDLS.Size = new System.Drawing.Size(1464, 156);
            this.dgvLDLS.TabIndex = 2;
            // 
            // cmsManageLDL
            // 
            this.cmsManageLDL.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageLDL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowLicenseDetails});
            this.cmsManageLDL.Name = "cmsManageLDL";
            this.cmsManageLDL.Size = new System.Drawing.Size(328, 58);
            // 
            // tsmShowLicenseDetails
            // 
            this.tsmShowLicenseDetails.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowLicenseDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowLicenseDetails.Image")));
            this.tsmShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowLicenseDetails.Name = "tsmShowLicenseDetails";
            this.tsmShowLicenseDetails.Size = new System.Drawing.Size(327, 54);
            this.tsmShowLicenseDetails.Text = "Show License Details";
            this.tsmShowLicenseDetails.Click += new System.EventHandler(this.tsmShowLicenseDetails_Click);
            // 
            // tbInternational
            // 
            this.tbInternational.BackColor = System.Drawing.Color.White;
            this.tbInternational.Controls.Add(this.dgvI_Licenses);
            this.tbInternational.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInternational.Location = new System.Drawing.Point(4, 25);
            this.tbInternational.Name = "tbInternational";
            this.tbInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternational.Size = new System.Drawing.Size(1476, 173);
            this.tbInternational.TabIndex = 1;
            this.tbInternational.Text = "International";
            // 
            // dgvI_Licenses
            // 
            this.dgvI_Licenses.AllowUserToAddRows = false;
            this.dgvI_Licenses.AllowUserToDeleteRows = false;
            this.dgvI_Licenses.AllowUserToOrderColumns = true;
            this.dgvI_Licenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvI_Licenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvI_Licenses.ContextMenuStrip = this.cmsManageIDL;
            this.dgvI_Licenses.Location = new System.Drawing.Point(6, 8);
            this.dgvI_Licenses.MultiSelect = false;
            this.dgvI_Licenses.Name = "dgvI_Licenses";
            this.dgvI_Licenses.ReadOnly = true;
            this.dgvI_Licenses.RowHeadersWidth = 51;
            this.dgvI_Licenses.RowTemplate.Height = 24;
            this.dgvI_Licenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvI_Licenses.Size = new System.Drawing.Size(1464, 156);
            this.dgvI_Licenses.TabIndex = 3;
            // 
            // cmsManageIDL
            // 
            this.cmsManageIDL.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageIDL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowILicenseDetails});
            this.cmsManageIDL.Name = "cmsManageIDL";
            this.cmsManageIDL.Size = new System.Drawing.Size(291, 58);
            // 
            // tsmShowILicenseDetails
            // 
            this.tsmShowILicenseDetails.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowILicenseDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowILicenseDetails.Image")));
            this.tsmShowILicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowILicenseDetails.Name = "tsmShowILicenseDetails";
            this.tsmShowILicenseDetails.Size = new System.Drawing.Size(290, 54);
            this.tsmShowILicenseDetails.Text = "Show LicenseInfo";
            this.tsmShowILicenseDetails.Click += new System.EventHandler(this.tsmShowILicenseDetails_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1317, 787);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(179, 48);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // uctrlPersonalDetails1
            // 
            this.uctrlPersonalDetails1.BackColor = System.Drawing.Color.White;
            this.uctrlPersonalDetails1.Location = new System.Drawing.Point(297, 70);
            this.uctrlPersonalDetails1.Name = "uctrlPersonalDetails1";
            this.uctrlPersonalDetails1.Size = new System.Drawing.Size(1199, 503);
            this.uctrlPersonalDetails1.TabIndex = 0;
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1508, 833);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uctrlPersonalDetails1);
            this.Name = "frmLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLicensesHistory";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tb.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLS)).EndInit();
            this.cmsManageLDL.ResumeLayout(false);
            this.tbInternational.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvI_Licenses)).EndInit();
            this.cmsManageIDL.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uctrlPersonalDetails uctrlPersonalDetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tb;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tbInternational;
        private System.Windows.Forms.DataGridView dgvLDLS;
        private System.Windows.Forms.DataGridView dgvI_Licenses;
        private System.Windows.Forms.ContextMenuStrip cmsManageLDL;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseDetails;
        private System.Windows.Forms.ContextMenuStrip cmsManageIDL;
        private System.Windows.Forms.ToolStripMenuItem tsmShowILicenseDetails;
        private System.Windows.Forms.Button btnClose;
    }
}