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
    public partial class DlgEntryTeam : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        STEntryTeam stTeamPart;

        CEntryPlayers clTeamComposition;
        List<STEntryPlayers> team_composition;
        List<STCoach> list_coach;


        CTeam team;
        CDivision div;

        ushort limit_player;

        string caption;

        bool g_f;

        STEntryPlayers flawour;
        int gpos;

        /* конструктор 1 */
        public DlgEntryTeam(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            stTeamPart = new STEntryTeam();

            caption = "Новая заявка";
        }
        /* конструктор 2 */
        public DlgEntryTeam(SqlConnection cn, STInfoSeason inf, STEntryTeam st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;
            stTeamPart = st;

            caption = "Редактирование заявки";

            comboBoxNameTeam.Enabled = false;
        }
        /* запуск формы */
        private void DlgTeamParticipant_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                init_combo_team();
                init_combo_coach();
                init_combo_division();

                clTeamComposition = new CEntryPlayers(connect);

                if (stTeamPart.idteam != 0) set_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /* инициализация списка команд */
        private void init_combo_team()
        {
            try
            {
                team = new CTeam(connect);

                List<STTeam> list = team.GetListTeam(0);

                foreach (STTeam item in list)
                {
                    comboBoxNameTeam.Items.Add(item.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /* инициализация списка тренеров */
        private void init_combo_coach()
        {
            CCoach clCoach;
            string text;

            try
            {
                clCoach = new CCoach(connect);

                list_coach = clCoach.GetList();

                comboBoxCoach1.Items.Add("");
                comboBoxCoach2.Items.Add("");
                comboBoxCoach3.Items.Add("");

                foreach (STCoach item in list_coach)
                {
                    text = string.Format("{0} {1}", item.family, item.name);
                    comboBoxCoach1.Items.Add(text);
                    comboBoxCoach2.Items.Add(text);
                    comboBoxCoach3.Items.Add(text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /* инициализация списка дивизионов */
        private void init_combo_division()
        {
            try
            {
                comboBoxDivision.Items.Clear();

                if (IS.cntdivision > 0)
                {
                    div = new CDivision(connect);

                    List<STDivision> list = div.GetListDivision((int)IS.idseason);

                    foreach (STDivision item in list)
                    {
                        comboBoxDivision.Items.Add(item.name);
                    }
                }
                else comboBoxDivision.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /* инициализация списка игроков */
        private void init_combo_captain()
        {
            CPlayer clPlayer;
            string text;

            try
            {
                comboBoxCaptain.Items.Clear();

                comboBoxCaptain.Items.Add("");

                foreach (STEntryPlayers item in team_composition)
                {
                    clPlayer = new CPlayer(connect, item.idplayer);
                    text = string.Format("#{0} {1} {2}",item.number, clPlayer.stPlayer.family, clPlayer.stPlayer.name);

                    comboBoxCaptain.Items.Add(text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /* инициализация списка состава команды */
        private void init_data(List<STEntryPlayers> tm_c)
        {
            CPlayer clPlayer;
            CAge age = new CAge();
            CStatus status;

            string amplua = "";

            try
            {
                g_f = false;

                dataGridViewCompositionTeam.Rows.Clear();

                if (tm_c.Count > 0)
                {
                    g_f = true;

                    dataGridViewCompositionTeam.Rows.Add(tm_c.Count);

                    for (int i = 0; i < tm_c.Count; i++)
                    {
                        if (tm_c[i].dateout == null)
                        {
                            if (tm_c[i].datein == stTeamPart.datein)
                                dataGridViewCompositionTeam.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            else dataGridViewCompositionTeam.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
                        }
                        else dataGridViewCompositionTeam.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                        /* № п\п */
                        dataGridViewCompositionTeam.Rows[i].Cells[0].Value = (i + 1).ToString();
                        /* Амплуа */
                        if (tm_c[i].amplua != null)
                        {
                            if (tm_c[i].amplua == 1) amplua = "З";
                            if (tm_c[i].amplua == 2) amplua = "Ф";
                            if (tm_c[i].amplua == 3) amplua = "Ц";
                        }
                        else amplua = "";
                        dataGridViewCompositionTeam.Rows[i].Cells[1].Value = amplua;
                        /* ФИО */
                        clPlayer = new CPlayer(connect, tm_c[i].idplayer);
                        dataGridViewCompositionTeam.Rows[i].Cells[2].Value = clPlayer.stPlayer.family +
                            " " + clPlayer.stPlayer.name + " " + clPlayer.stPlayer.payname;
                        /* Номер */
                        dataGridViewCompositionTeam.Rows[i].Cells[3].Value = tm_c[i].number.ToString();
                        /* Рост */
                        if (tm_c[i].growing != null)
                            dataGridViewCompositionTeam.Rows[i].Cells[4].Value = tm_c[i].growing.ToString();
                        /* Вес */
                        if (tm_c[i].weight != null)
                            dataGridViewCompositionTeam.Rows[i].Cells[5].Value = tm_c[i].weight.ToString();
                        /* Возраст */
                        if (clPlayer.stPlayer.datebirth != null)
                        {
                            dataGridViewCompositionTeam.Rows[i].Cells[6].Value =
                                age.GetAge((DateTime)clPlayer.stPlayer.datebirth, DateTime.Now).ToString();
                        }

                        /* Дата заявки */
                        dataGridViewCompositionTeam.Rows[i].Cells[7].Value = tm_c[i].datein.ToShortDateString();
                        /* Дата отзаявки*/
                        if (tm_c[i].dateout != null)
                        {
                            DateTime dt = (DateTime)tm_c[i].dateout;
                            dataGridViewCompositionTeam.Rows[i].Cells[8].Value = dt.ToShortDateString();
                        }

                        if (flawour.Equals(tm_c[i])) gpos = i;

                        
                    }

                    dataGridViewCompositionTeam.ClearSelection();
                    dataGridViewCompositionTeam.AllowUserToAddRows = false;
                }
                else dataGridViewCompositionTeam.AllowUserToAddRows = false;

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        /* вставка данных */
        private void set_data()
        {
            CCoach clCoach;
            CPlayer clPlayer;
            string text;

            try
            {
                team = new CTeam(connect,stTeamPart.idteam);
                comboBoxNameTeam.Text = team.stTeam.name;

                CCity city = new CCity(connect,team.stTeam.idcity);
                labelDisl.Text = string.Format("{0}, {1}",city.stFullCity.name, city.stFullCity.nameregion);

                dateTimePickerDateIn.Value = stTeamPart.datein;

                div = new CDivision(connect, (int)IS.idseason, stTeamPart.iddivision);
                comboBoxDivision.Text = div.stDiv.name;

                clTeamComposition = new CEntryPlayers(connect);
                team_composition = clTeamComposition.GetListEntryPlayers(IS.idseason, stTeamPart.idteam, "Number");

                init_data(team_composition);
                init_combo_captain();

                if (stTeamPart.idcoach1 != null)
                {
                    clCoach = new CCoach(connect, (int)stTeamPart.idcoach1);
                    text = string.Format("{0} {1}", clCoach.stCoach.family, clCoach.stCoach.name);
                    comboBoxCoach1.Text = text;
                }

                if (stTeamPart.idcoach2 != null)
                {
                    clCoach = new CCoach(connect, (int)stTeamPart.idcoach2);
                    text = string.Format("{0} {1}", clCoach.stCoach.family, clCoach.stCoach.name);
                    comboBoxCoach2.Text = text;
                }

                if (stTeamPart.idcoach3 != null)
                {
                    clCoach = new CCoach(connect, (int)stTeamPart.idcoach3);
                    text = string.Format("{0} {1}", clCoach.stCoach.family, clCoach.stCoach.name);
                    comboBoxCoach3.Text = text;
                }

                if (stTeamPart.idcaptain != null)
                {
                    clPlayer = new CPlayer(connect, (int)stTeamPart.idcaptain);
                    string num = get_num_captain((int)stTeamPart.idcaptain);
                    text = string.Format("#{0} {1} {2}", num, clPlayer.stPlayer.family, clPlayer.stPlayer.name);
                    comboBoxCaptain.Text = text;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private string get_num_captain(int id)
        {
            string ret = null;

            try
            {
                foreach (STEntryPlayers item in team_composition)
                {
                    if (item.idplayer == id) ret = item.number;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private bool save()
        {
            bool ret = false;

            STEntryTeam stTP = new STEntryTeam();
            
            stTP = read_data();

            CEntryTeam clTPart = new CEntryTeam(connect);

            if (stTeamPart.idteam != 0)
                ret = clTPart.Update(stTP, stTeamPart);
            else
                ret = clTPart.Insert(stTP);

            return ret;
        }

        private STEntryTeam read_data()
        {
            STEntryTeam ret = new STEntryTeam();

            try
            {
                if (stTeamPart.idteam != 0 && stTeamPart.idseason != 0)
                {
                    ret.idseason = stTeamPart.idseason;
                    ret.idteam = stTeamPart.idteam;
                }
                else
                {
                    ret.idseason = (int)IS.idseason;
                    
                    team = new CTeam(connect,comboBoxNameTeam.Text.Trim());
                    ret.idteam = team.stTeam.id;
                }

                div = new CDivision(connect, (int)IS.idseason, comboBoxDivision.Text.Trim());
                ret.iddivision = div.stDiv.id;

                ret.datein = new DateTime(dateTimePickerDateIn.Value.Year, dateTimePickerDateIn.Value.Month,
                    dateTimePickerDateIn.Value.Day, 0, 0, 0, 0);

                if (comboBoxCoach1.Text.Length > 0)
                    ret.idcoach1 = get_id_coach(comboBoxCoach1.Text.Trim());
                else ret.idcoach1 = 0;

                if (comboBoxCoach2.Text.Length > 0)
                    ret.idcoach2 = get_id_coach(comboBoxCoach2.Text.Trim());
                else ret.idcoach2 = 0;

                if (comboBoxCoach3.Text.Length > 0)
                    ret.idcoach3 = get_id_coach(comboBoxCoach3.Text.Trim());
                else ret.idcoach3 = 0;

                if (comboBoxCaptain.Text.Length > 0)
                    ret.idcaptain = get_id_player(comboBoxCaptain.Text.Trim());
                else ret.idcaptain = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private STEntryPlayers GetSelectionData()
        {
            STEntryPlayers ret = new STEntryPlayers();

            string shortname = null;

            string comp = null;

            CPlayer clPlayer;

            try
            {
                foreach (DataGridViewRow item in dataGridViewCompositionTeam.SelectedRows)
                {
                    shortname = item.Cells[1].Value.ToString();

                    foreach (STEntryPlayers data in team_composition)
                    {
                        clPlayer = new CPlayer(connect, data.idplayer);
                        comp = string.Format("{0} {1} {2}",clPlayer.stPlayer.family, clPlayer.stPlayer.name,
                            clPlayer.stPlayer.payname);

                        if (shortname == comp) ret = data;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
   

        public int RetId()
        {
            return stTeamPart.idteam;
        }

        private int get_id_coach(string text)
        {
            int ret = 0;

            try
            {
                char[] del = { ' ' };
                string[] words = text.Split(del);

                string famili = words[0];
                string name = words[1];

                CCoach cl = new CCoach(connect, famili, name);

                ret = cl.stCoach.idcoach;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
        private int get_id_player(string text)
        {
            int ret = 0;

            try
            {
                char[] del = { '#', ' ' };
                string[] words = text.Split(del);

                string number = words[1];
                string famili = words[2];
                string name = words[3];

                foreach (STEntryPlayers item in team_composition)
                {
                    if (number.Equals(item.number))
                        ret = item.idplayer;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        /*
        private List<STEntryPlayers> GetTeamComposition(int idteam)
        {
            List<STEntryPlayers> ret = new List<STEntryPlayers>();

            try
            {
                List<List<STTeamComposition>> list = clTeamComposition.GetComposition(IS.idseason, idteam,
                    DateTime.Now);

                foreach (STTeamComposition item1 in list[3])
                {
                    ret.Add(item1);
                }

                foreach (STTeamComposition item2 in list[2])
                {
                    ret.Add(item2);
                }
 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
            
            return ret;
        }
*/

        private void dataGridViewCompositionTeam_TabIndexChanged(object sender, EventArgs e)
        {
            if (!dataGridViewCompositionTeam.CanFocus)
                dataGridViewCompositionTeam.ClearSelection();
        }
       
    }
}