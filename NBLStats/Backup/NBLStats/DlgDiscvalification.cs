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
    public partial class DlgDiscvalification : Form
    {
        SqlConnection connect;

        string caption;
        STDiscvalification gstDV;
        CDiscvalification clDV;

        int mode;

        STDiscvalification stC;

        CTeam clTeam;
        CPlayer clPlayer;
        CCoach clCoach;
        
        int idseason;

        public DlgDiscvalification(SqlConnection cn, int isd)
        {
            InitializeComponent();

            connect = cn;

            idseason = isd;

            caption = "Добавить дисквалификацию";

            mode = 0;
        }

        public DlgDiscvalification(SqlConnection cn, STDiscvalification st)
        {
            InitializeComponent();

            connect = cn;

            gstDV = st;
            idseason = gstDV.idseason;

            caption = "Редактировать дисквалификацию";

            mode = 1;
        }

        private void DlgDiscvalification_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                clDV = new CDiscvalification(connect);
                
                init_combo_team();

                if (mode == 1) set_data();
                else
                {
                    int id = clDV.GetFreeId(idseason);
                    textBoxId.Text = id.ToString();

                    radioButtonPlayer.Checked = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 
        }

        private void init_combo_team()
        {
            try
            {
                clTeam = new CTeam(connect);
                List<STTeam> lst = clTeam.GetListTeam(idseason);

                foreach (STTeam team in lst)
                {
                    comboBoxTeam.Items.Add(team.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_part()
        {
            int idteam = 0;
            CEntryPlayers clEP = new CEntryPlayers(connect);
            CEntryTeam clET;

            string text;

            try
            {
                comboBoxPart.Items.Clear();

                if (comboBoxTeam.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxTeam.Text.Trim());
                    idteam = clTeam.stTeam.id;
                }
                else idteam = 0;

                if (radioButtonPlayer.Checked == true)
                {
                    List<STEntryPlayers> lst = clEP.GetListEntryPlayers(idseason, idteam, null);
                    foreach (STEntryPlayers step in lst)
                    {
                        clPlayer = new CPlayer(connect, step.idplayer);
                        text = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.personalnum);
                        comboBoxPart.Items.Add(text);
                    }

                }
                if (radioButtonCoach.Checked == true)
                {
                    clET = new CEntryTeam(connect, idseason, idteam);
                    clCoach = new CCoach(connect, (int)clET.gstTeamPart.idcoach1);
                    if (clCoach.stCoach.idcoach > 0)
                    {
                        text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                            clCoach.stCoach.personalnum);
                        comboBoxPart.Items.Add(text);
                    }
                    clCoach = new CCoach(connect, (int)clET.gstTeamPart.idcoach2);
                    if (clCoach.stCoach.idcoach > 0)
                    {
                        text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                            clCoach.stCoach.personalnum);
                        comboBoxPart.Items.Add(text);
                    }
                    clCoach = new CCoach(connect, (int)clET.gstTeamPart.idcoach3);
                    if (clCoach.stCoach.idcoach > 0)
                    {
                        text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                            clCoach.stCoach.personalnum);
                        comboBoxPart.Items.Add(text);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonPlayer_CheckedChanged(object sender, EventArgs e)
        {
            init_combo_part();
        }

        private void radioButtonCoach_CheckedChanged(object sender, EventArgs e)
        {
            init_combo_part();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private void comboBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_combo_part();
        }

        private bool save()
        {
            bool ret = false;

            try
            {
                stC = new STDiscvalification();

                stC = read_data();

                if (mode == 1)
                    ret = clDV.Update(stC, gstDV);
                else
                    ret = clDV.Insert(stC);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void set_data()
        {
            string text;

            try
            {
                textBoxId.Text = gstDV.id.ToString();

                clTeam = new CTeam(connect, gstDV.idteam);
                comboBoxTeam.Text = clTeam.stTeam.name;

                if (gstDV.typepart == 0)
                {
                    radioButtonPlayer.Checked = true;

                    clPlayer = new CPlayer(connect, gstDV.idpart);
                    text = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                         clPlayer.stPlayer.personalnum);
                    comboBoxPart.Text = text;
                }
                if (gstDV.typepart == 1)
                {
                    radioButtonCoach.Checked = true;

                    clCoach = new CCoach(connect, gstDV.idpart);
                    text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                        clCoach.stCoach.personalnum);
                    comboBoxPart.Text = text;
                }

                textBoxCntGame.Text = gstDV.cntgame.ToString();

                dateTimePickerDateBegin.Value = gstDV.datebegin;
                dateTimePickerDateEnd.Value = gstDV.dateend;

                textBoxDescript.Text = gstDV.descript;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STDiscvalification read_data()
        {
            STDiscvalification ret = new STDiscvalification();
            string text;

            try
            {
                ret.idseason = idseason;

                if (textBoxId.Text.Length > 0)
                    ret.id = int.Parse(textBoxId.Text.Trim());
                else ret.id = 0;

                if (radioButtonPlayer.Checked == true)
                {
                    ret.typepart = 0;

                    char[] del = { ' ', '(', ')' };
                    string s = comboBoxPart.Text.Trim();
                    string[] words = s.Split(del);

                    clPlayer = new CPlayer(connect, words[0].Trim(), words[1].Trim(), words[3].Trim());

                    ret.idpart = clPlayer.stPlayer.idplayer;
                }
                if (radioButtonCoach.Checked == true)
                {
                    ret.typepart = 1;

                    char[] del = { ' ', '(', ')' };
                    string s = comboBoxPart.Text.Trim();
                    string[] words = s.Split(del);

                    clCoach = new CCoach(connect, words[0].Trim(), words[1].Trim(), words[3].Trim());

                    ret.idpart = clCoach.stCoach.idcoach;
                }

                if (comboBoxTeam.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxTeam.Text.Trim());
                    ret.idteam = clTeam.stTeam.id;
                }

                if (textBoxCntGame.Text.Length > 0)
                    ret.cntgame = int.Parse(textBoxCntGame.Text.Trim());
                else ret.cntgame = 0;

                ret.datebegin = new DateTime(dateTimePickerDateBegin.Value.Year, dateTimePickerDateBegin.Value.Month,
                    dateTimePickerDateBegin.Value.Day, 0, 0, 0, 0);

                ret.dateend = new DateTime(dateTimePickerDateEnd.Value.Year, dateTimePickerDateEnd.Value.Month,
                    dateTimePickerDateEnd.Value.Day, 0, 0, 0, 0);

                ret.descript = textBoxDescript.Text.Trim();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        public STDiscvalification GetFl()
        {
            return stC;
        }
    }
}