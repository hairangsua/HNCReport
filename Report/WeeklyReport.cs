using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BL.RpTaskReportDaily.XtraReportModel;

namespace HNCReport.Report
{
    public partial class WeeklyReport : DevExpress.XtraReports.UI.XtraReport
    {
        public WeeklyReport()
        {
            InitializeComponent();
        }

        public void SetDataSource(XtraReportDateDataSourceModel aData)
        {
            objectDataSource1.DataSource = aData;
        }

        public static WeeklyReport GetReport(XtraReportDateDataSourceModel aData)
        {
            var rpt = new WeeklyReport();

            rpt.SetDataSource(aData);

            return rpt;
        }

    }
}
