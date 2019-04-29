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
using HNCReport.Model;
using HNCReport.CommonDTO;
using HNCReport.Helper;

namespace HNCReport
{
    public partial class DailyReport : frmBase
    {
        private List<RpTaskDailyReportModel> _lstTaskDaily;

        public DailyReport()
        {
            InitializeComponent();

            dtReportDate.EditValue = DateTime.Now;

            var user = AppContext.GetUserProfile();
            using (var con = AppContext.GetConnection())
            {
                con.Open();
                var lstAllTask = con.Query<RpTaskDailyReportModel>($@"{RpTaskDailyReportModel.SQL_SELECT} WHERE asignee_code = '{user.StaffCode}';") as List<RpTaskDailyReportModel>;
                _lstTaskDaily = getTaskDailyDataSource(lstAllTask);
                if (_lstTaskDaily.HasItem())
                {
                    cboTasks.Properties.DataSource = _lstTaskDaily;
                    cboTasks.Properties.DisplayMember = nameof(RpTaskDailyReportModel.FullName);
                    cboTasks.Properties.ValueMember = nameof(RpTaskDailyReportModel.Code);
                }
            }
        }

        private List<RpTaskDailyReportModel> getTaskDailyDataSource(List<RpTaskDailyReportModel> lstAllTask)
        {
            var rs = new List<RpTaskDailyReportModel>();

            var lstDone = lstAllTask.Where(x => x.Status == RpTaskDailyReportModel.Constant.Status.DONE).Select(x => x.Code).Distinct().ToList();

            var lstCode = lstAllTask.Where(x => x.Status != RpTaskDailyReportModel.Constant.Status.DONE && !lstDone.Contains(x.Code)).Select(x => x.Code).Distinct().ToList();
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

                _Task.Status = percent == 100 ? RpTaskDailyReportModel.Constant.Status.DONE : RpTaskDailyReportModel.Constant.Status.PROCESSING;

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

        private void updateTask(RpTaskDailyReportModel reportTask)
        {
            using (var con = AppContext.GetConnection())
            {
                con.Open();
                con.Execute(RpTaskDailyReportModel.SQL_INSERT, reportTask);

                var originTask = con.QueryFirstOrDefault<RpTaskModel>($@"{RpTaskModel.SQL_SELECT} WHERE id = '{reportTask.TaskId}'");

                if (originTask == null)
                {
                    MessageBox.Show($"Không tìm thấy task {reportTask.Code} với Id {reportTask.TaskId}");
                    return;
                }

                if (originTask.Percent == 100)
                {
                    MessageBox.Show($"Task đã xong nên không thể update!");
                    return;
                }

                var taskSql = $@"UPDATE rp_task SET percent = '{reportTask.CompletePercent}', total_hour = '{originTask.TotalHour + reportTask.HourPerDay}'  WHERE id = '{originTask.Id}' ";
                con.Execute(taskSql);
            }
        }

        private RpTaskDailyReportModel _Task = null;
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
