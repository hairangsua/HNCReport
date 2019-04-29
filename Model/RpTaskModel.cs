using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCReport.Model
{
    public class RpTaskModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string RefCode { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public decimal Percent { get; set; }
        public decimal ToltalHour { get; set; }
        public string AsigneeStaffCode { get; set; }
        public string AsigneeStaffName { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string UpdatedUser { get; set; }
    }
}
