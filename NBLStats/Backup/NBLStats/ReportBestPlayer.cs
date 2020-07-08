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
    public partial class ReportBestPlayer : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CDivision clDiv;
        CTypeGames tp;

        CScheme clScheme;

        STParamReportBestPlayer param;

        int gDiv, gType;

        public ReportBestPlayer(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void ReportBestPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                clDiv = new CDivision(connect);
                tp = new CTypeGames();


                init_combo_type();
                init_combo_division();

                textBoxLimit2.Text = "3,1";
                textBoxLimit3.Text = "1,2";
                textBoxLimitFt.Text = "1,9";

                textBoxPCG.Text = "51";

                textBoxCntPlayer.Text = "30";
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_division()
        {
            try
            {
                List<STDivision> lst = clDiv.GetListDivision(IS.idseason);

                foreach (STDivision item in lst)
                {
                    comboBoxDivision.Items.Add(item.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_type()
        {
            try
            {
                STTypeGame[] st = tp.types;

                foreach (STTypeGame item in st)
                    comboBoxTypeGame.Items.Add(item.name);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_stage()
        {
            try
            {
                comboBoxStage.Items.Clear();
                comboBoxStage.Text = null;

                clScheme = new CScheme(connect);
                List<STScheme> list = clScheme.GetListScheme(IS.idseason, gDiv, gType);

                if (list.Count > 0)
                {
                    comboBoxStage.Items.Add("");

                    comboBoxStage.Enabled = true;

                    foreach (STScheme item in list)
                        comboBoxStage.Items.Add(item.namestage);
                }
                else comboBoxStage.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
                ReportExcelBestPlayer cl = new ReportExcelBestPlayer(connect, param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private STParamReportBestPlayer read_param()
        {
            STParamReportBestPlayer ret = new STParamReportBestPlayer();

            try
            {
                ret.idseason = IS.idseason;

                if (comboBoxTypeGame.Text.Length > 0)
                    ret.type = tp.GetTypeCode(comboBoxTypeGame.Text.Trim());
                else ret.type = -1;

                if (comboBoxDivision.Text.Length > 0)
                {
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                    ret.iddivision = clDiv.stDiv.id;
                }
                else ret.iddivision = 0;

                if (comboBoxStage.Text.Length > 0)
                {
                    clScheme = new CScheme(connect, ret.idseason, ret.iddivision, comboBoxStage.Text.Trim());
                    ret.idstage = clScheme.stScheme.idstage;
                }

                if (textBoxRound.Text.Length > 0)
                    ret.round = int.Parse(textBoxRound.Text.Trim());
                else ret.round = 0;

                if (textBoxLimit2.Text.Length > 0)
                    ret.limit2 = double.Parse(textBoxLimit2.Text.Trim());
                else ret.limit2 = 0;

                if (textBoxLimit3.Text.Length > 0)
                    ret.limit3 = double.Parse(textBoxLimit3.Text.Trim());
                else ret.limit3 = 0;

                if (textBoxLimitFt.Text.Length > 0)
                    ret.limitft = double.Parse(textBoxLimitFt.Text.Trim());
                else ret.limitft = 0;

                if (textBoxPCG.Text.Length > 0)
                    ret.pcg = int.Parse(textBoxPCG.Text.Trim());
                else ret.pcg = 0;

                if (textBoxCntPlayer.Text.Length > 0)
                    ret.cntplayer = int.Parse(textBoxCntPlayer.Text.Trim());
                else ret.cntplayer = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDivision.Text.Length > 0)
            {
                clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                gDiv = clDiv.stDiv.id;
            }
            else gDiv = 0;

            init_combo_stage();
        }

        private void comboBoxTypeGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypeGame.Text.Length > 0)
                gType = tp.GetTypeCode(comboBoxTypeGame.Text.Trim());
            else gType = -1;

            init_combo_stage();
        }
    }
}