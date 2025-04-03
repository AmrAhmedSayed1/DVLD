namespace DVLD
{
    partial class frmPersonalDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.uctrlPersonalDetails1 = new DVLD.uctrlPersonalDetails();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(404, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personal Details";
            // 
            // uctrlPersonalDetails1
            // 
            this.uctrlPersonalDetails1.BackColor = System.Drawing.Color.White;
            this.uctrlPersonalDetails1.Location = new System.Drawing.Point(2, 95);
            this.uctrlPersonalDetails1.Name = "uctrlPersonalDetails1";
            this.uctrlPersonalDetails1.Size = new System.Drawing.Size(1199, 503);
            this.uctrlPersonalDetails1.TabIndex = 1;
            // 
            // frmPersonalDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1203, 597);
            this.Controls.Add(this.uctrlPersonalDetails1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonalDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personal Details";
            this.Load += new System.EventHandler(this.frmPersonalDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private uctrlPersonalDetails uctrlPersonalDetails1;
    }
}