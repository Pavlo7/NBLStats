/*  Справочник регионов (областей) */

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
    public partial class Regions : Form
    {
        SqlConnection connect;
        CRegion clRegion;
        List<STRegion> list;
        ushort mode;
        bool g_f;

        STRegion flawour;
        int gpos;

        public Regions(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
                     
            clRegion = new CRegion(connect);

            this.WindowState = FormWindowState.Maximized;

            gpos = 0;
        }

        private void Regions_Load(object sender, EventArgs e)
        {
            init_list();
        }

        private void init_list()
        {
            dataGridViewRegion.Rows.Clear();

            list = clRegion.GetListRegion();

            CCountry country;

            try
            {
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewRegion.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewRegion.Rows[i].Cells[0].Value = (i + 1).ToString();

                        dataGridViewRegion.Rows[i].Cells[1].Value = list[i].name;

                        dataGridViewRegion.Rows[i].Cells[2].Value = list[i].shortname;

                        country = new CCountry(connect, list[i].idcountry);
                        dataGridViewRegion.Rows[i].Cells[3].Value = country.stCountry.shortname;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewRegion.AllowUserToAddRows = false;
                }
                else dataGridViewRegion.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddRegion_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditRegion_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteRegion_Click(object sender, EventArgs e)
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
                DlgRegions wnd = new DlgRegions(connect, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewRegion.Rows.Count > 0)
                    {
                        dataGridViewRegion.Rows[gpos].Selected = true;
                        dataGridViewRegion.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STRegion data = GetSelectionData();

                DlgRegions wnd = new DlgRegions(connect, data, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_list();

                    if (gpos >= 0 && dataGridViewRegion.Rows.Count > 0)
                    {
                        dataGridViewRegion.Rows[gpos].Selected = true;
                        dataGridViewRegion.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STRegion data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clRegion.Delete(data);
                    init_list();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void listViewRegion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void contextMenuStripRegion_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (!g_f)
                {
                    ToolStripMenuItemDeleteRegion.Enabled = false;
                    ToolStripMenuItemEditRegion.Enabled = false;
                    ToolStripMenuItemExportExcel.Enabled = false;
                }
                else
                {
                    ToolStripMenuItemDeleteRegion.Enabled = true;
                    ToolStripMenuItemEditRegion.Enabled = true;
                    ToolStripMenuItemExportExcel.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STRegion GetSelectionData()
        {
            STRegion ret = new STRegion();

            string n;

            try
            {
                foreach (DataGridViewRow item in dataGridViewRegion.SelectedRows)
                {
                    n = item.Cells[1].Value.ToString();

                    CRegion ct = new CRegion(connect, n);

                    ret = ct.stReg;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}