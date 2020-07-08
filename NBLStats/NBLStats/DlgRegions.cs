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
    public partial class DlgRegions : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STRegion gstRegion;
        CRegion clRegion;
        STRegion stC;

        public DlgRegions(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            caption = "Добавить регион";

            init_combo();
        }

        public DlgRegions(SqlConnection cn, STRegion st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstRegion = st;

            caption = "Редактировать регион";

            init_combo();

            set_data();
        }

        private void DlgRegions_Load(object sender, EventArgs e)
        {
            this.Text = caption;

            clRegion = new CRegion(connect);
          
            textBoxName.Focus();
        }

        private void init_combo()
        {
            CCountry country;

            try
            {
                comboBoxCountry.Items.Clear();

                country = new CCountry(connect);

                List<STCountry> list_c = country.GetListCountry();

                string text = null;
    
                foreach (STCountry item in list_c)
                {
                    comboBoxCountry.Items.Add(item.shortname);

                    if (item.name == "РБ") text = "РБ";
                
                }

                if (text != null)
                    comboBoxCountry.Text = text; ;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void set_data()
        {
            CCountry country;

            try
            {
                textBoxName.Text = gstRegion.name;
                textBoxShortName.Text = gstRegion.shortname;

                country = new CCountry(connect, gstRegion.idcountry);

                comboBoxCountry.Text = country.stCountry.shortname;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STRegion read_data()
        {
            STRegion ret = new STRegion();

            CCountry country;

            try
            {
                if (gstRegion.id != 0)
                    ret.id = gstRegion.id;
                else ret.id = clRegion.GetFreeId();

                if (textBoxName.Text.Length > 0)
                    ret.name = textBoxName.Text.Trim();
                else ret.name = null;

                if (textBoxShortName.Text.Length > 0)
                    ret.shortname = textBoxShortName.Text.Trim();
                else ret.shortname = null;

                string str = comboBoxCountry.Text.Trim();
                if (str.Length > 0)
                {
                    country = new CCountry(connect, str);
                    ret.idcountry = country.stCountry.id;
                }
                else ret.idcountry = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

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

        private bool save()
        {
            bool ret = false;

            stC = new STRegion();

            stC = read_data();

            if (gstRegion.id != 0)
                ret = clRegion.Update(stC);
            else
                ret = clRegion.Insert(stC);

            return ret;
        }

        public STRegion GetFl()
        {
            return stC;
        }
    }
}