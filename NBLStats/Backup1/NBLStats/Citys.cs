/*  Справочник облстей */

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
    public partial class Citys : Form
    {
        SqlConnection connect;
        CCity clCity;
        List<STCity> list;
        ushort mode;
        bool g_f;

        STCity flawour;
        int gpos;

        public Citys(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            
            clCity = new CCity(connect);

            this.WindowState = FormWindowState.Maximized;

            gpos = 0;
        }

        private void Citys_Load(object sender, EventArgs e)
        {
            init_list();
        }

        private void init_list()
        {
            dataGridViewCity.Rows.Clear();

            list = clCity.GetListCity();

            CRegion region;

            try
            {
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewCity.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewCity.Rows[i].Cells[0].Value = (i + 1).ToString();

                        dataGridViewCity.Rows[i].Cells[1].Value = list[i].name;

                        region = new CRegion(connect, list[i].idreg);

                        dataGridViewCity.Rows[i].Cells[2].Value = region.stFullReg.name;
                        dataGridViewCity.Rows[i].Cells[3].Value = region.stFullReg.shortnamecountry;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewCity.AllowUserToAddRows = false;
                }
                else dataGridViewCity.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddCity_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditCity_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteCity_Click(object sender, EventArgs e)
        {
            del();
        }

        private void contextMenuStripCity_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (!g_f)
                {
                    ToolStripMenuItemDeleteCity.Enabled = false;
                    ToolStripMenuItemEditCity.Enabled = false;
                    ToolStripMenuItemExportExcel.Enabled = false;
                }
                else
                {
                    ToolStripMenuItemDeleteCity.Enabled = true;
                    ToolStripMenuItemEditCity.Enabled = true;
                    ToolStripMenuItemExportExcel.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void listViewCity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgCitys wnd = new DlgCitys(connect, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewCity.Rows.Count > 0)
                    {
                        dataGridViewCity.Rows[gpos].Selected = true;
                        dataGridViewCity.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STCity data = GetSelectionData();

                DlgCitys wnd = new DlgCitys(connect, data, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewCity.Rows.Count > 0)
                    {
                        dataGridViewCity.Rows[gpos].Selected = true;
                        dataGridViewCity.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STCity data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clCity.Delete(data);
                    init_list();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STCity GetSelectionData()
        {
            
            STCity ret = new STCity();

            string n;

            try
            {
                foreach (DataGridViewRow item in dataGridViewCity.SelectedRows)
                {
                    n = item.Cells[1].Value.ToString();

                    CCity ct = new CCity(connect, n);

                    ret = ct.stCity;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

       
    }
}