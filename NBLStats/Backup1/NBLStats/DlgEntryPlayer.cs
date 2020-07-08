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
    public partial class DlgEntryPlayer : Form
    {
        SqlConnection connect;                   /* ������� */
        STInfoSeason IS;                         /* ��������� ������ */

        STEntryPlayers? oldData;                 /* ��������� ������������ */
        STEntryPlayers rData;                    /* ��������� ������ ������ ������������� */

     //   int idteam;                              /* ������� */
     //   DateTime datein;                         /* ���� ������ ������� */

        ushort mode;

        CEntryPlayers clWork;
        CTeam clTeam;
        CPlayer clPlayer;

        CDraft clDraft;
        STDraftPlayer stDraft;
        bool bDraft;

        STPlayerParam view_param;

        int recomendedteam;

        public DlgEntryPlayer(SqlConnection cn, STInfoSeason inf, STEntryPlayers? data, int rt)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            oldData = data;

            recomendedteam = rt;
        }


        private void DlgTeamsPlayer_Load(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                clWork = new CEntryPlayers(connect);
                clTeam = new CTeam(connect);
                clDraft = new CDraft(connect);
              
                init_combo_players();
                init_combo_team();

                if (oldData != null) mode = 1;
                else mode = 0;

                if (mode == 0)
                {
                    text = "�������� ������ ������";

                    DateTime dttt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0);

                    if (DateTime.Now <= IS.datebegin)
                    {
                        dateTimePickerDate.Value = IS.datebegin;
                        dateTimePickerTimeIn.Value = dttt;
                    }
                    else
                    {
                        dateTimePickerDate.Value = dttt;
                        dateTimePickerTimeIn.Value = dttt;
                    }


                    if (recomendedteam != null)
                    {
                        clTeam = new CTeam(connect, recomendedteam);
                        comboBoxTeam.Text = clTeam.stTeam.name;
                    }

                    checkBoxOut.CheckState = CheckState.Unchecked;
                    dateTimePickerDateOut.Enabled = false;
                    dateTimePickerTimeOut.Enabled = false;

                    textBoxPriority.Text = "0";

                }
                if (mode == 1)
                {
                    text = "������������� ������ ������";
                    set_data((STEntryPlayers)oldData);
                }

                view_param.idseason = null;

                this.Text = text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_team()
        {
            try
            {
                comboBoxTeam.Items.Clear();

                List<STTeam> lst = clTeam.GetListTeam(IS.idseason);

                foreach (STTeam item in lst)
                {
                    comboBoxTeam.Items.Add(item.name);
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

        private void set_data(STEntryPlayers data)
        {
            string text = null;

            try
            {

                CPlayer part = new CPlayer(connect, data.idplayer);

                text = string.Format("{0} {1} ({2})", part.stPlayer.family, part.stPlayer.name,
                         part.stPlayer.personalnum);

                comboBoxName.Text = text;

                clTeam = new CTeam(connect, data.idteam);
                comboBoxTeam.Text = clTeam.stTeam.name;

                dateTimePickerDate.Value = data.datein;
                dateTimePickerTimeIn.Value = data.datein;

                textBoxNumber.Text = data.number.ToString();
               
                if (data.growing != null)
                    textBoxGrowing.Text = data.growing.ToString();
                if (data.weight != null)
                    textBoxWeight.Text = data.weight.ToString();

                if (data.dateout != null)
                {
                    checkBoxOut.CheckState = CheckState.Checked;
                    dateTimePickerDateOut.Value = (DateTime)data.dateout;
                    dateTimePickerTimeOut.Value = (DateTime)data.dateout;
                }
                else
                {
                    checkBoxOut.CheckState = CheckState.Unchecked;
                    dateTimePickerDateOut.Enabled = false;
                    dateTimePickerTimeOut.Enabled = false;
                }

                if (data.amplua != null)
                {
                    if (data.amplua == 1) comboBoxAmplua.Text = "��������";
                    if (data.amplua == 2) comboBoxAmplua.Text = "�������";
                    if (data.amplua == 3) comboBoxAmplua.Text = "���������";
                }

                textBoxPriority.Text = data.priority.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private STEntryPlayers read_data()
        {
            STEntryPlayers ret = new STEntryPlayers();

            try
            {
                ret.idseason = IS.idseason;
                
                if (comboBoxName.Text.Length > 0)
                {
                    ret.idplayer = clPlayer.stPlayer.idplayer;
                }
                else ret.idplayer = 0;

                if (comboBoxTeam.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxTeam.Text.Trim());
                    ret.idteam = clTeam.stTeam.id;
                }
                else ret.idteam = 0;

                ret.datein = new DateTime(dateTimePickerDate.Value.Year, dateTimePickerDate.Value.Month,
                    dateTimePickerDate.Value.Day, dateTimePickerTimeIn.Value.Hour, dateTimePickerTimeIn.Value.Minute, 
                    0, 0);

                if (textBoxNumber.Text.Length > 0)
                    ret.number = textBoxNumber.Text.Trim();
                else ret.number = null;

                if (textBoxGrowing.Text.Length > 0)
                    ret.growing = int.Parse(textBoxGrowing.Text.Trim());
                else ret.growing = 0;

                if (textBoxWeight.Text.Length > 0)
                    ret.weight = int.Parse(textBoxWeight.Text.Trim());
                else ret.weight = 0;

                if (checkBoxOut.CheckState == CheckState.Checked)
                {
                    ret.dateout = new DateTime(dateTimePickerDateOut.Value.Year, dateTimePickerDateOut.Value.Month,
                    dateTimePickerDateOut.Value.Day, dateTimePickerTimeOut.Value.Hour, dateTimePickerTimeOut.Value.Minute,
                    0, 0);
                }

                if (comboBoxAmplua.Text.Length > 0)
                {
                    string am = comboBoxAmplua.Text.Trim();

                    if (am.Equals("��������")) ret.amplua = 1;
                    if (am.Equals("�������")) ret.amplua = 2;
                    if (am.Equals("���������")) ret.amplua = 3;
                }
                else ret.amplua = null;

                if (textBoxPriority.Text.Length > 0)
                    ret.priority = int.Parse(textBoxPriority.Text.Trim());
                else ret.priority = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
     
        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bDraft = false;
            stDraft = new STDraftPlayer();
            try
            {
                if (comboBoxName.Text.Length > 0)
                {
                    char[] del = { ' ', '(' , ')'};
                    
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
                        stDraft = clDraft.IsDraftPlayer(clPlayer.stPlayer.idplayer, DateTime.Now);
                        if (stDraft.idplayer > 0)
                        {
                            labelIsDemind.ForeColor = Color.BlueViolet;
                            labelIsDemind.Text = "�����";
                            bDraft = true;
                        }
                        else
                        {
                            labelIsDemind.ForeColor = Color.DarkGreen;
                            labelIsDemind.Text = "��������";
                        }
                    }


                    string str1 = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);

                    labelFIO.Text = str1;

                    CAge age = new CAge();

                    if (clPlayer.stPlayer.datebirth != null)
                    {
                        DateTime dte = (DateTime)clPlayer.stPlayer.datebirth;
                        string sm = age.GetFullAge(dte, DateTime.Now);

                        string str2 = string.Format("{0}, {1}", dte.ToLongDateString(), sm);

                        labelDate.Text = str2;
                    }

                    CCountry clCountry = new CCountry(connect);

                    string str3 = string.Format("{0}, {1}", clPlayer.stPlayer.personalnum, 
                        clCountry.stCountry.shortname);

                    labelPersNum.Text = str3;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                rData = read_data();

                if (rData.idplayer > 0 && rData.idteam > 0)
                {

                    if (mode == 1)
                    {
                        if (clWork.Update(rData, (STEntryPlayers)oldData)) DialogResult = DialogResult.OK;
                    }

                    if (mode == 0)
                    {
                        if (bDraft)
                        {
                            if (MessageBox.Show("������� ������ � ������?", "��������!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                DateTime dtout = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                    DateTime.Now.Day,0,0,0,0);
                                clDraft.OutDraft(rData.idplayer, stDraft.dtin, dtout, rData.idteam);
                            }
                        }

                        if (clWork.Insert(rData)) DialogResult = DialogResult.OK;
                    }
                }
                else
                    MessageBox.Show("�� ��� ������������ ���� ���������", "��������!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public STEntryPlayers GetFl()
        {
            return rData;
        }

        private void checkBoxOut_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOut.CheckState == CheckState.Checked)
            {
                dateTimePickerDateOut.Enabled = true;
                dateTimePickerTimeOut.Enabled = true;
            }
            else
            {
                dateTimePickerDateOut.Enabled = false;
                dateTimePickerTimeOut.Enabled = false;
            }
        }
    }
}