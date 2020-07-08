namespace NBLStats
{
    partial class ChangeSeason
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
            this.dataGridViewSeason = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripSeason = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemNewSeason = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditSeason = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteSeason = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEndSeason = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeason)).BeginInit();
            this.contextMenuStripSeason.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSeason
            // 
            this.dataGridViewSeason.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewSeason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeason.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Id,
            this.Column6});
            this.dataGridViewSeason.ContextMenuStrip = this.contextMenuStripSeason;
            this.dataGridViewSeason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeason.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSeason.MultiSelect = false;
            this.dataGridViewSeason.Name = "dataGridViewSeason";
            this.dataGridViewSeason.ReadOnly = true;
            this.dataGridViewSeason.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSeason.Size = new System.Drawing.Size(857, 514);
            this.dataGridViewSeason.TabIndex = 8;
            this.dataGridViewSeason.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSeason_MouseDoubleClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "№ сезона";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Название сезона";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дата начала сезона";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Дата окончания сезона";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Число дивизионов";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Id
            // 
            this.Id.HeaderText = "Число команд";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Состояние";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // contextMenuStripSeason
            // 
            this.contextMenuStripSeason.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNewSeason,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditSeason,
            this.ToolStripMenuItemDeleteSeason,
            this.toolStripSeparator2,
            this.ToolStripMenuItemEndSeason});
            this.contextMenuStripSeason.Name = "contextMenuStripSeason";
            this.contextMenuStripSeason.Size = new System.Drawing.Size(260, 104);
            // 
            // ToolStripMenuItemNewSeason
            // 
            this.ToolStripMenuItemNewSeason.Name = "ToolStripMenuItemNewSeason";
            this.ToolStripMenuItemNewSeason.Size = new System.Drawing.Size(259, 22);
            this.ToolStripMenuItemNewSeason.Text = "Создать новый сезон";
            this.ToolStripMenuItemNewSeason.Click += new System.EventHandler(this.ToolStripMenuItemNewSeason_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // ToolStripMenuItemEditSeason
            // 
            this.ToolStripMenuItemEditSeason.Name = "ToolStripMenuItemEditSeason";
            this.ToolStripMenuItemEditSeason.Size = new System.Drawing.Size(259, 22);
            this.ToolStripMenuItemEditSeason.Text = "Редактировать параметры сезона";
            this.ToolStripMenuItemEditSeason.Click += new System.EventHandler(this.ToolStripMenuItemEditSeason_Click);
            // 
            // ToolStripMenuItemDeleteSeason
            // 
            this.ToolStripMenuItemDeleteSeason.Name = "ToolStripMenuItemDeleteSeason";
            this.ToolStripMenuItemDeleteSeason.Size = new System.Drawing.Size(259, 22);
            this.ToolStripMenuItemDeleteSeason.Text = "Удалить сезон";
            this.ToolStripMenuItemDeleteSeason.Click += new System.EventHandler(this.ToolStripMenuItemDeleteSeason_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(256, 6);
            // 
            // ToolStripMenuItemEndSeason
            // 
            this.ToolStripMenuItemEndSeason.Name = "ToolStripMenuItemEndSeason";
            this.ToolStripMenuItemEndSeason.Size = new System.Drawing.Size(259, 22);
            this.ToolStripMenuItemEndSeason.Text = "Завершить сезон";
            // 
            // ChangeSeason
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 514);
            this.Controls.Add(this.dataGridViewSeason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSeason";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация о сезонах";
            this.Load += new System.EventHandler(this.ChangeSeason_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeason)).EndInit();
            this.contextMenuStripSeason.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSeason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSeason;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNewSeason;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditSeason;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEndSeason;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteSeason;

    }
}