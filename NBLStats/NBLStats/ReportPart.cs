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
    public partial class ReportPart : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        DateTime dtbeg;
        DateTime dtend;

        CGame clGame;

        public ReportPart(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void ReportPart_Load(object sender, EventArgs e)
        {
            try
            {
                clGame = new CGame(connect);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                read_param();

                create();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool create()
        {
            bool ret = true;

            try
            {
                ReportExcelParticipant cl = new ReportExcelParticipant(connect, IS, dtbeg, dtend);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private void read_param()
        {
            try
            {
                dtbeg = new DateTime(dateTimePickerDateBegin.Value.Year, dateTimePickerDateBegin.Value.Month,
                    dateTimePickerDateBegin.Value.Day, 0, 0, 0, 0);

                dtend = new DateTime(dateTimePickerDateEnd.Value.Year, dateTimePickerDateEnd.Value.Month,
                    dateTimePickerDateEnd.Value.Day, 23, 59, 59, 0);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
