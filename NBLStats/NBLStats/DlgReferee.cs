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
    public partial class DlgReferee : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STReferee gstReferee;
        CReferee clReferee;
        CParamApp clParam;
        int gid;

        public DlgReferee(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            clReferee = new CReferee(connect);
            clParam = new CParamApp();

            gid = clReferee.GetFreeId();

            caption = "Новый судья";
        }

        public DlgReferee(SqlConnection cn, ushort md, STReferee st)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstReferee = st;

            gid = gstReferee.idref;

            clReferee = new CReferee(connect);
            clParam = new CParamApp();

            caption = "Редактировать данные судьи";
        }

        private void DlgReferee_Load(object sender, EventArgs e)
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

                if (gstReferee.idref != 0)
                {
                    textBoxFamily.Text = gstReferee.family;
                    textBoxName.Text = gstReferee.name;
                    if (gstReferee.payname != null)
                        textBoxSecondName.Text = gstReferee.payname;
                    if (gstReferee.datebirth != null)
                        dateTimePickerDateBirth.Value = (DateTime)gstReferee.datebirth;
                    if (gstReferee.category != null)
                        comboBoxCategory.Text = gstReferee.category;

                    textBoxPersonalNum.Text = gstReferee.personalnum;

                    if (gstReferee.idcountry != null)
                    {
                        clCo = new CCountry(connect, (int)gstReferee.idcountry);
                        comboBoxCountry.Text = clCo.stCountry.shortname;

                    }

                    if (gstReferee.descript != null)
                        textBoxDescript.Text = gstReferee.descript;

                    if (gstReferee.namefoto != null && gstReferee.namefoto.Length > 0)
                    {
                        string pathfoto = string.Format("{0}\\{1}", clParam.s_Path.pathfoto, gstReferee.namefoto);
                        
                        FileInfo fi = new FileInfo(pathfoto);
                        if (fi.Exists)
                        {

                            labelNameFoto.Text = gstReferee.namefoto;

                            Bitmap bt = new Bitmap(pathfoto);
                            pictureBoxFoto.Image = bt; ;
                        }
                        else
                            MessageBox.Show(string.Format("Файл {0} не найден", pathfoto),
                                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (gstReferee.vf == 1) checkBoxVisible.Checked = true;
                    else checkBoxVisible.Checked = false;

                    if (gstReferee.tax!= null)
                        textBoxTax.Text = ((double)gstReferee.tax).ToString("f2");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STReferee read_data()
        {
            STReferee ret = new STReferee();

            CCountry clCo;

            try
            {
                ret.idref = gid;

                if (textBoxFamily.Text.Length > 0)
                    ret.family = textBoxFamily.Text;
                else ret.family = null;

                if (textBoxName.Text.Length > 0)
                    ret.name = textBoxName.Text;
                else ret.name = null;

                if (textBoxSecondName.Text.Length > 0)
                    ret.payname = textBoxSecondName.Text;
                else ret.payname = null;

                if (comboBoxCategory.Text.Length > 0)
                    ret.category = comboBoxCategory.Text;
                else ret.category = null;

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

                if (checkBoxVisible.Checked == true) ret.vf = 1;
                else ret.vf = 0;

                if (!string.IsNullOrEmpty(textBoxTax.Text.Trim()))
                {
                    double dbl = 0;
                    string s = string.Format("{0:f2}", textBoxTax.Text.Trim());
                    double.TryParse(s, out dbl);
                    ret.tax = dbl;
                }
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
            if (save()) DialogResult = DialogResult.OK;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private bool save()
        {
            bool ret = false;

            STReferee data = new STReferee();

            data = read_data();

            if (gstReferee.idref != 0)
                ret = clReferee.Update(data, gstReferee.idref);
            else
                ret = clReferee.Insert(data);

            return ret;
        }

        public int RetId()
        {
            return gid;
        }
    }
}