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
    public partial class DlgPlayers : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STPlayer gstPlayer;
        CPlayer clPlayer;
        CParamApp clParam;
        int gid;

        public DlgPlayers(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            clPlayer = new CPlayer(connect);
            clParam = new CParamApp();

            gid = clPlayer.GetFreeId();

            caption = "Новый игрок";
        }

        public DlgPlayers(SqlConnection cn, ushort md, STPlayer st)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstPlayer = st;

            gid = gstPlayer.idplayer;

            clPlayer = new CPlayer(connect);
            clParam = new CParamApp();

            caption = "Редактировать данные игрока";
        }

        private void DlgPlayers_Load(object sender, EventArgs e)
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

                if (gstPlayer.idplayer != 0)
                {
                    textBoxFamily.Text = gstPlayer.family;
                    textBoxName.Text = gstPlayer.name;
                    textBoxSecondName.Text = gstPlayer.payname;
                    if (gstPlayer.datebirth != null)
                        dateTimePickerDateBirth.Value = (DateTime)gstPlayer.datebirth;
                    textBoxPersonalNum.Text = gstPlayer.personalnum;

                    if (gstPlayer.idcountry != null)
                    {
                        clCo = new CCountry(connect, (int)gstPlayer.idcountry);
                        comboBoxCountry.Text = clCo.stCountry.shortname;
                    }

                    textBoxDescript.Text = gstPlayer.descript;
                    textBoxFotoWeb.Text = gstPlayer.fotoweb;

                    if (gstPlayer.namefoto != null && gstPlayer.namefoto.Length > 0)
                    {
                        string pathfoto = string.Format("{0}\\{1}", clParam.s_Path.pathfoto, gstPlayer.namefoto);

                        FileInfo fi = new FileInfo(pathfoto);
                        if (fi.Exists)
                        {
                            labelNameFoto.Text = gstPlayer.namefoto;

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

        private STPlayer read_data()
        {
            STPlayer ret = new STPlayer();

            CCountry clCo;

            try
            {
                ret.idplayer = gid;

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

                if (textBoxFotoWeb.Text.Length > 0)
                    ret.fotoweb = textBoxFotoWeb.Text.Trim();
                else ret.fotoweb = null;

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
            bool fl = true;

            bool ret = false;

            STPlayer data = new STPlayer();

            data = read_data();

            string text;
            string str;

            DateTime dt;

            List<STPlayer> lst_p = clPlayer.IsFamily(data.family);

            if (lst_p.Count > 0)
            {
                text = "Игроки с такой фамилией уже есть в базе данных:\r\n";

                foreach (STPlayer player in lst_p)
                {
                    if (player.datebirth != null)
                    {
                        dt = (DateTime)player.datebirth;
                        str = string.Format("{0} {1} {2}, {3}\r\n", player.family, player.name, player.payname,
                            dt.ToShortDateString());
                    }
                    else str = string.Format("{0} {1} {2}\r\n", player.family, player.name, player.payname);


                    text += str;
                }

                text += "Продолжить?";

                if (MessageBox.Show(text, "Внимание!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    fl = false;
            }

            if (fl)
            {
                if (gstPlayer.idplayer != 0)
                    ret = clPlayer.Update(data, gstPlayer.idplayer);
                else
                    ret = clPlayer.Insert(data);
            }

            return ret;
        }

        public int RetId()
        {
            return gid;
        }
    }
}