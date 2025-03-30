namespace DVLD
{
    partial class uctrlManageIntApps
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctrlManageIntApps));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewIDLApp = new System.Windows.Forms.Button();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.dgvI_LicensesApps = new System.Windows.Forms.DataGridView();
            this.cmsManageIntLicenseApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowPersonLHis = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvI_LicensesApps)).BeginInit();
            this.cmsManageIntLicenseApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbIsActive
            // 
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(416, 44);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(146, 33);
            this.cbIsActive.TabIndex = 23;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 32);
            this.label2.TabIndex = 21;
            this.label2.Text = "#Records : ";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(416, 44);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(246, 33);
            this.txtFilter.TabIndex = 20;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filter By";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "I license ID",
            "App ID",
            "L License ID",
            "Driver ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(174, 44);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(225, 33);
            this.cbFilterBy.TabIndex = 18;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnAddNewIDLApp
            // 
            this.btnAddNewIDLApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewIDLApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAddNewIDLApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewIDLApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewIDLApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewIDLApp.Image")));
            this.btnAddNewIDLApp.Location = new System.Drawing.Point(1206, 10);
            this.btnAddNewIDLApp.Name = "btnAddNewIDLApp";
            this.btnAddNewIDLApp.Size = new System.Drawing.Size(96, 90);
            this.btnAddNewIDLApp.TabIndex = 17;
            this.btnAddNewIDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewIDLApp.Click += new System.EventHandler(this.btnAddNewIDLApp_Click);
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(193, 413);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(48, 32);
            this.lblNumOfRecords.TabIndex = 22;
            this.lblNumOfRecords.Text = "??";
            // 
            // dgvI_LicensesApps
            // 
            this.dgvI_LicensesApps.AllowUserToAddRows = false;
            this.dgvI_LicensesApps.AllowUserToDeleteRows = false;
            this.dgvI_LicensesApps.AllowUserToOrderColumns = true;
            this.dgvI_LicensesApps.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvI_LicensesApps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvI_LicensesApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvI_LicensesApps.ContextMenuStrip = this.cmsManageIntLicenseApps;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvI_LicensesApps.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvI_LicensesApps.Location = new System.Drawing.Point(5, 106);
            this.dgvI_LicensesApps.MultiSelect = false;
            this.dgvI_LicensesApps.Name = "dgvI_LicensesApps";
            this.dgvI_LicensesApps.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvI_LicensesApps.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvI_LicensesApps.RowHeadersWidth = 51;
            this.dgvI_LicensesApps.RowTemplate.Height = 24;
            this.dgvI_LicensesApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvI_LicensesApps.Size = new System.Drawing.Size(1297, 295);
            this.dgvI_LicensesApps.TabIndex = 16;
            // 
            // cmsManageIntLicenseApps
            // 
            this.cmsManageIntLicenseApps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageIntLicenseApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowPersonDetails,
            this.tsmShowLicenseInfo,
            this.tsmShowPersonLHis});
            this.cmsManageIntLicenseApps.Name = "contextMenuStrip1";
            this.cmsManageIntLicenseApps.Size = new System.Drawing.Size(327, 194);
            // 
            // tsmShowPersonDetails
            // 
            this.tsmShowPersonDetails.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowPersonDetails.Image")));
            this.tsmShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonDetails.Name = "tsmShowPersonDetails";
            this.tsmShowPersonDetails.Size = new System.Drawing.Size(326, 54);
            this.tsmShowPersonDetails.Text = "Show Person Details";
            this.tsmShowPersonDetails.Click += new System.EventHandler(this.tsmShowPersonDetails_Click);
            // 
            // tsmShowLicenseInfo
            // 
            this.tsmShowLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowLicenseInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowLicenseInfo.Image")));
            this.tsmShowLicenseInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowLicenseInfo.Name = "tsmShowLicenseInfo";
            this.tsmShowLicenseInfo.Size = new System.Drawing.Size(326, 54);
            this.tsmShowLicenseInfo.Text = "Show License Info";
            this.tsmShowLicenseInfo.Click += new System.EventHandler(this.tsmShowLicenseInfo_Click);
            // 
            // tsmShowPersonLHis
            // 
            this.tsmShowPersonLHis.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonLHis.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowPersonLHis.Image")));
            this.tsmShowPersonLHis.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonLHis.Name = "tsmShowPersonLHis";
            this.tsmShowPersonLHis.Size = new System.Drawing.Size(326, 54);
            this.tsmShowPersonLHis.Text = "Show Person License History";
            this.tsmShowPersonLHis.Click += new System.EventHandler(this.tsmShowPersonLHis_Click);
            // 
            // uctrlManageIntApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnAddNewIDLApp);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.dgvI_LicensesApps);
            this.Name = "uctrlManageIntApps";
            this.Size = new System.Drawing.Size(1307, 454);
            this.Load += new System.EventHandler(this.uctrlManageIntApps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvI_LicensesApps)).EndInit();
            this.cmsManageIntLicenseApps.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnAddNewIDLApp;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.DataGridView dgvI_LicensesApps;
        private System.Windows.Forms.ContextMenuStrip cmsManageIntLicenseApps;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLHis;
    }
}
