using Dapper;
using HNCReport.Model;
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
using HNCReport.Helper;
using HNCReport.Security;

namespace HNCReport
{
    public partial class frmCreateUser : frmBase
    {
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

                CreateUser(staffCode, staffName, userName, passwordHash, passwordSalt);
                MessageBox.Show("Tạo mới thành công!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CreateUser(string aStaffCode,
                                string aStaffName,
                                string aUserName,
                                byte[] aPasswordHash,
                                byte[] aPasswordSalt)
        {
            string sql = @"INSERT INTO `hnc-report`.`user` ( `id`, `staff_code`, `staff_name`, `username`, `password_salt`, `password_hash` )
                           VALUES
                           ( @Id, @StaffCode, @StaffName, @UserName, @PasswordSalt, @PasswordHash );";

            using (var con = AppContext.GetConnection())
            {
                con.Open();
                var affectedRows = con.Execute(sql, new User
                {
                    Id = IdHelper.NewGuid(),
                    StaffCode = aStaffCode,
                    StaffName = aStaffName,
                    Username = aUserName,
                    PasswordHash = aPasswordHash,
                    PasswordSalt = aPasswordSalt
                });
            }
        }
    }
}
