namespace NBLStats
{
    partial class Team
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
            this.contextMenuStripTeam = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonThis = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridViewTeam = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.stext = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripTeam.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeam)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripTeam
            // 
            this.contextMenuStripTeam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddTeam,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditTeam,
            this.ToolStripMenuItemDeleteTeam,
            this.toolStripSeparator2,
            this.ToolStripMenuItemExportExcel});
            this.contextMenuStripTeam.Name = "contextMenuStripPart";
            this.contextMenuStripTeam.Size = new System.Drawing.Size(165, 104);
            // 
            // ToolStripMenuItemAddTeam
            // 
            this.ToolStripMenuItemAddTeam.Image = global::NBLStats.Properties.Resources.plus;
            this.ToolStripMenuItemAddTeam.Name = "ToolStripMenuItemAddTeam";
            this.ToolStripMenuItemAddTeam.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemAddTeam.Text = "Добавить";
            this.ToolStripMenuItemAddTeam.Click += new System.EventHandler(this.ToolStripMenuItemAddTeam_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // ToolStripMenuItemEditTeam
            // 
            this.ToolStripMenuItemEditTeam.Name = "ToolStripMenuItemEditTeam";
            this.ToolStripMenuItemEditTeam.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemEditTeam.Text = "Редактировать";
            this.ToolStripMenuItemEditTeam.Click += new System.EventHandler(this.ToolStripMenuItemEditTeam_Click);
            // 
            // ToolStripMenuItemDeleteTeam
            // 
            this.ToolStripMenuItemDeleteTeam.Image = global::NBLStats.Properties.Resources.delete;
            this.ToolStripMenuItemDeleteTeam.Name = "ToolStripMenuItemDeleteTeam";
            this.ToolStripMenuItemDeleteTeam.Size = new System.Drawing.Size(164, 22);
            this.ToolStripMenuItemDeleteTeam.Text = "Удалить";
            this.ToolStripMenuItemDeleteTeam.Click += new System.EventHandler(this.ToolStripMenuItemDeleteTeam_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonThis);
            this.groupBox1.Controls.Add(this.radioButtonAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Условия выборки";
            // 
            // radioButtonThis
            // 
            this.radioButtonThis.AutoSize = true;
            this.radioButtonThis.Location = new System.Drawing.Point(9, 45);
            this.radioButtonThis.Name = "radioButtonThis";
            this.radioButtonThis.Size = new System.Drawing.Size(103, 17);
            this.radioButtonThis.TabIndex = 2;
            this.radioButtonThis.TabStop = true;
            this.radioButtonThis.Text = "Текущий сезон";
            this.radioButtonThis.UseVisualStyleBackColor = true;
            this.radioButtonThis.CheckedChanged += new System.EventHandler(this.radioButtonThis_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(9, 22);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(93, 17);
            this.radioButtonAll.TabIndex = 0;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Все команды";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(12, 486);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridViewTeam
            // 
            this.dataGridViewTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTeam.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTeam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Id,
            this.Column7});
            this.dataGridViewTeam.ContextMenuStrip = this.contextMenuStripTeam;
            this.dataGridViewTeam.Location = new System.Drawing.Point(159, 0);
            this.dataGridViewTeam.MultiSelect = false;
            this.dataGridViewTeam.Name = "dataGridViewTeam";
            this.dataGridViewTeam.ReadOnly = true;
            this.dataGridViewTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeam.Size = new System.Drawing.Size(963, 518);
            this.dataGridViewTeam.TabIndex = 7;
            this.dataGridViewTeam.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTeam_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.stext,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 521);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1021, 22);
            this.statusStrip1.TabIndex = 8;
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
            // Column5
            // 
            this.Column5.HeaderText = "№п\\п";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Название";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 160;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Название латиницей";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 140;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Город";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Регион";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 140;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Страна";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 150;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Width = 40;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "№ группы";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Team
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 543);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewTeam);
            this.Name = "Team";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочник команд НБЛ";
            this.Load += new System.EventHandler(this.Team_Load);
            this.contextMenuStripTeam.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeam)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonThis;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTeam;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddTeam;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditTeam;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteTeam;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewTeam;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripStatusLabel stext;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}