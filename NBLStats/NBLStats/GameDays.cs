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
    public partial class GameDays : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        bool g_f;

        CGameDays clWork;
        List<STGameDays> list;

        STGameDays flawour;
        int gpos;

        CParticipant clPart;
        CPlace clPlace;

        public GameDays(SqlConnection cn, STInfoSeason st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = st;
            mode = md;
        }

        private void GameDays_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CGameDays(connect);
               
                
                this.WindowState = FormWindowState.Maximized;

                gpos = 0;

                init_data();

                

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        
        private void init_data()
        {
            string text;
            List<int> arr;
            bool fl;

            bool fll;
            int curmonth = 0;

            Color colorfont;

            try
            {
                dataGridViewGameDays.Rows.Clear();

                list = clWork.GetData(IS.idseason);

                if (list.Count > 0)
                {
                    dataGridViewGameDays.Rows.Add(list.Count);

                    curmonth = list[0].date.Month;
                    fll = false;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (curmonth != list[i].date.Month)
                        {
                            curmonth = list[i].date.Month;
                            fll = !fll;
                        }

                        if (fll) colorfont = Color.LightCyan;
                        else colorfont = Color.White;

                        dataGridViewGameDays.Rows[i].DefaultCellStyle.BackColor = colorfont;

                        dataGridViewGameDays.Rows[i].Cells[0].Value = list[i].nday;
                        dataGridViewGameDays.Rows[i].Cells[1].Value = list[i].date.ToLongDateString();

                        if (list[i].idplace > 0)
                        {
                            clPlace = new CPlace(connect, list[i].idplace);
                            dataGridViewGameDays.Rows[i].Cells[2].Value = clPlace.stPlace.name;
                        }
                        else dataGridViewGameDays.Rows[i].Cells[2].Value = "";

                        dataGridViewGameDays.Rows[i].Cells[3].Value = list[i].cntgames;

                        if (list[i].adminline != null)
                        {
                            arr = clWork.GetArrayData(list[i].adminline);

                            if (arr.Count > 0)
                            {
                                text = null;
                                fl = false;

                                foreach (int n in arr)
                                {
                                    clPart = new CParticipant(connect,n);

                                    if (fl == false)
                                    {
                                        text = string.Format("{0} {1}", clPart.stPart.family, 
                                            clPart.stPart.name);
                                        fl = true;
                                    }
                                    else text += ", " + string.Format("{0} {1}", clPart.stPart.family,
                                            clPart.stPart.name);
                                }

                                dataGridViewGameDays.Rows[i].Cells[4].Value = text;
                            }
                        }

                        if (list[i].washerline != null)
                        {
                            arr = clWork.GetArrayData(list[i].washerline);

                            if (arr.Count > 0)
                            {
                                text = null;
                                fl = false;

                                foreach (int n in arr)
                                {
                                    clPart = new CParticipant(connect, n);

                                    if (fl == false)
                                    {
                                        text = string.Format("{0} {1}", clPart.stPart.family,
                                            clPart.stPart.name);
                                        fl = true;
                                    }
                                    else text += ", " + string.Format("{0} {1}", clPart.stPart.family,
                                            clPart.stPart.name);
                                }

                                dataGridViewGameDays.Rows[i].Cells[5].Value = text;
                            }
                        }

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewGameDays.AllowUserToAddRows = false;

                    if (gpos <= 0)
                        dataGridViewGameDays.FirstDisplayedScrollingRowIndex = list.Count - 1;
                }
                else dataGridViewGameDays.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddGameDay_Click(object sender, EventArgs e)
        {
            add();
        }
        private void ToolStripMenuItemEditGameDay_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void ToolStripMenuItemDeleteGameDay_Click(object sender, EventArgs e)
        {
            del();
        }
        private void dataGridViewGameDays_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgGameDays wnd = new DlgGameDays(connect, IS, null);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewGameDays.Rows.Count > 0)
                    {
                        dataGridViewGameDays.Rows[gpos].Selected = true;
                        dataGridViewGameDays.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void edit()
        {
            try
            {
                STGameDays data = GetSelectionData();

                if (data.nday> 0)
                {
                    DlgGameDays wnd = new DlgGameDays(connect, IS, data);

                    DialogResult result = wnd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data();

                        if (gpos >= 0 && dataGridViewGameDays.Rows.Count > 0)
                        {
                            dataGridViewGameDays.Rows[gpos].Selected = true;
                            dataGridViewGameDays.FirstDisplayedScrollingRowIndex = gpos;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void del()
        {
            string text = null;
            try
            {
                STGameDays data = GetSelectionData();

                if (data.nday > 0)
                {
                    text = string.Format("Вы действиетльно желаете удалить игровой день {0}?", data.nday);

                    if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        == DialogResult.OK)
                    {
                        clWork.Delete(data);
                        init_data();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STGameDays GetSelectionData()
        {
            STGameDays ret = new STGameDays();
            CPlace clPlace;

            int n;
            int idplace = 0;

            try
            {
                foreach (DataGridViewRow item in dataGridViewGameDays.SelectedRows)
                {
                    if (item.Cells[0].Value != null)
                    {
                        n = int.Parse(item.Cells[0].Value.ToString());

                        if (item.Cells[2].Value.ToString() != null)
                        {

                            clPlace = new CPlace(connect, item.Cells[2].Value.ToString());
                            idplace =  clPlace.stPlace.id;
                        }


                        ret = clWork.GetRecord(IS.idseason, n, idplace);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}
