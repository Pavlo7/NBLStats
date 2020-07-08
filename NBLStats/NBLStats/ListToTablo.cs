using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace NBLStats
{
    public partial class ListToTablo : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        CParamApp clParamApp;

        string fullpath;
        string filename;

        DateTime param;

        public ListToTablo(SqlConnection cn, STInfoSeason si)
        {
            InitializeComponent();

            connect = cn;
            IS = si;
        }

        private void ListToTablo_Load(object sender, EventArgs e)
        {
            clParamApp = new CParamApp();

            filename = "табло.txt";

            fullpath = Path.Combine(clParamApp.s_Path.pathreport, filename);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            param = new DateTime(dateTimePickerDate.Value.Year, dateTimePickerDate.Value.Month, 
                dateTimePickerDate.Value.Day, 0,0,0,0);
            create();
            DialogResult = DialogResult.OK;
        }

        private void create()
        {
            try
            {
                FileInfo fi1 = new FileInfo(fullpath);
                StreamWriter sw = fi1.CreateText();

                CEntryTeam clET = new CEntryTeam(connect);

                CEntryPlayers clEP = new CEntryPlayers(connect);
                List<STEntryPlayers> list_p;

                CPlayer clPlayer;

                string text;

                string number;

                List<STEntryTeamWithName> lst = clET.GetTeamParticipantWithName(IS.idseason, 
                    "EntryTeam.IdDivision, Team.NameTeam");

                foreach (STEntryTeamWithName team in lst)
                {
                    sw.WriteLine("-");
                    sw.WriteLine(team.name.ToString().ToUpper());

                    list_p = clEP.GetListEntryPlayersReal(IS.idseason, team.idteam, param, null);

                    foreach (STEntryPlayers ep in list_p)
                    {
                        if (ep.priority == 0)
                        {
                            clPlayer = new CPlayer(connect, ep.idplayer);

                            number = "0";

                            if (ep.number.Length > 0 && ep.number.Length <= 2)
                                number = ep.number;

                            text = string.Format("{0} {1}", number, clPlayer.stPlayer.family);
                            sw.WriteLine(text);
                        }
                    }
                }

                sw.WriteLine("-");
                sw.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
