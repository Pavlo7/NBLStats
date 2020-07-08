namespace NBLStats
{
    partial class GameDays
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
            this.dataGridViewGameDays = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGameDay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddGameDay = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEditGameDay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemDeleteGameDay = new System.Windows.Forms.ToolStripMenuItem();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameDays)).BeginInit();
            this.contextMenuStripGameDay.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewGameDays
            // 
            this.dataGridViewGameDays.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewGameDays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGameDays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column2,
            this.Column1,
            this.Column4,
            this.Column3,
            this.Column6});
            this.dataGridViewGameDays.ContextMenuStrip = this.contextMenuStripGameDay;
            this.dataGridViewGameDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGameDays.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGameDays.MultiSelect = false;
            this.dataGridViewGameDays.Name = "dataGridViewGameDays";
            this.dataGridViewGameDays.ReadOnly = true;
            this.dataGridViewGameDays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGameDays.Size = new System.Drawing.Size(838, 524);
            this.dataGridViewGameDays.TabIndex = 6;
            this.dataGridViewGameDays.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGameDays_MouseDoubleClick);
            // 
            // contextMenuStripGameDay
            // 
            this.contextMenuStripGameDay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddGameDay,
            this.ToolStripMenuItemEditGameDay,
            this.toolStripSeparator1,
            this.ToolStripMenuItemDeleteGameDay});
            this.contextMenuStripGameDay.Name = "contextMenuStripGame";
            this.contextMenuStripGameDay.Size = new System.Drawing.Size(237, 76);
            // 
            // ToolStripMenuItemAddGameDay
            // 
            this.ToolStripMenuItemAddGameDay.Name = "ToolStripMenuItemAddGameDay";
            this.ToolStripMenuItemAddGameDay.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ToolStripMenuItemAddGameDay.Size = new System.Drawing.Size(236, 22);
            this.ToolStripMenuItemAddGameDay.Text = "Добавить игровой день";
            this.ToolStripMenuItemAddGameDay.Click += new System.EventHandler(this.ToolStripMenuItemAddGameDay_Click);
            // 
            // ToolStripMenuItemEditGameDay
            // 
            this.ToolStripMenuItemEditGameDay.Name = "ToolStripMenuItemEditGameDay";
            this.ToolStripMenuItemEditGameDay.Size = new System.Drawing.Size(236, 22);
            this.ToolStripMenuItemEditGameDay.Text = "Редактировать игровой день";
            this.ToolStripMenuItemEditGameDay.Click += new System.EventHandler(this.ToolStripMenuItemEditGameDay_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // ToolStripMenuItemDeleteGameDay
            // 
            this.ToolStripMenuItemDeleteGameDay.Name = "ToolStripMenuItemDeleteGameDay";
            this.ToolStripMenuItemDeleteGameDay.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ToolStripMenuItemDeleteGameDay.Size = new System.Drawing.Size(236, 22);
            this.ToolStripMenuItemDeleteGameDay.Text = "Удалить игровой день";
            this.ToolStripMenuItemDeleteGameDay.Click += new System.EventHandler(this.ToolStripMenuItemDeleteGameDay_Click);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "№ ";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дата";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Место";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Кол-во игр";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Адмиристраторы";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Уборка пола";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 300;
            // 
            // GameDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 524);
            this.Controls.Add(this.dataGridViewGameDays);
            this.Name = "GameDays";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Описание игрового дня";
            this.Load += new System.EventHandler(this.GameDays_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameDays)).EndInit();
            this.contextMenuStripGameDay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGameDays;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGameDay;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddGameDay;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditGameDay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteGameDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}