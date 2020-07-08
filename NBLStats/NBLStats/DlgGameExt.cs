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
 
    public partial class DlgGameExt : Form
    {
        SqlConnection connect;
        STGameTagsPart data;
        STGameTagsPart newdata;
        
        int mode;

        CParticipant clPart;

        bool all;

        public DlgGameExt(SqlConnection cn, STGameTagsPart? st)
        {
            InitializeComponent();
            
            connect = cn;

            if (st != null)
            {
                mode = 1;
                data = (STGameTagsPart)st;
            }
            else mode = 0;
        }

        private void DlgGameExt_Load(object sender, EventArgs e)
        {
            try
            {
                clPart = new CParticipant(connect);

                all = false;
                init();


                //if (data.strinterviea != null)
                //    textBoxIntA.Text = data.strinterviea;
                //if (data.strintervieb != null)
                //    textBoxIntB.Text = data.strintervieb;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init()
        {
            try
            {
                init_list_secretar();
                init_list_tablo();
                init_list_time();
                init_list_24();
                init_list_diktor();
                init_list_vrach();
                init_list_video();
                init_list_komissar();
                init_list_foto();
                init_list_interviw();
                init_list_svabra();
                init_list_report();
                init_list_stat();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private void init_list_secretar()
        {
            try
            {
                checkedListBoxSecretar.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(1);
                else list = clPart.GetList(1, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxSecretar.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.secretar)
                        {
                            if (list[i].idpart == j) checkedListBoxSecretar.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_tablo()
        {
            try
            {
                checkedListBoxTable.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(2);
                else list = clPart.GetList(2, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxTable.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.tablo)
                        {
                            if (list[i].idpart == j) checkedListBoxTable.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_time()
        {
            try
            {
                checkedListBoxTime.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(2);
                else list = clPart.GetList(2, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxTime.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.time)
                        {
                            if (list[i].idpart == j) checkedListBoxTime.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_24()
        {
            try
            {
                checkedListBox24.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(2);
                else list = clPart.GetList(2, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBox24.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.t24)
                        {
                            if (list[i].idpart == j) checkedListBox24.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_diktor()
        {
            try
            {
                checkedListBoxDiktor.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(3);
                else list = clPart.GetList(3, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxDiktor.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.diktor)
                        {
                            if (list[i].idpart == j) checkedListBoxDiktor.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_vrach()
        {
            try
            {
                checkedListBoxVrach.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(4);
                else list = clPart.GetList(4, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxVrach.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.vrach)
                        {
                            if (list[i].idpart == j) checkedListBoxVrach.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_komissar()
        {
            try
            {
                checkedListBoxKomissar.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(13);
                else list = clPart.GetList(13, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxKomissar.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.komissar)
                        {
                            if (list[i].idpart == j) checkedListBoxKomissar.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_video()
        {
            try
            {
                checkedListBoxVideo.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(5);
                else list = clPart.GetList(5, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxVideo.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.video)
                        {
                            if (list[i].idpart == j) checkedListBoxVideo.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_foto()
        {
            try
            {
                checkedListBoxFoto.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(6);
                else list = clPart.GetList(6, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxFoto.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.foto)
                        {
                            if (list[i].idpart == j) checkedListBoxFoto.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_interviw()
        {
            try
            {
                checkedListBoxIntrviewA.Items.Clear();
                checkedListBoxIntrviewB.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(10);
                else list = clPart.GetList(10, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxIntrviewA.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));
                    checkedListBoxIntrviewB.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.interviewa)
                        {
                            if (list[i].idpart == j) checkedListBoxIntrviewA.SetItemChecked(i, true);
                        }
                        foreach (int j in data.interviewb)
                        {
                            if (list[i].idpart == j) checkedListBoxIntrviewB.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_svabra()
        {
            try
            {
                checkedListBoxShvabra.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(8);
                else list = clPart.GetList(8, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxShvabra.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.svabrist)
                        {
                            if (list[i].idpart == j) checkedListBoxShvabra.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_report()
        {
            try
            {
                checkedListBoxReport.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(11);
                else list = clPart.GetList(11, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxReport.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.report)
                        {
                            if (list[i].idpart == j) checkedListBoxReport.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }
        private void init_list_stat()
        {
            try
            {
                checkedListBoxStats.Items.Clear();

                List<STParticipant> list;

                if (all) list = clPart.GetList(12);
                else list = clPart.GetList(12, DateTime.Now);

                for (int i = 0; i < list.Count; i++)
                {
                    checkedListBoxStats.Items.Add(string.Format("{0} {1}", list[i].family, list[i].name));

                    if (mode == 1)
                    {
                        foreach (int j in data.statist)
                        {
                            if (list[i].idpart == j) checkedListBoxStats.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }
        }

        private STGameTagsPart read_data()
        {
            STGameTagsPart rData = new STGameTagsPart();
            rData.diktor = new List<int>();
            rData.foto = new List<int>();
            rData.interviewa = new List<int>();
            rData.interviewb = new List<int>();
            rData.komissar = new List<int>();
            rData.report = new List<int>();
            rData.secretar = new List<int>();
            rData.statist = new List<int>();
            rData.svabrist = new List<int>();
            rData.tablo = new List<int>();
            rData.video = new List<int>();
            rData.vrach = new List<int>();
            rData.t24 = new List<int>();
            rData.time = new List<int>();


            string text = null;
            string family = null;
            string name = null;
            string[] words;

            try
            {
               // if (textBoxIntA.Text.Length > 0)
               //     rData.strinterviea = textBoxIntA.Text.Trim();
               // else rData.strinterviea = null;

              //  if (textBoxIntB.Text.Length > 0)
              //      rData.strintervieb = textBoxIntB.Text.Trim();
              //  else rData.strintervieb = null;

                /* секретарь */
                for (int i = 0; i < checkedListBoxSecretar.Items.Count; i++)
                {
                    if (checkedListBoxSecretar.GetItemChecked(i))
                    {
                        text = checkedListBoxSecretar.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.secretar.Add(clPart.stPart.idpart);
                    }
                }
                /* оператор табло */
                for (int i = 0; i < checkedListBoxTable.Items.Count; i++)
                {
                    if (checkedListBoxTable.GetItemChecked(i))
                    {
                        text = checkedListBoxTable.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.tablo.Add(clPart.stPart.idpart);
                    }
                }
                /* оператор время */
                for (int i = 0; i < checkedListBoxTime.Items.Count; i++)
                {
                    if (checkedListBoxTime.GetItemChecked(i))
                    {
                        text = checkedListBoxTime.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.time.Add(clPart.stPart.idpart);
                    }
                }
                /* оператор 24 */
                for (int i = 0; i < checkedListBox24.Items.Count; i++)
                {
                    if (checkedListBox24.GetItemChecked(i))
                    {
                        text = checkedListBox24.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.t24.Add(clPart.stPart.idpart);
                    }
                }
                /* диктор */
                for (int i = 0; i < checkedListBoxDiktor.Items.Count; i++)
                {
                    if (checkedListBoxDiktor.GetItemChecked(i))
                    {
                        text = checkedListBoxDiktor.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.diktor.Add(clPart.stPart.idpart);
                    }
                }
                /* врач */
                for (int i = 0; i < checkedListBoxVrach.Items.Count; i++)
                {
                    if (checkedListBoxVrach.GetItemChecked(i))
                    {
                        text = checkedListBoxVrach.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.vrach.Add(clPart.stPart.idpart);
                    }
                }
                /* комиссар */
                for (int i = 0; i < checkedListBoxKomissar.Items.Count; i++)
                {
                    if (checkedListBoxKomissar.GetItemChecked(i))
                    {
                        text = checkedListBoxKomissar.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.komissar.Add(clPart.stPart.idpart);
                    }
                }
                /* видео */
                for (int i = 0; i < checkedListBoxVideo.Items.Count; i++)
                {
                    if (checkedListBoxVideo.GetItemChecked(i))
                    {
                        text = checkedListBoxVideo.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.video.Add(clPart.stPart.idpart);
                    }
                }
                /* фото */
                for (int i = 0; i < checkedListBoxFoto.Items.Count; i++)
                {
                    if (checkedListBoxFoto.GetItemChecked(i))
                    {
                        text = checkedListBoxFoto.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.foto.Add(clPart.stPart.idpart);
                    }
                }
                /* интревью А */
                for (int i = 0; i < checkedListBoxIntrviewA.Items.Count; i++)
                {
                    if (checkedListBoxIntrviewA.GetItemChecked(i))
                    {
                        text = checkedListBoxIntrviewA.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.interviewa.Add(clPart.stPart.idpart);
                    }
                }
                /* интервью Б */
                for (int i = 0; i < checkedListBoxIntrviewB.Items.Count; i++)
                {
                    if (checkedListBoxIntrviewB.GetItemChecked(i))
                    {
                        text = checkedListBoxIntrviewB.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.interviewb.Add(clPart.stPart.idpart);
                    }
                }
                /* швабра */
                for (int i = 0; i < checkedListBoxShvabra.Items.Count; i++)
                {
                    if (checkedListBoxShvabra.GetItemChecked(i))
                    {
                        text = checkedListBoxShvabra.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.svabrist.Add(clPart.stPart.idpart);
                    }
                }
                /* отчет */
                for (int i = 0; i < checkedListBoxReport.Items.Count; i++)
                {
                    if (checkedListBoxReport.GetItemChecked(i))
                    {
                        text = checkedListBoxReport.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.report.Add(clPart.stPart.idpart);
                    }
                }
                /* статистика */
                for (int i = 0; i < checkedListBoxStats.Items.Count; i++)
                {
                    if (checkedListBoxStats.GetItemChecked(i))
                    {
                        text = checkedListBoxStats.Items[i].ToString();
                        if (text.Length > 0)
                        {
                            char[] del = { ' ' };
                            words = text.Split(del);

                            family = words[0];
                            name = words[1];

                            clPart = new CParticipant(connect, family, name);

                        }

                        rData.statist.Add(clPart.stPart.idpart);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); }

            return rData;
        }

        public STGameTagsPart GetData()
        {
            return newdata;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                newdata = read_data();

                DialogResult = DialogResult.OK;
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source); } 
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked == true) all = true;
            else all = false;

            init();
        }
      
    }
}
