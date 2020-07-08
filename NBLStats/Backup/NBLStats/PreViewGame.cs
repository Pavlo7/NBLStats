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
    public struct RecordPlayerPreView
    {
        public int idplayer;
        public double averpoints;
        public double averass;
        public double averstl;
        public double averblk;
        public double averreb;
        public double pc2;
        public double pc3;
        public double pcft;
        public double pcall;
    }

    public partial class PreViewGame : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CTeam clTeam;
        CGame clGame;

        STTeam team1;
        STTeam team2;

        List<STGame> list_data;
        int cnt;

        int idseason;
        int iddivision;
        int idgroup;

        CInfoSeason clIS;
        CDivision clDivision;
        CGroup clGroup;

        public PreViewGame(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void PreViewGame_Load(object sender, EventArgs e)
        {
            try
            {
                clTeam = new CTeam(connect);
                clGame = new CGame(connect);

                clIS = new CInfoSeason(connect);
                clDivision = new CDivision(connect);

                team1 = new STTeam();
                team2 = new STTeam();

                init_combo_season();
                init_combo_division();
                init_combo_group();

                init_combo_team();

             

                cnt = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_season()
        {
            try
            {
                comboBoxSeason.Items.Clear();

                List<STInfoSeason> lst = clIS.GetListSeason();

                if (lst.Count > 0)
                {
                    foreach (STInfoSeason item in lst)
                        comboBoxSeason.Items.Add(item.nameseason);
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_division()
        {
            try
            {
                List<STDivision> list = clDivision.GetListDivision(idseason);

                if (list.Count > 0)
                {
                    comboBoxDivision.Items.Add("");
                    
                    foreach (STDivision item in list)
                        comboBoxDivision.Items.Add(item.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_combo_group()
        {
            try
            {
                comboBoxGroup.Items.Clear();

                clGroup = new CGroup(connect);
                List<STGroup> list = clGroup.GetListGroup(idseason, iddivision);

                if (list.Count > 0)
                {
                    comboBoxGroup.Items.Add("");

                    comboBoxGroup.Enabled = true;
                    
                    foreach (STGroup item in list)
                        comboBoxGroup.Items.Add(item.namegroup);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_combo_team()
        {
            try
            {
                comboBoxTeam1.Items.Clear();
                comboBoxTeam2.Items.Clear();

                List<STTeam> lst = clTeam.GetListTeam(0);

                foreach (STTeam team in lst)
                {
                    comboBoxTeam1.Items.Add(team.name);
                    comboBoxTeam2.Items.Add(team.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTeam1.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxTeam1.Text.Trim());
                    team1 = clTeam.stTeam;
                }

                if (comboBoxTeam2.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxTeam2.Text.Trim());
                    team2 = clTeam.stTeam;
                }

                if (team1.id > 0 && team2.id > 0) Create();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void Create()
        {
            try
            {

                List<int> arr_1 = get_arr_team(team1.id);
                List<int> arr_2 = get_arr_team(team2.id);

                list_data = new List<STGame>();

                List<STGame> prom_list;

                foreach (int tm1 in arr_1)
                    foreach(int tm2 in arr_2)
                    {
                        prom_list = clGame.GetListGamesPreView(tm1, tm2);

                        foreach (STGame game in prom_list)
                            list_data.Add(game);
                    }

                ListCompareBySeason lst = new ListCompareBySeason();
                list_data.Sort(lst);

                init_data_history();

                init_data_stats_team();

                init_data_leader_team();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data_history()
        {
            string text, tm1, tm2;

            CInfoSeason clIS = new CInfoSeason(connect);
            STInfoSeason st;

            DateTime dt;

            CPlace clPlace;

            try
            {
            //    if (MessageBox.Show("Обнулить данные?", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            //        == DialogResult.OK)
            //    {
            //        dataGridViewPersonalResult.Rows.Clear();

//                    cnt = 1;
//                }

                dataGridViewPersonalResult.Rows.Clear();

                cnt = 1;

                if (list_data.Count > 0)
                {
                    dataGridViewPersonalResult.Rows.Add(list_data.Count);
                                        

                    for (int i=0;i<list_data.Count;i++)
                    {
                        dataGridViewPersonalResult.Rows[i].Cells[0].Value = cnt.ToString();

                        clIS = new CInfoSeason(connect, list_data[i].idseason);
                        st = (STInfoSeason)clIS.s_IS;
                        dataGridViewPersonalResult.Rows[i].Cells[1].Value = st.nameseason;

                        dataGridViewPersonalResult.Rows[i].Cells[2].Value = list_data[i].idgame;

                        clTeam = new CTeam(connect, (int)list_data[i].idteam1);
                        tm1 = clTeam.stTeam.name;
                        clTeam = new CTeam(connect, (int)list_data[i].idteam2);
                        tm2 = clTeam.stTeam.name;

                        text = string.Format("{0} {1} - {2} {3}", tm1, list_data[i].apoints, list_data[i].bpoints,tm2);
                        dataGridViewPersonalResult.Rows[i].Cells[3].Value = text;

                        dt = (DateTime)list_data[i].datetime;
                        text = dt.ToShortDateString();
                        dataGridViewPersonalResult.Rows[i].Cells[4].Value = text;

                        clPlace = new CPlace(connect, (int)list_data[i].idplace);
                        dataGridViewPersonalResult.Rows[i].Cells[5].Value = clPlace.stPlace.name;

                        cnt++;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data_stats_team()
        {
            string text = null;

            double dbl1 = 0, dbl2 = 0;

            CPositionTeamInGroup clPIG;
            CStatsTeam clSTT;

            STGameParam param;

            try
            {
                dataGridViewStandings.Rows.Clear();

                cnt = 1;

                STPositionTeamInGroup pos_team1 = new STPositionTeamInGroup();
                STPositionTeamInGroup pos_team2 = new STPositionTeamInGroup();

                clPIG = new CPositionTeamInGroup(connect, idseason, iddivision, idgroup, DateTime.Now,DateTime.Now);
                pos_team1 = clPIG.GetStanding(team1.id);
                clPIG = new CPositionTeamInGroup(connect, idseason, iddivision, idgroup, DateTime.Now, DateTime.Now);
                pos_team2 = clPIG.GetStanding(team2.id);


                STStatsTeamInSeason stats_team1 = new STStatsTeamInSeason();
                STStatsTeamInSeason stats_team2 = new STStatsTeamInSeason();

                clSTT = new CStatsTeam(connect);

                param = new STGameParam();
                param.idseason = idseason;
                param.iddivision = iddivision;
                param.idgroup = idgroup;
                param.idteam = team1.id;
                stats_team1 = clSTT.GetStatsTeam(param);

                param = new STGameParam();
                param.idseason = idseason;
                param.iddivision = iddivision;
                param.idgroup = idgroup;
                param.idteam = team2.id;
                stats_team2 = clSTT.GetStatsTeam(param);

                dataGridViewStandings.Rows.Add(15);

                /* Названия команд */
                clTeam = new CTeam(connect, stats_team1.idteam);
                dataGridViewStandings.Rows[0].Cells[0].Value = clTeam.stTeam.name;
                dataGridViewStandings.Rows[0].Cells[1].Value = "Название команд";
                clTeam = new CTeam(connect, stats_team2.idteam);
                dataGridViewStandings.Rows[0].Cells[2].Value = clTeam.stTeam.name;

                /* Число сезонов в НБЛ */
                dataGridViewStandings.Rows[1].Cells[0].Value = "";
                dataGridViewStandings.Rows[1].Cells[1].Value = "Число сезонов в НБЛ";
                dataGridViewStandings.Rows[1].Cells[2].Value = "";

                /* Место в группе */
                dataGridViewStandings.Rows[2].Cells[0].Value = pos_team1.rang;
                dataGridViewStandings.Rows[2].Cells[1].Value = "Место в группе";
                dataGridViewStandings.Rows[2].Cells[2].Value = pos_team2.rang;

                /* Число игр */
                text = string.Format("{0} ({1} - {2})", pos_team1.cntgame, pos_team1.wins, pos_team1.lost);
                dataGridViewStandings.Rows[3].Cells[0].Value = text;
                dataGridViewStandings.Rows[3].Cells[1].Value = "Число игр (выигрышей - поражений)";
                text = string.Format("{0} ({1} - {2})", pos_team2.cntgame, pos_team2.wins, pos_team2.lost);
                dataGridViewStandings.Rows[3].Cells[2].Value = text;

                /* Очки (забитые - пропущенные) */
                if (pos_team1.cntgame > 0)
                {
                    dbl1 = pos_team1.points_coll / pos_team1.cntgame;
                    dbl2 = pos_team1.points_miss / pos_team1.cntgame;
                }
                else
                {
                    dbl1 = 0;
                    dbl2 = 0;
                }
                text = string.Format("{0:f1} - {1:f1}", dbl1, dbl2);
                dataGridViewStandings.Rows[4].Cells[0].Value = text;
                dataGridViewStandings.Rows[4].Cells[1].Value = "Очки (забитые - пропущенные)";
                if (pos_team2.cntgame > 0)
                {
                    dbl1 = pos_team2.points_coll / pos_team2.cntgame;
                    dbl2 = pos_team2.points_miss / pos_team2.cntgame;
                }
                else
                {
                    dbl1 = 0;
                    dbl2 = 0;
                }
                text = string.Format("{0:f1} - {1:f1}", dbl1, dbl2);
                dataGridViewStandings.Rows[4].Cells[2].Value = text;

                /* Процент попадания с игры */
                text = string.Format("{0:f1}", stats_team1.pcall);
                dataGridViewStandings.Rows[5].Cells[0].Value = text;
                dataGridViewStandings.Rows[5].Cells[1].Value = "Процент попадания с игры";
                text = string.Format("{0:f1}", stats_team2.pcall);
                dataGridViewStandings.Rows[5].Cells[2].Value = text;

                /* Процент попадания средних бросков */
                text = string.Format("{0:f1}", stats_team1.pc2);
                dataGridViewStandings.Rows[6].Cells[0].Value = text;
                dataGridViewStandings.Rows[6].Cells[1].Value = "Процент попадания средних бросков";
                text = string.Format("{0:f1}", stats_team2.pc2);
                dataGridViewStandings.Rows[6].Cells[2].Value = text;

                /* Процент попадания дальних бросков */
                text = string.Format("{0:f1}", stats_team1.pc3);
                dataGridViewStandings.Rows[7].Cells[0].Value = text;
                dataGridViewStandings.Rows[7].Cells[1].Value = "Процент попадания дальних бросков";
                text = string.Format("{0:f1}", stats_team2.pc3);
                dataGridViewStandings.Rows[7].Cells[2].Value = text;

                /* Процент попадания штрафных бросков */
                text = string.Format("{0:f1}", stats_team1.pcft);
                dataGridViewStandings.Rows[8].Cells[0].Value = text;
                dataGridViewStandings.Rows[8].Cells[1].Value = "Процент попадания штрафных бросков";
                text = string.Format("{0:f1}", stats_team2.pcft);
                dataGridViewStandings.Rows[8].Cells[2].Value = text;

                /* Подборы */
                text = string.Format("{0:f1}", stats_team1.averrebounds);
                dataGridViewStandings.Rows[9].Cells[0].Value = text;
                dataGridViewStandings.Rows[9].Cells[1].Value = "Подборы";
                text = string.Format("{0:f1}", stats_team2.averrebounds);
                dataGridViewStandings.Rows[9].Cells[2].Value = text;

                /* Результативные передачи */
                text = string.Format("{0:f1}", stats_team1.averassists);
                dataGridViewStandings.Rows[10].Cells[0].Value = text;
                dataGridViewStandings.Rows[10].Cells[1].Value = "Результативные передачи";
                text = string.Format("{0:f1}", stats_team2.averassists);
                dataGridViewStandings.Rows[10].Cells[2].Value = text;

                /* Перехваты */
                text = string.Format("{0:f1}", stats_team1.aversteals);
                dataGridViewStandings.Rows[11].Cells[0].Value = text;
                dataGridViewStandings.Rows[11].Cells[1].Value = "Перехваты";
                text = string.Format("{0:f1}", stats_team2.aversteals);
                dataGridViewStandings.Rows[11].Cells[2].Value = text;

                /* Блок-шоты */
                text = string.Format("{0:f1}", stats_team1.averblocks);
                dataGridViewStandings.Rows[12].Cells[0].Value = text;
                dataGridViewStandings.Rows[12].Cells[1].Value = "Блок-шоты";
                text = string.Format("{0:f1}", stats_team2.averblocks);
                dataGridViewStandings.Rows[12].Cells[2].Value = text;

                /* Потери */
                text = string.Format("{0:f1}", stats_team1.averturnovers);
                dataGridViewStandings.Rows[13].Cells[0].Value = text;
                dataGridViewStandings.Rows[13].Cells[1].Value = "Потери";
                text = string.Format("{0:f1}", stats_team2.averturnovers);
                dataGridViewStandings.Rows[13].Cells[2].Value = text;

                /* Фолы */
                text = string.Format("{0:f1}", stats_team1.averfouls);
                dataGridViewStandings.Rows[14].Cells[0].Value = text;
                dataGridViewStandings.Rows[14].Cells[1].Value = "Фолы";
                text = string.Format("{0:f1}", stats_team2.averfouls);
                dataGridViewStandings.Rows[14].Cells[2].Value = text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data_leader_team()
        {
            try
            {
                CEntryPlayers clEP = new CEntryPlayers(connect);
                List<STEntryPlayers> data_list1 = clEP.GetListEntryPlayersReal(IS.idseason, team1.id, 
                    DateTime.Now, null);
                List<STEntryPlayers> data_list2 = clEP.GetListEntryPlayersReal(IS.idseason, team2.id,
                    DateTime.Now, null);


                List<RecordPlayerPreView> stTeam1 = CalculateStats(data_list1);
                List<RecordPlayerPreView> stTeam2 = CalculateStats(data_list2);

                dataGridViewLeader.Rows.Clear();

                dataGridViewLeader.Rows.Add(9);

                /* Очки */
                dataGridViewLeader.Rows[0].Cells[0].Value = GetStringData(stTeam1, 1);
                dataGridViewLeader.Rows[0].Cells[1].Value = "Очки";
                dataGridViewLeader.Rows[0].Cells[2].Value = GetStringData(stTeam2, 1);

                /* Подборы */
                dataGridViewLeader.Rows[1].Cells[0].Value = GetStringData(stTeam1, 2);
                dataGridViewLeader.Rows[1].Cells[1].Value = "Подборы";
                dataGridViewLeader.Rows[1].Cells[2].Value = GetStringData(stTeam2, 2);

                /* Передачи */
                dataGridViewLeader.Rows[2].Cells[0].Value = GetStringData(stTeam1, 3);
                dataGridViewLeader.Rows[2].Cells[1].Value = "Передачи";
                dataGridViewLeader.Rows[2].Cells[2].Value = GetStringData(stTeam2, 3);

                /* Перехваты */
                dataGridViewLeader.Rows[3].Cells[0].Value = GetStringData(stTeam1, 4);
                dataGridViewLeader.Rows[3].Cells[1].Value = "Перехваты";
                dataGridViewLeader.Rows[3].Cells[2].Value = GetStringData(stTeam2, 4);

                /* Блок-шоты */
                dataGridViewLeader.Rows[4].Cells[0].Value = GetStringData(stTeam1, 5);
                dataGridViewLeader.Rows[4].Cells[1].Value = "Блок-шоты";
                dataGridViewLeader.Rows[4].Cells[2].Value = GetStringData(stTeam2, 5);

                /* Процент 2 очк. */
                dataGridViewLeader.Rows[5].Cells[0].Value = GetStringData(stTeam1, 6);
                dataGridViewLeader.Rows[5].Cells[1].Value = "Процент 2 очк.";
                dataGridViewLeader.Rows[5].Cells[2].Value = GetStringData(stTeam2, 6);

                /* Процент 3 очк. */
                dataGridViewLeader.Rows[6].Cells[0].Value = GetStringData(stTeam1, 7);
                dataGridViewLeader.Rows[6].Cells[1].Value = "Процент 3 очк.";
                dataGridViewLeader.Rows[6].Cells[2].Value = GetStringData(stTeam2, 7);

                /* Процент штраф. */
                dataGridViewLeader.Rows[7].Cells[0].Value = GetStringData(stTeam1, 8);
                dataGridViewLeader.Rows[7].Cells[1].Value = "Процент штраф.";
                dataGridViewLeader.Rows[7].Cells[2].Value = GetStringData(stTeam2, 8);

                /* Процент с игры */
                dataGridViewLeader.Rows[8].Cells[0].Value = GetStringData(stTeam1, 9);
                dataGridViewLeader.Rows[8].Cells[1].Value = "Процент с игры";
                dataGridViewLeader.Rows[8].Cells[2].Value = GetStringData(stTeam2, 9);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private List<int> get_arr_team(int idteam)
        {
            List<int> ret = new List<int>();
            List<int> arr1 = new List<int>();
            List<int> arr2 = new List<int>();
            ret.Add(idteam);
            arr1.Add(idteam);

            int id = idteam;

            try 
            {
                do
                {
                    clTeam = new CTeam(connect, id);
                    if (clTeam.stTeam.idprev != null)
                        id = (int)clTeam.stTeam.idprev;
                    else id = 0;

                    if (id > 0) 
                    {
                        ret.Add(id);
                        arr1.Add(id);
                    }
                }
                while (id > 0);

                foreach (int i in arr1)
                {
                    List<int> bt = clTeam.GetExId(i);
                    foreach (int btt in bt)
                    {
                        if (!isarr(arr1, btt))
                            arr2.Add(btt);
                    }
                }


                foreach (int i1 in arr2)
                    ret.Add(i1);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
        private bool isarr(List<int> arr, int i)
        {
            bool ret = false;
            try
            {
                foreach (int x in arr)
                    if (x == i) ret = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void comboBoxSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSeason.Text.Length > 0)
                    idseason = (int)clIS.GetId(comboBoxSeason.Text.Trim());
                else idseason = 0;

                init_combo_division();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    clDivision = new CDivision(connect, idseason, comboBoxDivision.Text.Trim());
                    iddivision = clDivision.stDiv.id;
                }
                else iddivision = 0;

                init_combo_group();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxGroup.Text.Length > 0)
                {
                   clGroup = new CGroup(connect, idseason, iddivision, comboBoxGroup.Text.Trim());
                   idgroup = clGroup.stGroup.idgroup;
                }
                else idgroup = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private List<RecordPlayerPreView> CalculateStats(List<STEntryPlayers> list_players)
        {
            List<RecordPlayerPreView> ret = new List<RecordPlayerPreView>();
            RecordPlayerPreView item;

            STParamStats prst;

            int cntgame = 0;
            int afg = 0;
            int a3fg = 0;
            int aft = 0;
            int hfg = 0;
            int h3fg = 0;
            int hft = 0;
            int points = 0;
            int rebounds = 0;
            int assists = 0;
            int steals = 0;
            int blocks = 0;

            try
            {
                CStats clSatas = new CStats(connect);
                List<STStats> stats;

                foreach (STEntryPlayers data in list_players)
                {
                    item = new RecordPlayerPreView();

                    item.idplayer = data.idplayer;

                    /* Считам статистику */
                    prst = new STParamStats();
                    prst.idseason = IS.idseason;
                    prst.idplayer = data.idplayer;
                    stats = clSatas.GetStats(prst);

                    cntgame = 0;
                    afg = 0;
                    a3fg = 0;
                    aft = 0;
                    hfg = 0;
                    h3fg = 0;
                    hft = 0;
                    points = 0;
                    rebounds = 0;
                    assists = 0;
                    steals = 0;
                    blocks = 0;

                    if (stats.Count > 0)
                    {
                        foreach (STStats statplayer in stats)
                        {
                            

                            cntgame++;

                            afg += statplayer.afg;
                            a3fg += statplayer.a3fg;
                            aft += statplayer.aft;
                            hfg += statplayer.hfg;
                            h3fg += statplayer.h3fg;
                            hft += statplayer.hft;
                            points += statplayer.points;
                            rebounds += statplayer.rebounds;
                            assists += statplayer.assists;
                            steals += statplayer.steals;
                            blocks += statplayer.blocks;
                        }

                        if (afg > 0)
                            item.pc2 = (1.0 * hfg) / afg * 100;
                        else item.pc2 = 0;

                        if (a3fg > 0)
                            item.pc3 = (1.0 * h3fg) / a3fg * 100;
                        else item.pc3 = 0;

                        if (aft > 0)
                            item.pcft = (1.0 * hft) / aft * 100;
                        else item.pcft = 0;

                        if (afg + a3fg > 0)
                            item.pcall = ((1.0 * hfg + h3fg) / (afg + a3fg)) * 100;
                        else item.pcall = 0;

                        if (cntgame > 0)
                        {
                            item.averpoints = 1.0 * points / cntgame;
                            item.averpoints = 1.0 * rebounds / cntgame;
                            item.averass = 1.0 * assists / cntgame;
                            item.averstl = 1.0 * blocks / cntgame;
                            item.averblk = 1.0 * steals / cntgame;
                        }
                        else
                        {
                            item.averpoints = 0;
                            item.averpoints = 0;
                            item.averass = 0;
                            item.averstl = 0;
                            item.averblk = 0;
                        }
                    }

                    ret.Add(item);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private string GetStringData(List<RecordPlayerPreView> data, int id)
        {
            string ret = null;
            CPlayer clPlayer;

            List<int> arr_id = new List<int>();
            double c_data = 0;

            try
            {
                foreach (RecordPlayerPreView item in data)
                {
                    switch (id)
                    {
                        case 1:
                            if (item.averpoints > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.averpoints;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.averpoints == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 2:
                            if (item.averreb > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.averreb;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.averreb == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 3:
                            if (item.averass > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.averass;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.averass == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 4:
                            if (item.averstl > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.averstl;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.averstl == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 5:
                            if (item.averblk > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.averblk;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.averblk == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 6:
                            if (item.pc2 > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.pc2;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.pc2 == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 7:
                            if (item.pc3 > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.pc3;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.pc3 == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 8:
                            if (item.pcft > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.pcft;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.pcft == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;

                        case 9:
                            if (item.pcall > c_data)
                            {
                                arr_id = new List<int>();
                                c_data = item.pcall;
                                arr_id.Add(item.idplayer);
                            }
                            if (item.pcall == c_data)
                            {
                                arr_id.Add(item.idplayer);
                            }
                            break;
                    }
                }

                bool fl = true;

                if (arr_id.Count > 0)
                {
                    foreach (int idp in arr_id)
                    {
                        clPlayer = new CPlayer(connect, id);
                        if (!fl) ret += string.Format(", {0} {1}", clPlayer.stPlayer.family,
                            clPlayer.stPlayer.name);
                        else
                        {
                            ret = string.Format("{0} {1}", clPlayer.stPlayer.family,
                            clPlayer.stPlayer.name);

                            fl = false;
                        }
                        
                    }

                    ret += string.Format(" {0:f2}", c_data);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }

    public class ListCompareBySeason : IComparer<STGame>
    {
        public int Compare(STGame x, STGame y)
        {
            if (x.idseason > y.idseason) return 1;
            if (x.idseason < y.idseason) return -1;
            if (x.idseason == y.idseason) return 0;

            return 0;
        }

    };
}