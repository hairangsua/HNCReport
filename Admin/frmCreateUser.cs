using BL.RpUser;
using BL.Security;
using Kinta.Framework.Helper;
using System;
using System.Windows.Forms;

namespace HNCReport
{
    public partial class frmCreateUser : frmBase
    {
        private RpUserRepo _repoUser = new RpUserRepo();

        public frmCreateUser()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = txtUserName.Text;
                var passWord = txtPassword.Text;
                var staffCode = txtStaffCode.Text;
                var staffName = txtStaffName.Text;

                byte[] passwordHash, passwordSalt;

                PasswordExtension.CreatePasswordHash(passWord, out passwordHash, out passwordSalt);

                _repoUser.Insert(new RpUserModel
                {
                    Id = IdHelper.NewGuid(),
                    StaffCode = staffCode,
                    StaffName = staffName,
                    Username = userName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });

                MessageBox.Show("Tạo mới thành công!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
