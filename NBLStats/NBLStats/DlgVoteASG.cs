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
    public partial class DlgVoteASG : Form
    {
        SqlConnection connect;

        CVoteAllStarsGame clWork;

        STVoteASG stC;
        STVoteASG gstDV;

        int idseason;
        int mode;

        string caption;

        int[] Data;

        CPlayer clPlayer;
        CCoach clCoach;

        public DlgVoteASG(SqlConnection cn, int isd)
        {
            InitializeComponent();

            connect = cn;

            idseason = isd;

            caption = "Добавить голосование";

            mode = 0;
        }

        public DlgVoteASG(SqlConnection cn, STVoteASG st)
        {
            InitializeComponent();

            connect = cn;
            gstDV = st;

            idseason = gstDV.idseason;

            caption = "Редактировать голосование";

            mode = 1;
        }
        

        private void DlgVoteASG_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = caption;

                clWork = new CVoteAllStarsGame(connect);
                
                if (mode == 1) set_data();

                init_list1d();
                init_list1a();
                init_list1c();
                init_list1ch();
                init_list2d();
                init_list2a();
                init_list2c();
                init_list2ch();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        void init_list1d()
        {
            int[] arr = {289,772,2,142,1584,1686,939,857,198,453,1222,1648,911,41,516,155,668,1658,1195,1277,440,759,
                        835,714,1744,1070,1646,157,1160,1586,1467,1114,1476,1726,1525,1592,843,1328,1690,1461,233,1429,
                        360,191,848,435,313,1677,792,449,1610,1731};

            string name;
            checkedListBox1d.Items.Clear();

            List<STPlayer> lst_p = new List<STPlayer>();

            for (int i = 0; i < arr.Length; i++)
            {
                clPlayer = new CPlayer(connect, arr[i]);
                lst_p.Add(clPlayer.stPlayer);
            }

            ListCompareNamePlayer comp = new ListCompareNamePlayer();
            lst_p.Sort(comp);

            foreach (STPlayer item in lst_p)
            {
                name = string.Format("{0} {1} ({2})", item.family, item.name, item.idplayer);

                if (mode == 0)
                    checkedListBox1d.Items.Add(name, false);
                else
                {
                    if (item.idplayer == Data[0] || item.idplayer == Data[1])
                        checkedListBox1d.Items.Add(name, true);
                    else checkedListBox1d.Items.Add(name, false);
                }
            }
        }
        void init_list1a()
        {
            int[] arr = {1509,775,1736,1572,1193,1505,481,1482,1016,1568,75,307,918,1141,88,161,577,300,173,1084,910,29,
                         658,205,1196,617,485,1558,1378,995,1618,1404,1302,652,1345,1167,1424,1471,1714,1522,1181,958,66,
                         947,1462,1634,1580,907,285,790,1621,671};

            string name;
            checkedListBox1a.Items.Clear();

            List<STPlayer> lst_p = new List<STPlayer>();

            for (int i = 0; i < arr.Length; i++)
            {
                clPlayer = new CPlayer(connect, arr[i]);
                lst_p.Add(clPlayer.stPlayer);
            }

            ListCompareNamePlayer comp = new ListCompareNamePlayer();
            lst_p.Sort(comp);


            foreach (STPlayer item in lst_p)
            {

                name = string.Format("{0} {1} ({2})", item.family, item.name, item.idplayer);

                if (mode == 0)
                    checkedListBox1a.Items.Add(name, false);
                else
                {
                    if (item.idplayer == Data[2] || item.idplayer == Data[3])
                        checkedListBox1a.Items.Add(name, true);
                    else checkedListBox1a.Items.Add(name, false);
                }
            }
        }
        void init_list1c()
        {
            int[] arr = {1509,775,1736,1572,1193,1505,481,1482,1016,1568,75,307,918,1141,88,161,577,300,173,1084,910,29,
                         658,205,1196,617,485,1558,1378,995,1618,1404,1302,652,1345,1167,1424,1471,1714,1522,1181,958,66,
                         947,1462,1634,1580,907,285,790,1621,671};

            string name;
            checkedListBox1c.Items.Clear();

            List<STPlayer> lst_p = new List<STPlayer>();

            for (int i = 0; i < arr.Length; i++)
            {
                clPlayer = new CPlayer(connect, arr[i]);
                lst_p.Add(clPlayer.stPlayer);
            }

            ListCompareNamePlayer comp = new ListCompareNamePlayer();
            lst_p.Sort(comp);

            foreach (STPlayer item in lst_p)
            {
                name = string.Format("{0} {1} ({2})", item.family, item.name, item.idplayer);

                if (mode == 0)
                    checkedListBox1c.Items.Add(name, false);
                else
                {
                    if (item.idplayer == Data[4])
                        checkedListBox1c.Items.Add(name, true);
                    else checkedListBox1c.Items.Add(name, false);
                }
            }
        }
        void init_list1ch()
        {
            int[] arr = {123,9,68,4,62,78,43,55,6,170,193,85,108,195,203,225,26,148,190,75,226,120};

            string name;
            checkedListBox1ch.Items.Clear();

            List<STCoach> lst_p = new List<STCoach>();

            for (int i = 0; i < arr.Length; i++)
            {
                clCoach = new CCoach(connect, arr[i]);
                lst_p.Add(clCoach.stCoach);
            }

            ListCompareNameCoach comp = new ListCompareNameCoach();
            lst_p.Sort(comp);

            foreach (STCoach item in lst_p)
            {

                name = string.Format("{0} {1} ({2})", item.family, item.name, item.idcoach);

                if (mode == 0)
                    checkedListBox1ch.Items.Add(name, false);
                else
                {
                    if (item.idcoach == Data[5])
                        checkedListBox1ch.Items.Add(name, true);
                    else checkedListBox1ch.Items.Add(name, false);
                }
            }
        }
        void init_list2d()
        {
            int[] arr = {};

            string name;
            checkedListBox2d.Items.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                clPlayer = new CPlayer(connect, arr[i]);

                name = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name, arr[i]);

                if (mode == 0)
                    checkedListBox2d.Items.Add(name, false);
                else
                {
                    if (arr[i] == Data[6] || arr[i] == Data[7])
                        checkedListBox2d.Items.Add(name, true);
                    else checkedListBox2d.Items.Add(name, false);
                }
            }
        }
        void init_list2a()
        {
            int[] arr = {};

            string name;
            checkedListBox2a.Items.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                clPlayer = new CPlayer(connect, arr[i]);

                name = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name, arr[i]);

                if (mode == 0)
                    checkedListBox2a.Items.Add(name, false);
                else
                {
                    if (arr[i] == Data[8] || arr[i] == Data[9])
                        checkedListBox2a.Items.Add(name, true);
                    else checkedListBox2a.Items.Add(name, false);
                }
            }
        }
        void init_list2c()
        {
            int[] arr = {};

            string name;
            checkedListBox2c.Items.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                clPlayer = new CPlayer(connect, arr[i]);

                name = string.Format("{0} {1} ({2})", clPlayer.stPlayer.family, clPlayer.stPlayer.name, arr[i]);

                if (mode == 0)
                    checkedListBox2c.Items.Add(name, false);
                else
                {
                    if (arr[i] == Data[10])
                        checkedListBox2c.Items.Add(name, true);
                    else checkedListBox2c.Items.Add(name, false);
                }
            }
        }
        void init_list2ch()
        {
            int[] arr = {};

            string name;
            checkedListBox2ch.Items.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                clCoach = new CCoach(connect, arr[i]);

                name = string.Format("{0} {1} ({2})", clCoach.stCoach.family, clCoach.stCoach.name, arr[i]);

                if (mode == 0)
                    checkedListBox2ch.Items.Add(name, false);
                else
                {
                    if (arr[i] == Data[11])
                        checkedListBox2ch.Items.Add(name, true);
                    else checkedListBox2ch.Items.Add(name, false);
                }
            }
        }

        private void set_data()
        {
            string text;

            try
            {
                textBoxName.Text = gstDV.name;
                textBoxEmail.Text = gstDV.email;
                textBoxIP.Text = gstDV.ip;

                dateTimePickerDate.Value = gstDV.ed;

                dateTimePickerTime.Value = gstDV.ed;

                Data = con_from_string_to_arr(gstDV.data);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STVoteASG read_data()
        {
            int[] arr = new int[12];
 
            STVoteASG ret = new STVoteASG();

            int i;
            int cnt;

            try
            {
                ret.idseason = idseason;

                ret.name = textBoxName.Text.Trim();
                ret.ip = textBoxIP.Text.Trim();
                ret.email = textBoxEmail.Text.Trim();

                cnt = 0;
                arr[0] = 0;
                arr[1] = 0;
                for (i = 0; i < checkedListBox1d.Items.Count; i++)
                {
                    if (cnt == 2) break;

                    if (checkedListBox1d.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[0] = get_int(checkedListBox1d.Items[i].ToString());
                            cnt = 1;
                        }
                        else if (cnt == 1)
                        {
                            arr[1] = get_int(checkedListBox1d.Items[i].ToString());
                            cnt = 2;
                        }
                    }
                }

                cnt = 0;
                arr[2] = 0;
                arr[3] = 0;
                for (i = 0; i < checkedListBox1a.Items.Count; i++)
                {
                    if (cnt == 2) break;

                    if (checkedListBox1a.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[2] = get_int(checkedListBox1a.Items[i].ToString());
                            cnt = 1;
                        }
                        else if (cnt == 1)
                        {
                            arr[3] = get_int(checkedListBox1a.Items[i].ToString());
                            cnt = 2;
                        }
                    }
                }

                cnt = 0;
                arr[4] = 0;
                for (i = 0; i < checkedListBox1c.Items.Count; i++)
                {
                    if (cnt == 1) break;

                    if (checkedListBox1c.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[4] = get_int(checkedListBox1c.Items[i].ToString());
                            cnt = 1;
                        }
                    }
                }

                cnt = 0;
                arr[5] = 0;
                for (i = 0; i < checkedListBox1ch.Items.Count; i++)
                {
                    if (cnt == 1) break;

                    if (checkedListBox1ch.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[5] = get_int(checkedListBox1ch.Items[i].ToString());
                            cnt = 1;
                        }
                    }
                }

                cnt = 0;
                arr[6] = 0;
                arr[7] = 0;
                for (i = 0; i < checkedListBox2d.Items.Count; i++)
                {
                    if (cnt == 2) break;

                    if (checkedListBox2d.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[6] = get_int(checkedListBox2d.Items[i].ToString());
                            cnt = 1;
                        }
                        else if (cnt == 1)
                        {
                            arr[7] = get_int(checkedListBox2d.Items[i].ToString());
                            cnt = 2;
                        }
                    }
                }

                cnt = 0;
                arr[8] = 0;
                arr[9] = 0;
                for (i = 0; i < checkedListBox2a.Items.Count; i++)
                {
                    if (cnt == 2) break;

                    if (checkedListBox2a.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[8] = get_int(checkedListBox2a.Items[i].ToString());
                            cnt = 1;
                        }
                        else if (cnt == 1)
                        {
                            arr[9] = get_int(checkedListBox2a.Items[i].ToString());
                            cnt = 2;
                        }
                    }
                }

                cnt = 0;
                arr[10] = 0;
                for (i = 0; i < checkedListBox2c.Items.Count; i++)
                {
                    if (cnt == 1) break;

                    if (checkedListBox2c.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[10] = get_int(checkedListBox2c.Items[i].ToString());
                            cnt = 1;
                        }
                    }
                }

                cnt = 0;
                arr[11] = 0;
                for (i = 0; i < checkedListBox2ch.Items.Count; i++)
                {
                    if (cnt == 1) break;

                    if (checkedListBox2ch.GetItemChecked(i))
                    {
                        if (cnt == 0)
                        {
                            arr[11] = get_int(checkedListBox2ch.Items[i].ToString());
                            cnt = 1;
                        }
                    }
                }

                ret.data = con_from_arr_to_string(arr);

                ret.ed = new DateTime(dateTimePickerDate.Value.Year, dateTimePickerDate.Value.Month,
                    dateTimePickerDate.Value.Day, dateTimePickerTime.Value.Hour, dateTimePickerTime.Value.Minute,
                    0, 0);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private int get_int(string data)
        {
            int ret = 0;

            char[] del = { ' ', '(', ')' };

            try
            {
                string[] words = data.Split(del);
                if (words[3] != null)
                    ret = int.Parse(words[3].Trim());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private bool save()
        {
            bool ret = false;

            try
            {
                stC = new STVoteASG();

                stC = read_data();

                if (mode == 1)
                    ret = clWork.Update(stC, gstDV);
                else
                    ret = clWork.Insert(stC);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        public STVoteASG GetFl()
        {
           return stC;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (save()) DialogResult = DialogResult.OK;
        }

        private int[] con_from_string_to_arr(string data)
        {
            int[] ret = new int[12];

            try
            {

                char[] del = { ',' };
                string[] words = data.Split(del);

                if (words[0] != null)
                    ret[0] = int.Parse(words[0]);
                else ret[0] = 0;

                if (words[1] != null)
                    ret[1] = int.Parse(words[1]);
                else ret[1] = 0;

                if (words[2] != null)
                    ret[2] = int.Parse(words[2]);
                else ret[2] = 0;

                if (words[3] != null)
                    ret[3] = int.Parse(words[3]);
                else ret[3] = 0;

                if (words[4] != null)
                    ret[4] = int.Parse(words[4]);
                else ret[4] = 0;

                if (words[5] != null)
                    ret[5] = int.Parse(words[5]);
                else ret[5] = 0;

                if (words[6] != null)
                    ret[6] = int.Parse(words[6]);
                else ret[6] = 0;

                if (words[7] != null)
                    ret[7] = int.Parse(words[7]);
                else ret[7] = 0;

                if (words[8] != null)
                    ret[8] = int.Parse(words[8]);
                else ret[8] = 0;

                if (words[9] != null)
                    ret[9] = int.Parse(words[9]);
                else ret[9] = 0;

                if (words[10] != null)
                    ret[10] = int.Parse(words[10]);
                else ret[10] = 0;

                if (words[11] != null)
                    ret[11] = int.Parse(words[11]);
                else ret[11] = 0;


            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }

        private string con_from_arr_to_string(int[] data)
        {
            string ret = null;
            bool first = true;

            try
            {

                for (int i = 0; i < data.Length; i++)
                {
                    if (first)
                    {
                        ret = data[i].ToString();
                        first = false;
                    }
                    else ret += string.Format(",{0}", data[i]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return ret;
        }
    }


    public class ListCompareNamePlayer : IComparer<STPlayer>
    {
        public int Compare(STPlayer x, STPlayer y)
        {
            if (string.Compare(x.family,y.family) < 0) return -1;
            if (string.Compare(x.family, y.family) >= 0) return 1;
            
            return 0;
        }

    };

    public class ListCompareNameCoach : IComparer<STCoach>
    {
        public int Compare(STCoach x, STCoach y)
        {
            if (string.Compare(x.family, y.family) < 0) return -1;
            if (string.Compare(x.family, y.family) >= 0) return 1;

            return 0;
        }

    };
}
