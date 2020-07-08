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
    public partial class Games : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        bool g_f;
        int type;
        int iddivision;

        CGame clGame;
        List<STGame> list;

        STGame flawour;
        int gpos;

        public Games(SqlConnection cn, STInfoSeason st, ushort md, int tp)
        {
            InitializeComponent();

            connect = cn;
            IS = st;
            mode = md;
            type = tp;

            this.WindowState = FormWindowState.Maximized;

            gpos = 0;
        }

        private void Games_Load(object sender, EventArgs e)
        {
            try
            {
                clGame = new CGame(connect);

                init_combo();
                
                switch(type)
                {
                    case 0: 
                        this.Text = "Игры. Регулярный сезон.";
                        comboBoxDivision.Enabled = true;
                        break;
                    case 1: 
                        this.Text = "Игры. Плей-офф.";
                        comboBoxDivision.Enabled = true;
                        break;
                    case 2: 
                        this.Text = "Игры. Ротация между дивизионами.";
                        comboBoxDivision.Enabled = false;
                        break;
                }

                iddivision = 0;

                init_data();
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            CDivision cl = new CDivision(connect);
            List<STDivision> lst = cl.GetListDivision(IS.idseason);

            try
            {
                comboBoxDivision.Items.Clear();

                foreach (STDivision item in lst)
                    comboBoxDivision.Items.Add(item.name);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        /* виз. отображение календаря */
        private void init_data()
        {
            STGameParam param = new STGameParam();
            param.idseason = IS.idseason;
            param.type = type;
            param.iddivision = iddivision;
            param.ordername = "IdStage,NRound,DateTimeGame,IdDivision,IdGroup";

            try
            {
                dataGridViewGames.Rows.Clear();
          
                list = new List<STGame>();
                list = clGame.GetListGames(param);
 
                if (list.Count > 0)
                {
                    int r = get_count_round(list);

                    dataGridViewGames.Rows.Add(list.Count + r);
      
                    int cnt = 0;
                    bool first = false;

                    int curstage = 0;
                    int curround = 0;

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (first == false)
                        {
                            curstage = (int)list[i].idstage;
                            curround = (int)list[i].round;
                            
                            first = true;

                            init_list_add_capt(list[i], cnt);
                            cnt++;
                        }

                        if (curstage == list[i].idstage && curround == list[i].round)
                        {
                            if (flawour.Equals(list[i])) gpos = cnt;

                            init_list_add_row(list[i], cnt);
                            cnt++;
                        }
                        else
                        {
                            curstage = (int)list[i].idstage;
                            curround = (int)list[i].round;

                            init_list_add_capt(list[i], cnt);
                            cnt++;

                            if (flawour.Equals(list[i])) gpos = cnt;

                            init_list_add_row(list[i], cnt);
                            cnt++;
                        }
                    }

                    dataGridViewGames.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        /* вспомогательные функции виз. отображения календаря */
        private void init_list_add_row(STGame item, int i)
        {
            CTeam clTeam = new CTeam(connect);
            CPlace clPlace = new CPlace(connect);
            CDivision clDivision = new CDivision(connect);
            CGroup clGroup = new CGroup(connect);
            CCity clCity;

            string text = null;
            string team1 = null;
            string team2 = null;

            Color color = Color.Black;

            try
            {
                if (item.apoints > 0 && item.bpoints > 0)
                    color = Color.Black;
                else color = Color.Red;

                dataGridViewGames.Rows[i].DefaultCellStyle.ForeColor = color;

                /* вставляем номер игры */
                dataGridViewGames.Rows[i].Cells[1].Value = item.idgame;

                /* игра и результат */
                if (item.idteam1 != null)
                {
                    clTeam = new CTeam(connect, (int)item.idteam1);
                    team1 = clTeam.stTeam.name;
                }
                if (item.idteam2 != null)
                {
                    clTeam = new CTeam(connect, (int)item.idteam2);
                    team2 = clTeam.stTeam.name;
                }

                text = string.Format("{0} {1} - {2} {3}", team1, item.apoints, item.bpoints, team2);

                /* выводим команды которые играют */
                dataGridViewGames.Rows[i].Cells[2].Value = text;

                /* дата и время игры */
                if (item.datetime != null)
                {
                    DateTime dt = (DateTime)item.datetime;
                    text = string.Format("{0} {1}:{2:00}", dt.ToLongDateString(), dt.Hour, dt.Minute);
                    dataGridViewGames.Rows[i].Cells[3].Value = text;
                }

                /* место игры */
                if (item.idplace != null)
                {
                    clPlace = new CPlace(connect, (int)item.idplace);
                    clCity = new CCity(connect, clPlace.stPlace.idcity);
                    text = clPlace.stPlace.name;
                    if (clCity.stFullCity.name != null)
                    {
                        text += string.Format(" ({0},{1})", clCity.stFullCity.name, 
                            clCity.stFullCity.shortnamecountry);
                    }

                    dataGridViewGames.Rows[i].Cells[4].Value = text;
                }

                /* группа */
                if (item.idgroup != null)
                {
                    clGroup = new CGroup(connect, (int)IS.idseason, (int)item.iddivision , (int)item.idgroup);
                    text = string.Format("{0}", clGroup.stGroup.namegroup);

                    dataGridViewGames.Rows[i].Cells[5].Value = text;
                }
                                
               

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        private void init_list_add_capt(STGame item, int i)
        {
            string text = null;
           
            CScheme clScheme = new CScheme(connect,IS.idseason,(int)item.iddivision,(int)item.idstage);
            
            try
            {
                /* вставляем дату и тур */
                text = string.Format("{0}, {1} тур", clScheme.stScheme.namestage , item.round);
                dataGridViewGames.Rows[i].Cells[0].Value = text;
                dataGridViewGames.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
       
        private int get_count_round(List<STGame> list)
        {
            int ret = 0;

            bool first = false;

            DateTime currdate = DateTime.Now;
            DateTime dt = DateTime.Now;

            int idsatge = 0;
            int rnd = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (first == false)
                {
                    idsatge = (int)list[i].idstage;
                    rnd = (int)list[i].round;
                    
                    first = true;
                    ret++;
                }

                if (idsatge != list[i].idstage || rnd != list[i].round)
                {
                    idsatge = (int)list[i].idstage;
                    rnd = (int)list[i].round;
                    
                    ret++;
                }
            }

            return ret;
        }

        private void dataGridViewGames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }
        private void ToolStripMenuItemAddGame_Click(object sender, EventArgs e)
        {
            add();
        }
        private void ToolStripMenuItemEditGame_Click(object sender, EventArgs e)
        {
            edit();
        }
        private void ToolStripMenuItemDeleteGame_Click(object sender, EventArgs e)
        {
            del();
        }
        private void ToolStripMenuItemStatsGame_Click(object sender, EventArgs e)
        {
            stats();
        }

        private void add()
        {
            try
            {
                Game wnd = new Game(connect, IS, mode, type);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewGames.Rows.Count > 0)
                    {
                        dataGridViewGames.Rows[gpos].Selected = true;
                        dataGridViewGames.FirstDisplayedScrollingRowIndex = gpos;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void edit()
        {
            try
            {
                STGame data = GetSelectionData();

                if (data.idgame > 0)
                {
                    Game wnd = new Game(connect, IS, mode, data);

                    DialogResult result = wnd.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        flawour = wnd.GetFl();

                        init_data();

                        if (gpos >= 0 && dataGridViewGames.Rows.Count > 0)
                        {
                            dataGridViewGames.Rows[gpos].Selected = true;
                            dataGridViewGames.FirstDisplayedScrollingRowIndex = gpos;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void del()
        {
            string text = null;
            try
            {
                STGame data = GetSelectionData();

                if (data.idgame > 0)
                {
                    text = string.Format("Вы действиетльно желаете удалить игру {0}?", data.idgame);

                    if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        == DialogResult.OK)
                    {
                        clGame.Delete(data);
                        init_data();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void stats()
        {
            try
            {
                STGame data = GetSelectionData();

                if (data.idgame > 0)
                {
                    Stats wnd = new Stats(connect,IS,mode,data);
                    wnd.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STGame GetSelectionData()
        {

            STGame ret = new STGame();

            int n;

            try
            {
                foreach (DataGridViewRow item in dataGridViewGames.SelectedRows)
                {
                    if (item.Cells[1].Value != null)
                    {
                        n = int.Parse(item.Cells[1].Value.ToString());

                        ret = clGame.GetGame(IS.idseason, n);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            CDivision cl;
            string name = null;

            try
            {
                if (comboBoxDivision.Text.Length > 0)
                    name = comboBoxDivision.Text.Trim();

                cl = new CDivision(connect, IS.idseason, name);
                iddivision = cl.stDiv.id;

                init_data();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}