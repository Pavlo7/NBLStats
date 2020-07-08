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
    public partial class DlgStats : Form
    {
        SqlConnection connect;
        ushort mode;
        STStats gSTStats;

        int idseason;
        int idgame;
        int idteam;
        int idplayer;
        string number;

        int type;

        CStats clStats;
        STStats stC;

        public DlgStats(SqlConnection cn, ushort md, int ids, int idg, int idt,int idp, string n)
        {
            InitializeComponent();

            connect = cn;
            idseason = ids;
            idgame = idg;
            idteam = idt;
            idplayer = idp;
            number = n;

            type = 0;
        }

        public DlgStats(SqlConnection cn, ushort md, STStats st)
        {
            InitializeComponent();

            connect = cn;
            gSTStats = st;
            idseason = gSTStats.idseason;
            idgame = gSTStats.idgame;
            idteam = gSTStats.idteam;
            idplayer = gSTStats.idplayer;

            type = 1;
        }

        private void DlgStats_Load(object sender, EventArgs e)
        {
            try
            {
                CPlayer pl = new CPlayer(connect, idplayer);
                string text = string.Format("{0} {1}",pl.stPlayer.family, pl.stPlayer.name);
                labelName.Text = text;

                if (type == 0)
                    textBoxNumber.Text = number;
                if (type == 1)
                    set_data();

                textBoxNumber.Select();
                textBoxNumber.Focus();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                stC = read_data();

                clStats = new CStats(connect);

                if (type == 0)
                {
                    if (clStats.Insert(stC)) DialogResult = DialogResult.OK;
                }
                else if(type == 1)
                {
                    if (clStats.Update(stC, gSTStats.idseason, gSTStats.idgame, gSTStats.idplayer)) 
                        DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data()
        {
            try
            {
                textBoxNumber.Text = gSTStats.number.ToString();
                
                if (gSTStats.flagstart == 1) checkBoxStart.CheckState = CheckState.Checked;
                else checkBoxStart.CheckState = CheckState.Unchecked;

                textBoxPoints.Text = gSTStats.points.ToString();

                numericUpDownAFG.Text = gSTStats.afg.ToString();
                numericUpDownHFG.Text = gSTStats.hfg.ToString();
                numericUpDownA3FG.Text = gSTStats.a3fg.ToString();
                numericUpDownH3FG.Text = gSTStats.h3fg.ToString();
                numericUpDownAFT.Text = gSTStats.aft.ToString();
                numericUpDownHFT.Text = gSTStats.hft.ToString();

                textBoxRebounds.Text = gSTStats.rebounds.ToString();
                numericUpDownRebIts.Text = gSTStats.rebits.ToString();
                numericUpDownRebStg.Text = gSTStats.rebstg.ToString();

                numericUpDownAssists.Text = gSTStats.assists.ToString();
                numericUpDownSteals.Text = gSTStats.steals.ToString();
                numericUpDownBlock.Text = gSTStats.blocks.ToString();
                numericUpDownFoulsAdv.Text = gSTStats.foulsadv.ToString();

                numericUpDownFouls.Text = gSTStats.psfouls.ToString();
                numericUpDownFoulsU.Text = gSTStats.foulsu.ToString();
                numericUpDownFoulsT.Text = gSTStats.foulst.ToString();
                numericUpDownFoulsD.Text = gSTStats.foulsd.ToString();
                numericUpDownFoulsDash.Text = gSTStats.foulsdash.ToString();

                textBoxTurnovers.Text = gSTStats.turnovers.ToString();
                numericUpDownTurnAss.Text = gSTStats.turnass.ToString();
                numericUpDownTurnTeh.Text = gSTStats.turnteh.ToString();

                textBoxTime.Text = gSTStats.ptime.ToString();
                textBoxPM.Text = gSTStats.pm.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STStats read_data()
        {
            STStats ret = new STStats();

            try
            {
                /* идентификатор сезона */
                ret.idseason = idseason;
                /* идентификатор команды */
                ret.idteam = idteam;
                /* идентификатор игры */
                ret.idgame = idgame;
                /* идентификатор игрока */
                ret.idplayer = idplayer;
                /* номер */
                if (textBoxNumber.Text.Length > 0)
                    ret.number = textBoxNumber.Text.Trim();
                else ret.number = null;
                /* стартовый состав */
                if (checkBoxStart.Checked == true)
                    ret.flagstart = 1;
                else ret.flagstart = 0;
                /* очки */
                if (textBoxPoints.Text.Length > 0)
                    ret.points = int.Parse(textBoxPoints.Text.Trim());
                else ret.points = 0;
                /* броски */
                if (numericUpDownAFG.Text.Length > 0)
                    ret.afg = int.Parse(numericUpDownAFG.Text.Trim());
                else ret.afg = 0;
                if (numericUpDownHFG.Text.Length > 0)
                    ret.hfg = int.Parse(numericUpDownHFG.Text.Trim());
                else ret.hfg = 0;
                if (numericUpDownA3FG.Text.Length > 0)
                    ret.a3fg = int.Parse(numericUpDownA3FG.Text.Trim());
                else ret.a3fg = 0;
                if (numericUpDownH3FG.Text.Length > 0)
                    ret.h3fg = int.Parse(numericUpDownH3FG.Text.Trim());
                else ret.h3fg = 0;
                if (numericUpDownAFT.Text.Length > 0)
                    ret.aft = int.Parse(numericUpDownAFT.Text.Trim());
                else ret.aft = 0;
                if (numericUpDownHFT.Text.Length > 0)
                    ret.hft = int.Parse(numericUpDownHFT.Text.Trim());
                else ret.hft = 0;
                /* подборы */
                if (textBoxRebounds.Text.Length > 0)
                    ret.rebounds = int.Parse(textBoxRebounds.Text.Trim());
                else ret.rebounds = 0;
                if (numericUpDownRebIts.Text.Length > 0)
                    ret.rebits = int.Parse(numericUpDownRebIts.Text.Trim());
                else ret.rebits = 0;
                if (numericUpDownRebStg.Text.Length > 0)
                    ret.rebstg = int.Parse(numericUpDownRebStg.Text.Trim());
                else ret.rebstg = 0;
                /* передачи */
                if (numericUpDownAssists.Text.Length > 0)
                    ret.assists = int.Parse(numericUpDownAssists.Text.Trim());
                else ret.assists = 0;
                /* перехваты */
                if (numericUpDownSteals.Text.Length > 0)
                    ret.steals = int.Parse(numericUpDownSteals.Text.Trim());
                else ret.steals = 0;
                /* блоки */
                if (numericUpDownBlock.Text.Length > 0)
                    ret.blocks = int.Parse(numericUpDownBlock.Text.Trim());
                else ret.blocks = 0;
                /* фолы соперников */
                if (numericUpDownFoulsAdv.Text.Length > 0)
                    ret.foulsadv = int.Parse(numericUpDownFoulsAdv.Text.Trim());
                else ret.foulsadv = 0;
                /* фолы*/
                if (numericUpDownFouls.Text.Length > 0)
                    ret.psfouls = int.Parse(numericUpDownFouls.Text.Trim());
                else ret.psfouls = 0;
                if (numericUpDownFoulsU.Text.Length > 0)
                    ret.foulsu = int.Parse(numericUpDownFoulsU.Text.Trim());
                else ret.foulsu = 0;
                if (numericUpDownFoulsT.Text.Length > 0)
                    ret.foulst = int.Parse(numericUpDownFoulsT.Text.Trim());
                else ret.foulst = 0;
                if (numericUpDownFoulsD.Text.Length > 0)
                    ret.foulsd = int.Parse(numericUpDownFoulsD.Text.Trim());
                else ret.foulsd = 0;
                if (numericUpDownFoulsDash.Text.Length > 0)
                    ret.foulsdash = int.Parse(numericUpDownFoulsDash.Text.Trim());
                else ret.foulsdash = 0;
                /* потери */
                if (textBoxTurnovers.Text.Length > 0)
                    ret.turnovers = int.Parse(textBoxTurnovers.Text.Trim());
                else ret.turnovers = 0;
                if (numericUpDownTurnAss.Text.Length > 0)
                    ret.turnass = int.Parse(numericUpDownTurnAss.Text.Trim());
                else ret.turnass = 0;
                if (numericUpDownTurnTeh.Text.Length > 0)
                    ret.turnteh = int.Parse(numericUpDownTurnTeh.Text.Trim());
                else ret.turnteh = 0;
                /* потери */
                if (textBoxTime.Text.Length > 0)
                    ret.ptime = int.Parse(textBoxTime.Text.Trim());
                else ret.ptime = 0;
                /* +\- */
                if (textBoxPM.Text.Length > 0)
                    ret.pm = int.Parse(textBoxPM.Text.Trim());
                else ret.pm = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        public STStats GetFl()
        {
            return stC;
        }

        private void numericUpDownHFG_ValueChanged(object sender, EventArgs e)
        {
            set_points();
        }
        private void numericUpDownH3FG_ValueChanged(object sender, EventArgs e)
        {
            set_points();
        }
        private void numericUpDownHFT_ValueChanged(object sender, EventArgs e)
        {
            set_points();
        }

        private void set_points()
        {
            try
            {
                int hfg = 0, h3fg = 0, hft = 0;
                            
                hfg = (int)numericUpDownHFG.Value;
                h3fg = (int)numericUpDownH3FG.Value;
                hft = (int)numericUpDownHFT.Value;

                int points = (hfg * 2) + (h3fg * 3) + hft;

                if (points > 0)
                    textBoxPoints.Text = points.ToString();
                else textBoxPoints.Text = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void numericUpDownRebIts_ValueChanged(object sender, EventArgs e)
        {
            set_rebounds();
        }
        private void numericUpDownRebStg_ValueChanged(object sender, EventArgs e)
        {
            set_rebounds();
        }

        private void set_rebounds()
        {
            try
            {
                int rebits = 0, rebstg = 0;

                rebits = (int)numericUpDownRebIts.Value;
                rebstg = (int)numericUpDownRebStg.Value;
                int rebounds = rebits + rebstg;

                textBoxRebounds.Text = rebounds.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void numericUpDownTurnAss_ValueChanged(object sender, EventArgs e)
        {
            set_turnovers();
        }

        private void numericUpDownTurnTeh_ValueChanged(object sender, EventArgs e)
        {
            set_turnovers();
        }

        private void set_turnovers()
        {
            try
            {
                int turnass = 0, turnteh = 0;

                turnass = (int)numericUpDownTurnAss.Value;
                turnteh = (int)numericUpDownTurnTeh.Value;
                int turnovers = turnass + turnteh;

                textBoxTurnovers.Text = turnovers.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
       
    }
}