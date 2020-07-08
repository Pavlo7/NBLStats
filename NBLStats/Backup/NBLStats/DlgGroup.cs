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
    public partial class DlgGroup : Form
    {
        SqlConnection connect;
        ushort mode;
        string caption;
        STGroup gstGroup;
        CGroup clGroup;
        STInfoSeason IS;
        CScheme clScheme;
        CDivision clDivision;

        STGroup stC;

        public DlgGroup(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            IS = inf;

            caption = "Добавить группу";
        }

        public DlgGroup(SqlConnection cn, STInfoSeason inf, STGroup st, ushort md)
        {
            InitializeComponent();

            connect = cn;
            mode = md;
            IS = inf;
            gstGroup = st;

            caption = "Редактировать группу";
        }

        private void DlgGroup_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                clGroup = new CGroup(connect);
                clScheme = new CScheme(connect);
                clDivision = new CDivision(connect);

                init_combo_division();
             
                init_combo_scheme(0);

                set_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_scheme(int idcdiv)
        {
            try
            {
                comboBoxStage.Items.Clear();
                
                List<STScheme> list = new List<STScheme>();

                list = clScheme.GetListScheme((int)IS.idseason, idcdiv);

                if (list.Count > 0)
                {
                    foreach (STScheme item in list)
                    {
                        if (item.type == 0)
                            comboBoxStage.Items.Add(item.namestage);
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
         }
        private void init_combo_division()
        {
            try
            {
                comboBoxDivision.Items.Clear();

                List<STDivision> list = new List<STDivision>();

                list = clDivision.GetListDivision(IS.idseason);

                if (list.Count > 0)
                {
                    foreach (STDivision item in list)
                    {
                        comboBoxDivision.Items.Add(item.name);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name;
            int id = 0;

            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    name = comboBoxDivision.Text.Trim();
                    clDivision = new CDivision(connect, IS.idseason, name);

                    id = clDivision.stDiv.id;
                }

                init_combo_scheme(id);

                comboBoxStage.Text = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data()
        {
            if (gstGroup.idgroup > 0)
            {
                clDivision = new CDivision(connect, IS.idseason, gstGroup.iddivision);
                comboBoxDivision.Text = clDivision.stDiv.name;
                
                textBoxNameGroup.Text = gstGroup.namegroup;

                CScheme scheme = new CScheme(connect, (int)IS.idseason, gstGroup.iddivision, gstGroup.idstage);

                comboBoxStage.Text = scheme.stScheme.namestage;

                textBoxCntTeam.Text = gstGroup.cntteam.ToString();
                textBoxCntTeamNext.Text = gstGroup.cntteamnext.ToString();
            }
            else
            {
                comboBoxDivision.Text = null;
                textBoxNameGroup.Text = null;
                textBoxCntTeam.Text = null;
                comboBoxStage.Text = null;
                textBoxCntTeamNext.Text = null;
            }

            textBoxNameGroup.Focus();                
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private STGroup read_data()
        {
            STGroup ret = new STGroup();

            string text = null;

            try
            {
                /* основные параметры */
                ret.idseason = IS.idseason;

                if (IS.cntdivision > 1)
                {
                    if (comboBoxDivision.Text.Length > 0)
                    {
                        text = comboBoxDivision.Text.Trim();
                        clDivision = new CDivision(connect, IS.idseason, text);
                        ret.iddivision = clDivision.stDiv.id;
                    }
                }
                else ret.iddivision = 0;

                if (gstGroup.idgroup > 0)
                {
                    ret.idgroup = gstGroup.idgroup;
                }
                else
                {
                    ret.idgroup = clGroup.GetFreeId((int)IS.idseason);
                }

                if (textBoxNameGroup.Text.Length > 0)
                    ret.namegroup = textBoxNameGroup.Text.Trim();
                else ret.namegroup = "";

                if (comboBoxStage.Text.Length > 0)
                {
                    text = comboBoxStage.Text.Trim();
                    CScheme scheme = new CScheme(connect, (int)IS.idseason, ret.iddivision, text);
                    ret.idstage = scheme.stScheme.idstage;
                }
                else ret.idstage = 0;

                if (textBoxCntTeam.Text.Length > 0)
                    ret.cntteam = int.Parse(textBoxCntTeam.Text.Trim());
                else ret.cntteam = 0;

                if (textBoxCntTeamNext.Text.Length > 0)
                    ret.cntteamnext = int.Parse(textBoxCntTeamNext.Text.Trim());
                else ret.cntteamnext = 0;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            stC = read_data();

            if (gstGroup.idgroup > 0)
                ret = clGroup.Update(stC);
            else
                ret = clGroup.Insert(stC);

            return ret;
        }

        public STGroup GetFl()
        {
            return stC;
        }

       
    }
}