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
        private List<RpTaskReportDailyModel> _lstAllTaskDaily;
        private RpTaskReportDailyRepo _repoRepostDaily = new RpTaskReportDailyRepo();

        public DailyReport()
        {
            InitializeComponent();

            dtReportDate.EditValue = DateTime.Now;

            var user = AppContext.GetUserProfile();
            var staffCode = user.StaffCode;

            _lstAllTaskDaily = _repoRepostDaily.Find(x => x.AsigneeCode == staffCode);

            _lstTaskDaily = getTaskDailyDataSource(_lstAllTaskDaily);
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
                if (_lstCreate.IsNullOrEmpty())
                {
                    MessageBox.Show("Làm gì có gì mà update!");
                    return;
                }

                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                _repoRepostDaily.BulkInsert(_lstCreate);

                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private RpTaskReportDailyModel _selecetedTask = null;
        private void cboTasks_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var taskCode = cboTasks.EditValue.ToString();
                _selecetedTask = _lstTaskDaily.FirstOrDefault(x => x.Code == taskCode);
                if (_selecetedTask != null)
                {
                    txtCompletePercent.EditValue = _selecetedTask.CompletePercent;
                    txtHours.EditValue = _selecetedTask.HourPerDay;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private List<RpTaskReportDailyModel> _lstCreate;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_lstCreate.IsNullOrEmpty())
                {
                    _lstCreate = new List<RpTaskReportDailyModel>();
                }

                decimal percent = decimal.Parse(txtCompletePercent.EditValue.ToString());

                if (percent == 0)
                {
                    MessageBox.Show("0% kìa. Không làm thì thôi k cần báo cáo đâu!");
                    return;
                }

                var hourPerDay = decimal.Parse(txtHours.EditValue.ToString());

                if (_lstCreate.HasItem())
                {
                    var isExist = _lstCreate.Any(x => x.Code == _selecetedTask.Code);
                    if (isExist)
                    {
                        MessageBox.Show("Đã tồn tại task trong list định báo cáo!");
                        return;
                    }
                }

                var objExistByDate = _lstAllTaskDaily.FirstOrDefault(x => x.Code == _selecetedTask.Code && x.ReportDate == dtReportDate.DateTime.Date && x.Status != RpTaskReportDailyModel.Constant.Status.CREATE);
                if (objExistByDate != null)
                {
                    MessageBox.Show($"Task {objExistByDate.FullName} này đã báo cáo ngày {objExistByDate.ReportDate.ToString("dd/MM/yyyy")}");
                    return;
                }

                if (percent < 0 || percent > 100)
                {
                    MessageBox.Show("Phần % chỉ nằm trong khoảng 0 - 100%");
                    return;
                }

                if (hourPerDay <= 0 || hourPerDay > 8)
                {
                    MessageBox.Show("Số giờ chỉ nằm trong khoảng lớn hơn 0 nhỏ hơn 8");
                    return;
                }

                var originTask = _repoRepostDaily.FirstOrDefault(x => x.Id == _selecetedTask.Id);

                if (originTask == null)
                {
                    MessageBox.Show($"Không tìm thấy task {_selecetedTask.Code} với Id {_selecetedTask.TaskId}");
                    return;
                }

                if (originTask.CompletePercent == 100)
                {
                    MessageBox.Show($"Task đã xong nên không thể update!");
                    return;
                }

                if (originTask.ReportDate.Date > dtReportDate.DateTime.Date)
                {
                    MessageBox.Show($"Ngày báo cáo không thể nhỏ hơn ngày báo cáo trước!");
                    return;
                }

                if (percent < originTask.CompletePercent)
                {
                    MessageBox.Show($"% đang nhỏ hơn % hôm trước!");
                    return;
                }

                _selecetedTask.Id = IdHelper.NewGuid();
                _selecetedTask.HourPerDay = hourPerDay;
                _selecetedTask.CompletePercent = percent;
                _selecetedTask.ReportDate = dtReportDate.DateTime;
                _selecetedTask.LastReportId = originTask.Id;

                _selecetedTask.Status = percent == 100 ? RpTaskReportDailyModel.Constant.Status.DONE : RpTaskReportDailyModel.Constant.Status.PROCESSING;

                _selecetedTask.CreatedTime = DateTime.Now;
                _selecetedTask.UpdatedTime = DateTime.Now;
                _selecetedTask.CreatedUser = AppContext.UserName;
                _selecetedTask.UpdatedUser = AppContext.UserName;

                _lstCreate.Add(_selecetedTask);

                gridView.DataSource = _lstCreate;
                gridView.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
