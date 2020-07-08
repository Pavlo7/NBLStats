namespace NBLStats
{
    partial class Postment
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
            this.dataGridViewPostment = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripPost = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddPost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemEditPost = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeletePost = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPostment)).BeginInit();
            this.contextMenuStripPost.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPostment
            // 
            this.dataGridViewPostment.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPostment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPostment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewPostment.ContextMenuStrip = this.contextMenuStripPost;
            this.dataGridViewPostment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPostment.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPostment.MultiSelect = false;
            this.dataGridViewPostment.Name = "dataGridViewPostment";
            this.dataGridViewPostment.ReadOnly = true;
            this.dataGridViewPostment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPostment.Size = new System.Drawing.Size(543, 268);
            this.dataGridViewPostment.TabIndex = 5;
            this.dataGridViewPostment.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewPostment_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Наименование должности";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Описание";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 300;
            // 
            // contextMenuStripPost
            // 
            this.contextMenuStripPost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddPost,
            this.toolStripSeparator1,
            this.ToolStripMenuItemEditPost,
            this.ToolStripMenuItemDeletePost});
            this.contextMenuStripPost.Name = "contextMenuStripPart";
            this.contextMenuStripPost.Size = new System.Drawing.Size(161, 76);
            // 
            // ToolStripMenuItemAddPost
            // 
            this.ToolStripMenuItemAddPost.Name = "ToolStripMenuItemAddPost";
            this.ToolStripMenuItemAddPost.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemAddPost.Text = "Добавить";
            this.ToolStripMenuItemAddPost.Click += new System.EventHandler(this.ToolStripMenuItemAddPost_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // ToolStripMenuItemEditPost
            // 
            this.ToolStripMenuItemEditPost.Name = "ToolStripMenuItemEditPost";
            this.ToolStripMenuItemEditPost.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemEditPost.Text = "Редактировать";
            this.ToolStripMenuItemEditPost.Click += new System.EventHandler(this.ToolStripMenuItemEditPost_Click);
            // 
            // ToolStripMenuItemDeletePost
            // 
            this.ToolStripMenuItemDeletePost.Name = "ToolStripMenuItemDeletePost";
            this.ToolStripMenuItemDeletePost.Size = new System.Drawing.Size(160, 22);
            this.ToolStripMenuItemDeletePost.Text = "Удалить";
            this.ToolStripMenuItemDeletePost.Click += new System.EventHandler(this.ToolStripMenuItemDeletePost_Click);
            // 
            // Postment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 268);
            this.Controls.Add(this.dataGridViewPostment);
            this.Name = "Postment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Справочник должностей";
            this.Load += new System.EventHandler(this.Postment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPostment)).EndInit();
            this.contextMenuStripPost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPostment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPost;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditPost;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeletePost;
    }
}