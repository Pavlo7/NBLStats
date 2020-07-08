namespace NBLStats
{
    partial class Place
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
            this.contextMenuStripPlace = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeletePlace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewPlace = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlace)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripPlace
            // 
            this.contextMenuStripPlace.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddPlace,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditPlace,
            this.ToolStripMenuItemDeletePlace,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcel});
            this.contextMenuStripPlace.Name = "contextMenuStripPart";
            this.contextMenuStripPlace.Size = new System.Drawing.Size(165, 104);
            this.contextMenuStripPlace.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripPlace_Opening);
            // 
            // ToolStripMenuItemAddPlace
            // 
            this.ToolStripMenuItemAddPlace.Name = "ToolStripMenuItemAddPlace";
            this.ToolStripMenuItemAddPlace.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemAddPlace.Text = "Добавить";
            this.ToolStripMenuItemAddPlace.Click += new System.EventHandler(this.ToolStripMenuItemAddPlace_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemEditPlace
            // 
            this.ToolStripMenuItemEditPlace.Name = "ToolStripMenuItemEditPlace";
            this.ToolStripMenuItemEditPlace.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemEditPlace.Text = "Редактировать";
            this.ToolStripMenuItemEditPlace.Click += new System.EventHandler(this.ToolStripMenuItemEditPlace_Click);
            // 
            // ToolStripMenuItemDeletePlace
            // 
            this.ToolStripMenuItemDeletePlace.Name = "ToolStripMenuItemDeletePlace";
            this.ToolStripMenuItemDeletePlace.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemDeletePlace.Text = "Удалить";
            this.ToolStripMenuItemDeletePlace.Click += new System.EventHandler(this.ToolStripMenuItemDeletePlace_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemExportExcel
            // 
            this.ToolStripMenuItemExportExcel.Name = "ToolStripMenuItemExportExcel";
            this.ToolStripMenuItemExportExcel.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemExportExcel.Text = "Экспорт в Excel";
            // 
            // dataGridViewPlace
            // 
            this.dataGridViewPlace.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPlace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewPlace.ContextMenuStrip = this.contextMenuStripPlace;
            this.dataGridViewPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPlace.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPlace.MultiSelect = false;
            this.dataGridViewPlace.Name = "dataGridViewPlace";
            this.dataGridViewPlace.ReadOnly = true;
            this.dataGridViewPlace.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPlace.Size = new System.Drawing.Size(574, 304);
            this.dataGridViewPlace.TabIndex = 1;
            this.dataGridViewPlace.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewPlace_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№п\\п";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Город";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Адрес";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Флаг видимости";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Place
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 304);
            this.Controls.Add(this.dataGridViewPlace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Place";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник игровых площадок";
            this.Load += new System.EventHandler(this.Place_Load);
            this.contextMenuStripPlace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripPlace;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPlace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditPlace;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeletePlace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}