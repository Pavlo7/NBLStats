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
    public partial class Coach : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        List<STCoach> list;
        CCoach clCoach;
        ushort mode;
        bool g_f;

        public Coach(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clCoach = new CCoach(connect);

            this.WindowState = FormWindowState.Maximized;
        }

        private void Coach_Load(object sender, EventArgs e)
        {
            try
            {
                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void init_data()
        {
            string text;
            DateTime dt;

            CCountry clCo = new CCountry(connect);

            g_f = false;

            try
            {
                dataGridViewCoach.Rows.Clear();

                list = new List<STCoach>();

                list = clCoach.GetList();

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewCoach.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewCoach.Rows[i].Cells[0].Value = (i + 1).ToString();
                       
                        text = list[i].family + " " + list[i].name + " " + list[i].payname;
                        dataGridViewCoach.Rows[i].Cells[1].Value = text;

                        if (list[i].datebirth != null)
                        {
                            dt = (DateTime)list[i].datebirth;
                            dataGridViewCoach.Rows[i].Cells[2].Value = dt.ToShortDateString();
                        }

                        dataGridViewCoach.Rows[i].Cells[3].Value = list[i].personalnum;

                        if (list[i].idcountry != null)
                        {
                            clCo = new CCountry(connect, (int)list[i].idcountry);
                            dataGridViewCoach.Rows[i].Cells[4].Value = clCo.stCountry.shortname;
                        }

                        dataGridViewCoach.Rows[i].Cells[5].Value = list[i].namefoto;

                        dataGridViewCoach.Rows[i].Cells[6].Value = list[i].idcoach.ToString();

                        dataGridViewCoach.Rows[i].Cells[7].Value = list[i].descript;
                    }

                    dataGridViewCoach.AllowUserToAddRows = false;
                }

                toolStripStatusLabel1.Text = string.Format("Число тренеров: {0}", list.Count);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridViewCoach_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            DlgCoach wnd = new DlgCoach(connect, mode);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                init_data();

                if (dataGridViewCoach.Rows.Count > 0)
                {
                    int x = get_num_row(wnd.RetId());
                    dataGridViewCoach.Rows[x].Selected = true;

                    dataGridViewCoach.FirstDisplayedScrollingRowIndex = x;
                }
            }
        }
        private void edit()
        {
            STCoach data = GetSelectionData();

            if (data.idcoach > 0)
            {
                DlgCoach wnd = new DlgCoach(connect, mode, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewCoach.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewCoach.Rows[x].Selected = true;

                        dataGridViewCoach.FirstDisplayedScrollingRowIndex = x;
                    }
                }
            }
        }
        private void del()
        {
            STCoach data = GetSelectionData();

            if (data.idcoach > 0)
            {
                string text = string.Format("Вы действительно желаете удалить тренера: {0} {1} {2}",
                    data.family, data.name, data.payname);

                if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (clCoach.Delete(data))
                    {
                        init_data();
                    }
                }
            }
        }

        private STCoach GetSelectionData()
        {
            STCoach ret = new STCoach();

            int id;

            try
            {
                if (g_f)
                {
                    foreach (DataGridViewRow item in dataGridViewCoach.SelectedRows)
                    {
                        id = int.Parse(item.Cells[6].Value.ToString());

                        foreach (STCoach s in list)
                            if (id == s.idcoach) ret = s;
                    }
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
                if (list[i].idcoach == id) ret = i;
            }

            return ret;
        }

        private void ToolStripMenuItemAddCoach_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditCoach_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteCoach_Click(object sender, EventArgs e)
        {
            del();
        }

       
      
    }
}