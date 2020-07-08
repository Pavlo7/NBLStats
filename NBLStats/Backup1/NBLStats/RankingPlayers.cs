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
    

    public partial class RankingPlayers : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        List<STRankingPlayers> itogdata;

        public RankingPlayers(SqlConnection cn, STInfoSeason iss)
        {
            InitializeComponent();
            connect = cn;
            IS = iss;
        }

        private void RankingPlayers_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            CRankingPlayers clRan = new CRankingPlayers(connect, IS, 4);
            itogdata = clRan.itogdata;

            init_data();
        }
        
       

        private void init_data()
        {
            try
            {
                dataGridViewRankingPlayers.Rows.Clear();

                if (itogdata.Count > 0)
                {
                    dataGridViewRankingPlayers.Rows.Add(itogdata.Count);


                    for (int i = 0; i < itogdata.Count; i++)
                    {
                        dataGridViewRankingPlayers.Rows[i].Cells[0].Value = (i+1).ToString();
                        dataGridViewRankingPlayers.Rows[i].Cells[1].Value = itogdata[i].nameplayer;
                        dataGridViewRankingPlayers.Rows[i].Cells[2].Value = itogdata[i].namecurrentteam;
                        dataGridViewRankingPlayers.Rows[i].Cells[3].Value =
                             string.Format("{0}, ({1})", itogdata[i].total.ToString(), itogdata[i].stotal);
                        dataGridViewRankingPlayers.Rows[i].Cells[4].Value = 
                            string.Format("{0}, ({1})",itogdata[i].atake,itogdata[i].satake);
                        dataGridViewRankingPlayers.Rows[i].Cells[5].Value =
                            string.Format("{0}, ({1})", itogdata[i].effective, itogdata[i].seffective);
                        dataGridViewRankingPlayers.Rows[i].Cells[6].Value =
                            string.Format("{0}, ({1})", itogdata[i].defender, itogdata[i].sdefender);
                        dataGridViewRankingPlayers.Rows[i].Cells[7].Value =
                            string.Format("{0}, ({1})", itogdata[i].power, itogdata[i].spower);
                        dataGridViewRankingPlayers.Rows[i].Cells[8].Value =
                            string.Format("{0}, ({1})", itogdata[i].temporary, itogdata[i].stemporary);
                    }

                    dataGridViewRankingPlayers.AllowUserToAddRows = false;
                }
                else dataGridViewRankingPlayers.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemToExcel_Click(object sender, EventArgs e)
        {
            ExcelRankingPlayer cl = new ExcelRankingPlayer(connect, IS, itogdata, 1);
        }
    }


   
}
