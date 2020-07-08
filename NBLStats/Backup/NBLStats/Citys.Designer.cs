namespace NBLStats
{
    partial class Citys
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
            this.contextMenuStripCity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddCity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditCity = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteCity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewCity = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCity)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripCity
            // 
            this.contextMenuStripCity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddCity,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditCity,
            this.ToolStripMenuItemDeleteCity,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcel});
            this.contextMenuStripCity.Name = "contextMenuStripPart";
            this.contextMenuStripCity.Size = new System.Drawing.Size(158, 104);
            this.contextMenuStripCity.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripCity_Opening);
            // 
            // ToolStripMenuItemAddCity
            // 
            this.ToolStripMenuItemAddCity.Name = "ToolStripMenuItemAddCity";
            this.ToolStripMenuItemAddCity.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemAddCity.Text = "Добавить";
            this.ToolStripMenuItemAddCity.Click += new System.EventHandler(this.ToolStripMenuItemAddCity_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // ToolStripMenuItemEditCity
            // 
            this.ToolStripMenuItemEditCity.Name = "ToolStripMenuItemEditCity";
            this.ToolStripMenuItemEditCity.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemEditCity.Text = "Редактировать";
            this.ToolStripMenuItemEditCity.Click += new System.EventHandler(this.ToolStripMenuItemEditCity_Click);
            // 
            // ToolStripMenuItemDeleteCity
            // 
            this.ToolStripMenuItemDeleteCity.Name = "ToolStripMenuItemDeleteCity";
            this.ToolStripMenuItemDeleteCity.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemDeleteCity.Text = "Удалить";
            this.ToolStripMenuItemDeleteCity.Click += new System.EventHandler(this.ToolStripMenuItemDeleteCity_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // ToolStripMenuItemExportExcel
            // 
            this.ToolStripMenuItemExportExcel.Name = "ToolStripMenuItemExportExcel";
            this.ToolStripMenuItemExportExcel.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemExportExcel.Text = "Экспорт в Excel";
            // 
            // dataGridViewCity
            // 
            this.dataGridViewCity.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewCity.ContextMenuStrip = this.contextMenuStripCity;
            this.dataGridViewCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCity.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCity.MultiSelect = false;
            this.dataGridViewCity.Name = "dataGridViewCity";
            this.dataGridViewCity.ReadOnly = true;
            this.dataGridViewCity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCity.Size = new System.Drawing.Size(647, 348);
            this.dataGridViewCity.TabIndex = 3;
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
            this.Column2.HeaderText = "Название города";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Регион (область)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Страна";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Citys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 348);
            this.Controls.Add(this.dataGridViewCity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Citys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник городов";
            this.Load += new System.EventHandler(this.Citys_Load);
            this.contextMenuStripCity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripCity;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddCity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditCity;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteCity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}