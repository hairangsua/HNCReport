using Dapper;
using HNCReport.Model;
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

        public static User GetUserProfile()
        {
            User user = null;
            using (var con = GetConnection())
            {
                con.Open();
                user = con.QueryFirstOrDefault<User>($@"SELECT staff_code as StaffCode, staff_name as StaffName, username as UserName FROM `user` WHERE username = '{UserName}';");
            }

            return user;
        }

        public static RpStaffModel GetStaffProfile()
        {
            var user = GetUserProfile();

            RpStaffModel staff = null;
            using (var con = GetConnection())
            {
                con.Open();
                staff = con.QueryFirstOrDefault<RpStaffModel>($@"SELECT
                                                                	id AS Id,
                                                                	staff_code AS StaffCode,
                                                                	staff_name AS StaffName,
                                                                	position_code AS PositionCode,
                                                                	leader_code LeaderCode,
                                                                	created_time AS CreatedTime,
                                                                	created_user AS CreatedUser,
                                                                	updated_time AS UpdatedTime,
                                                                	updated_user AS UpdatedUser 
                                                                FROM
                                                                	rp_staff WHERE staff_code = '{user.StaffCode}';");
            }

            return staff;
        }

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
            var staff = GetStaffProfile();
            if (staff == null)
            {
                return false;
            }

            return staff.LeaderCode == RpJobPositionModel.LEADER;
        }

        public static bool IsStaff()
        {
            var staff = GetStaffProfile();
            if (staff == null)
            {
                return false;
            }
            return staff.LeaderCode == RpJobPositionModel.STAFF;
        }

        public static bool IsAdmin()
        {
            return UserName == "admin";
        }

        public static IDbConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static readonly string ConnectionString = @"Persist Security Info=True;Data Source=35.236.185.220;Port=3306;Initial Catalog=hnc-report;User ID=root;Password=nghia1996;charset=utf8;Pooling=true;";
    }
}
