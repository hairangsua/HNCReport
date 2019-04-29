using DevExpress.XtraEditors;

namespace HNCReport.ForLead
{
    partial class frmForStaff
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
            this.btnDailyReport = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnDailyReport
            // 
            this.btnDailyReport.Location = new System.Drawing.Point(45, 27);
            this.btnDailyReport.Name = "btnDailyReport";
            this.btnDailyReport.Size = new System.Drawing.Size(168, 141);
            this.btnDailyReport.TabIndex = 0;
            this.btnDailyReport.Text = "Daily Report";
            this.btnDailyReport.Click += new System.EventHandler(this.btnDailyReport_Click);
            // 
            // frmForStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDailyReport);
            this.Name = "frmForStaff";
            this.Text = "IT Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButton btnDailyReport;
    }
}