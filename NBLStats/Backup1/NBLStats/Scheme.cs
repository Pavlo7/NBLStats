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
    public partial class Scheme : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        ushort mode;
        int idCurrDiv;

        CScheme clScheme;

        bool g_f;

        STScheme flawour;
        int gpos;

        public Scheme()
        {
            InitializeComponent();
        }

        public Scheme(SqlConnection cn, STInfoSeason inf, ushort md)
        {
            InitializeComponent();

            connect = cn;
            IS = inf;
            mode = md;

            clScheme = new CScheme(connect);
        }

        private void Scheme_Load(object sender, EventArgs e)
        {
            init_combo();
        }

        private void init_combo()
        {
            try
            {
                if (IS.cntdivision > 0)
                {
                    CDivision div = new CDivision(connect);

                    List<STDivision> list_div = div.GetListDivision((int)IS.idseason);

                    foreach (STDivision item in list_div)
                    {
                        comboBoxNameDivision.Items.Add(item.name);
                    }

                    if (list_div.Count > 0)
                    {
                        comboBoxNameDivision.Text = comboBoxNameDivision.Items[0].ToString();

                        idCurrDiv = list_div[0].id;
                    }

                    init_data(idCurrDiv);
                }
                else comboBoxNameDivision.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void init_data(int iddivision)
        {
            dataGridViewScheme.Rows.Clear();

            CScheme clScheme = new CScheme(connect);
            List<STScheme> list = clScheme.GetListScheme((int)IS.idseason, iddivision);
            
            ListCompare lt = new ListCompare();

            CTypeGames clTp = new CTypeGames();

            try
            {
                list.Sort(lt);

                if (list.Count > 0)
                {
                    g_f = true;

                    dataGridViewScheme.Rows.Add(list.Count);

                    for (int i = 0; i < list.Count; i++)
                    {

                        dataGridViewScheme.Rows[i].Cells[0].Value = clTp.GetTypeName(list[i].type);

                        dataGridViewScheme.Rows[i].Cells[1].Value = list[i].namestage;

                        dataGridViewScheme.Rows[i].Cells[2].Value = list[i].cntround.ToString();

                        dataGridViewScheme.Rows[i].Cells[3].Value = list[i].idstage.ToString();

                        if (flawour.Equals(list[i])) gpos = i;
                    }

                    dataGridViewScheme.AllowUserToAddRows = false;
                }
                else dataGridViewScheme.AllowUserToAddRows = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private Color getcolor(int x)
        {
            Color ret = Color.Black;

            switch (x)
            {
                case 0: ret = Color.DarkBlue; break;
                case 1: ret = Color.DarkRed; break;
                case 2: ret = Color.DarkGreen; break;
            }

            return ret;
        }

        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            del();
        }

        private void add()
        {
            DlgScheme wnd = new DlgScheme(connect, IS, idCurrDiv, mode);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                flawour = wnd.GetFl();

                init_data(idCurrDiv);

                if (gpos >= 0 && dataGridViewScheme.Rows.Count > 0)
                {
                    dataGridViewScheme.Rows[gpos].Selected = true;
                    dataGridViewScheme.FirstDisplayedScrollingRowIndex = gpos;
                }
            }
        }

        private void del()
        {
            STScheme data = GetSelectionData();

            if (MessageBox.Show("Вы действиетльно желаете удалить данную запись?", "Внимание!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clScheme.Delete(data);
                init_data(idCurrDiv);
            }
        }

        private void edit()
        {
            STScheme data = GetSelectionData();

            DlgScheme wnd = new DlgScheme(connect, IS, idCurrDiv, data, mode);

            DialogResult result = wnd.ShowDialog();

            if (result == DialogResult.OK)
            {
                flawour = wnd.GetFl();

                init_data(idCurrDiv);

                if (gpos >= 0 && dataGridViewScheme.Rows.Count > 0)
                {
                    dataGridViewScheme.Rows[gpos].Selected = true;
                    dataGridViewScheme.FirstDisplayedScrollingRowIndex = gpos;
                }
            }
        }
         
    

        private STScheme GetSelectionData()
        {   
            STScheme ret = new STScheme();

            int n;

            try
            {
                foreach (DataGridViewRow item in dataGridViewScheme.SelectedRows)
                {
                    n = int.Parse(item.Cells[3].Value.ToString());

                    CScheme sp = new CScheme(connect, (int)IS.idseason, idCurrDiv, n);

                    ret = sp.stScheme;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,ex.Source); }

            return ret;
        }

        private void listViewScheme_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void comboBoxNameDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string s = comboBoxNameDivision.Text.Trim();

                CDivision div = new CDivision(connect, (int)IS.idseason, s);

                init_data(div.stDiv.id);

                idCurrDiv = div.stDiv.id;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void dataGridViewScheme_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }
    }
     

    public class ListCompare : IComparer<STScheme>
    {
        public int Compare(STScheme x, STScheme y)
        {
            if (x.type < y.type) return -1;
            if (x.type > y.type) return 1;
            if (x.type == y.type)
            {
                if (x.idstage == y.idstage) return 0;
                if (x.idstage < y.idstage) return -1;
                if (x.idstage > y.idstage) return 1;
            }

            return 0;
        }

    };
}