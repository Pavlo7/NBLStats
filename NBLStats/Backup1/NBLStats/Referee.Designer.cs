namespace NBLStats
{
    partial class Referee
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
            this.contextMenuStripPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddPart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditPart = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeletePart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewReferee = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferee)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.stext,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(880, 22);
            this.statusStrip1.TabIndex = 5;
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
            // contextMenuStripPlayer
            // 
            this.contextMenuStripPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddPart,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditPart,
            this.ToolStripMenuItemDeletePart,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcel});
            this.contextMenuStripPlayer.Name = "contextMenuStripPart";
            this.contextMenuStripPlayer.Size = new System.Drawing.Size(165, 104);
            // 
            // ToolStripMenuItemAddPart
            // 
            this.ToolStripMenuItemAddPart.Name = "ToolStripMenuItemAddPart";
            this.ToolStripMenuItemAddPart.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemAddPart.Text = "Добавить";
            this.ToolStripMenuItemAddPart.Click += new System.EventHandler(this.ToolStripMenuItemAddPart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemEditPart
            // 
            this.ToolStripMenuItemEditPart.Name = "ToolStripMenuItemEditPart";
            this.ToolStripMenuItemEditPart.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemEditPart.Text = "Редактировать";
            this.ToolStripMenuItemEditPart.Click += new System.EventHandler(this.ToolStripMenuItemEditPart_Click);
            // 
            // ToolStripMenuItemDeletePart
            // 
            this.ToolStripMenuItemDeletePart.Name = "ToolStripMenuItemDeletePart";
            this.ToolStripMenuItemDeletePart.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemDeletePart.Text = "Удалить";
            this.ToolStripMenuItemDeletePart.Click += new System.EventHandler(this.ToolStripMenuItemDeletePart_Click);
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
            this.ToolStripMenuItemExportExcel.Click += new System.EventHandler(this.ToolStripMenuItemExportExcel_Click);
            // 
            // dataGridViewReferee
            // 
            this.dataGridViewReferee.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReferee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReferee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Id,
            this.Column6,
            this.Column9});
            this.dataGridViewReferee.ContextMenuStrip = this.contextMenuStripPlayer;
            this.dataGridViewReferee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReferee.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReferee.MultiSelect = false;
            this.dataGridViewReferee.Name = "dataGridViewReferee";
            this.dataGridViewReferee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReferee.Size = new System.Drawing.Size(880, 518);
            this.dataGridViewReferee.TabIndex = 6;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "№п\\п";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ф.И.О.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 240;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Категория";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
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
            // Column9
            // 
            this.Column9.HeaderText = "Флаг видимости";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // Referee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 540);
            this.Controls.Add(this.dataGridViewReferee);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Referee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Referee";
            this.Load += new System.EventHandler(this.Referee_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripPlayer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripStatusLabel stext;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPlayer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditPart;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeletePart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewReferee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}