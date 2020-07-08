namespace NBLStats
{
    partial class CalendarGames
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
            this.dataGridViewCalendarGames = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddGame = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEditGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemDeleteGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemStatsGame = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendarGames)).BeginInit();
            this.contextMenuStripGame.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 582);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewCalendarGames
            // 
            this.dataGridViewCalendarGames.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCalendarGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalendarGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column2,
            this.Column4,
            this.Column3,
            this.Column6,
            this.Column1,
            this.Column5});
            this.dataGridViewCalendarGames.ContextMenuStrip = this.contextMenuStripGame;
            this.dataGridViewCalendarGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCalendarGames.Location = new System.Drawing.Point(228, 0);
            this.dataGridViewCalendarGames.MultiSelect = false;
            this.dataGridViewCalendarGames.Name = "dataGridViewCalendarGames";
            this.dataGridViewCalendarGames.ReadOnly = true;
            this.dataGridViewCalendarGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCalendarGames.Size = new System.Drawing.Size(705, 582);
            this.dataGridViewCalendarGames.TabIndex = 5;
            this.dataGridViewCalendarGames.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewCalendarGames_MouseDoubleClick);
            // 
            // contextMenuStripGame
            // 
            this.contextMenuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddGame,
            this.ToolStripMenuItemEditGame,
            this.toolStripSeparator1,
            this.ToolStripMenuItemDeleteGame,
            this.toolStripSeparator2,
            this.ToolStripMenuItemStatsGame});
            this.contextMenuStripGame.Name = "contextMenuStripGame";
            this.contextMenuStripGame.Size = new System.Drawing.Size(186, 104);
            // 
            // ToolStripMenuItemAddGame
            // 
            this.ToolStripMenuItemAddGame.Name = "ToolStripMenuItemAddGame";
            this.ToolStripMenuItemAddGame.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ToolStripMenuItemAddGame.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItemAddGame.Text = "Добавить игру";
            this.ToolStripMenuItemAddGame.Click += new System.EventHandler(this.ToolStripMenuItemAddGame_Click);
            // 
            // ToolStripMenuItemEditGame
            // 
            this.ToolStripMenuItemEditGame.Name = "ToolStripMenuItemEditGame";
            this.ToolStripMenuItemEditGame.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItemEditGame.Text = "Редактировать игру";
            this.ToolStripMenuItemEditGame.Click += new System.EventHandler(this.ToolStripMenuItemEditGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // ToolStripMenuItemDeleteGame
            // 
            this.ToolStripMenuItemDeleteGame.Name = "ToolStripMenuItemDeleteGame";
            this.ToolStripMenuItemDeleteGame.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ToolStripMenuItemDeleteGame.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItemDeleteGame.Text = "Удалить игру";
            this.ToolStripMenuItemDeleteGame.Click += new System.EventHandler(this.ToolStripMenuItemDeleteGame_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // ToolStripMenuItemStatsGame
            // 
            this.ToolStripMenuItemStatsGame.Name = "ToolStripMenuItemStatsGame";
            this.ToolStripMenuItemStatsGame.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.ToolStripMenuItemStatsGame.Size = new System.Drawing.Size(185, 22);
            this.ToolStripMenuItemStatsGame.Text = "Статистика";
            this.ToolStripMenuItemStatsGame.Click += new System.EventHandler(this.ToolStripMenuItemStatsGame_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(141, 73);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 8;
            this.buttonSearch.Text = "Применить";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 55);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(9, 19);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(185, 21);
            this.comboBoxDivision.TabIndex = 1;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Дата";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "№ игры";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 55;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Время";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Игра\\результат";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Группа";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Стадия, № тура";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Место";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // CalendarGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 582);
            this.Controls.Add(this.dataGridViewCalendarGames);
            this.Controls.Add(this.panel1);
            this.Name = "CalendarGames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Календарь игр";
            this.Load += new System.EventHandler(this.CalendarGames_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendarGames)).EndInit();
            this.contextMenuStripGame.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCalendarGames;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGame;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddGame;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStatsGame;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}