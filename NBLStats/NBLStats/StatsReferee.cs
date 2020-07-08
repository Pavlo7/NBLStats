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
    public partial class StatsReferee : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        CStatsReferee clWork;
        List<STStatsReferee> list;

        CReferee clReferee;

        bool g_f;

        STStatsReferee flawour;
        int gpos;
        
        public StatsReferee(SqlConnection cn, STInfoSeason st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = st;
            mode = md;
        }

        private void StatsReferee_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                clWork = new CStatsReferee(connect);

                init_data();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            try
            {
                dataGridViewStatReferee.Rows.Clear();

                list = clWork.GetListData(IS.idseason);

                if (list.Count > 0)
                {
                    dataGridViewStatReferee.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewStatReferee.Rows[i].Cells[0].Value = list[i].idgame;

                        clReferee = new CReferee(connect, list[i].idreferee);
                        dataGridViewStatReferee.Rows[i].Cells[1].Value = string.Format("{0} {1}",
                            clReferee.stRef.family, clReferee.stRef.name);

                        CTeam clTeam = new CTeam(connect, list[i].idteam);
                        dataGridViewStatReferee.Rows[i].Cells[2].Value = clTeam.stTeam.name;

                        int sum = list[i].cntfoulsd + list[i].cntfoulsp + list[i].cntfoulst + list[i].cntfoulsu;
                        dataGridViewStatReferee.Rows[i].Cells[3].Value = sum.ToString();
                        
                        dataGridViewStatReferee.Rows[i].Cells[4].Value = list[i].cntfoulsp.ToString();
                        dataGridViewStatReferee.Rows[i].Cells[5].Value = list[i].cntfoulsu.ToString();
                        dataGridViewStatReferee.Rows[i].Cells[6].Value = list[i].cntfoulst.ToString();
                        dataGridViewStatReferee.Rows[i].Cells[7].Value = list[i].cntfoulsd.ToString();
                        dataGridViewStatReferee.Rows[i].Cells[8].Value = list[i].cntfoulsc.ToString();
                        dataGridViewStatReferee.Rows[i].Cells[9].Value = list[i].cntfoulsb.ToString();

                        dataGridViewStatReferee.Rows[i].Cells[10].Value = list[i].filename;
                        dataGridViewStatReferee.Rows[i].Cells[11].Value = list[i].idreferee;

                        if (flawour.idgame == list[i].idgame && flawour.idreferee == list[i].idreferee &&
                            flawour.idteam == list[i].idteam) gpos = i;
                    }

                    dataGridViewStatReferee.AllowUserToAddRows = false;
                }
                else dataGridViewStatReferee.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddDV_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemEditDV_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemDeleteDV_Click(object sender, EventArgs e)
        {

        }

    }
}
