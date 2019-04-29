using Dapper;
using HNCReport.Helper;
using HNCReport.Security;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCReport.Model
{
    public class User
    {
        public string Id { get; set; }
        public string StaffCode { get; set; }
        public string StaffName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public static bool Authenticate(string username, string password)
        {

            if (username.IsEmpty() || password.IsEmpty())
            {
                return false;
            }

            User user = null;

            using (var con = AppContext.GetConnection())
            {
                con.Open();
                user = con.QueryFirstOrDefault<User>($@"SELECT
                                                        id AS Id,
                                                        username AS Username,
                                                        staff_code AS StaffCode,
                                                        staff_name AS StaffName,
                                                        password_hash AS PasswordHash,
                                                        password_salt AS PasswordSalt
                                                        FROM
                                                        `hnc-report`.`user`
                                                        WHERE username = '{username}'");
            }


            if (user == null)
            {
                //System.Windows.Forms.MessageBox.Show("username is not existed");
                return false;
            }

            if (!PasswordExtension.VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
            {
                //System.Windows.Forms.MessageBox.Show("username or password not match");
                return false;
            }

            return true;
        }
    }
}
