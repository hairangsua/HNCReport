using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using BL.RpTaskReportDaily;
using Kinta.Framework.Helper;
using BL.RpTask;

namespace HNCReport
{
    public partial class DailyReport : frmBase
    {
        private List<RpTaskReportDailyModel> _lstTaskDaily;
        private RpTaskReportDailyRepo _repoRepostDaily = new RpTaskReportDailyRepo();

        public DailyReport()
        {
            InitializeComponent();

            dtReportDate.EditValue = DateTime.Now;

            var user = AppContext.GetUserProfile();

            var lstAllTask = _repoRepostDaily.Find(x => x.AsigneeCode == user.StaffCode);
            _lstTaskDaily = getTaskDailyDataSource(lstAllTask);
            if (_lstTaskDaily.HasItem())
            {
                cboTasks.Properties.DataSource = _lstTaskDaily;
                cboTasks.Properties.DisplayMember = nameof(RpTaskReportDailyModel.FullName);
                cboTasks.Properties.ValueMember = nameof(RpTaskReportDailyModel.Code);
            }
        }

        private List<RpTaskReportDailyModel> getTaskDailyDataSource(List<RpTaskReportDailyModel> lstAllTask)
        {
            var rs = new List<RpTaskReportDailyModel>();

            var lstDone = lstAllTask.Where(x => x.Status == RpTaskReportDailyModel.Constant.Status.DONE).Select(x => x.Code).Distinct().ToList();

            var lstCode = lstAllTask.Where(x => x.Status != RpTaskReportDailyModel.Constant.Status.DONE && !lstDone.Contains(x.Code)).Select(x => x.Code).Distinct().ToList();
            if (lstCode.IsNullOrEmpty())
            {
                return rs;
            }

            foreach (var code in lstCode)
            {
                var lstTaskByCode = lstAllTask.Where(x => x.Code == code).OrderByDescending(x => x.ReportDate).ToList();
                rs.Add(lstTaskByCode.FirstOrDefault());
            }

            return rs;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal percent = decimal.Parse(txtCompletePercent.EditValue.ToString());
                var hourPerDay = decimal.Parse(txtHours.EditValue.ToString());

                if (percent < 0 || percent > 100)
                {
                    MessageBox.Show("Phần % chỉ nằm trong khoảng 0 - 100%");
                    return;
                }

                if (hourPerDay < 0 || hourPerDay > 8)
                {
                    MessageBox.Show("Số giờ chỉ nằm trong khoảng 0 - 8");
                    return;
                }

                _Task.Id = IdHelper.NewGuid();
                _Task.HourPerDay = hourPerDay;
                _Task.CompletePercent = percent;
                _Task.ReportDate = dtReportDate.DateTime;

                _Task.Status = percent == 100 ? RpTaskReportDailyModel.Constant.Status.DONE : RpTaskReportDailyModel.Constant.Status.PROCESSING;

                _Task.CreatedTime = DateTime.Now;
                _Task.UpdatedTime = DateTime.Now;
                _Task.CreatedUser = AppContext.UserName;
                _Task.UpdatedUser = AppContext.UserName;

                updateTask(_Task);

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void updateTask(RpTaskReportDailyModel reportTask)
        {
            //using (var con = AppContext.GetConnection())
            //{
            //    con.Open();
            //    con.Execute(RpTaskReportDailyModel.SQL_INSERT, reportTask);

            //    var originTask = con.QueryFirstOrDefault<RpTaskModel>($@"{RpTaskModel.SQL_SELECT} WHERE id = '{reportTask.TaskId}'");

            //    if (originTask == null)
            //    {
            //        MessageBox.Show($"Không tìm thấy task {reportTask.Code} với Id {reportTask.TaskId}");
            //        return;
            //    }

            //    if (originTask.Percent == 100)
            //    {
            //        MessageBox.Show($"Task đã xong nên không thể update!");
            //        return;
            //    }

            //    var taskSql = $@"UPDATE rp_task SET percent = '{reportTask.CompletePercent}', total_hour = '{originTask.TotalHour + reportTask.HourPerDay}'  WHERE id = '{originTask.Id}' ";
            //    con.Execute(taskSql);
            //}
        }

        private RpTaskReportDailyModel _Task = null;
        private void cboTasks_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var taskCode = cboTasks.EditValue.ToString();
                _Task = _lstTaskDaily.FirstOrDefault(x => x.Code == taskCode);
                if (_Task != null)
                {
                    txtCompletePercent.EditValue = _Task.CompletePercent;
                    txtHours.EditValue = _Task.HourPerDay;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
