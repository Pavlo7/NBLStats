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
    public partial class FinalResult : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        bool g_f;

        CDivision clDiv;
        CEntryTeam clET;
        CFinalResult clWork;

        List<STEntryTeam> list_team;

        STDivision currdiv;

        STFinalResult flawour;
        int gpos;

        public FinalResult(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void FinalResult_Load(object sender, EventArgs e)
        {
            try
            {
                clDiv = new CDivision(connect);
                clET = new CEntryTeam(connect);
                clWork = new CFinalResult(connect);

                init_combo();

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            try
            {
                comboBoxDivision.Items.Clear();

                List<STDivision> lst = clDiv.GetListDivision(IS.idseason);

                foreach (STDivision item in lst)
                {
                    comboBoxDivision.Items.Add(item.name);
                }

                if (comboBoxDivision.Items.Count == 1)
                {
                    comboBoxDivision.Text = comboBoxDivision.Items[0].ToString();
                    comboBoxDivision.Enabled = false;

                    currdiv = lst[0];
                }
                else comboBoxDivision.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            CTeam clTeam;

            try
            {
                dataGridViewFinalResult.Rows.Clear();

                list_team = clET.GetTeamParticipant(IS.idseason, currdiv.id);

                if (list_team.Count > 0)
                {
                    g_f = true;

                    dataGridViewFinalResult.Rows.Add(list_team.Count);

                    for (int i = 0; i < list_team.Count; i++)
                    {
                        STFinalResult st = clWork.GetData(IS.idseason, currdiv.id, list_team[i].idteam);

                        clTeam = new CTeam(connect, list_team[i].idteam);

                        if (st.rang > 0)
                        {
                            dataGridViewFinalResult.Rows[i].Cells[0].Value = st.rang.ToString();
                        }
                        else dataGridViewFinalResult.Rows[i].Cells[0].Value = "";

                        dataGridViewFinalResult.Rows[i].Cells[1].Value = clTeam.stTeam.name;

                        if (flawour.idteam == list_team[i].idteam) gpos = i;
                    }

                    dataGridViewFinalResult.ClearSelection();

                    dataGridViewFinalResult.AllowUserToAddRows = false;
                }
                else dataGridViewFinalResult.AllowUserToAddRows = false;
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void dataGridViewFinalResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();        
        }

        private void edit()
        {
            try
            {
                STFinalResult data = GetSelectionData();

                DlgFinalResult wnd = new DlgFinalResult(connect, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewFinalResult.Rows.Count > 0)
                    {
                        dataGridViewFinalResult.Rows[gpos].Selected = true;
                        dataGridViewFinalResult.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STFinalResult GetSelectionData()
        {
            STFinalResult ret = new STFinalResult();

            ret.idseason = IS.idseason;
            ret.iddivision = currdiv.id;

            string n;

            CTeam clTeam;

            try
            {
                foreach (DataGridViewRow item in dataGridViewFinalResult.SelectedRows)
                {
                    n = item.Cells[1].Value.ToString();
                    clTeam = new CTeam(connect, n);

                    ret.idteam = clTeam.stTeam.id;
                    string s = item.Cells[0].Value.ToString();

                    if (s.Length > 0) ret.rang = int.Parse(s);
                    else ret.rang = 0;

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    text = comboBoxDivision.Text.Trim();
                    clDiv = new CDivision(connect, IS.idseason, text);

                    currdiv = clDiv.stDiv;

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}