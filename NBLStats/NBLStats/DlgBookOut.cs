using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace NBLStats
{
    public partial class DlgBookOut : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        CParamApp clParamApp;

        string pathbook;
        string pathgame;

        bool bBook;
        bool bGames;
        int iCB;
        int iCE;

        public DlgBookOut(SqlConnection cn, STInfoSeason si)
        {
            InitializeComponent();
            connect = cn;
            IS = si;
        }

        private void DlgBookOut_Load(object sender, EventArgs e)
        {
            try
            {
                clParamApp = new CParamApp();

                pathbook = Path.Combine(clParamApp.s_Path.pathreport, "Book");
                pathgame = Path.Combine(clParamApp.s_Path.pathreport, "Pre");

                DirectoryInfo dir = new DirectoryInfo(pathbook);
                DirectoryInfo dirgame = new DirectoryInfo(pathgame);

                dirgame.Create();
                dir.Create();

                checkBoxBook.Checked = true;
                checkBoxGames.Checked = true;

                textBoxGamesBegin.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (read_param())
                {
                    if (bBook)
                    {
                        out_place();
                        out_team();
                        out_player();
                        out_referee();
                        out_coach();
                        out_part();
                    }

                    if (bGames)
                    {
                        for (int i = iCB; i <= iCE; i++)
                            out_game(i);
                    }

                    MessageBox.Show("Выгрузка завершена успешно", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private bool read_param()
        {
            bool ret = true;

            string s;

            try
            {
                if (checkBoxBook.Checked == true)
                    bBook = true;
                else bBook = false;

                if (checkBoxGames.Checked == true)
                {
                    bGames = true;

                    s = textBoxGamesBegin.Text.Trim();

                    if (char.IsDigit(s, 0))
                        iCB = int.Parse(s);
                    else
                    {
                        MessageBox.Show("Введите число", "Внимание!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        ret = false;
                        iCB = 0;
                    }

                    s = textBoxGamesEnd.Text.Trim();

                    if (char.IsDigit(s, 0))
                        iCE = int.Parse(s);
                    else
                    {
                        MessageBox.Show("Введите число", "Внимание!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        ret = false;
                        iCE = 0;
                    }

                    if (iCB > iCE)
                    {
                        MessageBox.Show("Стартовый номер не может быть больше конечного", "Внимание!", 
                            MessageBoxButtons.OK,  MessageBoxIcon.Error);
                        ret = false;
                    }
                
                }
                else
                {
                    bGames = false;
                    iCB = 0;
                    iCE = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void out_place()
        {
            CPlace clPlace;
            List<STPlace> list;

            List<STSmartBookPlace> lst_smart = new List<STSmartBookPlace>();
            STSmartBookPlace item;

            try
            {
                clPlace = new CPlace(connect);
                list = clPlace.GetListPlace();
                
                foreach (STPlace row in list)
                {
                    item = new STSmartBookPlace();

                    item.id = row.id;
                    item.place = row.name;

                    lst_smart.Add(item);
                }
               
                CSmartBookPlace clSmart = new CSmartBookPlace(pathbook);
                clSmart.Write(lst_smart);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void out_referee()
        {
            CReferee clRef;
            List<STReferee> list;

            try
            {
                clRef = new CReferee(connect);
                list = clRef.GetList();

                List<STSmartBookReferee> lst_smart = new List<STSmartBookReferee>();
                STSmartBookReferee item;

                foreach (STReferee row in list)
                {
                    item = new STSmartBookReferee();

                    item.idref = row.idref;
                    item.name = row.name;
                    item.family = row.family;

                    lst_smart.Add(item);
                }

                CSmartBookReferee clSmart = new CSmartBookReferee(pathbook);
                clSmart.Write(lst_smart);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void out_team()
        {
            CEntryTeam clET;
            List<STEntryTeamWithName> list;

            try
            {
                clET = new CEntryTeam(connect);
                list = clET.GetTeamParticipantWithName(IS.idseason);

                List<STSmartBookTeam> lst_smart = new List<STSmartBookTeam>();
                STSmartBookTeam item;

                foreach (STEntryTeamWithName row in list)
                {
                    item = new STSmartBookTeam();

                    item.id = row.idteam;
                    item.nameteam = row.name;
                    if (row.idcoach1 != null)
                        item.idcoach1 = (int)row.idcoach1;
                    else item.idcoach1 = 0;
                    if (row.idcoach2 != null)
                        item.idcoach2 = (int)row.idcoach2;
                    else item.idcoach2 = 0;
                    if (row.idcoach3 != null)
                        item.idcoach3 = (int)row.idcoach3;
                    else item.idcoach3 = 0;

                    lst_smart.Add(item);
                }

                CSmartBookTeam clSmart = new CSmartBookTeam(pathbook);
                clSmart.Write(lst_smart);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void out_player()
        {
            CEntryPlayers clEP;
            List<STEntryPlayers> list;

            CPlayer clPlayer;

            try
            {
                clEP = new CEntryPlayers(connect);
                list = clEP.GetListEntryPlayers(IS.idseason, 0, "IdTeam,Number");

                List<STSmartBookPlayer> lst_smart = new List<STSmartBookPlayer>();
                STSmartBookPlayer item;

                foreach (STEntryPlayers row in list)
                {
                    if (row.dateout == null)
                    {
                        item = new STSmartBookPlayer();
                        clPlayer = new CPlayer(connect, row.idplayer);

                        item.family = clPlayer.stPlayer.family;
                        item.idplayer = row.idplayer;
                        item.idteam = row.idteam;
                        item.name = clPlayer.stPlayer.name;
                        item.number = int.Parse(row.number);

                        lst_smart.Add(item);
                    }
                }

                CSmartBookPlayer clSmart = new CSmartBookPlayer(pathbook);
                clSmart.Write(lst_smart);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void out_coach()
        {
            CCoach clCoach;
            List<STCoach> list;

            CEntryTeam clET = new CEntryTeam(connect);
            List<STEntryTeam> lst_et = clET.GetTeamParticipant(IS.idseason);

            try
            {
                clCoach = new CCoach(connect);
             //   list = clCoach.GetList();

                List<STSmartBookCoach> lst_smart = new List<STSmartBookCoach>();
                STSmartBookCoach item;

                foreach (STEntryTeam row in lst_et)
                {
                    if (row.idcoach1 != null && row.idcoach1 > 0)
                    {
                        item = new STSmartBookCoach();

                        clCoach = new CCoach(connect, (int)row.idcoach1);

                        item.family = clCoach.stCoach.family;
                        item.idcoach = clCoach.stCoach.idcoach;
                        item.name = clCoach.stCoach.name;
                        item.idteam = row.idteam;

                        lst_smart.Add(item);
                    }

                    if (row.idcoach2 != null && row.idcoach2 > 0)
                    {
                        item = new STSmartBookCoach();

                        clCoach = new CCoach(connect, (int)row.idcoach2);

                        item.family = clCoach.stCoach.family;
                        item.idcoach = clCoach.stCoach.idcoach;
                        item.name = clCoach.stCoach.name;
                        item.idteam = row.idteam;

                        lst_smart.Add(item);
                    }

                    if (row.idcoach3 != null && row.idcoach3 > 0)
                    {
                        item = new STSmartBookCoach();

                        clCoach = new CCoach(connect, (int)row.idcoach3);

                        item.family = clCoach.stCoach.family;
                        item.idcoach = clCoach.stCoach.idcoach;
                        item.name = clCoach.stCoach.name;
                        item.idteam = row.idteam;

                        lst_smart.Add(item);
                    }
                }

                CSmartBookCoach clSmart = new CSmartBookCoach(pathbook);
                clSmart.Write(lst_smart);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void out_part()
        {
            CParticipant clPart;
            List<STParticipant> list;

            List<int> arr;

            try
            {
                clPart = new CParticipant(connect);
                list = clPart.GetList();

                List<STSmartBookPart> lst_smart = new List<STSmartBookPart>();
                STSmartBookPart item;

                foreach (STParticipant row in list)
                {
                    if (row.post != null)
                    {
                        arr = clPart.GetArrayPost(row.post);

                        foreach (int n in arr)
                        {
                            item = new STSmartBookPart();

                            item.family = row.family;
                            item.idpart = row.idpart;
                            item.name = row.name;
                            item.post = n;

                            lst_smart.Add(item);
                        }
                    }
                }

                CSmartBookPart clSmart = new CSmartBookPart(pathbook);
                clSmart.Write(lst_smart);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void out_game(int idgame)
        {
            CGame clGame;
            STGame game;

            try
            {
                clGame = new CGame(connect);
                game = clGame.GetGame(IS.idseason, idgame);

                string name = string.Format("nbl{0:000}{1:000}.pre",IS.idseason, idgame);

                string pathfile = Path.Combine(pathgame, name);

                STSmartHeadPRE data = new STSmartHeadPRE();
                data.idgame = game.idgame;
                data.idseason = game.idseason;
                if (game.datetime != null)
                    data.datetime = (DateTime)game.datetime;
                else data.datetime = DateTime.Now;

                if (game.idplace != null)
                    data.idplace = (int)game.idplace;
                else data.idplace = 0;

                if (game.idteam1 != null)
                    data.idteam1 = (int)game.idteam1;
                else data.idteam1 = 0;

                if (game.idteam2 != null)
                    data.idteam2 = (int)game.idteam2;
                else data.idteam2 = 0;

                if (game.idstreferee != null)
                    data.idstreferee = (int)game.idstreferee;
                else data.idstreferee = 0;

                if (game.idreferee1 != null)
                    data.idreferee1 = (int)game.idreferee1;
                else data.idreferee1 = 0;

                if (game.idreferee2 != null)
                    data.idreferee2 = (int)game.idreferee2;
                else data.idreferee2 = 0;

                CSmartPre clSmartPre = new CSmartPre(pathfile);

                clSmartPre.Write(data);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void checkBoxGames_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGames.Checked == true)
            {
                textBoxGamesBegin.Enabled = true;
                textBoxGamesEnd.Enabled = true;

                textBoxGamesBegin.Focus();
            }
            else
            {
                textBoxGamesBegin.Enabled = false;
                textBoxGamesEnd.Enabled = false;

                textBoxGamesBegin.Text = null;
                textBoxGamesEnd.Text = null;
            }
        }

        
    }
}
