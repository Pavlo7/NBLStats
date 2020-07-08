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
    public partial class CalendarGames : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        bool g_f;
       

        CGame clGame;
        List<STGame> list;

        STGame flawour;
        int gpos;

        STGame? recom;

        CTeam clTeam;
        CPlace clPlace;
        CDivision clDivision;
        CGroup clGroup;
        CCity clCity;
        CScheme clScheme;

        bool bDivision;
        int iIdDivision;
        bool bType;
        int iIdType;

        public CalendarGames(SqlConnection cn, STInfoSeason st, ushort md)
        {
            InitializeComponent();
            connect = cn;
            IS = st;
            mode = md;

        }

        private void CalendarGames_Load(object sender, EventArgs e)
        {
            try
            {
                clGame = new CGame(connect);
                clTeam = new CTeam(connect);
                clDivision = new CDivision(connect);
                clGroup = new CGroup(connect);
                
              //  init_combo();

                this.WindowState = FormWindowState.Maximized;

                gpos = 0;

                bDivision = false;
                bType = false;
                iIdDivision = -1;
                iIdType = -1;
                
                init_combo();
                
                init_data();

                recom = null;

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

                comboBoxDivision.Items.Add("");

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
            if (bType)
                param.type = iIdType;
            if (bDivision)
                param.iddivision = iIdDivision;
            param.ordername = "DateTimeGame,IdPlace";

            try
            {
                dataGridViewCalendarGames.Rows.Clear();

                list = new List<STGame>();
                list = clGame.GetListGames(param);

                if (list.Count > 0)
                {
                    int r = get_count_days(list);

                    dataGridViewCalendarGames.Rows.Add(list.Count + r);

                    int cnt = 0;
                   
                    DateTime currdate = DateTime.MinValue;
                    DateTime rdate;

                    for (int i = 0; i < list.Count; i++)
                    {
                        rdate  =(DateTime)list[i].datetime;
                        if (currdate.Year == rdate.Year && currdate.Month == rdate.Month &&
                            currdate.Day == rdate.Day)
                        {
                            if (flawour.idgame.Equals(list[i].idgame)) gpos = cnt;

                            init_list_add_row(list[i], cnt);
                            cnt++;
                        }
                        else
                        {
                            currdate = rdate;

                            init_list_add_capt(currdate, cnt);
                            cnt++;

                            if (flawour.idgame.Equals(list[i].idgame)) gpos = cnt;

                            init_list_add_row(list[i], cnt);
                            cnt++;
                        }
                      
                    }

                    dataGridViewCalendarGames.AllowUserToAddRows = false;

                    if (gpos <= 0)
                        dataGridViewCalendarGames.FirstDisplayedScrollingRowIndex = cnt-1;
                }
                else dataGridViewCalendarGames.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        /* вспомогательные функции виз. отображения календаря */
        private void init_list_add_row(STGame item, int i)
        {
            string text = null;
            string team1 = null;
            string team2 = null;

            Color color = Color.Black;

            try
            {
                if (item.idteamwins > 0)
                    color = Color.Black;
                else color = Color.Red;

                dataGridViewCalendarGames.Rows[i].DefaultCellStyle.ForeColor = color;

                /* вставляем номер игры */
                dataGridViewCalendarGames.Rows[i].Cells[1].Value = item.idgame;
                /* дата и время игры */
                if (item.datetime != null)
                {
                    DateTime dt = (DateTime)item.datetime;
                    text = string.Format("{0}:{1:00}", dt.Hour, dt.Minute);
                    dataGridViewCalendarGames.Rows[i].Cells[2].Value = text;
                }
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
                dataGridViewCalendarGames.Rows[i].Cells[3].Value = text;

                /* группа */
                if (item.idgroup != null)
                {
                    clGroup = new CGroup(connect, (int)IS.idseason, (int)item.iddivision, (int)item.idgroup);
                    text = string.Format("{0}", clGroup.stGroup.namegroup);

                    dataGridViewCalendarGames.Rows[i].Cells[4].Value = text;
                }

                if (item.idstage != null)
                {
                    clScheme = new CScheme(connect, IS.idseason, (int)item.iddivision, (int)item.idstage);
                    text = string.Format("{0}", clScheme.stScheme.namestage);
                    dataGridViewCalendarGames.Rows[i].Cells[5].Value = text;
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

                    dataGridViewCalendarGames.Rows[i].Cells[6].Value = text;
                }
            
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
        private void init_list_add_capt(DateTime dt, int i)
        {
            string text = null;

            try
            {
                /* вставляем дату и тур */
                text = string.Format("{0}", dt.ToLongDateString());
                dataGridViewCalendarGames.Rows[i].Cells[0].Value = text;
                dataGridViewCalendarGames.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private int get_count_days(List<STGame> list)
        {
            int ret = 0;

            DateTime currdate = DateTime.MinValue;
            DateTime rdate;

            for (int i = 0; i < list.Count; i++)
            {
                rdate  =(DateTime)list[i].datetime;
                if (currdate.Year == rdate.Year && currdate.Month == rdate.Month &&
                    currdate.Day == rdate.Day)
                {

                }
                else
                {
                    ret++;
                    currdate = rdate;
                }
            }

            return ret;
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

        private void dataGridViewCalendarGames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void add()
        {
            try
            {
                Game wnd = new Game(connect, IS, recom, mode);

                DialogResult result = wnd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    flawour = wnd.GetFl();

                    init_data();

                    if (gpos >= 0 && dataGridViewCalendarGames.Rows.Count > 0)
                    {
                        dataGridViewCalendarGames.Rows[gpos].Selected = true;
                        dataGridViewCalendarGames.FirstDisplayedScrollingRowIndex = gpos;
                    }

                    recom = flawour;
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

                        if (gpos >= 0 && dataGridViewCalendarGames.Rows.Count > 0)
                        {
                            dataGridViewCalendarGames.Rows[gpos].Selected = true;
                            dataGridViewCalendarGames.FirstDisplayedScrollingRowIndex = gpos;
                        }

                        recom = flawour;
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
                    if (data.idteamwins == null || data.idteamwins == 0)
                        MessageBox.Show("Необходимо заполнить протокол", "Внимание!", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    else
                    {
                        Stats wnd = new Stats(connect, IS, mode, data);
                        wnd.ShowDialog();
                    }
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
                foreach (DataGridViewRow item in dataGridViewCalendarGames.SelectedRows)
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
                {
                    name = comboBoxDivision.Text.Trim();

                    cl = new CDivision(connect, IS.idseason, name);
                    bDivision = true;
                    iIdDivision = cl.stDiv.id;
                }
                else
                {
                    bDivision = false;
                    iIdDivision = 0;
                }

                init_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
