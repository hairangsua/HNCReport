using DevExpress.XtraEditors;

namespace HNCReport.Task
{
    partial class frmCreateTask
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTask = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTaskCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTaskName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboAssignee = new DevExpress.XtraEditors.LookUpEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.rpStaffRepoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtTask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAssignee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStaffRepoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Task";
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(59, 12);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(695, 20);
            this.txtTask.TabIndex = 0;
            this.txtTask.Validated += new System.EventHandler(this.txtTask_Validated);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Code";
            // 
            // txtTaskCode
            // 
            this.txtTaskCode.Location = new System.Drawing.Point(59, 42);
            this.txtTaskCode.Name = "txtTaskCode";
            this.txtTaskCode.Size = new System.Drawing.Size(79, 20);
            this.txtTaskCode.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(154, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Name";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(187, 42);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(567, 20);
            this.txtTaskName.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 71);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Assignee";
            // 
            // cboAssignee
            // 
            this.cboAssignee.Location = new System.Drawing.Point(59, 68);
            this.cboAssignee.Name = "cboAssignee";
            this.cboAssignee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAssignee.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StaffCode", "Staff Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StaffName", "Staff Name")});
            this.cboAssignee.Properties.DataSource = this.rpStaffRepoBindingSource;
            this.cboAssignee.Size = new System.Drawing.Size(695, 20);
            this.cboAssignee.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(679, 102);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // rpStaffRepoBindingSource
            // 
            this.rpStaffRepoBindingSource.DataSource = typeof(BL.RpStaff.RpStaffRepo);
            // 
            // frmCreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 139);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cboAssignee);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.txtTaskCode);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmCreateTask";
            this.Text = "Create Task";
            ((System.ComponentModel.ISupportInitialize)(this.txtTask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAssignee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpStaffRepoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelControl labelControl1;
        private TextEdit txtTask;
        private LabelControl labelControl2;
        private TextEdit txtTaskCode;
        private LabelControl labelControl3;
        private TextEdit txtTaskName;
        private LabelControl labelControl4;
        private LookUpEdit cboAssignee;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private SimpleButton btnCreate;
        private System.Windows.Forms.BindingSource rpStaffRepoBindingSource;
    }
}