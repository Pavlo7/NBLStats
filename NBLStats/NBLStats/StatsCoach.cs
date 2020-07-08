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
    public partial class StatsCoach : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        
        CStatsCoach clWork;
        List<STStatsCoach> list;

        CCoach clCoach;
        CTeam clTeam;

        int gpos;

        public StatsCoach(SqlConnection cn, STInfoSeason st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = st;
            mode = md;
        }

        private void StatsCoach_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                clWork = new CStatsCoach(connect);

                gpos = 0;

                init_data();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            try
            {
                dataGridViewStatCoach.Rows.Clear();

                list = clWork.GetListData(IS.idseason);

                if (list.Count > 0)
                {
                    dataGridViewStatCoach.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewStatCoach.Rows[i].Cells[0].Value = list[i].idgame;
                        clTeam = new CTeam(connect, list[i].idteam);
                        dataGridViewStatCoach.Rows[i].Cells[1].Value = clTeam.stTeam.name;

                        clCoach = new CCoach(connect, list[i].idcoach);
                        dataGridViewStatCoach.Rows[i].Cells[2].Value = string.Format("{0} {1}",
                            clCoach.stCoach.family,clCoach.stCoach.name);

                        dataGridViewStatCoach.Rows[i].Cells[3].Value = list[i].cntfoulst.ToString();
                        dataGridViewStatCoach.Rows[i].Cells[4].Value = list[i].cntfoulsd.ToString();
                        dataGridViewStatCoach.Rows[i].Cells[5].Value = list[i].filename;
                    }

                    dataGridViewStatCoach.AllowUserToAddRows = false;
                }
                else dataGridViewStatCoach.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
