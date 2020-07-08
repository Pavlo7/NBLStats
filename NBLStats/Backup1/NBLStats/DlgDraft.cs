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
    public partial class DlgDraft : Form
    {
        SqlConnection connect;                   /* коннект */
        STInfoSeason IS;                         /* параметры сезона */

        STDraftPlayer? oldData;                 /* структура передаваемая */
        STDraftPlayer rData;                    /* структура заявки игрока редактируемая */

        ushort mode;

        CDraft clWork;
        CPlayer clPlayer;
        CTeam clTeam;

        STPlayerParam view_param;

        public DlgDraft(SqlConnection cn, STInfoSeason inf, STDraftPlayer? data)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            oldData = data;
        }

        private void DlgDraft_Load(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                clWork = new CDraft(connect);
                clPlayer = new CPlayer(connect);
                clTeam = new CTeam(connect);

                view_param.idseason = null;

                init_combo_players();
                init_combo_team();

                if (oldData != null) mode = 1;
                else mode = 0;

                if (mode == 0)
                {
                    text = "Добавить игрока на драфт";

                    checkBoxOut.CheckState = CheckState.Unchecked;
                    dateTimePickerDateOut.Enabled = false;
                }
                if (mode == 1)
                {
                    text = "Редактировать игрока на драфте";
                    set_data((STDraftPlayer)oldData);
                }

                this.Text = text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_team()
        {
            try
            {
                comboBoxIdLastTeam.Items.Clear();
                comboBoxIdNextTeam.Items.Clear();

                List<STTeam> lst = clTeam.GetListTeam(IS.idseason);
                List<STTeam> lst2 = clTeam.GetListTeam(0);

                comboBoxIdLastTeam.Items.Add("");
                comboBoxIdNextTeam.Items.Add("");

                foreach (STTeam item in lst)
                {
                    //comboBoxIdLastTeam.Items.Add(item.name);
                    comboBoxIdNextTeam.Items.Add(item.name);
                }

                foreach (STTeam item in lst2)
                {
                    comboBoxIdLastTeam.Items.Add(item.name);
                    //comboBoxIdNextTeam.Items.Add(item.name);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_players()
        {
            comboBoxName.Items.Clear();

            string text = null;

            try
            {
                CPlayer player = new CPlayer(connect);

                List<STPlayer> list = player.GetList(view_param);

                foreach (STPlayer item in list)
                {
                    text = string.Format("{0} {1} ({2})", item.family, item.name, item.personalnum);
                    comboBoxName.Items.Add(text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void set_data(STDraftPlayer data)
        {
            string text = null;

            try
            {
                CPlayer part = new CPlayer(connect, data.idplayer);

                text = string.Format("{0} {1} ({2})", data.family, data.name,
                         data.personalnum);

                comboBoxName.Text = text;

                dateTimePickerDateIn.Value = data.dtin;

                textBoxGrowing.Text = data.growing.ToString();
                textBoxWeight.Text = data.weight.ToString();

                if (data.amplua == 1 || data.amplua == 4 || data.amplua == 5 || data.amplua == 7)
                    checkBoxAD.Checked = true;
                if (data.amplua == 2 || data.amplua == 4 || data.amplua == 6 || data.amplua == 7)
                    checkBoxAF.Checked = true;
                if (data.amplua == 3 || data.amplua == 5 || data.amplua == 6 || data.amplua == 7)
                    checkBoxAC.Checked = true;

                comboBoxIdLastTeam.Text = data.namelastteam;
                comboBoxIdNextTeam.Text = data.namenextteam;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private STDraftPlayer read_data()
        {
            STDraftPlayer ret = new STDraftPlayer();

            try
            {
                if (comboBoxName.Text.Length > 0)
                {
                    ret.idplayer = clPlayer.stPlayer.idplayer;
                }
                else ret.idplayer = 0;

                ret.dtin = new DateTime(dateTimePickerDateIn.Value.Year, dateTimePickerDateIn.Value.Month,
                    dateTimePickerDateIn.Value.Day, 0, 0, 0, 0);

                if (comboBoxIdLastTeam.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxIdLastTeam.Text.Trim());
                    ret.idlastteam = clTeam.stTeam.id;
                }
                else ret.idlastteam = 0;

                if (textBoxGrowing.Text.Length > 0)
                    ret.growing = int.Parse(textBoxGrowing.Text.Trim());
                else ret.growing = 0;

                if (textBoxWeight.Text.Length > 0)
                    ret.weight = int.Parse(textBoxWeight.Text.Trim());
                else ret.weight = 0;

                ret.amplua = 0;

                if (checkBoxAD.Checked == true)
                {
                    ret.amplua = 1;
                }
                if (checkBoxAF.Checked == true)
                {
                    ret.amplua = 2;
                }
                if (checkBoxAC.Checked == true)
                {
                    ret.amplua = 3;
                }
                if (checkBoxAD.Checked == true && checkBoxAF.Checked == true)
                {
                    ret.amplua = 4;
                }
                if (checkBoxAF.Checked == true && checkBoxAC.Checked == true)
                {
                    ret.amplua = 5;
                }
                if (checkBoxAF.Checked == true && checkBoxAC.Checked == true)
                {
                    ret.amplua = 6;
                }
                if (checkBoxAD.Checked == true && checkBoxAF.Checked == true && checkBoxAC.Checked == true)
                {
                    ret.amplua = 7;
                }

                if (checkBoxOut.Checked == true)
                {
                    ret.dtout = new DateTime(dateTimePickerDateOut.Value.Year, dateTimePickerDateOut.Value.Month,
                        dateTimePickerDateOut.Value.Day, 0, 0, 0, 0);

                    if (comboBoxIdNextTeam.Text.Length > 0)
                    {
                        clTeam = new CTeam(connect, comboBoxIdNextTeam.Text.Trim());
                        ret.idnextteam = clTeam.stTeam.id;
                    }
                    else ret.idnextteam = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxName.Text.Length > 0)
                {
                    char[] del = { ' ', '(', ')' };

                    string s = comboBoxName.Text.Trim();

                    string[] words = s.Split(del);

                    clPlayer = new CPlayer(connect, words[0].Trim(), words[1].Trim(), words[3].Trim());
                    CEntryPlayers cl = new CEntryPlayers(connect);

                    int idt = cl.IsEntryPlayer(IS.idseason, clPlayer.stPlayer.idplayer);


                    if (idt != 0)
                    {
                        CTeam tm = new CTeam(connect, idt);
                        labelIsDemind.ForeColor = Color.Red;
                        labelIsDemind.Text = string.Format("{0}", tm.stTeam.name);

                    }
                    else
                    {
                        labelIsDemind.ForeColor = Color.DarkGreen;
                        labelIsDemind.Text = "свободен";
                    }


                    string str1 = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);

                }
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
                rData = read_data();

                if (rData.idplayer > 0)
                {

                    if (mode == 1)
                    {
                        STDraftPlayer od = (STDraftPlayer)oldData;
                        if (clWork.Update(rData, od.idplayer, od.dtin)) DialogResult = DialogResult.OK;
                    }

                    if (mode == 0)
                    {
                        if (clWork.Insert(rData)) DialogResult = DialogResult.OK;
                    }
                }
                else
                    MessageBox.Show("Не все обязательные поля заполнены", "Внимание!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        public STDraftPlayer GetFl()
        {
            return rData;
        }

        private void checkBoxOut_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOut.Checked == true)
            {
                dateTimePickerDateOut.Enabled = true;
                comboBoxIdNextTeam.Enabled = true;
            }
            else
            {
                dateTimePickerDateOut.Enabled = false;
                comboBoxIdNextTeam.Enabled = false;
            }
        }
    }
}
