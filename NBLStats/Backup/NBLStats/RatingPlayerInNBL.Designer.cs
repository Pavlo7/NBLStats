namespace NBLStats
{
    partial class RatingPlayerInNBL
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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonFouls = new System.Windows.Forms.RadioButton();
            this.radioButtonBlocks = new System.Windows.Forms.RadioButton();
            this.radioButtonSteals = new System.Windows.Forms.RadioButton();
            this.radioButtonAssists = new System.Windows.Forms.RadioButton();
            this.radioButtonRebounds = new System.Windows.Forms.RadioButton();
            this.radioButtonPoints = new System.Windows.Forms.RadioButton();
            this.radioButtonCntGames = new System.Windows.Forms.RadioButton();
            this.dataGridViewRatingNBL = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRatingNBL)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.groupBox1);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(239, 503);
            this.panelSearch.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonFouls);
            this.groupBox1.Controls.Add(this.radioButtonBlocks);
            this.groupBox1.Controls.Add(this.radioButtonSteals);
            this.groupBox1.Controls.Add(this.radioButtonAssists);
            this.groupBox1.Controls.Add(this.radioButtonRebounds);
            this.groupBox1.Controls.Add(this.radioButtonPoints);
            this.groupBox1.Controls.Add(this.radioButtonCntGames);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Условия выбора";
            // 
            // radioButtonFouls
            // 
            this.radioButtonFouls.AutoSize = true;
            this.radioButtonFouls.Location = new System.Drawing.Point(9, 158);
            this.radioButtonFouls.Name = "radioButtonFouls";
            this.radioButtonFouls.Size = new System.Drawing.Size(74, 17);
            this.radioButtonFouls.TabIndex = 7;
            this.radioButtonFouls.TabStop = true;
            this.radioButtonFouls.Text = "по фолам";
            this.radioButtonFouls.UseVisualStyleBackColor = true;
            this.radioButtonFouls.CheckedChanged += new System.EventHandler(this.radioButtonFouls_CheckedChanged);
            // 
            // radioButtonBlocks
            // 
            this.radioButtonBlocks.AutoSize = true;
            this.radioButtonBlocks.Location = new System.Drawing.Point(9, 135);
            this.radioButtonBlocks.Name = "radioButtonBlocks";
            this.radioButtonBlocks.Size = new System.Drawing.Size(100, 17);
            this.radioButtonBlocks.TabIndex = 5;
            this.radioButtonBlocks.TabStop = true;
            this.radioButtonBlocks.Text = "по блок-шотам";
            this.radioButtonBlocks.UseVisualStyleBackColor = true;
            this.radioButtonBlocks.CheckedChanged += new System.EventHandler(this.radioButtonBlocks_CheckedChanged);
            // 
            // radioButtonSteals
            // 
            this.radioButtonSteals.AutoSize = true;
            this.radioButtonSteals.Location = new System.Drawing.Point(9, 112);
            this.radioButtonSteals.Name = "radioButtonSteals";
            this.radioButtonSteals.Size = new System.Drawing.Size(100, 17);
            this.radioButtonSteals.TabIndex = 4;
            this.radioButtonSteals.TabStop = true;
            this.radioButtonSteals.Text = "по перехватам";
            this.radioButtonSteals.UseVisualStyleBackColor = true;
            this.radioButtonSteals.CheckedChanged += new System.EventHandler(this.radioButtonSteals_CheckedChanged);
            // 
            // radioButtonAssists
            // 
            this.radioButtonAssists.AutoSize = true;
            this.radioButtonAssists.Location = new System.Drawing.Point(9, 89);
            this.radioButtonAssists.Name = "radioButtonAssists";
            this.radioButtonAssists.Size = new System.Drawing.Size(95, 17);
            this.radioButtonAssists.TabIndex = 3;
            this.radioButtonAssists.TabStop = true;
            this.radioButtonAssists.Text = "по передачам";
            this.radioButtonAssists.UseVisualStyleBackColor = true;
            this.radioButtonAssists.CheckedChanged += new System.EventHandler(this.radioButtonAssists_CheckedChanged);
            // 
            // radioButtonRebounds
            // 
            this.radioButtonRebounds.AutoSize = true;
            this.radioButtonRebounds.Location = new System.Drawing.Point(9, 66);
            this.radioButtonRebounds.Name = "radioButtonRebounds";
            this.radioButtonRebounds.Size = new System.Drawing.Size(90, 17);
            this.radioButtonRebounds.TabIndex = 2;
            this.radioButtonRebounds.TabStop = true;
            this.radioButtonRebounds.Text = "по подборам";
            this.radioButtonRebounds.UseVisualStyleBackColor = true;
            this.radioButtonRebounds.CheckedChanged += new System.EventHandler(this.radioButtonRebounds_CheckedChanged);
            // 
            // radioButtonPoints
            // 
            this.radioButtonPoints.AutoSize = true;
            this.radioButtonPoints.Location = new System.Drawing.Point(9, 43);
            this.radioButtonPoints.Name = "radioButtonPoints";
            this.radioButtonPoints.Size = new System.Drawing.Size(71, 17);
            this.radioButtonPoints.TabIndex = 1;
            this.radioButtonPoints.TabStop = true;
            this.radioButtonPoints.Text = "по очкам";
            this.radioButtonPoints.UseVisualStyleBackColor = true;
            this.radioButtonPoints.CheckedChanged += new System.EventHandler(this.radioButtonPoints_CheckedChanged);
            // 
            // radioButtonCntGames
            // 
            this.radioButtonCntGames.AutoSize = true;
            this.radioButtonCntGames.Location = new System.Drawing.Point(9, 20);
            this.radioButtonCntGames.Name = "radioButtonCntGames";
            this.radioButtonCntGames.Size = new System.Drawing.Size(170, 17);
            this.radioButtonCntGames.TabIndex = 0;
            this.radioButtonCntGames.TabStop = true;
            this.radioButtonCntGames.Text = "по количеству сыграных игр";
            this.radioButtonCntGames.UseVisualStyleBackColor = true;
            this.radioButtonCntGames.CheckedChanged += new System.EventHandler(this.radioButtonCntGames_CheckedChanged);
            // 
            // dataGridViewRatingNBL
            // 
            this.dataGridViewRatingNBL.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRatingNBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRatingNBL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column10,
            this.Column9});
            this.dataGridViewRatingNBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRatingNBL.Location = new System.Drawing.Point(239, 0);
            this.dataGridViewRatingNBL.MultiSelect = false;
            this.dataGridViewRatingNBL.Name = "dataGridViewRatingNBL";
            this.dataGridViewRatingNBL.ReadOnly = true;
            this.dataGridViewRatingNBL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewRatingNBL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRatingNBL.Size = new System.Drawing.Size(715, 503);
            this.dataGridViewRatingNBL.TabIndex = 9;
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
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Команда";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Игры";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Очки";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Подборы";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Передачи";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Перехваты";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 70;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Блок-шоты";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Фолы";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 70;
            // 
            // RatingPlayerInNBL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 503);
            this.Controls.Add(this.dataGridViewRatingNBL);
            this.Controls.Add(this.panelSearch);
            this.Name = "RatingPlayerInNBL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика игроков в НБЛ";
            this.Load += new System.EventHandler(this.RatingPlayerInNBL_Load);
            this.panelSearch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRatingNBL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.DataGridView dataGridViewRatingNBL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonCntGames;
        private System.Windows.Forms.RadioButton radioButtonFouls;
        private System.Windows.Forms.RadioButton radioButtonBlocks;
        private System.Windows.Forms.RadioButton radioButtonSteals;
        private System.Windows.Forms.RadioButton radioButtonAssists;
        private System.Windows.Forms.RadioButton radioButtonRebounds;
        private System.Windows.Forms.RadioButton radioButtonPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;

    }
}