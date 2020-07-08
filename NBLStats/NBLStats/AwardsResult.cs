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
    public partial class AwardsResult : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        bool g_f;

        CDivision clDiv;
        CTeam clTeam;
        CAward clAward;
        CPlayer clPlayer;
        CEntryPlayers clEP;

        CAwarsResult clWork;
        List<STAwardsResult> list;
        
        
        STDivision currdiv;

        STAwardsResult flawour;
        int gpos;

        public AwardsResult(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void AwardsResult_Load(object sender, EventArgs e)
        {
            try
            {
                clDiv = new CDivision(connect);
                clWork = new CAwarsResult(connect);
                clTeam = new CTeam(connect);
                clAward = new CAward(connect);

                init_combo();
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
            try
            {
                dataGridViewAwardResult.Rows.Clear();

                list = clWork.GetListData(IS.idseason, currdiv.id);

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewAwardResult.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        STAward st = clAward.GetAward(list[i].idaward);
                        dataGridViewAwardResult.Rows[i].Cells[0].Value = st.nameaward;


                        clPlayer = new CPlayer(connect, list[i].idplayer);

                        dataGridViewAwardResult.Rows[i].Cells[1].Value = string.Format("{0} {1}",
                            clPlayer.stPlayer.name, clPlayer.stPlayer.family);


                        clEP = new CEntryPlayers(connect);
                        int x = clEP.IsEntryPlayer(IS.idseason, list[i].idplayer);

                        if (x > 0)
                        {
                            clTeam = new CTeam(connect, x);
                            dataGridViewAwardResult.Rows[i].Cells[2].Value = clTeam.stTeam.name;
                        }

                        if (list[i].result != null) dataGridViewAwardResult.Rows[i].Cells[3].Value = 
                            string.Format("{0:f2}",list[i].result);

                        dataGridViewAwardResult.Rows[i].Cells[4].Value = list[i].idplayer;

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewAwardResult.ClearSelection();

                    dataGridViewAwardResult.AllowUserToAddRows = false;
                }
                else dataGridViewAwardResult.AllowUserToAddRows = false;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    text = comboBoxDivision.Text.Trim();
                    clDiv = new CDivision(connect,IS.idseason,text);

                    currdiv = clDiv.stDiv;

                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void oolStripMenuItemAddAward_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEditAward_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDelAward_Click(object sender, EventArgs e)
        {
            del();
        }

        private void dataGridViewAwardResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgAwardsResult wnd = new DlgAwardsResult(connect, IS, currdiv.id, null);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewAwardResult.Rows.Count > 0)
                    {
                        dataGridViewAwardResult.Rows[gpos].Selected = true;
                        dataGridViewAwardResult.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STAwardsResult data = GetSelectionData();

                DlgAwardsResult wnd = new DlgAwardsResult(connect, IS, currdiv.id, data);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewAwardResult.Rows.Count > 0)
                    {
                        dataGridViewAwardResult.Rows[gpos].Selected = true;
                        dataGridViewAwardResult.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void del()
        {
            try
            {
                STAwardsResult data = GetSelectionData();

                if (MessageBox.Show("Вы действиетльно желаете удалить запись?", "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clWork.Delete(data);
                    init_data();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STAwardsResult GetSelectionData()
        {
            STAwardsResult ret = new STAwardsResult();

            STAward st;
            int idaward;
            int idplayer;

            try
            {
                foreach (DataGridViewRow item in dataGridViewAwardResult.SelectedRows)
                {
                    st = clAward.GetAward(item.Cells[0].Value.ToString());
            
                    idaward = st.idaward;
                    idplayer = int.Parse(item.Cells[4].Value.ToString());

                    ret = clWork.GetData(IS.idseason, currdiv.id, idaward, idplayer);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}