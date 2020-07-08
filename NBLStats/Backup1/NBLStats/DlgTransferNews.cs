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
    public partial class DlgTransferNews : Form 
    {
        SqlConnection connect;
        STInfoSeason IS;

        DateTime param_dtbegin;
        DateTime param_dtend;

        int mode;

        public DlgTransferNews(SqlConnection cn, STInfoSeason inf, int md)  
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void DlgTransferNews_Load(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                if (mode == 1) text = "Трансферные новости (для сайта)";
                if (mode == 2) text = "Новости драфта (для сайта)";

                this.Text = text;

                DateTime dtbegin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);
                DateTime dtend = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0, 0);

                dateTimePickerDateBegin.Value = dtbegin;
                dateTimePickerTimeBegin.Value = dtbegin;
                dateTimePickerDateEnd.Value = dtend;
                dateTimePickerTimeEnd.Value = dtend;
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message, ex.Source + " DlgTransferNews:: DlgTransferNews_Load()"); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Create()) DialogResult = DialogResult.OK;
        }

        private bool Create()
        {
            bool ret = true;

            try
            {
                param_dtbegin = new DateTime(dateTimePickerDateBegin.Value.Year, dateTimePickerDateBegin.Value.Month,
                            dateTimePickerDateBegin.Value.Day, dateTimePickerTimeBegin.Value.Hour,
                            dateTimePickerTimeBegin.Value.Minute, 0, 0);
                param_dtend = new DateTime(dateTimePickerDateEnd.Value.Year, dateTimePickerDateEnd.Value.Month,
                    dateTimePickerDateEnd.Value.Day, dateTimePickerTimeEnd.Value.Hour,
                    dateTimePickerTimeEnd.Value.Minute, 0, 0); ;

                if (mode == 1)
                {
                    WebReportTextTransferNews cl = new WebReportTextTransferNews(connect, IS, param_dtbegin, param_dtend);
                }
                if (mode == 2)
                {
                    WebReportTextNewsDraft clD = new WebReportTextNewsDraft(connect, IS, param_dtbegin, param_dtend);
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, ex.Source + " DlgTransferNews:: Create()"); ret = false; }

            return ret;
        }
    }
}
