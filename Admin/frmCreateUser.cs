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
using Dapper;
using HNCReport.Helper;

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

                CreatePasswordHash(passWord, out passwordHash, out passwordSalt);
                
                CreateUser(staffCode, userName, passwordHash, passwordSalt);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CreateUser(string staffCode, string userName, byte[] passwordHash, byte[] passwordSalt)
        {
            //var sql = "INSERT INTO `hnc-report`.`user`(`id`, `staff_code`, `username`, `password_salt`, `password_hash`) VALUES ('{}', '{}', '{}', {}, {});";

            string sql = "INSERT INTO `hnc-report`.`user`(`id`, `staff_code`, `username`, `password_salt`, `password_hash`) VALUES (@Id,@StaffCode,@UserName,@PasswordSalt,@PasswordHash);";
            using (var con = AppContext.GetConnection())
            {
                con.Open();
                var affectedRows = con.Execute(sql, new User
                {
                    Id = IdHelper.NewGuid(),
                    StaffCode = staffCode,
                    Username = userName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }



    }
}
