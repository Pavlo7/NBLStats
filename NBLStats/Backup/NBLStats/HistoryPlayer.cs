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
    public partial class HistoryPlayer : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STPlayer gstPlayer;
        CParamApp clParam;

        public HistoryPlayer(SqlConnection cn, ushort md, STPlayer st)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstPlayer = st;
        }

        private void HistoryPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                clParam = new CParamApp();

                set_data();
                init_data_in();
                init_data_stats();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data()
        {
            DateTime dt;
            CAge age = new CAge();
            int ag;

            try
            {
                textBoxFIO.Text = gstPlayer.family + " " + gstPlayer.name + " " + gstPlayer.payname;
                if (gstPlayer.datebirth != null)
                {
                    dt = (DateTime)gstPlayer.datebirth;
                    textBoxDateBirth.Text = dt.ToLongDateString();

                    ag = age.GetAge((DateTime)gstPlayer.datebirth, DateTime.Now);
                    textBoxAge.Text = ag.ToString();
                }

                if (gstPlayer.namefoto != null && gstPlayer.namefoto.Length > 0)
                {
                    string pathfoto = string.Format("{0}\\{1}", clParam.s_Path.pathfoto, gstPlayer.namefoto);

                    FileInfo fi = new FileInfo(pathfoto);
                    if (fi.Exists)
                    {
                        Bitmap bt = new Bitmap(pathfoto);
                        pictureBoxFoto.Image = bt; ;
                    }
                    else
                        MessageBox.Show(string.Format("Файл {0} не найден", pathfoto),
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data_in()
        {
            CPlayer clP = new CPlayer(connect);
            CEntryPlayers clEP = new CEntryPlayers(connect);
            CInfoSeason clIS;
            CTeam clTeam;

            try
            {
                dataGridViewIn.Rows.Clear();

                List<STEntryPlayers> list = clEP.GetListEntryPlayer(gstPlayer.idplayer);

                if (list.Count > 0)
                {
                    dataGridViewIn.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewIn.Rows[i].Cells[0].Value = list[i].idseason;

                        clIS = new CInfoSeason(connect,list[i].idseason);
                        STInfoSeason st = (STInfoSeason)clIS.s_IS;
                        dataGridViewIn.Rows[i].Cells[1].Value = st.nameseason;

                        clTeam = new CTeam(connect, list[i].idteam);
                        dataGridViewIn.Rows[i].Cells[2].Value = clTeam.stTeam.name;

                        int cnt = clP.GetCntGames(list[i].idseason, list[i].idteam, gstPlayer.idplayer);
                        dataGridViewIn.Rows[i].Cells[3].Value = cnt.ToString();
                       

                        dataGridViewIn.Rows[i].Cells[4].Value = list[i].datein.ToLongDateString();

                        if (list[i].dateout != null)
                        {
                            DateTime dt = (DateTime)list[i].dateout;
                            dataGridViewIn.Rows[i].Cells[5].Value = dt.ToLongDateString();
                        }
                    }

                    dataGridViewIn.ClearSelection();
                    

                    dataGridViewIn.AllowUserToAddRows = false;
                }
                else dataGridViewIn.AllowUserToAddRows = false;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data_stats()
        {
            CStats clP = new CStats(connect);
            STParamStats param = new STParamStats();

            string text;

            try
            {
                dataGridViewStats.Rows.Clear();

                param.idgame = null;
                param.idseason = null;
                param.idteam = null;
                param.idplayer = gstPlayer.idplayer;
                param.order = "IdSeason,IdGame";

                List<STStats> list = clP.GetStats(param); ;

                if (list.Count > 0)
                {
                    dataGridViewStats.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewStats.Rows[i].Cells[0].Value = list[i].idseason.ToString();

                        dataGridViewStats.Rows[i].Cells[1].Value = list[i].idgame.ToString();

                        dataGridViewStats.Rows[i].Cells[2].Value = list[i].points.ToString();

                        dataGridViewStats.Rows[i].Cells[3].Value = string.Format("{0}\\{1}",
                            list[i].hfg, list[i].afg);

                        dataGridViewStats.Rows[i].Cells[4].Value = string.Format("{0}\\{1}",
                            list[i].h3fg, list[i].a3fg);

                        dataGridViewStats.Rows[i].Cells[5].Value = string.Format("{0}\\{1}",
                            list[i].hft, list[i].aft);

                        dataGridViewStats.Rows[i].Cells[6].Value = list[i].rebounds.ToString();

                        dataGridViewStats.Rows[i].Cells[7].Value = list[i].assists.ToString();

                        dataGridViewStats.Rows[i].Cells[8].Value = list[i].steals.ToString();

                        dataGridViewStats.Rows[i].Cells[9].Value = list[i].blocks.ToString();

                        dataGridViewStats.Rows[i].Cells[10].Value = list[i].foulsadv.ToString();

                        dataGridViewStats.Rows[i].Cells[11].Value = list[i].turnovers.ToString();

                        dataGridViewStats.Rows[i].Cells[12].Value = list[i].psfouls.ToString();

                        dataGridViewStats.Rows[i].Cells[13].Value = string.Format("{0:00}:{1:00}",
                            list[i].ptime / 60, list[i].ptime % 60);

                        dataGridViewStats.Rows[i].Cells[14].Value = list[i].pm.ToString();

                        KPI kpi = new KPI(list[i]);
                        text = string.Format("{0:f3}", kpi.kpi);
                        dataGridViewStats.Rows[i].Cells[15].Value = text;
                    }

                    dataGridViewStats.ClearSelection();

                    dataGridViewStats.AllowUserToAddRows = false;
                }
                else dataGridViewStats.AllowUserToAddRows = false;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

    }
}