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
    public partial class ReportPreViewWeb : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        List<STGame> list;

        CGame clGame;

        bool prAll;

        public ReportPreViewWeb(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void ReportPreViewWeb_Load(object sender, EventArgs e)
        {
            try
            {
                prAll = false;
                clGame = new CGame(connect);

                init_list_game();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_list_game()
        {
            STGameParam param = new STGameParam();

            param.idseason = IS.idseason;

            try
            {
                checkedListBoxGames.Items.Clear();

                List<STGame> list_all = clGame.GetListGames(param);

                foreach (STGame game in list_all)
                {
                    if (game.idteamwins == null || game.idteamwins <=0)
                         checkedListBoxGames.Items.Add(game.idgame);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                list = read_param();

                create();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool create()
        {
            bool ret = true;

            try
            {
                WebReportTextPreviewGame cl = new WebReportTextPreviewGame(connect, IS, list, prAll);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private List<STGame> read_param()
        {
            List<STGame> ret = new List<STGame>();

            STGame data;

            try
            {
                for (int i = 0; i < checkedListBoxGames.Items.Count; i++)
                {
                    if (checkedListBoxGames.GetItemChecked(i))
                    {
                        int code = int.Parse(checkedListBoxGames.Items[i].ToString());
                        data = clGame.GetGame(IS.idseason, code);

                        ret.Add(data);
                    }
                }

                if (checkBoxAll.Checked == true) prAll = true;
                else prAll = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}
