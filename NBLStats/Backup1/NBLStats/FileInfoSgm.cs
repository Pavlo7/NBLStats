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
    public partial class FileInfoSgm : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        bool g_f;

        CFileInfo  clWork;
        List<STFileInfo> list;

        STFileInfo flawour;
        int gpos;

        public FileInfoSgm(SqlConnection cn, STInfoSeason st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = st;
            mode = md;
        }

        private void FileInfoSgm_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                clWork = new CFileInfo(connect);
             
                gpos = 0;

                init_data();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_data()
        {
            try
            {
                dataGridViewFileInfo.Rows.Clear();

                list = clWork.GetListData(IS.idseason);

                if (list.Count > 0)
                {
                    dataGridViewFileInfo.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {
                        dataGridViewFileInfo.Rows[i].Cells[0].Value = list[i].filename;
                        dataGridViewFileInfo.Rows[i].Cells[1].Value = list[i].enterdate.ToString();
                    }

                    dataGridViewFileInfo.AllowUserToAddRows = false;
                }
                else dataGridViewFileInfo.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void ToolStripMenuItemDeleteFileInfo_Click(object sender, EventArgs e)
        {
            string text = null;
            try
            {
                STFileInfo data = GetSelectionData();

                if (data.filename != null)
                {
                    text = string.Format("Вы действиетльно желаете файл {0}?", data.filename);

                    if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        == DialogResult.OK)
                    {
                        clWork.Delete(data);
                        init_data();

                        CGame clGame = new CGame(connect);
                        clGame.Delete(data.idseason, data.filename);

                        CStats clStats = new CStats(connect);
                        clStats.Delete(data.idseason, data.filename);

                        CCardTrow lcCardTrow = new CCardTrow(connect);
                        lcCardTrow.Delete(data.idseason, data.filename);

                        CStatsCoach clStatsCoach = new CStatsCoach(connect);
                        clStatsCoach.Delete(data.idseason, data.filename);

                        CStatsReferee lcStatsReferee = new CStatsReferee(connect);
                        lcStatsReferee.Delete(data.idseason, data.filename);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STFileInfo GetSelectionData()
        {

            STFileInfo ret = new STFileInfo();

            string fn;

            try
            {
                foreach (DataGridViewRow item in dataGridViewFileInfo.SelectedRows)
                {
                    if (item.Cells[0].Value != null)
                    {
                        fn = item.Cells[0].Value.ToString();

                        STFileInfo? df = clWork.GetRecord(IS.idseason, fn);

                        if (df != null) ret = (STFileInfo)df;
                        else ret.filename = null;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}
