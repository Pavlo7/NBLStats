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
    public partial class ReportExcelProtocols : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        STParamExcelProtocls param;

        public ReportExcelProtocols(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void ReportExcelProtocols_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxGame1.Focus();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool create()
        {
            bool ret = true;

            try
            {
                ExcelProtocols cl = new ExcelProtocols(connect, param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private STParamExcelProtocls read_param()
        {
            STParamExcelProtocls ret = new STParamExcelProtocls();

            int rank = 1;

            int g1 = 0;
            int g2 = 0;

            try
            {
                ret.idseason = IS.idseason;

                if (textBoxGame1.Text.Length > 0) g1 = int.Parse(textBoxGame1.Text.Trim());
                if (textBoxGame2.Text.Length > 0)
                {
                    g2 = int.Parse(textBoxGame2.Text.Trim());

                    if (g1 <= g2)
                    {
                        rank = g2 - g1 + 1;
                        ret.arr_games = new int[rank];

                        for (int i = 0; i < rank; i++)
                        {
                            ret.arr_games[i] = g1 + i;
                        }
                    }
                }
                else
                {
                    ret.arr_games = new int[rank];
                    ret.arr_games[0] = g1;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}