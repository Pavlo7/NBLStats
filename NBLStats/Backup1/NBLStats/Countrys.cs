/*  Справочник стран */

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
    public partial class Countrys : Form
    {
        SqlConnection connect;
        CCountry clCountry;
        List<STCountry> list;
        ushort mode;
        bool g_f;

        STCountry flawour;
        int gpos;

        public Countrys(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            clCountry = new CCountry(connect);

            this.WindowState = FormWindowState.Maximized;

            gpos = 0;
        }

        private void Countrys_Load(object sender, EventArgs e)
        {
            init_list();
        }

        private void init_list()
        {
            dataGridViewCountry.Rows.Clear();

            list = clCountry.GetListCountry();

            try
            {
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewCountry.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewCountry.Rows[i].Cells[0].Value = (i + 1).ToString();

                        dataGridViewCountry.Rows[i].Cells[1].Value = list[i].name;

                        dataGridViewCountry.Rows[i].Cells[2].Value = list[i].shortname;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewCountry.AllowUserToAddRows = false;
                }
                else dataGridViewCountry.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddCountry_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditCountry_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteCountry_Click(object sender, EventArgs e)
        {
            del();
        }

        private void ToolStripMenuItemExportExcel_Click(object sender, EventArgs e)
        {

        }

        private void add()
        {
            try
            {
                DlgCountrys wnd = new DlgCountrys(connect, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewCountry.Rows.Count > 0)
                    {
                        dataGridViewCountry.Rows[gpos].Selected = true;
                        dataGridViewCountry.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STCountry data = GetSelectionData();

                DlgCountrys wnd = new DlgCountrys(connect, data, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewCountry.Rows.Count > 0)
                    {
                        dataGridViewCountry.Rows[gpos].Selected = true;
                        dataGridViewCountry.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STCountry data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clCountry.Delete(data);
                    init_list();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void contextMenuStripCountry_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (!g_f)
                {
                    ToolStripMenuItemDeleteCountry.Enabled = false;
                    ToolStripMenuItemEditCountry.Enabled = false;
                    ToolStripMenuItemExportExcel.Enabled = false;
                }
                else
                {
                    ToolStripMenuItemDeleteCountry.Enabled = true;
                    ToolStripMenuItemEditCountry.Enabled = true;
                    ToolStripMenuItemExportExcel.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STCountry GetSelectionData()
        {
            STCountry ret = new STCountry();

            string n = null; ;

            try
            {
                foreach (DataGridViewRow item in dataGridViewCountry.SelectedRows)
                {
                    n = item.Cells[2].Value.ToString();

                    CCountry ct = new CCountry(connect, n);

                    ret = ct.stCountry;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void listViewCountry_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }
    }
}