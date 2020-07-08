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
    public partial class Draft : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CDraft clWork;
        List<STDraftPlayer> full_list;

        bool g_f;

        STDraftPlayer flawour;
        int gpos;

        public Draft(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void Draft_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CDraft(connect);
                
                this.WindowState = FormWindowState.Maximized;

                dataGridViewDraft.AutoResizeColumns();
            
                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            g_f = false;
            gpos = -1;

            string text;

            try
            {
                full_list = clWork.GetList();

                dataGridViewDraft.Rows.Clear();

                string amplua = "";

                int npp = 1;

                if (full_list.Count > 0)
                {
                    g_f = true;

                    dataGridViewDraft.Rows.Add(full_list.Count);

                    for (int i = 0; i < full_list.Count; i++)
                    {
                        dataGridViewDraft.Rows[i].Cells[0].Value = npp.ToString();

                        text = string.Format("{0} {1} {2}", full_list[i].family, full_list[i].name,
                            full_list[i].payname);
                        dataGridViewDraft.Rows[i].Cells[1].Value = text;

                        amplua = "";
                        if (full_list[i].amplua == 1) amplua = "защитник";
                        if (full_list[i].amplua == 2) amplua = "форвард";
                        if (full_list[i].amplua == 3) amplua = "центровой";
                        if (full_list[i].amplua == 4) amplua = "защитник, форвард";
                        if (full_list[i].amplua == 5) amplua = "защитник, центровой";
                        if (full_list[i].amplua == 6) amplua = "форвард, центровой";
                        if (full_list[i].amplua == 7) amplua = "защитник, форвард, центровой";
                        dataGridViewDraft.Rows[i].Cells[2].Value = amplua;

                        dataGridViewDraft.Rows[i].Cells[3].Value = full_list[i].growing.ToString();

                        dataGridViewDraft.Rows[i].Cells[4].Value = full_list[i].weight.ToString();

                        dataGridViewDraft.Rows[i].Cells[5].Value = full_list[i].namecounrty;

                        dataGridViewDraft.Rows[i].Cells[6].Value = full_list[i].dtin.ToString("yyyy-MM-dd");

                        if (full_list[i].dtout != null)
                        {
                            DateTime dt = (DateTime)full_list[i].dtout;
                            dataGridViewDraft.Rows[i].Cells[7].Value = dt.ToString("yyyy-MM-dd");
                        }

                        dataGridViewDraft.Rows[i].Cells[8].Value = full_list[i].namelastteam;
                        dataGridViewDraft.Rows[i].Cells[9].Value = full_list[i].namenextteam;

                        dataGridViewDraft.Rows[i].Cells[10].Value = full_list[i].idplayer.ToString();

                        if (flawour.idplayer == full_list[i].idplayer) gpos = i;

                        npp++;
                    }

                    dataGridViewDraft.AllowUserToAddRows = false;
                }
                else dataGridViewDraft.AllowUserToAddRows = false;

                dataGridViewDraft.AutoResizeColumns();

                toolStripStatusLabel1.Text = string.Format("Количество записей: {0}", full_list.Count);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddPlayer_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditPlayer_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemdelPlayer_Click(object sender, EventArgs e)
        {
            del();
        }

        private void add()
        {
            try
            {
                DlgDraft wnd = new DlgDraft(connect, IS, null);

                if (wnd.ShowDialog() == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewDraft.Rows.Count > 0)
                    {
                        dataGridViewDraft.Rows[gpos].Selected = true;
                        dataGridViewDraft.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STDraftPlayer data = GetSelectionData();

                if (data.idplayer > 0)
                {

                    DlgDraft wnd = new DlgDraft(connect, IS, data);

                    if (wnd.ShowDialog() == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data();

                        if (gpos >= 0 && dataGridViewDraft.Rows.Count > 0)
                        {
                            dataGridViewDraft.Rows[gpos].Selected = true;
                            dataGridViewDraft.FirstDisplayedScrollingRowIndex = gpos;
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
                STDraftPlayer data = GetSelectionData();
                if (data.idplayer > 0)
                {
                    if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        clWork.Delete(data.idplayer, data.dtin);
                        init_data();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STDraftPlayer GetSelectionData()
        {
            STDraftPlayer ret = new STDraftPlayer();

            int idplayer;
            DateTime datein;
            
            try
            {
                foreach (DataGridViewRow item in dataGridViewDraft.SelectedRows)
                {
                    idplayer = int.Parse(item.Cells[10].Value.ToString().Trim());
                    datein = DateTime.Parse(item.Cells[6].Value.ToString().Trim());

                    ret = clWork.GetRecord(idplayer, datein);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void dataGridViewDraft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemTransferNews_Click(object sender, EventArgs e)
        {
            try
            {
                DlgTransferNews dlg = new DlgTransferNews(connect, IS, 2);
                dlg.ShowDialog();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
