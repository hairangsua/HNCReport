using DevExpress.XtraEditors;

namespace HNCReport.ForLead
{
    partial class frmForLead
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
            this.btnCreateTask = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetReportWeekly = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Location = new System.Drawing.Point(45, 27);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(168, 141);
            this.btnCreateTask.TabIndex = 0;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // btnGetReportWeekly
            // 
            this.btnGetReportWeekly.Location = new System.Drawing.Point(248, 27);
            this.btnGetReportWeekly.Name = "btnGetReportWeekly";
            this.btnGetReportWeekly.Size = new System.Drawing.Size(168, 141);
            this.btnGetReportWeekly.TabIndex = 0;
            this.btnGetReportWeekly.Text = "Report weekly";
            this.btnGetReportWeekly.Click += new System.EventHandler(this.btnGetReportWeekly_Click);
            // 
            // frmForLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetReportWeekly);
            this.Controls.Add(this.btnCreateTask);
            this.Name = "frmForLead";
            this.Text = "IT Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButton btnCreateTask;
        private SimpleButton btnGetReportWeekly;
    }
}