namespace HNCReport
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
            this.btnForLead = new System.Windows.Forms.Button();
            this.btnForStaff = new System.Windows.Forms.Button();
            this.btnForAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForLead
            // 
            this.btnForLead.Location = new System.Drawing.Point(39, 37);
            this.btnForLead.Name = "btnForLead";
            this.btnForLead.Size = new System.Drawing.Size(235, 182);
            this.btnForLead.TabIndex = 0;
            this.btnForLead.Text = "For Lead";
            this.btnForLead.UseVisualStyleBackColor = true;
            this.btnForLead.Click += new System.EventHandler(this.btnForLead_Click);
            // 
            // btnForStaff
            // 
            this.btnForStaff.Location = new System.Drawing.Point(309, 37);
            this.btnForStaff.Name = "btnForStaff";
            this.btnForStaff.Size = new System.Drawing.Size(232, 182);
            this.btnForStaff.TabIndex = 0;
            this.btnForStaff.Text = "For Staff";
            this.btnForStaff.UseVisualStyleBackColor = true;
            this.btnForStaff.Click += new System.EventHandler(this.btnForStaff_Click);
            // 
            // btnForAdmin
            // 
            this.btnForAdmin.Location = new System.Drawing.Point(39, 246);
            this.btnForAdmin.Name = "btnForAdmin";
            this.btnForAdmin.Size = new System.Drawing.Size(235, 182);
            this.btnForAdmin.TabIndex = 0;
            this.btnForAdmin.Text = "For Assmin";
            this.btnForAdmin.UseVisualStyleBackColor = true;
            this.btnForAdmin.Click += new System.EventHandler(this.btnForAdmin_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(587, 464);
            this.Controls.Add(this.btnForStaff);
            this.Controls.Add(this.btnForAdmin);
            this.Controls.Add(this.btnForLead);
            this.Name = "MainForm";
            this.Text = "HNC Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForLead;
        private System.Windows.Forms.Button btnForStaff;
        private System.Windows.Forms.Button btnForAdmin;
    }
}

