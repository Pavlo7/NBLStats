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
    public partial class DlgImportTimePM : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        string temp_path;
        
        public DlgImportTimePM(SqlConnection cn, STInfoSeason si)
        {
            InitializeComponent();
            connect = cn;
            IS = si;
        }

        private void DlgImportTimePM_Load(object sender, EventArgs e)
        {
            try
            {
                temp_path = "D:\\Баскетбол\\Импорт\\";
                labelPath.Text = temp_path;

                init_spool(temp_path);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_spool(string path)
        {
            try
            {
                listBoxSpool.Items.Clear();

                string[] files = Directory.GetFiles(path, "pm.xls");
                foreach (string file in files)
                {
                    FileInfo FI = new FileInfo(file);
                    listBoxSpool.Items.Add(FI.Name);
                }

                files = Directory.GetFiles(path, "time.xls");
                foreach (string file in files)
                {
                    FileInfo FI = new FileInfo(file);
                    listBoxSpool.Items.Add(FI.Name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialogPath.ShowDialog() == DialogResult.OK)
                {
                    temp_path = folderBrowserDialogPath.SelectedPath;
                    labelPath.Text = temp_path;
                    init_spool(temp_path);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxResult.Items.Clear();
                ExcelImportData cl = new ExcelImportData(connect, IS);

                string[] files = Directory.GetFiles(temp_path, "pm.xls");
                foreach (string file in files)
                {
                    FileInfo FI = new FileInfo(file);
                    if (cl.ImportPM(FI.FullName))
                        listBoxResult.Items.Add("Файл +\\- импортирован");
                    else listBoxResult.Items.Add("Ошибка импорта файла +\\-");
                }

                files = Directory.GetFiles(temp_path, "time.xls");
                foreach (string file in files)
                {
                    FileInfo FI = new FileInfo(file);
                    if (cl.ImportTime(FI.FullName))
                        listBoxResult.Items.Add("Файл времени импортирован");
                    else listBoxResult.Items.Add("Ошибка импорта файла времени");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
