using BL.RpJobPosition;
using BL.RpStaff;
using BL.RpUser;
using System.Windows.Forms;

namespace HNCReport
{
    public class AppContext
    {
        public static string UserName { get; set; }
        public static bool IsLogin { get; set; }

        public static RpUserModel GetUserProfile()
        {
            string userName = UserName;
            return new RpUserRepo().FirstOrDefault(x => x.Username == userName);
        }

        public static RpStaffModel GetStaffProfile()
        {
            var user = GetUserProfile();

            return new RpStaffRepo().FirstOrDefault(x => x.StaffCode == user.StaffCode);
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

            return staff.LeaderCode == RpJobPositionModel.Constant.LEADER;
        }

        public static bool IsStaff()
        {
            var staff = GetStaffProfile();
            if (staff == null)
            {
                return false;
            }
            return staff.LeaderCode == RpJobPositionModel.Constant.STAFF;
        }

        public static bool IsAdmin()
        {
            return UserName == "admin";
        }
    }
}
