namespace NBLStats
{
    partial class EntryPlayer
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
            this.statusStripEntryPlayers = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.radioButtonTeam = new System.Windows.Forms.RadioButton();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.radioButtonOneDiv = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.dataGridViewEntryPlayers = new System.Windows.Forms.DataGridView();
            this.contextMenuStripEntryPlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemdelPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemTransferNews = new System.Windows.Forms.ToolStripMenuItem();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripEntryPlayers.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryPlayers)).BeginInit();
            this.contextMenuStripEntryPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripEntryPlayers
            // 
            this.statusStripEntryPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripEntryPlayers.Location = new System.Drawing.Point(0, 487);
            this.statusStripEntryPlayers.Name = "statusStripEntryPlayers";
            this.statusStripEntryPlayers.Size = new System.Drawing.Size(947, 22);
            this.statusStripEntryPlayers.TabIndex = 0;
            this.statusStripEntryPlayers.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 487);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBoxTeam);
            this.groupBox1.Controls.Add(this.radioButtonTeam);
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Controls.Add(this.radioButtonOneDiv);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 191);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбрать дивизион";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(145, 159);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 7;
            this.buttonGo.Text = "Применить";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(9, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 10);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(67, 116);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(153, 21);
            this.comboBoxTeam.TabIndex = 5;
            // 
            // radioButtonTeam
            // 
            this.radioButtonTeam.AutoSize = true;
            this.radioButtonTeam.Location = new System.Drawing.Point(9, 93);
            this.radioButtonTeam.Name = "radioButtonTeam";
            this.radioButtonTeam.Size = new System.Drawing.Size(144, 17);
            this.radioButtonTeam.TabIndex = 4;
            this.radioButtonTeam.TabStop = true;
            this.radioButtonTeam.Text = "Игроки одной команды";
            this.radioButtonTeam.UseVisualStyleBackColor = true;
            this.radioButtonTeam.CheckedChanged += new System.EventHandler(this.radioButtonTeam_CheckedChanged);
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(67, 66);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(153, 21);
            this.comboBoxDivision.TabIndex = 3;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // radioButtonOneDiv
            // 
            this.radioButtonOneDiv.AutoSize = true;
            this.radioButtonOneDiv.Location = new System.Drawing.Point(9, 43);
            this.radioButtonOneDiv.Name = "radioButtonOneDiv";
            this.radioButtonOneDiv.Size = new System.Drawing.Size(157, 17);
            this.radioButtonOneDiv.TabIndex = 2;
            this.radioButtonOneDiv.TabStop = true;
            this.radioButtonOneDiv.Text = "Игроки одного дивизиона";
            this.radioButtonOneDiv.UseVisualStyleBackColor = true;
            this.radioButtonOneDiv.CheckedChanged += new System.EventHandler(this.radioButtonOneDiv_CheckedChanged);
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
            // dataGridViewEntryPlayers
            // 
            this.dataGridViewEntryPlayers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEntryPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntryPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column12});
            this.dataGridViewEntryPlayers.ContextMenuStrip = this.contextMenuStripEntryPlayers;
            this.dataGridViewEntryPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEntryPlayers.Location = new System.Drawing.Point(254, 0);
            this.dataGridViewEntryPlayers.MultiSelect = false;
            this.dataGridViewEntryPlayers.Name = "dataGridViewEntryPlayers";
            this.dataGridViewEntryPlayers.ReadOnly = true;
            this.dataGridViewEntryPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEntryPlayers.Size = new System.Drawing.Size(693, 487);
            this.dataGridViewEntryPlayers.TabIndex = 3;
            this.dataGridViewEntryPlayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewEntryPlayers_MouseDoubleClick);
            // 
            // contextMenuStripEntryPlayers
            // 
            this.contextMenuStripEntryPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddPlayer,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditPlayer,
            this.ToolStripMenuItemdelPlayer,
            this.toolStripSeparator2,
            this.ToolStripMenuItemHistory,
            this.toolStripSeparator3,
            this.ToolStripMenuItemToExcel,
            this.toolStripSeparator4,
            this.ToolStripMenuItemTransferNews});
            this.contextMenuStripEntryPlayers.Name = "contextMenuStripEntryPlayers";
            this.contextMenuStripEntryPlayers.Size = new System.Drawing.Size(261, 160);
            // 
            // ToolStripMenuItemAddPlayer
            // 
            this.ToolStripMenuItemAddPlayer.Name = "ToolStripMenuItemAddPlayer";
            this.ToolStripMenuItemAddPlayer.Size = new System.Drawing.Size(260, 22);
            this.ToolStripMenuItemAddPlayer.Text = "Добавить заявку игрока";
            this.ToolStripMenuItemAddPlayer.Click += new System.EventHandler(this.ToolStripMenuItemAddPlayer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(257, 6);
            // 
            // ToolStripMenuItemEditPlayer
            // 
            this.ToolStripMenuItemEditPlayer.Name = "ToolStripMenuItemEditPlayer";
            this.ToolStripMenuItemEditPlayer.Size = new System.Drawing.Size(260, 22);
            this.ToolStripMenuItemEditPlayer.Text = "Редактировать заявку игрока";
            this.ToolStripMenuItemEditPlayer.Click += new System.EventHandler(this.ToolStripMenuItemEditPlayer_Click);
            // 
            // ToolStripMenuItemdelPlayer
            // 
            this.ToolStripMenuItemdelPlayer.Name = "ToolStripMenuItemdelPlayer";
            this.ToolStripMenuItemdelPlayer.Size = new System.Drawing.Size(260, 22);
            this.ToolStripMenuItemdelPlayer.Text = "Удалить заявку игрока";
            this.ToolStripMenuItemdelPlayer.Click += new System.EventHandler(this.ToolStripMenuItemdelPlayer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(257, 6);
            // 
            // ToolStripMenuItemHistory
            // 
            this.ToolStripMenuItemHistory.Name = "ToolStripMenuItemHistory";
            this.ToolStripMenuItemHistory.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.ToolStripMenuItemHistory.Size = new System.Drawing.Size(260, 22);
            this.ToolStripMenuItemHistory.Text = "История";
            this.ToolStripMenuItemHistory.Click += new System.EventHandler(this.ToolStripMenuItemHistory_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(257, 6);
            // 
            // ToolStripMenuItemToExcel
            // 
            this.ToolStripMenuItemToExcel.Name = "ToolStripMenuItemToExcel";
            this.ToolStripMenuItemToExcel.Size = new System.Drawing.Size(260, 22);
            this.ToolStripMenuItemToExcel.Text = "Список Excel";
            this.ToolStripMenuItemToExcel.Click += new System.EventHandler(this.ToolStripMenuItemToExcel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(257, 6);
            // 
            // ToolStripMenuItemTransferNews
            // 
            this.ToolStripMenuItemTransferNews.Name = "ToolStripMenuItemTransferNews";
            this.ToolStripMenuItemTransferNews.Size = new System.Drawing.Size(260, 22);
            this.ToolStripMenuItemTransferNews.Text = "Трансферные новости (для сайта)";
            this.ToolStripMenuItemTransferNews.Click += new System.EventHandler(this.ToolStripMenuItemTransferNews_Click);
            // 
            // Column10
            // 
            this.Column10.HeaderText = "№п\\п";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 40;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "А";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 20;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ф.И.О.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 240;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Команда";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 110;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Номер";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Рост";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Вес";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Дата заявки";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Дата отзаявки";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 90;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Id";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 40;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Личный номер";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 120;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Приоритет";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // EntryPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 509);
            this.Controls.Add(this.dataGridViewEntryPlayers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStripEntryPlayers);
            this.Name = "EntryPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заявки игроков";
            this.Load += new System.EventHandler(this.EntryPlayer_Load);
            this.statusStripEntryPlayers.ResumeLayout(false);
            this.statusStripEntryPlayers.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryPlayers)).EndInit();
            this.contextMenuStripEntryPlayers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripEntryPlayers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewEntryPlayers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEntryPlayers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPlayer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditPlayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemdelPlayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemToExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTeam;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.RadioButton radioButtonOneDiv;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTransferNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;

    }
}