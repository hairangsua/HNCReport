using DevExpress.XtraEditors;

namespace HNCReport
{
    partial class DailyReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompletePercent = new DevExpress.XtraEditors.TextEdit();
            this.txtHours = new DevExpress.XtraEditors.TextEdit();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtReportDate = new DevExpress.XtraEditors.DateEdit();
            this.cboTasks = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompletePercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTasks.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Công việc chưa hoàn thành";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ty lệ hoàn thành (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số giờ làm trong ngày (giờ)";
            // 
            // txtCompletePercent
            // 
            this.txtCompletePercent.Location = new System.Drawing.Point(157, 39);
            this.txtCompletePercent.Name = "txtCompletePercent";
            this.txtCompletePercent.Size = new System.Drawing.Size(107, 20);
            this.txtCompletePercent.TabIndex = 2;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(424, 39);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(107, 20);
            this.txtHours.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(735, 68);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày";
            // 
            // dtReportDate
            // 
            this.dtReportDate.EditValue = null;
            this.dtReportDate.Location = new System.Drawing.Point(588, 42);
            this.dtReportDate.Name = "dtReportDate";
            this.dtReportDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReportDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReportDate.Size = new System.Drawing.Size(222, 20);
            this.dtReportDate.TabIndex = 4;
            // 
            // cboTasks
            // 
            this.cboTasks.Location = new System.Drawing.Point(157, 6);
            this.cboTasks.Name = "cboTasks";
            this.cboTasks.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTasks.Size = new System.Drawing.Size(653, 20);
            this.cboTasks.TabIndex = 5;
            // 
            // DailyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 106);
            this.Controls.Add(this.cboTasks);
            this.Controls.Add(this.dtReportDate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.txtCompletePercent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DailyReport";
            this.Text = "Báo cáo từng task";
            ((System.ComponentModel.ISupportInitialize)(this.txtCompletePercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTasks.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private TextEdit txtCompletePercent;
        private TextEdit txtHours;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private DateEdit dtReportDate;
        private LookUpEdit cboTasks;
    }
}