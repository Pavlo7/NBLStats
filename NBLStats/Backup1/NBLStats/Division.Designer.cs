namespace NBLStats
{
    partial class Division
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
            this.contextMenuStripDivision = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddDiv = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditDiv = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteDiv = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewDivision = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripDivision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDivision)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripDivision
            // 
            this.contextMenuStripDivision.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddDiv,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditDiv,
            this.ToolStripMenuItemDeleteDiv});
            this.contextMenuStripDivision.Name = "contextMenuStripPart";
            this.contextMenuStripDivision.Size = new System.Drawing.Size(210, 76);
            // 
            // ToolStripMenuItemAddDiv
            // 
            this.ToolStripMenuItemAddDiv.Name = "ToolStripMenuItemAddDiv";
            this.ToolStripMenuItemAddDiv.Size = new System.Drawing.Size(209, 22);
            this.ToolStripMenuItemAddDiv.Text = "Добавить дивизион";
            this.ToolStripMenuItemAddDiv.Click += new System.EventHandler(this.ToolStripMenuItemAddDiv_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // ToolStripMenuItemEditDiv
            // 
            this.ToolStripMenuItemEditDiv.Name = "ToolStripMenuItemEditDiv";
            this.ToolStripMenuItemEditDiv.Size = new System.Drawing.Size(209, 22);
            this.ToolStripMenuItemEditDiv.Text = "Редактировать дивизион";
            this.ToolStripMenuItemEditDiv.Click += new System.EventHandler(this.ToolStripMenuItemEditDiv_Click);
            // 
            // ToolStripMenuItemDeleteDiv
            // 
            this.ToolStripMenuItemDeleteDiv.Name = "ToolStripMenuItemDeleteDiv";
            this.ToolStripMenuItemDeleteDiv.Size = new System.Drawing.Size(209, 22);
            this.ToolStripMenuItemDeleteDiv.Text = "Удалить дивизион";
            this.ToolStripMenuItemDeleteDiv.Click += new System.EventHandler(this.ToolStripMenuItemDeleteDiv_Click);
            // 
            // dataGridViewDivision
            // 
            this.dataGridViewDivision.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDivision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDivision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Id});
            this.dataGridViewDivision.ContextMenuStrip = this.contextMenuStripDivision;
            this.dataGridViewDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDivision.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDivision.MultiSelect = false;
            this.dataGridViewDivision.Name = "dataGridViewDivision";
            this.dataGridViewDivision.ReadOnly = true;
            this.dataGridViewDivision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDivision.Size = new System.Drawing.Size(871, 355);
            this.dataGridViewDivision.TabIndex = 5;
            this.dataGridViewDivision.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewDivision_MouseDoubleClick);
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
            this.Column1.HeaderText = "Название";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 180;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Число команд";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Регулярный сезон";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Плей-офф";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Игры ротации";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Деадлайн";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // Division
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 355);
            this.Controls.Add(this.dataGridViewDivision);
            this.Name = "Division";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дивизионы";
            this.Load += new System.EventHandler(this.Division_Load);
            this.contextMenuStripDivision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDivision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripDivision;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddDiv;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditDiv;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteDiv;
        private System.Windows.Forms.DataGridView dataGridViewDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}