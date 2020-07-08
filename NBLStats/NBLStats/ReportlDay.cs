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
    public partial class ReportlDay : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        STParamReportDay param;

        public ReportlDay(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void ReportExcelDay_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
                ReportExcelDay cl = new ReportExcelDay(connect, param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private STParamReportDay read_param()
        {
            STParamReportDay ret = new STParamReportDay();

            try
            {
                ret.idseason = IS.idseason;
                ret.dtbeg = new DateTime(dateTimePickerBegin.Value.Year, dateTimePickerBegin.Value.Month,
                    dateTimePickerBegin.Value.Day, 0, 0, 0, 0);
                ret.dtend = new DateTime(dateTimePickerEnd.Value.Year, dateTimePickerEnd.Value.Month,
                    dateTimePickerEnd.Value.Day, 0, 0, 0, 0);

                CGame clGame = new CGame(connect);

                STGameParam pr = new STGameParam();
                pr.idseason = IS.idseason;
                pr.dt = ret.dtbeg;

                List<STGame> list = clGame.GetListGames(pr);

                ret.arr_games = new int[list.Count];

                for (int i = 0; i < list.Count; i++ )
                {
                    ret.arr_games[i] = list[i].idgame;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}