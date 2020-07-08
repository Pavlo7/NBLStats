namespace NBLStats
{
    partial class Countrys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Countrys));
            this.contextMenuStripCountry = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewCountry = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripCountry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripCountry
            // 
            this.contextMenuStripCountry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddCountry,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditCountry,
            this.ToolStripMenuItemDeleteCountry,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcel});
            this.contextMenuStripCountry.Name = "contextMenuStripPart";
            this.contextMenuStripCountry.Size = new System.Drawing.Size(158, 104);
            this.contextMenuStripCountry.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripCountry_Opening);
            // 
            // ToolStripMenuItemAddCountry
            // 
            this.ToolStripMenuItemAddCountry.Name = "ToolStripMenuItemAddCountry";
            this.ToolStripMenuItemAddCountry.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemAddCountry.Text = "Добавить";
            this.ToolStripMenuItemAddCountry.Click += new System.EventHandler(this.ToolStripMenuItemAddCountry_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // ToolStripMenuItemEditCountry
            // 
            this.ToolStripMenuItemEditCountry.Name = "ToolStripMenuItemEditCountry";
            this.ToolStripMenuItemEditCountry.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemEditCountry.Text = "Редактировать";
            this.ToolStripMenuItemEditCountry.Click += new System.EventHandler(this.ToolStripMenuItemEditCountry_Click);
            // 
            // ToolStripMenuItemDeleteCountry
            // 
            this.ToolStripMenuItemDeleteCountry.Name = "ToolStripMenuItemDeleteCountry";
            this.ToolStripMenuItemDeleteCountry.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemDeleteCountry.Text = "Удалить";
            this.ToolStripMenuItemDeleteCountry.Click += new System.EventHandler(this.ToolStripMenuItemDeleteCountry_Click);
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
            this.ToolStripMenuItemExportExcel.Click += new System.EventHandler(this.ToolStripMenuItemExportExcel_Click);
            // 
            // dataGridViewCountry
            // 
            this.dataGridViewCountry.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCountry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewCountry.ContextMenuStrip = this.contextMenuStripCountry;
            this.dataGridViewCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCountry.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCountry.MultiSelect = false;
            this.dataGridViewCountry.Name = "dataGridViewCountry";
            this.dataGridViewCountry.ReadOnly = true;
            this.dataGridViewCountry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCountry.Size = new System.Drawing.Size(381, 230);
            this.dataGridViewCountry.TabIndex = 2;
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
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Краткое название";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Countrys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 230);
            this.Controls.Add(this.dataGridViewCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Countrys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник стран";
            this.Load += new System.EventHandler(this.Countrys_Load);
            this.contextMenuStripCountry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripCountry;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddCountry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditCountry;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteCountry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}