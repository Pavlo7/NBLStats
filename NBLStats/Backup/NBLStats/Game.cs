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
    public partial class Game : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;

        CReferee clReferee;
        CParticipant clParticipant;
        CDivision clDivision;
        CScheme clScheme;
        CGroup clGroup;
        CTeam clTeam;
        CPlace clPlace;

        STGame stC;
        STGame gstGame;

        string caption;

        int gType;
        int gDiv;
        int gStage;
        int gGroup;
        int gTeam1;
        int gTeam2;

        bool newgame;

        bool fread;

        public Game(SqlConnection cn, STInfoSeason st, ushort m, int tp)
        {
            InitializeComponent();
 
            connect = cn;
            IS = st;
            mode = m;
            gType = tp;

            newgame = true;

            caption = "Новая игра";
        }

        public Game(SqlConnection cn, STInfoSeason st, ushort m, STGame stru)
        {
            InitializeComponent();

            connect = cn;
            IS = st;
            mode = m;

            gstGame = stru;

            if (stru.type != null)
                gType = (int)stru.type;

            if (stru.iddivision != null)
                gDiv = (int)stru.iddivision;
            else gDiv = 0;
            if (stru.idgroup != null)
                gGroup = (int)stru.idgroup;
            else gGroup = 0;
            if (stru.idstage != null)
                gStage = (int)stru.idstage;
            else gStage = 0;

            newgame = false;

            caption = "Редактировать игру";
        }

        private void Protocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                fread = true;

                init_combo_division();
                init_combo_place();
                init_combo_referee();
                init_combo_part();
                init_combo_stage();
                init_combo_group();
                init_combo_team();

                gDiv = 0;
                gGroup = 0;
                gStage = 0;

                if (newgame) PrepareNewGame();
                else PrepareEditGame(gstGame);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 
        }

        /*  ИНИЦИАЛИЗАЦИЯ СПИСКОВ */
        /*  +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */
        /* инициализация списка дивизионов */
        private void init_combo_division()
        {
            try
            {
                if (gType == 2) comboBoxDivision.Enabled = false;
               
                else
                {
                    comboBoxDivision.Items.Clear();
                    comboBoxDivision.Text = null;

                    clDivision = new CDivision(connect);
                    List<STDivision> list = clDivision.GetListDivision(IS.idseason);

                    if (list.Count > 0)
                    {
                        comboBoxDivision.Items.Add("");

                        foreach (STDivision item in list)
                            comboBoxDivision.Items.Add(item.name);
                    }
                    else comboBoxDivision.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = null;

            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    name = comboBoxDivision.Text.Trim();
                    clDivision = new CDivision(connect, IS.idseason, name);

                    gDiv = clDivision.stDiv.id;

                    init_combo_stage();
                    init_combo_team();
                    init_combo_group();

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /* инициализация списка стадий */
        private void init_combo_stage()
        {
            try
            {
                comboBoxStage.Items.Clear();
                comboBoxStage.Text = null;

                clScheme = new CScheme(connect);
                List<STScheme> list = clScheme.GetListScheme(IS.idseason, gDiv, gType);

                if (list.Count > 0)
                {
                    comboBoxStage.Items.Add("");

                    comboBoxStage.Enabled = true;

                    foreach (STScheme item in list)
                        comboBoxStage.Items.Add(item.namestage);
                }
                else comboBoxStage.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void comboBoxStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = null;

            try
            {
                if (comboBoxStage.Text.Length > 0)
                {
                    name = comboBoxStage.Text.Trim();
                    clScheme = new CScheme(connect,IS.idseason, gDiv, name);

                    gStage = clScheme.stScheme.idstage;

                    if (gType == 0)
                        init_combo_group();

                    init_combo_round(clScheme.stScheme.cntround);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /* инициализация списка групп */
        private void init_combo_group()
        {
            try
            {
                if (gType == 2) comboBoxGroup.Enabled = false;
                else
                {

                    comboBoxGroup.Items.Clear();

                    clGroup = new CGroup(connect);
                    List<STGroup> list = clGroup.GetListGroup(IS.idseason, gDiv, gStage);

                    if (list.Count > 0)
                    {
                        comboBoxGroup.Items.Add("");

                        comboBoxGroup.Enabled = true;

                        foreach (STGroup item in list)
                            comboBoxGroup.Items.Add(item.namegroup);
                    }
                    else comboBoxGroup.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = null;

            try
            {
                if (comboBoxGroup.Text.Length > 0)
                {
                    name = comboBoxGroup.Text.Trim();
                    clGroup = new CGroup(connect, IS.idseason, gDiv, name);

                    gGroup = clGroup.stGroup.idgroup;

                    init_combo_team();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /* инициализация списка туров */
        private void init_combo_round(int x)
        {
            try
            {
                comboBoxRound.Items.Clear();

                if (x > 0)
                {
                    comboBoxRound.Enabled = true;

                    for(int i=0; i<x; i++)
                        comboBoxRound.Items.Add((i+1).ToString());
                }
                else comboBoxRound.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /* инициализация списка команд */
        private void init_combo_team()
        {
            try
            {
                comboBoxTeam1.Items.Clear();
                comboBoxTeam2.Items.Clear();

                clTeam = new CTeam(connect);
                List<STTeam> list = clTeam.GetListTeam(IS.idseason, gDiv, gGroup);

                if (list.Count > 0)
                {
                    foreach (STTeam item in list)
                    {
                        comboBoxTeam1.Items.Add(item.name);
                        comboBoxTeam2.Items.Add(item.name);
                    }
                }
                else
                {
                    comboBoxTeam1.Enabled = false;
                    comboBoxTeam2.Enabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void comboBoxTeam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = null;

            try
            {
                if (comboBoxTeam1.Text.Length > 0)
                {
                    name = comboBoxTeam1.Text.Trim();
                    clTeam = new CTeam(connect, name);

                    gTeam1 = clTeam.stTeam.id;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void comboBoxTeam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = null;

            try
            {
                if (comboBoxTeam2.Text.Length > 0)
                {
                    name = comboBoxTeam2.Text.Trim();
                    clTeam = new CTeam(connect, name);

                    gTeam2 = clTeam.stTeam.id;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /* инициализация списка площадок */
        private void init_combo_place()
        {
            try
            {
                comboBoxPlace.Items.Clear();

                clPlace = new CPlace(connect);
                List<STPlace> list = clPlace.GetListPlace();

                comboBoxPlace.Items.Add("");

                if (list.Count > 0)
                {
                    foreach (STPlace item in list)
                        if (item.vf == 1)
                            comboBoxPlace.Items.Add(item.name);
                }
                else comboBoxPlace.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /* инициализация списка судей */
        private void init_combo_referee()
        {
            string text = null;

            try
            {
                comboBoxStReferee.Items.Clear();
                comboBoxReferee1.Items.Clear();
                comboBoxReferee2.Items.Clear();

                clReferee = new CReferee(connect);
                List<STReferee> lst = clReferee.GetList();

                comboBoxStReferee.Items.Add("");
                comboBoxReferee1.Items.Add("");
                comboBoxReferee2.Items.Add("");

                foreach (STReferee item in lst)
                {
                    if (item.vf == 1)
                    {
                        text = string.Format("{0} {1}", item.family, item.name);
                        comboBoxStReferee.Items.Add(text);
                        comboBoxReferee1.Items.Add(text);
                        comboBoxReferee2.Items.Add(text);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /* инициализация списка обслуж. персонала */
        private void init_combo_part()
        {
            string text = null;

            try
            {
                comboBoxSecretar.Items.Clear();
                comboBoxOperPanel.Items.Clear();
                comboBoxOperVideo.Items.Clear();
                comboBoxMedic.Items.Clear();
                comboBoxDiktor.Items.Clear();
                comboBoxStatist.Items.Clear();

                comboBoxSecretar.Items.Add("");
                comboBoxOperPanel.Items.Add("");
                comboBoxOperVideo.Items.Add("");
                comboBoxMedic.Items.Add("");
                comboBoxDiktor.Items.Add("");
                comboBoxStatist.Items.Add("");

                clParticipant = new CParticipant(connect);
                List<STParticipant> lst = clParticipant.GetList();

                foreach (STParticipant item in lst)
                {
                    if (item.vf == 1)
                    {
                        text = string.Format("{0} {1}", item.family, item.name);

                        comboBoxSecretar.Items.Add(text);
                        comboBoxOperPanel.Items.Add(text);
                        comboBoxOperVideo.Items.Add(text);
                        comboBoxMedic.Items.Add(text);
                        comboBoxDiktor.Items.Add(text);
                        comboBoxStatist.Items.Add(text);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        /*  +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ */

        public STGame GetFl()
        {
            return stC;
        }
    
        private void buttonSave_Click(object sender, EventArgs e)
        {
            CGame clGame = new CGame(connect);
            try
            {
                stC = read_data();

                if (fread)
                {
                    if (newgame == true)
                    {
                        if (clGame.Insert(stC)) DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (clGame.Update(stC, IS.idseason, gstGame.idgame)) DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 
        }

        private STGame read_data()
        {
            STGame ret = new STGame();
            
            try
            {
                /* сезон */
                ret.idseason = IS.idseason;
                /* тип игры */
                ret.type = gType;
                /* номер игры */
                if (textBoxNum.Text.Length > 0)
                    ret.idgame = int.Parse(textBoxNum.Text.Trim());
                /* дата\время игры */
                ret.datetime = new DateTime(dateTimePickerDate.Value.Year, dateTimePickerDate.Value.Month,
                    dateTimePickerDate.Value.Day, dateTimePickerTime.Value.Hour, dateTimePickerTime.Value.Minute,
                    0, 0);
                /* дивизион */
                if (comboBoxDivision.Text.Length > 0)
                {
                    clDivision = new CDivision(connect, IS.idseason, comboBoxDivision.Text);
                    ret.iddivision = clDivision.stDiv.id;
                }
                else ret.iddivision = 0;
                /* стадия */
                if (comboBoxStage.Text.Length > 0)
                {
                    clScheme = new CScheme(connect, IS.idseason, (int)ret.iddivision, comboBoxStage.Text.Trim());
                    ret.idstage = clScheme.stScheme.idstage;
                }
                else ret.idstage = null;
                /* группа */
                if (comboBoxGroup.Text.Length > 0)
                {
                    clGroup = new CGroup(connect, IS.idseason, (int)ret.iddivision, comboBoxGroup.Text.Trim());
                    ret.idgroup = clGroup.stGroup.idgroup;
                }
                else ret.idgroup = null;
                /* номер тура */
                if (comboBoxRound.Text.Length > 0)
                {
                    ret.round = int.Parse(comboBoxRound.Text.Trim());
                }
                else ret.round = null;
                /* площадка */
                if (comboBoxPlace.Text.Length > 0)
                {
                    clPlace = new CPlace(connect, comboBoxPlace.Text.Trim());
                    ret.idplace = clPlace.stPlace.id;
                }
                else ret.idplace = null;
                /* команда 1 */
                if (comboBoxTeam1.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxTeam1.Text.Trim());
                    ret.idteam1 = clTeam.stTeam.id;
                }
                else ret.idteam1 = null;
                /* команда 2 */
                if (comboBoxTeam2.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxTeam2.Text.Trim());
                    ret.idteam2 = clTeam.stTeam.id;
                }
                else ret.idteam2 = null;
                /* данный команд */
                if (textBoxAPer1.Text.Length > 0) ret.aper1 = int.Parse(textBoxAPer1.Text.Trim());
                else ret.aper1 = null;
                if (textBoxAPer2.Text.Length > 0) ret.aper2 = int.Parse(textBoxAPer2.Text.Trim());
                else ret.aper2 = null;
                if (textBoxADopPer.Text.Length > 0) ret.adopper = int.Parse(textBoxADopPer.Text.Trim());
                else ret.adopper = null;
                if (textBoxAF1.Text.Length > 0) ret.ateamfouls1 = int.Parse(textBoxAF1.Text.Trim());
                else ret.ateamfouls1 = null;
                if (textBoxAF2.Text.Length > 0) ret.ateamfouls2 = int.Parse(textBoxAF2.Text.Trim());
                else ret.ateamfouls2 = null;
                if (textBoxAF3.Text.Length > 0) ret.ateamfouls3 = int.Parse(textBoxAF3.Text.Trim());
                else ret.ateamfouls3 = null;
                if (textBoxAF4.Text.Length > 0) ret.ateamfouls4 = int.Parse(textBoxAF4.Text.Trim());
                else ret.ateamfouls4 = null;

                if (textBoxBPer1.Text.Length > 0) ret.bper1 = int.Parse(textBoxBPer1.Text.Trim());
                else ret.bper1 = null;
                if (textBoxBPer2.Text.Length > 0) ret.bper2 = int.Parse(textBoxBPer2.Text.Trim());
                else ret.bper2 = null;
                if (textBoxBDopPer.Text.Length > 0) ret.bdopper = int.Parse(textBoxBDopPer.Text.Trim());
                else ret.bdopper = null;
                if (textBoxBF1.Text.Length > 0) ret.bteamfouls1 = int.Parse(textBoxBF1.Text.Trim());
                else ret.bteamfouls1 = null;
                if (textBoxBF2.Text.Length > 0) ret.bteamfouls2 = int.Parse(textBoxBF2.Text.Trim());
                else ret.bteamfouls2 = null;
                if (textBoxBF3.Text.Length > 0) ret.bteamfouls3 = int.Parse(textBoxBF3.Text.Trim());
                else ret.bteamfouls3 = null;
                if (textBoxBF4.Text.Length > 0) ret.bteamfouls4 = int.Parse(textBoxBF4.Text.Trim());
                else ret.bteamfouls4 = null;

                if (textBoxAPoints1.Text.Length > 0) ret.apointsper1 = int.Parse(textBoxAPoints1.Text.Trim());
                else ret.apointsper1 = null;
                if (textBoxAPoints2.Text.Length > 0) ret.apointsper2 = int.Parse(textBoxAPoints2.Text.Trim());
                else ret.apointsper2 = null;
                if (textBoxAPoints3.Text.Length > 0) ret.apointsper3 = int.Parse(textBoxAPoints3.Text.Trim());
                else ret.apointsper3 = null;
                if (textBoxAPoints4.Text.Length > 0) ret.apointsper4 = int.Parse(textBoxAPoints4.Text.Trim());
                else ret.apointsper4 = null;
                if (textBoxADopPoints.Text.Length > 0) ret.apointsdopper = int.Parse(textBoxADopPoints.Text.Trim());
                else ret.apointsdopper = null;
                if (textBoxAPoints.Text.Length > 0) ret.apoints = int.Parse(textBoxAPoints.Text.Trim());
                else ret.apoints = null;

                if (textBoxBPoints1.Text.Length > 0) ret.bpointsper1 = int.Parse(textBoxBPoints1.Text.Trim());
                else ret.bpointsper1 = null;
                if (textBoxBPoints2.Text.Length > 0) ret.bpointsper2 = int.Parse(textBoxBPoints2.Text.Trim());
                else ret.bpointsper2 = null;
                if (textBoxBPoints3.Text.Length > 0) ret.bpointsper3 = int.Parse(textBoxBPoints3.Text.Trim());
                else ret.bpointsper3 = null;
                if (textBoxBPoints4.Text.Length > 0) ret.bpointsper4 = int.Parse(textBoxBPoints4.Text.Trim());
                else ret.bpointsper4 = null;
                if (textBoxBDopPoints.Text.Length > 0) ret.bpointsdopper = int.Parse(textBoxBDopPoints.Text.Trim());
                else ret.bpointsdopper = null;
                if (textBoxBPoints.Text.Length > 0) ret.bpoints = int.Parse(textBoxBPoints.Text.Trim());
                else ret.bpoints = null;
                /* флаг технического результата */
                if (checkBoxTeh.Checked == true) ret.flagteh = 1;
                else ret.flagteh = 0;
           
                /* команда - победитель */
                if (ret.apoints > ret.bpoints) ret.idteamwins = ret.idteam1;
                else if (ret.apoints < ret.bpoints) ret.idteamwins = ret.idteam2;
                else ret.idteamwins = null;
                    
                /* судьи */
                if (comboBoxStReferee.Text.Length > 0)
                    ret.idstreferee = get_referee(comboBoxStReferee.Text.Trim());
                else ret.idstreferee = null;
                if (comboBoxReferee1.Text.Length > 0)
                    ret.idreferee1 = get_referee(comboBoxReferee1.Text.Trim());
                else ret.idreferee1 = null;
                if (comboBoxReferee2.Text.Length > 0)
                    ret.idreferee2 = get_referee(comboBoxReferee2.Text.Trim());
                else ret.idreferee2 = null;
                /* оценки судьям */
                if (textBoxPointsStrefree.Text.Length > 0)
                    ret.srrefereepoints = double.Parse(textBoxPointsStrefree.Text.Trim());
                else ret.srrefereepoints = null;
                if (textBoxPointsReferee1.Text.Length > 0)
                    ret.referee1points = double.Parse(textBoxPointsReferee1.Text.Trim());
                else ret.referee1points = null;
                if (textBoxPointsReferee2.Text.Length > 0)
                    ret.referee2points = double.Parse(textBoxPointsReferee2.Text.Trim());
                else ret.referee2points = null;

                /* секретарь */
                if (comboBoxSecretar.Text.Length > 0)
                    ret.idwriting = get_participant(comboBoxSecretar.Text.Trim());
                else ret.idwriting = null;
                /* секретарь */
                if (comboBoxOperPanel.Text.Length > 0)
                    ret.idoperpanel = get_participant(comboBoxOperPanel.Text.Trim());
                else ret.idoperpanel = null;
                /* видеооператор */
                if (comboBoxOperVideo.Text.Length > 0)
                    ret.idopervideo = get_participant(comboBoxOperVideo.Text.Trim());
                else ret.idopervideo = null;
                /* врач */
                if (comboBoxMedic.Text.Length > 0)
                    ret.idmedical = get_participant(comboBoxMedic.Text.Trim());
                else ret.idmedical = null;
                /* диктор */
                if (comboBoxDiktor.Text.Length > 0)
                    ret.iddiktor = get_participant(comboBoxDiktor.Text.Trim());
                else ret.iddiktor = null;
                /* подсчёт статистики */
                if (comboBoxStatist.Text.Length > 0)
                    ret.idstatister = get_participant(comboBoxStatist.Text.Trim());
                else ret.idstatister = null;

                /* остальная статистика */
                if (textBoxCntLook.Text.Length > 0) ret.cntlook = int.Parse(textBoxCntLook.Text.Trim());
                else ret.cntlook = null;
                if (textBoxChangeLider.Text.Length > 0) ret.changelider = int.Parse(textBoxChangeLider.Text.Trim());
                else ret.changelider = null;
                if (textBoxMaxPointsA.Text.Length > 0) ret.maxpointsteam1 = int.Parse(textBoxMaxPointsA.Text.Trim());
                else ret.maxpointsteam1 = null;
                if (textBoxMaxPointsB.Text.Length > 0) ret.maxpointsteam2 = int.Parse(textBoxMaxPointsB.Text.Trim());
                else ret.maxpointsteam2 = null;
                if (textBoxEqualsResult.Text.Length > 0) ret.equalsresult = int.Parse(textBoxEqualsResult.Text.Trim());
                else ret.equalsresult = null;
                if (textBoxMaxDiff.Text.Length > 0) ret.maxdiff = int.Parse(textBoxMaxDiff.Text.Trim());
                else ret.maxdiff = null;

                fread = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); fread = false; }

            return ret;
        }

        private void PrepareNewGame()
        {
            CGame cl = new CGame(connect);
            try
            {
                textBoxNum.Text = cl.GetFreeNumber(IS.idseason).ToString();
                textBoxNum.Focus();
                textBoxNum.Select();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void PrepareEditGame(STGame data)
        {
            string text;

            try
            {
                /* номер игры */
                textBoxNum.Text = data.idgame.ToString();
                /* дата\время игры */
                if (data.datetime != null)
                {
                    dateTimePickerDate.Value = new DateTime(data.datetime.Value.Year, data.datetime.Value.Month,
                        data.datetime.Value.Day, 0, 0, 0, 0);
                    dateTimePickerTime.Value = new DateTime(data.datetime.Value.Year, data.datetime.Value.Month,
                        data.datetime.Value.Day, data.datetime.Value.Hour, data.datetime.Value.Minute, 0, 0);
                }
                /* дивизион */
                if (data.iddivision != null)
                {
                    clDivision = new CDivision(connect, IS.idseason, (int)data.iddivision);
                    comboBoxDivision.Text = clDivision.stDiv.name;
                }
                /* стадия */
                if (data.idstage != null)
                {
                    clScheme = new CScheme(connect, IS.idseason, (int)data.iddivision,(int)data.idstage);
                    comboBoxStage.Text = clScheme.stScheme.namestage;
                }
                /* группа */
                if (data.idgroup != null)
                {
                    clGroup = new CGroup(connect, IS.idseason, (int)data.iddivision, (int)data.idgroup);
                    comboBoxGroup.Text = clGroup.stGroup.namegroup;
                }
                /* номер тура */
                if (data.round != null)
                {
                    comboBoxRound.Text = data.round.ToString();
                }
                /* площадка */
                if (data.idplace != null)
                {
                    clPlace = new CPlace(connect,(int)data.idplace);
                    comboBoxPlace.Text = clPlace.stPlace.name;
                }
                /* команда 1 */
                if (data.idteam1 != null)
                {
                    clTeam = new CTeam(connect, (int)data.idteam1);
                    comboBoxTeam1.Text = clTeam.stTeam.name;
                }
                /* команда 2 */
                if (data.idteam2 != null)
                {
                    clTeam = new CTeam(connect, (int)data.idteam2);
                    comboBoxTeam2.Text = clTeam.stTeam.name;
                }

                /* данный команд */
                if (data.aper1 != null) textBoxAPer1.Text = data.aper1.ToString();
                if (data.aper2 != null) textBoxAPer2.Text = data.aper2.ToString();
                if (data.adopper != null) textBoxADopPer.Text = data.adopper.ToString();
                if (data.ateamfouls1 != null) textBoxAF1.Text = data.ateamfouls1.ToString();
                if (data.ateamfouls2 != null) textBoxAF2.Text = data.ateamfouls2.ToString();
                if (data.ateamfouls3 != null) textBoxAF3.Text = data.ateamfouls3.ToString();
                if (data.ateamfouls4 != null) textBoxAF4.Text = data.ateamfouls4.ToString();

                if (data.bper1 != null) textBoxBPer1.Text = data.bper1.ToString();
                if (data.bper2 != null) textBoxBPer2.Text = data.bper2.ToString();
                if (data.bdopper != null) textBoxBDopPer.Text = data.bdopper.ToString();
                if (data.bteamfouls1 != null) textBoxBF1.Text = data.bteamfouls1.ToString();
                if (data.bteamfouls2 != null) textBoxBF2.Text = data.bteamfouls2.ToString();
                if (data.bteamfouls3 != null) textBoxBF3.Text = data.bteamfouls3.ToString();
                if (data.bteamfouls4 != null) textBoxBF4.Text = data.bteamfouls4.ToString();

                if (data.apointsper1 != null) textBoxAPoints1.Text = data.apointsper1.ToString();
                if (data.apointsper2 != null) textBoxAPoints2.Text = data.apointsper2.ToString();
                if (data.apointsper3 != null) textBoxAPoints3.Text = data.apointsper3.ToString();
                if (data.apointsper4 != null) textBoxAPoints4.Text = data.apointsper4.ToString();
                if (data.apointsdopper != null) textBoxADopPoints.Text = data.apointsdopper.ToString();
                if (data.apoints != null) textBoxAPoints.Text = data.apoints.ToString();

                if (data.bpointsper1 != null) textBoxBPoints1.Text = data.bpointsper1.ToString();
                if (data.bpointsper2 != null) textBoxBPoints2.Text = data.bpointsper2.ToString();
                if (data.bpointsper3 != null) textBoxBPoints3.Text = data.bpointsper3.ToString();
                if (data.bpointsper4 != null) textBoxBPoints4.Text = data.bpointsper4.ToString();
                if (data.bpointsdopper != null) textBoxBDopPoints.Text = data.bpointsdopper.ToString();
                if (data.bpoints != null) textBoxBPoints.Text = data.bpoints.ToString();
                /* флаг технического результата */
                if (data.flagteh != null)
                {
                    if (data.flagteh == 1) checkBoxTeh.Checked = true;
                }

                /* команда - победитель */
                if (data.idteamwins != null)
                {
                    clTeam = new CTeam(connect, (int)data.idteamwins);
                    labelTeamWins.Text = clTeam.stTeam.name;
                }

                /* судьи */
                if (data.idstreferee != null)
                {
                    clReferee = new CReferee(connect,(int)data.idstreferee);
                    text = string.Format("{0} {1}", clReferee.stRef.family, clReferee.stRef.name);
                    comboBoxStReferee.Text = text;
                }
                if (data.idreferee1 != null)
                {
                    clReferee = new CReferee(connect, (int)data.idreferee1);
                    text = string.Format("{0} {1}", clReferee.stRef.family, clReferee.stRef.name);
                    comboBoxReferee1.Text = text;
                }
                if (data.idreferee2 != null)
                {
                    clReferee = new CReferee(connect, (int)data.idreferee2);
                    text = string.Format("{0} {1}", clReferee.stRef.family, clReferee.stRef.name);
                    comboBoxReferee2.Text = text;
                }
                /* оценки судьям */
                if (data.srrefereepoints != null) textBoxPointsStrefree.Text = data.srrefereepoints.ToString();
                if (data.referee1points != null) textBoxPointsReferee1.Text = data.referee1points.ToString();
                if (data.referee2points != null) textBoxPointsReferee2.Text = data.referee2points.ToString();
                
                /* секретарь */
                if (data.idwriting != null)
                {
                    clParticipant = new CParticipant(connect, (int)data.idwriting);
                    text = string.Format("{0} {1}", clParticipant.stPart.family, clParticipant.stPart.name);
                    comboBoxSecretar.Text = text;
                }
                /* секретарь */
                if (data.idoperpanel != null)
                {
                    clParticipant = new CParticipant(connect, (int)data.idoperpanel);
                    text = string.Format("{0} {1}", clParticipant.stPart.family, clParticipant.stPart.name);
                    comboBoxOperPanel.Text = text;
                }
                /* видеооператор */
                if (data.idopervideo != null)
                {
                    clParticipant = new CParticipant(connect, (int)data.idopervideo);
                    text = string.Format("{0} {1}", clParticipant.stPart.family, clParticipant.stPart.name);
                    comboBoxOperVideo.Text = text;
                }
                /* врач */
                if (data.idmedical != null)
                {
                    clParticipant = new CParticipant(connect, (int)data.idmedical);
                    text = string.Format("{0} {1}", clParticipant.stPart.family, clParticipant.stPart.name);
                    comboBoxMedic.Text = text;
                }
                /* диктор */
                if (data.iddiktor != null)
                {
                    clParticipant = new CParticipant(connect, (int)data.iddiktor);
                    text = string.Format("{0} {1}", clParticipant.stPart.family, clParticipant.stPart.name);
                    comboBoxDiktor.Text = text;
                }
                /* подсчёт статистики */
                if (data.idstatister != null)
                {
                    clParticipant = new CParticipant(connect, (int)data.idstatister);
                    text = string.Format("{0} {1}", clParticipant.stPart.family, clParticipant.stPart.name);
                    comboBoxStatist.Text = text;
                }

                /* остальная статистика */
                if (data.cntlook != null) textBoxCntLook.Text = data.cntlook.ToString();
                if (data.changelider != null) textBoxChangeLider.Text = data.changelider.ToString();
                if (data.maxpointsteam1 != null) textBoxMaxPointsA.Text = data.maxpointsteam1.ToString();
                if (data.maxpointsteam2 != null) textBoxMaxPointsB.Text = data.maxpointsteam2.ToString();
                if (data.equalsresult != null) textBoxEqualsResult.Text = data.equalsresult.ToString();
                if (data.maxdiff != null) textBoxMaxDiff.Text = data.maxdiff.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        /* расчет результата и команды победителя */
        private void textBoxAPoints1_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxAPoints2_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxAPoints3_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxAPoints4_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxADopPoints_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxBPoints1_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxBPoints2_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxBPoints3_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxBPoints4_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void textBoxBDopPoints_TextChanged(object sender, EventArgs e)
        {
            calculate_result();
        }
        private void calculate_result()
        {
            int s = 0, r=0;
            int idwins = 0;
            
            try
            {
                s = 0;

                if (textBoxAPoints1.Text.Length > 0)
                    s += int.Parse(textBoxAPoints1.Text.Trim());
                if (textBoxAPoints2.Text.Length > 0)
                    s += int.Parse(textBoxAPoints2.Text.Trim());
                if (textBoxAPoints3.Text.Length > 0)
                    s += int.Parse(textBoxAPoints3.Text.Trim());
                if (textBoxAPoints4.Text.Length > 0)
                    s += int.Parse(textBoxAPoints4.Text.Trim());
                if (textBoxADopPoints.Text.Length > 0)
                    s += int.Parse(textBoxADopPoints.Text.Trim());

                if (s != 0) textBoxAPoints.Text = s.ToString();
                else textBoxAPoints.Text = null;

                r = 0;

                if (textBoxBPoints1.Text.Length > 0)
                    r += int.Parse(textBoxBPoints1.Text.Trim());
                if (textBoxBPoints2.Text.Length > 0)
                    r += int.Parse(textBoxBPoints2.Text.Trim());
                if (textBoxBPoints3.Text.Length > 0)
                    r += int.Parse(textBoxBPoints3.Text.Trim());
                if (textBoxBPoints4.Text.Length > 0)
                    r += int.Parse(textBoxBPoints4.Text.Trim());
                if (textBoxBDopPoints.Text.Length > 0)
                    r += int.Parse(textBoxBDopPoints.Text.Trim());

                if (r != 0) textBoxBPoints.Text = r.ToString();
                else textBoxBPoints.Text = null;

                if (s > r) idwins = gTeam1;
                if (s < r) idwins = gTeam2;

                if (idwins != 0)
                {
                    clTeam = new CTeam(connect, idwins);
                    labelTeamWins.Text = clTeam.stTeam.name;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 
        }

        private int get_participant(string text)
        {
            int ret = 0;

            try
            {
                char[] del = {' '};
                string[] words = text.Split(del);

                string famili = words[0];
                string name = words[1];

                CParticipant cl = new CParticipant(connect, famili, name);

                ret = cl.stPart.idpart;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
        private int get_referee(string text)
        {
            int ret = 0;

            try
            {
                char[] del = { ' ' };
                string[] words = text.Split(del);

                string famili = words[0];
                string name = words[1];

                CReferee cl = new CReferee(connect, famili, name);

                ret = cl.stRef.idref;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
 
    }
}