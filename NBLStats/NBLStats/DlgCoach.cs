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
    public partial class DlgCoach : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STCoach gstCoach;
        CCoach clCoach;
        CParamApp clParam;
        int gid;

        public DlgCoach(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            clCoach = new CCoach(connect);
            clParam = new CParamApp();

            gid = clCoach.GetFreeId();

            caption = "Новый тренер";
        }

        public DlgCoach(SqlConnection cn, ushort md, STCoach st)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstCoach = st;

            gid = gstCoach.idcoach;

            clCoach = new CCoach(connect);
            clParam = new CParamApp();

            caption = "Редактировать данные тренера";
        }


        private void DlgCoach_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                init_combo_country();

                set_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void init_combo_country()
        {
            try
            {
                comboBoxCountry.Items.Clear();

                CCountry cl = new CCountry(connect);
                List<STCountry> lst = cl.GetListCountry();

                foreach (STCountry item in lst)
                {
                    comboBoxCountry.Items.Add(item.shortname);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void set_data()
        {
            CCountry clCo;

            try
            {
                textBoxId.Text = gid.ToString();

                if (gstCoach.idcoach != 0)
                {
                    textBoxFamily.Text = gstCoach.family;
                    textBoxName.Text = gstCoach.name;
                    textBoxSecondName.Text = gstCoach.payname;
                    if (gstCoach.datebirth != null)
                        dateTimePickerDateBirth.Value = (DateTime)gstCoach.datebirth;
                    textBoxPersonalNum.Text = gstCoach.personalnum;

                    if (gstCoach.idcountry != null)
                    {
                        clCo = new CCountry(connect, (int)gstCoach.idcountry);
                        comboBoxCountry.Text = clCo.stCountry.shortname;
                    }

                    textBoxDescript.Text = gstCoach.descript;

                    if (gstCoach.namefoto != null && gstCoach.namefoto.Length > 0)
                    {
                        string pathfoto = string.Format("{0}\\{1}", clParam.s_Path.pathfoto, gstCoach.namefoto);

                        FileInfo fi = new FileInfo(pathfoto);
                        if (fi.Exists)
                        {
                            labelNameFoto.Text = gstCoach.namefoto;

                            Bitmap bt = new Bitmap(pathfoto);
                            pictureBoxFoto.Image = bt; ;
                        }
                        else
                            MessageBox.Show(string.Format("Файл {0} не найден", pathfoto),
                                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STCoach read_data()
        {
            STCoach ret = new STCoach();

            CCountry clCo;

            try
            {
                ret.idcoach = gid;

                if (textBoxFamily.Text.Length > 0)
                    ret.family = textBoxFamily.Text;
                else ret.family = null;

                if (textBoxName.Text.Length > 0)
                    ret.name = textBoxName.Text;
                else ret.name = null;

                if (textBoxSecondName.Text.Length > 0)
                    ret.payname = textBoxSecondName.Text;
                else ret.payname = null;

                ret.datebirth = new DateTime(dateTimePickerDateBirth.Value.Year,
                    dateTimePickerDateBirth.Value.Month, dateTimePickerDateBirth.Value.Day, 0, 0, 0, 0);

                if (textBoxPersonalNum.Text.Length > 0)
                    ret.personalnum = textBoxPersonalNum.Text;
                else ret.personalnum = null;

                if (comboBoxCountry.Text.Length > 0)
                {
                    string c = comboBoxCountry.Text;

                    clCo = new CCountry(connect, c);

                    ret.idcountry = clCo.stCountry.id;
                }
                else ret.idcountry = 0;

                if (labelNameFoto.Text.Length > 0)
                    ret.namefoto = labelNameFoto.Text.Trim();
                else ret.namefoto = null;

                if (textBoxDescript.Text.Length > 0)
                    ret.descript = textBoxDescript.Text;
                else ret.descript = null;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private void ToolStripMenuItemSelectFoto_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogFoto.InitialDirectory = clParam.s_Path.pathfoto;
                openFileDialogFoto.Filter = "Формат BMP (*.bmp)|*.bmp|Формат GIF (*.gif)|*.gif|Формат JPEG(*.jpeg)|*.jpeg";
                openFileDialogFoto.RestoreDirectory = true;
                openFileDialogFoto.FileName = "";

                string pathfoto = null;
                string namefoto = null;

                if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo dir = new DirectoryInfo(openFileDialogFoto.FileName);
                    namefoto = dir.Name;
                    labelNameFoto.Text = dir.Name;
                    pathfoto = string.Format("{0}\\{1}", clParam.s_Path.pathfoto, namefoto);
                    Bitmap bt = new Bitmap(pathfoto);
                    pictureBoxFoto.Image = bt; ;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void ToolStripMenuItemDeleteFoto_Click(object sender, EventArgs e)
        {
            pictureBoxFoto.Image = null;
            labelNameFoto.Text = null;
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

            STCoach data = new STCoach();

            data = read_data();

            if (gstCoach.idcoach != 0)
                ret = clCoach.Update(data, gstCoach.idcoach);
            else
                ret = clCoach.Insert(data);

            return ret;
        }

        public int RetId()
        {
            return gid;
        }
    }
}