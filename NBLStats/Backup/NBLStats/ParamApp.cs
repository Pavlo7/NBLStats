using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace NBLStats
{
    public partial class ParamApp : Form
    {
        public ParamApp()
        {
            InitializeComponent();
        }

        private void ParamApp_Load(object sender, EventArgs e)
        {
            read_xml();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            save_data();
        }

        private void read_xml()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();

                xDoc.Load("config.xml");

                foreach (XmlElement element in xDoc.DocumentElement)
                {
                    if (element.Name.Equals("ConnectDB"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (node.Attributes[0].Value.Equals("Server"))
                            {
                                textBoxServer.Text = node.Attributes[1].Value;
                            }
                            if (node.Attributes[0].Value.Equals("DB"))
                            {
                                textBoxDB.Text = node.Attributes[1].Value;
                            }
                            if (node.Attributes[0].Value.Equals("User"))
                            {
                                textBoxUser.Text = node.Attributes[1].Value;
                            }
                            if (node.Attributes[0].Value.Equals("Pwd"))
                            {
                                textBoxPwd.Text = node.Attributes[1].Value;
                            }
                        }
                    }

                    if (element.Name.Equals("PathData"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (node.Attributes[0].Value.Equals("PathReport"))
                            {
                                textBoxPathReport.Text = node.Attributes[1].Value;
                            }
                            if (node.Attributes[0].Value.Equals("PathPattern"))
                            {
                                textBoxPathPattern.Text = node.Attributes[1].Value;
                            }
                            if (node.Attributes[0].Value.Equals("PathFoto"))
                            {
                                textBoxPathFoto.Text = node.Attributes[1].Value;
                            }
                            if (node.Attributes[0].Value.Equals("PathFanGameImport"))
                            {
                                textBoxPathFGImport.Text = node.Attributes[1].Value;
                            }
                            if (node.Attributes[0].Value.Equals("PathFanGameArch"))
                            {
                                textBoxPathFGArch.Text = node.Attributes[1].Value;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save_data()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();

                xDoc.Load("config.xml");

                foreach (XmlElement element in xDoc.DocumentElement)
                {
                    if (element.Name.Equals("ConnectDB"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (node.Attributes[0].Value.Equals("Server"))
                            {
                                node.Attributes[1].Value = textBoxServer.Text.Trim();
                            }
                            if (node.Attributes[0].Value.Equals("DB"))
                            {
                                node.Attributes[1].Value = textBoxDB.Text.Trim();
                            }
                            if (node.Attributes[0].Value.Equals("User"))
                            {
                                node.Attributes[1].Value = textBoxUser.Text.Trim();
                            }
                            if (node.Attributes[0].Value.Equals("Pwd"))
                            {
                                node.Attributes[1].Value = textBoxPwd.Text.Trim();
                            }
                        }
                    }

                    if (element.Name.Equals("PathData"))
                    {
                        foreach (XmlNode node in element.ChildNodes)
                        {
                            if (node.Attributes[0].Value.Equals("PathReport"))
                            {
                                node.Attributes[1].Value = textBoxPathReport.Text.Trim();
                            }
                            if (node.Attributes[0].Value.Equals("PathPattern"))
                            {
                                node.Attributes[1].Value = textBoxPathPattern.Text.Trim();
                            }
                            if (node.Attributes[0].Value.Equals("PathFoto"))
                            {
                                node.Attributes[1].Value = textBoxPathFoto.Text.Trim();
                            }
                            if (node.Attributes[0].Value.Equals("PathFanGameImport"))
                            {
                                node.Attributes[1].Value = textBoxPathFGImport.Text.Trim();
                            }
                            if (node.Attributes[0].Value.Equals("PathFanGameArch"))
                            {
                                node.Attributes[1].Value = textBoxPathFGArch.Text.Trim();
                            }
                        }
                    }
                }

                xDoc.Save("config.xml");

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEditPathReport_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPathReport.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonEditPathPattern_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPathPattern.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonEditPathFoto_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPathFoto.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonEditPathFGI_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPathFGImport.Text = folderBrowserDialog1.SelectedPath;
        }

        private void buttonEditPathFGA_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPathFGArch.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}