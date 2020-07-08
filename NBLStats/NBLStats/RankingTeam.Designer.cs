namespace NBLStats
{
    partial class RankingTeam
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
            this.dataGridViewRankingTeam = new System.Windows.Forms.DataGridView();
            this.panelData = new System.Windows.Forms.Panel();
            this.buttonToExcel = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDR = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxIS = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRankingTeam)).BeginInit();
            this.panelData.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRankingTeam
            // 
            this.dataGridViewRankingTeam.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewRankingTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRankingTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridViewRankingTeam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRankingTeam.Location = new System.Drawing.Point(242, 0);
            this.dataGridViewRankingTeam.Name = "dataGridViewRankingTeam";
            this.dataGridViewRankingTeam.Size = new System.Drawing.Size(693, 546);
            this.dataGridViewRankingTeam.TabIndex = 3;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.groupBox1);
            this.panelData.Controls.Add(this.groupBoxData);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(242, 546);
            this.panelData.TabIndex = 2;
            // 
            // buttonToExcel
            // 
            this.buttonToExcel.Location = new System.Drawing.Point(21, 89);
            this.buttonToExcel.Name = "buttonToExcel";
            this.buttonToExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonToExcel.TabIndex = 13;
            this.buttonToExcel.Text = "В Excel";
            this.buttonToExcel.UseVisualStyleBackColor = true;
            this.buttonToExcel.Click += new System.EventHandler(this.buttonToExcel_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.buttonToExcel);
            this.groupBoxData.Controls.Add(this.label2);
            this.groupBoxData.Controls.Add(this.buttonSearch);
            this.groupBoxData.Controls.Add(this.comboBoxIS);
            this.groupBoxData.Location = new System.Drawing.Point(12, 12);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(213, 126);
            this.groupBoxData.TabIndex = 0;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Выбрать дату публикации";
            // 
            // dateTimePickerDR
            // 
            this.dateTimePickerDR.Location = new System.Drawing.Point(21, 30);
            this.dateTimePickerDR.Name = "dateTimePickerDR";
            this.dateTimePickerDR.Size = new System.Drawing.Size(176, 20);
            this.dateTimePickerDR.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Дата публикации";
            // 
            // buttonCalc
            // 
            this.buttonCalc.Location = new System.Drawing.Point(122, 71);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(75, 23);
            this.buttonCalc.TabIndex = 12;
            this.buttonCalc.Text = "Рассчитать";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(122, 89);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Применить";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxIS
            // 
            this.comboBoxIS.FormattingEnabled = true;
            this.comboBoxIS.Location = new System.Drawing.Point(21, 44);
            this.comboBoxIS.Name = "comboBoxIS";
            this.comboBoxIS.Size = new System.Drawing.Size(176, 21);
            this.comboBoxIS.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerDR);
            this.groupBox1.Controls.Add(this.buttonCalc);
            this.groupBox1.Location = new System.Drawing.Point(12, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 126);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расчет ";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "№";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Команда";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Баллы";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Сила";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Игры";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // RankingTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 546);
            this.Controls.Add(this.dataGridViewRankingTeam);
            this.Controls.Add(this.panelData);
            this.Name = "RankingTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Рейтинг команд НБЛ";
            this.Load += new System.EventHandler(this.RankingTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRankingTeam)).EndInit();
            this.panelData.ResumeLayout(false);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRankingTeam;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.ComboBox comboBoxIS;
        private System.Windows.Forms.Button buttonCalc;
        private System.Windows.Forms.Button buttonToExcel;
        private System.Windows.Forms.DateTimePicker dateTimePickerDR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}