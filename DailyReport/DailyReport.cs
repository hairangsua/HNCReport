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
        public DailyReport()
        {
            InitializeComponent();

            var user = AppContext.GetUserProfile();
            using (var con = AppContext.GetConnection())
            {
                con.Open();
                var lstTask = con.Query<RpTaskDailyReportModel>($"SELECT * FROM rp_task_report_daily WHERE asignee_code = {user.StaffCode}") as List<RpTaskDailyReportModel>;
                if (lstTask.HasItem())
                {
                    cboTasks.Properties.DataSource = lstTask;
                    cboTasks.Properties.DisplayMember = nameof(RpTaskDailyReportModel.Name);
                    cboTasks.Properties.ValueMember = nameof(RpTaskDailyReportModel.Code);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
