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
    public struct STDataSymbol5
    {
        public string amplua;
        public string name;
        public string team;
        public double ball;
        public double points;
        public double rebounds;
        public double steals;
        public double assists;
        public double block;
        public int res;
    }

    public partial class Symbol5 : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        CParamApp clParamApp;

        string fullpath;
        string filename;

        DateTime dtbegin;
        DateTime dtend;
        int flag;

        public List<STDataSymbol5> lst_center;
        public List<STDataSymbol5> lst_defender;
        public List<STDataSymbol5> lst_forward;

        public Symbol5(SqlConnection cn, STInfoSeason si)
        {
            InitializeComponent();

            connect = cn;
            IS = si;
        }

        private void Symbol5_Load(object sender, EventArgs e)
        {
            clParamApp = new CParamApp();

            checkBoxFlaf.Checked = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                dtbegin = new DateTime(dateTimePickerDateB.Value.Year, dateTimePickerDateB.Value.Month,
                    dateTimePickerDateB.Value.Day, 0, 0, 0, 0);
                dtend = new DateTime(dateTimePickerDateE.Value.Year, dateTimePickerDateE.Value.Month,
                    dateTimePickerDateE.Value.Day, 23, 59, 59, 0);

                flag = 0;
                if (checkBoxFlaf.Checked == true) flag = 1;
                if (checkBoxAll.Checked == true) flag = 2;
                
                create();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void create()
        {
            CDivision clDiv = new CDivision(connect);
            List<STDivision> lst_div = new List<STDivision>();

            CGame clGame = new CGame(connect);
            List<STGame> lst_game = new List<STGame>();
            STGameParam paramGame;

            

            try
            {
                filename = string.Format("символичесике пятерки_{0}-{1}.txt",dtbegin.ToShortDateString(),
                    dtend.ToShortDateString());

                fullpath = Path.Combine(clParamApp.s_Path.pathreport, filename);


                FileInfo fi1 = new FileInfo(fullpath);
                StreamWriter sw = fi1.CreateText();

                lst_div = clDiv.GetListDivision(IS.idseason);

                if (flag == 1)
                {
                    paramGame = new STGameParam();
                    paramGame.idseason = IS.idseason;
                    paramGame.dtbegin = dtbegin;
                    paramGame.dtend = dtend;
                    paramGame.type = 2;

                    lst_game = clGame.GetListGames(paramGame);

                    insert_report(lst_game, sw, "стыковые игры");
                }
                else if (flag == 2)
                {
                    paramGame = new STGameParam();
                    paramGame.idseason = IS.idseason;
                    paramGame.dtbegin = dtbegin;
                    paramGame.dtend = dtend;
                    
                    lst_game = clGame.GetListGames(paramGame);

                    insert_report(lst_game, sw, "все дивизионы");
                }
                else
                {
                    foreach (STDivision division in lst_div)
                    {
                        paramGame = new STGameParam();
                        paramGame.idseason = IS.idseason;
                        paramGame.dtbegin = dtbegin;
                        paramGame.dtend = dtend;
                        paramGame.iddivision = division.id;


                        lst_game = clGame.GetListGames(paramGame);

                        insert_report(lst_game, sw, division.name);

                    }// конец цикла по дивизионам

                }


                sw.WriteLine("-");
                sw.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void insert_report(List<STGame> lst_game, StreamWriter sw, string name)
        {
            CStats clSatas = new CStats(connect);
            List<STStats> stats;
            STParamStats prst;

            List<STStats> data = new List<STStats>();

            try
            {
                if (lst_game.Count > 0)
                {
                    sw.WriteLine(name);
                    sw.WriteLine("---------------------------");

                    sw.WriteLine("<p>&nbsp;</p>");

                    lst_center = new List<STDataSymbol5>();
                    lst_defender = new List<STDataSymbol5>();
                    lst_forward = new List<STDataSymbol5>();

                    data = new List<STStats>();

                    // вытягиваем стаистику 
                    foreach (STGame game in lst_game)
                    {
                        int r = 0;
                        STStats newst;

                        prst = new STParamStats();
                        prst.idseason = game.idseason;
                        prst.idgame = game.idgame;
                        prst.idteam = game.idteam1;
                        stats = clSatas.GetStats(prst);

                        if (game.apoints >= 0 && game.bpoints >= 0)
                            r = (int)game.apoints - (int)game.bpoints;


                        foreach (STStats st in stats)
                        {
                            newst = st;
                            newst.pm = r;
                            data.Add(newst);
                        }

                        prst = new STParamStats();
                        prst.idseason = game.idseason;
                        prst.idgame = game.idgame;
                        prst.idteam = game.idteam2;
                        stats = clSatas.GetStats(prst);

                        if (game.apoints >= 0 && game.bpoints >= 0)
                            r = (int)game.bpoints - (int)game.apoints;

                        foreach (STStats st in stats)
                        {
                            newst = st;
                            newst.pm = r;
                            data.Add(newst);
                        }
                    }

                    // сортируем по id
                    ListCompareStatsByID clCompareStats = new ListCompareStatsByID();
                    data.Sort(clCompareStats);

                    // расчитываем
                    int currid = 0;
                    int curteam = 0;
                    int cnt = 1;
                    STDataSymbol5 item;

                    CEntryPlayers clEP = new CEntryPlayers(connect);
                    STEntryPlayers stEP;

                    CTeam clTeam = new CTeam(connect);
                    CPlayer clPlayer = new CPlayer(connect);

                    int point = 0;
                    int reb = 0;
                    int ass = 0;
                    int stl = 0;
                    int blk = 0;
                    int res = 0;

                    double kf = 0;

                    bool first = true;

                    for (int i = 0; i < data.Count; i++)
                    {
                        if (first)
                        {
                            currid = data[0].idplayer;
                            curteam = data[0].idteam;

                            point = data[0].points;
                            reb = data[0].rebounds;
                            ass = data[0].assists;
                            stl = data[0].steals;
                            blk = data[0].blocks;
                            res = data[0].pm;

                            cnt = 1;

                            first = false;
                        }
                        else
                        {
                            if (currid == data[i].idplayer)
                            {
                                cnt++;
                                ass += data[i].assists;
                                blk += data[i].blocks;
                                point += data[i].points;
                                reb += data[i].rebounds;
                                stl += data[i].steals;
                                res += data[i].pm;

                            }
                            else
                            {
                                // 
                                item = new STDataSymbol5();
                                clTeam = new CTeam(connect, curteam);
                                clPlayer = new CPlayer(connect, currid);
                                stEP = clEP.GetEntryPlayerLast(data[i].idseason, currid);

                                item.team = clTeam.stTeam.name;
                                item.name = clPlayer.stPlayer.family + " " + clPlayer.stPlayer.name;

                                item.points = (1.0 * point) / cnt;
                                item.assists = (1.0 * ass) / cnt;
                                item.block = (1.0 * blk) / cnt;
                                item.rebounds = (1.0 * reb) / cnt;
                                item.steals = (1.0 * stl) / cnt;
                                item.res = res;


                                if (item.res > 30) kf = 1.1;
                                if (item.res > 20 && item.res <= 30) kf = 1.2;
                                if (item.res > 10 && item.res <= 20) kf = 1.25;
                                if (item.res > 5 && item.res <= 10) kf = 1.3;
                                if (item.res > 0 && item.res <= 5) kf = 1.35;
                                if (item.res > -5 && item.res <= 0) kf = 0.95;
                                if (item.res > -10 && item.res <= -5) kf = 0.9;
                                if (item.res > -20 && item.res <= -10) kf = 0.85;
                                if (item.res > -30 && item.res <= -20) kf = 0.8;
                                if (item.res <= -30) kf = 0.7;

                                if (stEP.amplua != null)
                                {
                                    if (stEP.amplua == 1)
                                    {
                                        item.amplua = "защитник";

                                        item.ball = ((item.points * 1.5) + (item.assists * 2.5) + item.rebounds +
                                            (item.steals * 2) + item.block) * kf;

                                        lst_defender.Add(item);
                                    }
                                    if (stEP.amplua == 2)
                                    {
                                        item.amplua = "форвард";


                                        item.ball = ((item.points * 2.5) + (item.assists * 1.5) + item.rebounds +
                                            item.steals + item.block) * kf;

                                        lst_forward.Add(item);

                                    }
                                    if (stEP.amplua == 3)
                                    {
                                        item.amplua = "центровой";


                                        item.ball = ((item.points + item.assists + (item.rebounds * 2.5) +
                                            item.steals + (item.block * 2))) * kf;

                                        lst_center.Add(item);
                                    }
                                }

                                currid = data[i].idplayer;
                                curteam = data[i].idteam;

                                point = data[i].points;
                                reb = data[i].rebounds;
                                ass = data[i].assists;
                                stl = data[i].steals;
                                blk = data[i].blocks;
                                res = data[i].pm;

                                cnt = 1;
                            }
                        }
                    }

                    item = new STDataSymbol5();
                    clTeam = new CTeam(connect, curteam);
                    clPlayer = new CPlayer(connect, currid);
                    stEP = clEP.GetEntryPlayerLast(IS.idseason, currid);

                    item.team = clTeam.stTeam.name;
                    item.name = clPlayer.stPlayer.family + " " + clPlayer.stPlayer.name;

                    item.points = (1.0 * point) / cnt;
                    item.assists = (1.0 * ass) / cnt;
                    item.block = (1.0 * blk) / cnt;
                    item.rebounds = (1.0 * reb) / cnt;
                    item.steals = (1.0 * stl) / cnt;
                    item.res = res;

                    if (item.res > 30) kf = 1.1;
                    if (item.res > 20 && item.res <= 30) kf = 1.2;
                    if (item.res > 10 && item.res <= 20) kf = 1.25;
                    if (item.res > 5 && item.res <= 10) kf = 1.3;
                    if (item.res > 0 && item.res <= 5) kf = 1.35;
                    if (item.res > -5 && item.res <= 0) kf = 0.95;
                    if (item.res > -10 && item.res <= -5) kf = 0.9;
                    if (item.res > -20 && item.res <= -10) kf = 0.85;
                    if (item.res > -30 && item.res <= -20) kf = 0.8;
                    if (item.res <= -30) kf = 0.7;


                    if (stEP.amplua != null)
                    {
                        if (stEP.amplua == 1)
                        {
                            item.amplua = "защитник";

                            item.ball = ((item.points * 1.5) + (item.assists * 2.5) + item.rebounds +
                                (item.steals * 2) + item.block) * kf;

                            lst_defender.Add(item);
                        }
                        if (stEP.amplua == 2)
                        {
                            item.amplua = "форвард";


                            item.ball = ((item.points * 2.5) + (item.assists * 1.5) + item.rebounds +
                                item.steals + item.block) * kf;

                            lst_forward.Add(item);

                        }
                        if (stEP.amplua == 3)
                        {
                            item.amplua = "центровой";


                            item.ball = ((item.points + item.assists + (item.rebounds * 2.5) +
                                item.steals + (item.block * 2))) * kf;

                            lst_center.Add(item);

                        }
                    }


                    // сортируем по баллам
                    ListCompareByBall clComparyBall = new ListCompareByBall();
                    lst_center.Sort(clComparyBall);
                    lst_defender.Sort(clComparyBall);
                    lst_forward.Sort(clComparyBall);

                    // выводим в файл
                    int x = 1;

                    foreach (STDataSymbol5 set in lst_defender)
                    {
                   //     if (x == 5) break;
                        sw.WriteLine(string.Format
                            ("<p>{0,2}.{1,-20} ({2}) {3} , баллы:{4}, о:{5}, пб:{6}, пр:{7}, пх:{8}, б:{9}</p>",
                            x, set.name, set.team, set.amplua, set.ball, set.points, set.rebounds,
                            set.assists, set.steals, set.block));
                        x++;
                    }
                    foreach (STDataSymbol5 set in lst_forward)
                    {
                   //     if (x == 9) break;
                        sw.WriteLine(string.Format
                            ("<p>{0,2}.{1,-20} ({2}) {3} , баллы:{4}, о:{5}, пб:{6}, пр:{7}, пх:{8}, б:{9}</p>",
                            x, set.name, set.team, set.amplua, set.ball, set.points, set.rebounds,
                            set.assists, set.steals, set.block));
                        x++;
                    }
                    foreach (STDataSymbol5 set in lst_center)
                    {
                     //   if (x == 11) break;
                        sw.WriteLine(string.Format
                            ("<p>{0,2}.{1,-20} ({2}) {3} , баллы:{4}, о:{5}, пб:{6}, пр:{7}, пх:{8}, б:{9}</p>",
                            x, set.name, set.team, set.amplua, set.ball, set.points, set.rebounds,
                            set.assists, set.steals, set.block));
                        x++;
                    }

                    sw.WriteLine("<p>&nbsp;</p>");
                    sw.WriteLine("<p><img src=\"\" alt=\"\" /></p>");
                    sw.WriteLine("<p>&nbsp;</p>");
                    sw.WriteLine("<p>&nbsp;</p>");

                    sw.WriteLine("------------");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }



    public class ListCompareStatsByID : IComparer<STStats>
    {
        public int Compare(STStats x, STStats y)
        {
            if (x.idplayer > y.idplayer) return -1;
            if (x.idplayer < y.idplayer) return 1;
            if (x.idplayer == y.idplayer)  return 0;

            return 0;
        }

    };

    public class ListCompareByBall : IComparer<STDataSymbol5>
    {
        public int Compare(STDataSymbol5 x, STDataSymbol5 y)
        {
            if (x.ball > y.ball) return -1;
            if (x.ball < y.ball) return 1;
            if (x.ball == y.ball) return 0;
           

            return 0;
        }

    };
}
