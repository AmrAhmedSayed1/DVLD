namespace DVLD
{
    partial class frmManageTestsAppointments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageTestsAppointments));
            this.dgvTestsAppointments = new System.Windows.Forms.DataGridView();
            this.cmsTestsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEditTestAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewTestAppointment = new System.Windows.Forms.Button();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.lblTestType = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.uctrlAppInfo1 = new DVLD.uctrlAppInfo();
            this.uctrlNewLDLAppInfo1 = new DVLD.uctrlNewLDLAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsAppointments)).BeginInit();
            this.cmsTestsAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTestsAppointments
            // 
            this.dgvTestsAppointments.AllowUserToAddRows = false;
            this.dgvTestsAppointments.AllowUserToDeleteRows = false;
            this.dgvTestsAppointments.AllowUserToOrderColumns = true;
            this.dgvTestsAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTestsAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestsAppointments.ContextMenuStrip = this.cmsTestsAppointments;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestsAppointments.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTestsAppointments.Location = new System.Drawing.Point(15, 623);
            this.dgvTestsAppointments.MultiSelect = false;
            this.dgvTestsAppointments.Name = "dgvTestsAppointments";
            this.dgvTestsAppointments.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTestsAppointments.RowHeadersWidth = 51;
            this.dgvTestsAppointments.RowTemplate.Height = 24;
            this.dgvTestsAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestsAppointments.Size = new System.Drawing.Size(1010, 124);
            this.dgvTestsAppointments.TabIndex = 23;
            // 
            // cmsTestsAppointments
            // 
            this.cmsTestsAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTestsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditTestAppointment,
            this.tsmTakeTest,
            this.toolStripSeparator1});
            this.cmsTestsAppointments.Name = "contextMenuStrip1";
            this.cmsTestsAppointments.Size = new System.Drawing.Size(179, 118);
            this.cmsTestsAppointments.MouseEnter += new System.EventHandler(this.cmsTestsAppointments_MouseEnter);
            // 
            // tsmEditTestAppointment
            // 
            this.tsmEditTestAppointment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEditTestAppointment.Image = ((System.Drawing.Image)(resources.GetObject("tsmEditTestAppointment.Image")));
            this.tsmEditTestAppointment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditTestAppointment.Name = "tsmEditTestAppointment";
            this.tsmEditTestAppointment.Size = new System.Drawing.Size(178, 54);
            this.tsmEditTestAppointment.Text = "Edit";
            this.tsmEditTestAppointment.Click += new System.EventHandler(this.tsmEditTestAppointment_Click);
            // 
            // tsmTakeTest
            // 
            this.tsmTakeTest.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmTakeTest.Image = ((System.Drawing.Image)(resources.GetObject("tsmTakeTest.Image")));
            this.tsmTakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmTakeTest.Name = "tsmTakeTest";
            this.tsmTakeTest.Size = new System.Drawing.Size(178, 54);
            this.tsmTakeTest.Text = "Take Test";
            this.tsmTakeTest.Click += new System.EventHandler(this.tsmTakeTest_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(206, 758);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(48, 32);
            this.lblNumOfRecords.TabIndex = 26;
            this.lblNumOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 758);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 32);
            this.label2.TabIndex = 25;
            this.label2.Text = "#Records : ";
            // 
            // btnAddNewTestAppointment
            // 
            this.btnAddNewTestAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewTestAppointment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAddNewTestAppointment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddNewTestAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTestAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewTestAppointment.Image")));
            this.btnAddNewTestAppointment.Location = new System.Drawing.Point(976, 576);
            this.btnAddNewTestAppointment.Name = "btnAddNewTestAppointment";
            this.btnAddNewTestAppointment.Size = new System.Drawing.Size(49, 41);
            this.btnAddNewTestAppointment.TabIndex = 24;
            this.btnAddNewTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewTestAppointment.Click += new System.EventHandler(this.btnAddNewTestAppointment_Click);
            // 
            // pbTestType
            // 
            this.pbTestType.Location = new System.Drawing.Point(424, 12);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(194, 90);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTestType.TabIndex = 27;
            this.pbTestType.TabStop = false;
            // 
            // lblTestType
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTestType.Location = new System.Drawing.Point(432, 112);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(172, 38);
            this.lblTestType.TabIndex = 28;
            this.lblTestType.Text = "Test Type";
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.Red;
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.Location = new System.Drawing.Point(814, 751);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(211, 65);
            this.Close.TabIndex = 29;
            this.Close.Text = "Close";
            this.Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // uctrlAppInfo1
            // 
            this.uctrlAppInfo1.BackColor = System.Drawing.Color.White;
            this.uctrlAppInfo1.Location = new System.Drawing.Point(12, 316);
            this.uctrlAppInfo1.Name = "uctrlAppInfo1";
            this.uctrlAppInfo1.Size = new System.Drawing.Size(1013, 255);
            this.uctrlAppInfo1.TabIndex = 1;
            // 
            // uctrlNewLDLAppInfo1
            // 
            this.uctrlNewLDLAppInfo1.BackColor = System.Drawing.Color.White;
            this.uctrlNewLDLAppInfo1.Location = new System.Drawing.Point(12, 145);
            this.uctrlNewLDLAppInfo1.Name = "uctrlNewLDLAppInfo1";
            this.uctrlNewLDLAppInfo1.Size = new System.Drawing.Size(1013, 153);
            this.uctrlNewLDLAppInfo1.TabIndex = 0;
            // 
            // frmManageTestsAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1038, 817);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.lblTestType);
            this.Controls.Add(this.pbTestType);
            this.Controls.Add(this.dgvTestsAppointments);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewTestAppointment);
            this.Controls.Add(this.uctrlAppInfo1);
            this.Controls.Add(this.uctrlNewLDLAppInfo1);
            this.Name = "frmManageTestsAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVisionTest";
            this.Load += new System.EventHandler(this.frmManageTestsAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsAppointments)).EndInit();
            this.cmsTestsAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uctrlNewLDLAppInfo uctrlNewLDLAppInfo1;
        private uctrlAppInfo uctrlAppInfo1;
        private System.Windows.Forms.DataGridView dgvTestsAppointments;
        private System.Windows.Forms.ContextMenuStrip cmsTestsAppointments;
        private System.Windows.Forms.ToolStripMenuItem tsmEditTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem tsmTakeTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewTestAppointment;
        private System.Windows.Forms.PictureBox pbTestType;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.Button Close;
    }
}