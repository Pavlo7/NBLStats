namespace NBLStats
{
    partial class VoteASG
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxSort = new System.Windows.Forms.GroupBox();
            this.radioButtonSortPlayer = new System.Windows.Forms.RadioButton();
            this.radioButtonSortIP = new System.Windows.Forms.RadioButton();
            this.radioButtonSortEmail = new System.Windows.Forms.RadioButton();
            this.radioButtonSortName = new System.Windows.Forms.RadioButton();
            this.buttonGo = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.checkBoxIP = new System.Windows.Forms.CheckBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.checkBoxEmail = new System.Windows.Forms.CheckBox();
            this.radioButtonUs = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.statusStripVoteASG = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripVoteASG = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddVote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditVote = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelVote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemResult = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewVoteASG = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxSort.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.statusStripVoteASG.SuspendLayout();
            this.contextMenuStripVoteASG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoteASG)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 579);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxSort);
            this.groupBox1.Controls.Add(this.buttonGo);
            this.groupBox1.Controls.Add(this.groupBoxData);
            this.groupBox1.Controls.Add(this.radioButtonUs);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 325);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Условия";
            // 
            // groupBoxSort
            // 
            this.groupBoxSort.Controls.Add(this.radioButtonSortPlayer);
            this.groupBoxSort.Controls.Add(this.radioButtonSortIP);
            this.groupBoxSort.Controls.Add(this.radioButtonSortEmail);
            this.groupBoxSort.Controls.Add(this.radioButtonSortName);
            this.groupBoxSort.Location = new System.Drawing.Point(9, 201);
            this.groupBoxSort.Name = "groupBoxSort";
            this.groupBoxSort.Size = new System.Drawing.Size(211, 90);
            this.groupBoxSort.TabIndex = 13;
            this.groupBoxSort.TabStop = false;
            this.groupBoxSort.Text = "Сортировка";
            // 
            // radioButtonSortPlayer
            // 
            this.radioButtonSortPlayer.AutoSize = true;
            this.radioButtonSortPlayer.Location = new System.Drawing.Point(104, 19);
            this.radioButtonSortPlayer.Name = "radioButtonSortPlayer";
            this.radioButtonSortPlayer.Size = new System.Drawing.Size(74, 17);
            this.radioButtonSortPlayer.TabIndex = 3;
            this.radioButtonSortPlayer.TabStop = true;
            this.radioButtonSortPlayer.Text = "по игроку";
            this.radioButtonSortPlayer.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortIP
            // 
            this.radioButtonSortIP.AutoSize = true;
            this.radioButtonSortIP.Location = new System.Drawing.Point(6, 65);
            this.radioButtonSortIP.Name = "radioButtonSortIP";
            this.radioButtonSortIP.Size = new System.Drawing.Size(50, 17);
            this.radioButtonSortIP.TabIndex = 2;
            this.radioButtonSortIP.TabStop = true;
            this.radioButtonSortIP.Text = "по IP";
            this.radioButtonSortIP.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortEmail
            // 
            this.radioButtonSortEmail.AutoSize = true;
            this.radioButtonSortEmail.Location = new System.Drawing.Point(6, 42);
            this.radioButtonSortEmail.Name = "radioButtonSortEmail";
            this.radioButtonSortEmail.Size = new System.Drawing.Size(68, 17);
            this.radioButtonSortEmail.TabIndex = 1;
            this.radioButtonSortEmail.TabStop = true;
            this.radioButtonSortEmail.Text = "по E-mail";
            this.radioButtonSortEmail.UseVisualStyleBackColor = true;
            // 
            // radioButtonSortName
            // 
            this.radioButtonSortName.AutoSize = true;
            this.radioButtonSortName.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSortName.Name = "radioButtonSortName";
            this.radioButtonSortName.Size = new System.Drawing.Size(72, 17);
            this.radioButtonSortName.TabIndex = 0;
            this.radioButtonSortName.TabStop = true;
            this.radioButtonSortName.Text = "по имени";
            this.radioButtonSortName.UseVisualStyleBackColor = true;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(145, 296);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 7;
            this.buttonGo.Text = "Применить";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.checkBoxAll);
            this.groupBoxData.Controls.Add(this.textBoxIP);
            this.groupBoxData.Controls.Add(this.checkBoxIP);
            this.groupBoxData.Controls.Add(this.textBoxEmail);
            this.groupBoxData.Controls.Add(this.checkBoxEmail);
            this.groupBoxData.Location = new System.Drawing.Point(9, 43);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(211, 152);
            this.groupBoxData.TabIndex = 6;
            this.groupBoxData.TabStop = false;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(159, 86);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(43, 20);
            this.textBoxIP.TabIndex = 12;
            // 
            // checkBoxIP
            // 
            this.checkBoxIP.AutoSize = true;
            this.checkBoxIP.Location = new System.Drawing.Point(6, 63);
            this.checkBoxIP.Name = "checkBoxIP";
            this.checkBoxIP.Size = new System.Drawing.Size(163, 17);
            this.checkBoxIP.TabIndex = 11;
            this.checkBoxIP.Text = "кол-во голосов с одного IP";
            this.checkBoxIP.UseVisualStyleBackColor = true;
            this.checkBoxIP.CheckedChanged += new System.EventHandler(this.checkBoxIP_CheckedChanged);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(159, 33);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(43, 20);
            this.textBoxEmail.TabIndex = 10;
            // 
            // checkBoxEmail
            // 
            this.checkBoxEmail.AutoSize = true;
            this.checkBoxEmail.Location = new System.Drawing.Point(6, 14);
            this.checkBoxEmail.Name = "checkBoxEmail";
            this.checkBoxEmail.Size = new System.Drawing.Size(183, 17);
            this.checkBoxEmail.TabIndex = 9;
            this.checkBoxEmail.Text = "кол-во голосов с одного e_mail";
            this.checkBoxEmail.UseVisualStyleBackColor = true;
            this.checkBoxEmail.CheckedChanged += new System.EventHandler(this.checkBoxEmail_CheckedChanged);
            // 
            // radioButtonUs
            // 
            this.radioButtonUs.AutoSize = true;
            this.radioButtonUs.Location = new System.Drawing.Point(126, 20);
            this.radioButtonUs.Name = "radioButtonUs";
            this.radioButtonUs.Size = new System.Drawing.Size(85, 17);
            this.radioButtonUs.TabIndex = 2;
            this.radioButtonUs.TabStop = true;
            this.radioButtonUs.Text = "По условию";
            this.radioButtonUs.UseVisualStyleBackColor = true;
            this.radioButtonUs.CheckedChanged += new System.EventHandler(this.radioButtonUs_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(9, 20);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(82, 17);
            this.radioButtonAll.TabIndex = 1;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Все игроки";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // statusStripVoteASG
            // 
            this.statusStripVoteASG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripVoteASG.Location = new System.Drawing.Point(254, 557);
            this.statusStripVoteASG.Name = "statusStripVoteASG";
            this.statusStripVoteASG.Size = new System.Drawing.Size(686, 22);
            this.statusStripVoteASG.TabIndex = 7;
            this.statusStripVoteASG.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // contextMenuStripVoteASG
            // 
            this.contextMenuStripVoteASG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddVote,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditVote,
            this.ToolStripMenuItemDelVote,
            this.toolStripSeparator2,
            this.ToolStripMenuItemResult});
            this.contextMenuStripVoteASG.Name = "contextMenuStripEntryPlayers";
            this.contextMenuStripVoteASG.Size = new System.Drawing.Size(192, 104);
            // 
            // ToolStripMenuItemAddVote
            // 
            this.ToolStripMenuItemAddVote.Name = "ToolStripMenuItemAddVote";
            this.ToolStripMenuItemAddVote.Size = new System.Drawing.Size(191, 22);
            this.ToolStripMenuItemAddVote.Text = "Добавить голос";
            this.ToolStripMenuItemAddVote.Click += new System.EventHandler(this.ToolStripMenuItemAddVote_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // ToolStripMenuItemEditVote
            // 
            this.ToolStripMenuItemEditVote.Name = "ToolStripMenuItemEditVote";
            this.ToolStripMenuItemEditVote.Size = new System.Drawing.Size(191, 22);
            this.ToolStripMenuItemEditVote.Text = "Редактировать голос";
            this.ToolStripMenuItemEditVote.Click += new System.EventHandler(this.ToolStripMenuItemEditVote_Click);
            // 
            // ToolStripMenuItemDelVote
            // 
            this.ToolStripMenuItemDelVote.Name = "ToolStripMenuItemDelVote";
            this.ToolStripMenuItemDelVote.Size = new System.Drawing.Size(191, 22);
            this.ToolStripMenuItemDelVote.Text = "Удалить голос";
            this.ToolStripMenuItemDelVote.Click += new System.EventHandler(this.ToolStripMenuItemDelVote_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // ToolStripMenuItemResult
            // 
            this.ToolStripMenuItemResult.Name = "ToolStripMenuItemResult";
            this.ToolStripMenuItemResult.Size = new System.Drawing.Size(191, 22);
            this.ToolStripMenuItemResult.Text = "Результат";
            this.ToolStripMenuItemResult.Click += new System.EventHandler(this.ToolStripMenuItemResult_Click);
            // 
            // dataGridViewVoteASG
            // 
            this.dataGridViewVoteASG.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewVoteASG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVoteASG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column5});
            this.dataGridViewVoteASG.ContextMenuStrip = this.contextMenuStripVoteASG;
            this.dataGridViewVoteASG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVoteASG.Location = new System.Drawing.Point(254, 0);
            this.dataGridViewVoteASG.MultiSelect = false;
            this.dataGridViewVoteASG.Name = "dataGridViewVoteASG";
            this.dataGridViewVoteASG.ReadOnly = true;
            this.dataGridViewVoteASG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVoteASG.Size = new System.Drawing.Size(686, 557);
            this.dataGridViewVoteASG.TabIndex = 8;
            this.dataGridViewVoteASG.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewVoteASG_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Имя";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "E_mail";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "IP";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Дата";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 140;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Состав";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 180;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(6, 117);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAll.TabIndex = 13;
            this.checkBoxAll.Text = "только полные";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // VoteASG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 579);
            this.Controls.Add(this.dataGridViewVoteASG);
            this.Controls.Add(this.statusStripVoteASG);
            this.Controls.Add(this.panel1);
            this.Name = "VoteASG";
            this.Text = "Результаты голосования на матч звёзд";
            this.Load += new System.EventHandler(this.VoteASG_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSort.ResumeLayout(false);
            this.groupBoxSort.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.statusStripVoteASG.ResumeLayout(false);
            this.statusStripVoteASG.PerformLayout();
            this.contextMenuStripVoteASG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoteASG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxSort;
        private System.Windows.Forms.RadioButton radioButtonSortPlayer;
        private System.Windows.Forms.RadioButton radioButtonSortIP;
        private System.Windows.Forms.RadioButton radioButtonSortEmail;
        private System.Windows.Forms.RadioButton radioButtonSortName;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.CheckBox checkBoxIP;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.CheckBox checkBoxEmail;
        private System.Windows.Forms.RadioButton radioButtonUs;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.StatusStrip statusStripVoteASG;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripVoteASG;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddVote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditVote;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelVote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemResult;
        private System.Windows.Forms.DataGridView dataGridViewVoteASG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.CheckBox checkBoxAll;
    }
}