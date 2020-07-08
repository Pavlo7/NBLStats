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
    public partial class DlgScheme : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STScheme gstScheme;
        CScheme clScheme;
        STInfoSeason IS;
        int idcdiv;
        CTypeGames cl;

        STScheme stC;

        public DlgScheme(SqlConnection cn, STInfoSeason inf, int iddiv, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            IS = inf;

            idcdiv = iddiv;

            caption = "Добавить этап";
        }

        public DlgScheme(SqlConnection cn, STInfoSeason inf, int iddiv, STScheme st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            IS = inf;
            gstScheme = st;

            idcdiv = iddiv;

            caption = "Редактировать этап";
        }

        private void DlgScheme_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                clScheme = new CScheme(connect);
                cl = new CTypeGames();

                init_combo();

                set_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo()
        {
            CDivision cld = new CDivision(connect, IS.idseason,idcdiv);

            try
            {
                comboBoxTypes.Items.Clear();

                STTypeGame[] arr = cl.types;

                for (int i = 0; i < arr.Length ; i++)
                {
                    if (arr[i].code == 0 && cld.stDiv.flag_reg ==1)
                        comboBoxTypes.Items.Add(arr[i].name.ToString());
                    if (arr[i].code == 1 && cld.stDiv.flag_po == 1)
                        comboBoxTypes.Items.Add(arr[i].name.ToString());
                    if (arr[i].code == 2 && cld.stDiv.flag_styk == 1)
                        comboBoxTypes.Items.Add(arr[i].name.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data()
        {
            try
            {
                if (gstScheme.idstage > 0)
                {
                    textBoxNameStage.Text = gstScheme.namestage;

                    comboBoxTypes.Text = cl.GetTypeName(gstScheme.type);

                    textBoxCntRound.Text = gstScheme.cntround.ToString();

                    if (gstScheme.iddivision == 0)
                        checkBoxTug.CheckState = CheckState.Checked;
                    else checkBoxTug.CheckState = CheckState.Unchecked;
                }
                else
                {
                    textBoxCntRound.Text = null;
                    textBoxNameStage.Text = null;
                    comboBoxTypes.Text = null;
                    checkBoxTug.CheckState = CheckState.Unchecked;
                }

                textBoxNameStage.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private STScheme read_data()
        {
            STScheme ret = new STScheme();

            try
            {
                /* основные параметры */
                ret.idseason = (int)IS.idseason;

                ret.iddivision = idcdiv;

                if (gstScheme.idstage > 0)
                {
                    ret.idstage = gstScheme.idstage;
                }
                else
                {
                    ret.idstage = clScheme.GetFreeId((int)IS.idseason);
                }

                if (textBoxNameStage.Text.Length > 0)
                    ret.namestage = textBoxNameStage.Text.Trim();
                else ret.namestage = "";

                if (comboBoxTypes.Text.Length > 0)
                    ret.type = cl.GetTypeCode(comboBoxTypes.Text.Trim());
                else ret.type =-1;

                if (textBoxCntRound.Text.Length > 0)
                    ret.cntround = int.Parse(textBoxCntRound.Text.Trim());
                else ret.cntround = 0;

                if (checkBoxTug.CheckState == CheckState.Checked)
                    ret.iddivision = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            stC = read_data();

            if (gstScheme.idstage > 0)
                ret = clScheme.Update(stC, gstScheme);
            else
                ret = clScheme.Insert(stC);

            return ret;
        }

        public STScheme GetFl()
        {
            return stC;
        }
    }
}