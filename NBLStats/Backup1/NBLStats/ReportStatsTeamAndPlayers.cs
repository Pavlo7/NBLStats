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
    public partial class ReportStatsTeamAndPlayers : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CTeam clTeam;
        CDivision clDiv;
        CGroup clGroup;
        CEntryTeam clET;

        List<STTeam> param;
        List<STEntryTeam> data;

        bool prAll;             // учитывать игры других этапов

        public ReportStatsTeamAndPlayers(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();
            
            connect = cn;
            IS = inf;
        }

        private void ReportStatsTeamAndPlayers_Load(object sender, EventArgs e)
        {
            try
            {
                clTeam = new CTeam(connect);
                clDiv = new CDivision(connect);
                clGroup = new CGroup(connect);
                clET = new CEntryTeam(connect);

                prAll = false;

                init_combo_division();

                radioButtonUsTeam.Checked = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                param = read_param();

                create();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            DialogResult = DialogResult.OK;
        }

        private List<STTeam> read_param()
        {
            List<STTeam> ret = new List<STTeam>();
            
            try
            {
                for (int i = 0; i < checkedListBoxTeam.Items.Count; i++)
                {
                    if (checkedListBoxTeam.GetItemChecked(i))
                    {
                        clTeam = new CTeam(connect, checkedListBoxTeam.Items[i].ToString());
                        ret.Add(clTeam.stTeam);
                    }
                }

                if (checkBoxAll.Checked == true)
                    prAll = true;
                else prAll = false;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private bool create()
        {
            bool ret = true;

            try
            {
                ReportExcelStatsTeam cl = new ReportExcelStatsTeam(connect, IS, param, prAll);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private void init_list_team(List<STEntryTeam> lst)
        {
            bool bp;

            try
            {
                checkedListBoxTeam.Items.Clear();

                List<STEntryTeam> list_all = clET.GetTeamParticipant(IS.idseason);

                bp = false;

                foreach (STEntryTeam eteam in list_all)
                {
                    foreach (STEntryTeam team in lst)
                    {
                        if (eteam.idteam == team.idteam) bp = true;
                    }

                    clTeam = new CTeam(connect, eteam.idteam);
                    checkedListBoxTeam.Items.Add(clTeam.stTeam.name, bp);

                    bp = false;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_division()
        {
            try
            {
                comboBoxDivision.Items.Clear();

                List<STDivision> lst = clDiv.GetListDivision(IS.idseason);

                foreach (STDivision item in lst)
                {
                    comboBoxDivision.Items.Add(item.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_combo_group(int id)
        {
            try
            {
                comboBoxGroup.Items.Clear();

                List<STGroup> lst = clGroup.GetListGroup(IS.idseason, id);

                foreach (STGroup item in lst)
                {
                    comboBoxGroup.Items.Add(item.namegroup);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                    int id = clDiv.stDiv.id;

                    init_combo_group(id);

                    data = clET.GetTeamParticipant(IS.idseason, id);

                    init_list_team(data);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonAllTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAllTeam.Checked == true)
            {
                groupBoxUs.Enabled = false;

                comboBoxDivision.Text = null;
                comboBoxGroup.Text = null;

                data = clET.GetTeamParticipant(IS.idseason);

                init_list_team(data);
            }
        }

        private void radioButtonUsTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUsTeam.Checked == true)
            {
                groupBoxUs.Enabled = true;
            }
        }

        private void radioButtonHandTeam_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHandTeam.Checked == true)
            {
                groupBoxUs.Enabled = false;

                comboBoxDivision.Text = null;
                comboBoxGroup.Text = null;

                data = new List<STEntryTeam>();

                init_list_team(data);
            }
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDivision.Text.Length > 0 && comboBoxGroup.Text.Length > 0)
                {
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                    int iddiv = clDiv.stDiv.id;

                    clGroup = new CGroup(connect, IS.idseason, iddiv, comboBoxGroup.Text.Trim());
                    int idgroup = clGroup.stGroup.idgroup;

                    data = clET.GetTeamParticipant(IS.idseason, iddiv, idgroup);

                    init_list_team(data);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
