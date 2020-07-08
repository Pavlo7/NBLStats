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
    public partial class EntryPlayer : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        CEntryPlayers clWork;
        List<STEntryPlayers> full_list;

        bool g_f;

        CDivision clDiv;
        CTeam clTeam;

        STEntryPlayers flawour;
        int gpos;

        int recom;

        int param_iddiv;
        int param_idteam;

        CHistoryEntryPlayers clHEP;
        STHistoryEntryPlayers stHEP;

        public EntryPlayer(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
        }

        private void EntryPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                clWork = new CEntryPlayers(connect);
                clHEP = new CHistoryEntryPlayers(connect);

                this.WindowState = FormWindowState.Maximized;

                recom = 0;
                param_iddiv = 0;
                param_idteam = 0;

                init_combo_div();
                
                radioButtonAll.Checked = true;
                comboBoxDivision.Enabled = false;
                comboBoxTeam.Enabled = false;

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source);  }
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

        private void init_combo_team(int iddiv)
        {
            try
            {
                CEntryTeam clET = new CEntryTeam(connect);
                List<STEntryTeam> lst = clET.GetTeamParticipant(IS.idseason, iddiv);

                comboBoxTeam.Items.Clear();

                foreach (STEntryTeam item in lst)
                {
                    clTeam = new CTeam(connect, item.idteam);
                    comboBoxTeam.Items.Add(clTeam.stTeam.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            g_f = false;
            gpos = -1;

            CPlayer clPlayer;
            CTeam clTeam;
            CEntryTeam clET;

            string text;

            try
            {
                full_list = new List<STEntryPlayers>();

                List<STEntryPlayers> data_list = 
                     clWork.GetListEntryPlayers(IS.idseason, param_idteam, "IdTeam,Number");

                if (param_iddiv > 0)
                {
                    clET = new CEntryTeam(connect);
                    List<STEntryTeam> lstet = clET.GetTeamParticipant(IS.idseason, param_iddiv);

                    foreach (STEntryPlayers step in data_list)
                    {
                        foreach (STEntryTeam stet in lstet)
                        {
                            if (step.idteam == stet.idteam)
                            {
                                full_list.Add(step);
                                break;
                            }
                        }
                    }

                }
                else full_list = data_list;

                dataGridViewEntryPlayers.Rows.Clear();


                Color colortext;
                Color colorfont;

                int currteam = 0;

                bool fl = false;

                string amplua = "";

                int npp = 1;

                if (full_list.Count > 0)
                {
                    currteam = full_list[0].idteam;

                    g_f = true;

                    dataGridViewEntryPlayers.Rows.Add(full_list.Count);

                    for (int i = 0; i < full_list.Count; i++)
                    {
                        if (currteam != full_list[i].idteam)
                        {
                            currteam = full_list[i].idteam;
                            fl = !fl;

                            npp = 1;
                        }

                        if (fl) colorfont = Color.LightCyan;
                        else colorfont = Color.White;

                        colortext = Color.Black;

                        dataGridViewEntryPlayers.Rows[i].DefaultCellStyle.BackColor = colorfont;

                        clET = new CEntryTeam(connect, IS.idseason, full_list[i].idteam);
                        if (full_list[i].datein != clET.gstTeamPart.datein)
                            colortext = Color.Blue;

                        dataGridViewEntryPlayers.Rows[i].Cells[0].Value = npp.ToString();

                        if (full_list[i].amplua != null)
                        {
                            if (full_list[i].amplua == 1) amplua = "З";
                            if (full_list[i].amplua == 2) amplua = "Ф";
                            if (full_list[i].amplua == 3) amplua = "Ц";
                        }
                        else amplua = "";
                        dataGridViewEntryPlayers.Rows[i].Cells[1].Value = amplua;

                        clPlayer = new CPlayer(connect, full_list[i].idplayer);
                        text = string.Format("{0} {1} {2}", clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                            clPlayer.stPlayer.payname);
                        dataGridViewEntryPlayers.Rows[i].Cells[2].Value = text;

                        clTeam = new CTeam(connect, full_list[i].idteam);
                        dataGridViewEntryPlayers.Rows[i].Cells[3].Value = clTeam.stTeam.name;

                        dataGridViewEntryPlayers.Rows[i].Cells[4].Value = full_list[i].number;

                        if (full_list[i].growing != null)
                            dataGridViewEntryPlayers.Rows[i].Cells[5].Value = full_list[i].growing.ToString();

                        if (full_list[i].weight != null)
                            dataGridViewEntryPlayers.Rows[i].Cells[6].Value = full_list[i].weight.ToString();

                        dataGridViewEntryPlayers.Rows[i].Cells[7].Value = full_list[i].datein.ToShortDateString();

                        if (full_list[i].dateout != null)
                        {
                            DateTime dt = (DateTime)full_list[i].dateout;
                            dataGridViewEntryPlayers.Rows[i].Cells[8].Value = dt.ToShortDateString();
                            colortext = colortext = Color.Red;
                        }

                        dataGridViewEntryPlayers.Rows[i].Cells[9].Value = full_list[i].idplayer.ToString();

                        dataGridViewEntryPlayers.Rows[i].Cells[10].Value = clPlayer.stPlayer.personalnum;

                        dataGridViewEntryPlayers.Rows[i].Cells[11].Value = full_list[i].priority.ToString();

                        dataGridViewEntryPlayers.Rows[i].DefaultCellStyle.ForeColor = colortext;

                        if (flawour.Equals(full_list[i])) gpos = i;

                        npp++;
                    }

                    dataGridViewEntryPlayers.AllowUserToAddRows = false;
                }
                else dataGridViewEntryPlayers.AllowUserToAddRows = false;

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
        private void dataGridViewEntryPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                DlgEntryPlayer wnd = new DlgEntryPlayer(connect, IS, null, recom);

                if (wnd.ShowDialog() == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewEntryPlayers.Rows.Count > 0)
                    {
                        dataGridViewEntryPlayers.Rows[gpos].Selected = true;
                        dataGridViewEntryPlayers.FirstDisplayedScrollingRowIndex = gpos;
                    }

                    recom = flawour.idteam;

                    // делаем запись в историю
                    stHEP = new STHistoryEntryPlayers();
                    stHEP.opertype = 1;
                    stHEP.ed = DateTime.Now;
                    stHEP.idseason = flawour.idseason;
                    stHEP.idteam = flawour.idteam;
                    stHEP.idplayer = flawour.idplayer;
                    stHEP.text = string.Format("Дата: {0}, Номер: {1}, Рост: {2}, Вес: {3}",
                        flawour.datein.ToString(), flawour.number, flawour.growing, flawour.weight);

                    clHEP.Insert(stHEP);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void edit()
        {
            try
            {
                STEntryPlayers? data = GetSelectionData();

                if (data != null)
                {

                    DlgEntryPlayer wnd = new DlgEntryPlayer(connect, IS, data, recom);

                    if (wnd.ShowDialog() == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data();

                        if (gpos >= 0 && dataGridViewEntryPlayers.Rows.Count > 0)
                        {
                            dataGridViewEntryPlayers.Rows[gpos].Selected = true;
                            dataGridViewEntryPlayers.FirstDisplayedScrollingRowIndex = gpos;
                        }

                        recom = flawour.idteam;

                        STEntryPlayers old = (STEntryPlayers)data;

                        // делаем запись в историю
                        stHEP = new STHistoryEntryPlayers();
                        stHEP.ed = DateTime.Now;
                        stHEP.idseason = flawour.idseason;
                        stHEP.idteam = flawour.idteam;
                        stHEP.idplayer = flawour.idplayer;

                        if (flawour.dateout != null)
                        {
                            DateTime dt = (DateTime)flawour.dateout;
                            stHEP.opertype = 3;
                            stHEP.text = string.Format("Отзаявка {0}", dt.ToString());

                            clHEP.Insert(stHEP);
                        }

                        if (old.idteam != flawour.idteam)
                        {
                            string team1;
                            string team2;

                            CTeam clTeam = new CTeam(connect, old.idteam);
                            team1 = clTeam.stTeam.name;
                            clTeam = new CTeam(connect, flawour.idteam);
                            team2 = clTeam.stTeam.name;

                            stHEP.opertype = 4;
                            stHEP.text = string.Format("Смена команды с {0} на {1}", team1, team2);

                            clHEP.Insert(stHEP);
                        }

                        if (old.number != flawour.number)
                        {
                            
                            stHEP.opertype = 5;
                            stHEP.text = string.Format("Смена номера с {0} на {1}", old.number, flawour.number);

                            clHEP.Insert(stHEP);
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
                STEntryPlayers? data = GetSelectionData();
                if (data != null)
                {
                    if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        clWork.Delete((STEntryPlayers)data);
                        init_data();

                        STEntryPlayers del = (STEntryPlayers)data;
                        // делаем запись в историю
                        stHEP = new STHistoryEntryPlayers();
                        stHEP.opertype = 2;
                        stHEP.ed = DateTime.Now;
                        stHEP.idseason = del.idseason;
                        stHEP.idteam = del.idteam;
                        stHEP.idplayer = del.idplayer;
                        stHEP.text = string.Format("Дата: {0}, Номер: {1}, Рост: {2}, Вес: {3}",
                            del.datein.ToString(), del.number, del.growing, del.weight);

                        clHEP.Insert(stHEP);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STEntryPlayers? GetSelectionData()
        {
            STEntryPlayers? ret = null;

            int idteam, idplayer;
            DateTime datein;
            string text;

            CTeam team;

            try
            {
                foreach (DataGridViewRow item in dataGridViewEntryPlayers.SelectedRows)
                {
                    text = item.Cells[3].Value.ToString();
                    team = new CTeam(connect, text);
                    idteam = team.stTeam.id;

                    idplayer = int.Parse(item.Cells[9].Value.ToString().Trim());
                    datein = DateTime.Parse(item.Cells[7].Value.ToString().Trim());

                    ret = clWork.GetEntryPlayer(IS.idseason, idteam, idplayer, datein);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void ToolStripMenuItemToExcel_Click(object sender, EventArgs e)
        {
            ExcelListEntryPlayers dlg = new ExcelListEntryPlayers(connect,full_list, IS.nameseason);
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAll.Checked == true)
                {
                    comboBoxTeam.Text = null;
                    comboBoxDivision.Text = null;
                    comboBoxDivision.Enabled = false;
                    comboBoxTeam.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonOneDiv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonOneDiv.Checked == true)
                {
                    comboBoxDivision.Enabled = true;

                    comboBoxTeam.Text = null;
                    comboBoxTeam.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void radioButtonTeam_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonTeam.Checked == true)
                {
                    comboBoxTeam.Enabled = true;

                    comboBoxDivision.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                    x = clDiv.stDiv.id;
                }
                else x = 0;

                init_combo_team(x);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {  
            try
            {
                if (radioButtonAll.Checked == true)
                {
                    param_iddiv = 0;
                    param_idteam = 0;
                }

                if (radioButtonOneDiv.Checked == true)
                {
                    if (comboBoxDivision.Text.Length > 0)
                    {
                        clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                        param_iddiv = clDiv.stDiv.id;
                    }
                    else param_iddiv = 0;
                }

                if (radioButtonTeam.Checked == true)
                {
                    if (comboBoxTeam.Text.Length > 0)
                    {
                        clTeam = new CTeam(connect, comboBoxTeam.Text.Trim());
                        param_idteam = clTeam.stTeam.id;
                    }
                }

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemHistory_Click(object sender, EventArgs e)
        {
            try
            {
                
                STEntryPlayers? data = GetSelectionData();
                STEntryPlayers ret = (STEntryPlayers)data;

                CPlayer clP = new CPlayer(connect, ret.idplayer);

                HistoryPlayer wnd = new HistoryPlayer(connect, mode, clP.stPlayer);

                DialogResult result = wnd.ShowDialog();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ToolStripMenuItemTransferNews_Click(object sender, EventArgs e)
        {
            try
            {
                DlgTransferNews dlg = new DlgTransferNews(connect, IS, 1);
                dlg.ShowDialog();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

    }
}