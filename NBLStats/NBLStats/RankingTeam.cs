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
    public partial class RankingTeam : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CRankingTeam clRT;

        CInfoSeason clIS;
        CTeam clTeam;

        int idseason;
        DateTime dr;

        public RankingTeam(SqlConnection cn, STInfoSeason iss)
        {
            InitializeComponent();

            connect = cn;
            IS = iss;
        }

        private void RankingTeam_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            clIS = new CInfoSeason(connect);
            clRT = new CRankingTeam(connect);

            init_combo_div();

            idseason = 0;
            dr = DateTime.MinValue;
        }


        private void init_combo_div()
        {
            try
            {
                List<DateTime> lst = clRT.GetListDate();
                //List<STInfoSeason> lst = clIS.GetListSeason();

                if (lst.Count > 0)
                {
                    comboBoxIS.Items.Clear();

                    foreach (DateTime item in lst)
                        comboBoxIS.Items.Add(item.ToShortDateString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DateTime? dt = null;

            try
            {
                if (comboBoxIS.Text.Length > 0)
                {
                    dt = DateTime.Parse(comboBoxIS.Text.Trim());
                    
                    //dr = new DateTime(dateTimePickerDR.Value.Year, dateTimePickerDR.Value.Month,
                    //        dateTimePickerDR.Value.Day, 0, 0, 0, 0);

                    if (dt != null)
                        intit_data((DateTime)dt);
                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void intit_data(DateTime dt)
        {
            CTeam clTeam;
          
            try
            {

                List<STRankingTeam> list = clRT.GetListRankingTeam(dt);

            //    List<STRankingTeam> list_rt = Formed(list);

                dataGridViewRankingTeam.Rows.Clear();

                if (list.Count > 0)
                {


                    dataGridViewRankingTeam.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                       
                        dataGridViewRankingTeam.Rows[i].Cells[0].Value = list[i].ranking.ToString();
                        clTeam = new CTeam(connect, list[i].idteam);
                            dataGridViewRankingTeam.Rows[i].Cells[1].Value = clTeam.stTeam.name;
                            dataGridViewRankingTeam.Rows[i].Cells[2].Value = list[i].points.ToString();
                            dataGridViewRankingTeam.Rows[i].Cells[3].Value = list[i].power.ToString();
                            dataGridViewRankingTeam.Rows[i].Cells[4].Value = list[i].game.ToString();
                            
                       
                    }

                    dataGridViewRankingTeam.AllowUserToAddRows = false;
                }
                else dataGridViewRankingTeam.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private List<STRankingTeam> Formed(List<STRankingTeam> list)
        {
            List<STRankingTeam> ret = new List<STRankingTeam>();
            STRankingTeam item;

            List<STRankingTeam> mix_list = new List<STRankingTeam>();
 
            try
            {
                int currrank = 1;
                foreach (STRankingTeam row in list)
                {
                    if (row.ranking != currrank)
                    {
                        item = get_row(mix_list);
                        ret.Add(item);

                        currrank = row.ranking;
                        mix_list.Clear();
                        mix_list.Add(row);
                    }
                    else
                    {
                        mix_list.Add(row);
                    }
                }

                item = get_row(mix_list);
                ret.Add(item);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private STRankingTeam get_row(List<STRankingTeam> mix_list)
        {
            STRankingTeam ret = new STRankingTeam();

            CEntryTeam clET = new CEntryTeam(connect);
            STEntryTeam stET;

            try
            {
                if (mix_list.Count == 1)
                {
                    ret = mix_list[0];
                }
                else
                {
                    for (int i = IS.idseason; i > 0; i--)
                    {
                            foreach (STRankingTeam row in mix_list)
                            {
                                
                                    clET = new CEntryTeam(connect, i, row.idteam);
                                    if (clET.gstTeamPart.idteam > 0)
                                    {
                                        ret = row;
                                        return ret;
                                    }
                                
                            }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            try
            {
                dr = new DateTime(dateTimePickerDR.Value.Year, dateTimePickerDR.Value.Month,
                    dateTimePickerDR.Value.Day, 0, 0, 0, 0);

                clRT.Calculate(dr);

                intit_data(dr);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ReportExcelRankingTeam report = new ReportExcelRankingTeam(connect, IS);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

       
    }
}
