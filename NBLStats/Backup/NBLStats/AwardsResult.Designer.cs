namespace NBLStats
{
    partial class AwardsResult
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
            this.dataGridViewAwardResult = new System.Windows.Forms.DataGridView();
            this.contextMenuStripAwardResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.oolStripMenuItemAddAward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditAward = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelAward = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAwardResult)).BeginInit();
            this.contextMenuStripAwardResult.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAwardResult
            // 
            this.dataGridViewAwardResult.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAwardResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAwardResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dataGridViewAwardResult.ContextMenuStrip = this.contextMenuStripAwardResult;
            this.dataGridViewAwardResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAwardResult.Location = new System.Drawing.Point(221, 0);
            this.dataGridViewAwardResult.MultiSelect = false;
            this.dataGridViewAwardResult.Name = "dataGridViewAwardResult";
            this.dataGridViewAwardResult.ReadOnly = true;
            this.dataGridViewAwardResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAwardResult.Size = new System.Drawing.Size(773, 707);
            this.dataGridViewAwardResult.TabIndex = 7;
            this.dataGridViewAwardResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewAwardResult_MouseDoubleClick);
            // 
            // contextMenuStripAwardResult
            // 
            this.contextMenuStripAwardResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oolStripMenuItemAddAward,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditAward,
            this.ToolStripMenuItemDelAward});
            this.contextMenuStripAwardResult.Name = "contextMenuStripAwardResult";
            this.contextMenuStripAwardResult.Size = new System.Drawing.Size(204, 76);
            // 
            // oolStripMenuItemAddAward
            // 
            this.oolStripMenuItemAddAward.Name = "oolStripMenuItemAddAward";
            this.oolStripMenuItemAddAward.Size = new System.Drawing.Size(203, 22);
            this.oolStripMenuItemAddAward.Text = "Добавить награду";
            this.oolStripMenuItemAddAward.Click += new System.EventHandler(this.oolStripMenuItemAddAward_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // ToolStripMenuItemEditAward
            // 
            this.ToolStripMenuItemEditAward.Name = "ToolStripMenuItemEditAward";
            this.ToolStripMenuItemEditAward.Size = new System.Drawing.Size(203, 22);
            this.ToolStripMenuItemEditAward.Text = "Редактировать награду";
            this.ToolStripMenuItemEditAward.Click += new System.EventHandler(this.ToolStripMenuItemEditAward_Click);
            // 
            // ToolStripMenuItemDelAward
            // 
            this.ToolStripMenuItemDelAward.Name = "ToolStripMenuItemDelAward";
            this.ToolStripMenuItemDelAward.Size = new System.Drawing.Size(203, 22);
            this.ToolStripMenuItemDelAward.Text = "Удалить награду";
            this.ToolStripMenuItemDelAward.Click += new System.EventHandler(this.ToolStripMenuItemDelAward_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 707);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(10, 20);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(170, 21);
            this.comboBoxDivision.TabIndex = 0;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Награда";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 270;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ф.И.О.";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 170;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Команда";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Результат";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Id игрока";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 60;
            // 
            // AwardsResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 707);
            this.Controls.Add(this.dataGridViewAwardResult);
            this.Controls.Add(this.panel1);
            this.Name = "AwardsResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Персональные награды";
            this.Load += new System.EventHandler(this.AwardsResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAwardResult)).EndInit();
            this.contextMenuStripAwardResult.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAwardResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAwardResult;
        private System.Windows.Forms.ToolStripMenuItem oolStripMenuItemAddAward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditAward;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelAward;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}