namespace DVLD
{
    partial class uctrlManageNewLDLApps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctrlManageNewLDLApps));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAddNewLDLApp = new System.Windows.Forms.Button();
            this.tsmIssueDLFT = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.tsmScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowAppDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsManagePerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowPersonLHis = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLDLApps = new System.Windows.Forms.DataGridView();
            this.cmsManagePerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Complated",
            "Canceld"});
            this.cbStatus.Location = new System.Drawing.Point(414, 44);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(146, 33);
            this.cbStatus.TabIndex = 15;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "#Records : ";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(414, 44);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(246, 33);
            this.txtFilter.TabIndex = 12;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filter By";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L App ID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(172, 44);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(225, 33);
            this.cbFilterBy.TabIndex = 10;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnAddNewLDLApp
            // 
            this.btnAddNewLDLApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewLDLApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAddNewLDLApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewLDLApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLDLApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewLDLApp.Image")));
            this.btnAddNewLDLApp.Location = new System.Drawing.Point(1204, 10);
            this.btnAddNewLDLApp.Name = "btnAddNewLDLApp";
            this.btnAddNewLDLApp.Size = new System.Drawing.Size(96, 90);
            this.btnAddNewLDLApp.TabIndex = 9;
            this.btnAddNewLDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewLDLApp.Click += new System.EventHandler(this.btnAddNewLDLApp_Click);
            // 
            // tsmIssueDLFT
            // 
            this.tsmIssueDLFT.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmIssueDLFT.Image = ((System.Drawing.Image)(resources.GetObject("tsmIssueDLFT.Image")));
            this.tsmIssueDLFT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmIssueDLFT.Name = "tsmIssueDLFT";
            this.tsmIssueDLFT.Size = new System.Drawing.Size(356, 54);
            this.tsmIssueDLFT.Text = "Issue Driving License (First Time)";
            this.tsmIssueDLFT.Click += new System.EventHandler(this.tsmIssueDLFT_Click);
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(191, 413);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(48, 32);
            this.lblNumOfRecords.TabIndex = 14;
            this.lblNumOfRecords.Text = "??";
            // 
            // tsmScheduleTests
            // 
            this.tsmScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmScheduleVisionTest,
            this.tsmScheduleWrittenTest,
            this.tsmScheduleStreetTest});
            this.tsmScheduleTests.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmScheduleTests.Image = ((System.Drawing.Image)(resources.GetObject("tsmScheduleTests.Image")));
            this.tsmScheduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmScheduleTests.Name = "tsmScheduleTests";
            this.tsmScheduleTests.Size = new System.Drawing.Size(356, 54);
            this.tsmScheduleTests.Text = "Schedule Tests";
            // 
            // tsmScheduleVisionTest
            // 
            this.tsmScheduleVisionTest.Image = ((System.Drawing.Image)(resources.GetObject("tsmScheduleVisionTest.Image")));
            this.tsmScheduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmScheduleVisionTest.Name = "tsmScheduleVisionTest";
            this.tsmScheduleVisionTest.Size = new System.Drawing.Size(287, 54);
            this.tsmScheduleVisionTest.Text = "Schedule Vision Test";
            this.tsmScheduleVisionTest.Click += new System.EventHandler(this.tsmScheduleVisionTest_Click);
            // 
            // tsmScheduleWrittenTest
            // 
            this.tsmScheduleWrittenTest.Image = ((System.Drawing.Image)(resources.GetObject("tsmScheduleWrittenTest.Image")));
            this.tsmScheduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmScheduleWrittenTest.Name = "tsmScheduleWrittenTest";
            this.tsmScheduleWrittenTest.Size = new System.Drawing.Size(287, 54);
            this.tsmScheduleWrittenTest.Text = "Schedule Written Test";
            this.tsmScheduleWrittenTest.Click += new System.EventHandler(this.tsmScheduleWrittenTest_Click);
            // 
            // tsmScheduleStreetTest
            // 
            this.tsmScheduleStreetTest.Image = ((System.Drawing.Image)(resources.GetObject("tsmScheduleStreetTest.Image")));
            this.tsmScheduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmScheduleStreetTest.Name = "tsmScheduleStreetTest";
            this.tsmScheduleStreetTest.Size = new System.Drawing.Size(287, 54);
            this.tsmScheduleStreetTest.Text = "Schedule Street Test";
            this.tsmScheduleStreetTest.Click += new System.EventHandler(this.tsmScheduleStreetTest_Click);
            // 
            // tsmCancelApp
            // 
            this.tsmCancelApp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmCancelApp.Image = ((System.Drawing.Image)(resources.GetObject("tsmCancelApp.Image")));
            this.tsmCancelApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCancelApp.Name = "tsmCancelApp";
            this.tsmCancelApp.Size = new System.Drawing.Size(356, 54);
            this.tsmCancelApp.Text = "Cancel Application";
            this.tsmCancelApp.Click += new System.EventHandler(this.tsmCancelApp_Click);
            // 
            // tsmDeleteApp
            // 
            this.tsmDeleteApp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDeleteApp.Image = ((System.Drawing.Image)(resources.GetObject("tsmDeleteApp.Image")));
            this.tsmDeleteApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDeleteApp.Name = "tsmDeleteApp";
            this.tsmDeleteApp.Size = new System.Drawing.Size(356, 54);
            this.tsmDeleteApp.Text = "Delete Application";
            this.tsmDeleteApp.Click += new System.EventHandler(this.tsmDeleteApp_Click);
            // 
            // tsmEditApp
            // 
            this.tsmEditApp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEditApp.Image = ((System.Drawing.Image)(resources.GetObject("tsmEditApp.Image")));
            this.tsmEditApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditApp.Name = "tsmEditApp";
            this.tsmEditApp.Size = new System.Drawing.Size(356, 54);
            this.tsmEditApp.Text = "Edit Application";
            this.tsmEditApp.Click += new System.EventHandler(this.tsmEditApp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(353, 6);
            // 
            // tsmShowAppDetails
            // 
            this.tsmShowAppDetails.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowAppDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowAppDetails.Image")));
            this.tsmShowAppDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowAppDetails.Name = "tsmShowAppDetails";
            this.tsmShowAppDetails.Size = new System.Drawing.Size(356, 54);
            this.tsmShowAppDetails.Text = "Show Applicatoin Details";
            this.tsmShowAppDetails.Click += new System.EventHandler(this.tsmShowAppDetails_Click);
            // 
            // cmsManagePerson
            // 
            this.cmsManagePerson.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManagePerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowAppDetails,
            this.toolStripSeparator1,
            this.tsmEditApp,
            this.tsmDeleteApp,
            this.toolStripSeparator3,
            this.tsmCancelApp,
            this.toolStripSeparator2,
            this.tsmScheduleTests,
            this.toolStripSeparator4,
            this.tsmIssueDLFT,
            this.toolStripSeparator5,
            this.tsmShowLicense,
            this.toolStripSeparator6,
            this.tsmShowPersonLHis});
            this.cmsManagePerson.Name = "contextMenuStrip1";
            this.cmsManagePerson.Size = new System.Drawing.Size(357, 500);
            this.cmsManagePerson.MouseEnter += new System.EventHandler(this.cmsManagePerson_MouseEnter);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(353, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(353, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(353, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(353, 6);
            // 
            // tsmShowLicense
            // 
            this.tsmShowLicense.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowLicense.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowLicense.Image")));
            this.tsmShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowLicense.Name = "tsmShowLicense";
            this.tsmShowLicense.Size = new System.Drawing.Size(356, 54);
            this.tsmShowLicense.Text = "Show License";
            this.tsmShowLicense.Click += new System.EventHandler(this.tsmShowLicense_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(353, 6);
            // 
            // tsmShowPersonLHis
            // 
            this.tsmShowPersonLHis.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonLHis.Image = ((System.Drawing.Image)(resources.GetObject("tsmShowPersonLHis.Image")));
            this.tsmShowPersonLHis.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowPersonLHis.Name = "tsmShowPersonLHis";
            this.tsmShowPersonLHis.Size = new System.Drawing.Size(356, 54);
            this.tsmShowPersonLHis.Text = "Show Person License History";
            this.tsmShowPersonLHis.Click += new System.EventHandler(this.tsmShowPersonLHis_Click);
            // 
            // dgvLDLApps
            // 
            this.dgvLDLApps.AllowUserToAddRows = false;
            this.dgvLDLApps.AllowUserToDeleteRows = false;
            this.dgvLDLApps.AllowUserToOrderColumns = true;
            this.dgvLDLApps.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLDLApps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLDLApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLApps.ContextMenuStrip = this.cmsManagePerson;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLDLApps.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLDLApps.Location = new System.Drawing.Point(3, 106);
            this.dgvLDLApps.MultiSelect = false;
            this.dgvLDLApps.Name = "dgvLDLApps";
            this.dgvLDLApps.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLDLApps.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLDLApps.RowHeadersWidth = 51;
            this.dgvLDLApps.RowTemplate.Height = 24;
            this.dgvLDLApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLDLApps.Size = new System.Drawing.Size(1297, 295);
            this.dgvLDLApps.TabIndex = 8;
            // 
            // uctrlManageNewLDLApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnAddNewLDLApp);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.dgvLDLApps);
            this.Name = "uctrlManageNewLDLApps";
            this.Size = new System.Drawing.Size(1307, 454);
            this.Load += new System.EventHandler(this.uctrlManageLDLApps_Load);
            this.cmsManagePerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnAddNewLDLApp;
        private System.Windows.Forms.ToolStripMenuItem tsmIssueDLFT;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelApp;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteApp;
        private System.Windows.Forms.ToolStripMenuItem tsmEditApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmShowAppDetails;
        private System.Windows.Forms.ContextMenuStrip cmsManagePerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView dgvLDLApps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLHis;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleStreetTest;
    }
}
