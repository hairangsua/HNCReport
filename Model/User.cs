using Dapper;
using HNCReport.Helper;
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
                user = con.QueryFirstOrDefault<User>($"SELECT id as Id,username as Username,staff_code as StaffCode,password_hash as PasswordHash,password_salt as PasswordSalt FROM user WHERE username = '{username}'");
            }


            if (user == null)
            {
                throw new Exception("username is not existed");
            }

            if (!VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
            {
                throw new Exception("username or password not match");
            }

            return true;
        }

        private static bool VerifyPasswordHash(string password, byte[] storedSalt, byte[] storedHash)
        {
            if (password.IsEmpty())
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (password.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            }

            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password salt (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password hash (128 bytes expected).", "passwordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerHash.Length; i++)
                {
                    if (computerHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
