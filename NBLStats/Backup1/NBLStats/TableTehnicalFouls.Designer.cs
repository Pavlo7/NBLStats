namespace NBLStats
{
    partial class TableTehnicalFouls
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
            this.dataGridViewTehFouls = new System.Windows.Forms.DataGridView();
            this.contextMenuTF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddTF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditTF = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteTF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcelTF = new System.Windows.Forms.ToolStripMenuItem();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTehFouls)).BeginInit();
            this.contextMenuTF.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTehFouls
            // 
            this.dataGridViewTehFouls.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTehFouls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTehFouls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridViewTehFouls.ContextMenuStrip = this.contextMenuTF;
            this.dataGridViewTehFouls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTehFouls.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTehFouls.MultiSelect = false;
            this.dataGridViewTehFouls.Name = "dataGridViewTehFouls";
            this.dataGridViewTehFouls.ReadOnly = true;
            this.dataGridViewTehFouls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTehFouls.Size = new System.Drawing.Size(963, 563);
            this.dataGridViewTehFouls.TabIndex = 2;
            this.dataGridViewTehFouls.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTehFouls_MouseDoubleClick);
            // 
            // contextMenuTF
            // 
            this.contextMenuTF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddTF,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditTF,
            this.ToolStripMenuItemDeleteTF,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcelTF});
            this.contextMenuTF.Name = "contextMenuStripPart";
            this.contextMenuTF.Size = new System.Drawing.Size(165, 126);
            // 
            // ToolStripMenuItemAddTF
            // 
            this.ToolStripMenuItemAddTF.Name = "ToolStripMenuItemAddTF";
            this.ToolStripMenuItemAddTF.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemAddTF.Text = "Добавить";
            this.ToolStripMenuItemAddTF.Click += new System.EventHandler(this.ToolStripMenuItemAddTF_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemEditTF
            // 
            this.ToolStripMenuItemEditTF.Name = "ToolStripMenuItemEditTF";
            this.ToolStripMenuItemEditTF.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemEditTF.Text = "Редактировать";
            this.ToolStripMenuItemEditTF.Click += new System.EventHandler(this.ToolStripMenuItemEditTF_Click);
            // 
            // ToolStripMenuItemDeleteTF
            // 
            this.ToolStripMenuItemDeleteTF.Name = "ToolStripMenuItemDeleteTF";
            this.ToolStripMenuItemDeleteTF.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemDeleteTF.Text = "Удалить";
            this.ToolStripMenuItemDeleteTF.Click += new System.EventHandler(this.ToolStripMenuItemDeleteTF_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemExportExcelTF
            // 
            this.ToolStripMenuItemExportExcelTF.Name = "ToolStripMenuItemExportExcelTF";
            this.ToolStripMenuItemExportExcelTF.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemExportExcelTF.Text = "Экспорт в Excel";
            this.ToolStripMenuItemExportExcelTF.Click += new System.EventHandler(this.ToolStripMenuItemExportExcelTF_Click);
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
            this.Column4.HeaderText = "Игра";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Дата";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Описание";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 300;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Судья";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // TableTehnicalFouls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 563);
            this.Controls.Add(this.dataGridViewTehFouls);
            this.Name = "TableTehnicalFouls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица технических фолов";
            this.Load += new System.EventHandler(this.TableTehnicalFouls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTehFouls)).EndInit();
            this.contextMenuTF.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTehFouls;
        private System.Windows.Forms.ContextMenuStrip contextMenuTF;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddTF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditTF;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteTF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcelTF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}