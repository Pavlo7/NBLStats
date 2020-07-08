/*  Справочник персональных наград */

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
    public partial class Awards : Form
    {
        SqlConnection connect;
        CAward clWork;
        List<STAward> list;
        ushort mode;
        bool g_f;

        STAward flawour;
        int gpos;

        public Awards(SqlConnection cn, ushort md)
        {
            InitializeComponent();
            
            connect = cn;
            mode = md;
        }

        private void Awards_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CAward(connect);

                this.WindowState = FormWindowState.Maximized;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            dataGridViewAward.Rows.Clear();

            list = clWork.GetList();

            gpos = -1;

            try
            {
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewAward.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewAward.Rows[i].Cells[0].Value = list[i].idaward.ToString();

                        if (list[i].nameaward != null)
                            dataGridViewAward.Rows[i].Cells[1].Value = list[i].nameaward;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewAward.AllowUserToAddRows = false;
                }
                else dataGridViewAward.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddAward_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditAward_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteAward_Click(object sender, EventArgs e)
        {
            del();
        }

        private void dataGridViewAward_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgAwards wnd = new DlgAwards(connect, null);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewAward.Rows.Count > 0)
                    {
                        dataGridViewAward.Rows[gpos].Selected = true;
                        dataGridViewAward.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STAward data = GetSelectionData();

                DlgAwards wnd = new DlgAwards(connect, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewAward.Rows.Count > 0)
                    {
                        dataGridViewAward.Rows[gpos].Selected = true;
                        dataGridViewAward.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STAward data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clWork.Delete(data);
                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STAward GetSelectionData()
        {
            STAward ret = new STAward();
            int n;

            try
            {
                foreach (DataGridViewRow item in dataGridViewAward.SelectedRows)
                {
                    n = int.Parse(item.Cells[0].Value.ToString());

                    ret = clWork.GetAward(n);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

    }
}