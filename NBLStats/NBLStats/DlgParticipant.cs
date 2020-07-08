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

        CParticipant clWork;
        CPostment clPost;

        STParticipant? oldData;
        STParticipant rData;
        
        CParamApp clParam;
        
        public DlgParticipant(SqlConnection cn, STParticipant? data)
        {
            InitializeComponent();

            connect = cn;
            oldData = data;
        }

        private void DlgParticipant_Load(object sender, EventArgs e)
        {
            string text = null;

            try
            {

                clWork = new CParticipant(connect);
                clParam = new CParamApp();
                clPost = new CPostment(connect);

                if (oldData != null) mode = 1;
                else mode = 0;

                if (mode == 0)
                {
                    text = "Новый участник";
                    int n = clWork.GetFreeId();
                    textBoxId.Text = n.ToString();
                    textBoxFamily.Focus();
                }
                if (mode == 1)
                {
                    text = "Редактировать данные участника";
                    set_data((STParticipant)oldData);
                }
                this.Text = text;

                init_combo_country();

                init_list_post();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,ex.Source); }
        }

        private void init_list_post()
        {
            List<int> arr = new List<int>();
            STParticipant data;

            try
            {
                checkedListBoxPost.Items.Clear();

                if (mode == 1)
                {
                    data = (STParticipant)oldData;
                    arr = clWork.GetArrayPost(data.post);
                }

                List<STPostment> list = clPost.GetList();

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxPost.Items.Add(list[i].namepost);

                    if (mode == 1)
                    {
                        foreach (int j in arr)
                        {
                            if (list[i].idpost == j) checkedListBoxPost.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
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

        private void set_data(STParticipant data)
        {
            CCountry clCo;

            try
            {
                textBoxId.Text = data.idpart.ToString();

                if (data.idpart != 0)
                {
                    textBoxFamily.Text = data.family;
                    textBoxName.Text = data.name;
                    if (data.payname != null)
                        textBoxSecondName.Text = data.payname;
                    if (data.datebirth != null)
                        dateTimePickerDateBirth.Value = (DateTime)data.datebirth;

                    if (data.adminflag == 1) checkBoxNBL.CheckState = CheckState.Checked;
                    else checkBoxNBL.CheckState = CheckState.Unchecked;

                    textBoxPersonalNum.Text = data.personalnum;

                    if (data.idcountry != null)
                    {
                        clCo = new CCountry(connect, (int)data.idcountry);
                        comboBoxCountry.Text = clCo.stCountry.shortname;
                    }

                    if (data.namefoto != null && data.namefoto.Length > 0)
                    {
                        string pathfoto = string.Format("{0}\\{1}", clParam.s_Path.pathfoto, data.namefoto);
                        
                        FileInfo fi = new FileInfo(pathfoto);
                        if (fi.Exists)
                        {
                            labelNameFoto.Text = data.namefoto;

                            Bitmap bt = new Bitmap(pathfoto);
                            pictureBoxFoto.Image = bt; ;
                        }
                        else
                            MessageBox.Show(string.Format("Файл {0} не найден", pathfoto),
                                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (data.vf == 1) checkBoxVisible.Checked = true;
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
                if (textBoxId.Text.Length > 0)
                    ret.idpart = int.Parse(textBoxId.Text.Trim());
                else ret.idpart = 0;
              
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

                if (checkBoxVisible.Checked == true) ret.vf = 1;
                else ret.vf = 0;

                List<int> arr = new List<int>();
                STPostment st;
                for (int i = 0; i < checkedListBoxPost.Items.Count; i++)
                {
                    if (checkedListBoxPost.GetItemChecked(i))
                    {
                        st = new STPostment();
                        string text = checkedListBoxPost.Items[i].ToString();
                        if (text.Length > 0) st = clPost.GetPost(text);

                        arr.Add(st.idpost);
                    }
                }

                if (arr.Count > 0) ret.post = clWork.GetStringPost(arr);
                else ret.post = null;



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
            try
            {
                rData = read_data();

                if (mode == 1)
                {
                    if (clWork.Update(rData, (STParticipant)oldData)) DialogResult = DialogResult.OK;
                }

                if (mode == 0)
                {
                    if (clWork.Insert(rData)) DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        public STParticipant GetFl()
        {
            return rData;
        }
    }
}