using HNCReport.Task;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HNCReport.ForLead
{
    public partial class frmForStaff : frmBase
    {
        public frmForStaff()
        {
            InitializeComponent();
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new DailyReport();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
