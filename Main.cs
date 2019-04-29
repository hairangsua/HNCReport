using HNCReport.ForLead;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNCReport
{
    public partial class MainForm : frmBase
    {
        public MainForm()
        {
            InitializeComponent();

            try
            {
                var frmLogin = new frmLogin();
                frmLogin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void btnForLead_Click(object sender, EventArgs e)
        {
            try
            {
                var b = AppContext.ValidateAuthenticated();
                if (!b)
                {
                    return;
                }

                if (AppContext.IsStaff())
                {
                    return;
                }

                var frm = new frmForLead();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnForStaff_Click(object sender, EventArgs e)
        {
            try
            {
                var b = AppContext.ValidateAuthenticated();
                if (!b)
                {
                    return;
                }

                var frm = new frmForStaff();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void btnForAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AppContext.IsAdmin())
                {
                    MessageBox.Show("Ô có fai ass min đâu mà đc sử dụng tính năng này!");
                    return;
                }

                var frm = new frmCreateUser();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
