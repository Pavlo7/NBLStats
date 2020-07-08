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
    public partial class HistoryEntryPlayers : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CHistoryEntryPlayers clWork;
        List<STHistoryEntryPlayers> full_list;

        bool g_f;
        int gpos;

        public HistoryEntryPlayers(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void HistoryEntryPlayers_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CHistoryEntryPlayers(connect);

                this.WindowState = FormWindowState.Maximized;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            g_f = false;
            gpos = -1;

            CPlayer clPlayer;
            CTeam clTeam;
        
            string text = null;

            try
            {
                full_list = clWork.GetListData(IS.idseason);

                dataGridViewHistoryEntryPlayers.Rows.Clear();

                int npp = 1;

                if (full_list.Count > 0)
                {
                    g_f = true;

                    dataGridViewHistoryEntryPlayers.Rows.Add(full_list.Count);

                    for (int i = 0; i < full_list.Count; i++)
                    {
                        dataGridViewHistoryEntryPlayers.Rows[i].Cells[0].Value = npp.ToString();
                        dataGridViewHistoryEntryPlayers.Rows[i].Cells[1].Value = full_list[i].ed.ToString();

                        text = null;
                        if (full_list[i].opertype == 1) text = "Заявка";
                        if (full_list[i].opertype == 2) text = "Удаление заявки";
                        if (full_list[i].opertype == 3) text = "Отзаявка";
                        if (full_list[i].opertype == 4) text = "Смена команды";
                        if (full_list[i].opertype == 5) text = "Смена номера";

                        dataGridViewHistoryEntryPlayers.Rows[i].Cells[2].Value = text;

                        clPlayer = new CPlayer(connect, full_list[i].idplayer);
                        text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                            clPlayer.stPlayer.payname);
                        dataGridViewHistoryEntryPlayers.Rows[i].Cells[3].Value = text;

                        clTeam = new CTeam(connect, full_list[i].idteam);
                        dataGridViewHistoryEntryPlayers.Rows[i].Cells[4].Value = clTeam.stTeam.name;

                        dataGridViewHistoryEntryPlayers.Rows[i].Cells[5].Value = full_list[i].text;

                        npp++;
                    }

                    dataGridViewHistoryEntryPlayers.AllowUserToAddRows = false;
                }
                else dataGridViewHistoryEntryPlayers.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

    }
}
