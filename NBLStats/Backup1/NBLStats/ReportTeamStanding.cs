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
    public partial class ReportTeamStanding : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CInfoSeason clIS;
        
        CDivision clDiv;
        CGroup clGroup;

        bool prAll;

        STParamReportTeamStanding param;

        public ReportTeamStanding(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void ReportTeamStanding_Load(object sender, EventArgs e)
        {
            try
            {
                prAll = false;

                clDiv = new CDivision(connect);
                clGroup = new CGroup(connect);

                init_combo_division();

                dateTimePickerDate.Enabled = false;
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
                    checkedListBoxGroupR1.Items.Clear();

                    string text = comboBoxDivision.Text.Trim();
                    clDiv = new CDivision(connect,IS.idseason, text);

                    clGroup = new CGroup(connect);
                    List<STGroup> lst = clGroup.GetListGroup(IS.idseason, clDiv.stDiv.id);

                    foreach (STGroup item in lst)
                    {
                        checkedListBoxGroupR1.Items.Add(item.namegroup, true);
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDate.CheckState == CheckState.Checked)
            {
                dateTimePickerDate.Enabled = true;
                dateTimePickerDate.Value = IS.datebegin;
            }
            else dateTimePickerDate.Enabled = false;
        }

        private bool create()
        {
            bool ret = true;

            try
            {
                ReportExcelTeamStanding cl = new ReportExcelTeamStanding(connect, param, prAll);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); ret = false; }

            return ret;
        }

        private STParamReportTeamStanding read_param()
        {
            STParamReportTeamStanding ret = new STParamReportTeamStanding();
            List<int> li = new List<int>();

            try
            {
                ret.idseason = IS.idseason;

                if (comboBoxDivision.Text.Length > 0)
                {
                    clDiv = new CDivision(connect,IS.idseason, comboBoxDivision.Text.Trim());
                    ret.iddivision = clDiv.stDiv.id;
                }
                else ret.iddivision = 0;

                for(int i=0;i<checkedListBoxGroupR1.Items.Count;i++)
                {
                    if (checkedListBoxGroupR1.GetItemChecked(i))
                    {

                        string name = checkedListBoxGroupR1.Items[i].ToString();
                        clGroup = new CGroup(connect, IS.idseason, ret.iddivision, name);
                        
                        if (clGroup.stGroup.idgroup > 0)
                            li.Add(clGroup.stGroup.idgroup);
                    }
                }

                if (li.Count > 0)
                {
                    ret.arr_idgroup = new int[li.Count];

                    for (int j = 0; j < ret.arr_idgroup.Length; j++)
                    {
                        ret.arr_idgroup[j] = li[j];
                    }
                }
                else ret.arr_idgroup = new int[0];

                if (checkBoxDate.CheckState == CheckState.Checked)
                {
                    ret.dt = new DateTime(dateTimePickerDate.Value.Year, dateTimePickerDate.Value.Month,
                        dateTimePickerDate.Value.Day, 0, 0, 0, 0);

                    prAll = true;
                }
                else
                {
                    prAll = false;
                    ret.dt = null;
                }

                ret.filename = string.Format("Положение команд_{0}.xls",clDiv.stDiv.name);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }
}