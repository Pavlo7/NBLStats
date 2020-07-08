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
    public partial class Division : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        CDivision clDivision;
        List<STDivision> list;
        ushort mode;
        int cnt_div;

        bool g_f;

        STDivision flawour;
        int gpos;

        public Division(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clDivision = new CDivision(connect);
        }

        private void Division_Load(object sender, EventArgs e)
        {
            init_data();
        }

        private void init_data()
        {
            dataGridViewDivision.Rows.Clear();

            list = clDivision.GetListDivision(IS.idseason);

            try
            {
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewDivision.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewDivision.Rows[i].Cells[0].Value = (i + 1).ToString();

                        dataGridViewDivision.Rows[i].Cells[1].Value = list[i].name;

                        dataGridViewDivision.Rows[i].Cells[2].Value = list[i].cntteam.ToString();

                        if (list[i].flag_reg == 1) dataGridViewDivision.Rows[i].Cells[3].Value = "да";
                        else dataGridViewDivision.Rows[i].Cells[3].Value = "нет";

                        if (list[i].flag_po == 1) dataGridViewDivision.Rows[i].Cells[4].Value = "да";
                        else dataGridViewDivision.Rows[i].Cells[4].Value = "нет";

                        if (list[i].flag_styk == 1) dataGridViewDivision.Rows[i].Cells[5].Value = "да";
                        else dataGridViewDivision.Rows[i].Cells[5].Value = "нет";

                        if (list[i].deadline != null)
                        {
                            DateTime dt = (DateTime)list[i].deadline;
                            dataGridViewDivision.Rows[i].Cells[6].Value = dt.ToShortDateString();
                        }

                        dataGridViewDivision.Rows[i].Cells[7].Value = list[i].id.ToString(); ;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewDivision.AllowUserToAddRows = false;
                }
                else dataGridViewDivision.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void add()
        {
            try
            {
                DlgDivision wnd = new DlgDivision(connect, IS, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewDivision.Rows.Count > 0)
                    {
                        dataGridViewDivision.Rows[gpos].Selected = true;
                        dataGridViewDivision.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STDivision data = GetSelectionData();

                if (MessageBox.Show("¬ы действиетльно желаете удалить данную запись?", "¬нимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clDivision.Delete(data);
                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STDivision data = GetSelectionData();

                DlgDivision wnd = new DlgDivision(connect, IS, data, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewDivision.Rows.Count > 0)
                    {
                        dataGridViewDivision.Rows[gpos].Selected = true;
                        dataGridViewDivision.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STDivision GetSelectionData()
        {
            STDivision ret = new STDivision();

            string n;

            try
            {
                foreach (DataGridViewRow item in dataGridViewDivision.SelectedRows)
                {
                    n = item.Cells[1].Value.ToString();

                    CDivision sp = new CDivision(connect, (int)IS.idseason, n);

                    ret = sp.stDiv;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void ToolStripMenuItemAddDiv_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditDiv_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteDiv_Click(object sender, EventArgs e)
        {
            del();
        }


        private void dataGridViewDivision_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }
    }
}