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
    /*public struct RecordDisplayStats
    {
        public int idplayer;
        public string fio;
        public int idteam;
        public string nameteam;
        public int iddivision;
        public int age;
        public int agestart;
        public int cntseason;
        public int idcountry;
        public int cntgame;
        public int points;
        public double pc2;
        public double pc3;
        public double pcft;
        public double pcall;
        public int afg;
        public int hfg;
        public int a3fg;
        public int h3fg;
        public int aft;
        public int hft;
        public int rebounds;
        public int rebits;
        public int rebstg;
        public int assists;
        public int steals;
        public int blocks;
        public int turnovers;
        public int turnass;
        public int turnteh;
        public int foulsadv;
        public int psfouls;
        public int foulsdash;
        public int foulst;
        public int foulsd;
        public int foulsu;
        public int pm;
        public int ptime;
        public double kpi;
        public double averpoints;
        public double averpc2;
        public double averpc3;
        public double averpcft;
        public double averpcall;
        public double averrebounds;
        public double averassists;
        public double aversteals;
        public double averblocks;
        public double averfoulsadv;
        public double averturnovers;
        public double averpsfouls;
        public double averptime;
        public double averkpi;
        public double averafg;
        public double averhfg;
        public double avera3fg;
        public double averh3fg;
        public double averaft;
        public double averhft;
    }*/

    public struct ParamDisplayStats
    {
        public int iddivision;
        public int idteam;
        public bool years21;
        public bool years18;
        public bool novik;
        public bool legion;
        public bool aver;
        public int sort;
    }

    public partial class DisplayStats : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        bool g_f;

        ParamDisplayStats param;

        CDivision clDiv;
        CTeam clTeam;

        List<RecordDisplayStats> container;
        List<RecordDisplayStats> data;

        public DisplayStats(SqlConnection cn, STInfoSeason iss, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            IS = iss;
        }

        private void DisplayStats_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                ParamDisplayStats ret = new ParamDisplayStats();
                ret.iddivision = 0;
                ret.idteam = 0;
                ret.legion = false;
                ret.novik = false;
                ret.years18 = false;
                ret.years21 = false;
                ret.aver = false;
                ret.sort = 1;       /* сортировка по очкам */

                radioButtonAll.Checked = true;
                radioButtonFull.Checked = true;
                radioButtonSortPoints.Checked = true;

                comboBoxTeam.Enabled = false;
                comboBoxDivision.Enabled = false;

                init_combo_div();

                Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_div()
        {
            try
            {
                clDiv = new CDivision(connect);
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

        private void init_combo_team(int iddiv)
        {
            try
            {
                CEntryTeam clET = new CEntryTeam(connect);
                List<STEntryTeam> lst = clET.GetTeamParticipant(IS.idseason, iddiv);

                foreach (STEntryTeam item in lst)
                {
                    clTeam = new CTeam(connect, item.idteam);
                    comboBoxTeam.Items.Add(clTeam.stTeam.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void Start()
        {
            CEntryPlayers clEP = new CEntryPlayers(connect);
            List<STEntryPlayers> data_list = clEP.GetListEntryPlayers(IS.idseason, 0, "IdTeam");
            
            RecordDisplayStats record;

            CEntryTeam clET;

            CStats clSatas = new CStats(connect);
            List<STStats> stats;

            STParamStats prst;

            CPlayer clPlayer;
            string text;
          
            try
            {
                container = new List<RecordDisplayStats>();

                foreach (STEntryPlayers data in data_list)
                {
                    if (data.dateout == null)
                    {
                        record = new RecordDisplayStats();

                        /* Номер и команда */
                        record.idplayer = data.idplayer;
                        clPlayer = new CPlayer(connect, data.idplayer);
                        text = string.Format("{0} {1}", clPlayer.stPlayer.family.ToUpper(), clPlayer.stPlayer.name);
                        record.fio = text;
                        
                        record.idteam = data.idteam;
                        clTeam = new CTeam(connect, data.idteam);
                        record.nameteam = clTeam.stTeam.name;
                        
                        /*Дивизион */
                        clET = new CEntryTeam(connect, IS.idseason, data.idteam);
                        record.iddivision = clET.gstTeamPart.iddivision;

                        /* Гражданство */
                        clPlayer = new CPlayer(connect, data.idplayer);
                        if (clPlayer.stPlayer.idcountry != null)
                            record.idcountry = (int)clPlayer.stPlayer.idcountry;
                        else record.idcountry = 0;

                        /* Число сезонов */
                        record.cntseason = clEP.GetCntSeasonPlayer(data.idplayer);

                        /* Возраст */
                        CAge age = new CAge();
                        if (clPlayer.stPlayer.datebirth != null)
                        {
                            record.age = age.GetAge((DateTime)clPlayer.stPlayer.datebirth, DateTime.Now);
                            record.agestart = age.GetAge((DateTime)clPlayer.stPlayer.datebirth, IS.datebegin);
                        }
                        else
                        {
                            record.age = 0;
                            record.agestart = 0;
                        }

                        /* Считам статистику */
                        prst = new STParamStats();
                        prst.idseason = IS.idseason;
                        prst.idplayer= data.idplayer;
                        stats = clSatas.GetStats(prst);

                        if (stats.Count > 0)
                        {
                            foreach (STStats statplayer in stats)
                            {
                                record.cntgame++;

                                record.afg += statplayer.afg;
                                record.a3fg += statplayer.a3fg;
                                record.aft += statplayer.aft;
                                record.hfg += statplayer.hfg;
                                record.h3fg += statplayer.h3fg;
                                record.hft += statplayer.hft;
                                record.points += statplayer.points;
                                record.rebits += statplayer.rebits;
                                record.rebounds += statplayer.rebounds;
                                record.rebstg += statplayer.rebstg;
                                record.assists += statplayer.assists;
                                record.steals += statplayer.steals;
                                record.blocks += statplayer.blocks;
                                record.foulsadv += statplayer.foulsadv;
                                record.turnass += statplayer.turnass;
                                record.turnovers += statplayer.turnovers;
                                record.turnteh += statplayer.turnteh;
                                record.psfouls += statplayer.psfouls;
                                record.ptime += statplayer.ptime;
                                record.pm += statplayer.pm;
                                KPI kpi = new KPI(statplayer);
                                record.kpi += kpi.kpi;
                            }

                            if (record.afg > 0)
                                record.pc2 = (1.0 * record.hfg) / record.afg * 100;
                            else record.pc2 = 0;

                            if (record.a3fg > 0)
                                record.pc3 = (1.0 * record.h3fg) / record.a3fg * 100;
                            else record.pc3 = 0;

                            if (record.aft > 0)
                                record.pcft = (1.0 * record.hft) / record.aft * 100;
                            else record.pcft = 0;

                            if (record.afg + record.a3fg > 0)
                                record.pcall =
                                    ((1.0 * record.hfg + record.h3fg) / (record.afg + record.a3fg)) * 100;
                            else record.pcall = 0;

                            if (record.cntgame > 0)
                            {
                                record.averpoints = 1.0 * record.points / record.cntgame;
                                record.averrebounds = 1.0 * record.rebounds / record.cntgame;
                                record.averassists = 1.0 * record.assists / record.cntgame;
                                record.averblocks = 1.0 * record.blocks / record.cntgame;
                                record.aversteals = 1.0 * record.steals / record.cntgame;
                                record.averfoulsadv = 1.0 * record.foulsadv / record.cntgame;
                                record.averkpi = 1.0 * record.kpi / record.cntgame;
                                record.averptime = 1.0 * record.ptime / record.cntgame;
                                record.averturnovers = 1.0 * record.turnovers / record.cntgame;
                                record.averafg = 1.0 * record.afg / record.cntgame;
                                record.avera3fg = 1.0 * record.a3fg / record.cntgame;
                                record.averaft = 1.0 * record.aft / record.cntgame;
                                record.averhfg = 1.0 * record.hfg / record.cntgame;
                                record.averh3fg = 1.0 * record.h3fg / record.cntgame;
                                record.averhft = 1.0 * record.hft / record.cntgame;
                                record.averpsfouls = 1.0 * record.psfouls / record.cntgame;

                                if (record.averafg > 0)
                                    record.averpc2 = (1.0 * record.averhfg) / record.averafg * 100;
                                else record.averpc2 = 0;

                                if (record.avera3fg > 0)
                                    record.averpc3 = (1.0 * record.averh3fg) / record.avera3fg * 100;
                                else record.averpc3 = 0;

                                if (record.averaft > 0)
                                    record.averpcft = (1.0 * record.averhft) / record.averaft * 100;
                                else record.averpcft = 0;

                                if (record.averafg + record.avera3fg > 0)
                                    record.averpcall =
                                        ((1.0 * record.averhfg + record.averh3fg) / (record.averafg + record.avera3fg)) * 100;
                                else record.averpcall = 0;

                            }
                            else
                            {
                                record.averpoints = 0;
                                record.averrebounds = 0;
                                record.averassists = 0;
                                record.averblocks = 0;
                                record.aversteals = 0;
                                record.averfoulsadv = 0;
                                record.averkpi = 0;
                                record.averptime = 0;
                                record.averturnovers = 0;
                                record.averafg = 0;
                                record.avera3fg = 0;
                                record.averaft = 0;
                                record.averhfg = 0;
                                record.averh3fg = 0;
                                record.averhft = 0;
                                record.averpcall = 0;
                                record.averpcft = 0;
                                record.averpc3 = 0;
                                record.averpc2 = 0;
                                record.averpsfouls = 0;
                            }
                        }

                        container.Add(record);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_list(List<RecordDisplayStats> data)
        {
            CPlayer clPlayer;
            CTeam clTeam;
            
            string text = null;

            try
            {

                dataGridViewDisplayStats.Rows.Clear();

                if (data.Count > 0)
                {
                    g_f = true;

                    dataGridViewDisplayStats.Rows.Add(data.Count);

                    for (int i = 0; i < data.Count; i++)
                    {
                        dataGridViewDisplayStats.Rows[i].Cells[0].Value = (i+1).ToString();

                     //   clPlayer = new CPlayer(connect, data[i].idplayer);
                     //   text = string.Format("{0} {1}", clPlayer.stPlayer.family.ToUpper(), clPlayer.stPlayer.name);
                        //dataGridViewDisplayStats.Rows[i].Cells[1].Value = text;
                        dataGridViewDisplayStats.Rows[i].Cells[1].Value = data[i].fio;

                       // clTeam = new CTeam(connect, data[i].idteam);
                       // dataGridViewDisplayStats.Rows[i].Cells[2].Value = clTeam.stTeam.name;
                        dataGridViewDisplayStats.Rows[i].Cells[2].Value = data[i].nameteam;

                        /* Игры */
                        dataGridViewDisplayStats.Rows[i].Cells[3].Value = data[i].cntgame.ToString();

                        /* Очки */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].averpoints);
                        }
                        else
                        {
                            text = data[i].points.ToString();
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[4].Value = text;

                        /* % с игры */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}%", data[i].averpcall);
                        }
                        else
                        {
                            text = string.Format("{0:f1}% ({1}/{2})", data[i].pcall,
                                data[i].hfg + data[i].h3fg, data[i].afg + data[i].a3fg);
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[5].Value = text;

                        /* % 2 очк */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}%", data[i].averpc2);
                        }
                        else
                        {
                            text = string.Format("{0:f1}% ({1}/{2})", data[i].pc2,
                                data[i].hfg, data[i].afg);
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[6].Value = text;

                        /* % 3 очк */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}%", data[i].averpc3);
                        }
                        else
                        {
                            text = string.Format("{0:f1}% ({1}/{2})", data[i].pc3,
                                data[i].h3fg, data[i].a3fg);
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[7].Value = text;

                        /* % штраф */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}%", data[i].averpcft);
                        }
                        else
                        {
                            text = string.Format("{0:f1}% ({1}/{2})", data[i].pcft,
                                data[i].hft, data[i].aft);
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[8].Value = text;

                        /* подборы */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].averrebounds);
                        }
                        else
                        {
                            text = string.Format("{0} ({1}/{2})", data[i].rebounds,
                                data[i].rebits, data[i].rebstg);
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[9].Value = text;

                        /* передачи */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].averassists);
                        }
                        else
                        {
                            text = data[i].assists.ToString();
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[10].Value = text;

                        /* перехваты */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].aversteals);
                        }
                        else
                        {
                            text = data[i].steals.ToString();
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[11].Value = text;

                        /* блок - шоты */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].averblocks);
                        }
                        else
                        {
                            text = data[i].blocks.ToString();
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[12].Value = text;

                        /* фолы соперников */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].averfoulsadv);
                        }
                        else
                        {
                            text = data[i].foulsadv.ToString();
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[13].Value = text;

                        /* потери */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].averturnovers);
                        }
                        else
                        {
                            text = data[i].turnovers.ToString();
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[14].Value = text;

                        /* персональные фолы */
                        if (param.aver)
                        {
                            text = string.Format("{0:f1}", data[i].averpsfouls);
                        }
                        else
                        {
                            text = data[i].psfouls.ToString();
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[15].Value = text;

                        /* время */
                        if (param.aver)
                        {
                            text = string.Format("{0:00}:{1:00}", data[i].averptime / 60, 
                                data[i].averptime % 60);
                        }
                        else
                        {
                            text = string.Format("{0:00}:{1:00}", data[i].ptime / 60,
                                data[i].ptime % 60);
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[16].Value = text;

                        /* КПИ */
                        if (param.aver)
                        {
                            text = string.Format("{0:f3}", data[i].averkpi);
                        }
                        else
                        {
                            text = string.Format("{0:f3}", data[i].kpi);
                        }
                        dataGridViewDisplayStats.Rows[i].Cells[17].Value = text;

                    }

                    dataGridViewDisplayStats.AllowUserToAddRows = false;
                }
                else dataGridViewDisplayStats.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private ParamDisplayStats read_param()
        {  
            ParamDisplayStats ret = new ParamDisplayStats();
            ret.iddivision = 0;
            ret.idteam = 0;
            ret.legion = false;
            ret.novik = false;
            ret.years18 = false;
            ret.years21 = false;
            ret.aver = false;
            ret.sort = 1;       /* сортировка по очкам */

            try
            {
                if (radioButtonDivision.Checked == true)
                {
                    if (comboBoxDivision.Text.Length > 0)
                    {
                        clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                        ret.iddivision = clDiv.stDiv.id;
                    }
                }

                if (radioButtonTeam.Checked == true)
                {
                    if (comboBoxTeam.Text.Length > 0)
                    {
                        clTeam = new CTeam(connect, comboBoxTeam.Text.Trim());
                        ret.idteam = clTeam.stTeam.id;
                    }
                }

                if (checkBoxDo21.CheckState == CheckState.Checked)
                    ret.years21 = true;
                else ret.years21 = false;
                if (checkBoxDo18.CheckState == CheckState.Checked)
                    ret.years18 = true;
                else ret.years18 = false;
                if (checkBoxNewPlayer.CheckState == CheckState.Checked)
                    ret.novik = true;
                else ret.novik = false;
                if (checkBoxLegionery.CheckState == CheckState.Checked)
                    ret.legion = true;
                else ret.legion = false;


                if (radioButtonFull.Checked == true)
                    ret.aver = false;
                if (radioButtonAver.Checked == true)
                    ret.aver = true;

                if (radioButtonSortPoints.Checked == true)
                    ret.sort = 1;
                if (radioButtonSortPCAll.Checked == true)
                    ret.sort = 2;
                if (radioButtonSortPC2.Checked == true)
                    ret.sort = 3;
                if (radioButtonSortPC3.Checked == true)
                    ret.sort = 4;
                if (radioButtonSortPCFT.Checked == true)
                    ret.sort = 5;
                if (radioButtonSortReb.Checked == true)
                    ret.sort = 6;
                if (radioButtonSortAss.Checked == true)
                    ret.sort = 7;
                if (radioButtonSortStl.Checked == true)
                    ret.sort = 8;
                if (radioButtonSortBlk.Checked == true)
                    ret.sort = 9;
                if (radioButton1SortFAdv.Checked == true)
                    ret.sort = 10;
                if (radioButtonSortTur.Checked == true)
                    ret.sort = 11;
                if (radioButtonSortFol.Checked == true)
                    ret.sort = 12;
                if (radioButtonSortTime.Checked == true)
                    ret.sort = 13;
                if (radioButtonSortKPI.Checked == true)
                    ret.sort = 14;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                param = read_param();

                data = GetData(container);

                init_list(data);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                    x = clDiv.stDiv.id;
                }
                else x = 0;

                init_combo_team(x);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private List<RecordDisplayStats> GetData(List<RecordDisplayStats> data)
        {
            List<RecordDisplayStats> ret = new List<RecordDisplayStats>();

            bool flag = true;

            try
            {
                foreach (RecordDisplayStats item in data)
                {
                    flag = true;

                    if (param.iddivision > 0)
                    {
                        if (param.iddivision != item.iddivision) flag = false;
                    }

                    if (param.idteam > 0)
                    {
                        if (param.idteam != item.idteam) flag = false;
                    }

                    if (param.years21)
                    {
                        if (item.agestart > 20) flag = false;
                    }

                    if (param.years18)
                    {
                        if (item.agestart > 17) flag = false;
                    }

                    if (param.novik)
                    {
                        if (item.cntseason > 1) flag = false;
                    }

                    if (param.legion)
                    {
                        if (item.idcountry == 1) flag = false;
                    }

            
                    if (flag)
                        ret.Add(item);
                }


                ListCompareDisplayPlayer clSrot = new ListCompareDisplayPlayer(param.sort, param.aver);

                ret.Sort(clSrot);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true)
            {
                comboBoxDivision.Text = null;
                comboBoxTeam.Text = null;

                comboBoxTeam.Enabled = false;
                comboBoxDivision.Enabled = false;
            }
        }

        private void radioButtonDivision_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDivision.Checked == true)
            {
                comboBoxDivision.Enabled = true;

                comboBoxTeam.Text = null;
                comboBoxTeam.Enabled = false;
            }
        }

        private void radioButtonTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTeam.Checked == true)
            {
                comboBoxTeam.Enabled = true;

                comboBoxDivision.Text = null;
                comboBoxDivision.Enabled = false;
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            ExcelPlayerStat cl = new ExcelPlayerStat(data);
        }
    }



    public class ListCompareDisplayPlayer : IComparer<RecordDisplayStats>
    {
        public int code;
        public bool param;

        public ListCompareDisplayPlayer(int c, bool p)
        {
            code = c;
            param = p;
        }

        public int Compare(RecordDisplayStats x, RecordDisplayStats y)
        {
            switch (code)
            {
                /* Очки */
                case 1:
                    if (param)
                    {
                        if (x.averpoints > y.averpoints) return -1;
                        if (x.averpoints < y.averpoints) return 1;
                        if (x.averpoints == y.averpoints) return 0;
                    }
                    else
                    {
                        if (x.points > y.points) return -1;
                        if (x.points < y.points) return 1;
                        if (x.points == y.points) return 0;
                    }
                    break;
                /* Процент с игры */
                case 2: 
                    if (param)
                    {
                        if (x.averpcall > y.averpcall) return -1;
                        if (x.averpcall < y.averpcall) return 1;
                        if (x.averpcall == y.averpcall) return 0;
                    }
                    else
                    {
                        if (x.pcall > y.pcall) return -1;
                        if (x.pcall < y.pcall) return 1;
                        if (x.pcall == y.pcall) return 0;
                    }
                    break;
                /* Процент 2 */
                case 3:
                    if (param)
                    {
                        if (x.averpc2 > y.averpc2) return -1;
                        if (x.averpc2 < y.averpc2) return 1;
                        if (x.averpc2 == y.averpc2) return 0;
                    }
                    else
                    {
                        if (x.pc2 > y.pc2) return -1;
                        if (x.pc2 < y.pc2) return 1;
                        if (x.pc2 == y.pc2) return 0;
                    }
                    break;
                /* Процент 3 */
                case 4:
                    if (param)
                    {
                        if (x.averpc3 > y.averpc3) return -1;
                        if (x.averpc3 < y.averpc3) return 1;
                        if (x.averpc3 == y.averpc3) return 0;
                    }
                    else
                    {
                        if (x.pc3 > y.pc3) return -1;
                        if (x.pc3 < y.pc3) return 1;
                        if (x.pc3 == y.pc3) return 0;
                    }
                    break;
                /* Процент штраф */
                case 5:
                    if (param)
                    {
                        if (x.averpcft > y.averpcft) return -1;
                        if (x.averpcft < y.averpcft) return 1;
                        if (x.averpcft == y.averpcft) return 0;
                    }
                    else
                    {
                        if (x.pcft > y.pcft) return -1;
                        if (x.pcft < y.pcft) return 1;
                        if (x.pcft == y.pcft) return 0;
                    }
                    break;
                /* Подборы */
                case 6:
                    if (param)
                    {
                        if (x.averrebounds > y.averrebounds) return -1;
                        if (x.averrebounds < y.averrebounds) return 1;
                        if (x.averrebounds == y.averrebounds) return 0;
                    }
                    else
                    {
                        if (x.rebounds > y.rebounds) return -1;
                        if (x.rebounds < y.rebounds) return 1;
                        if (x.rebounds == y.rebounds) return 0;
                    }
                    break;
                /* Передачи */
                case 7:
                    if (param)
                    {
                        if (x.averassists > y.averassists) return -1;
                        if (x.averassists < y.averassists) return 1;
                        if (x.averassists == y.averassists) return 0;
                    }
                    else
                    {
                        if (x.assists > y.assists) return -1;
                        if (x.assists < y.assists) return 1;
                        if (x.assists == y.assists) return 0;
                    }
                    break;
                /* Перехваты */
                case 8:
                    if (param)
                    {
                        if (x.aversteals > y.aversteals) return -1;
                        if (x.aversteals < y.aversteals) return 1;
                        if (x.aversteals == y.aversteals) return 0;
                    }
                    else
                    {
                        if (x.steals > y.steals) return -1;
                        if (x.steals < y.steals) return 1;
                        if (x.steals == y.steals) return 0;
                    }
                    break;
                /* Блок-шоты */
                case 9:
                    if (param)
                    {
                        if (x.averblocks > y.averblocks) return -1;
                        if (x.averblocks < y.averblocks) return 1;
                        if (x.averblocks == y.averblocks) return 0;
                    }
                    else
                    {
                        if (x.blocks > y.blocks) return -1;
                        if (x.blocks < y.blocks) return 1;
                        if (x.blocks == y.blocks) return 0;
                    }
                    break;
                /* Фолы соперников */
                case 10:
                    if (param)
                    {
                        if (x.averfoulsadv > y.averfoulsadv) return -1;
                        if (x.averfoulsadv < y.averfoulsadv) return 1;
                        if (x.averfoulsadv == y.averfoulsadv) return 0;
                    }
                    else
                    {
                        if (x.foulsadv > y.foulsadv) return -1;
                        if (x.foulsadv < y.foulsadv) return 1;
                        if (x.foulsadv == y.foulsadv) return 0;
                    }
                    break;
                /* Потери */
                case 11:
                    if (param)
                    {
                        if (x.averturnovers > y.averturnovers) return -1;
                        if (x.averturnovers < y.averturnovers) return 1;
                        if (x.averturnovers == y.averturnovers) return 0;
                    }
                    else
                    {
                        if (x.turnovers > y.turnovers) return -1;
                        if (x.turnovers < y.turnovers) return 1;
                        if (x.turnovers == y.turnovers) return 0;
                    }
                    break;
                /* Персональные фолы */
                case 12:
                    if (param)
                    {
                        if (x.averpsfouls > y.averpsfouls) return -1;
                        if (x.averpsfouls < y.averpsfouls) return 1;
                        if (x.averpsfouls == y.averpsfouls) return 0;
                    }
                    else
                    {
                        if (x.psfouls > y.psfouls) return -1;
                        if (x.psfouls < y.psfouls) return 1;
                        if (x.psfouls == y.psfouls) return 0;
                    }
                    break;
                /* Время */
                case 13:
                    if (param)
                    {
                        if (x.averptime > y.averptime) return -1;
                        if (x.averptime < y.averptime) return 1;
                        if (x.averptime == y.averptime) return 0;
                    }
                    else
                    {
                        if (x.ptime > y.ptime) return -1;
                        if (x.ptime < y.ptime) return 1;
                        if (x.ptime == y.ptime) return 0;
                    }
                    break;
                /* КПИ */
                case 14:
                    if (param)
                    {
                        if (x.averkpi > y.averkpi) return -1;
                        if (x.averkpi < y.averkpi) return 1;
                        if (x.averkpi == y.averkpi) return 0;
                    }
                    else
                    {
                        if (x.kpi > y.kpi) return -1;
                        if (x.kpi < y.kpi) return 1;
                        if (x.kpi == y.kpi) return 0;
                    }
                    break;
            }

            return 0;
        }

    };
}