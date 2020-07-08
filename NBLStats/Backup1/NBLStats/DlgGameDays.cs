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
    public partial class DlgGameDays : Form
    {
        SqlConnection connect;
        STInfoSeason IS;
        string caption;
        ushort mode;
        CGameDays clWork;

        STGameDays? oldData;
        STGameDays rData;

        CParticipant clPart;
        CPlace clPlace;


        public DlgGameDays(SqlConnection cn, STInfoSeason si, STGameDays? data)
        {
            InitializeComponent();

            connect = cn;
            IS = si;
            oldData = data;

            clPlace = new CPlace(connect);

            init_combo_palce();
        }

        private void init_combo_palce()
        {
            try
            {
                comboBoxPlace.Items.Clear();

                List<STPlace> list = clPlace.GetListPlace();

                comboBoxPlace.Items.Add("");

                if (list.Count > 0)
                {
                    foreach (STPlace item in list)
                        if (item.vf == 1)
                            comboBoxPlace.Items.Add(item.name);
                }
                else comboBoxPlace.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void DlgGameDays_Load(object sender, EventArgs e)
        {
            string text = null;

            try
            {

                clWork = new CGameDays(connect);
                clPart = new CParticipant(connect);

                if (oldData != null) mode = 1;
                else mode = 0;

                if (mode == 0)
                {
                    text = "Новый игровой день";
                    int n = clWork.GetFreeId(IS.idseason);
                    textBoxNDay.Text = n.ToString();
                    textBoxCntGame.Focus();
                }
                if (mode == 1)
                {
                    text = "Редактировать игровой день";
                    set_data((STGameDays)oldData);
                }
                this.Text = text;

                init_list_admin();
                init_list_washer();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_list_admin()
        {
            List<int> arr = new List<int>();
            STGameDays data;

            try
            {
                checkedListBoxAdmin.Items.Clear();

                if (mode == 1)
                {
                    data = (STGameDays)oldData;
                    arr = clWork.GetArrayData(data.adminline);
                }

                List<STParticipant> list = clPart.GetList(7);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxAdmin.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in arr)
                        {
                            if (list[i].idpart == j) checkedListBoxAdmin.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_washer()
        {
            List<int> arr = new List<int>();
            STGameDays data;

            try
            {
                checkedListBoxWasher.Items.Clear();

                if (mode == 1)
                {
                    data = (STGameDays)oldData;
                    arr = clWork.GetArrayData(data.washerline);
                }

                List<STParticipant> list = clPart.GetList(9);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxWasher.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in arr)
                        {
                            if (list[i].idpart == j) checkedListBoxWasher.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void set_data(STGameDays data)
        {
            try
            {
                textBoxNDay.Text = data.nday.ToString();

                dateTimePickerDate.Value = data.date;

                textBoxCntGame.Text = data.cntgames.ToString();

                clPlace = new CPlace(connect, data.idplace);

                comboBoxPlace.Text = clPlace.stPlace.name;
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private STGameDays read_data()
        {
            STGameDays ret = new STGameDays();
            List<int> arr = new List<int>();
            string text = null;
            string family = null;
            string name = null;
            string[] words;

            try
            {
                ret.idseason = IS.idseason;

                if (textBoxNDay.Text.Length > 0)
                    ret.nday = int.Parse(textBoxNDay.Text.Trim());
                else ret.nday = 0;

                ret.date = new DateTime(dateTimePickerDate.Value.Year,
                   dateTimePickerDate.Value.Month, dateTimePickerDate.Value.Day, 0, 0, 0, 0);

                if (textBoxCntGame.Text.Length > 0)
                    ret.cntgames = int.Parse(textBoxCntGame.Text.Trim());
                else ret.cntgames = 0;

                for (int i = 0; i < checkedListBoxAdmin.Items.Count; i++)
                {
                    if (checkedListBoxAdmin.GetItemChecked(i))
                    {
                        text = checkedListBoxAdmin.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        arr.Add(clPart.stPart.idpart);
                    }
                }

                if (arr.Count > 0) ret.adminline = clWork.GetStringData(arr);
                else ret.adminline = null;

                arr = new List<int>();
                for (int i = 0; i < checkedListBoxWasher.Items.Count; i++)
                {
                    if (checkedListBoxWasher.GetItemChecked(i))
                    {
                        text = checkedListBoxWasher.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        arr.Add(clPart.stPart.idpart);
                    }
                }

                if (arr.Count > 0) ret.washerline = clWork.GetStringData(arr);
                else ret.washerline = null;

                if (comboBoxPlace.Text.Length > 1)
                {
                    clPlace = new CPlace(connect, comboBoxPlace.Text.Trim());
                    ret.idplace = clPlace.stPlace.id;
                }
                else ret.idplace = 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            return ret;
        }

        public STGameDays GetFl()
        {
            return rData;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                rData = read_data();

                if (mode == 1)
                {
                    if (clWork.Update(rData, (STGameDays)oldData)) DialogResult = DialogResult.OK;
                }

                if (mode == 0)
                {
                    if (clWork.Insert(rData)) DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
    }
}
