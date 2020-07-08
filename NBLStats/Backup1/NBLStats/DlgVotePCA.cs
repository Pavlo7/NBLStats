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
    public partial class DlgVotePCA : Form
    {
        SqlConnection connect;

        CDivision clDiv;

        CVotePCA clWork;

        STVotePCA stC;
        STVotePCA gstDV;

        int idseason;
        int mode;

        string caption;

        public DlgVotePCA(SqlConnection cn, int isd)
        {
            InitializeComponent();

            connect = cn;

            idseason = isd;

            caption = "Добавить голосование";

            mode = 0;
        }

        public DlgVotePCA(SqlConnection cn, STVotePCA st)
        {
            InitializeComponent();

            connect = cn;
            gstDV = st;

            idseason = gstDV.idseason;

            caption = "Редактировать голосование";

            mode = 1;
        }

        private void DlgVotePCA_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                clWork = new CVotePCA(connect);
                clDiv = new CDivision(connect);

                init_combo_division();

                if (mode == 1) set_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_division()
        {
            try
            {
                comboBoxDivision.Items.Clear();

                List<STDivision> lst = clDiv.GetListDivision(idseason);
                foreach (STDivision item in lst)
                    comboBoxDivision.Items.Add(item.name);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_players(int iddivision)
        {

            CEntryPlayers clEP = new CEntryPlayers(connect);
            CEntryTeam clET = new CEntryTeam(connect);

            List<STEntryPlayers> list;
            List<STEntryTeam> list_team;

            string text = null;

            try
            {
                comboBoxPlayer.Items.Clear();

                list_team = clET.GetTeamParticipant(idseason, iddivision);

                foreach (STEntryTeam it in list_team)
                {
                    list = clEP.GetListEntryPlayersReal(idseason, it.idteam, DateTime.Now, null);

                    foreach (STEntryPlayers item in list)
                    {
                        CPlayer clPlayer = new CPlayer(connect, item.idplayer);
                        text = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                            clPlayer.stPlayer.personalnum);
                        comboBoxPlayer.Items.Add(text);
                    }
                }


                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    CDivision clDiv = new CDivision(connect, idseason, comboBoxDivision.Text.Trim());

                    init_combo_players(clDiv.stDiv.id);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data()
        {
            string text;

            try
            {
                textBoxName.Text = gstDV.name;
                textBoxEmail.Text = gstDV.email;
                textBoxIP.Text = gstDV.ip;

                CDivision clDiv = new CDivision(connect, idseason, gstDV.iddivision);
                comboBoxDivision.Text = clDiv.stDiv.name;

                CPlayer clPlayer = new CPlayer(connect, gstDV.idplayer);
                text = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                         clPlayer.stPlayer.personalnum);
                comboBoxPlayer.Text = text;

                dateTimePickerDate.Value = gstDV.ed;

                dateTimePickerTime.Value = gstDV.ed;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STVotePCA read_data()
        {
            STVotePCA ret = new STVotePCA();
           
            try
            {
                ret.idseason = idseason;

                ret.name = textBoxName.Text.Trim();
                ret.ip = textBoxIP.Text.Trim();
                ret.email = textBoxEmail.Text.Trim();


                char[] del = { ' ', '(', ')' };
                string s = comboBoxPlayer.Text.Trim();
                string[] words = s.Split(del);

                CDivision clDiv = new CDivision(connect, idseason, comboBoxDivision.Text.Trim());
                ret.iddivision = clDiv.stDiv.id;

                CPlayer clPlayer = new CPlayer(connect, words[0].Trim(), words[1].Trim(), words[3].Trim());
                ret.idplayer = clPlayer.stPlayer.idplayer;

                ret.ed = new DateTime(dateTimePickerDate.Value.Year, dateTimePickerDate.Value.Month,
                    dateTimePickerDate.Value.Day, dateTimePickerTime.Value.Hour, dateTimePickerTime.Value.Minute, 
                    0, 0);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            try
            {
                stC = new STVotePCA();

                stC = read_data();

                if (mode == 1)
                    ret = clWork.Update(stC, gstDV);
                else
                    ret = clWork.Insert(stC);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public STVotePCA GetFl()
        {
            return stC;
        }
    }
}