namespace NBLStats
{
    partial class FileInfoSgm
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
            this.dataGridViewFileInfo = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripFileInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemDeleteFileInfo = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileInfo)).BeginInit();
            this.contextMenuStripFileInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFileInfo
            // 
            this.dataGridViewFileInfo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFileInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFileInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column2});
            this.dataGridViewFileInfo.ContextMenuStrip = this.contextMenuStripFileInfo;
            this.dataGridViewFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFileInfo.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFileInfo.MultiSelect = false;
            this.dataGridViewFileInfo.Name = "dataGridViewFileInfo";
            this.dataGridViewFileInfo.ReadOnly = true;
            this.dataGridViewFileInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFileInfo.Size = new System.Drawing.Size(856, 444);
            this.dataGridViewFileInfo.TabIndex = 6;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Имя файла";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дата записи";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // contextMenuStripFileInfo
            // 
            this.contextMenuStripFileInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDeleteFileInfo});
            this.contextMenuStripFileInfo.Name = "contextMenuStripGame";
            this.contextMenuStripFileInfo.Size = new System.Drawing.Size(181, 48);
            // 
            // ToolStripMenuItemDeleteFileInfo
            // 
            this.ToolStripMenuItemDeleteFileInfo.Name = "ToolStripMenuItemDeleteFileInfo";
            this.ToolStripMenuItemDeleteFileInfo.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ToolStripMenuItemDeleteFileInfo.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemDeleteFileInfo.Text = "Удалить файл";
            this.ToolStripMenuItemDeleteFileInfo.Click += new System.EventHandler(this.ToolStripMenuItemDeleteFileInfo_Click);
            // 
            // FileInfoSgm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 444);
            this.Controls.Add(this.dataGridViewFileInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FileInfoSgm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Записанные в БД файлы";
            this.Load += new System.EventHandler(this.FileInfoSgm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileInfo)).EndInit();
            this.contextMenuStripFileInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFileInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteFileInfo;
    }
}