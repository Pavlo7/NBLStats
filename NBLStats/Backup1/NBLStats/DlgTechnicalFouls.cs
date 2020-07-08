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
    public partial class DlgTechnicalFouls : Form
    {
        SqlConnection connect;
        
        string caption;
        STTehnicFouls gstTF;
        CTehnicFouls clTF;

        int mode;

        STTehnicFouls stC;

        CTeam clTeam;
        CPlayer clPlayer;
        CCoach clCoach;
        CGame clGame;
        CReferee clReferee;

        STGame game;
        string name1, name2;

        int idseason;

        public DlgTechnicalFouls(SqlConnection cn, int isd)
        {
            InitializeComponent();

            connect = cn;

            idseason = isd;
            
            caption = "Добавить технический фол";

            mode = 0;
           
        }
        public DlgTechnicalFouls(SqlConnection cn, STTehnicFouls st)
        {
            InitializeComponent();

            connect = cn;
            gstTF = st;
            idseason = gstTF.idseason;

            mode = 1;

            caption = "Редактировать технический фол";

            
        }

        private void DlgTechnicalFouls_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                clTF = new CTehnicFouls(connect);
                clGame = new CGame(connect);
                

                init_combo_team();
                init_combo_referee();

                if (mode == 1) set_data();
                else
                {
                    int id = clTF.GetFreeId(idseason);
                    textBoxId.Text = id.ToString();

                    radioButtonPlayer.Checked = true;
                }

             //   init_combo_part();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 
        }

        private void init_combo_referee()
        {
            string text = null;

            try
            {
                comboBoxReferee.Items.Clear();
                
                clReferee = new CReferee(connect);
                List<STReferee> lst = clReferee.GetList();

                foreach (STReferee item in lst)
                {
                    if (item.vf == 1)
                    {
                        text = string.Format("{0} {1}", item.family, item.name);
                        comboBoxReferee.Items.Add(text);
                     
                    }
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
                    if (clET.gstTeamPart.idcoach1 != null)
                    {
                        clCoach = new CCoach(connect, (int)clET.gstTeamPart.idcoach1);
                        if (clCoach.stCoach.idcoach > 0)
                        {
                            text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                                clCoach.stCoach.personalnum);
                            comboBoxPart.Items.Add(text);
                        }
                    }
                    if (clET.gstTeamPart.idcoach2 != null)
                    {
                        clCoach = new CCoach(connect, (int)clET.gstTeamPart.idcoach2);
                        if (clCoach.stCoach.idcoach > 0)
                        {
                            text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                                clCoach.stCoach.personalnum);
                            comboBoxPart.Items.Add(text);
                        }
                    }
                    if (clET.gstTeamPart.idcoach3 != null)
                    {
                        clCoach = new CCoach(connect, (int)clET.gstTeamPart.idcoach3);
                        if (clCoach.stCoach.idcoach > 0)
                        {
                            text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                                clCoach.stCoach.personalnum);
                            comboBoxPart.Items.Add(text);
                        }
                    }
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
            if (save()) DialogResult = DialogResult.OK;
        }

        private bool save()
        {
            bool ret = false;

            try
            {
                stC = new STTehnicFouls();

                stC = read_data();

                if (mode == 1)
                    ret = clTF.Update(stC, gstTF);
                else
                    ret = clTF.Insert(stC);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 

            return ret;
        }

        private void set_data()
        { 
            string text;

            try
            {
                textBoxId.Text = gstTF.id.ToString();

                clTeam = new CTeam(connect, gstTF.idteam);
                comboBoxTeam.Text = clTeam.stTeam.name;

                if (gstTF.typepart == 0)
                {
                    radioButtonPlayer.Checked = true;

                    clPlayer = new CPlayer(connect, gstTF.idpart);
                    text = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                         clPlayer.stPlayer.personalnum);
                    comboBoxPart.Text = text;
                }
                if (gstTF.typepart == 1)
                {
                    radioButtonCoach.Checked = true;

                    clCoach = new CCoach(connect, gstTF.idpart);
                    text = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name,
                        clCoach.stCoach.personalnum);
                    comboBoxPart.Text = text;
                }

                textBoxNGame.Text = gstTF.idgame.ToString();

                game = clGame.GetGame(gstTF.idseason, gstTF.idgame);
                clTeam = new CTeam(connect, (int)game.idteam1);
                name1 = clTeam.stTeam.name;
                clTeam = new CTeam(connect, (int)game.idteam2);
                name2 = clTeam.stTeam.name;
                text = string.Format("{0} - {1}", name1, name2);
                textBoxDescriptGame.Text = text;

                textBoxDescript.Text = gstTF.descript;

                if (gstTF.idreferee > 0)
                {
                    clReferee = new CReferee(connect, (int)gstTF.idreferee);
                    text = string.Format("{0} {1}", clReferee.stRef.family, clReferee.stRef.name);
                    comboBoxReferee.Text = text;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 
        }

        private STTehnicFouls read_data()
        {
            STTehnicFouls ret = new STTehnicFouls();
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

                    char[] del = { ' ', '(' , ')'};
                    string s = comboBoxPart.Text.Trim();
                    string[] words = s.Split(del);

                    clPlayer = new CPlayer(connect, words[0].Trim(), words[1].Trim(), words[3].Trim());

                    ret.idpart = clPlayer.stPlayer.idplayer;
                }
                if (radioButtonCoach.Checked == true)
                {
                    ret.typepart = 1;

                    char[] del = { ' ', '(' , ')'};
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

                if (textBoxNGame.Text.Length > 0)
                    ret.idgame = int.Parse(textBoxNGame.Text.Trim());
                else ret.idgame = 0;

                if (ret.idgame > 0)
                {
                    STGame st = clGame.GetGame(idseason, ret.idgame);
                    ret.date = new DateTime(st.datetime.Value.Year, st.datetime.Value.Month, st.datetime.Value.Day,
                        0, 0, 0, 0);
                }
                else ret.date = DateTime.Now;

                ret.descript = textBoxDescript.Text.Trim();

                if (comboBoxReferee.Text.Length > 0)
                    ret.idreferee = get_referee(comboBoxReferee.Text.Trim());
                else ret.idreferee = 0;
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        public STTehnicFouls GetFl()
        {
            return stC;
        }

        private void textBoxNGame_TextChanged(object sender, EventArgs e)
        {
            int idgame = 0;
            STGame st;
            string name1, name2;
            string text;
            
            try
            {
                if (textBoxNGame.Text.Length > 0)
                {
                    idgame = int.Parse(textBoxNGame.Text.Trim());
                    
                    st = clGame.GetGame(idseason, idgame);

                    clTeam = new CTeam(connect, (int)st.idteam1);
                    name1 = clTeam.stTeam.name;
                    clTeam = new CTeam(connect, (int)st.idteam2);
                    name2 = clTeam.stTeam.name;
                    text = string.Format("{0} - {1}", name1, name2);
                    textBoxDescriptGame.Text = text;

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

        private void comboBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_combo_part();
        }

        private int get_referee(string text)
        {
            int ret = 0;

            try
            {
                char[] del = { ' ' };
                string[] words = text.Split(del);

                string famili = words[0];
                string name = words[1];

                CReferee cl = new CReferee(connect, famili, name);

                ret = cl.stRef.idref;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}