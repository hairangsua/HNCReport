using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCReport.Model
{
    public class RpStaffModel
    {
        public string Id { get; set; }
        public string StaffCode { get; set; }
        public string StaffName { get; set; }
        public string PositionCode { get; set; }
        public string LeaderCode { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string UpdatedUser { get; set; }
    }
}
