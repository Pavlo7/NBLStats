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
    public struct STDataRating
    {
        public string name;
        public string nameteam;
        public int cntgame;
        public int points;
        public int rebounds;
        public int assists;
        public int steals;
        public int blocks;
        public int fouls;
    }

    public partial class RatingPlayerInNBL : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        List<STDataRating> container;

        public RatingPlayerInNBL(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            this.WindowState = FormWindowState.Maximized;
        }

        private void RatingPlayerInNBL_Load(object sender, EventArgs e)
        {
            try
            {
                container = calculate();

                radioButtonCntGames.Checked = true;

                ListCompareRatingNBLByCntGames cl = new ListCompareRatingNBLByCntGames();
                container.Sort(cl);

                init_data();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            try
            {
                dataGridViewRatingNBL.Rows.Clear();

                if (container.Count > 0)
                {
                    dataGridViewRatingNBL.Rows.Add(container.Count);

                    for (int i = 0; i < container.Count; i++)
                    {
                        dataGridViewRatingNBL.Rows[i].Cells[0].Value = (i+1).ToString();

                        dataGridViewRatingNBL.Rows[i].Cells[1].Value = container[i].name;

                        dataGridViewRatingNBL.Rows[i].Cells[2].Value = container[i].nameteam;

                        dataGridViewRatingNBL.Rows[i].Cells[3].Value = container[i].cntgame.ToString();

                        dataGridViewRatingNBL.Rows[i].Cells[4].Value = container[i].points.ToString();

                        dataGridViewRatingNBL.Rows[i].Cells[5].Value = container[i].rebounds.ToString();

                        dataGridViewRatingNBL.Rows[i].Cells[6].Value = container[i].assists.ToString();

                        dataGridViewRatingNBL.Rows[i].Cells[7].Value = container[i].steals.ToString();

                        dataGridViewRatingNBL.Rows[i].Cells[8].Value = container[i].blocks.ToString();

                        dataGridViewRatingNBL.Rows[i].Cells[9].Value = container[i].fouls.ToString();
                        
                    }

                    dataGridViewRatingNBL.ClearSelection();
                }
                else dataGridViewRatingNBL.AllowUserToAddRows = false;
                
                dataGridViewRatingNBL.AllowUserToAddRows = false;
                    
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private List<STDataRating> calculate()
        {
            List<STDataRating> ret = new List<STDataRating>();
            STDataRating item;

            CPlayer clPlayer;
            List<STPlayer> lst_player;
            STPlayerParam paramPlayer = new STPlayerParam();
            paramPlayer.idseason = null;

            CStats clStats;
            List<STStats> stStats;
            STParamStats paramStats;

            CEntryPlayers clEP;
            STEntryPlayers stEP;

            int idteam = 0;

            CTeam clTeam;

            try
            {
                clPlayer = new CPlayer(connect);
                clStats = new CStats(connect);
                clEP = new CEntryPlayers(connect);

                lst_player = clPlayer.GetList(paramPlayer);

                foreach(STPlayer st in lst_player)
                {
                    item = new STDataRating();

                    clPlayer = new CPlayer(connect, st.idplayer);
                    item.name = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                        clPlayer.stPlayer.payname);
                    idteam = clEP.IsEntryPlayer(IS.idseason, st.idplayer);
                    if (idteam > 0)
                    {
                        clTeam = new CTeam(connect, idteam);
                        item.nameteam = clTeam.stTeam.name;
                    }
                    else item.nameteam = "не заявлен в текущем сезоне";

                    paramStats = new STParamStats();
                    paramStats.idplayer = st.idplayer;

                    stStats = clStats.GetStats(paramStats);

                    foreach (STStats stst in stStats)
                    {
                        item.cntgame++;

                        item.points += stst.points;
                        item.rebounds += stst.rebounds;
                        item.steals += stst.steals;
                        item.fouls += stst.psfouls;
                        item.blocks += stst.blocks;
                        item.assists += stst.assists;
                    }

                    ret.Add(item);
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void radioButtonCntGames_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonCntGames.Checked == true)
                {
                    ListCompareRatingNBLByCntGames cl = new ListCompareRatingNBLByCntGames();
                    container.Sort(cl);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void radioButtonPoints_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonPoints.Checked == true)
                {
                    ListCompareRatingNBLByPoints cl = new ListCompareRatingNBLByPoints();
                    container.Sort(cl);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void radioButtonRebounds_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonRebounds.Checked == true)
                {
                    ListCompareRatingNBLByRebounds cl = new ListCompareRatingNBLByRebounds();
                    container.Sort(cl);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void radioButtonAssists_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAssists.Checked == true)
                {
                    ListCompareRatingNBLByAssists cl = new ListCompareRatingNBLByAssists();
                    container.Sort(cl);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void radioButtonSteals_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonSteals.Checked == true)
                {
                    ListCompareRatingNBLBySteals cl = new ListCompareRatingNBLBySteals();
                    container.Sort(cl);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void radioButtonBlocks_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonBlocks.Checked == true)
                {
                    ListCompareRatingNBLByBlocks cl = new ListCompareRatingNBLByBlocks();
                    container.Sort(cl);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void radioButtonFouls_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonFouls.Checked == true)
                {
                    ListCompareRatingNBLByFouls cl = new ListCompareRatingNBLByFouls();
                    container.Sort(cl);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }


    public class ListCompareRatingNBLByCntGames : IComparer<STDataRating>
    {
        public int Compare(STDataRating x, STDataRating y)
        {
            if (x.cntgame > y.cntgame) return -1;
            if (x.cntgame < y.cntgame) return 1;
            if (x.cntgame == y.cntgame) return 0;

            return 0;
        }

    };
    public class ListCompareRatingNBLByPoints : IComparer<STDataRating>
    {
        public int Compare(STDataRating x, STDataRating y)
        {
            if (x.points > y.points) return -1;
            if (x.points < y.points) return 1;
            if (x.points == y.points) return 0;

            return 0;
        }

    };
    public class ListCompareRatingNBLByAssists : IComparer<STDataRating>
    {
        public int Compare(STDataRating x, STDataRating y)
        {
            if (x.assists > y.assists) return -1;
            if (x.assists < y.assists) return 1;
            if (x.assists == y.assists) return 0;

            return 0;
        }

    };
    public class ListCompareRatingNBLByRebounds : IComparer<STDataRating>
    {
        public int Compare(STDataRating x, STDataRating y)
        {
            if (x.rebounds > y.rebounds) return -1;
            if (x.rebounds < y.rebounds) return 1;
            if (x.rebounds == y.rebounds) return 0;

            return 0;
        }

    };
    public class ListCompareRatingNBLBySteals : IComparer<STDataRating>
    {
        public int Compare(STDataRating x, STDataRating y)
        {
            if (x.steals > y.steals) return -1;
            if (x.steals < y.steals) return 1;
            if (x.steals == y.steals) return 0;

            return 0;
        }

    };
    public class ListCompareRatingNBLByBlocks : IComparer<STDataRating>
    {
        public int Compare(STDataRating x, STDataRating y)
        {
            if (x.blocks > y.blocks) return -1;
            if (x.blocks < y.blocks) return 1;
            if (x.blocks == y.blocks) return 0;

            return 0;
        }

    };
    public class ListCompareRatingNBLByFouls : IComparer<STDataRating>
    {
        public int Compare(STDataRating x, STDataRating y)
        {
            if (x.fouls > y.fouls) return -1;
            if (x.fouls < y.fouls) return 1;
            if (x.fouls == y.fouls) return 0;

            return 0;
        }

    };
}