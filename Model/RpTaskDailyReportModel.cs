using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCReport.Model
{
    public class RpTaskDailyReportModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string AsigneeCode { get; set; }
        public DateTime ReportDate { get; set; }
        public decimal HourPerDate { get; set; }
        public decimal CompletePercent { get; set; }
        public string MentionData { get; set; }
        public string Note { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string UpdatedUser { get; set; }
    }
}
