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
    public partial class DlgDivision : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STDivision gstDivision;
        CDivision clDivision;
        STInfoSeason IS;

        STDivision stC;

        public DlgDivision(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            IS = inf;

            caption = "Добавить дивизион";

           
        }

        public DlgDivision(SqlConnection cn, STInfoSeason inf, STDivision st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstDivision = st;
            IS = inf;

            caption = "Редактировать дивизион";

           
        }

        private void DlgDivision_Load(object sender, EventArgs e)
        {
            this.Text = caption;

            clDivision = new CDivision(connect);

            //textBoxName.Focus();

            set_data();
        }

        private void set_data()
        {
            groupBoxReg.Enabled = false;
            groupBoxPO.Enabled = false;
            groupBoxStyk.Enabled = false;

            textBoxCntTeamIn.Enabled = false;
            textBoxCntTeamOut.Enabled = false;

            try
            {
                textBoxName.Text = gstDivision.name;
                textBoxCntTeam.Text = gstDivision.cntteam.ToString();
                textBoxCntPlayer.Text = gstDivision.cntplayer.ToString();

                if (gstDivision.flag_reg == 1)
                {
                    checkBoxReg.Checked = true;
                    groupBoxReg.Enabled = true;
                    textBoxCntStageReg.Text = gstDivision.cntstagereg.ToString();
                    if (gstDivision.flag_wins_reg == 1)
                        checkBoxWinsReg.Checked = true;
                }
                else
                {
                    checkBoxReg.Checked = false;
                    groupBoxReg.Enabled = false;
                    textBoxCntStageReg.Text = "";
                    checkBoxWinsReg.Checked = false;
                }

                if (gstDivision.flag_po == 1)
                {
                    checkBoxPO.Checked = true;
                    groupBoxPO.Enabled = true;
                    textBoxCntTeamPO.Text = gstDivision.cntteampo.ToString();
                    textBoxCntStagePO.Text = gstDivision.cntstagepo.ToString();
                }
                else 
                {
                    checkBoxPO.Checked = false;
                    groupBoxPO.Enabled = false;
                    textBoxCntTeamPO.Text = "";
                    textBoxCntStagePO.Text = "";

                }

                if (gstDivision.flag_styk == 1)
                {
                    checkBoxStyk.Checked = true;
                    groupBoxStyk.Enabled = true;
                    textBoxCntTeamStyk.Text = gstDivision.cntteamstyk.ToString();
                }
                else
                {
                    checkBoxStyk.Checked = false;
                    groupBoxStyk.Enabled = false;
                    textBoxCntTeamStyk.Text = "";
                }

                if (gstDivision.flag_in == 1)
                {
                    checkBoxTeamIn.Checked = true;
                    textBoxCntTeamIn.Text = gstDivision.cntteamin.ToString();
                }
                else
                {
                    checkBoxTeamIn.Checked = false;
                    textBoxCntTeamIn.Text = "";
                }

                if (gstDivision.flag_out == 1)
                {
                    checkBoxTeamOut.Checked = true;
                    textBoxCntTeamOut.Text = gstDivision.cntteamout.ToString();
                }
                else
                {
                    checkBoxTeamOut.Checked = false;
                    textBoxCntTeamOut.Text = "";
                }

                if (gstDivision.deadline != null) dateTimePickerDead.Value = (DateTime)gstDivision.deadline;
                else dateTimePickerDead.Value = IS.dateend;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private STDivision read_data()
        {
            STDivision ret = new STDivision();

            try
            {
                /* основные параметры */
                ret.idseason = (int)IS.idseason;

                if (gstDivision.id != 0)
                    ret.id = gstDivision.id;
                else ret.id = clDivision.GetFreeId((int)IS.idseason);

                if (textBoxName.Text.Length > 0)
                    ret.name = textBoxName.Text.Trim();
                else ret.name = null;

                if (textBoxCntTeam.Text.Length > 0)
                    ret.cntteam = int.Parse(textBoxCntTeam.Text.Trim());
                else ret.cntteam = 0;

                if (textBoxCntPlayer.Text.Length > 0)
                    ret.cntplayer = int.Parse(textBoxCntPlayer.Text.Trim());
                else ret.cntplayer = 0;

                /* игры регулярки */
                if (checkBoxReg.CheckState == CheckState.Checked)
                {
                    ret.flag_reg = 1;
                    
                    if (textBoxCntStageReg.Text.Length > 0)
                        ret.cntstagereg = int.Parse(textBoxCntStageReg.Text.Trim());
                    else ret.cntstagereg = 0;

                    if (checkBoxWinsReg.CheckState == CheckState.Checked)
                        ret.flag_wins_reg = 1;
                    else ret.flag_wins_reg = 0;
                }
                else
                {
                    ret.flag_reg = 0;
                    ret.cntstagereg = 0;
                    ret.flag_wins_reg = 0;
                }

                /* игры плей-офф */
                if (checkBoxPO.CheckState == CheckState.Checked)
                {
                    ret.flag_po = 1;

                    if (textBoxCntStagePO.Text.Length > 0)
                        ret.cntstagepo = int.Parse(textBoxCntStagePO.Text.Trim());
                    else ret.cntstagepo = 0;

                    if (textBoxCntTeamPO.Text.Length > 0)
                        ret.cntteampo = int.Parse(textBoxCntTeamPO.Text.Trim());
                    else ret.cntteampo = 0;
                }
                else
                {
                    ret.flag_po = 0;
                    ret.cntstagepo = 0;
                    ret.cntteampo = 0;
                }

                /* стыковые игры */
                if (checkBoxStyk.CheckState == CheckState.Checked)
                {
                    ret.flag_styk = 1;

                    if (textBoxCntTeamStyk.Text.Length > 0)
                        ret.cntteamstyk = int.Parse(textBoxCntTeamStyk.Text.Trim());
                    else ret.cntteamstyk = 0;
                }
                else
                {
                    ret.flag_styk = 0;
                    ret.cntteamstyk = 0;
                }

                /* ротация */

                if (checkBoxTeamIn.CheckState == CheckState.Checked)
                {
                    ret.flag_in = 1;

                    if (textBoxCntTeamIn.Text.Length > 0)
                        ret.cntteamin = int.Parse(textBoxCntTeamIn.Text.Trim());
                    else ret.cntteamin = 0;
                }
                else
                {
                    ret.flag_in = 0;
                    ret.cntteamin = 0;
                }

                if (checkBoxTeamOut.CheckState == CheckState.Checked)
                {
                    ret.flag_out = 1;

                    if (textBoxCntTeamOut.Text.Length > 0)
                        ret.cntteamout = int.Parse(textBoxCntTeamOut.Text.Trim());
                    else ret.cntteamout = 0;
                }
                else
                {
                    ret.flag_out = 0;
                    ret.cntteamout = 0;
                }

                ret.deadline = new DateTime(dateTimePickerDead.Value.Year, dateTimePickerDead.Value.Month,
                    dateTimePickerDead.Value.Day, 0, 0, 0, 0);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            stC = read_data();

            if (gstDivision.id != 0)
                ret = clDivision.Update(stC);
            else
                ret = clDivision.Insert(stC);

            return ret;
        }

        public STDivision GetFl()
        {
            return stC;
        }

        private void checkBoxReg_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReg.CheckState == CheckState.Checked)
            {
                groupBoxReg.Enabled = true;
                textBoxCntStageReg.Focus();
            }
            else
            {
                textBoxCntStageReg.Text = "";
                checkBoxWinsReg.Checked = false;
                groupBoxReg.Enabled = false;
            }
        }
        private void checkBoxPO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPO.CheckState == CheckState.Checked)
            {
                groupBoxPO.Enabled = true;
                textBoxCntStagePO.Focus();
            }
            else
            {
                textBoxCntStagePO.Text = "";
                textBoxCntTeamPO.Text = "";
                groupBoxPO.Enabled = false;
            }
        }
        private void checkBoxStyk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStyk.CheckState == CheckState.Checked)
            {
                groupBoxStyk.Enabled = true;
                textBoxCntTeamStyk.Focus();
            }
            else
            {
                textBoxCntTeamStyk.Text = "";
                groupBoxStyk.Enabled = false;
            }
        }
        private void checkBoxWinsReg_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWinsReg.CheckState == CheckState.Checked)
            {
                checkBoxPO.CheckState = CheckState.Unchecked;
                checkBoxPO.Enabled = false;

                groupBoxPO.Enabled = false;
                textBoxCntTeamPO.Text = "";
                textBoxCntStagePO.Text = "";
            }
            else
            {
                checkBoxPO.Enabled = true;
            }
        }
        private void checkBoxTeamIn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTeamIn.CheckState == CheckState.Checked)
            {
                textBoxCntTeamIn.Enabled = true;
                textBoxCntTeamIn.Focus();
            }
            else
            {
                textBoxCntTeamIn.Text = "";
                textBoxCntTeamIn.Enabled = false;
            }
        }
        private void checkBoxTeamOut_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTeamOut.CheckState == CheckState.Checked)
            {
                textBoxCntTeamOut.Enabled = true;
                textBoxCntTeamOut.Focus();
            }
            else
            {
                textBoxCntTeamOut.Text = "";
                textBoxCntTeamOut.Enabled = false;
            }
        }

    }
}