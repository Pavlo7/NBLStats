using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace NBLStats
{
    public partial class ConvertToMySQL : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        MySqlConnection mysql_dbc;
     
        public ConvertToMySQL(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void ConvertToMySQL_Load(object sender, EventArgs e)
        {
            string host; // Имя хоста
            string user; // Имя пользователя
            string database; // Имя базы данных
            string password; // Пароль
            string Connect;// строка для подключения

            password = "123";
            host = "localhost";
            user = "root";
            database = "nbldb";

            Connect = "Database=" + database + ";Datasource=" + host + ";User=" + user + ";Password=" + password +
                ";charset=utf8";

            mysql_dbc = new MySqlConnection(Connect);
            
            mysql_dbc.Open();

            progressBarTable.Visible = true;
            
        }

        bool cnv_infoseason()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;
            
            try
            {
                query = "DELETE FROM InfoSeason";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CInfoSeason cls = new CInfoSeason(connect);

                List<STInfoSeason> lst = cls.GetListSeason();

                foreach (STInfoSeason item in lst)
                {
                    query = "INSERT INTO Nbldb.InfoSeason (IdSeason, NameSeason, DateBegin, DateEnd, CntDivision, CntTeam," +
                        "Flag, FlagEnd) VALUES (@1, @2, @3, @4, @5, @6, @7, @8)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.String, "@2", item.nameseason));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@3", item.datebegin));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@4", item.dateend));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.cntdivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.cntteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.flag));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@8", item.flagend));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_infoseason()");
                ret = false; 
            }

            if (ret == true) add_record("InfoSeason", 0, cnt);
            else add_record("InfoSeason", 1, cnt);

            return ret;
        }
        bool cnv_city()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM City";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CCity cls = new CCity(connect);

                List<STCity> lst = cls.GetListCity();


                foreach (STCity item in lst)
                {
                    query = "INSERT INTO Nbldb.City (IdCity, IdRegion, NameCity) VALUES (@1, @2, @3)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idreg));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_city()");
                ret = false;
            }

            if (ret == true) add_record("City", 0, cnt);
            else add_record("City", 1, cnt);

            return ret;
        }
        bool cnv_award()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Award";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CAward cls = new CAward(connect);

                List<STAward> lst = cls.GetList();


                foreach (STAward item in lst)
                {
                    query = "INSERT INTO Nbldb.Award (IdAward, NameAward) VALUES (@1, @2)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idaward));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.nameaward));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_award()");
                ret = false;
            }

            if (ret == true) add_record("Award", 0, cnt);
            else add_record("Award", 1, cnt);

            return ret;
        }
        bool cnv_awardresult()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM AwardResult";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CAwarsResult cls = new CAwarsResult(connect);

                List<STAwardsResult> lst = cls.GetListData();

                foreach (STAwardsResult item in lst)
                {
                    query = "INSERT INTO Nbldb.AwardResult (IdSeason, IdDivision, IdAward, IdPlayer, Result) " +
                        "VALUES (@1, @2, @3, @4, @5)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idaward));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idplayer));
                    cmd.Parameters.Add(crp(MySqlDbType.Double, "@5", item.result));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_awardresult()");
                ret = false;
            }

            if (ret == true) add_record("AwardResult", 0, cnt);
            else add_record("AwardResult", 1, cnt);

            return ret;
        }
        bool cnv_cardtrow()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM CardTrow";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CCardTrow cls = new CCardTrow(connect);

                List<STCardTrow> lst = cls.GetListCardTrow();

                foreach (STCardTrow item in lst)
                {
                    query = "INSERT INTO Nbldb.CardTrow (IdSeason, IdGame, IdTeam, PointsListMiss1, " +
                        "PointsListMiss2, PointsListMade1, PointsListMade2, FileName) " +
                        "VALUES (@1, @2, @3, @4, @5, @6, @7, @8)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idgame));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.str_lst1_miss));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@5", item.str_lst2_miss));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@6", item.str_lst1_made));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@7", item.str_lst2_made));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@8", item.filename));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_cardtrow()");
                ret = false;
            }

            if (ret == true) add_record("CardTrow", 0, cnt);
            else add_record("CardTrow", 1, cnt);

            return ret;
        }
        bool cnv_coach()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Coach";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CCoach cls = new CCoach(connect);

                List<STCoach> lst = cls.GetList();

                foreach (STCoach item in lst)
                {
                    query = "INSERT INTO Nbldb.Coach (IdCoach, Family, Namep, PayName, DateBirth, " +
                        "PersonalNum, IdCountry, NameFoto, Descript) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idcoach));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.family));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.payname));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@5", item.datebirth));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@6", item.personalnum));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.idcountry));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@8", item.namefoto));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@9", item.descript));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_coach()");
                ret = false;
            }

            if (ret == true) add_record("Coach", 0, cnt);
            else add_record("Coach", 1, cnt);

            return ret;
        }
        bool cnv_compositiongroup()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM CompositionGroup";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CCompositionGroup cls = new CCompositionGroup(connect);

                List<STCompositionGroup> lst = cls.GetList();

                foreach (STCompositionGroup item in lst)
                {
                    query = "INSERT INTO Nbldb.CompositionGroup (IdSeason, IdDivision, IdGroup, IdTeam) " +
                        "VALUES (@1, @2, @3, @4)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idgroup));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idteam));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_compositiongroup()");
                ret = false;
            }

            if (ret == true) add_record("CompositionGroup", 0, cnt);
            else add_record("CompositionGroup", 1, cnt);

            return ret;
        }
        bool cnv_country()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Country";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CCountry cls = new CCountry(connect);

                List<STCountry> lst = cls.GetListCountry();

                foreach (STCountry item in lst)
                {
                    query = "INSERT INTO Nbldb.Country (IdCountry, NameCountry, ShortNameCountry) " +
                        "VALUES (@1, @2, @3)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.shortname));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_country()");
                ret = false;
            }

            if (ret == true) add_record("Country", 0, cnt);
            else add_record("Country", 1, cnt);

            return ret;
        }
        bool cnv_discvalification()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Discvalification";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CDiscvalification cls = new CDiscvalification(connect);

                List<STDiscvalification> lst = cls.GetListData();

                foreach (STDiscvalification item in lst)
                {
                    query = "INSERT INTO Nbldb.Discvalification (IdSeason, IdPart, TypePart, IdTeam, CntGame, " +
                        "DateBegin, DateEnd, Descript, Id, IdDivision) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, " +
                        "@9, @10)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idpart));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.typepart));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.cntgame));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@6", item.datebegin));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@7", item.dateend));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@8", item.descript));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@9", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@10", item.iddivision));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_discvalification()");
                ret = false;
            }

            if (ret == true) add_record("Discvalification", 0, cnt);
            else add_record("Discvalification", 1, cnt);

            return ret;
        }
        bool cnv_division()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Division";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CDivision cls = new CDivision(connect);

                List<STDivision> lst = cls.GetListDivision();

                foreach (STDivision item in lst)
                {
                    query = "INSERT INTO Nbldb.Division (IdSeason, IdDivision, NameDivision, CntTeam, " +
                        "CntPlayerInTeam, FlagReg, CntStageReg, FlagWinsReg, FlagPO, CntTeamPO, CntStagePO, " +
                        "FlagStyk, CntTeamStyk, FlagOut, CntTeamOut, FlagIn, CntTeamIn, DeadLine) " +
                        "VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.cntteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.cntplayer));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.flag_reg));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.cntstagereg));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@8", item.flag_wins_reg));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@9", item.flag_po));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@10", item.cntteampo));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@11", item.cntstagepo));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@12", item.flag_styk));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@13", item.cntteamstyk));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@14", item.flag_out));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@15", item.cntteamout));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@16", item.flag_in));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@17", item.cntteamin));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@18", item.deadline));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_division()");
                ret = false;
            }

            if (ret == true) add_record("Division", 0, cnt);
            else add_record("Division", 1, cnt);

            return ret;
        }
        bool cnv_entryplayers()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM EntryPlayers";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CEntryPlayers cls = new CEntryPlayers(connect);

                List<STEntryPlayers> lst = cls.GetListEntryPlayers();

                foreach (STEntryPlayers item in lst)
                {
                    query = "INSERT INTO Nbldb.EntryPlayers (IdSeason, IdTeam, IdPlayer, Number, Growing," +
                        "Weight, DateIn, DateOut, Amplua) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idplayer));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.number));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.growing));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.weight));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@7", item.datein));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@8", item.dateout));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@9", item.amplua));
                 
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_entryplayers()");
                ret = false;
            }

            if (ret == true) add_record("EntryPlayers", 0, cnt);
            else add_record("EntryPlayers", 1, cnt);

            return ret;
        }
        bool cnv_entryteam()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM EntryTeam";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CEntryTeam cls = new CEntryTeam(connect);

                List<STEntryTeam> lst = cls.GetTeamParticipant();

                foreach (STEntryTeam item in lst)
                {
                    query = "INSERT INTO Nbldb.EntryTeam (IdSeason, IdDivision, IdTeam, DateIn, IdCoach1, " +
                        "IdCoach2, IdCaptain, IdCoach3) VALUES (@1, @2, @3, @4, @5, @6, @7, @8)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@4", item.datein));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.idcoach1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.idcoach2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.idcaptain));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@8", item.idcoach3));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_entryteam()");
                ret = false;
            }

            if (ret == true) add_record("EntryTeam", 0, cnt);
            else add_record("EntryTeam", 1, cnt);

            return ret;
        }
        bool cnv_fileinfo()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM FileInfo";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CFileInfo cls = new CFileInfo(connect);

                List<STFileInfo> lst = cls.GetListData();

                foreach (STFileInfo item in lst)
                {
                    query = "INSERT INTO Nbldb.FileInfo (IdSeason, FileName, EnterDate) VALUES (@1, @2, @3)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.filename));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@3", item.enterdate));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_fileinfo()");
                ret = false;
            }

            if (ret == true) add_record("FileInfo", 0, cnt);
            else add_record("FileInfo", 1, cnt);

            return ret;
        }
        bool cnv_finalresult()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM FinalResult";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CFinalResult cls = new CFinalResult(connect);

                List<STFinalResult> lst = cls.GetData();

                foreach (STFinalResult item in lst)
                {
                    query = "INSERT INTO Nbldb.FinalResult (IdSeason, IdDivision, IdTeam, Rang) " +
                        "VALUES (@1, @2, @3, @4)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.rang));
                  
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_finalresult()");
                ret = false;
            }

            if (ret == true) add_record("FinalResult", 0, cnt);
            else add_record("FinalResult", 1, cnt);

            return ret;
        }
        bool cnv_gamedays()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM GameDays";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CGameDays cls = new CGameDays(connect);

                List<STGameDays> lst = cls.GetData();

                foreach (STGameDays item in lst)
                {
                    query = "INSERT INTO Nbldb.GameDays (DNum, DDate, CntGames, AdminLine, WasherLine," +
                        "IdSeason) VALUES (@1, @2, @3, @4, @5, @6)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.nday));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@2", item.date));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.cntgames));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.adminline));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@5", item.washerline));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.idseason));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_gamedays()");
                ret = false;
            }

            if (ret == true) add_record("GameDays", 0, cnt);
            else add_record("GameDays", 1, cnt);

            return ret;
        }
        bool cnv_games()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Games";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();

                string strtags = null;


                CGame cls = new CGame(connect);

                List<STGameOld> lst = cls.GetListGames();

                STGameTagsPart stTags;
                CTags clTags = new CTags();

                foreach (STGameOld st in lst)
                {
                    if (st.tags == null)
                    {
                        stTags = new STGameTagsPart();
                        stTags.diktor = new List<int>();
                        stTags.foto = new List<int>();
                        stTags.interviewa = new List<int>();
                        stTags.interviewb = new List<int>();
                        stTags.komissar = new List<int>();
                        stTags.report = new List<int>();
                        stTags.secretar = new List<int>();
                        stTags.statist = new List<int>();
                        stTags.svabrist = new List<int>();
                        stTags.tablo = new List<int>();
                        stTags.video = new List<int>();
                        stTags.vrach = new List<int>();
                        stTags.strinterviea = null;
                        stTags.strintervieb = null;

                        if (st.idwriting != null)
                            stTags.secretar.Add((int)st.idwriting);
                        if (st.idoperpanel != null)
                            stTags.tablo.Add((int)st.idoperpanel);
                        if (st.idopervideo != null)
                            stTags.video.Add((int)st.idopervideo);
                        if (st.iddiktor != null)
                            stTags.diktor.Add((int)st.iddiktor);
                        if (st.idmedical != null)
                            stTags.vrach.Add((int)st.idmedical);
                        if (st.idstatister != null)
                            stTags.statist.Add((int)st.idstatister);
                        if (st.idfoto != null)
                            stTags.foto.Add((int)st.idfoto);
                        if (st.idintera != null)
                            stTags.interviewa.Add((int)st.idintera);
                        if (st.idinterb != null)
                            stTags.interviewb.Add((int)st.idinterb);
                        if (st.idsvabra != null)
                            stTags.svabrist.Add((int)st.idsvabra);

                        strtags = clTags.GetStringFromTagsPart(stTags);
                    }
                    else strtags = st.tags;

                    query = "INSERT INTO Nbldb.Games (IdSeason,IdDivision,IdGame,Type,IdStage,NRound,IdGroup," +
                    "DateTimeGame,IdTeam1,IdTeam2,IdPlace,FlagTeh,IdStReferee,IdReferee1,IdReferee2," +
                    "StRefereePoints,Referee1Points,Referee2Points,APer1,APer2,ADopPer,ATeamFouls1,ATeamFouls2," +
                    "ATeamFouls3,ATeamFouls4,APointsPer1,APointsPer2,APointsPer3,APointsPer4,APointsDopPer," +
                    "APoints,BPer1,BPer2,BDopPer,BTeamFouls1,BTeamFouls2,BTeamFouls3,BTeamFouls4,BPointsPer1," +
                    "BPointsPer2,BPointsPer3,BPointsPer4,BPointsDopPer,BPoints,IdTeamWins,ChangeLider," +
                    "MaxPointsTeam1,MaxPointsTeam2,EqualsResult,MaxDiff,CntLook,Descript,Tags,FileName) " +
                    "VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, " +
                    "@19, @20, @21, @22, @23, @24, @25, @26, @27, @28, @29, @30, @31, @32, @33, @34, @35, @36, " +
                    "@37, @38, @39, @40, @41, @42, @43, @44, @45, @46, @47, @48, @49, @50, @51, @52, @53, @54)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", st.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", st.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", st.idgame));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", st.type));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", st.idstage));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", st.round));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", st.idgroup));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@8", st.datetime));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@9", st.idteam1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@10", st.idteam2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@11", st.idplace));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@12", st.flagteh));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@13", st.idstreferee));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@14", st.idreferee1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@15", st.idreferee2));
                    cmd.Parameters.Add(crp(MySqlDbType.Float, "@16", st.stref_assess_team1));
                    cmd.Parameters.Add(crp(MySqlDbType.Float, "@17", st.ref1_assess_team1));
                    cmd.Parameters.Add(crp(MySqlDbType.Float, "@18", st.ref1_assess_team2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@19", st.aper1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@20", st.aper2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@21", st.adopper));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@22", st.ateamfouls1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@23", st.ateamfouls2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@24", st.ateamfouls3));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@25", st.ateamfouls4));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@26", st.apointsper1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@27", st.apointsper2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@28", st.apointsper3));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@29", st.apointsper4));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@30", st.apointsdopper));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@31", st.apoints));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@32", st.bper1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@33", st.bper2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@34", st.bdopper));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@35", st.bteamfouls1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@36", st.bteamfouls2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@37", st.bteamfouls3));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@38", st.bteamfouls4));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@39", st.bpointsper1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@40", st.bpointsper2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@41", st.bpointsper3));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@42", st.bpointsper4));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@43", st.bpointsdopper));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@44", st.bpoints));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@45", st.idteamwins));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@46", st.changelider));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@47", st.maxpointsteam1));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@48", st.maxpointsteam2));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@49", st.equalsresult));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@50", st.maxdiff));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@51", st.cntlook));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@52", st.descript));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@53", strtags));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@54", st.filename));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_games()");
                ret = false;
            }

            if (ret == true) add_record("Games", 0, cnt);
            else add_record("Games", 1, cnt);

            return ret;
        }
        bool cnv_groups()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Groups";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CGroup cls = new CGroup(connect);

                List<STGroup> lst = cls.GetListGroup();

                foreach (STGroup item in lst)
                {
                    query = "INSERT INTO Nbldb.Groups (IdSeason,IdDivision,IdGroup,NameGroup,IdStage," +
                            "CntTeamInGroup,CntTeamInNextStage) VALUES (@1, @2, @3, @4, @5, @6, @7)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idgroup));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.namegroup));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.idstage));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.cntteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.cntteamnext));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_groups()");
                ret = false;
            }

            if (ret == true) add_record("Groups", 0, cnt);
            else add_record("Groups", 1, cnt);

            return ret;
        }
        bool cnv_participant()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Participant";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CParticipant cls = new CParticipant(connect);

                List<STParticipant> lst = cls.GetList();

                foreach (STParticipant item in lst)
                {
                    query = "INSERT INTO Nbldb.Participant (IdParticipant,Family,Namep,PayName,DateBirth," +
                        "PersonalNum,IdCountry,NameFoto,Post,AdminFlag,VisibleFlag) VALUES (@1, @2, @3, @4, " +
                        "@5, @6, @7, @8, @9, @10, @11)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idpart));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.family));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.payname));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@5", item.datebirth));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@6", item.personalnum));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.idcountry));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@8", item.namefoto));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@9", item.post));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@10", item.adminflag));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@11", item.vf));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_participant()");
                ret = false;
            }

            if (ret == true) add_record("Participant", 0, cnt);
            else add_record("Participant", 1, cnt);

            return ret;
        }
        bool cnv_place()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Place";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CPlace cls = new CPlace(connect);

                List<STPlace> lst = cls.GetListPlace();

                foreach (STPlace item in lst)
                {
                    query = "INSERT INTO Nbldb.Place (IdCity,IdPlace,NamePlace,AddressPlace,VisibleFlag) " +
                        "VALUES (@1, @2, @3, @4, @5)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idcity));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.address));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.vf));
                   
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_place()");
                ret = false;
            }

            if (ret == true) add_record("Place", 0, cnt);
            else add_record("Place", 1, cnt);

            return ret;
        }
        bool cnv_player()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Players";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CPlayer cls = new CPlayer(connect);

                List<STPlayer> lst = cls.GetList();

                foreach (STPlayer item in lst)
                {
                    query = "INSERT INTO Nbldb.Players (IdPlayer, Family, Namep, PayName, DateBirth, " +
                        "PersonalNum, IdCountry, NameFoto, Descript) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idplayer));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.family));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.payname));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@5", item.datebirth));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@6", item.personalnum));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.idcountry));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@8", item.namefoto));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@9", item.descript));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_player()");
                ret = false;
            }

            if (ret == true) add_record("Players", 0, cnt);
            else add_record("Players", 1, cnt);

            return ret;
        }
        bool cnv_postment()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Postment";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CPostment cls = new CPostment(connect);

                List<STPostment> lst = cls.GetList();

                foreach (STPostment item in lst)
                {
                    query = "INSERT INTO Nbldb.Postment (IdPost, NamePost, Descript) VALUES (@1, @2, @3)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idpost));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.namepost));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.descript));
                   
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_postment()");
                ret = false;
            }

            if (ret == true) add_record("Postment", 0, cnt);
            else add_record("Postment", 1, cnt);

            return ret;
        }
        bool cnv_recordperson()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM RecordsPerson";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CRecordsPerson cls = new CRecordsPerson(connect);

                List<STRecordsPerson> lst = cls.GetRecords();

                foreach (STRecordsPerson item in lst)
                {
                    query = "INSERT INTO Nbldb.RecordsPerson (IdDivision, CodeRecord, IdPlayer, Result, IdTeam, " +
                        "IdSeason, IdGame) VALUES (@1, @2, @3, @4, @5, @6, @7)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.coderecord));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idplayer));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.result));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.idgame));
                   

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_recordperson()");
                ret = false;
            }

            if (ret == true) add_record("RecordsPerson", 0, cnt);
            else add_record("RecordsPerson", 1, cnt);

            return ret;
        }
        bool cnv_referee()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Referee";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CReferee cls = new CReferee(connect);

                List<STReferee> lst = cls.GetList();

                foreach (STReferee item in lst)
                {
                    query = "INSERT INTO Nbldb.Referee (IdReferee, Family, Namep, PayName, DateBirth, " +
                        "PersonalNum, IdCountry, NameFoto, Descript, Category, VisibleFlag) VALUES (@1, @2, " +
                        "@3, @4, @5, @6, @7, @8, @9, @10, @11)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idref));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.family));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.payname));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@5", item.datebirth));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@6", item.personalnum));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.idcountry));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@8", item.namefoto));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@9", item.descript));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@10", item.category));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@11", item.vf));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_referee()");
                ret = false;
            }

            if (ret == true) add_record("Referee", 0, cnt);
            else add_record("Referee", 1, cnt);

            return ret;
        }
        bool cnv_region()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Region";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CRegion cls = new CRegion(connect);

                List<STRegion> lst = cls.GetListRegion();

                foreach (STRegion item in lst)
                {
                    query = "INSERT INTO Nbldb.Region (IdRegion,IdCountry,NameRegion,ShortNameRegion) " +
                        "VALUES (@1, @2, @3, @4)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idcountry));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.shortname));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_region()");
                ret = false;
            }

            if (ret == true) add_record("Region", 0, cnt);
            else add_record("Region", 1, cnt);

            return ret;
        }
        bool cnv_scheme()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Scheme";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CScheme cls = new CScheme(connect);

                List<STScheme> lst = cls.GetListScheme();

                foreach (STScheme item in lst)
                {
                    query = "INSERT INTO Nbldb.Scheme (IdSeason, IdDivision, Type, IdStage, NameStage, " +
                        "CntRound) VALUES (@1, @2, @3, @4, @5, @6)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.iddivision));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.type));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idstage));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@5", item.namestage));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.cntround));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_scheme()");
                ret = false;
            }

            if (ret == true) add_record("Scheme", 0, cnt);
            else add_record("Scheme", 1, cnt);

            return ret;
        }
        bool cnv_statcoach()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM StatCoach";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CStatsCoach cls = new CStatsCoach(connect);

                List<STStatsCoach> lst = cls.GetListData();

                foreach (STStatsCoach item in lst)
                {
                    query = "INSERT INTO Nbldb.StatCoach (IdSeason, IdGame, IdTeam, IdCoach, CntFoulsT, " +
                        "CntFoulsD, FileName) VALUES (@1, @2, @3, @4, @5, @6, @7)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idgame));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idcoach));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.cntfoulst));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.cntfoulsd));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@7", item.filename));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_statcoach()");
                ret = false;
            }

            if (ret == true) add_record("StatCoach", 0, cnt);
            else add_record("StatCoach", 1, cnt);

            return ret;
        }
        bool cnv_statplayer()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM StatPlayer";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();

                labelTable.Text = "StatPlayer";
                

                CStats cls = new CStats(connect);

                List<STStats> lst = cls.GetStats();

                progressBarTable.Minimum = 1;
                progressBarTable.Maximum = lst.Count;
                progressBarTable.Value = 1;
                progressBarTable.Step = 1;

                foreach (STStats st in lst)
                {

                    query = "INSERT INTO Nbldb.StatPlayer (IdSeason,IdGame,IdTeam,IdPlayer,Number,FlagStart,Points," +
                    "AFG,HFG,A3FG,H3FG,AFT,HFT,Rebounds,Rebits,Rebstg,Assists,Steals,Blocks,Turnovers,Turnass," +
                    "Turnteh,Dunks,Breakouts,Foulsadv,PsFouls,Foulsdash,FoulsT,FoulsD,FoulsU,PM,PTime,FileName) " +
                    "VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, " +
                    "@19, @20, @21, @22, @23, @24, @25, @26, @27, @28, @29, @30, @31, @32, @33)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", st.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", st.idgame));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", st.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", st.idplayer));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", st.number));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", st.flagstart));
                    cmd.Parameters.Add(crp(MySqlDbType.Float, "@7", st.points));
                    cmd.Parameters.Add(crp(MySqlDbType.Float, "@8", st.afg));
                    cmd.Parameters.Add(crp(MySqlDbType.Float, "@9", st.hfg));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@10", st.a3fg));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@11", st.h3fg));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@12", st.aft));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@13", st.hft));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@14", st.rebounds));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@15", st.rebits));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@16", st.rebstg));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@17", st.assists));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@18", st.steals));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@19", st.blocks));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@20", st.turnovers));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@21", st.turnass));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@22", st.turnteh));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@23", st.dank));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@24", st.breakouts));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@25", st.foulsadv));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@26", st.psfouls));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@27", st.foulsdash));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@28", st.foulst));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@29", st.foulsd));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@30", st.foulsu));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@31", st.pm));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@32", st.ptime));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@33", st.filename));
                  
                    cmd.ExecuteNonQuery();

                    cnt++;
                    progressBarTable.PerformStep();
                    progressBarTable.Refresh();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_statplayer()");
                ret = false;
            }

            if (ret == true) add_record("StatPlayer", 0, cnt);
            else add_record("StatPlayer", 1, cnt);

            return ret;
        }
        bool cnv_statreferee()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM StatReferee";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CStatsReferee cls = new CStatsReferee(connect);

                List<STStatsReferee> lst = cls.GetListData();

                foreach (STStatsReferee item in lst)
                {
                    query = "INSERT INTO Nbldb.StatReferee (IdSeason, IdGame, IdReferee, IdTeam, CntFoulsP, " +
                        "CntFoulsU, CntFoulsT, CntFoulsD, CntFoulsC, CntFoulsB, FileName) " +
                        "VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idgame));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idreferee));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.cntfoulsp));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@6", item.cntfoulsu));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@7", item.cntfoulst));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@8", item.cntfoulsd));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@9", item.cntfoulsc));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@10", item.cntfoulsb));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@11", item.filename));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_statreferee()");
                ret = false;
            }

            if (ret == true) add_record("StatReferee", 0, cnt);
            else add_record("StatReferee", 1, cnt);

            return ret;
        }
        bool cnv_team()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM Team";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CTeam cls = new CTeam(connect);

                List<STTeam> lst = cls.GetListTeam(0);

                foreach (STTeam item in lst)
                {
                    query = "INSERT INTO Nbldb.Team (IdTeam, NameTeam, IdCity, IdPrev, LatinName) " +
                        "VALUES (@1, @2, @3, @4, @5)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.idcity));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idprev));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@5", item.latinname));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_team()");
                ret = false;
            }

            if (ret == true) add_record("Team", 0, cnt);
            else add_record("Team", 1, cnt);

            return ret;
        }
        bool cnv_technicfouls()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM TehnicFouls";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CTehnicFouls cls = new CTehnicFouls(connect);

                List<STTehnicFouls> lst = cls.GetListData();

                foreach (STTehnicFouls item in lst)
                {
                    query = "INSERT INTO Nbldb.TehnicFouls (IdSeason, IdPart, TypePart, IdTeam, IdGame, Date, " +
                        "Descript, Id, IdReferee) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idpart));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@3", item.typepart));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@4", item.idteam));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@5", item.idgame));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@6", item.date));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@7", item.descript));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@8", item.id));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@9", item.idreferee));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_technicfouls()");
                ret = false;
            }

            if (ret == true) add_record("TehnicFouls", 0, cnt);
            else add_record("TehnicFouls", 1, cnt);

            return ret;
        }
        bool cnv_voteallstarsgame()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM VoteAllStarsGame";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CVoteAllStarsGame cls = new CVoteAllStarsGame(connect);

                List<STVoteASG> lst = cls.GetList();

                foreach (STVoteASG item in lst)
                {
                    query = "INSERT INTO Nbldb.VoteAllStarsGame (IdSeason, Name, Email, IP, EnterDate, " +
                        "VoteData) VALUES (@1, @2, @3, @4, @5, @6)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@2", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.email));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.ip));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@5", item.ed));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@6", item.data));
                    
                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_voteallstarsgame()");
                ret = false;
            }

            if (ret == true) add_record("VoteAllStarsGame", 0, cnt);
            else add_record("VoteAllStarsGame", 1, cnt);

            return ret;
        }
        bool cnv_votepca()
        {
            bool ret = true;

            string query;
            MySqlCommand cmd;

            int cnt = 0;

            try
            {
                query = "DELETE FROM VotePCA";
                cmd = new MySqlCommand(query, mysql_dbc);
                cmd.ExecuteNonQuery();


                CVotePCA cls = new CVotePCA(connect);

                List<STVotePCA> lst = cls.GetList();

                foreach (STVotePCA item in lst)
                {
                    query = "INSERT INTO Nbldb.VotePCA (IdSeason, IdPlayer, Name, Email, IP, EnterDate, " +
                        "IdDivision) VALUES (@1, @2, @3, @4, @5, @6, @7)";

                    cmd = new MySqlCommand(query, mysql_dbc);

                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@1", item.idseason));
                    cmd.Parameters.Add(crp(MySqlDbType.Int32, "@2", item.idplayer));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@3", item.name));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@4", item.email));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@5", item.ip));
                    cmd.Parameters.Add(crp(MySqlDbType.DateTime, "@6", item.ed));
                    cmd.Parameters.Add(crp(MySqlDbType.VarChar, "@7", item.iddivision));

                    cmd.ExecuteNonQuery();

                    cnt++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::cnv_votepca()");
                ret = false;
            }

            if (ret == true) add_record("VotePCA", 0, cnt);
            else add_record("VotePCA", 1, cnt);

            return ret;
        }
     

        private MySqlParameter crp(MySqlDbType type, string pname, object val)
        {
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = pname;
            param.MySqlDbType = type;
            param.Value = val;
            
            return param;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                listViewData.Items.Clear();


                //cnv_infoseason();
                //cnv_city();
                //cnv_award();
                //cnv_awardresult();
                //cnv_cardtrow();
                //cnv_coach();
                //cnv_compositiongroup();
                //cnv_country();
                //cnv_discvalification();
                //cnv_division();
                //cnv_entryplayers();
                //cnv_entryteam();
                //cnv_fileinfo();
                //cnv_finalresult();
                //cnv_gamedays();
                //cnv_games();
                //cnv_groups();
                //cnv_participant();
                //cnv_place();
                //cnv_player();
                //cnv_postment();
                //cnv_recordperson();
                //cnv_referee();
                //cnv_region();
                //cnv_scheme();
                //cnv_statcoach();
                //cnv_statplayer();
                //cnv_statreferee();
                //cnv_team();
                //cnv_technicfouls();
                //cnv_voteallstarsgame();
                cnv_votepca();
            }
            catch (Exception ex) {MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::buttonOK_Click()"); }
        }

        private void add_record(string table, int result, int cnt)
        {
            ListViewItem listview;

            try
            {
                if (result == 0)
                {
                    listview = new ListViewItem(table,0);
                    listview.SubItems.Add("OK");
                }
                else
                {
                    listview = new ListViewItem(table,1);
                    listview.SubItems.Add("ERROR");
                }
                listview.SubItems.Add(cnt.ToString());

                listViewData.Items.Add(listview);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source + " ConvertToMySQL::add_record()"); }
        }
    }
}
