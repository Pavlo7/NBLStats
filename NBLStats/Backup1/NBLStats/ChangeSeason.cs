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
    public partial class ChangeSeason : Form
    {
        SqlConnection connect;
     //   STInfoSeason IS;
        CInfoSeason cis;
        List<STInfoSeason> list;

        ushort mode;

        bool g_f;

        STInfoSeason flawour;
        int gpos;

        public ChangeSeason(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            //IS = data;
            connect = cn;

            mode = md;

            cis = new CInfoSeason(connect);
        }

        private void ChangeSeason_Load(object sender, EventArgs e)
        {
            try
            {
                gpos = 0;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {

            string text = null;

            try
            {
                g_f = false;

                dataGridViewSeason.Rows.Clear();

                list = cis.GetListSeason();

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewSeason.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].flag == 1)
                            dataGridViewSeason.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;

                        dataGridViewSeason.Rows[i].Cells[0].Value = list[i].idseason.ToString();

                        dataGridViewSeason.Rows[i].Cells[1].Value = list[i].nameseason;

                        dataGridViewSeason.Rows[i].Cells[2].Value = list[i].datebegin.ToLongDateString();

                        dataGridViewSeason.Rows[i].Cells[3].Value = list[i].dateend.ToLongDateString();

                        dataGridViewSeason.Rows[i].Cells[4].Value = list[i].cntdivision.ToString(); ;

                        dataGridViewSeason.Rows[i].Cells[5].Value = list[i].cntteam.ToString();

                        if (list[i].flag == 1) text = "текущий";
                        if (list[i].flag == 0)
                        {
                            if (list[i].flagend == 1) text = "завершен";
                            if (list[i].flagend == 0) text = "в процессе";
                        }

                        dataGridViewSeason.Rows[i].Cells[6].Value = text;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewSeason.AllowUserToAddRows = false;
                }
                else dataGridViewSeason.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemNewSeason_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditSeason_Click(object sender, EventArgs e)
        {
            edit();
        }

        private STInfoSeason GetSelectionData()
        {
            STInfoSeason ret = new STInfoSeason();

            int id;

            try
            {
                if (g_f)
                {
                    foreach (DataGridViewRow item in dataGridViewSeason.SelectedRows)
                    {
                        id = int.Parse(item.Cells[0].Value.ToString());

                        foreach (STInfoSeason s in list)
                            if (id == s.idseason) ret = s;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void add()
        {
            try
            {
                ParamSeason wnd = new ParamSeason(connect);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewSeason.Rows.Count > 0)
                    {
                        dataGridViewSeason.Rows[gpos].Selected = true;
                        dataGridViewSeason.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STInfoSeason data = GetSelectionData();

                ParamSeason wnd = new ParamSeason(connect, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewSeason.Rows.Count > 0)
                    {
                        dataGridViewSeason.Rows[gpos].Selected = true;
                        dataGridViewSeason.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemDeleteSeason_Click(object sender, EventArgs e)
        {
            string text;

            try
            {
                STInfoSeason data = GetSelectionData();

                CInfoSeason cis = new CInfoSeason(connect);

                text = string.Format("Вы действительно желаете удалить сезон: {0}?",data.nameseason);

                if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                    DialogResult.OK)
                {

                    cis.Delete(data);

                    init_data();

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void dataGridViewSeason_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        
    }
}