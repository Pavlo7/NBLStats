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
    public partial class Referee : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        List<STReferee> list;
        CReferee clReferee;
        ushort mode;
        bool g_f;


        public Referee(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clReferee = new CReferee(connect);

            this.WindowState = FormWindowState.Maximized;
        }

        private void Referee_Load(object sender, EventArgs e)
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
                dataGridViewReferee.Rows.Clear();

                list = new List<STReferee>();

                list = clReferee.GetList();

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewReferee.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewReferee.Rows[i].Cells[0].Value = (i + 1).ToString();
                        
                        text = list[i].family + " " + list[i].name + " " + list[i].payname;
                        dataGridViewReferee.Rows[i].Cells[1].Value = text;


                        dataGridViewReferee.Rows[i].Cells[2].Value = list[i].category;

                        if (list[i].datebirth != null)
                        {
                            dt = (DateTime)list[i].datebirth;
                            dataGridViewReferee.Rows[i].Cells[3].Value = dt.ToShortDateString();
                        }

                        dataGridViewReferee.Rows[i].Cells[4].Value = list[i].personalnum;

                        if (list[i].idcountry != null)
                        {
                            clCo = new CCountry(connect, (int)list[i].idcountry);
                            dataGridViewReferee.Rows[i].Cells[5].Value = clCo.stCountry.shortname;
                        }

                        dataGridViewReferee.Rows[i].Cells[6].Value = list[i].namefoto;

                        dataGridViewReferee.Rows[i].Cells[7].Value = list[i].idref.ToString();

                        dataGridViewReferee.Rows[i].Cells[8].Value = list[i].descript;

                        if (list[i].vf != null)
                        {
                            if (list[i].vf == 1) dataGridViewReferee.Rows[i].Cells[9].Value = "*";
                        }
                    }

                    dataGridViewReferee.AllowUserToAddRows = false;
                }

                toolStripStatusLabel1.Text = string.Format("Число судей: {0}", list.Count);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void add()
        {
            DlgReferee wnd = new DlgReferee(connect, mode);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                init_data();

                if (dataGridViewReferee.Rows.Count > 0)
                {
                    int x = get_num_row(wnd.RetId());
                    dataGridViewReferee.Rows[x].Selected = true;

                    dataGridViewReferee.FirstDisplayedScrollingRowIndex = x;
                }
            }
        }
        private void edit()
        {
            STReferee data = GetSelectionData();

            if (data.idref > 0)
            {
                DlgReferee wnd = new DlgReferee(connect, mode, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewReferee.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewReferee.Rows[x].Selected = true;

                        dataGridViewReferee.FirstDisplayedScrollingRowIndex = x;
                    }
                }
            }
        }
        private void del()
        {
            STReferee data = GetSelectionData();

            if (data.idref > 0)
            {
                string text = string.Format("Вы действительно желаете удалить судью: {0} {1} {2}",
                    data.family, data.name, data.payname);

                if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (clReferee.Delete(data))
                    {
                        init_data();
                    }
                }
            }
        }

        private STReferee GetSelectionData()
        {
            STReferee ret = new STReferee();

            int id;

            try
            {   
                if (g_f)
                {
                    foreach (DataGridViewRow item in dataGridViewReferee.SelectedRows)
                    {
                        id = int.Parse(item.Cells[7].Value.ToString());

                        foreach (STReferee s in list)
                            if (id == s.idref) ret = s;
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
                if (list[i].idref == id) ret = i;
            }

            return ret;
        }

        private void dataGridViewCoach_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemAddPart_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditPart_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeletePart_Click(object sender, EventArgs e)
        {
            del();
        }

        private void ToolStripMenuItemExportExcel_Click(object sender, EventArgs e)
        {

        }
    }
}