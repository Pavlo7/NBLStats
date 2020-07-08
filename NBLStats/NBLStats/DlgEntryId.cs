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
    public partial class DlgEntryId : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CPlayer clPlayer;
        CEntryPlayers clEP;

        int idteam;
        int idgame;

        int idplayer;
        string number;

        List<STEntryPlayers> lst;

        public DlgEntryId(SqlConnection cn, STInfoSeason inf, int id, int idg, string num)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;

            idteam = id;
            idgame = idg;

            number = num;
        }

        private void DlgEntryId_Load(object sender, EventArgs e)
        {
            try
            {
                clEP = new CEntryPlayers(connect);
                labelText.Text = string.Format("Кто играл под номером {0}?", number);

                init_combo();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                idplayer = 0;

                if (comboBoxPlayer.Text.Length > 0)
                {
                    string text = comboBoxPlayer.Text.Trim();
                    char[] del = { '#', ' ' };
                    string[] words = text.Split(del);

                    string number = words[1];
                    string famili = words[2];
                    string name = words[3];

                    clPlayer = new CPlayer(connect);

                    foreach (STEntryPlayers item in lst)
                    {
                        clPlayer = new CPlayer(connect, item.idplayer);
                        if (number.Equals(item.number) && famili.Equals(clPlayer.stPlayer.family) &&
                            name.Equals(clPlayer.stPlayer.name))
                        {
                            idplayer = clPlayer.stPlayer.idplayer;
                            
                        }


                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            string text;
            
            try
            {
                comboBoxPlayer.Items.Clear();

                lst = clEP.GetListEntryPlayers(IS.idseason, idteam, "Number");
                
                //List<STEntryPlayers> lst = clEP.GetListEntryPlayersReal(IS.idseason, (int)gSTGame.idteam1,
               //     (DateTime)gSTGame.datetime, null);

                foreach (STEntryPlayers item in lst)
                {
                    clPlayer = new CPlayer(connect, item.idplayer);
                    text = string.Format("#{0} {1} {2}", item.number, clPlayer.stPlayer.family, clPlayer.stPlayer.name);
                    comboBoxPlayer.Items.Add(text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        public int GetData() { return idplayer; }
    }
}
