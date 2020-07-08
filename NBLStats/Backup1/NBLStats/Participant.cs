/*  Справочник сотрудников */

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
    public partial class Participant : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
       
        List<STParticipant> list;
        CParticipant clParticipant;
        ushort mode;

        bool g_f;

        CPostment clPost;
        STParticipant flawour;
        int gpos;

        public Participant(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
           
        }

        private void Participant_Load(object sender, EventArgs e)
        {
            try
            {
                clParticipant = new CParticipant(connect);

                this.WindowState = FormWindowState.Maximized;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            string text;
            DateTime dt;

            List<int> arr;
            bool fl;


            CCountry clCo = new CCountry(connect);
            clPost = new CPostment(connect);

            g_f = false;

            try
            {
                dataGridViewPart.Rows.Clear();

                list = new List<STParticipant>();

                list = clParticipant.GetList();

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewPart.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewPart.Rows[i].Cells[0].Value = (i + 1).ToString();

                        text = list[i].family + " " + list[i].name + " " + list[i].payname;
                        dataGridViewPart.Rows[i].Cells[1].Value = text;

                        if (list[i].datebirth != null)
                        {
                            dt = (DateTime)list[i].datebirth;
                            dataGridViewPart.Rows[i].Cells[2].Value = dt.ToShortDateString();
                        }

                        dataGridViewPart.Rows[i].Cells[3].Value = list[i].personalnum;

                        if (list[i].idcountry != null)
                        {
                            clCo = new CCountry(connect, (int)list[i].idcountry);
                            dataGridViewPart.Rows[i].Cells[4].Value = clCo.stCountry.shortname;
                        }

                        dataGridViewPart.Rows[i].Cells[5].Value = list[i].namefoto;

                      
                        if (list[i].post != null)
                        {
                            arr = clParticipant.GetArrayPost(list[i].post);

                            if (arr.Count > 0)
                            {
                                text = null;
                                string hd = null;
                                fl = false;

                                foreach (int n in arr)
                                {
                                    STPostment st = clPost.GetPost(n);

                                    if (fl == false)
                                    {
                                        text = st.namepost;
                                        fl = true;
                                    }
                                    else text += ", " + st.namepost;
                                }
                            }

                            dataGridViewPart.Rows[i].Cells[6].Value = text;
                        }


                        

                        if (list[i].adminflag == 1)
                            dataGridViewPart.Rows[i].Cells[7].Value = " * ";

                        dataGridViewPart.Rows[i].Cells[8].Value = list[i].idpart.ToString();

                        if (list[i].vf != null)
                        {
                            if (list[i].vf == 1) dataGridViewPart.Rows[i].Cells[9].Value = "*";
                        }
                        
                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewPart.AllowUserToAddRows = false;
                }
                else dataGridViewPart.AllowUserToAddRows = false;

                toolStripStatusLabel1.Text = string.Format("Число персонала: {0}", list.Count);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void add()
        {
            try
            {
                DlgParticipant wnd = new DlgParticipant(connect, null);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewPart.Rows.Count > 0)
                    {
                        dataGridViewPart.Rows[gpos].Selected = true;
                        dataGridViewPart.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void edit()
        {
            try
            {
                STParticipant data = GetSelectionData();

                if (data.idpart > 0)
                {
                    DlgParticipant wnd = new DlgParticipant(connect, data);

                    DialogResult result = wnd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data();

                        if (gpos >= 0 && dataGridViewPart.Rows.Count > 0)
                        {
                            dataGridViewPart.Rows[gpos].Selected = true;
                            dataGridViewPart.FirstDisplayedScrollingRowIndex = gpos;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void del()
        {
            try
            {
                STParticipant data = GetSelectionData();

                if (data.idpart > 0)
                {
                    string text = string.Format("Вы действительно желаете удалить тренера: {0} {1} {2}",
                        data.family, data.name, data.payname);

                    if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (clParticipant.Delete(data))
                        {
                            init_data();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STParticipant GetSelectionData()
        {
            STParticipant ret = new STParticipant();

            int id;

            try
            {
                foreach (DataGridViewRow item in dataGridViewPart.SelectedRows)
                {
                    id = int.Parse(item.Cells[8].Value.ToString());

                    foreach (STParticipant s in list)
                        if (id == s.idpart) ret = s;
                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
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

        private void ToolStripMenuItemExportExcelPart_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewPart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        

       
    }
}