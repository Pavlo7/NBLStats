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
    public partial class Team : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        CTeam clTeam;
        List<STTeam> list;
        ushort mode;

        bool f_g;
        int ps;

        public Team(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clTeam = new CTeam(connect);

            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Team_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtonThis.Checked = true;
                ps = (int)IS.idseason;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
          
            CCity city = new CCity(connect);

            string text = null;

            try
            {
                f_g = false;

                dataGridViewTeam.Rows.Clear();

                list = clTeam.GetListTeam(ps);

                if (list.Count > 0)
                {
                    f_g = true;

                    dataGridViewTeam.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewTeam.Rows[i].Cells[0].Value = (i + 1).ToString();

                        if (list[i].idprev != null)
                        {
                            clTeam = new CTeam(connect , (int)list[i].idprev);

                            text = string.Format("{0} (ex - {1})", list[i].name, clTeam.stTeam.name);

                            dataGridViewTeam.Rows[i].Cells[1].Value = text;

                        }
                        else  dataGridViewTeam.Rows[i].Cells[1].Value = list[i].name;

                        if (list[i].latinname != null)
                            dataGridViewTeam.Rows[i].Cells[2].Value = list[i].latinname;

                        city = new CCity(connect, list[i].idcity);

                        dataGridViewTeam.Rows[i].Cells[3].Value = city.stCity.name;

                        dataGridViewTeam.Rows[i].Cells[4].Value = city.stFullCity.nameregion;

                        dataGridViewTeam.Rows[i].Cells[5].Value = city.stFullCity.namecountry;

                        dataGridViewTeam.Rows[i].Cells[6].Value = list[i].id.ToString();

                        dataGridViewTeam.Rows[i].Cells[7].Value = list[i].idgroupteam.ToString();
                    }

                    dataGridViewTeam.AllowUserToAddRows = false;
                }
                else dataGridViewTeam.AllowUserToAddRows = false;

                toolStripStatusLabel1.Text = string.Format("Число команд: {0}", list.Count);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void add()
        {
            try
            {
                DlgTeam wnd = new DlgTeam(connect, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewTeam.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewTeam.Rows[x].Selected = true;

                        dataGridViewTeam.FirstDisplayedScrollingRowIndex = x;
                    }
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STTeam data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить данного участника?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clTeam.Delete(data);
                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STTeam data = GetSelectionData();

                DlgTeam wnd = new DlgTeam(connect, data, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    init_data();

                    if (dataGridViewTeam.Rows.Count > 0)
                    {
                        int x = get_num_row(wnd.RetId());
                        dataGridViewTeam.Rows[x].Selected = true;

                        dataGridViewTeam.FirstDisplayedScrollingRowIndex = x;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STTeam GetSelectionData()
        {
            STTeam ret = new STTeam();

            int id;

            try
            {

                if (f_g)
                {
                    foreach (DataGridViewRow item in dataGridViewTeam.SelectedRows)
                    {
                        id = int.Parse(item.Cells[6].Value.ToString());

                        foreach (STTeam s in list)
                            if (id == s.id) ret = s;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private int get_num_row(int id)
        {
            int ret = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == id) ret = i;
            }

            return ret;
        }

        private void ToolStripMenuItemAddTeam_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditTeam_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDeleteTeam_Click(object sender, EventArgs e)
        {
            del();
        }

        private void listViewTeam_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void dataGridViewTeam_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true) ps = 0;

            init_data();
        }

        private void radioButtonThis_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonThis.Checked == true) ps = (int)IS.idseason;

            init_data();
        }

        

        
    }
}