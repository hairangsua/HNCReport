﻿using Dapper;
using HNCReport.Helper;
using HNCReport.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNCReport.Task
{
    public partial class frmCreateTask : frmBase
    {
        public frmCreateTask()
        {
            InitializeComponent();

            var user = AppContext.GetUserProfile();

            var sql = $@"SELECT
                        	id AS Id,
                        	staff_code AS StaffCode,
                        	staff_name AS StaffName,
                        	position_code AS PositionCode,
                        	leader_code AS LeaderCode,
                        	created_time AS CreatedTime,
                        	created_user AS CreatedUser,
                            updated_time AS UpdatedTime,
                        	updated_user AS UpdatedUser 
                        FROM
                        	rp_staff 
                        WHERE
                        	leader_code = '{user.StaffCode}' OR staff_code = '{user.StaffCode}'";

            if (user != null)
            {
                using (var con = AppContext.GetConnection())
                {
                    con.Open();
                    var lstStaff = con.Query<RpStaffModel>(sql) as List<RpStaffModel>;
                    if (lstStaff.HasItem())
                    {
                        cboAssignee.Properties.DataSource = lstStaff;
                        cboAssignee.Properties.DisplayMember = nameof(RpStaffModel.StaffName);
                        cboAssignee.Properties.ValueMember = nameof(RpStaffModel.StaffCode);
                    }
                }
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var code = txtTaskCode.Text;
                var name = txtTaskName.Text;
                var asignee = cboAssignee.EditValue.ToString();

                string sql = $@"SELECT * FROM rp_task WHERE code = {code};";

                using (var con = AppContext.GetConnection())
                {
                    var exitedTask = con.QueryFirstOrDefault<RpTaskModel>(sql);
                    if (exitedTask != null)
                    {
                        MessageBox.Show($"Task {exitedTask.Code} đã tồn tại!");
                        return;
                    }
                }

                createTask(new RpTaskModel
                {
                    Id = IdHelper.NewGuid(),
                    Code = code,
                    Name = name,
                    TotalHour = 0,
                    Description = "",
                    IsDone = false,
                    Percent = 0,
                    RefCode = "",
                    AsigneeStaffCode = asignee,
                    AsigneeStaffName = cboAssignee.Properties.GetDisplayText(asignee),
                    CreatedTime = DateTime.Now,
                    CreatedUser = AppContext.UserName,
                    UpdatedTime = DateTime.Now,
                    UpdatedUser = AppContext.UserName
                });

                MessageBox.Show("Done!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private RpTaskModel createTask(RpTaskModel task)
        {
            var sql = @"INSERT INTO `hnc-report`.`rp_task` (
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


            RpTaskModel affected = null;
            using (var con = AppContext.GetConnection())
            {
                con.Open();
                con.Execute(sql, task);
            }

            return affected;
        }

        private void txtTask_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtTask.Text.IsNotEmpty())
                {
                    //ERP-6761 Tạo khung API cho app HNC Online
                    string task = txtTask.Text;

                    txtTaskCode.Text = task.Substring(4, 4);
                    txtTaskName.Text = task.Substring(9);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
