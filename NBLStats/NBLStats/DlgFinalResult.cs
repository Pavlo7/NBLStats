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
    public partial class DlgFinalResult : Form
    {
        SqlConnection connect;
        string caption;
        
        STFinalResult gstFR;
        CFinalResult clWork;
        STFinalResult stC;

        CEntryTeam clTeam;
        CTeam team;

        public DlgFinalResult(SqlConnection cn,  STFinalResult st)
        {
            InitializeComponent();

            connect = cn;
            gstFR = st;
        }

        private void DlgFinalResult_Load(object sender, EventArgs e)
        {
            try
            {
                clTeam = new CEntryTeam(connect);
                clWork = new CFinalResult(connect);

                if (gstFR.rang <= 0) caption = "Определить место";
                else caption = "Редактировать место";

                set_data();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void set_data()
        {
            try
            {
                team = new CTeam(connect, gstFR.idteam);
                textBoxTeam.Text = team.stTeam.name;

                if (gstFR.rang > 0)
                    textBoxRank.Text = gstFR.rang.ToString();

                textBoxRank.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STFinalResult read_data()
        {
            STFinalResult ret = new STFinalResult();

            try
            {
                ret.idseason = gstFR.idseason;
                ret.iddivision = gstFR.iddivision;
                ret.idteam = gstFR.idteam;
                
                if (textBoxRank.Text.Length > 0)
                {
                    ret.rang = int.Parse(textBoxRank.Text.Trim());
                }
                else ret.rang = 0;
                

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private bool save()
        {
            bool ret = false;

            stC = new STFinalResult();

            stC = read_data();

            if (gstFR.rang <= 0) ret = clWork.Insert(stC);
            else ret = clWork.Update(stC, gstFR);
            
            return ret;
        }

        public STFinalResult GetFl()
        {
            return stC;
        }
    }
}