using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using LibData;

namespace NBLStats
{
    public partial class MainWindow : Form
    {
        SqlConnection connect;  /* База данных */
                
        STInfoSeason IS;          /* Параметры сезона */

        ushort mode;            /* Режим загрузки */

        string sBaseCapture = "NBLStats. Учёт статистики игр по баскетболу. ";
               

        public MainWindow()
        {
            InitializeComponent();
        }
                
        private void MainWindow_Load(object sender, EventArgs e)
        {
            EnbDizMenu(false);
         
            this.Text = sBaseCapture;

            mode = 0;

            Connect();
        }

        private void ToolStripMenuItemConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void EnbDizMenu(bool bS)
        {
            ToolStripMenuItemBook.Enabled = bS;
            ToolStripMenuItemSeason.Enabled = bS;
            ToolStripMenuItemReport.Enabled = bS;
            MainToolStrip.Enabled = bS;
        }

        private void Connect()
        {
            Connect wnd = new Connect();

            DialogResult result = wnd.ShowDialog();
            if (result == DialogResult.Yes)
            {
                EnbDizMenu(false);
                
                IS = new STInfoSeason();

                wnd.RetConnect(out connect);

                if (connect.State == ConnectionState.Open)
                {
                    get_mode();

                    EnbDizMenu(true);
                    InitParamSeason();
                    
                }
            }
        }

        private void get_mode()
        {
            Mode wnd = new Mode();

            DialogResult result = wnd.ShowDialog();
            if (result == DialogResult.OK)
            {
                wnd.GetMode(out mode);
            }
        }

