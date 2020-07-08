namespace NBLStats
{
    partial class Awards
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
            this.contextMenuStripAward = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddAward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditAward = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteAward = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewAward = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripAward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAward)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripAward
            // 
            this.contextMenuStripAward.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddAward,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditAward,
            this.ToolStripMenuItemDeleteAward});
            this.contextMenuStripAward.Name = "contextMenuStripPart";
            this.contextMenuStripAward.Size = new System.Drawing.Size(161, 76);
            // 
            // ToolStripMenuItemAddAward
            // 
            this.ToolStripMenuItemAddAward.Name = "ToolStripMenuItemAddAward";
            this.ToolStripMenuItemAddAward.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemAddAward.Text = "Добавить";
            this.ToolStripMenuItemAddAward.Click += new System.EventHandler(this.ToolStripMenuItemAddAward_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // ToolStripMenuItemEditAward
            // 
            this.ToolStripMenuItemEditAward.Name = "ToolStripMenuItemEditAward";
            this.ToolStripMenuItemEditAward.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemEditAward.Text = "Редактировать";
            this.ToolStripMenuItemEditAward.Click += new System.EventHandler(this.ToolStripMenuItemEditAward_Click);
            // 
            // ToolStripMenuItemDeleteAward
            // 
            this.ToolStripMenuItemDeleteAward.Name = "ToolStripMenuItemDeleteAward";
            this.ToolStripMenuItemDeleteAward.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemDeleteAward.Text = "Удалить";
            this.ToolStripMenuItemDeleteAward.Click += new System.EventHandler(this.ToolStripMenuItemDeleteAward_Click);
            // 
            // dataGridViewAward
            // 
            this.dataGridViewAward.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAward.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAward.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewAward.ContextMenuStrip = this.contextMenuStripAward;
            this.dataGridViewAward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAward.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAward.MultiSelect = false;
            this.dataGridViewAward.Name = "dataGridViewAward";
            this.dataGridViewAward.ReadOnly = true;
            this.dataGridViewAward.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAward.Size = new System.Drawing.Size(553, 268);
            this.dataGridViewAward.TabIndex = 4;
            this.dataGridViewAward.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewAward_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№ номинации";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название номинации";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // Awards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 268);
            this.Controls.Add(this.dataGridViewAward);
            this.Name = "Awards";
            this.Text = "Awards";
            this.Load += new System.EventHandler(this.Awards_Load);
            this.contextMenuStripAward.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAward)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripAward;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddAward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditAward;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteAward;
        private System.Windows.Forms.DataGridView dataGridViewAward;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}