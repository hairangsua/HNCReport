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

            using (var frmLogin = new frmLogin())
            {
                frmLogin.OnNotAuthenAndCloseForm = (e) =>
                {
                    frmLogin.OnNotAuthenAndCloseForm = null;
                    Close();
                };
                frmLogin.ShowDialog();
            }


        }

        private bool ValidateStaff(string user)
        {
            return true;
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
            }
            catch (Exception)
            {

                throw;
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
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnForAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmCreateUser();
                frm.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
