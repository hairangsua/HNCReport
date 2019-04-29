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

namespace HNCReport
{
    public partial class DailyReport : frmBase
    {
        public DailyReport()
        {
            InitializeComponent();
        }

        private List<StringCodeName> getTaskNotCompleteByUsername(string userName)
        {
            using (var con = AppContext.GetConnection())
            {
                con.Open();
                var rp = con.Query<RpTaskDailyReportModel>("SELECT * FROM rp_task_report_daily");
            }

            return new List<StringCodeName>();
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
