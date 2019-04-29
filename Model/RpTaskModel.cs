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
        public decimal TotalHour { get; set; }
        public string AsigneeStaffCode { get; set; }
        public string AsigneeStaffName { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string UpdatedUser { get; set; }

        public const string SQL_INSERT = @"INSERT INTO `hnc-report`.`rp_task` (
                                                            	`id`,
                                                            	`code`,
                                                            	`name`,
                                                            	`ref_code`,
                                                            	`description`,
                                                            	`is_done`,
                                                            	`percent`,
                                                            	`total_hour`,
                                                            	`asignee_staff_code`,
                                                            	`asignee_staff_name`,
                                                            	`created_time`,
                                                            	`created_user`,
                                                            	`updated_time`,
                                                            	`updated_user` 
                                                            )
                                                            VALUES
                                                            	  ( @Id, @Code, @Name, @RefCode, @Description, @IsDone, @Percent, @TotalHour, @AsigneeStaffCode, @AsigneeStaffName, @CreatedTime, @CreatedUser, @UpdatedTime, @UpdatedUser);";

        public const string SQL_SELECT = @"SELECT
                                            	id AS Id,
                                            	code AS Code,
                                            	name AS Name,
                                            	ref_code AS RefeCode,
                                            	description AS Description,
                                            	is_done AS IsDone,
                                            	percent AS Percent,
                                            	total_hour AS TotalHour,
                                            	asignee_staff_code AS AsigneeStaffCode,
                                            	asignee_staff_name AS AsignessStaffName,
                                            	created_time AS CreatedTime,
                                            	created_user AS CreatedUser,
                                            	updated_time AS UpdatedTime,
                                            	updated_user AS UpdatedUser 
                                            FROM
                                            	rp_task";
    }
}
