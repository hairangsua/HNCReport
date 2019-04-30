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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompletePercent = new DevExpress.XtraEditors.TextEdit();
            this.txtHours = new DevExpress.XtraEditors.TextEdit();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtReportDate = new DevExpress.XtraEditors.DateEdit();
            this.cboTasks = new DevExpress.XtraEditors.LookUpEdit();
            this.gridView = new DevExpress.XtraGrid.GridControl();
            this.rpTaskReportDailyModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAsigneeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReportDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHourPerDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompletePercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompletePercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTasks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpTaskReportDailyModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.cboTasks.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompletePercent", "Complete Percent")});
            this.cboTasks.Size = new System.Drawing.Size(653, 20);
            this.cboTasks.TabIndex = 5;
            this.cboTasks.EditValueChanged += new System.EventHandler(this.cboTasks_EditValueChanged);
            // 
            // gridView
            // 
            this.gridView.DataSource = this.rpTaskReportDailyModelBindingSource;
            this.gridView.Location = new System.Drawing.Point(3, 97);
            this.gridView.MainView = this.gridView1;
            this.gridView.Name = "gridView";
            this.gridView.Size = new System.Drawing.Size(816, 498);
            this.gridView.TabIndex = 6;
            this.gridView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // rpTaskReportDailyModelBindingSource
            // 
            this.rpTaskReportDailyModelBindingSource.DataSource = typeof(BL.RpTaskReportDaily.RpTaskReportDailyModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colFullName,
            this.colAsigneeCode,
            this.colReportDate,
            this.colHourPerDay,
            this.colCompletePercent});
            this.gridView1.GridControl = this.gridView;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            // 
            // colFullName
            // 
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.ReadOnly = true;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            this.colFullName.Width = 427;
            // 
            // colAsigneeCode
            // 
            this.colAsigneeCode.FieldName = "AsigneeCode";
            this.colAsigneeCode.Name = "colAsigneeCode";
            this.colAsigneeCode.Visible = true;
            this.colAsigneeCode.VisibleIndex = 1;
            this.colAsigneeCode.Width = 298;
            // 
            // colReportDate
            // 
            this.colReportDate.FieldName = "ReportDate";
            this.colReportDate.Name = "colReportDate";
            this.colReportDate.Visible = true;
            this.colReportDate.VisibleIndex = 2;
            this.colReportDate.Width = 298;
            // 
            // colHourPerDay
            // 
            this.colHourPerDay.FieldName = "HourPerDay";
            this.colHourPerDay.Name = "colHourPerDay";
            this.colHourPerDay.Visible = true;
            this.colHourPerDay.VisibleIndex = 3;
            this.colHourPerDay.Width = 298;
            // 
            // colCompletePercent
            // 
            this.colCompletePercent.FieldName = "CompletePercent";
            this.colCompletePercent.Name = "colCompletePercent";
            this.colCompletePercent.Visible = true;
            this.colCompletePercent.VisibleIndex = 4;
            this.colCompletePercent.Width = 301;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(654, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // DailyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 597);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.cboTasks);
            this.Controls.Add(this.dtReportDate);
            this.Controls.Add(this.btnAdd);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpTaskReportDailyModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.BindingSource rpTaskReportDailyModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colAsigneeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colReportDate;
        private DevExpress.XtraGrid.Columns.GridColumn colHourPerDay;
        private DevExpress.XtraGrid.Columns.GridColumn colCompletePercent;
    }
}