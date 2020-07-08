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
    public partial class DlgTeam : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STTeam gstTeam;
        CTeam clTeam;

        int gid;

        public DlgTeam(SqlConnection cn, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;

            caption = "Добавить команду";

            init_combo();
        }

        public DlgTeam(SqlConnection cn, STTeam st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            gstTeam = st;

            caption = "Редактировать команду";

            init_combo();
            init_combo_team();

            set_data();
        }

        private void DlgTeam_Load(object sender, EventArgs e)
        {
            this.Text = caption;

            clTeam = new CTeam(connect);

            textBoxName.Focus();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void init_combo_team()
        {
            try
            {
                clTeam = new CTeam(connect);
                List<STTeam> lst = clTeam.GetListTeam(0);

                comboBoxPrevTeam.Items.Clear();

                comboBoxPrevTeam.Items.Add("");

                foreach (STTeam item in lst)
                {
                    comboBoxPrevTeam.Items.Add(item.name);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
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
                    CCity citys = new CCity(connect,text);
                    set_disl(citys.stFullCity);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data()
        {
            CCity city;

            try
            {
                textBoxName.Text = gstTeam.name;

                city = new CCity(connect, gstTeam.idcity);

                comboBoxCity.Text = city.stCity.name;
                                
                set_disl(city.stFullCity);

                if (gstTeam.idprev != null)
                {
                    clTeam = new CTeam(connect, (int)gstTeam.idprev);
                    comboBoxPrevTeam.Text = clTeam.stTeam.name;
                }

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

        private STTeam read_data()
        {
            STTeam ret = new STTeam();

            CCity city;

            try
            {
                if (gstTeam.id != 0)
                    ret.id = gstTeam.id;
                else ret.id = clTeam.GetFreeId();

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

                if (comboBoxPrevTeam.Text.Length > 0)
                {
                    clTeam = new CTeam(connect, comboBoxPrevTeam.Text.Trim());
                    ret.idprev = clTeam.stTeam.id;
                }
                else ret.idprev = null;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            STTeam stC = new STTeam();

            stC = read_data();

            if (gstTeam.id != 0)
                ret = clTeam.Update(stC);
            else
                ret = clTeam.Insert(stC);

            return ret;
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

        public int RetId()
        {
            return gstTeam.id;
        }
    }
}