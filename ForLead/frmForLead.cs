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
    public partial class frmForLead : frmBase
    {
        public frmForLead()
        {
            InitializeComponent();
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmCreateTask();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void btnGetReportWeekly_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }

        }
    }
}
