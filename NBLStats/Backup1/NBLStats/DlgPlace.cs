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
    public partial class DlgPlace : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STPlace gstPlace;
        CPlace clPlace;
        STPlace stC;

        public DlgPlace(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            caption = "Добавить площадку";

            init_combo();
        }

        public DlgPlace(SqlConnection cn, STPlace st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstPlace = st;

            caption = "Редактировать площадку";

            init_combo();

            set_data();
        }

        private void DlgPlace_Load(object sender, EventArgs e)
        {
            this.Text = caption;

            clPlace = new CPlace(connect);

            textBoxName.Focus();
        }

        private void init_combo()
        {
            CCity city;

            try
            {
                comboBoxCity.Items.Clear();

                city = new CCity(connect);

                List<STCity> list_c = city.GetListCity();

                string text = null;

                foreach (STCity item in list_c)
                {
                    comboBoxCity.Items.Add(item.name);

                    if (item.name == "Минск") text = "Минск";

                }

                if (text != null)
                {
                    comboBoxCity.Text = text; ;
                    CCity citys = new CCity(connect, text);
                    set_disl(citys.stFullCity);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void set_data()
        {
            CCity city;

            try
            {
                textBoxName.Text = gstPlace.name;

                city = new CCity(connect, gstPlace.idcity);

                comboBoxCity.Text = city.stCity.name;

                set_disl(city.stFullCity);

                textBoxAddress.Text = gstPlace.address;

                if (gstPlace.vf == 1) checkBoxVisible.Checked = true;
                else checkBoxVisible.Checked = false;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void set_disl(STFullDataCity data)
        {
            try
            {
                string text = string.Format("{0}, {1}", data.shortnamecountry,
                    data.nameregion);

                labelDisl.Text = text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STPlace read_data()
        {
            STPlace ret = new STPlace();

            CCity city;

            try
            {
                if (gstPlace.id != 0)
                    ret.id = gstPlace.id;
                else ret.id = clPlace.GetFreeId();

                if (textBoxName.Text.Length > 0)
                    ret.name = textBoxName.Text.Trim();
                else ret.name = null;

                string str = comboBoxCity.Text.Trim();
                if (str.Length > 0)
                {
                    city = new CCity(connect, str);
                    ret.idcity = city.stCity.id;
                }
                else ret.idcity = 0;

                if (textBoxAddress.Text.Length > 0)
                    ret.address= textBoxAddress.Text.Trim();
                else ret.address = null;

                if (checkBoxVisible.Checked == true)
                    ret.vf = 1;
                else ret.vf = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            stC = new STPlace();

            stC = read_data();

            if (gstPlace.id != 0)
                ret = clPlace.Update(stC);
            else
                ret = clPlace.Insert(stC);

            return ret;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        public STPlace GetFl()
        {
            return stC;
        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            CCity city;

            string str = comboBoxCity.Text.Trim();
            if (str.Length > 0)
            {
                 city = new CCity(connect, str);
                 
                 set_disl(city.stFullCity);
            }
            
            
        }
    }
}