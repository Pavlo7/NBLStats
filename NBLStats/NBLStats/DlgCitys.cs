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
    public partial class DlgCitys : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        
        STCity gstCity;
        CCity clCity;
        STCity stC;

        public DlgCitys(SqlConnection cn, ushort md)
        {
            InitializeComponent();
            
            connect = cn;
            mode = md;

            caption = "Добавить город";

            init_combo();
        }

        public DlgCitys(SqlConnection cn, STCity st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstCity = st;

            caption = "Редактировать город";

            init_combo();

            set_data();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private void DlgCitys_Load(object sender, EventArgs e)
        {
            this.Text = caption;

            clCity = new CCity(connect);

            textBoxName.Focus();
        }

        private void init_combo()
        {
            CRegion region;

            try
            {
                comboBoxRegion.Items.Clear();

                region = new CRegion(connect);

                List<STRegion> list_r = region.GetListRegion();

                string text = null;

                foreach (STRegion item in list_r)
                {
                    comboBoxRegion.Items.Add(item.name);

                    if (item.name == "Минск") text = "Минск";

                }

                if (text != null)
                    comboBoxRegion.Text = text; ;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void set_data()
        {
            CRegion region;

            try
            {
                textBoxName.Text = gstCity.name;

                region = new CRegion(connect, gstCity.idreg);

                comboBoxRegion.Text = region.stReg.name;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STCity read_data()
        {
            STCity ret = new STCity();

            CRegion region;

            try
            {
                if (gstCity.id != 0)
                    ret.id = gstCity.id;
                else ret.id = clCity.GetFreeId();

                if (textBoxName.Text.Length > 0)
                    ret.name = textBoxName.Text.Trim();
                else ret.name = null;

                string str = comboBoxRegion.Text.Trim();
                if (str.Length > 0)
                {
                    region = new CRegion(connect, str);
                    ret.idreg = region.stReg.id;
                }
                else ret.idreg = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            stC = new STCity();

            stC = read_data();

            if (gstCity.id != 0)
                ret = clCity.Update(stC);
            else
                ret = clCity.Insert(stC);

            return ret;
        }

        public STCity GetFl()
        {
            return stC;
        }
    }
}