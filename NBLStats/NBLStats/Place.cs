/*  Справочник игровых площадок */

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
    public partial class Place : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CPlace clPlace;
        List<STPlace> list;
       
        ushort mode;
        bool g_f;

        STPlace flawour;
        int gpos;

        public Place(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clPlace = new CPlace(connect);

            this.WindowState = FormWindowState.Maximized;
            
            gpos = 0;

        }

        private void Place_Load(object sender, EventArgs e)
        {
            init_list();
        }

        private void init_list()
        {
            list = clPlace.GetListPlace();

            CCity city;

            dataGridViewPlace.Rows.Clear();

            try
            {
                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewPlace.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewPlace.Rows[i].Cells[0].Value = (i + 1).ToString();

                        dataGridViewPlace.Rows[i].Cells[1].Value = list[i].name;

                        city = new CCity(connect, list[i].idcity);
                        dataGridViewPlace.Rows[i].Cells[2].Value = city.stCity.name;

                        dataGridViewPlace.Rows[i].Cells[3].Value = list[i].address;

                        if (list[i].vf != null)
                        {
                            if (list[i].vf == 1)
                            dataGridViewPlace.Rows[i].Cells[4].Value = "*";
                        }

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewPlace.AllowUserToAddRows = false;
                }
                else dataGridViewPlace.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void add()
        {
            DlgPlace wnd = new DlgPlace(connect, mode);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                flawour = wnd.GetFl();

                init_list();

                if (gpos >= 0 && dataGridViewPlace.Rows.Count > 0)
                {
                    dataGridViewPlace.Rows[gpos].Selected = true;
                    dataGridViewPlace.FirstDisplayedScrollingRowIndex = gpos;
                }
            }
        }

        private void del()
        {
            STPlace data = GetSelectionData();

            if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clPlace.Delete(data);
                init_list();
            }
        }


        private void edit()
        {
            STPlace data = GetSelectionData();

            DlgPlace wnd = new DlgPlace(connect, data, mode);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                flawour = wnd.GetFl();

                init_list();

                if (gpos >= 0 && dataGridViewPlace.Rows.Count > 0)
                {
                    dataGridViewPlace.Rows[gpos].Selected = true;
                    dataGridViewPlace.FirstDisplayedScrollingRowIndex = gpos;
                }
            }
        }

        private STPlace GetSelectionData()
        {
            STPlace ret = new STPlace();

            string n;

            foreach (DataGridViewRow item in dataGridViewPlace.SelectedRows)
            {
                n = item.Cells[1].Value.ToString();

                CPlace sp = new CPlace(connect, n);

                ret = sp.stPlace;
            }

            return ret;
        }

        private void ToolStripMenuItemAddPlace_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditPlace_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeletePlace_Click(object sender, EventArgs e)
        {
            del();
        }

        private void listViewPlace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void contextMenuStripPlace_Opening(object sender, CancelEventArgs e)
        {
            if (!g_f)
            {
                ToolStripMenuItemEditPlace.Enabled = false;
                ToolStripMenuItemDeletePlace.Enabled = false;
                ToolStripMenuItemExportExcel.Enabled = false;
            }
            else
            {
                ToolStripMenuItemEditPlace.Enabled = true;
                ToolStripMenuItemDeletePlace.Enabled = true;
                ToolStripMenuItemExportExcel.Enabled = true;
            }
        }

        private void dataGridViewPlace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }
    }
}