        private void InitParamSeason()
        {
            string sNewCapture;

            CInfoSeason cis = new CInfoSeason(connect);

            STInfoSeason? NN = cis.GetCurretDataSeason();

            if (NN != null)
            {
                IS = (STInfoSeason)NN;

                string text = string.Format("(Наименование сезона: {0}. Дата начала сезона: {1})",IS.nameseason,
                    IS.datebegin.ToLongDateString().Trim());
                
                sNewCapture = sBaseCapture + text;

                this.Text = sNewCapture;
            }
            else
            {
                MessageBox.Show("Текущего сезона не существует!\r\nНеобходимо создать новый, либо установить текущий сезон.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ChangeSeason wnd = new ChangeSeason(connect, mode);

                DialogResult result = wnd.ShowDialog();

                IS = new STInfoSeason();
                InitParamSeason();
            }
        }

      //  private void ToolStripMenuItemSeasonParam_Click(object sender, EventArgs e)
      //  {
      //      ParamSeason wnd = new ParamSeason(connect, IS);

      //      DialogResult result = wnd.ShowDialog();
            
      //      if (result == DialogResult.OK)
      //      {
      //          IS = new STInfoSeason();
      //          InitParamSeason();
      //      }
      //  }

        private void ToolStripMenuItemSeasonNewChange_Click(object sender, EventArgs e)
        {
            ChangeSeason wnd = new ChangeSeason(connect, mode);

            DialogResult result = wnd.ShowDialog();

          //  if (result == DialogResult.Yes)
          //  {
                IS = new STInfoSeason();
                InitParamSeason();
          //  }
        }

        private void ToolStripMenuItemParam_Click(object sender, EventArgs e)
        {
            ParamApp wnd = new ParamApp();

            DialogResult result = wnd.ShowDialog();
            
        }
               

        private void ToolStripMenuItemBookCountry_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Countrys ctwindow = new Countrys(connect, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemBookRegion_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Regions ctwindow = new Regions(connect, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemCity_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Citys ctwindow = new Citys(connect, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemBookTeam_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Team ctwindow = new Team(connect, IS, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemBookPlaceBookPlace_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Place ctwindow = new Place(connect, IS, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemDivision_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Division ctwindow = new Division(connect, IS, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemSeasonTeam_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                EntryTeam ctwindow = new EntryTeam(connect, IS, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemSeasonShema_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Scheme ctwindow = new Scheme(connect, IS, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemSeasonGroup_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Group ctwindow = new Group(connect, IS, mode);
                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
        private void ToolStripMenuItemBookPlayers_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Players ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Players)
                        ctwindow = f as Players;
                }

                if (ctwindow == null)
                    ctwindow = new Players(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemBookCoach_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Coach ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Coach)
                        ctwindow = f as Coach;
                }

                if (ctwindow == null)
                    ctwindow = new Coach(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemBookReferee_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Referee ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Referee)
                        ctwindow = f as Referee;
                }

                if (ctwindow == null)
                    ctwindow = new Referee(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemBookPart_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Participant ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Participant)
                        ctwindow = f as Participant;
                }

                if (ctwindow == null)
                    ctwindow = new Participant(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       

     /*   private void ToolStripMenuItemGamesRegular_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Games ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Games)
                        ctwindow = f as Games;
                }

                if (ctwindow == null)
                    ctwindow = new Games(connect, IS, mode, 0);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }*/

      /*  private void плейоффToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Games ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Games)
                        ctwindow = f as Games;
                }

                if (ctwindow == null)
                    ctwindow = new Games(connect, IS, mode, 1);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void игрыРотацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Games ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Games)
                        ctwindow = f as Games;
                }

                if (ctwindow == null)
                    ctwindow = new Games(connect, IS, mode, 2);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        */
        private void StripMenuItemEntryPlayers_Click(object sender, EventArgs e)
        {
            try
            {
                EntryPlayer ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is EntryPlayer)
                        ctwindow = f as EntryPlayer;
                }

                if (ctwindow == null)
                    ctwindow = new EntryPlayer(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source);  }
        }

        private void ToolStripMenuItemPersonalAwards_Click(object sender, EventArgs e)
        {
            try
            {
                Awards ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Awards)
                        ctwindow = f as Awards;
                }

                if (ctwindow == null)
                    ctwindow = new Awards(connect, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemFinalresult_Click(object sender, EventArgs e)
        {
            try
            {
                FinalResult ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is FinalResult)
                        ctwindow = f as FinalResult;
                }

                if (ctwindow == null)
                    ctwindow = new FinalResult(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemPersonalAward_Click(object sender, EventArgs e)
        {
            try
            {
                AwardsResult ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is AwardsResult)
                        ctwindow = f as AwardsResult;
                }

                if (ctwindow == null)
                    ctwindow = new AwardsResult(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportReferee_Click(object sender, EventArgs e)
        {
            try
            {
                ReportReferee wnd = new ReportReferee(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void положениеКомандToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReportTeamStanding wnd = new ReportTeamStanding(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemRatingPlayerInNBL_Click(object sender, EventArgs e)
        {
            try
            {
                RatingPlayerInNBL ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is RatingPlayerInNBL)
                        ctwindow = f as RatingPlayerInNBL;
                }

                if (ctwindow == null)
                    ctwindow = new RatingPlayerInNBL(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportGame_Click(object sender, EventArgs e)
        {
            try
            {
                ReportAboutGame wnd = new ReportAboutGame(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportSatasPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                ReportStatsPlayer wnd = new ReportStatsPlayer(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportBestPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                ReportBestPlayer wnd = new ReportBestPlayer(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemExcelProtocols_Click(object sender, EventArgs e)
        {
            try
            {
                ReportExcelProtocols wnd = new ReportExcelProtocols(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportDay_Click(object sender, EventArgs e)
        {
            try
            {
                ReportlDay wnd = new ReportlDay(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemTehnicalFouls_Click(object sender, EventArgs e)
        {
            try
            {
                TableTehnicalFouls ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is TableTehnicalFouls)
                        ctwindow = f as TableTehnicalFouls;
                }

                if (ctwindow == null)
                    ctwindow = new TableTehnicalFouls(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemDiscvalification_Click(object sender, EventArgs e)
        {
            try
            {
                TableDiscvalification ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is TableDiscvalification)
                        ctwindow = f as TableDiscvalification;
                }

                if (ctwindow == null)
                    ctwindow = new TableDiscvalification(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemDisplayStats_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayStats ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is DisplayStats)
                        ctwindow = f as DisplayStats;
                }

                if (ctwindow == null)
                    ctwindow = new DisplayStats(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemFanParty_Click(object sender, EventArgs e)
        {
            try
            {
                FanParty ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is FanParty)
                        ctwindow = f as FanParty;
                }

                if (ctwindow == null)
                    ctwindow = new FanParty(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemFanRate_Click(object sender, EventArgs e)
        {
            try
            {
                FanRate ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is FanRate)
                        ctwindow = f as FanRate;
                }

                if (ctwindow == null)
                    ctwindow = new FanRate(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemFanScore_Click(object sender, EventArgs e)
        {
            try
            {
                FanScore ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is FanScore)
                        ctwindow = f as FanScore;
                }

                if (ctwindow == null)
                    ctwindow = new FanScore(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateData wnd = new CalculateData(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportAll_Click(object sender, EventArgs e)
        {
            try
            {
                FanGameReportAll wnd = new FanGameReportAll(connect, IS, mode);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
            
        }

        private void ToolStripMenuItemFanReportItog_Click(object sender, EventArgs e)
        {
            try
            {
                FanGameReportItog wnd = new FanGameReportItog(connect, IS, mode);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemImport_Click(object sender, EventArgs e)
        {
            try
            {
                DlgImportData wnd = new DlgImportData(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
            
        }

        private void ToolStripMenuItemVotePCA_Click(object sender, EventArgs e)
        {
            try
            {
                VotePCA ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is VotePCA)
                        ctwindow = f as VotePCA;
                }

                if (ctwindow == null)
                    ctwindow = new VotePCA(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemStatsTeamAndPlayers_Click(object sender, EventArgs e)
        {
            try
            {
                ReportStatsTeamAndPlayers wnd = new ReportStatsTeamAndPlayers(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemRecordsPerson_Click(object sender, EventArgs e)
        {
            try
            {
                RecordsPerson ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is RecordsPerson)
                        ctwindow = f as RecordsPerson;
                }

                if (ctwindow == null)
                    ctwindow = new RecordsPerson(connect, IS);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemPreViewWeb_Click(object sender, EventArgs e)
        {
            try
            {
                ReportPreViewWeb wnd = new ReportPreViewWeb(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportPart_Click(object sender, EventArgs e)
        {
            try
            {
                ReportPart wnd = new ReportPart(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemReportRatingsTeam_Click(object sender, EventArgs e)
        {
            try
            {

                ReportRatingsTeam wnd = new ReportRatingsTeam(connect, IS);

                wnd.ShowDialog();

                /*ReportRatingsTeam ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is ReportRatingsTeam)
                        ctwindow = f as ReportRatingsTeam;
                }

                if (ctwindow == null)
                    ctwindow = new ReportRatingsTeam(connect, IS);

                ctwindow.MdiParent = this;
                ctwindow.Show();
                 * */
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemVoteASG_Click(object sender, EventArgs e)
        {
            try
            {
                VoteASG ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is VoteASG)
                        ctwindow = f as VoteASG;
                }

                if (ctwindow == null)
                    ctwindow = new VoteASG(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemPostment_Click(object sender, EventArgs e)
        {
            try
            {
                Postment ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Postment)
                        ctwindow = f as Postment;
                }

                if (ctwindow == null)
                    ctwindow = new Postment(connect, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemGameDays_Click(object sender, EventArgs e)
        {
            try
            {
                GameDays ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is GameDays)
                        ctwindow = f as GameDays;
                }

                if (ctwindow == null)
                    ctwindow = new GameDays(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemCalendar_Click_1(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                CalendarGames ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is CalendarGames)
                        ctwindow = f as CalendarGames;
                }

                if (ctwindow == null)
                    ctwindow = new CalendarGames(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemImportTimePM_Click(object sender, EventArgs e)
        {
            try
            {
                DlgImportTimePM wnd = new DlgImportTimePM(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemBookOut_Click(object sender, EventArgs e)
        {
            try
            {
                DlgBookOut wnd = new DlgBookOut(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemWriteFileStats_Click(object sender, EventArgs e)
        {
            try
            {
                ImportStats wnd = new ImportStats(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemWriteInBDFileSgm_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                FileInfoSgm ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is FileInfoSgm)
                        ctwindow = f as FileInfoSgm;
                }

                if (ctwindow == null)
                    ctwindow = new FileInfoSgm(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemStatsCoach_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                StatsCoach ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is StatsCoach)
                        ctwindow = f as StatsCoach;
                }

                if (ctwindow == null)
                    ctwindow = new StatsCoach(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemStatsReferee_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                StatsReferee ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is StatsReferee)
                        ctwindow = f as StatsReferee;
                }

                if (ctwindow == null)
                    ctwindow = new StatsReferee(connect, IS, mode);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemListForTablo_Click(object sender, EventArgs e)
        {
            try
            {
                ListToTablo dlg = new ListToTablo(connect, IS);
                dlg.ShowDialog();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemSimvol5_Click(object sender, EventArgs e)
        {
            try
            {
                Symbol5 dlg = new Symbol5(connect, IS);
                dlg.ShowDialog();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemConvertMySql_Click(object sender, EventArgs e)
        {
            try
            {
                ConvertToMySQL dlg = new ConvertToMySQL(connect, IS);
                dlg.ShowDialog();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemRankingTeam_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                RankingTeam ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is RankingTeam)
                        ctwindow = f as RankingTeam;
                }

                if (ctwindow == null)
                    ctwindow = new RankingTeam(connect, IS);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemHistoryEntryPlayers_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                HistoryEntryPlayers ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is HistoryEntryPlayers)
                        ctwindow = f as HistoryEntryPlayers;
                }

                if (ctwindow == null)
                    ctwindow = new HistoryEntryPlayers(connect, IS);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemDraft_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                Draft ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is Draft)
                        ctwindow = f as Draft;
                }

                if (ctwindow == null)
                    ctwindow = new Draft(connect, IS);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemRatingPlayers_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Open)
            {
                RankingPlayers ctwindow = null;

                foreach (Form f in this.MdiChildren)
                {
                    if (f is RankingPlayers)
                        ctwindow = f as RankingPlayers;
                }

                if (ctwindow == null)
                    ctwindow = new RankingPlayers(connect, IS);

                ctwindow.MdiParent = this;
                ctwindow.Show();
            }
            else MessageBox.Show("Ошибка!!!", "Отсутствует соединение с БД",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ToolStripMenuItemAssessReferee_Click(object sender, EventArgs e)
        {
            try
            {
                ReportAssessRefereeWnd wnd = new ReportAssessRefereeWnd(connect, IS);

                wnd.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}