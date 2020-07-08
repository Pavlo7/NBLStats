namespace NBLStats
{
    partial class Regions
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
            this.contextMenuStripRegion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewRegion = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripRegion
            // 
            this.contextMenuStripRegion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddRegion,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditRegion,
            this.ToolStripMenuItemDeleteRegion,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcel});
            this.contextMenuStripRegion.Name = "contextMenuStripPart";
            this.contextMenuStripRegion.Size = new System.Drawing.Size(158, 104);
            this.contextMenuStripRegion.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripRegion_Opening);
            // 
            // ToolStripMenuItemAddRegion
            // 
            this.ToolStripMenuItemAddRegion.Name = "ToolStripMenuItemAddRegion";
            this.ToolStripMenuItemAddRegion.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemAddRegion.Text = "Добавить";
            this.ToolStripMenuItemAddRegion.Click += new System.EventHandler(this.ToolStripMenuItemAddRegion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // ToolStripMenuItemEditRegion
            // 
            this.ToolStripMenuItemEditRegion.Name = "ToolStripMenuItemEditRegion";
            this.ToolStripMenuItemEditRegion.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemEditRegion.Text = "Редактировать";
            this.ToolStripMenuItemEditRegion.Click += new System.EventHandler(this.ToolStripMenuItemEditRegion_Click);
            // 
            // ToolStripMenuItemDeleteRegion
            // 
            this.ToolStripMenuItemDeleteRegion.Name = "ToolStripMenuItemDeleteRegion";
            this.ToolStripMenuItemDeleteRegion.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItemDeleteRegion.Text = "Удалить";
            this.ToolStripMenuItemDeleteRegion.Click += new System.EventHandler(this.ToolStripMenuItemDeleteRegion_Click);
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
            // dataGridViewRegion
            // 
            this.dataGridViewRegion.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRegion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewRegion.ContextMenuStrip = this.contextMenuStripRegion;
            this.dataGridViewRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRegion.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRegion.MultiSelect = false;
            this.dataGridViewRegion.Name = "dataGridViewRegion";
            this.dataGridViewRegion.ReadOnly = true;
            this.dataGridViewRegion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRegion.Size = new System.Drawing.Size(549, 276);
            this.dataGridViewRegion.TabIndex = 3;
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
            this.Column2.HeaderText = "Название региона (области)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Краткое название";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Страна";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Regions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 276);
            this.Controls.Add(this.dataGridViewRegion);
            this.Name = "Regions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник регионов (областей)";
            this.Load += new System.EventHandler(this.Regions_Load);
            this.contextMenuStripRegion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripRegion;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddRegion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditRegion;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteRegion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}