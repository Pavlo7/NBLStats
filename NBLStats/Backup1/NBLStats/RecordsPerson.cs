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
    public partial class RecordsPerson : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CDivision clDiv;

        public RecordsPerson(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void RecordsPerson_Load(object sender, EventArgs e)
        {
            try
            {
                clDiv = new CDivision(connect);

                init_combo();

                clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            try
            {
                List<STDivision> lst = clDiv.GetListDivision(IS.idseason);

                if (lst.Count > 0)
                {
                    comboBoxDivision.Items.Clear();

                    foreach (STDivision item in lst)
                        comboBoxDivision.Items.Add(item.name);
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
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                    set_data(clDiv.stDiv.id);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void clear()
        {
            try
            {
                labelResult1.Text = null;
                labelTeam1.Text = null;
                labelPlayer1.Text = null;
                labelSeason1.Text = null;
                labelGame1.Text = null;

                labelResult2.Text = null;
                labelTeam2.Text = null;
                labelPlayer2.Text = null;
                labelSeason2.Text = null;
                labelGame2.Text = null;

                labelResult3.Text = null;
                labelTeam3.Text = null;
                labelPlayer3.Text = null;
                labelSeason3.Text = null;
                labelGame3.Text = null;

                labelResult4.Text = null;
                labelTeam4.Text = null;
                labelPlayer4.Text = null;
                labelSeason4.Text = null;
                labelGame4.Text = null;

                labelResult5.Text = null;
                labelTeam5.Text = null;
                labelPlayer5.Text = null;
                labelSeason5.Text = null;
                labelGame5.Text = null;

                labelResult6.Text = null;
                labelTeam6.Text = null;
                labelPlayer6.Text = null;
                labelSeason6.Text = null;
                labelGame6.Text = null;

                labelResult7.Text = null;
                labelTeam7.Text = null;
                labelPlayer7.Text = null;
                labelSeason7.Text = null;
                labelGame7.Text = null;

                labelResult8.Text = null;
                labelTeam8.Text = null;
                labelPlayer8.Text = null;
                labelSeason8.Text = null;
                labelGame8.Text = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data(int iddiv)
        {
            CPlayer clPlayer;
            CTeam clTeam;
            CGame clGame;

            STRecordsPerson data;
            STRecordsPerson? reads;
            string text;

            STGame game;
            string team1, team2;
            DateTime dt;

            CRecordsPerson clRec = new CRecordsPerson(connect);

            try
            {
                /* Очки*/
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 1);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult1.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer1.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam1.Text = clTeam.stTeam.name;

                    labelSeason1.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame1.Text = text;
                }
                else
                {
                    labelResult1.Text = null;
                    labelTeam1.Text = null;
                    labelPlayer1.Text = null;
                    labelSeason1.Text = null;
                    labelGame1.Text = null;
                }
                /*__________________________________________________*/

                /* Подборы*/
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 2);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult2.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer2.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam2.Text = clTeam.stTeam.name;

                    labelSeason2.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame2.Text = text;
                }
                else
                {
                    labelResult2.Text = null;
                    labelTeam2.Text = null;
                    labelPlayer2.Text = null;
                    labelSeason2.Text = null;
                    labelGame2.Text = null;
                }
                /*__________________________________________________*/

                /* Передачи*/
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 3);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult3.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer3.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam3.Text = clTeam.stTeam.name;

                    labelSeason3.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame3.Text = text;
                }
                else
                {
                    labelResult3.Text = null;
                    labelTeam3.Text = null;
                    labelPlayer3.Text = null;
                    labelSeason3.Text = null;
                    labelGame3.Text = null;
                }
                /*__________________________________________________*/

                /* Перехваты */
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 4);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult4.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer4.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam4.Text = clTeam.stTeam.name;

                    labelSeason4.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame4.Text = text;
                }
                else
                {
                    labelResult4.Text = null;
                    labelTeam4.Text = null;
                    labelPlayer4.Text = null;
                    labelSeason4.Text = null;
                    labelGame4.Text = null;
                }
                /*__________________________________________________*/

                /* Блок - шоты*/
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 5);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult5.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer5.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam5.Text = clTeam.stTeam.name;

                    labelSeason5.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame5.Text = text;
                }
                else
                {
                    labelResult5.Text = null;
                    labelTeam5.Text = null;
                    labelPlayer5.Text = null;
                    labelSeason5.Text = null;
                    labelGame5.Text = null;
                }
                /*__________________________________________________*/

                /* 2-х */
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 6);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult6.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer6.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam6.Text = clTeam.stTeam.name;

                    labelSeason6.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame6.Text = text;
                }
                else
                {
                    labelResult6.Text = null;
                    labelTeam6.Text = null;
                    labelPlayer6.Text = null;
                    labelSeason6.Text = null;
                    labelGame6.Text = null;
                }
                /*__________________________________________________*/

                /* 3-х */
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 7);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult7.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer7.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam7.Text = clTeam.stTeam.name;

                    labelSeason7.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame7.Text = text;
                }
                else
                {
                    labelResult7.Text = null;
                    labelTeam7.Text = null;
                    labelPlayer7.Text = null;
                    labelSeason7.Text = null;
                    labelGame7.Text = null;
                }
                /*__________________________________________________*/

                /* штраф */
                /*__________________________________________________*/
                reads = clRec.GetRecord(iddiv, 8);

                if (reads != null)
                {
                    data = (STRecordsPerson)reads;

                    labelResult8.Text = data.result.ToString();

                    clPlayer = new CPlayer(connect, data.idplayer);
                    text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    labelPlayer8.Text = text;

                    clTeam = new CTeam(connect, data.idteam);
                    labelTeam8.Text = clTeam.stTeam.name;

                    labelSeason8.Text = data.idseason.ToString();

                    clGame = new CGame(connect);
                    game = clGame.GetGame(data.idseason, data.idgame);

                    team1 = null;
                    team2 = null;
                    dt = new DateTime();

                    if (game.idteam1 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam1);
                        team1 = clTeam.stTeam.name;
                    }

                    if (game.idteam2 != null)
                    {
                        clTeam = new CTeam(connect, (int)game.idteam2);
                        team2 = clTeam.stTeam.name;
                    }

                    if (game.datetime != null) dt = (DateTime)game.datetime;
                    text = string.Format("{0} - {1} ({2})", team1, team2, dt.ToShortDateString());

                    labelGame8.Text = text;
                }
                else
                {
                    labelResult8.Text = null;
                    labelTeam8.Text = null;
                    labelPlayer8.Text = null;
                    labelSeason8.Text = null;
                    labelGame8.Text = null;
                }
                /*__________________________________________________*/
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
