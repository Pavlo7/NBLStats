using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NBLStats
{
    public partial class FanGameReportItog : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        int mode;

        public FanGameReportItog(SqlConnection cn, STInfoSeason si, int m)
        {
            InitializeComponent();

            connect = cn;
            IS = si;
            mode = m;
        }

        private void FanGameReportItog_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source);  }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxRound.Text.Length > 0)
                {
                    int r = int.Parse(textBoxRound.Text.Trim());

                    ReportExcelFanGameItog report = new ReportExcelFanGameItog(connect, IS, r);

                    report.Create();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}