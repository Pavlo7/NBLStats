namespace NBLStats
{
    partial class Games
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
            this.dataGridViewGames = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripGame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddGame = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEditGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemDeleteGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemStatsGame = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).BeginInit();
            this.contextMenuStripGame.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewGames
            // 
            this.dataGridViewGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGames.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridViewGames.ContextMenuStrip = this.contextMenuStripGame;
            this.dataGridViewGames.Location = new System.Drawing.Point(220, 0);
            this.dataGridViewGames.MultiSelect = false;
            this.dataGridViewGames.Name = "dataGridViewGames";
            this.dataGridViewGames.ReadOnly = true;
            this.dataGridViewGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGames.Size = new System.Drawing.Size(704, 577);
            this.dataGridViewGames.TabIndex = 4;
            this.dataGridViewGames.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGames_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Стадия, № тура";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "№ игры";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Игра\\результат";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Дата\\время";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Место";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Группа";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 55);
            this.groupBox1.TabIndex = 5;
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
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(137, 67);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Применить";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // Games
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 577);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewGames);
            this.Name = "Games";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Games_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGames)).EndInit();
            this.contextMenuStripGame.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGames;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGame;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddGame;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStatsGame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button buttonSearch;
    }
}