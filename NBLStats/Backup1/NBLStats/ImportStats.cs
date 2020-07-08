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
    public struct STLoadFileInfo
    {
        public int iIdSeason;
        public string strFileName;
        public DateTime dtWrite;
        public int iErrorCode;
    }


    public partial class ImportStats : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CParamApp clParam;

        CFileInfo clFileInfo;

        STLoadFileInfo fileinfo;

        CRecordsPerson clRecords;
        List<STRecordsPerson> lst_records;

        bool brec;

        public ImportStats(SqlConnection cn, STInfoSeason si)
        {
            InitializeComponent();

            connect = cn;
            IS = si;
        }

        private void ImportStats_Load(object sender, EventArgs e)
        {
            try
            {
                clParam = new CParamApp();

                clFileInfo = new CFileInfo(connect);
                clRecords = new CRecordsPerson(connect);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void StartProc(object sender, DoWorkEventArgs e)
        {
            string[] files; // каталог с файлами
            STFileInfo stFI;
            
            try
            {
                // находим все файлы для закачки
                files = Directory.GetFiles(clParam.s_Path.pathsgmfile, "NBL*?.sgm");

                // цикл по ним
                foreach (string file in files)
                {
                    // если нажата кнопка отмена - выскакиваем
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        backgroundWorker1.ReportProgress(0);
                        return;
                    }

                    FileInfo FI = new FileInfo(file);

                    stFI = new STFileInfo();
                    stFI.idseason = IS.idseason;
                    stFI.filename = FI.Name;
                    stFI.enterdate = DateTime.Now;

                    // проверяем не записан ли этот файл ранее
                    STFileInfo? inbase = clFileInfo.GetRecord(stFI.idseason, stFI.filename);
                    if (inbase != null)
                    {
                        if (MessageBox.Show(string.Format("Файл {0} был записан ранее. Перезаписать?", FI.Name),
                                "Внимание!",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            clFileInfo.Update(stFI, (STFileInfo)inbase);
                            fileinfo = write_file(file); // перезаписываем

                          //  AddItemToList(fileinfo);
                        }
                    }
                    else
                    {
                        clFileInfo.Insert(stFI);
                        fileinfo = write_file(file); // если не записан такой файл записываем его

                  //      AddItemToList(fileinfo);
                    }

                    // если все хорошо переносим его в архив  и удаляем с пула
                    if (fileinfo.iErrorCode == 0)
                    {
                        string archfile = Path.Combine(clParam.s_Path.pathsgmfilearch, FI.Name);

                        if (File.Exists(archfile))
                            File.Delete(archfile);

                        FI.MoveTo(Path.Combine(clParam.s_Path.pathsgmfilearch, FI.Name));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STLoadFileInfo write_file(string filename)
        {
            STStats stStats;
            STLoadFileInfo ret = new STLoadFileInfo();

            try
            {
                
                ret.iErrorCode = 0;

                CSmartStats clSS = new CSmartStats(filename);

                STGame stGame = clSS.stGame;

                // вычисляем дивизион
                CGame clGame = new CGame(connect);
                STGame rgame = clGame.GetGame(IS.idseason, stGame.idgame);
                int iddiv = (int)rgame.iddivision;

                lst_records = clRecords.GetRecords(iddiv);

                // Записываем игру
                clGame.UpdateSGM(stGame, stGame.idseason, stGame.idgame);

                // Записываем статистику
                CStats clStats = new CStats(connect);

                List<STStats> lst = clSS.stStatsTeam1;

                foreach (STStats item in lst)
                {
                    if (item.ptime > 0)
                    {
                        stStats = verify_player(item);

                        verify_records(stStats);

                        clStats.Insert(stStats);
                    }
                }

                lst = clSS.stStatsTeam2;

                foreach (STStats item in lst)
                {
                    if (item.ptime > 0)
                    {

                        stStats = verify_player(item);

                        verify_records(stStats);

                        clStats.Insert(stStats);

                    }
                }

                // Записываем карту бросков
                CCardTrow clCardTrow = new CCardTrow(connect);

                STCardTrow card = clSS.stCardTrow1;
                clCardTrow.Insert(card);
                card = clSS.stCardTrow2;
                clCardTrow.Insert(card);

                // Записываем статистику тренеров
                CStatsCoach clStatCoach = new CStatsCoach(connect);

                STStatsCoach coach = clSS.stCoach1;
                clStatCoach.Insert(coach);
                coach = clSS.stCoach2;
                clStatCoach.Insert(coach);

                // Записываем статистику судей
                CStatsReferee clStatReferee = new CStatsReferee(connect);

                STStatsReferee referee = clSS.stReferee1_t1;
                clStatReferee.Insert(referee);
                referee = clSS.stReferee1_t2;
                clStatReferee.Insert(referee);
                referee = clSS.stReferee2_t1;
                clStatReferee.Insert(referee);
                referee = clSS.stReferee2_t2;
                clStatReferee.Insert(referee);
                referee = clSS.stStReferee_t1;
                clStatReferee.Insert(referee);
                referee = clSS.stStReferee_t2;
                clStatReferee.Insert(referee);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private STStats verify_player(STStats data)
        {
            STStats ret = new STStats();

            try
            {
                CPlayer clPlayer = new CPlayer(connect, data.idplayer);

                if (clPlayer.stPlayer.idplayer <= 0)
                {
                    ret = data;

                    DlgEntryId dlg = new DlgEntryId(connect, IS, data.idteam, data.idgame, data.number);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ret.idplayer = dlg.GetData();
                    }
                }
                else ret = data;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private void AddItemToList(STLoadFileInfo data)
        {
            string text;

            ListViewItem item;

            try
            {
                if (data.iErrorCode == 0)
                    item = new ListViewItem(data.strFileName);
                else item = new ListViewItem(data.strFileName);
                text = string.Format("{0}", data.dtWrite.ToShortDateString());
                item.SubItems.Add(data.iIdSeason.ToString());
                item.SubItems.Add(text);
                
                listViewFile.Items.Add(item);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                buttonOK.Enabled = false;
                buttonStop.Enabled = true;

                listViewFile.Items.Clear();

                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("После обработки текущего файла процесс записи будет остановлен...", "Внимание!", 
                    MessageBoxButtons.OK,  MessageBoxIcon.Warning);
                
                backgroundWorker1.CancelAsync();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StartProc(sender, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
                AddItemToList(fileinfo);

            progressBarData.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Запись файлов прервана пользователем...","Внимание!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            else if (e.Error != null)
            {
                MessageBox.Show("Error while performing background operation...", "Внимание!", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                
            }
            else
            {
                MessageBox.Show("Запись файлов завершена...", "Внимание!", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }

            //Change the status of the buttons on the UI accordingly
            buttonOK.Enabled = true;
            buttonStop.Enabled = false;

            progressBarData.Value = 0;
            progressBarData.Refresh();
        }

        private void verify_records(STStats stats)
        {
            CRecordsPerson clRec = new CRecordsPerson(connect);

            string text;

            STRecordsPerson newrecord;

            try
            {
                foreach (STRecordsPerson st in lst_records)
                {
                    if (st.coderecord == 1)
                    {
                        if (stats.points > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 1;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.points;

                            text = string.Format("Новый рекорд по очкам. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                    if (st.coderecord == 2)
                    {
                        if (stats.rebounds > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 2;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.rebounds;

                            text = string.Format("Новый рекорд по подборам. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                    if (st.coderecord == 3)
                    {
                        if (stats.assists > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 3;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.assists;

                            text = string.Format("Новый рекорд по результативным передачам. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                    if (st.coderecord == 4)
                    {
                        if (stats.steals > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 4;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.steals;

                            text = string.Format("Новый рекорд по перехватам. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                    if (st.coderecord == 5)
                    {
                        if (stats.blocks > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 5;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.blocks;

                            text = string.Format("Новый рекорд по блок-шотам. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                    if (st.coderecord == 6)
                    {
                        if (stats.hfg > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 6;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.hfg;

                            text = string.Format("Новый рекорд по количеству забитых средних бросков. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                    if (st.coderecord == 7)
                    {
                        if (stats.h3fg > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 7;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.h3fg;

                            text = string.Format("Новый рекорд по количеству забитых дальних бросков. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                    if (st.coderecord == 8)
                    {
                        if (stats.hft > st.result)
                        {
                            newrecord = new STRecordsPerson();
                            newrecord.coderecord = 8;
                            newrecord.iddivision = st.iddivision;
                            newrecord.idgame = stats.idgame;
                            newrecord.idplayer = stats.idplayer;
                            newrecord.idseason = stats.idseason;
                            newrecord.idteam = stats.idteam;
                            newrecord.result = stats.hft;

                            text = string.Format("Новый рекорд по количеству забитых штрафных бросков. Сохранить?");

                            if (MessageBox.Show(text, "Внимание!", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                clRec.Update(newrecord, st);
                                brec = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
