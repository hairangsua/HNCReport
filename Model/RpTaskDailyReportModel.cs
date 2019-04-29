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
        public string TaskId { get; set; }
        public string AsigneeCode { get; set; }
        public DateTime ReportDate { get; set; }
        public decimal HourPerDay { get; set; }
        public decimal CompletePercent { get; set; }
        public string MentionData { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string UpdatedUser { get; set; }
        public string FullName
        {
            get
            {
                return GetFullName(Code, Name);
            }
        }

        public static string GetFullName(string code, string name)
        {
            return $"ERP-{code} {name}";
        }

        public static RpTaskDailyReportModel ConvertTo(RpTaskModel task)
        {
            var rs = new RpTaskDailyReportModel
            {
                Code = task.Code,
                Name = task.Name,
                AsigneeCode = task.AsigneeStaffCode,
                TaskId = task.Id
            };

            return rs;
        }

        public static readonly string SQL_SELECT = @"SELECT
                                          	id AS Id,
                                          	code AS Code,
                                          	name AS Name,
                                          	asignee_code AS AsigneeCode,
                                          	report_date AS ReportDate,
                                          	hour_per_day AS HourPerDay,
                                          	complete_percent AS CompletePerCent,
                                          	mention_data AS MentionData,
                                          	status AS STATUS,
                                          	note AS Note,
                                          	created_time AS CreatedTime,
                                          	created_user AS CreatedUser,
                                          	updated_time AS UpdatedTime,
                                          	updated_user AS UpdatedUser 
                                          FROM
                                          	rp_task_report_daily";

        public static readonly string SQL_INSERT = @"INSERT INTO `hnc-report`.`rp_task_report_daily` ( `id`, `code`, `name`, `task_id`,`asignee_code`, `report_date`, `hour_per_day`, `complete_percent`, `mention_data`, `status`, `note`, `created_time`, `created_user`, `updated_time`, `updated_user` )
                                                                            VALUES
                                                                            	(
                                                                            		@Id,
                                                                            		@Code,
                                                                            		@Name,
                                                                            		@TaskId,
                                                                            		@AsigneeCode,
                                                                            		@ReportDate,
                                                                            		@HourPerDay,
                                                                            		@CompletePercent,
                                                                            		@MentionData,
                                                                                    @Status,
                                                                            		@Note,                                                                            		
                                                                            		@CreatedTime,
                                                                            		@CreatedUser,
                                                                            		@UpdatedTime,
                                                                            	    @UpdatedUser);";

        public class Constant
        {
            public class Status
            {
                public const string CREATE = "CREATE";
                public const string PROCESSING = "PROCESSING";
                public const string DONE = "DONE";
            }
        }
    }
}
