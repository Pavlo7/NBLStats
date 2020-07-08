namespace NBLStats
{
    partial class EntryTeam
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
            this.contextMenuStripTeamPart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddTeamPart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditTeamPart = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteTeamPart = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.radioButtonOneDiv = new System.Windows.Forms.RadioButton();
            this.radioButtonAllDiv = new System.Windows.Forms.RadioButton();
            this.dataGridViewTeamPart = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripTeamPart.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeamPart)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripTeamPart
            // 
            this.contextMenuStripTeamPart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddTeamPart,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditTeamPart,
            this.ToolStripMenuItemDeleteTeamPart});
            this.contextMenuStripTeamPart.Name = "contextMenuStripPart";
            this.contextMenuStripTeamPart.Size = new System.Drawing.Size(155, 76);
            // 
            // ToolStripMenuItemAddTeamPart
            // 
            this.ToolStripMenuItemAddTeamPart.Name = "ToolStripMenuItemAddTeamPart";
            this.ToolStripMenuItemAddTeamPart.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemAddTeamPart.Text = "Добавить";
            this.ToolStripMenuItemAddTeamPart.Click += new System.EventHandler(this.ToolStripMenuItemAddTeamPart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // ToolStripMenuItemEditTeamPart
            // 
            this.ToolStripMenuItemEditTeamPart.Name = "ToolStripMenuItemEditTeamPart";
            this.ToolStripMenuItemEditTeamPart.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemEditTeamPart.Text = "Редактировать";
            this.ToolStripMenuItemEditTeamPart.Click += new System.EventHandler(this.ToolStripMenuItemEditTeamPart_Click);
            // 
            // ToolStripMenuItemDeleteTeamPart
            // 
            this.ToolStripMenuItemDeleteTeamPart.Name = "ToolStripMenuItemDeleteTeamPart";
            this.ToolStripMenuItemDeleteTeamPart.Size = new System.Drawing.Size(154, 22);
            this.ToolStripMenuItemDeleteTeamPart.Text = "Удалить";
            this.ToolStripMenuItemDeleteTeamPart.Click += new System.EventHandler(this.ToolStripMenuItemDeleteTeamPart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Controls.Add(this.radioButtonOneDiv);
            this.groupBox1.Controls.Add(this.radioButtonAllDiv);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбрать дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(87, 66);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(133, 21);
            this.comboBoxDivision.TabIndex = 3;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // radioButtonOneDiv
            // 
            this.radioButtonOneDiv.AutoSize = true;
            this.radioButtonOneDiv.Location = new System.Drawing.Point(9, 43);
            this.radioButtonOneDiv.Name = "radioButtonOneDiv";
            this.radioButtonOneDiv.Size = new System.Drawing.Size(167, 17);
            this.radioButtonOneDiv.TabIndex = 2;
            this.radioButtonOneDiv.TabStop = true;
            this.radioButtonOneDiv.Text = "Команды одного дивизиона";
            this.radioButtonOneDiv.UseVisualStyleBackColor = true;
            this.radioButtonOneDiv.CheckedChanged += new System.EventHandler(this.radioButtonOneDiv_CheckedChanged);
            // 
            // radioButtonAllDiv
            // 
            this.radioButtonAllDiv.AutoSize = true;
            this.radioButtonAllDiv.Location = new System.Drawing.Point(9, 20);
            this.radioButtonAllDiv.Name = "radioButtonAllDiv";
            this.radioButtonAllDiv.Size = new System.Drawing.Size(93, 17);
            this.radioButtonAllDiv.TabIndex = 1;
            this.radioButtonAllDiv.TabStop = true;
            this.radioButtonAllDiv.Text = "Все команды";
            this.radioButtonAllDiv.UseVisualStyleBackColor = true;
            this.radioButtonAllDiv.CheckedChanged += new System.EventHandler(this.radioButtonAllDiv_CheckedChanged);
            // 
            // dataGridViewTeamPart
            // 
            this.dataGridViewTeamPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTeamPart.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTeamPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeamPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridViewTeamPart.ContextMenuStrip = this.contextMenuStripTeamPart;
            this.dataGridViewTeamPart.Location = new System.Drawing.Point(242, 0);
            this.dataGridViewTeamPart.MultiSelect = false;
            this.dataGridViewTeamPart.Name = "dataGridViewTeamPart";
            this.dataGridViewTeamPart.ReadOnly = true;
            this.dataGridViewTeamPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTeamPart.Size = new System.Drawing.Size(668, 580);
            this.dataGridViewTeamPart.TabIndex = 2;
            this.dataGridViewTeamPart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTeamPart_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№п\\п";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Команда";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Главный тренер";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 170;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Помощник тренера";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 170;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Капитан";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 170;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Число игроков";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Дата заявки";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Дивизион";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 120;
            // 
            // TeamParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 580);
            this.Controls.Add(this.dataGridViewTeamPart);
            this.Controls.Add(this.groupBox1);
            this.Name = "TeamParticipant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заявленные команды на сезон";
            this.Load += new System.EventHandler(this.TeamParticipant_Load);
            this.contextMenuStripTeamPart.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeamPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonOneDiv;
        private System.Windows.Forms.RadioButton radioButtonAllDiv;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTeamPart;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddTeamPart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditTeamPart;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteTeamPart;
        private System.Windows.Forms.DataGridView dataGridViewTeamPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}