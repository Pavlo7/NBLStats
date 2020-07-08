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
   
    public partial class ReportReferee : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CInfoSeason clIS;

        STParamReportReferee param;

        public ReportReferee(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;

        }

        private void ReportReferee_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtonOneSeason.Checked = true;

                clIS = new CInfoSeason(connect);

                init_combo();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            try
            {
                comboBoxNameSeason.Items.Clear();

                List<STInfoSeason> lst = clIS.GetListSeason();

                foreach (STInfoSeason item in lst)
                {
                    comboBoxNameSeason.Items.Add(item.nameseason);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                param = read_param();

                create();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            DialogResult = DialogResult.OK;
        }

        private bool create()
        {
            bool ret = true;

            try
            {
                ReportExcelReferee cl = new ReportExcelReferee(connect,param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false;  }

            return ret;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void radioButtonOneSeason_CheckedChanged(object sender, EventArgs e) 
        {
            if (radioButtonOneSeason.Checked == true)
            {
                comboBoxNameSeason.Enabled = true;
            }
        }

        private void radioButtonAllSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAllSeason.Checked == true)
            {
                comboBoxNameSeason.Text = null;
                comboBoxNameSeason.Enabled = false;
            }
        }

        private STParamReportReferee read_param()
        {
            STParamReportReferee ret = new STParamReportReferee();
           
            int? i = null;

            try
            {
                if (radioButtonAllSeason.Checked == true) ret.idseason = 0;
                if (radioButtonOneSeason.Checked == true)
                {
                   i = clIS.GetId(comboBoxNameSeason.Text.Trim());

                   if (i != null) ret.idseason = (int)i;
                   else ret.idseason = -1;
                }

                if (checkBoxDate.Checked == true)
                {
                    ret.dtbegin = new DateTime(dateTimePickerDateBigin.Value.Year,
                        dateTimePickerDateBigin.Value.Month, dateTimePickerDateBigin.Value.Day, 0, 0, 0, 0);
                    ret.dtend = new DateTime(dateTimePickerDateEnd.Value.Year,
                        dateTimePickerDateEnd.Value.Month, dateTimePickerDateEnd.Value.Day, 23, 59, 59, 0);
                }
                else
                {
                    ret.dtbegin = null;
                    ret.dtend = null;
                }

                ret.filename = string.Format("Статистика_судей_{0}_{1}_{2}_{3}_{4}", DateTime.Now.Year, 
                    DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}