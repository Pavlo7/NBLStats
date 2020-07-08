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
    public partial class DlgPostmetn : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;

        STPostment? oldData;
        STPostment rData;

        CPostment clWork;

        public DlgPostmetn(SqlConnection cn, STPostment? data)
        {
            InitializeComponent();
          
            connect = cn;
            oldData = data;

        }

        private void DlgPostmetn_Load(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                clWork = new CPostment(connect);

                if (oldData != null) mode = 1;
                else mode = 0;

                if (mode == 0)
                {
                    text = "Добавить должность";
                    int n = clWork.GetFreeId();
                    textBoxId.Text = n.ToString();
                    textBoxName.Focus();
                }
                if (mode == 1)
                {
                    text = "Редактировать должность";
                    set_data((STPostment)oldData);
                }
                this.Text = text;


            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
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
                    if (clWork.Update(rData, (STPostment)oldData)) DialogResult = DialogResult.OK;
                }

                if (mode == 0)
                {
                    if (clWork.Insert(rData)) DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void set_data(STPostment data)
        {
            try
            {
                textBoxId.Text = data.idpost.ToString();

                if (data.namepost != null) textBoxName.Text = data.namepost;
                if (data.descript != null) textBoxDescript.Text = data.descript;

                textBoxId.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
       
        private STPostment read_data()
        {
            STPostment ret = new STPostment();

            try
            {
                if (textBoxId.Text.Length > 0)
                    ret.idpost = int.Parse(textBoxId.Text.Trim());
                else ret.idpost = 0;

                if (textBoxName.Text.Length > 0)
                    ret.namepost = textBoxName.Text.Trim();
                else ret.namepost = null;

                if (textBoxDescript.Text.Length > 0)
                    ret.descript = textBoxDescript.Text.Trim();
                else ret.descript = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        public STPostment GetFl()
        {
            return rData;
        }
        
    }
}
