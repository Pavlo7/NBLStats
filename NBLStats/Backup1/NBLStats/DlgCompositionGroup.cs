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
    public partial class DlgCompositionGroup : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        ushort mode;
        string caption;

        STGroup stGroup;

        CCompositionGroup clCGroup;
        List<STCompositionGroup> list;

        bool g_f;

        CTeam clTeam;

        public DlgCompositionGroup(SqlConnection cn, STInfoSeason inf, ushort md, STGroup st)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            stGroup = st;
        }

        private void DlgCompositionGroup_Load(object sender, EventArgs e)
        {
            try
            {
                caption = string.Format("Состав группы \"{0}\"", stGroup.namegroup);

                this.Text = caption;

                init_combo();
                
                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            CTeam clTeam;

            try
            {
                dataGridViewCGroups.Rows.Clear();

                clCGroup = new CCompositionGroup(connect, IS.idseason, stGroup.iddivision, stGroup.idgroup);
                list = clCGroup.lstCompositionGroup;

                dataGridViewCGroups.Rows.Add(stGroup.cntteam);

                for (int i = 0; i < stGroup.cntteam; i++)
                {
                    dataGridViewCGroups.Rows[i].Cells[0].Value = (i+1).ToString();
                }

                for (int j =0; j< list.Count; j++)
                {
                    clTeam = new CTeam(connect,list[j].idteam);
                    dataGridViewCGroups.Rows[j].Cells[1].Value = clTeam.stTeam.name;
                }

                dataGridViewCGroups.AllowUserToAddRows = false;

                if (list.Count < stGroup.cntteam)
                {
                    comboBoxTeam.Enabled = true;
                    buttonAdd.Enabled = true;
                }
                else
                {
                    comboBoxTeam.Text = null;
                    comboBoxTeam.Enabled = false;
                    buttonAdd.Enabled = false;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            
            try
            {
                comboBoxTeam.Items.Clear();

                clTeam = new CTeam(connect);
                List<STTeam> lst = clTeam.GetListTeam(IS.idseason);

                foreach (STTeam item in lst)
                {
                    comboBoxTeam.Items.Add(item.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name;

            STCompositionGroup st;

            try
            {
                if (comboBoxTeam.Text.Length > 0)
                {
                    name = comboBoxTeam.Text.Trim();

                    clTeam = new CTeam(connect, name);

                    st.idseason = stGroup.idseason;
                    st.iddivision = stGroup.iddivision;
                    st.idgroup = stGroup.idgroup;
                    st.idteam = clTeam.stTeam.id;

                    clCGroup.Insert(st);

                    init_data();

                    comboBoxTeam.Text = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            string name;

            STCompositionGroup st;

            try
            {
                foreach (DataGridViewRow item in dataGridViewCGroups.SelectedRows)
                {
                    name = item.Cells[1].Value.ToString();

                    clTeam = new CTeam(connect,name);

                    st.idseason = stGroup.idseason;
                    st.iddivision = stGroup.iddivision;
                    st.idgroup = stGroup.idgroup;
                    st.idteam = clTeam.stTeam.id;

                    clCGroup.Delete(st);

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}