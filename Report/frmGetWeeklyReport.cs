using BL.RpStaff;
using BL.RpTaskReportDaily;
using BL.RpTaskReportDaily.XtraReportModel;
using DevExpress.XtraPrinting.Preview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNCReport.Report
{
    public partial class frmGetWeeklyReport : frmBase
    {
        private RpTaskReportDailyRepo _repoReport = new RpTaskReportDailyRepo();

        public frmGetWeeklyReport()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {

                var defaultData = XtraReportModel.GetDefaultData(dtFromDate.DateTime.Date, dtToDate.DateTime.Date, RpStaffModel.Constant.TEAM_WEB_ERP);

                var lst = _repoReport.Find(x => x.Status != RpTaskReportDailyModel.Constant.Status.CREATE);

                var rpt = WeeklyReport.GetReport(new XtraReportDateDataSourceModel { Data = XtraReportModel.Get(defaultData, lst) });
                //var docView = new DocumentViewer();
                //docView.DocumentSource = rpt;
                //rpt.CreateDocument();

                rpt.ExportToXlsx(AppDomain.CurrentDomain.BaseDirectory + "/a.xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void dtFromDate_Validated(object sender, EventArgs e)
        {
            try
            {
                if (dtFromDate.DateTime == null)
                {
                    return;
                }

                dtToDate.DateTime = dtFromDate.DateTime.AddDays(6);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
