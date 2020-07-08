namespace NBLStats
{
    partial class ReportReferee
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxNameSeason = new System.Windows.Forms.ComboBox();
            this.radioButtonOneSeason = new System.Windows.Forms.RadioButton();
            this.radioButtonAllSeason = new System.Windows.Forms.RadioButton();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxNameSeason);
            this.groupBox1.Controls.Add(this.radioButtonOneSeason);
            this.groupBox1.Controls.Add(this.radioButtonAllSeason);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxNameSeason
            // 
            this.comboBoxNameSeason.FormattingEnabled = true;
            this.comboBoxNameSeason.Location = new System.Drawing.Point(6, 36);
            this.comboBoxNameSeason.Name = "comboBoxNameSeason";
            this.comboBoxNameSeason.Size = new System.Drawing.Size(154, 21);
            this.comboBoxNameSeason.TabIndex = 2;
            // 
            // radioButtonOneSeason
            // 
            this.radioButtonOneSeason.AutoSize = true;
            this.radioButtonOneSeason.Location = new System.Drawing.Point(6, 13);
            this.radioButtonOneSeason.Name = "radioButtonOneSeason";
            this.radioButtonOneSeason.Size = new System.Drawing.Size(115, 17);
            this.radioButtonOneSeason.TabIndex = 1;
            this.radioButtonOneSeason.TabStop = true;
            this.radioButtonOneSeason.Text = "по одному сезону";
            this.radioButtonOneSeason.UseVisualStyleBackColor = true;
            this.radioButtonOneSeason.CheckedChanged += new System.EventHandler(this.radioButtonOneSeason_CheckedChanged);
            // 
            // radioButtonAllSeason
            // 
            this.radioButtonAllSeason.AutoSize = true;
            this.radioButtonAllSeason.Location = new System.Drawing.Point(206, 13);
            this.radioButtonAllSeason.Name = "radioButtonAllSeason";
            this.radioButtonAllSeason.Size = new System.Drawing.Size(113, 17);
            this.radioButtonAllSeason.TabIndex = 0;
            this.radioButtonAllSeason.TabStop = true;
            this.radioButtonAllSeason.Text = "по всем сезонам";
            this.radioButtonAllSeason.UseVisualStyleBackColor = true;
            this.radioButtonAllSeason.CheckedChanged += new System.EventHandler(this.radioButtonAllSeason_CheckedChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(9, 87);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(259, 87);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ReportReferee
            // 
            this.AcceptButton = this.buttonCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(344, 120);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportReferee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт по судьям";
            this.Load += new System.EventHandler(this.ReportReferee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxNameSeason;
        private System.Windows.Forms.RadioButton radioButtonOneSeason;
        private System.Windows.Forms.RadioButton radioButtonAllSeason;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
    }
}