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
    public partial class Stats : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        CStats clStats;
        List<STStats> list;

        bool g_f;

        STStats flawour;
        int gpos;

        STGame gSTGame;
        int curridteam;
        string currnameteam;
        int currentpoints;
        string nameteam1;
        string nameteam2;

        CEntryPlayers clTC;
        List<STEntryPlayers> team1;
        List<STEntryPlayers> team2;
        List<STEntryPlayers> currteam;

        ListCompareByNumberFormStats clfs;
        ListCompareByNumberFromEntryPlayers clep;

        public Stats(SqlConnection cn, STInfoSeason inf, ushort md, STGame gm)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
            gSTGame = gm;

            clStats = new CStats(connect);
            clfs = new ListCompareByNumberFormStats();
            clep = new ListCompareByNumberFromEntryPlayers();
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            string text;
            CTeam cl;
            CCity clc;

            int idcity1=0, idcity2=0;

            try
            {
                cl = new CTeam(connect,(int)gSTGame.idteam1);
                nameteam1 = cl.stTeam.name;
                idcity1 = cl.stTeam.idcity;
                cl = new CTeam(connect,(int)gSTGame.idteam2);
                nameteam2 = cl.stTeam.name;
                idcity2 = cl.stTeam.idcity;

                text = string.Format("Статистика игры: {0} - {1} {2}:{3}", nameteam1, nameteam2,
                    gSTGame.apoints, gSTGame.bpoints);
                this.Text = text;


                clc = new CCity(connect, idcity1);
                if (clc.stFullCity.name != null)
                    radioButtonTeam1.Text = string.Format("{0} ({1},{2})", nameteam1, clc.stFullCity.name,
                        clc.stFullCity.namecountry);
                else radioButtonTeam1.Text = nameteam1;

                clc = new CCity(connect, idcity2);
                if (clc.stFullCity.name != null)
                    radioButtonTeam2.Text = string.Format("{0} ({1},{2})", nameteam2, clc.stFullCity.name,
                        clc.stFullCity.namecountry);
                else radioButtonTeam2.Text = nameteam2;

                curridteam = (int)gSTGame.idteam1;
                currnameteam = nameteam1;
                currentpoints = (int)gSTGame.apoints;

                clTC = new CEntryPlayers(connect);
                List<STEntryPlayers> lst = clTC.GetListEntryPlayersReal(IS.idseason, (int)gSTGame.idteam1,
                    (DateTime)gSTGame.datetime, null);
                team1 = lst;
                team1.Sort(clep);
                lst = clTC.GetListEntryPlayersReal(IS.idseason, (int)gSTGame.idteam2,
                    (DateTime)gSTGame.datetime, null);
                team2 = lst;
                team2.Sort(clep);

                currteam = team1;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonTeam1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonTeam1.Checked == true)
                {
                    curridteam = (int)gSTGame.idteam1;
                    currnameteam = nameteam1;
                    currteam = team1;
                    currentpoints = (int)gSTGame.apoints;

                    init_data();
                    set_text();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonTeam2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonTeam2.Checked == true)
                {
                    curridteam = (int)gSTGame.idteam2;
                    currnameteam = nameteam2;
                    currteam = team2;
                    currentpoints = (int)gSTGame.bpoints;

                    init_data();
                    set_text();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            string text;
            bool fl = false;

            try
            {
                CPlayer clPl;

                comboBoxPlayers.Text = null;
                comboBoxPlayers.Items.Clear();
                comboBoxPlayers.Refresh();

                if (currteam != null)
                {
                    foreach (STEntryPlayers item in currteam)
                    {
                        fl = false;

                        foreach (STStats stat in list)
                        {
                            if (stat.idplayer == item.idplayer) fl = true;
                        }

                        if (!fl)
                        {
                            clPl = new CPlayer(connect, item.idplayer);
                            text = string.Format("#{0} {1} {2}", item.number, clPl.stPlayer.family, clPl.stPlayer.name);
                            comboBoxPlayers.Items.Add(text);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            string text;
            DateTime dt;

            g_f = false;

            CPlayer clPlayer;

            STStats itog = new STStats();

            try
            {
                dataGridViewStats.Rows.Clear();

                list = clStats.GetList(IS.idseason, (int)gSTGame.idgame, curridteam);

                list.Sort(clfs);

                if (list.Count < 12)
                    groupBoxAdd.Enabled = true;
                else groupBoxAdd.Enabled = false;
                
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewStats.Rows.Add(list.Count + 1);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (flawour.Equals(list[i])) gpos = i;

                        if (list[i].flagstart == 1)
                            dataGridViewStats.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                        else dataGridViewStats.Rows[i].DefaultCellStyle.BackColor = Color.White;

                        /* игровой номер */
                        dataGridViewStats.Rows[i].Cells[0].Value = list[i].number;
                        /* фамилия имя */
                        clPlayer = new CPlayer(connect, list[i].idplayer);
                        dataGridViewStats.Rows[i].Cells[1].Value = string.Format("{0} {1}",
                            clPlayer.stPlayer.family, clPlayer.stPlayer.name);
                        /* очки */
                        dataGridViewStats.Rows[i].Cells[2].Value = list[i].points.ToString();
                        itog.points += list[i].points;
                        /* 2 */
                        dataGridViewStats.Rows[i].Cells[3].Value = string.Format("{0}\\{1}",
                            list[i].hfg, list[i].afg);
                        itog.afg += list[i].afg;
                        itog.hfg += list[i].hfg;
                        /* 3 */
                        dataGridViewStats.Rows[i].Cells[4].Value = string.Format("{0}\\{1}",
                            list[i].h3fg, list[i].a3fg);
                        itog.a3fg += list[i].a3fg;
                        itog.h3fg += list[i].h3fg;
                        /* штрафные */
                        dataGridViewStats.Rows[i].Cells[5].Value = string.Format("{0}\\{1}",
                            list[i].hft, list[i].aft);
                        itog.aft += list[i].aft;
                        itog.hft += list[i].hft;
                        /* подборы */
                        dataGridViewStats.Rows[i].Cells[6].Value = string.Format("{0} ({1}\\{2})",
                            list[i].rebounds, list[i].rebits, list[i].rebstg);
                        itog.rebounds += list[i].rebounds;
                        itog.rebits += list[i].rebits;
                        itog.rebstg += list[i].rebstg;
                        /* передачи */
                        dataGridViewStats.Rows[i].Cells[7].Value = list[i].assists.ToString();
                        itog.assists += list[i].assists;
                        /* перехваты */
                        dataGridViewStats.Rows[i].Cells[8].Value = list[i].steals.ToString();
                        itog.steals += list[i].steals;
                        /* блок-шоты */
                        dataGridViewStats.Rows[i].Cells[9].Value = list[i].blocks.ToString();
                        itog.blocks += list[i].blocks;
                        /* фолы соперников */
                        dataGridViewStats.Rows[i].Cells[10].Value = list[i].foulsadv.ToString();
                        itog.foulsadv += list[i].foulsadv;
                        itog.foulsd += list[i].foulsd;
                        itog.foulsdash += list[i].foulsdash;
                        itog.foulst += list[i].foulst;
                        itog.foulsu += list[i].foulsu;
                        /* потери */
                        dataGridViewStats.Rows[i].Cells[11].Value = string.Format("{0} ({1}\\{2})",
                                list[i].turnovers, list[i].turnass, list[i].turnteh);
                        itog.turnovers += list[i].turnovers;
                        itog.turnass += list[i].turnass;
                        itog.turnteh += list[i].turnteh;
                        /* фолы */
                        text = string.Format("{0} ({1}/{2}/{3}/{4})", list[i].psfouls, list[i].foulsu, list[i].foulst,
                            list[i].foulsd,list[i].foulsdash);
                        dataGridViewStats.Rows[i].Cells[12].Value = text;
                        itog.psfouls += list[i].psfouls;
                        /* сыграное время */
                        dataGridViewStats.Rows[i].Cells[13].Value = string.Format("{0:00}:{1:00}",
                            list[i].ptime / 60, list[i].ptime % 60);
                        itog.ptime += list[i].ptime;
                        /* +\- */
                        dataGridViewStats.Rows[i].Cells[14].Value = list[i].pm.ToString();
                        itog.pm += list[i].pm;
                        /* КПИ */
                        KPI kpi = new KPI(list[i]);
                        text = string.Format("{0:f3}", kpi.kpi);
                        dataGridViewStats.Rows[i].Cells[15].Value = text;

                        
                    }

                    dataGridViewStats.Rows[list.Count].Cells[1].Value = "ИТОГО:";
                    /* очки */
                    dataGridViewStats.Rows[list.Count].Cells[2].Value = itog.points.ToString();
                    /* 2 */
                    dataGridViewStats.Rows[list.Count].Cells[3].Value = string.Format("{0}\\{1}",
                        itog.hfg, itog.afg);
                    /* 3 */
                    dataGridViewStats.Rows[list.Count].Cells[4].Value = string.Format("{0}\\{1}",
                        itog.h3fg, itog.a3fg);
                    /* штрафные */
                    dataGridViewStats.Rows[list.Count].Cells[5].Value = string.Format("{0}\\{1}",
                        itog.hft, itog.aft);
                    /* подборы */
                    dataGridViewStats.Rows[list.Count].Cells[6].Value = string.Format("{0} ({1}\\{2})",
                        itog.rebounds, itog.rebits, itog.rebstg);
                    /* передачи */
                    dataGridViewStats.Rows[list.Count].Cells[7].Value = itog.assists.ToString();
                    /* перехваты */
                    dataGridViewStats.Rows[list.Count].Cells[8].Value = itog.steals.ToString();
                    /* блок-шоты */
                    dataGridViewStats.Rows[list.Count].Cells[9].Value = itog.blocks.ToString();
                    /* фолы соперников */
                    dataGridViewStats.Rows[list.Count].Cells[10].Value = itog.foulsadv.ToString();
                    /* потери */
                    dataGridViewStats.Rows[list.Count].Cells[11].Value = string.Format("{0} ({1}\\{2})",
                        itog.turnovers, itog.turnass, itog.turnteh);
                    /* фолы */
                    dataGridViewStats.Rows[list.Count].Cells[12].Value = string.Format("{0} ({1}/{2}/{3}/{4})",
                        itog.psfouls, itog.foulsu, itog.foulst, itog.foulsd, itog.foulsdash);
                    /* сыграное время */
                    dataGridViewStats.Rows[list.Count].Cells[13].Value = string.Format("{0:000}:{1:00}",
                        itog.ptime / 60, itog.ptime % 60);
                    /* +\- */
                    dataGridViewStats.Rows[list.Count].Cells[14].Value = itog.pm.ToString();

                    if (itog.points == currentpoints)
                        dataGridViewStats.Rows[list.Count].DefaultCellStyle.BackColor = Color.LightGreen;
                    else dataGridViewStats.Rows[list.Count].DefaultCellStyle.BackColor = Color.Red;

                    dataGridViewStats.ClearSelection();

                    dataGridViewStats.AllowUserToAddRows = false;
                }
                else dataGridViewStats.AllowUserToAddRows = false;

                init_combo();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_text()
        {
            labelText.Text = string.Format("Статистика игроков команды: {0}", currnameteam);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            STEntryPlayers tc = new STEntryPlayers();

            try
            {
                if (comboBoxPlayers.Text.Length > 0)
                {
                    string text = comboBoxPlayers.Text.Trim();
                    char[] del = { '#', ' ' };
                    string[] words = text.Split(del);

                    string number = words[1];
                    string famili = words[2];
                    string name = words[3];

                    foreach (STEntryPlayers item in currteam)
                    {
                        CPlayer clp = new CPlayer(connect, item.idplayer);
                        if (number.Equals(item.number) && famili.Equals(clp.stPlayer.family) &&
                            name.Equals(clp.stPlayer.name))
                            tc = item;
                    }

                    DlgStats wnd = new DlgStats(connect, mode, tc.idseason, gSTGame.idgame,
                        tc.idteam, tc.idplayer, tc.number);

                    if (wnd.ShowDialog() == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data();

                        if (gpos >= 0 && dataGridViewStats.Rows.Count > 0)
                        {
                            dataGridViewStats.Rows[gpos].Selected = true;
                            //      dataGridViewStats.FirstDisplayedScrollingRowIndex = gpos;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            del();
        }

        private void dataGridViewStats_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void del()
        {

            try
            {
                STStats data = GetSelectionData();

                if (data.idplayer > 0)
                {

                    if (MessageBox.Show("Вы действиетльно желаете удалить запись?", "Внимание!",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        clStats.Delete(data);
                        init_data();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STStats data = GetSelectionData();

                if (data.idplayer > 0)
                {

                    DlgStats wnd = new DlgStats(connect, mode, data);

                    DialogResult result = wnd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data();

                        if (gpos >= 0 && dataGridViewStats.Rows.Count > 0)
                        {
                            dataGridViewStats.Rows[gpos].Selected = true;
                            //      dataGridViewStats.FirstDisplayedScrollingRowIndex = gpos;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STStats GetSelectionData()
        {
            STStats ret = new STStats();

            string number = null;
           
            try
            {
                foreach (DataGridViewRow item in dataGridViewStats.SelectedRows)
                {
                    if (item.Cells[0].Value != null)
                    {
                        number = item.Cells[0].Value.ToString().Trim();
                    }

                    foreach (STStats stat in list)
                    {
                        if (stat.number == number) ret = stat;
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

     
    }
}