using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NBLStats
{
    public partial class Mode : Form
    {
        ushort mode;
        CParamApp clParamApp;

        public Mode()
        {
            InitializeComponent();
            mode = 0;
            clParamApp = new CParamApp(); 
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string pwd = null;

            if (radioButtonView.Checked == true)
            {
                mode = 1;
                DialogResult = DialogResult.OK;
            }
            if (radioButtonEdit.Checked == true)
            {
                pwd = textBoxPwd.Text.Trim();

                if (pwd.Equals(clParamApp.strPwdMode))
                {
                    mode = 2;
                    DialogResult = DialogResult.OK;
                }
                else MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.None); 
            }

           
        }

        private void Mode_Load(object sender, EventArgs e)
        {
            radioButtonView.Checked = true;
        }

        public void GetMode(out ushort smode)
        {
            smode = mode;
        }

        private void radioButtonView_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonView.Checked == true)
            {
                textBoxPwd.Text = "";
                textBoxPwd.Enabled = false;
            }
        }

        private void radioButtonEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEdit.Checked == true)
            {
                textBoxPwd.Text = "";
                textBoxPwd.Enabled = true;
                textBoxPwd.Focus();
            }
        }
    }
}