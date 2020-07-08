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
    public partial class VotePCA : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        CVotePCA clWork;

        CDivision clDiv;

        STVotePCA flawour;
        int gpos;

        bool g_f;

        STViewVotePCA v_param;
        List<STVotePCA> full_list;

        public VotePCA(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void VotePCA_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CVotePCA(connect);

                this.WindowState = FormWindowState.Maximized;

                init_combo_div();

                radioButtonAll.Checked = true;

                groupBoxData.Enabled = false;

                radioButtonSortName.Checked = true;

                init_data(v_param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_div()
        {
            try
            {
                clDiv = new CDivision(connect);
                List<STDivision> lst = clDiv.GetListDivision(IS.idseason);

                if (lst.Count > 0)
                {
                    comboBoxDivision.Items.Clear();

                    foreach (STDivision item in lst)
                        comboBoxDivision.Items.Add(item.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data(STViewVotePCA param)
        {
            g_f = false;
            gpos = -1;

            CPlayer clPlayer;
          
            string text;

            try
            {
                dataGridViewVotePCA.Rows.Clear();

                full_list = clWork.GetList(IS.idseason, param);
            
                bool fl = false;

                if (full_list.Count > 0)
                {
                    g_f = true;

                    dataGridViewVotePCA.Rows.Add(full_list.Count);

                    for (int i = 0; i < full_list.Count; i++)
                    {
                        dataGridViewVotePCA.Rows[i].Cells[0].Value = full_list[i].name;
                        dataGridViewVotePCA.Rows[i].Cells[1].Value = full_list[i].email;
                        dataGridViewVotePCA.Rows[i].Cells[2].Value = full_list[i].ip;

                        CDivision clDiv = new CDivision(connect, IS.idseason, full_list[i].iddivision);
                        dataGridViewVotePCA.Rows[i].Cells[3].Value = clDiv.stDiv.name;

                        clPlayer = new CPlayer(connect, full_list[i].idplayer);
                        text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                            clPlayer.stPlayer.payname);
                        dataGridViewVotePCA.Rows[i].Cells[4].Value = text;

                        dataGridViewVotePCA.Rows[i].Cells[5].Value = full_list[i].ed.ToString();
                        
                        if (flawour.Equals(full_list[i])) gpos = i;
                    }

                    dataGridViewVotePCA.AllowUserToAddRows = false;
                }
                else dataGridViewVotePCA.AllowUserToAddRows = false;

                toolStripStatusLabel1.Text = string.Format("Количество записей: {0}", full_list.Count);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void add()
        {
            try
            {
                DlgVotePCA wnd = new DlgVotePCA(connect, IS.idseason);

                if (wnd.ShowDialog() == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data(v_param);

                    if (gpos >= 0 && dataGridViewVotePCA.Rows.Count > 0)
                    {
                        dataGridViewVotePCA.Rows[gpos].Selected = true;
                        dataGridViewVotePCA.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STVotePCA? data = GetSelectionData();

                if (data != null)
                {

                    DlgVotePCA wnd = new DlgVotePCA(connect, (STVotePCA)data);

                    if (wnd.ShowDialog() == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data(v_param);

                        if (gpos >= 0 && dataGridViewVotePCA.Rows.Count > 0)
                        {
                            dataGridViewVotePCA.Rows[gpos].Selected = true;
                            dataGridViewVotePCA.FirstDisplayedScrollingRowIndex = gpos;
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
                STVotePCA? data = GetSelectionData();
                if (data != null)
                {
                    if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        clWork.Delete((STVotePCA)data);
                        init_data(v_param);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STVotePCA? GetSelectionData()
        {
            STVotePCA? ret = null;

            int iddivision = 0;
            string email = null;
            DateTime ed = new DateTime();

            try
            {
                foreach (DataGridViewRow item in dataGridViewVotePCA.SelectedRows)
                {
                    email = item.Cells[1].Value.ToString();

                    CDivision clDiv = new CDivision(connect, IS.idseason, item.Cells[3].Value.ToString());
                    iddivision = clDiv.stDiv.id;

                    ed = DateTime.Parse(item.Cells[5].Value.ToString());

                    ret = clWork.GetRecord(IS.idseason, iddivision, email, ed);
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
                ReportExcelVotePCA rep = new ReportExcelVotePCA(connect, full_list);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void dataGridViewVotePCA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            try
            {
                v_param = new STViewVotePCA();

                v_param.all = true;
                v_param.cntemail = null;
                v_param.cntip = null;
                v_param.iddivision = null;
                v_param.order = null;

                if (radioButtonAll.Checked == true) v_param.all = true;

                if (radioButtonUs.Checked == true)
                {
                    v_param.all = false;

                    if (checkBoxDivision.CheckState == CheckState.Checked)
                    {

                        if (comboBoxDivision.Text.Length > 0)
                        {
                            CDivision clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                            v_param.iddivision = clDiv.stDiv.id;
                        }
                    }

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
                }

                if (radioButtonSortName.Checked == true) v_param.order = "Name";
                if (radioButtonSortEmail.Checked == true) v_param.order = "Email";
                if (radioButtonSortIP.Checked == true) v_param.order = "IP";
                if (radioButtonSortPlayer.Checked == true) v_param.order = "IdPlayer";
               
                init_data(v_param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked == true)
            {
                groupBoxData.Enabled = false;

                checkBoxDivision.CheckState = CheckState.Unchecked;
                checkBoxEmail.CheckState = CheckState.Unchecked;
                checkBoxIP.CheckState = CheckState.Unchecked;

                textBoxEmail.Text = null;
                textBoxIP.Text = null;
                comboBoxDivision.Text = null;
            }
        }

        private void radioButtonUs_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUs.Checked == true)
            {
                groupBoxData.Enabled = true;

                comboBoxDivision.Enabled = false;
                textBoxIP.Enabled = false;
                textBoxEmail.Enabled = false;
            }
        }

        private void checkBoxDivision_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDivision.CheckState == CheckState.Checked)
            {
                comboBoxDivision.Enabled = true;
                comboBoxDivision.Focus();
            }
            else
            {
                comboBoxDivision.Enabled = false;
                comboBoxDivision.Text = null;
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
    }
}