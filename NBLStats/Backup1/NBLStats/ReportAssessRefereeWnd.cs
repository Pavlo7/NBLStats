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
    public partial class ReportAssessRefereeWnd : Form
    {
        SqlConnection connect;
        STInfoSeason IS;


        ReportAssessRefereeParam param;

        public ReportAssessRefereeWnd(SqlConnection cn, STInfoSeason iss)
        {
            InitializeComponent();
            connect = cn;
            IS = iss;
        }

        private void ReportAssessRefereeWnd_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerBegin.Value = IS.datebegin;
                dateTimePickerEnd.Value = DateTime.Now;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                param = new ReportAssessRefereeParam();
                param.dtbegin = new DateTime(dateTimePickerBegin.Value.Year, dateTimePickerBegin.Value.Month,
                    dateTimePickerBegin.Value.Day, 0, 0, 0, 0);
                param.dtend = new DateTime(dateTimePickerEnd.Value.Year, dateTimePickerEnd.Value.Month,
                    dateTimePickerEnd.Value.Day, 23, 59, 59, 0);

                ReportAssessReferee report = new ReportAssessReferee(connect, IS, param);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
