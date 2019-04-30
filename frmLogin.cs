using BL.RpUser;
using Dapper;
using MySql.Data.MySqlClient;
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
    public partial class frmLogin : frmBase
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool isAuthenticate;

        private bool authenticate(string userName, string password)
        {
            var bl = new RpUserBL();
            return bl.Authenticate(userName, password);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;
            isAuthenticate = authenticate(userName, password);
            if (!isAuthenticate)
            {
                MessageBox.Show("Sai mật khẩu cmnr!");
                return;
            }

            AppContext.UserName = userName;
            AppContext.IsLogin = true;

            Close();
        }

        public Action<EventArgs> OnNotAuthenAndCloseForm = null;

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                base.OnClosed(e);

                if (!isAuthenticate)
                {
                    Application.Exit();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
