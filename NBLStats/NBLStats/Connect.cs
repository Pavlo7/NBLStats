using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Xml;

namespace NBLStats
{
    struct Authentication
    {
        public string ServerName;
        public string DBName;
        public string Login;
        public string Password;
    };
    
    public partial class Connect : Form
    {
        private SqlConnection sql;
        string gl_error;
        CParamApp clParamApp;
        Authentication aus;

        public Connect()
        {
            InitializeComponent();

            clParamApp = new CParamApp();
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            aus = new Authentication();

            try
            {
                aus.ServerName = clParamApp.s_Connect.server;
                aus.DBName = clParamApp.s_Connect.db;
                aus.Login = clParamApp.s_Connect.user;
                aus.Password = clParamApp.s_Connect.pwd;
               
                textBoxLogin.Text = aus.Login;
                textBoxPwd.Text = aus.Password;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString().Trim(),
                    "Метод: <ConnectToSqlServer_Load(object sender, EventArgs e)>.");
            }
        }

        /* Кнопка <Отмена> */
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /* Кнопка <Выполнить> */
        private void buttonGo_Click(object sender, EventArgs e)
        {
            try
            {
                aus.Login = textBoxLogin.Text.Trim();
                aus.Password = textBoxPwd.Text.Trim();

                string connectString = null;
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);

                builder.DataSource = aus.ServerName;
                builder.InitialCatalog = aus.DBName;
                builder.UserID = aus.Login;
                builder.Password = aus.Password;

                string temp = string.Format("Data Source=(local);Initial Catalog={0};" +
                    "Integrated Security=True", aus.DBName);

                //sql = new SqlConnection(builder.ConnectionString);
                sql = new SqlConnection(temp);
                sql.Open();

                if (sql.State == ConnectionState.Open) DialogResult = DialogResult.Yes;
            }
            catch (Exception es) { MessageBox.Show(es.Message.ToString().Trim()); }
        }

        /* Передает коннект */
        public void RetConnect(out SqlConnection connect)
        {
            connect = sql;
        }
     
    }
}