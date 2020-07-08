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
    public partial class ReportRatingsTeam : Form
    {
        SqlConnection connect;
        STInfoSeason IS;

        CDivision clDiv;
        CScheme clScheme;

        CTypeGames tp;

        int iddivision;
        int type;
        int idstage;

        public ReportRatingsTeam(SqlConnection cn, STInfoSeason inf)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
        }

        private void RatingsTeam_Load(object sender, EventArgs e)
        {
            try
            {
                clDiv = new CDivision(connect);
                clScheme = new CScheme(connect);
                tp = new CTypeGames();

                checkBoxStage.Checked = false;
                checkBoxType.Checked = false;

                comboBoxStage.Enabled = false;
                comboBoxType.Enabled = false;
                comboBoxType.Text = null;
                comboBoxStage.Text = null;

                init_combo_division();
                init_combo_type();

                iddivision = 0;
                 type = -1;
                idstage = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_combo_division()
        {
            List<STDivision> list;

            try
            {
                comboBoxDivision.Items.Clear();
                    
                list = clDiv.GetListDivision(IS.idseason);

                foreach (STDivision st in list)
                    comboBoxDivision.Items.Add(st.name);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_combo_type()
        {
            try
            {
                comboBoxType.Items.Clear();

                STTypeGame[] st = tp.types;

                foreach (STTypeGame item in st)
                    comboBoxType.Items.Add(item.name);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_combo_stage()
        {
            try
            {
                comboBoxStage.Items.Clear();
                comboBoxStage.Text = null;

                List<STScheme> list = clScheme.GetListScheme(IS.idseason, iddivision, type);

                if (list.Count > 0)
                {
                    comboBoxStage.Enabled = true;

                    foreach (STScheme item in list)
                        comboBoxStage.Items.Add(item.namestage);
                }
                else comboBoxStage.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
          //  DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int? itype;
            int? iidstage;

            try
            {
                if (iddivision > 0)
                {
                    if (type >= 0) itype = type;
                    else itype = null;

                    if (idstage > 0) iidstage = idstage;
                    else iidstage = null;

                    ReportExcelRatingsTeam cl = new ReportExcelRatingsTeam(connect, IS.idseason, iddivision,
                        itype, iidstage);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

           // DialogResult = DialogResult.OK;
        }

        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxType.CheckState == CheckState.Checked)
                {
                    comboBoxType.Enabled = true;
                }
                else
                {
                    comboBoxType.Enabled = false;
                    comboBoxType.Text = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void checkBoxStage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxStage.CheckState == CheckState.Checked)
                {
                    comboBoxStage.Enabled = true;
                }
                else
                {
                    comboBoxStage.Enabled = false;
                    comboBoxStage.Text = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDivision.Text.Length > 0)
                {
                    clDiv = new CDivision(connect, IS.idseason, comboBoxDivision.Text.Trim());

                    iddivision = clDiv.stDiv.id;
                }
                else iddivision = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxType.Text.Length > 0)
                    type = tp.GetTypeCode(comboBoxType.Text.Trim());
                else type = -1;

                init_combo_stage();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void comboBoxStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxStage.Text.Length > 0)
                {
                    clScheme = new CScheme(connect, IS.idseason, iddivision, comboBoxStage.Text.Trim());
                    idstage = clScheme.stScheme.idstage;
                }
                else idstage = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
