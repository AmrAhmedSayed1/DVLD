namespace DVLD
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDrivingLicensesServices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReplaceForLostOrDamaged = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmReleaseDetained = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManageApplciations = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDetainLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManageAppTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTestsTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.poepleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1821, 749);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.poepleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1821, 72);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDrivingLicensesServices,
            this.tsmManageApplciations,
            this.toolStripSeparator1,
            this.tsmDetainLicenses,
            this.tsmManageAppTypes,
            this.tsmTestsTypes});
            this.applicationsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("applicationsToolStripMenuItem.Image")));
            this.applicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(318, 68);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // tsmDrivingLicensesServices
            // 
            this.tsmDrivingLicensesServices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmNewDrivingLicense,
            this.tsmRenewDrivingLicense,
            this.tsmReplaceForLostOrDamaged,
            this.toolStripSeparator2,
            this.tsmReleaseDetained,
            this.tsmRetakeTest});
            this.tsmDrivingLicensesServices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDrivingLicensesServices.Image = ((System.Drawing.Image)(resources.GetObject("tsmDrivingLicensesServices.Image")));
            this.tsmDrivingLicensesServices.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDrivingLicensesServices.Name = "tsmDrivingLicensesServices";
            this.tsmDrivingLicensesServices.Size = new System.Drawing.Size(396, 54);
            this.tsmDrivingLicensesServices.Text = "Driving Licenses Services";
            // 
            // tsmNewDrivingLicense
            // 
            this.tsmNewDrivingLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.tsmNewDrivingLicense.Image = ((System.Drawing.Image)(resources.GetObject("tsmNewDrivingLicense.Image")));
            this.tsmNewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmNewDrivingLicense.Name = "tsmNewDrivingLicense";
            this.tsmNewDrivingLicense.Size = new System.Drawing.Size(511, 38);
            this.tsmNewDrivingLicense.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localLicenseToolStripMenuItem.Image")));
            this.localLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(300, 32);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("internationalLicenseToolStripMenuItem.Image")));
            this.internationalLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(300, 32);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // tsmRenewDrivingLicense
            // 
            this.tsmRenewDrivingLicense.Image = ((System.Drawing.Image)(resources.GetObject("tsmRenewDrivingLicense.Image")));
            this.tsmRenewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmRenewDrivingLicense.Name = "tsmRenewDrivingLicense";
            this.tsmRenewDrivingLicense.Size = new System.Drawing.Size(511, 38);
            this.tsmRenewDrivingLicense.Text = "Renew Driving License";
            this.tsmRenewDrivingLicense.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // tsmReplaceForLostOrDamaged
            // 
            this.tsmReplaceForLostOrDamaged.Image = ((System.Drawing.Image)(resources.GetObject("tsmReplaceForLostOrDamaged.Image")));
            this.tsmReplaceForLostOrDamaged.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmReplaceForLostOrDamaged.Name = "tsmReplaceForLostOrDamaged";
            this.tsmReplaceForLostOrDamaged.Size = new System.Drawing.Size(511, 38);
            this.tsmReplaceForLostOrDamaged.Text = "Replacement For Lost or Damaged License";
            this.tsmReplaceForLostOrDamaged.Click += new System.EventHandler(this.tsmReplaceForLostOrDamaged_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(508, 6);
            // 
            // tsmReleaseDetained
            // 
            this.tsmReleaseDetained.Image = ((System.Drawing.Image)(resources.GetObject("tsmReleaseDetained.Image")));
            this.tsmReleaseDetained.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmReleaseDetained.Name = "tsmReleaseDetained";
            this.tsmReleaseDetained.Size = new System.Drawing.Size(511, 38);
            this.tsmReleaseDetained.Text = "Release Detained Driving License";
            this.tsmReleaseDetained.Click += new System.EventHandler(this.tsmReleaseDetained_Click);
            // 
            // tsmRetakeTest
            // 
            this.tsmRetakeTest.Image = ((System.Drawing.Image)(resources.GetObject("tsmRetakeTest.Image")));
            this.tsmRetakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmRetakeTest.Name = "tsmRetakeTest";
            this.tsmRetakeTest.Size = new System.Drawing.Size(511, 38);
            this.tsmRetakeTest.Text = "Retake Test";
            this.tsmRetakeTest.Click += new System.EventHandler(this.tsmRetakeTest_Click);
            // 
            // tsmManageApplciations
            // 
            this.tsmManageApplciations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicatiToolStripMenuItem,
            this.internationalLicenseApplicationsToolStripMenuItem});
            this.tsmManageApplciations.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmManageApplciations.Image = ((System.Drawing.Image)(resources.GetObject("tsmManageApplciations.Image")));
            this.tsmManageApplciations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmManageApplciations.Name = "tsmManageApplciations";
            this.tsmManageApplciations.Size = new System.Drawing.Size(396, 54);
            this.tsmManageApplciations.Text = "Manage Applications";
            // 
            // localDrivingLicenseApplicatiToolStripMenuItem
            // 
            this.localDrivingLicenseApplicatiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localDrivingLicenseApplicatiToolStripMenuItem.Image")));
            this.localDrivingLicenseApplicatiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localDrivingLicenseApplicatiToolStripMenuItem.Name = "localDrivingLicenseApplicatiToolStripMenuItem";
            this.localDrivingLicenseApplicatiToolStripMenuItem.Size = new System.Drawing.Size(434, 38);
            this.localDrivingLicenseApplicatiToolStripMenuItem.Text = "Local Driving License Applications";
            this.localDrivingLicenseApplicatiToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicatiToolStripMenuItem_Click);
            // 
            // internationalLicenseApplicationsToolStripMenuItem
            // 
            this.internationalLicenseApplicationsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("internationalLicenseApplicationsToolStripMenuItem.Image")));
            this.internationalLicenseApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicenseApplicationsToolStripMenuItem.Name = "internationalLicenseApplicationsToolStripMenuItem";
            this.internationalLicenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(434, 38);
            this.internationalLicenseApplicationsToolStripMenuItem.Text = "International License Applications";
            this.internationalLicenseApplicationsToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseApplicationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(393, 6);
            // 
            // tsmDetainLicenses
            // 
            this.tsmDetainLicenses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicensesToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.releaseDetainLicenseToolStripMenuItem});
            this.tsmDetainLicenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDetainLicenses.Image = ((System.Drawing.Image)(resources.GetObject("tsmDetainLicenses.Image")));
            this.tsmDetainLicenses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDetainLicenses.Name = "tsmDetainLicenses";
            this.tsmDetainLicenses.Size = new System.Drawing.Size(396, 54);
            this.tsmDetainLicenses.Text = "Detain Licenses";
            // 
            // tsmManageAppTypes
            // 
            this.tsmManageAppTypes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmManageAppTypes.Image = ((System.Drawing.Image)(resources.GetObject("tsmManageAppTypes.Image")));
            this.tsmManageAppTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmManageAppTypes.Name = "tsmManageAppTypes";
            this.tsmManageAppTypes.Size = new System.Drawing.Size(396, 54);
            this.tsmManageAppTypes.Text = "Manage Applications Types";
            this.tsmManageAppTypes.Click += new System.EventHandler(this.tsmManageAppTypes_Click);
            // 
            // tsmTestsTypes
            // 
            this.tsmTestsTypes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmTestsTypes.Image = ((System.Drawing.Image)(resources.GetObject("tsmTestsTypes.Image")));
            this.tsmTestsTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmTestsTypes.Name = "tsmTestsTypes";
            this.tsmTestsTypes.Size = new System.Drawing.Size(396, 54);
            this.tsmTestsTypes.Text = "Manage Tests Types";
            this.tsmTestsTypes.Click += new System.EventHandler(this.applicationsTypesToolStripMenuItem_Click);
            // 
            // poepleToolStripMenuItem
            // 
            this.poepleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("poepleToolStripMenuItem.Image")));
            this.poepleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.poepleToolStripMenuItem.Name = "poepleToolStripMenuItem";
            this.poepleToolStripMenuItem.Size = new System.Drawing.Size(219, 68);
            this.poepleToolStripMenuItem.Text = "Poeple";
            this.poepleToolStripMenuItem.Click += new System.EventHandler(this.poepleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("driversToolStripMenuItem.Image")));
            this.driversToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(224, 68);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersToolStripMenuItem.Image")));
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(194, 68);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCurrentUserInfo,
            this.tsmChangePassword,
            this.tsmSignOut});
            this.accountSettingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("accountSettingsToolStripMenuItem.Image")));
            this.accountSettingsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(394, 68);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // tsmCurrentUserInfo
            // 
            this.tsmCurrentUserInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmCurrentUserInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsmCurrentUserInfo.Image")));
            this.tsmCurrentUserInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmCurrentUserInfo.Name = "tsmCurrentUserInfo";
            this.tsmCurrentUserInfo.Size = new System.Drawing.Size(301, 54);
            this.tsmCurrentUserInfo.Text = "Current User Info";
            this.tsmCurrentUserInfo.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // tsmChangePassword
            // 
            this.tsmChangePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("tsmChangePassword.Image")));
            this.tsmChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmChangePassword.Name = "tsmChangePassword";
            this.tsmChangePassword.Size = new System.Drawing.Size(301, 54);
            this.tsmChangePassword.Text = "Change Password";
            this.tsmChangePassword.Click += new System.EventHandler(this.tsmChangePassword_Click);
            // 
            // tsmSignOut
            // 
            this.tsmSignOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmSignOut.Image = ((System.Drawing.Image)(resources.GetObject("tsmSignOut.Image")));
            this.tsmSignOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmSignOut.Name = "tsmSignOut";
            this.tsmSignOut.Size = new System.Drawing.Size(301, 54);
            this.tsmSignOut.Text = "Sign Out";
            this.tsmSignOut.Click += new System.EventHandler(this.tsmSignOut_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 686);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1821, 135);
            this.label1.TabIndex = 3;
            this.label1.Text = "DVLD : Developed By AMR AHMED";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageDetainedLicensesToolStripMenuItem.Image")));
            this.manageDetainedLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(378, 54);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicensesToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("detainLicenseToolStripMenuItem.Image")));
            this.detainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(378, 54);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // releaseDetainLicenseToolStripMenuItem
            // 
            this.releaseDetainLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("releaseDetainLicenseToolStripMenuItem.Image")));
            this.releaseDetainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainLicenseToolStripMenuItem.Name = "releaseDetainLicenseToolStripMenuItem";
            this.releaseDetainLicenseToolStripMenuItem.Size = new System.Drawing.Size(378, 54);
            this.releaseDetainLicenseToolStripMenuItem.Text = "Release Detain License";
            this.releaseDetainLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainLicenseToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1821, 821);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poepleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmCurrentUserInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmSignOut;
        private System.Windows.Forms.ToolStripMenuItem tsmTestsTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmManageAppTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmDrivingLicensesServices;
        private System.Windows.Forms.ToolStripMenuItem tsmManageApplciations;
        private System.Windows.Forms.ToolStripMenuItem tsmDetainLicenses;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmNewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmRenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmReplaceForLostOrDamaged;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmReleaseDetained;
        private System.Windows.Forms.ToolStripMenuItem tsmRetakeTest;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainLicenseToolStripMenuItem;
    }
}

