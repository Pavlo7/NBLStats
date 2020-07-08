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
    public partial class VoteASG : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        CVoteAllStarsGame clWork;

        STVoteASG flawour;
        int gpos;

        bool g_f;

        STViewVoteASG v_param;
        List<STVoteASG> full_list;

        public VoteASG(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void VoteASG_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CVoteAllStarsGame(connect);

                this.WindowState = FormWindowState.Maximized;

                radioButtonAll.Checked = true;

                groupBoxData.Enabled = false;

                radioButtonSortName.Checked = true;

                init_data(v_param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data(STViewVoteASG param)
        {
            g_f = false;
            gpos = -1;

         //   CPlayer clPlayer;

            string text;

            try
            {
                dataGridViewVoteASG.Rows.Clear();

                full_list = clWork.GetList(IS.idseason, param);

                bool fl = false;

                if (full_list.Count > 0)
                {
                    g_f = true;

                    dataGridViewVoteASG.Rows.Add(full_list.Count);

                    for (int i = 0; i < full_list.Count; i++)
                    {
                        dataGridViewVoteASG.Rows[i].Cells[0].Value = full_list[i].name;
                        dataGridViewVoteASG.Rows[i].Cells[1].Value = full_list[i].email;
                        dataGridViewVoteASG.Rows[i].Cells[2].Value = full_list[i].ip;

                        dataGridViewVoteASG.Rows[i].Cells[3].Value = full_list[i].ed.ToString();

                        dataGridViewVoteASG.Rows[i].Cells[4].Value = full_list[i].data;

                        if (flawour.Equals(full_list[i])) gpos = i;
                    }

                    dataGridViewVoteASG.AllowUserToAddRows = false;
                }
                else dataGridViewVoteASG.AllowUserToAddRows = false;

                toolStripStatusLabel1.Text = string.Format("Количество записей: {0}", full_list.Count);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void add()
        {
            try
            {
                DlgVoteASG wnd = new DlgVoteASG(connect, IS.idseason);

                if (wnd.ShowDialog() == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data(v_param);

                    if (gpos >= 0 && dataGridViewVoteASG.Rows.Count > 0)
                    {
                        dataGridViewVoteASG.Rows[gpos].Selected = true;
                        dataGridViewVoteASG.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STVoteASG? data = GetSelectionData();

                if (data != null)
                {

                    DlgVoteASG wnd = new DlgVoteASG(connect, (STVoteASG)data);

                    if (wnd.ShowDialog() == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data(v_param);

                        if (gpos >= 0 && dataGridViewVoteASG.Rows.Count > 0)
                        {
                            dataGridViewVoteASG.Rows[gpos].Selected = true;
                            dataGridViewVoteASG.FirstDisplayedScrollingRowIndex = gpos;
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
                STVoteASG? data = GetSelectionData();
                if (data != null)
                {
                    if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        clWork.Delete((STVoteASG)data);
                        init_data(v_param);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STVoteASG? GetSelectionData()
        {
            STVoteASG? ret = null;

            string email = null;
            DateTime ed = new DateTime();

            try
            {
                foreach (DataGridViewRow item in dataGridViewVoteASG.SelectedRows)
                {
                    email = item.Cells[1].Value.ToString();

                    ed = DateTime.Parse(item.Cells[3].Value.ToString());

                    ret = clWork.GetRecord(IS.idseason, email, ed);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void ToolStripMenuItemAddVote_Click(object sender, EventArgs e)
        {
            add();
        }
        private void ToolStripMenuItemEditVote_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void ToolStripMenuItemDelVote_Click(object sender, EventArgs e)
        {
            del();
        }
        private void ToolStripMenuItemResult_Click(object sender, EventArgs e)
        {
            try
            {
                ReportExcelVoteASG rep = new ReportExcelVoteASG(connect, full_list);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void dataGridViewVoteASG_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true)
            {
                groupBoxData.Enabled = false;

                checkBoxEmail.CheckState = CheckState.Unchecked;
                checkBoxIP.CheckState = CheckState.Unchecked;

                textBoxEmail.Text = null;
                textBoxIP.Text = null;
            }
        }
        private void radioButtonUs_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUs.Checked == true)
            {
                groupBoxData.Enabled = true;

                textBoxIP.Enabled = false;
                textBoxEmail.Enabled = false;
            }
        }
        private void checkBoxEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEmail.CheckState == CheckState.Checked)
            {
                textBoxEmail.Enabled = true;
                textBoxEmail.Focus();
            }
            else
            {
                textBoxEmail.Enabled = false;
                textBoxEmail.Text = null;
            }
        }
        private void checkBoxIP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIP.CheckState == CheckState.Checked)
            {
                textBoxIP.Enabled = true;
                textBoxIP.Focus();
            }
            else
            {
                textBoxIP.Enabled = false;
                textBoxIP.Text = null;
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            try
            {
                v_param = new STViewVoteASG();

                v_param.all = true;
                v_param.cntemail = null;
                v_param.cntip = null;
                v_param.order = null;

                if (radioButtonAll.Checked == true) v_param.all = true;

                if (radioButtonUs.Checked == true)
                {
                    v_param.all = false;

                    if (checkBoxEmail.CheckState == CheckState.Checked)
                    {
                        if (textBoxEmail.Text.Length > 0)
                            v_param.cntemail = int.Parse(textBoxEmail.Text.Trim());
                    }

                    if (checkBoxIP.CheckState == CheckState.Checked)
                    {
                        if (textBoxIP.Text.Length > 0)
                            v_param.cntip = int.Parse(textBoxIP.Text.Trim());
                    }

                    if (checkBoxAll.CheckState == CheckState.Checked) v_param.full = true;
                }

                if (radioButtonSortName.Checked == true) v_param.order = "Name";
                if (radioButtonSortEmail.Checked == true) v_param.order = "Email";
                if (radioButtonSortIP.Checked == true) v_param.order = "IP";
                if (radioButtonSortPlayer.Checked == true) v_param.order = "IdPlayer";

                init_data(v_param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
