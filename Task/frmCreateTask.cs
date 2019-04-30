using BL.RpStaff;
using BL.RpTask;
using BL.RpTaskReportDaily;
using Dapper;
using Kinta.Framework.Helper;
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
        private RpStaffRepo _repoStaff = new RpStaffRepo();
        private RpTaskRepo _repoTask = new RpTaskRepo();
        private RpTaskReportDailyRepo _repoDailyReport = new RpTaskReportDailyRepo();

        public frmCreateTask()
        {
            InitializeComponent();

            var user = AppContext.GetUserProfile();

            if (user != null)
            {
                var lstStaff = _repoStaff.Find(x => x.LeaderCode == user.StaffCode || x.StaffCode == user.StaffCode);

                if (lstStaff.HasItem())
                {
                    cboAssignee.Properties.DataSource = lstStaff;
                    cboAssignee.Properties.DisplayMember = nameof(RpStaffModel.StaffName);
                    cboAssignee.Properties.ValueMember = nameof(RpStaffModel.StaffCode);
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

                var exitedTask = _repoTask.SingleOrDefault(x => x.Code == code);
                if (exitedTask != null)
                {
                    MessageBox.Show($"Task {exitedTask.Code} đã tồn tại!");
                    return;
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
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void createTask(RpTaskModel task)
        {
            using (var ts = _repoTask.Connection.BeginTransaction())
            {
                try
                {
                    _repoTask.Insert(task, ts);

                    var taskDaily = RpTaskReportDailyModel.ConvertTo(task);
                    taskDaily.Id = IdHelper.NewGuid();
                    taskDaily.Status = RpTaskReportDailyModel.Constant.Status.CREATE;
                    taskDaily.HourPerDay = 0;
                    taskDaily.CompletePercent = 0;
                    taskDaily.ReportDate = DateTime.Now;
                    taskDaily.CreatedTime = DateTime.Now;
                    taskDaily.CreatedUser = AppContext.UserName;
                    taskDaily.UpdatedTime = DateTime.Now;
                    taskDaily.UpdatedUser = AppContext.UserName;

                    _repoDailyReport.Insert(taskDaily, ts);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                    ts.Rollback();
                }
            }
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
