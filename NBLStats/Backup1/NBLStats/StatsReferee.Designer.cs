namespace NBLStats
{
    partial class StatsReferee
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.dataGridViewStatReferee = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuSREF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddDV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditDV = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteDV = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatReferee)).BeginInit();
            this.contextMenuSREF.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 742);
            this.panel1.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(141, 73);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 8;
            this.buttonSearch.Text = "Применить";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 55);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(9, 19);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(185, 21);
            this.comboBoxDivision.TabIndex = 1;
            // 
            // dataGridViewStatReferee
            // 
            this.dataGridViewStatReferee.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStatReferee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatReferee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column4,
            this.Column11,
            this.Column5,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column10,
            this.Column9,
            this.Column1,
            this.Column12});
            this.dataGridViewStatReferee.ContextMenuStrip = this.contextMenuSREF;
            this.dataGridViewStatReferee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStatReferee.Location = new System.Drawing.Point(228, 0);
            this.dataGridViewStatReferee.MultiSelect = false;
            this.dataGridViewStatReferee.Name = "dataGridViewStatReferee";
            this.dataGridViewStatReferee.ReadOnly = true;
            this.dataGridViewStatReferee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStatReferee.Size = new System.Drawing.Size(731, 742);
            this.dataGridViewStatReferee.TabIndex = 8;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "№ игры";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 40;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ФИО";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 250;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Команда";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Фолы";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "P";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "U";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "T";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "D";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 40;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "C";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 40;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "B";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 40;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Имя файла";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 180;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "id";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // contextMenuSREF
            // 
            this.contextMenuSREF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddDV,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditDV,
            this.ToolStripMenuItemDeleteDV});
            this.contextMenuSREF.Name = "contextMenuStripPart";
            this.contextMenuSREF.Size = new System.Drawing.Size(161, 98);
            // 
            // ToolStripMenuItemAddDV
            // 
            this.ToolStripMenuItemAddDV.Name = "ToolStripMenuItemAddDV";
            this.ToolStripMenuItemAddDV.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemAddDV.Text = "Добавить";
            this.ToolStripMenuItemAddDV.Click += new System.EventHandler(this.ToolStripMenuItemAddDV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // ToolStripMenuItemEditDV
            // 
            this.ToolStripMenuItemEditDV.Name = "ToolStripMenuItemEditDV";
            this.ToolStripMenuItemEditDV.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemEditDV.Text = "Редактировать";
            this.ToolStripMenuItemEditDV.Click += new System.EventHandler(this.ToolStripMenuItemEditDV_Click);
            // 
            // ToolStripMenuItemDeleteDV
            // 
            this.ToolStripMenuItemDeleteDV.Name = "ToolStripMenuItemDeleteDV";
            this.ToolStripMenuItemDeleteDV.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemDeleteDV.Text = "Удалить";
            this.ToolStripMenuItemDeleteDV.Click += new System.EventHandler(this.ToolStripMenuItemDeleteDV_Click);
            // 
            // StatsReferee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 742);
            this.Controls.Add(this.dataGridViewStatReferee);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "StatsReferee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Статистика судей";
            this.Load += new System.EventHandler(this.StatsReferee_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatReferee)).EndInit();
            this.contextMenuSREF.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.DataGridView dataGridViewStatReferee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.ContextMenuStrip contextMenuSREF;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddDV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditDV;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteDV;
    }
}