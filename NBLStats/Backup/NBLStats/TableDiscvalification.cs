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
    public partial class TableDiscvalification : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CDiscvalification clDv;
        List<STDiscvalification> list;

        ushort mode;
        bool g_f;

        STDiscvalification flawour;
        int gpos;

        public TableDiscvalification(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void TableDiscvalification_Load(object sender, EventArgs e)
        {
            try
            {
                clDv = new CDiscvalification(connect);

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

            string name1, name2;

            try
            {
                list = clDv.GetListData(IS.idseason);

                dataGridViewDV.Rows.Clear();

                if (list.Count > 0)
                {
                     g_f = true;

                    dataGridViewDV.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewDV.Rows[i].Cells[0].Value = list[i].id.ToString();

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
                        dataGridViewDV.Rows[i].Cells[1].Value = text;

                        clTeam = new CTeam(connect, list[i].idteam);
                        dataGridViewDV.Rows[i].Cells[2].Value = clTeam.stTeam.name;

                        dataGridViewDV.Rows[i].Cells[3].Value = list[i].cntgame;

                        dataGridViewDV.Rows[i].Cells[4].Value = list[i].datebegin.ToLongDateString();
                        dataGridViewDV.Rows[i].Cells[5].Value = list[i].dateend.ToLongDateString();

                        dataGridViewDV.Rows[i].Cells[6].Value = list[i].descript;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewDV.AllowUserToAddRows = false;
                }
                else dataGridViewDV.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddDV_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditDV_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteDV_Click(object sender, EventArgs e)
        {
            del();
        }

        private void ToolStripMenuItemExportExcelDV_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelListDiscvalification rep = new ExcelListDiscvalification(connect, list);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void dataGridViewDV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            DlgDiscvalification wnd = new DlgDiscvalification(connect, IS.idseason);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                flawour = wnd.GetFl();

                init_list();

                if (gpos >= 0 && dataGridViewDV.Rows.Count > 0)
                {
                    dataGridViewDV.Rows[gpos].Selected = true;
                    dataGridViewDV.FirstDisplayedScrollingRowIndex = gpos;
                }
            }
        }

        private void del()
        {
            STDiscvalification data = GetSelectionData();

            if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clDv.Delete(data);
                init_list();
            }
        }

        private void edit()
        {
            STDiscvalification data = GetSelectionData();

            DlgDiscvalification wnd = new DlgDiscvalification(connect, data);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                flawour = wnd.GetFl();

                init_list();

                if (gpos >= 0 && dataGridViewDV.Rows.Count > 0)
                {
                    dataGridViewDV.Rows[gpos].Selected = true;
                    dataGridViewDV.FirstDisplayedScrollingRowIndex = gpos;
                }
            }
        }

        private STDiscvalification GetSelectionData()
        {
            STDiscvalification ret = new STDiscvalification();

            foreach (DataGridViewRow item in dataGridViewDV.SelectedRows)
            {
                int id = int.Parse(item.Cells[0].Value.ToString().Trim());

                foreach (STDiscvalification data in list)
                    if (data.id == id) ret = data;
            }

            return ret;
        }
    }
}