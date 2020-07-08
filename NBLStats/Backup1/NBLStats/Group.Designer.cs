namespace NBLStats
{
    partial class Group
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
            this.contextMenuStripGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemComGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripGroup
            // 
            this.contextMenuStripGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddGroup,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditGroup,
            this.ToolStripMenuItemDelGroup,
            this.toolStripSeparator2,
            this.ToolStripMenuItemComGroup});
            this.contextMenuStripGroup.Name = "contextMenuStripGroup";
            this.contextMenuStripGroup.Size = new System.Drawing.Size(196, 104);
            // 
            // ToolStripMenuItemAddGroup
            // 
            this.ToolStripMenuItemAddGroup.Name = "ToolStripMenuItemAddGroup";
            this.ToolStripMenuItemAddGroup.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItemAddGroup.Text = "Добавить группу";
            this.ToolStripMenuItemAddGroup.Click += new System.EventHandler(this.ToolStripMenuItemAddGroup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // ToolStripMenuItemEditGroup
            // 
            this.ToolStripMenuItemEditGroup.Name = "ToolStripMenuItemEditGroup";
            this.ToolStripMenuItemEditGroup.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItemEditGroup.Text = "Редактировать группу";
            this.ToolStripMenuItemEditGroup.Click += new System.EventHandler(this.ToolStripMenuItemEditGroup_Click);
            // 
            // ToolStripMenuItemDelGroup
            // 
            this.ToolStripMenuItemDelGroup.Name = "ToolStripMenuItemDelGroup";
            this.ToolStripMenuItemDelGroup.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItemDelGroup.Text = "Удалить группу";
            this.ToolStripMenuItemDelGroup.Click += new System.EventHandler(this.ToolStripMenuItemDelGroup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // ToolStripMenuItemComGroup
            // 
            this.ToolStripMenuItemComGroup.Name = "ToolStripMenuItemComGroup";
            this.ToolStripMenuItemComGroup.Size = new System.Drawing.Size(195, 22);
            this.ToolStripMenuItemComGroup.Text = "Состав группы";
            this.ToolStripMenuItemComGroup.Click += new System.EventHandler(this.ToolStripMenuItemComGroup_Click);
            // 
            // dataGridViewGroups
            // 
            this.dataGridViewGroups.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Id,
            this.Column6,
            this.Column7});
            this.dataGridViewGroups.ContextMenuStrip = this.contextMenuStripGroup;
            this.dataGridViewGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGroups.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGroups.MultiSelect = false;
            this.dataGridViewGroups.Name = "dataGridViewGroups";
            this.dataGridViewGroups.ReadOnly = true;
            this.dataGridViewGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroups.Size = new System.Drawing.Size(833, 290);
            this.dataGridViewGroups.TabIndex = 9;
            this.dataGridViewGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGroups_MouseDoubleClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "№ п\\п";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Название группы";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Дивизион";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Стадия";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Число команд";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Id
            // 
            this.Id.HeaderText = "Число команд в след. стадию";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Заполнение группы";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Id";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 40;
            // 
            // Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 290);
            this.Controls.Add(this.dataGridViewGroups);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Группы";
            this.Load += new System.EventHandler(this.Group_Load);
            this.contextMenuStripGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroup;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditGroup;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemComGroup;
        private System.Windows.Forms.DataGridView dataGridViewGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}