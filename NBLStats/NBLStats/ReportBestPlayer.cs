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
                init_combo_date();

                textBoxLimit2.Text = "3,1";
                textBoxLimit3.Text = "1,2";
                textBoxLimitFt.Text = "1,9";

                textBoxPCG.Text = "51";

                textBoxCntPlayer.Text = "30";

                radioButtonOneDate.Checked = true;
                dateTimePickerDateEnd.Enabled = false;
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_date()
        {
            try
            {
                // ��������������� ���� ��������� ������� ����
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

     //       DialogResult = DialogResult.OK;
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

                if (radioButtonOneDate.Checked == true)
                {
                    ret.bdate = true;
                    ret.dtbeg = dateTimePickerDateBegin.Value;
                }

                if (radioButtonPeriodDate.Checked == true)
                {
                    ret.bdate = false;
                    ret.dtbeg = dateTimePickerDateBegin.Value;
                    ret.dtend = dateTimePickerDateEnd.Value;
                }


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

                string text = null;
                ret.lst_idgroup = new List<int>();
                CGroup clGroup = new CGroup(connect);
                for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
                {
                    if (checkedListBoxGroup.GetItemChecked(i))
                    {
                        clGroup = new CGroup(connect, IS.idseason, ret.iddivision, checkedListBoxGroup.Items[i].ToString());
                        if (!string.IsNullOrEmpty(text)) text += string.Format(",{0}", clGroup.stGroup.idgroup);
                        else text = clGroup.stGroup.idgroup.ToString();
                        ret.lst_idgroup.Add(clGroup.stGroup.idgroup);
                    }
                }
                if (!string.IsNullOrEmpty(text)) ret.strgroup = text;
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

                init_list_group(gDiv);
            }
            else gDiv = 0;

        }

        private void comboBoxTypeGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypeGame.Text.Length > 0)
                gType = tp.GetTypeCode(comboBoxTypeGame.Text.Trim());
            else gType = -1;
        }

        private void radioButtonOneDate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOneDate.Checked == true)
                dateTimePickerDateEnd.Enabled = false;

        }

        private void radioButtonPeriodDate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPeriodDate.Checked == true)
                dateTimePickerDateEnd.Enabled = true;
        }

        private void init_list_group(int id)
        {
            try
            {
                checkedListBoxGroup.Items.Clear();

                CGroup clGroup = new CGroup(connect);
                List<STGroup> lst = clGroup.GetListGroup(IS.idseason, id);

                foreach (STGroup group in lst)
                {
                    checkedListBoxGroup.Items.Add(group.namegroup);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        
    }
}