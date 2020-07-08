namespace NBLStats
{
    partial class Coach
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.stext = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripCoach = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddCoach = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditCoach = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteCoach = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcelCoach = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewCoach = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripCoach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoach)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.stext,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(805, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 17);
            // 
            // stext
            // 
            this.stext.Name = "stext";
            this.stext.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // contextMenuStripCoach
            // 
            this.contextMenuStripCoach.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddCoach,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditCoach,
            this.ToolStripMenuItemDeleteCoach,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcelCoach});
            this.contextMenuStripCoach.Name = "contextMenuStripPart";
            this.contextMenuStripCoach.Size = new System.Drawing.Size(165, 104);
            // 
            // ToolStripMenuItemAddCoach
            // 
            this.ToolStripMenuItemAddCoach.Name = "ToolStripMenuItemAddCoach";
            this.ToolStripMenuItemAddCoach.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemAddCoach.Text = "Добавить";
            this.ToolStripMenuItemAddCoach.Click += new System.EventHandler(this.ToolStripMenuItemAddCoach_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemEditCoach
            // 
            this.ToolStripMenuItemEditCoach.Name = "ToolStripMenuItemEditCoach";
            this.ToolStripMenuItemEditCoach.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemEditCoach.Text = "Редактировать";
            this.ToolStripMenuItemEditCoach.Click += new System.EventHandler(this.ToolStripMenuItemEditCoach_Click);
            // 
            // ToolStripMenuItemDeleteCoach
            // 
            this.ToolStripMenuItemDeleteCoach.Name = "ToolStripMenuItemDeleteCoach";
            this.ToolStripMenuItemDeleteCoach.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemDeleteCoach.Text = "Удалить";
            this.ToolStripMenuItemDeleteCoach.Click += new System.EventHandler(this.ToolStripMenuItemDeleteCoach_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemExportExcelCoach
            // 
            this.ToolStripMenuItemExportExcelCoach.Name = "ToolStripMenuItemExportExcelCoach";
            this.ToolStripMenuItemExportExcelCoach.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemExportExcelCoach.Text = "Экспорт в Excel";
            // 
            // dataGridViewCoach
            // 
            this.dataGridViewCoach.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCoach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Id,
            this.Column6});
            this.dataGridViewCoach.ContextMenuStrip = this.contextMenuStripCoach;
            this.dataGridViewCoach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCoach.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCoach.MultiSelect = false;
            this.dataGridViewCoach.Name = "dataGridViewCoach";
            this.dataGridViewCoach.ReadOnly = true;
            this.dataGridViewCoach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCoach.Size = new System.Drawing.Size(805, 524);
            this.dataGridViewCoach.TabIndex = 4;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "№п\\п";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ф.И.О.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 240;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дата рождения";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Персональный номер";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 110;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Гражданство";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Фото";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Примечание";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 250;
            // 
            // Coach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 546);
            this.Controls.Add(this.dataGridViewCoach);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Coach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник тренеров";
            this.Load += new System.EventHandler(this.Coach_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripCoach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripStatusLabel stext;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCoach;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddCoach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditCoach;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteCoach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcelCoach;
        private System.Windows.Forms.DataGridView dataGridViewCoach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}