namespace NBLStats
{
    partial class ParamApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlParam = new System.Windows.Forms.TabControl();
            this.tabPageConnect = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.tabPagePath = new System.Windows.Forms.TabPage();
            this.textBoxPathSgmArch = new System.Windows.Forms.TextBox();
            this.buttonEditPathSgmArch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPathSgm = new System.Windows.Forms.TextBox();
            this.buttonEditPathSGM = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPathFGArch = new System.Windows.Forms.TextBox();
            this.buttonEditPathFGA = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPathFGImport = new System.Windows.Forms.TextBox();
            this.buttonEditPathFGI = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPathFoto = new System.Windows.Forms.TextBox();
            this.buttonEditPathFoto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPathPattern = new System.Windows.Forms.TextBox();
            this.textBoxPathReport = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditPathPattern = new System.Windows.Forms.Button();
            this.buttonEditPathReport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControlParam.SuspendLayout();
            this.tabPageConnect.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPagePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlParam
            // 
            this.tabControlParam.Controls.Add(this.tabPageConnect);
            this.tabControlParam.Controls.Add(this.tabPagePath);
            this.tabControlParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlParam.Location = new System.Drawing.Point(0, 0);
            this.tabControlParam.Name = "tabControlParam";
            this.tabControlParam.SelectedIndex = 0;
            this.tabControlParam.Size = new System.Drawing.Size(351, 332);
            this.tabControlParam.TabIndex = 0;
            // 
            // tabPageConnect
            // 
            this.tabPageConnect.AllowDrop = true;
            this.tabPageConnect.Controls.Add(this.groupBox2);
            this.tabPageConnect.Controls.Add(this.groupBox1);
            this.tabPageConnect.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnect.Name = "tabPageConnect";
            this.tabPageConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnect.Size = new System.Drawing.Size(343, 306);
            this.tabPageConnect.TabIndex = 0;
            this.tabPageConnect.Text = "Подключение к БД";
            this.tabPageConnect.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxPwd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxUser);
            this.groupBox2.Location = new System.Drawing.Point(204, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 113);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Идентификация";
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Location = new System.Drawing.Point(12, 79);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(109, 20);
            this.textBoxPwd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Пользователь";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(12, 33);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(109, 20);
            this.textBoxUser.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxServer);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 113);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sql Server";
            // 
            // textBoxDB
            // 
            this.textBoxDB.Location = new System.Drawing.Point(12, 79);
            this.textBoxDB.Name = "textBoxDB";
            this.textBoxDB.Size = new System.Drawing.Size(172, 20);
            this.textBoxDB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "База данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сервер";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(12, 33);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(172, 20);
            this.textBoxServer.TabIndex = 1;
            // 
            // tabPagePath
            // 
            this.tabPagePath.Controls.Add(this.textBoxPathSgmArch);
            this.tabPagePath.Controls.Add(this.buttonEditPathSgmArch);
            this.tabPagePath.Controls.Add(this.label10);
            this.tabPagePath.Controls.Add(this.textBoxPathSgm);
            this.tabPagePath.Controls.Add(this.buttonEditPathSGM);
            this.tabPagePath.Controls.Add(this.label11);
            this.tabPagePath.Controls.Add(this.textBoxPathFGArch);
            this.tabPagePath.Controls.Add(this.buttonEditPathFGA);
            this.tabPagePath.Controls.Add(this.label9);
            this.tabPagePath.Controls.Add(this.textBoxPathFGImport);
            this.tabPagePath.Controls.Add(this.buttonEditPathFGI);
            this.tabPagePath.Controls.Add(this.label8);
            this.tabPagePath.Controls.Add(this.textBoxPathFoto);
            this.tabPagePath.Controls.Add(this.buttonEditPathFoto);
            this.tabPagePath.Controls.Add(this.label5);
            this.tabPagePath.Controls.Add(this.textBoxPathPattern);
            this.tabPagePath.Controls.Add(this.textBoxPathReport);
            this.tabPagePath.Controls.Add(this.label6);
            this.tabPagePath.Controls.Add(this.buttonEditPathPattern);
            this.tabPagePath.Controls.Add(this.buttonEditPathReport);
            this.tabPagePath.Controls.Add(this.label7);
            this.tabPagePath.Location = new System.Drawing.Point(4, 22);
            this.tabPagePath.Name = "tabPagePath";
            this.tabPagePath.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePath.Size = new System.Drawing.Size(343, 306);
            this.tabPagePath.TabIndex = 1;
            this.tabPagePath.Text = "Каталоги";
            this.tabPagePath.UseVisualStyleBackColor = true;
            // 
            // textBoxPathSgmArch
            // 
            this.textBoxPathSgmArch.Location = new System.Drawing.Point(7, 273);
            this.textBoxPathSgmArch.Name = "textBoxPathSgmArch";
            this.textBoxPathSgmArch.ReadOnly = true;
            this.textBoxPathSgmArch.Size = new System.Drawing.Size(286, 20);
            this.textBoxPathSgmArch.TabIndex = 22;
            // 
            // buttonEditPathSgmArch
            // 
            this.buttonEditPathSgmArch.Location = new System.Drawing.Point(301, 271);
            this.buttonEditPathSgmArch.Name = "buttonEditPathSgmArch";
            this.buttonEditPathSgmArch.Size = new System.Drawing.Size(30, 23);
            this.buttonEditPathSgmArch.TabIndex = 21;
            this.buttonEditPathSgmArch.Text = "...";
            this.buttonEditPathSgmArch.UseVisualStyleBackColor = true;
            this.buttonEditPathSgmArch.Click += new System.EventHandler(this.buttonEditPathSgmArch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(6, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Архивный каталог файлов статиститки";
            // 
            // textBoxPathSgm
            // 
            this.textBoxPathSgm.Location = new System.Drawing.Point(7, 233);
            this.textBoxPathSgm.Name = "textBoxPathSgm";
            this.textBoxPathSgm.ReadOnly = true;
            this.textBoxPathSgm.Size = new System.Drawing.Size(286, 20);
            this.textBoxPathSgm.TabIndex = 19;
            // 
            // buttonEditPathSGM
            // 
            this.buttonEditPathSGM.Location = new System.Drawing.Point(301, 231);
            this.buttonEditPathSGM.Name = "buttonEditPathSGM";
            this.buttonEditPathSGM.Size = new System.Drawing.Size(30, 23);
            this.buttonEditPathSGM.TabIndex = 18;
            this.buttonEditPathSGM.Text = "...";
            this.buttonEditPathSGM.UseVisualStyleBackColor = true;
            this.buttonEditPathSGM.Click += new System.EventHandler(this.buttonEditPathSGM_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Каталог импорта файлов статистики";
            // 
            // textBoxPathFGArch
            // 
            this.textBoxPathFGArch.Location = new System.Drawing.Point(8, 184);
            this.textBoxPathFGArch.Name = "textBoxPathFGArch";
            this.textBoxPathFGArch.ReadOnly = true;
            this.textBoxPathFGArch.Size = new System.Drawing.Size(286, 20);
            this.textBoxPathFGArch.TabIndex = 16;
            // 
            // buttonEditPathFGA
            // 
            this.buttonEditPathFGA.Location = new System.Drawing.Point(302, 182);
            this.buttonEditPathFGA.Name = "buttonEditPathFGA";
            this.buttonEditPathFGA.Size = new System.Drawing.Size(30, 23);
            this.buttonEditPathFGA.TabIndex = 15;
            this.buttonEditPathFGA.Text = "...";
            this.buttonEditPathFGA.UseVisualStyleBackColor = true;
            this.buttonEditPathFGA.Click += new System.EventHandler(this.buttonEditPathFGA_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(7, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(254, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Каталог архивов файлов игры для болельщиков";
            // 
            // textBoxPathFGImport
            // 
            this.textBoxPathFGImport.Location = new System.Drawing.Point(8, 144);
            this.textBoxPathFGImport.Name = "textBoxPathFGImport";
            this.textBoxPathFGImport.ReadOnly = true;
            this.textBoxPathFGImport.Size = new System.Drawing.Size(286, 20);
            this.textBoxPathFGImport.TabIndex = 13;
            // 
            // buttonEditPathFGI
            // 
            this.buttonEditPathFGI.Location = new System.Drawing.Point(302, 142);
            this.buttonEditPathFGI.Name = "buttonEditPathFGI";
            this.buttonEditPathFGI.Size = new System.Drawing.Size(30, 23);
            this.buttonEditPathFGI.TabIndex = 12;
            this.buttonEditPathFGI.Text = "...";
            this.buttonEditPathFGI.UseVisualStyleBackColor = true;
            this.buttonEditPathFGI.Click += new System.EventHandler(this.buttonEditPathFGI_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(7, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(256, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Каталог импорта файлов игры для болельщиков";
            // 
            // textBoxPathFoto
            // 
            this.textBoxPathFoto.Location = new System.Drawing.Point(8, 102);
            this.textBoxPathFoto.Name = "textBoxPathFoto";
            this.textBoxPathFoto.ReadOnly = true;
            this.textBoxPathFoto.Size = new System.Drawing.Size(286, 20);
            this.textBoxPathFoto.TabIndex = 10;
            // 
            // buttonEditPathFoto
            // 
            this.buttonEditPathFoto.Location = new System.Drawing.Point(302, 100);
            this.buttonEditPathFoto.Name = "buttonEditPathFoto";
            this.buttonEditPathFoto.Size = new System.Drawing.Size(30, 23);
            this.buttonEditPathFoto.TabIndex = 9;
            this.buttonEditPathFoto.Text = "...";
            this.buttonEditPathFoto.UseVisualStyleBackColor = true;
            this.buttonEditPathFoto.Click += new System.EventHandler(this.buttonEditPathFoto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Каталог фото";
            // 
            // textBoxPathPattern
            // 
            this.textBoxPathPattern.Location = new System.Drawing.Point(9, 62);
            this.textBoxPathPattern.Name = "textBoxPathPattern";
            this.textBoxPathPattern.ReadOnly = true;
            this.textBoxPathPattern.Size = new System.Drawing.Size(286, 20);
            this.textBoxPathPattern.TabIndex = 7;
            // 
            // textBoxPathReport
            // 
            this.textBoxPathReport.Location = new System.Drawing.Point(9, 21);
            this.textBoxPathReport.Name = "textBoxPathReport";
            this.textBoxPathReport.ReadOnly = true;
            this.textBoxPathReport.Size = new System.Drawing.Size(286, 20);
            this.textBoxPathReport.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Каталог отчетов";
            // 
            // buttonEditPathPattern
            // 
            this.buttonEditPathPattern.Location = new System.Drawing.Point(303, 60);
            this.buttonEditPathPattern.Name = "buttonEditPathPattern";
            this.buttonEditPathPattern.Size = new System.Drawing.Size(30, 23);
            this.buttonEditPathPattern.TabIndex = 5;
            this.buttonEditPathPattern.Text = "...";
            this.buttonEditPathPattern.UseVisualStyleBackColor = true;
            this.buttonEditPathPattern.Click += new System.EventHandler(this.buttonEditPathPattern_Click);
            // 
            // buttonEditPathReport
            // 
            this.buttonEditPathReport.Location = new System.Drawing.Point(303, 19);
            this.buttonEditPathReport.Name = "buttonEditPathReport";
            this.buttonEditPathReport.Size = new System.Drawing.Size(30, 23);
            this.buttonEditPathReport.TabIndex = 2;
            this.buttonEditPathReport.Text = "...";
            this.buttonEditPathReport.UseVisualStyleBackColor = true;
            this.buttonEditPathReport.Click += new System.EventHandler(this.buttonEditPathReport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(8, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Каталог шаблонов";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(0, 349);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(272, 349);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ParamApp
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(351, 384);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControlParam);
            this.MaximizeBox = false;
            this.Name = "ParamApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.ParamApp_Load);
            this.tabControlParam.ResumeLayout(false);
            this.tabPageConnect.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPagePath.ResumeLayout(false);
            this.tabPagePath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlParam;
        private System.Windows.Forms.TabPage tabPageConnect;
        private System.Windows.Forms.TabPage tabPagePath;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Button buttonEditPathPattern;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEditPathReport;
        private System.Windows.Forms.TextBox textBoxPathReport;
        private System.Windows.Forms.TextBox textBoxPathPattern;
        private System.Windows.Forms.TextBox textBoxPathFoto;
        private System.Windows.Forms.Button buttonEditPathFoto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBoxPathFGArch;
        private System.Windows.Forms.Button buttonEditPathFGA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPathFGImport;
        private System.Windows.Forms.Button buttonEditPathFGI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPathSgmArch;
        private System.Windows.Forms.Button buttonEditPathSgmArch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPathSgm;
        private System.Windows.Forms.Button buttonEditPathSGM;
        private System.Windows.Forms.Label label11;
    }
}