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
    public partial class EntryTeam : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        bool g_f;

        List<STEntryTeam> list;
        CEntryTeam clTeamParticipant;

        CPowerTeam clPT;

        List<STPowerTeam> powerteamdata;

        int iddiv;
        
        public EntryTeam(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clTeamParticipant = new CEntryTeam(connect);
            

            this.WindowState = FormWindowState.Maximized;
        }

        private void TeamParticipant_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtonAllDiv.Checked = true;

                iddiv = 0;

                if (IS.cntdivision <= 1)
                {
                    radioButtonOneDiv.Enabled = false;
                    comboBoxDivision.Enabled = false;
                }
                else  init_combo();

                clPT = new CPowerTeam(connect, IS, 0);
                powerteamdata = new List<STPowerTeam>();
                powerteamdata = clPT.GetData();

             //   init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            try
            {
                comboBoxDivision.Items.Clear();

                if (IS.cntdivision > 1)
                {
                    CDivision div = new CDivision(connect);

                    List<STDivision> list = div.GetListDivision((int)IS.idseason);

                    foreach (STDivision item in list)
                    {
                        comboBoxDivision.Items.Add(item.name);
                    }
                }
                else comboBoxDivision.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void init_data()
        {
            CTeam clTeam;
            CDivision clDivision;
            CPlayer clPlayer;
            CCoach clCoach;

            CEntryPlayers clEP = new CEntryPlayers(connect);


            string text;

            try
            {
                g_f = false;

                dataGridViewTeamPart.Rows.Clear();

                list = new List<STEntryTeam>();

                if (iddiv == 0)
                    list = clTeamParticipant.GetTeamParticipant((int)IS.idseason);
                else list = clTeamParticipant.GetTeamParticipant((int)IS.idseason, iddiv);

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewTeamPart.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        /* № п\п */
                        dataGridViewTeamPart.Rows[i].Cells[0].Value = (i + 1).ToString();

                        /* Команда */
                        clTeam = new CTeam(connect, list[i].idteam);
                        dataGridViewTeamPart.Rows[i].Cells[1].Value = clTeam.stTeam.name;

                        /* Главный тренер */
                        if (list[i].idcoach1 != null)
                        {
                            clCoach = new CCoach(connect, (int)list[i].idcoach1);
                            text = string.Format("{0} {1}", clCoach.stCoach.family, clCoach.stCoach.name);
                            dataGridViewTeamPart.Rows[i].Cells[2].Value = text;
                        }
                        
                        /* Помощник тренера */
                        if (list[i].idcoach2 != null && list[i].idcoach2 != 0)
                        {
                            clCoach = new CCoach(connect, (int)list[i].idcoach2);
                            text = string.Format("{0} {1}", clCoach.stCoach.family, clCoach.stCoach.name);

                            if (list[i].idcoach3 != null && list[i].idcoach3 != 0)
                            {
                                clCoach = new CCoach(connect, (int)list[i].idcoach3);
                                string text1 = 
                                    string.Format("{0} {1}", clCoach.stCoach.family, clCoach.stCoach.name);
                                text = text + ", " + text1;
                            }

                            dataGridViewTeamPart.Rows[i].Cells[3].Value = text;
                        }

                        /* Капитан */
                        if (list[i].idcaptain != null)
                        {
                            clPlayer = new CPlayer(connect, (int)list[i].idcaptain);
                            text = string.Format("{0} {1}", clPlayer.stPlayer.family, clPlayer.stPlayer.name);
                            dataGridViewTeamPart.Rows[i].Cells[4].Value = text;
                        }

                        /* Число игроков в команде */
                        dataGridViewTeamPart.Rows[i].Cells[5].Value = 
                            clEP.GetCntPlayers(list[i].idseason, list[i].idteam, null);
                            
                        /* Дата заявки */
                        dataGridViewTeamPart.Rows[i].Cells[6].Value = list[i].datein.ToShortDateString();

                        /* Дивизион */
                        clDivision = new CDivision(connect, list[i].idseason, list[i].iddivision);
                        dataGridViewTeamPart.Rows[i].Cells[7].Value = clDivision.stDiv.name;

                        double power = get_power(list[i].idteam);
                        dataGridViewTeamPart.Rows[i].Cells[8].Value = power.ToString();
                    }

                    dataGridViewTeamPart.AllowUserToAddRows = false;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }


        private double get_power(int idteam)
        {
            double ret = 0;
            if (powerteamdata != null)
            {
                foreach (STPowerTeam item in powerteamdata)
                {
                    if (item.idteam == idteam) return item.power;
                }
                
            }

            return ret;
        }


        private void ToolStripMenuItemAddTeamPart_Click(object sender, EventArgs e)
        {
            add();
        }
        private void ToolStripMenuItemEditTeamPart_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void ToolStripMenuItemDeleteTeamPart_Click(object sender, EventArgs e)
        {
            del();
        }
        private void dataGridViewTeamPart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }


        private void add()
        {
            try
            {
                DlgEntryTeam wnd = new DlgEntryTeam(connect, IS, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewTeamPart.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewTeamPart.Rows[x].Selected = true;

                        dataGridViewTeamPart.FirstDisplayedScrollingRowIndex = x;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void edit()
        {
            try
            {
                STEntryTeam st = GetSelectionData();

                DlgEntryTeam wnd = new DlgEntryTeam(connect, IS, st, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewTeamPart.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewTeamPart.Rows[x].Selected = true;

                        dataGridViewTeamPart.FirstDisplayedScrollingRowIndex = x;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void del()
        {
            try
            {
                STEntryTeam data = GetSelectionData();

                CTeam team = new CTeam(connect, data.idteam);

                string text = string.Format("Вы действиетльно желаете удалить заявку команды {0}?",
                    team.stTeam.name);

                if (MessageBox.Show(text, "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clTeamParticipant.Delete(data);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private STEntryTeam GetSelectionData()
        {
            STEntryTeam ret = new STEntryTeam();
            CTeam clTeam;

            string nameteam;

            try
            {
                foreach (DataGridViewRow item in dataGridViewTeamPart.SelectedRows)
                {
                    nameteam = item.Cells[1].Value.ToString();
                    
                    clTeam = new CTeam(connect, nameteam);

                    foreach (STEntryTeam s in list)
                        if (clTeam.stTeam.id == s.idteam) ret = s;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return ret;
        }

        private int get_num_row(int id)
        {
            int ret = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].idteam == id) ret = i;
            }

            return ret;
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    text = comboBoxDivision.Text.Trim();

                    CDivision div = new CDivision(connect,IS.idseason,text);

                    iddiv = div.stDiv.id;

                  //  init_data();
                }

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonAllDiv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAllDiv.Checked == true)
                {
                    iddiv = 0;
                    comboBoxDivision.Text = null;
                    comboBoxDivision.Enabled = false;
                }

              //  init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonOneDiv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonOneDiv.Checked == true)
                {
                    comboBoxDivision.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            init_data();
        }

       
    }
}