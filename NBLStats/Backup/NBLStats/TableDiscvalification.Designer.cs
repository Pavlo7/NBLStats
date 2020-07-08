namespace NBLStats
{
    partial class TableDiscvalification
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
            this.contextMenuDV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddDV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditDV = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteDV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcelDV = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewDV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDV)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuDV
            // 
            this.contextMenuDV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddDV,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditDV,
            this.ToolStripMenuItemDeleteDV,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcelDV});
            this.contextMenuDV.Name = "contextMenuStripPart";
            this.contextMenuDV.Size = new System.Drawing.Size(165, 104);
            // 
            // ToolStripMenuItemAddDV
            // 
            this.ToolStripMenuItemAddDV.Name = "ToolStripMenuItemAddDV";
            this.ToolStripMenuItemAddDV.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemAddDV.Text = "Добавить";
            this.ToolStripMenuItemAddDV.Click += new System.EventHandler(this.ToolStripMenuItemAddDV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemEditDV
            // 
            this.ToolStripMenuItemEditDV.Name = "ToolStripMenuItemEditDV";
            this.ToolStripMenuItemEditDV.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemEditDV.Text = "Редактировать";
            this.ToolStripMenuItemEditDV.Click += new System.EventHandler(this.ToolStripMenuItemEditDV_Click);
            // 
            // ToolStripMenuItemDeleteDV
            // 
            this.ToolStripMenuItemDeleteDV.Name = "ToolStripMenuItemDeleteDV";
            this.ToolStripMenuItemDeleteDV.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemDeleteDV.Text = "Удалить";
            this.ToolStripMenuItemDeleteDV.Click += new System.EventHandler(this.ToolStripMenuItemDeleteDV_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemExportExcelDV
            // 
            this.ToolStripMenuItemExportExcelDV.Name = "ToolStripMenuItemExportExcelDV";
            this.ToolStripMenuItemExportExcelDV.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemExportExcelDV.Text = "Экспорт в Excel";
            this.ToolStripMenuItemExportExcelDV.Click += new System.EventHandler(this.ToolStripMenuItemExportExcelDV_Click);
            // 
            // dataGridViewDV
            // 
            this.dataGridViewDV.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridViewDV.ContextMenuStrip = this.contextMenuDV;
            this.dataGridViewDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDV.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDV.MultiSelect = false;
            this.dataGridViewDV.Name = "dataGridViewDV";
            this.dataGridViewDV.ReadOnly = true;
            this.dataGridViewDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDV.Size = new System.Drawing.Size(965, 466);
            this.dataGridViewDV.TabIndex = 3;
            this.dataGridViewDV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewDV_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№п\\п";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ФИО";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Команда";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Число игр";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Дата начала дисквалификации";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Дата окончания дисквалификации";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Основание";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 300;
            // 
            // TableDiscvalification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 466);
            this.Controls.Add(this.dataGridViewDV);
            this.Name = "TableDiscvalification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица дисквалификаций";
            this.Load += new System.EventHandler(this.TableDiscvalification_Load);
            this.contextMenuDV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuDV;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddDV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditDV;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteDV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcelDV;
        private System.Windows.Forms.DataGridView dataGridViewDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}