namespace DVLD
{
    partial class uctrlManageApplicationsTypes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctrlManageApplicationsTypes));
            this.dgvApplicationsTypes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.cmsManageAppsTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEditApplicationType = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationsTypes)).BeginInit();
            this.cmsManageAppsTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvApplicationsTypes
            // 
            this.dgvApplicationsTypes.AllowUserToAddRows = false;
            this.dgvApplicationsTypes.AllowUserToDeleteRows = false;
            this.dgvApplicationsTypes.AllowUserToOrderColumns = true;
            this.dgvApplicationsTypes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplicationsTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApplicationsTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationsTypes.ContextMenuStrip = this.cmsManageAppsTypes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApplicationsTypes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApplicationsTypes.Location = new System.Drawing.Point(3, 3);
            this.dgvApplicationsTypes.MultiSelect = false;
            this.dgvApplicationsTypes.Name = "dgvApplicationsTypes";
            this.dgvApplicationsTypes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplicationsTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApplicationsTypes.RowHeadersWidth = 51;
            this.dgvApplicationsTypes.RowTemplate.Height = 24;
            this.dgvApplicationsTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationsTypes.Size = new System.Drawing.Size(647, 295);
            this.dgvApplicationsTypes.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 32);
            this.label2.TabIndex = 15;
            this.label2.Text = "#Records : ";
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(173, 304);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(48, 32);
            this.lblNumOfRecords.TabIndex = 16;
            this.lblNumOfRecords.Text = "??";
            // 
            // cmsManageAppsTypes
            // 
            this.cmsManageAppsTypes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageAppsTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditApplicationType});
            this.cmsManageAppsTypes.Name = "cmsManageAppsTypes";
            this.cmsManageAppsTypes.Size = new System.Drawing.Size(285, 86);
            // 
            // tsmEditApplicationType
            // 
            this.tsmEditApplicationType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEditApplicationType.Image = ((System.Drawing.Image)(resources.GetObject("tsmEditApplicationType.Image")));
            this.tsmEditApplicationType.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditApplicationType.Name = "tsmEditApplicationType";
            this.tsmEditApplicationType.Size = new System.Drawing.Size(284, 54);
            this.tsmEditApplicationType.Text = "Edit Application Type";
            this.tsmEditApplicationType.Click += new System.EventHandler(this.tsmEditApplicationType_Click);
            // 
            // uctrlManageApplicationsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.dgvApplicationsTypes);
            this.Name = "uctrlManageApplicationsTypes";
            this.Size = new System.Drawing.Size(655, 337);
            this.Load += new System.EventHandler(this.uctrlManageApplicationsTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationsTypes)).EndInit();
            this.cmsManageAppsTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApplicationsTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.ContextMenuStrip cmsManageAppsTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmEditApplicationType;
    }
}
