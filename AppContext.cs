using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNCReport
{
    public class AppContext
    {
        public static string UserName { get; set; }
        public static bool IsLogin { get; set; }

        public static bool ValidateAuthenticated()
        {
            if (!IsLogin)
            {
                MessageBox.Show("Chưa đăng nhập");
                return false;
            }

            return IsLogin;
        }

        public static bool IsLead()
        {
            return true;
        }

        public static bool IsStaff()
        {
            return true;
        }

        public static IDbConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static readonly string ConnectionString = @"Persist Security Info=True;Data Source=35.236.185.220;Port=3306;Initial Catalog=hnc-report;User ID=root;Password=nghia1996;charset=utf8;Pooling=true;";
    }
}
