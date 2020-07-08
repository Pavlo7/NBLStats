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
    public partial class DlgAwards : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;

        STAward? oldData;
        STAward rData;

        CAward clWork;

        public DlgAwards(SqlConnection cn, STAward? data)
        {
            InitializeComponent();

            connect = cn;
            oldData = data;
        }

        private void DlgAwards_Load(object sender, EventArgs e)
        {
            string text = null;

            try
            {
                clWork = new CAward(connect);

                if (oldData != null) mode = 1;
                else mode = 0;

                if (mode == 0)
                {
                    text = "Добавить номинацию";
                    int n = clWork.GetFreeId();
                    textBoxId.Text = n.ToString();
                    textBoxName.Focus();
                }
                if (mode == 1)
                {
                    text = "Редактировать номинацию";
                    set_data((STAward)oldData);
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
                    if (clWork.Update(rData, (STAward)oldData)) DialogResult = DialogResult.OK;
                }

                if (mode == 0)
                {
                    if (clWork.Insert(rData)) DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data(STAward data)
        {
            try
            {
                textBoxId.Text = data.idaward.ToString();

                if (data.nameaward != null) textBoxName.Text = data.nameaward;

                textBoxId.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private STAward read_data()
        {
            STAward ret = new STAward();

            try
            {
                if (textBoxId.Text.Length > 0)
                    ret.idaward = int.Parse(textBoxId.Text.Trim());
                else ret.idaward = 0;

                if (textBoxName.Text.Length > 0)
                    ret.nameaward = textBoxName.Text.Trim();
                else ret.nameaward = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        public STAward GetFl()
        {
            return rData;
        }
    }
}