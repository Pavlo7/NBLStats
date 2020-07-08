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
    public partial class Players : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        List<STPlayer> list;
        CPlayer clPlayer;
        ushort mode;

        bool g_f;

        STPlayerParam view_param;
        
        public Players(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clPlayer = new CPlayer(connect);

            this.WindowState = FormWindowState.Maximized;
        }

        private void Players_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtonCurrent.Checked = true;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void init_data()
        {
            string text;
            DateTime dt;

            CCountry clCo = new CCountry(connect);

            try
            {
                g_f = false;

                dataGridViewPlayers.Rows.Clear();

                list = new List<STPlayer>();

                list = clPlayer.GetList(view_param);

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewPlayers.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewPlayers.Rows[i].Cells[0].Value = (i + 1).ToString();
                        
                        text = list[i].family + " " + list[i].name + " " + list[i].payname;
                        dataGridViewPlayers.Rows[i].Cells[1].Value = text;

                        if (list[i].datebirth != null)
                        {
                            dt = (DateTime)list[i].datebirth;
                            dataGridViewPlayers.Rows[i].Cells[2].Value = dt.ToShortDateString();
                        }

                        dataGridViewPlayers.Rows[i].Cells[3].Value = list[i].personalnum;

                        if (list[i].idcountry != null)
                        {
                            clCo = new CCountry(connect, (int)list[i].idcountry);
                            dataGridViewPlayers.Rows[i].Cells[4].Value = clCo.stCountry.shortname;
                        }

                        dataGridViewPlayers.Rows[i].Cells[5].Value = list[i].namefoto;

                        dataGridViewPlayers.Rows[i].Cells[6].Value = list[i].idplayer.ToString();

                        dataGridViewPlayers.Rows[i].Cells[7].Value = list[i].descript;
                    }

                    dataGridViewPlayers.AllowUserToAddRows = false;
                }
                else dataGridViewPlayers.AllowUserToAddRows = false;

                toolStripStatusLabel1.Text = string.Format("Число игроков: {0}", list.Count);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridViewPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgPlayers wnd = new DlgPlayers(connect, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewPlayers.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewPlayers.Rows[x].Selected = true;

                        dataGridViewPlayers.FirstDisplayedScrollingRowIndex = x;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void edit()
        {
            try
            {
                STPlayer data = GetSelectionData();

                DlgPlayers wnd = new DlgPlayers(connect, mode, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewPlayers.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewPlayers.Rows[x].Selected = true;

                        dataGridViewPlayers.FirstDisplayedScrollingRowIndex = x;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void del()
        {
            try
            {
                STPlayer data = GetSelectionData();

                string text = string.Format("Вы действительно желаете удалить игрока: {0} {1} {2}",
                    data.family, data.name, data.payname);

                if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (clPlayer.Delete(data))
                    {
                        init_data();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private STPlayer GetSelectionData()
        {
            STPlayer ret = new STPlayer();

            int id;

            try
            {
                if (g_f)
                {
                    foreach (DataGridViewRow item in dataGridViewPlayers.SelectedRows)
                    {
                        id = int.Parse(item.Cells[6].Value.ToString());

                        foreach (STPlayer s in list)
                            if (id == s.idplayer) ret = s;
                    }
                }
            }
            catch (Exception ex)  { MessageBox.Show(ex.Message); }

            return ret;
        }

        private int get_num_row(int id)
        {
            int ret = 0;

            for (int i= 0;i<list.Count;i++)
            {
                if (list[i].idplayer == id) ret = i;
            }

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

        private void ToolStripMenuItemExportExcel_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            view_param.idseason = null;
            init_data();
        }

        private void radioButtonCurrent_CheckedChanged(object sender, EventArgs e)
        {
            view_param.idseason = IS.idseason;
            init_data();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = tabControl1.SelectedTab.Text;
            if (s.Equals("."))
                view_param.ch = null;
            else
                view_param.ch = tabControl1.SelectedTab.Text;
            
            init_data();
        }

        private void ToolStripMenuItemHistory_Click(object sender, EventArgs e)
        {
            try
            {
                STPlayer data = GetSelectionData();

                HistoryPlayer wnd = new HistoryPlayer(connect, mode, data);

                DialogResult result = wnd.ShowDialog();
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}