/*  Справочник должностей */

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
    public partial class Postment : Form
    {
        SqlConnection connect;
        CPostment clWork;
        List<STPostment> list;
        ushort mode;
        bool g_f;

        STPostment flawour;
        int gpos;

        public Postment(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
        }

        private void Postment_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CPostment(connect);

                this.WindowState = FormWindowState.Maximized;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            dataGridViewPostment.Rows.Clear();

            list = clWork.GetList();

            gpos = -1;

            try
            {
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewPostment.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewPostment.Rows[i].Cells[0].Value = list[i].idpost.ToString();

                        if (list[i].namepost != null)
                            dataGridViewPostment.Rows[i].Cells[1].Value = list[i].namepost;

                        if (list[i].descript != null)
                            dataGridViewPostment.Rows[i].Cells[2].Value = list[i].descript;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewPostment.AllowUserToAddRows = false;
                }
                else dataGridViewPostment.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddPost_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditPost_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeletePost_Click(object sender, EventArgs e)
        {
            del();
        }

        private void dataGridViewPostment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgPostmetn wnd = new DlgPostmetn(connect, null);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewPostment.Rows.Count > 0)
                    {
                        dataGridViewPostment.Rows[gpos].Selected = true;
                        dataGridViewPostment.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STPostment data = GetSelectionData();

                DlgPostmetn wnd = new DlgPostmetn(connect, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewPostment.Rows.Count > 0)
                    {
                        dataGridViewPostment.Rows[gpos].Selected = true;
                        dataGridViewPostment.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STPostment data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clWork.Delete(data);
                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STPostment GetSelectionData()
        {
            STPostment ret = new STPostment();
            int n;

            try
            {
                foreach (DataGridViewRow item in dataGridViewPostment.SelectedRows)
                {
                    n = int.Parse(item.Cells[0].Value.ToString());

                    ret = clWork.GetPost(n);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}
