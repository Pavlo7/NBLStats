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
    public partial class ParamSeason : Form
    {
        STInfoSeason IS;
        SqlConnection connect;
        int type;               /* 0 - новый сезон, 1 - старый сезон */
        
        CInfoSeason cis;
        string capture;

        STInfoSeason sdata;

        public ParamSeason(SqlConnection cn)
        {
            InitializeComponent();

            connect = cn;

            type = 0;

            capture = "Ќовый сезон";
        }

        public ParamSeason(SqlConnection cn, STInfoSeason data)
        {
            InitializeComponent();

            connect = cn;
            IS = data;

            type = 1;

            capture = "–едактировать сезон";
        }

        private void ParamSeason_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = capture;

                cis = new CInfoSeason(connect);

                set_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                sdata = read_data();

                /* провер€ем текущий сезон*/
                if (sdata.flag == 1)
                {
                    STInfoSeason? cd = cis.GetCurretDataSeason();
                    if (cd != null) 
                    {
                        STInfoSeason dat = (STInfoSeason)cd;
                        cis.RemoveCurrentSeason(dat.idseason);
                    }
                }

                if (type == 0) cis.Insert(sdata);
                if (type == 1) cis.Update(sdata, IS.idseason);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            DialogResult = DialogResult.OK;
        }
        
        private void set_data()
        {
            try
            {
                if (type == 1)
                {
                    labelId.Text = IS.idseason.ToString();
                    textBoxNameSeason.Text = IS.nameseason;
                    dateTimePickerDateBegin.Value = IS.datebegin;
                    dateTimePickerDateEnd.Value = IS.dateend;
                    textBoxCntDivision.Text = IS.cntdivision.ToString().Trim();
                    textBoxCntTeam.Text = IS.cntteam.ToString().Trim();

                    if (IS.flag == 1) checkBoxCurr.Checked = true;


                }
                else
                {
                    int id = cis.GetFreeId();
                    
                    labelId.Text = id.ToString().Trim();

                    textBoxNameSeason.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STInfoSeason read_data()
        {
            STInfoSeason ret = new STInfoSeason();

            try
            {
                ret.idseason = int.Parse(labelId.Text.Trim());

                if (textBoxNameSeason.Text.Length > 0)
                    ret.nameseason = textBoxNameSeason.Text.Trim();
                else ret.nameseason = null;

                ret.datebegin = dateTimePickerDateBegin.Value;
                ret.dateend = dateTimePickerDateEnd.Value;
                
                if (textBoxCntDivision.Text.Length > 0)
                    ret.cntdivision = int.Parse(textBoxCntDivision.Text.Trim());
                else ret.cntdivision = 0;

                if (textBoxCntTeam.Text.Length > 0)
                    ret.cntteam = int.Parse(textBoxCntTeam.Text.Trim());
                else ret.cntteam = 0;

                if (checkBoxCurr.Checked == true) ret.flag = 1;

                if (type == 0)
                    ret.flagend = 0;
                else ret.flagend = IS.flagend;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public STInfoSeason GetFl()
        {
            return sdata;
        }
       
    }
}