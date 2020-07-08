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
    public partial class DlgAwardsResult : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        int iddivision;
        
        string caption;

        STAwardsResult? oldData;
        STAwardsResult rData;

        CAwarsResult clWork;
        CAward clAward;
        CPlayer clPlayer;
        CTeam clTeam;

        int mode;

        STPlayerParam view_param;

        public DlgAwardsResult(SqlConnection cn, STInfoSeason inf, int iddiv, STAwardsResult? data)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            iddivision = iddiv;
            oldData = data;
        }

        private void DlgAwardsResult_Load(object sender, EventArgs e)
        {
            try
            {
                if (oldData != null) mode = 1;
                else mode = 0;

                clAward = new CAward(connect);
                clWork = new CAwarsResult(connect);

                view_param.idseason = IS.idseason;

                this.Text = caption;

                init_combo_award();

                init_combo_player();

                if (mode == 0)
                {
                    caption = "Добавить награду";
                }
                if (mode == 1)
                {
                    caption = "Редактировать награду";
                    set_data((STAwardsResult)oldData);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_award()
        {
            try
            {
                comboBoxAwards.Items.Clear();

                List<STAward> st = clAward.GetList();

                foreach (STAward item in st)
                {
                    comboBoxAwards.Items.Add(item.nameaward);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_player()
        {
            comboBoxPlayer.Items.Clear();

            string text = null;

            try
            {
                CPlayer player = new CPlayer(connect);

                List<STPlayer> list = player.GetList(view_param);

                foreach (STPlayer item in list)
                {
                    text = string.Format("{0} {1} ({2})", item.family, item.name, item.personalnum);
                    comboBoxPlayer.Items.Add(text);
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

                if (mode == 1)
                {
                    if (clWork.Update(rData, (STAwardsResult)oldData)) DialogResult = DialogResult.OK;
                }

                if (mode == 0)
                {
                    if (clWork.Insert(rData)) DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                char[] del = { ' ', '(', ')' };

                string s = comboBoxPlayer.Text.Trim();

                string[] words = s.Split(del);

                clPlayer = new CPlayer(connect, words[0].Trim(), words[1].Trim(), words[3].Trim());
                CEntryPlayers cl = new CEntryPlayers(connect);

                int idt = cl.IsEntryPlayer(IS.idseason, clPlayer.stPlayer.idplayer);


                if (idt != 0)
                {
                    CTeam tm = new CTeam(connect, idt);
                    textBoxTeam.Text = tm.stTeam.name;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data(STAwardsResult data)
        {
            string text = null;

            try
            {
                STAward st = clAward.GetAward(data.idaward);
                comboBoxAwards.Text = st.nameaward;

                clPlayer = new CPlayer(connect, data.idplayer);

                text = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                         clPlayer.stPlayer.personalnum);

                comboBoxPlayer.Text = text;

                if (data.result != null)
                {
                    text = string.Format("{0:f2}", data.result);
                    textBoxResult.Text = text;
                }

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STAwardsResult read_data()
        {
            STAwardsResult ret = new STAwardsResult();
            
            try
            {
                ret.idseason = IS.idseason;
                ret.iddivision = iddivision;

                if (comboBoxAwards.Text.Length > 0)
                {
                    STAward st = clAward.GetAward(comboBoxAwards.Text.Trim());
                    ret.idaward = st.idaward;
                }

                if (comboBoxPlayer.Text.Length > 0)
                {
                    char[] del = { ' ', '(', ')' };

                    string s = comboBoxPlayer.Text.Trim();

                    string[] words = s.Split(del);

                    clPlayer = new CPlayer(connect, words[0].Trim(), words[1].Trim(), words[3].Trim());

                    ret.idplayer = clPlayer.stPlayer.idplayer;
                }

                if (textBoxResult.Text.Length > 0)
                {
                    ret.result = double.Parse(textBoxResult.Text.Trim());
                }
                else ret.result = null;


            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        public STAwardsResult GetFl()
        {
            return rData;
        }
    }
}