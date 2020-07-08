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
    public partial class TableTehnicalFouls : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CTehnicFouls clTF;
        List<STTehnicFouls> list;

        ushort mode;
        bool g_f;

        STTehnicFouls flawour;
        int gpos;

        public TableTehnicalFouls(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void TableTehnicalFouls_Load(object sender, EventArgs e)
        {
            try
            {
                clTF = new CTehnicFouls(connect);

                this.WindowState = FormWindowState.Maximized;

                gpos = 0;

                init_list();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_list()
        {
            CPlayer clPlayer;
            CCoach clCoach;
            CTeam clTeam;
            CGame clGame;
            STGame game;

            string text = null;

            string name1,name2;

            try
            {
                list = clTF.GetListData(IS.idseason);

                dataGridViewTehFouls.Rows.Clear();

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewTehFouls.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewTehFouls.Rows[i].Cells[0].Value = list[i].id.ToString();

                        if (list[i].typepart == 0)
                        {
                            clPlayer = new CPlayer(connect, list[i].idpart);
                            text = string.Format("{0} {1}", clPlayer.stPlayer.family.ToUpper(), clPlayer.stPlayer.name);
                        }
                        else if (list[i].typepart == 1)
                        {
                            clCoach = new CCoach(connect, list[i].idpart);
                            text = string.Format("{0} {1} (тренер)", 
                                clCoach.stCoach.family.ToUpper(), clCoach.stCoach.name);
                        }
                        dataGridViewTehFouls.Rows[i].Cells[1].Value = text;

                        clTeam = new CTeam(connect,list[i].idteam);
                        dataGridViewTehFouls.Rows[i].Cells[2].Value = clTeam.stTeam.name;

                        clGame = new CGame(connect);
                        game = clGame.GetGame(list[i].idseason, list[i].idgame);
                        clTeam = new CTeam(connect,(int)game.idteam1);
                        name1 = clTeam.stTeam.name;
                        clTeam = new CTeam(connect,(int)game.idteam2);
                        name2 = clTeam.stTeam.name;
                        text = string.Format("№{0} {1} - {2} ", game.idgame, name1, name2);
                        dataGridViewTehFouls.Rows[i].Cells[3].Value = text;

                        dataGridViewTehFouls.Rows[i].Cells[4].Value = list[i].date.ToLongDateString();

                        dataGridViewTehFouls.Rows[i].Cells[5].Value = list[i].descript;

                        if (list[i].idreferee > 0)
                        {
                            CReferee clRef = new CReferee(connect, list[i].idreferee);
                            text = string.Format("{0} {1}", clRef.stRef.family, clRef.stRef.name);
                            dataGridViewTehFouls.Rows[i].Cells[6].Value = text;
                        }

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewTehFouls.AllowUserToAddRows = false;
                }
                else dataGridViewTehFouls.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddTF_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditTF_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteTF_Click(object sender, EventArgs e)
        {
            del();
        }

        private void dataGridViewTehFouls_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgTechnicalFouls wnd = new DlgTechnicalFouls(connect, IS.idseason);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewTehFouls.Rows.Count > 0)
                    {
                        dataGridViewTehFouls.Rows[gpos].Selected = true;
                        dataGridViewTehFouls.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STTehnicFouls data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clTF.Delete(data);
                    init_list();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STTehnicFouls data = GetSelectionData();

                DlgTechnicalFouls wnd = new DlgTechnicalFouls(connect, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewTehFouls.Rows.Count > 0)
                    {
                        dataGridViewTehFouls.Rows[gpos].Selected = true;
                        dataGridViewTehFouls.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STTehnicFouls GetSelectionData()
        {
            STTehnicFouls ret = new STTehnicFouls();

            try
            {
                foreach (DataGridViewRow item in dataGridViewTehFouls.SelectedRows)
                {
                    int id = int.Parse(item.Cells[0].Value.ToString().Trim());

                    foreach (STTehnicFouls data in list)
                        if (data.id == id) ret = data;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void ToolStripMenuItemExportExcelTF_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelListTehnicalFouls rep = new ExcelListTehnicalFouls(connect, list);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}