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
    public partial class DlgParticipant : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STParticipant gstParticipant;
        CParticipant clParticipant;
        CParamApp clParam;
        int gid;

        public DlgParticipant(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            clParticipant = new CParticipant(connect);
            clParam = new CParamApp();

            gid = clParticipant.GetFreeId();

            caption = "Новый участник";
        }

        public DlgParticipant(SqlConnection cn, ushort md, STParticipant st)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstParticipant = st;

            gid = gstParticipant.idpart;

            clParticipant = new CParticipant(connect);
            clParam = new CParamApp();

            caption = "Редактировать данные участника";
        }

        private void DlgParticipant_Load(object sender, EventArgs e)
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

                if (gstParticipant.idpart != 0)
                {
                    textBoxFamily.Text = gstParticipant.family;
                    textBoxName.Text = gstParticipant.name;
                    if (gstParticipant.payname != null)
                        textBoxSecondName.Text = gstParticipant.payname;
                    if (gstParticipant.datebirth != null)
                        dateTimePickerDateBirth.Value = (DateTime)gstParticipant.datebirth;

                    if (gstParticipant.adminflag == 1) checkBoxNBL.CheckState = CheckState.Checked;
                    else checkBoxNBL.CheckState = CheckState.Unchecked;

                    textBoxPersonalNum.Text = gstParticipant.personalnum;

                    if (gstParticipant.idcountry != null)
                    {
                        clCo = new CCountry(connect, (int)gstParticipant.idcountry);
                        comboBoxCountry.Text = clCo.stCountry.shortname;
                    }

                    if (gstParticipant.descript != null)
                        textBoxDescript.Text = gstParticipant.descript;

                    if (gstParticipant.namefoto != null && gstParticipant.namefoto.Length > 0)
                    {
                        string pathfoto = string.Format("{0}\\{1}", clParam.s_Path.pathfoto, gstParticipant.namefoto);
                        
                        FileInfo fi = new FileInfo(pathfoto);
                        if (fi.Exists)
                        {
                            labelNameFoto.Text = gstParticipant.namefoto;

                            Bitmap bt = new Bitmap(pathfoto);
                            pictureBoxFoto.Image = bt; ;
                        }
                        else
                            MessageBox.Show(string.Format("Файл {0} не найден", pathfoto),
                                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (gstParticipant.vf == 1) checkBoxVisible.Checked = true;
                    else checkBoxVisible.Checked = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STParticipant read_data()
        {
            STParticipant ret = new STParticipant();

            CCountry clCo;

            try
            {
                ret.idpart = gid;

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

                if (checkBoxNBL.CheckState == CheckState.Checked) ret.adminflag = 1;
                else ret.adminflag = 0;

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

                if (checkBoxVisible.Checked == true) ret.vf = 1;
                else ret.vf = 0;

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

            STParticipant data = new STParticipant();

            data = read_data();

            if (gstParticipant.idpart != 0)
                ret = clParticipant.Update(data, gstParticipant.idpart);
            else
                ret = clParticipant.Insert(data);

            return ret;
        }

        public int RetId()
        {
            return gid;
        }
    }
}