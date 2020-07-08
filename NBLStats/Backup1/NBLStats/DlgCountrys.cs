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
    public partial class DlgCountrys : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STCountry gstCountry;
        STCountry stC;
        CCountry clCountry;

        public DlgCountrys(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            caption = "Добавить страну";
        }

        public DlgCountrys(SqlConnection cn, STCountry st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstCountry = st;

            caption = "Редактировать страну";
        }
               

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void DlgCountrys_Load(object sender, EventArgs e)
        {
            this.Text = caption;

            clCountry = new CCountry(connect);
            
            set_data();

            textBoxName.Focus();
        }

        private bool save()
        {
            bool ret = false;

            stC = new STCountry();

            stC = read_data();

            if (gstCountry.id != 0)
                ret = clCountry.Update(stC);
            else
                ret = clCountry.Insert(stC);

            return ret;
        }

        private STCountry read_data()
        {
            STCountry ret = new STCountry();

            try
            {
                if (gstCountry.id != 0)
                    ret.id = gstCountry.id;
                else ret.id = clCountry.GetFreeId();

                if (textBoxName.Text.Length > 0)
                    ret.name = textBoxName.Text.Trim();
                else ret.name = null;

                if (textBoxShortName.Text.Length > 0)
                    ret.shortname = textBoxShortName.Text.Trim();
                else ret.shortname = null;
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private void set_data()
        {
            try
            {
                textBoxName.Text = gstCountry.name;
                textBoxShortName.Text = gstCountry.shortname;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        public STCountry GetFl()
        {
            return stC;
        }
    }
}