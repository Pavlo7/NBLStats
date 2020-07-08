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
    public partial class ReportStatsPlayer : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CInfoSeason clIS;

        CDivision clDiv;
        CGroup clGroup;

        STParamReportStatsPlayer param;


        public ReportStatsPlayer(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();
            
            connect = cn;
            IS = inf;
        }

        private void ReportStatsPlaer_Load(object sender, EventArgs e)
        {
            try
            {
                clDiv = new CDivision(connect);
                clGroup = new CGroup(connect);

                init_combo_division();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_division()
        {
            try
            {
                List<STDivision> lst = clDiv.GetListDivision(IS.idseason);

                foreach (STDivision item in lst)
                {
                    comboBoxDivision.Items.Add(item.name);
                }
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
                param = read_param();

                create();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            DialogResult = DialogResult.OK;
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    checkedListBoxGroup.Items.Clear();

                    string text = comboBoxDivision.Text.Trim();
                    clDiv = new CDivision(connect, IS.idseason, text);

                    clGroup = new CGroup(connect);
                    List<STGroup> lst = clGroup.GetListGroup(IS.idseason, clDiv.stDiv.id);

                    foreach (STGroup item in lst)
                    {
                        checkedListBoxGroup.Items.Add(item.namegroup, true);
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private bool create()
        {
            bool ret = true;

            try
            {
                ReportExcelStatsPlayer cl = new ReportExcelStatsPlayer(connect, param);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private STParamReportStatsPlayer read_param()
        {
            STParamReportStatsPlayer ret = new STParamReportStatsPlayer();
            List<int> li = new List<int>();

            try
            {
                ret.idseason = IS.idseason;

                if (comboBoxDivision.Text.Length > 0)
                {
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());
                    ret.iddivision = clDiv.stDiv.id;
                }
                else ret.iddivision = 0;

                for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
                {
                    if (checkedListBoxGroup.GetItemChecked(i))
                    {
                        clGroup = new CGroup(connect, IS.idseason, ret.iddivision, 
                            checkedListBoxGroup.Items[i].ToString());
                        li.Add(clGroup.stGroup.idgroup);
                    }
                }

                ret.arr_idgroup = new int[li.Count];

                for (int j = 0; j < ret.arr_idgroup.Length; j++)
                {
                    ret.arr_idgroup[j] = li[j];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
        
    }
}