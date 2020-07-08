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
    public partial class Group : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        int idCurrDiv;
        int idCurrGroup;
        List<STCompositionGroup> curCompositionGroup;
        List<STGroup> list;

        CGroup clGroup;
        CDivision clDivision;
        CScheme clScheme;
        CCompositionGroup clCompgroup;

        bool g_f;

        STGroup flawour;
        int gpos;

        public Group(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void Group_Load(object sender, EventArgs e)
        {   
            try
            {
                clGroup = new CGroup(connect);
               
                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            try
            {
                g_f = false;

                dataGridViewGroups.Rows.Clear();

                list = clGroup.GetListGroup(IS.idseason);

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewGroups.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {

                        dataGridViewGroups.Rows[i].Cells[0].Value = (i+1).ToString();

                        dataGridViewGroups.Rows[i].Cells[1].Value = list[i].namegroup;

                        clDivision = new CDivision(connect,IS.idseason,list[i].iddivision);
                        dataGridViewGroups.Rows[i].Cells[2].Value = clDivision.stDiv.name;

                        clScheme = new CScheme(connect, IS.idseason,list[i].iddivision, list[i].idstage);
                        dataGridViewGroups.Rows[i].Cells[3].Value = clScheme.stScheme.namestage;

                        dataGridViewGroups.Rows[i].Cells[4].Value = list[i].cntteam.ToString();

                        dataGridViewGroups.Rows[i].Cells[5].Value = list[i].cntteamnext.ToString();

                        clCompgroup = new CCompositionGroup(connect, IS.idseason, list[i].iddivision, 
                            list[i].idgroup);

                        dataGridViewGroups.Rows[i].Cells[6].Value = 
                            clCompgroup.lstCompositionGroup.Count.ToString();

                        dataGridViewGroups.Rows[i].Cells[7].Value = list[i].idgroup.ToString();

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewGroups.AllowUserToAddRows = false;
                }
                else dataGridViewGroups.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemAddGroup_Click(object sender, EventArgs e)
        {
            add();
        }
        private void ToolStripMenuItemEditGroup_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void ToolStripMenuItemDelGroup_Click(object sender, EventArgs e)
        {
            del();
        }

        private void dataGridViewGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgGroup wnd = new DlgGroup(connect, IS, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewGroups.Rows.Count > 0)
                    {
                        dataGridViewGroups.Rows[gpos].Selected = true;
                        dataGridViewGroups.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STGroup data = GetSelectionData();

                DlgGroup wnd = new DlgGroup(connect, IS, data, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewGroups.Rows.Count > 0)
                    {
                        dataGridViewGroups.Rows[gpos].Selected = true;
                        dataGridViewGroups.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STGroup data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    CGroup clGroup = new CGroup(connect);
                    clGroup.Delete(data);
                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STGroup GetSelectionData()
        {
            STGroup ret = new STGroup();

            string text;
            int id = 0;

            int iddiv = 0;
            int idstage = 0;

            try
            {
                if (g_f)
                {
                    foreach (DataGridViewRow item in dataGridViewGroups.SelectedRows)
                    {
                        id = int.Parse(item.Cells[7].Value.ToString().Trim());
                       
                        foreach (STGroup s in list)
                            if (s.idgroup == id)  ret = s;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void ToolStripMenuItemComGroup_Click(object sender, EventArgs e)
        {
            try
            {
                STGroup data = GetSelectionData();

                DlgCompositionGroup wnd = new DlgCompositionGroup(connect, IS, mode, data);

                DialogResult result = wnd.ShowDialog();

                flawour = data;

                init_data();

                if (gpos >= 0 && dataGridViewGroups.Rows.Count > 0)
                {
                    dataGridViewGroups.Rows[gpos].Selected = true;
                    dataGridViewGroups.FirstDisplayedScrollingRowIndex = gpos;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

    }
}
/*
        

        

        
        
        private void ToolStripMenuItemComGroup_Click(object sender, EventArgs e)
        {
            groupBoxComGroup.Enabled = true;

            STGroup data = GetSelectionData();

            idCurrGroup = data.idgroup;

            init_list_team();
            init_list_comgroup(idCurrGroup);
        }
       
       

       

        

        private void comboBoxNameGDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBoxNameGDivision.Text.Trim();

            CDivision div = new CDivision(connect, (int)IS.idseason, s);

            init_list_group(div.stDiv.id);

            idCurrDiv = div.stDiv.id;

            clear_composition();
        }

       
     private void init_list_comgroup(int idgroup)
        {
            CCompositionGroup comp = new CCompositionGroup(connect, (int)IS.idseason, idCurrDiv, idCurrGroup);
            curCompositionGroup = comp.lstCompositionGroup;

            listViewCompositionGroup.Items.Clear();

            ListViewItem item;

            int npp = 1;

            for (int i = 0; i < curCompositionGroup.Count; i++)
            {
                item = new ListViewItem(npp.ToString());

                CTeam team = new CTeam(connect, curCompositionGroup[i].idteam);
                item.SubItems.Add(team.stTeam.name);
                listViewCompositionGroup.Items.Add(item);

                npp++;
            }
        }

       

        private void buttonIn_Click(object sender, EventArgs e)
        {
            int idteam = 0;
            string nameteam = "";

            CTeam team;
            CCompositionGroup cgroup;

            bool fl = true;

            try
            {
                foreach (ListViewItem item in listViewTeam.SelectedItems)
                {
                    nameteam = item.SubItems[0].Text;
                    team = new CTeam(connect,nameteam);
                    idteam = team.stTeam.id;

                    STCompositionGroup stins;

                    cgroup = new CCompositionGroup(connect, (int)IS.idseason, idCurrDiv, idCurrGroup);

                    foreach (STCompositionGroup st in curCompositionGroup)
                    {
                        if (st.idteam == idteam) fl = false;
                    }

                    if (fl == false)
                        MessageBox.Show("Команда уже в группе!", "Внимание!", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    else
                    {
                        stins = new STCompositionGroup();

                        stins.idseason = (int)IS.idseason;
                        stins.iddivision = idCurrDiv;
                        stins.idgroup = idCurrGroup;
                        stins.idteam = idteam;

                        if (!cgroup.Insert(stins))
                        {
                            MessageBox.Show("Ошибка вставки записи", "Внимание!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        else
                        {
                            init_list_comgroup(idCurrGroup);
                        }
                    }

                }
            }
            catch (Exception ex) {MessageBox.Show(ex.Message.ToString()); }
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            int idteam = 0;
            string nameteam = "";

            CTeam team;
            CCompositionGroup cgroup;

            try
            {
                foreach (ListViewItem item in listViewCompositionGroup.SelectedItems)
                {
                    nameteam = item.SubItems[1].Text;
                    team = new CTeam(connect, nameteam);
                    idteam = team.stTeam.id;

                    STCompositionGroup stins;

                    cgroup = new CCompositionGroup(connect, (int)IS.idseason, idCurrDiv, idCurrGroup);

                    stins = new STCompositionGroup();

                    stins.idseason = (int)IS.idseason;
                    stins.iddivision = idCurrDiv;
                    stins.idgroup = idCurrGroup;
                    stins.idteam = idteam;

                    if (!cgroup.Delete(stins))
                    {
                        MessageBox.Show("Ошибка удаления записи", "Внимание!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        init_list_comgroup(idCurrGroup);
                    }
                }
            }
            catch (Exception ex) {MessageBox.Show(ex.Message.ToString()); }
        }
    }
}*/