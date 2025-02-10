namespace DVLD
{
    partial class uctrlManageTestsTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctrlManageTestsTypes));
            this.dgvTestsTypes = new System.Windows.Forms.DataGridView();
            this.cmsManageAppsTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmEditApplicationType = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsTypes)).BeginInit();
            this.cmsManageAppsTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTestsTypes
            // 
            this.dgvTestsTypes.AllowUserToAddRows = false;
            this.dgvTestsTypes.AllowUserToDeleteRows = false;
            this.dgvTestsTypes.AllowUserToOrderColumns = true;
            this.dgvTestsTypes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestsTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestsTypes.ContextMenuStrip = this.cmsManageAppsTypes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestsTypes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTestsTypes.Location = new System.Drawing.Point(4, 2);
            this.dgvTestsTypes.MultiSelect = false;
            this.dgvTestsTypes.Name = "dgvTestsTypes";
            this.dgvTestsTypes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestsTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTestsTypes.RowHeadersWidth = 51;
            this.dgvTestsTypes.RowTemplate.Height = 24;
            this.dgvTestsTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestsTypes.Size = new System.Drawing.Size(647, 295);
            this.dgvTestsTypes.TabIndex = 17;
            // 
            // cmsManageAppsTypes
            // 
            this.cmsManageAppsTypes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageAppsTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditApplicationType});
            this.cmsManageAppsTypes.Name = "cmsManageAppsTypes";
            this.cmsManageAppsTypes.Size = new System.Drawing.Size(243, 86);
            // 
            // tsmEditApplicationType
            // 
            this.tsmEditApplicationType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEditApplicationType.Image = ((System.Drawing.Image)(resources.GetObject("tsmEditApplicationType.Image")));
            this.tsmEditApplicationType.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditApplicationType.Name = "tsmEditApplicationType";
            this.tsmEditApplicationType.Size = new System.Drawing.Size(242, 54);
            this.tsmEditApplicationType.Text = "Edit Test Type";
            this.tsmEditApplicationType.Click += new System.EventHandler(this.tsmEditApplicationType_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = "#Records : ";
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(174, 303);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(48, 32);
            this.lblNumOfRecords.TabIndex = 19;
            this.lblNumOfRecords.Text = "??";
            // 
            // uctrlManageTestsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvTestsTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumOfRecords);
            this.Name = "uctrlManageTestsTypes";
            this.Size = new System.Drawing.Size(655, 337);
            this.Load += new System.EventHandler(this.uctrlManageTestsTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestsTypes)).EndInit();
            this.cmsManageAppsTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTestsTypes;
        private System.Windows.Forms.ContextMenuStrip cmsManageAppsTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmEditApplicationType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumOfRecords;
    }
}
