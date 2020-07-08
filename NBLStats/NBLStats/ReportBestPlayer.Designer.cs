namespace NBLStats
{
    partial class ReportBestPlayer
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTypeGame = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCntPlayer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPCG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLimitFt = new System.Windows.Forms.TextBox();
            this.textBoxLimit3 = new System.Windows.Forms.TextBox();
            this.textBoxLimit2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonPeriodDate = new System.Windows.Forms.RadioButton();
            this.radioButtonOneDate = new System.Windows.Forms.RadioButton();
            this.checkedListBoxGroup = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(7, 321);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Создать";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(303, 321);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkedListBoxGroup);
            this.groupBox1.Controls.Add(this.comboBoxTypeGame);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 218);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Условия отчёта";
            // 
            // comboBoxTypeGame
            // 
            this.comboBoxTypeGame.FormattingEnabled = true;
            this.comboBoxTypeGame.Location = new System.Drawing.Point(10, 75);
            this.comboBoxTypeGame.Name = "comboBoxTypeGame";
            this.comboBoxTypeGame.Size = new System.Drawing.Size(147, 21);
            this.comboBoxTypeGame.TabIndex = 1;
            this.comboBoxTypeGame.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeGame_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Игры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(10, 33);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(147, 21);
            this.comboBoxDivision.TabIndex = 2;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCntPlayer);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxPCG);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxLimitFt);
            this.groupBox3.Controls.Add(this.textBoxLimit3);
            this.groupBox3.Controls.Add(this.textBoxLimit2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(185, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 110);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Лимит расчетов";
            // 
            // textBoxCntPlayer
            // 
            this.textBoxCntPlayer.Location = new System.Drawing.Point(143, 56);
            this.textBoxCntPlayer.Name = "textBoxCntPlayer";
            this.textBoxCntPlayer.Size = new System.Drawing.Size(40, 20);
            this.textBoxCntPlayer.TabIndex = 7;
            this.textBoxCntPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "лучших ";
            // 
            // textBoxPCG
            // 
            this.textBoxPCG.Location = new System.Drawing.Point(143, 85);
            this.textBoxPCG.Name = "textBoxPCG";
            this.textBoxPCG.Size = new System.Drawing.Size(40, 20);
            this.textBoxPCG.TabIndex = 6;
            this.textBoxPCG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "процент игр от команды";
            // 
            // textBoxLimitFt
            // 
            this.textBoxLimitFt.Location = new System.Drawing.Point(75, 68);
            this.textBoxLimitFt.Name = "textBoxLimitFt";
            this.textBoxLimitFt.Size = new System.Drawing.Size(40, 20);
            this.textBoxLimitFt.TabIndex = 5;
            this.textBoxLimitFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxLimit3
            // 
            this.textBoxLimit3.Location = new System.Drawing.Point(75, 42);
            this.textBoxLimit3.Name = "textBoxLimit3";
            this.textBoxLimit3.Size = new System.Drawing.Size(40, 20);
            this.textBoxLimit3.TabIndex = 4;
            this.textBoxLimit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxLimit2
            // 
            this.textBoxLimit2.Location = new System.Drawing.Point(75, 18);
            this.textBoxLimit2.Name = "textBoxLimit2";
            this.textBoxLimit2.Size = new System.Drawing.Size(40, 20);
            this.textBoxLimit2.TabIndex = 3;
            this.textBoxLimit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "для штраф.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "для 2-х очк.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "для 3-х очк.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePickerDateEnd);
            this.groupBox2.Controls.Add(this.dateTimePickerDateBegin);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.radioButtonPeriodDate);
            this.groupBox2.Controls.Add(this.radioButtonOneDate);
            this.groupBox2.Location = new System.Drawing.Point(7, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 71);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "10 лучших";
            // 
            // dateTimePickerDateEnd
            // 
            this.dateTimePickerDateEnd.Location = new System.Drawing.Point(209, 40);
            this.dateTimePickerDateEnd.Name = "dateTimePickerDateEnd";
            this.dateTimePickerDateEnd.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerDateEnd.TabIndex = 5;
            // 
            // dateTimePickerDateBegin
            // 
            this.dateTimePickerDateBegin.Location = new System.Drawing.Point(24, 40);
            this.dateTimePickerDateBegin.Name = "dateTimePickerDateBegin";
            this.dateTimePickerDateBegin.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerDateBegin.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "по";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "c";
            // 
            // radioButtonPeriodDate
            // 
            this.radioButtonPeriodDate.AutoSize = true;
            this.radioButtonPeriodDate.Location = new System.Drawing.Point(81, 19);
            this.radioButtonPeriodDate.Name = "radioButtonPeriodDate";
            this.radioButtonPeriodDate.Size = new System.Drawing.Size(76, 17);
            this.radioButtonPeriodDate.TabIndex = 1;
            this.radioButtonPeriodDate.TabStop = true;
            this.radioButtonPeriodDate.Text = "за период";
            this.radioButtonPeriodDate.UseVisualStyleBackColor = true;
            this.radioButtonPeriodDate.CheckedChanged += new System.EventHandler(this.radioButtonPeriodDate_CheckedChanged);
            // 
            // radioButtonOneDate
            // 
            this.radioButtonOneDate.AutoSize = true;
            this.radioButtonOneDate.Location = new System.Drawing.Point(10, 19);
            this.radioButtonOneDate.Name = "radioButtonOneDate";
            this.radioButtonOneDate.Size = new System.Drawing.Size(62, 17);
            this.radioButtonOneDate.TabIndex = 0;
            this.radioButtonOneDate.TabStop = true;
            this.radioButtonOneDate.Text = "за дату";
            this.radioButtonOneDate.UseVisualStyleBackColor = true;
            this.radioButtonOneDate.CheckedChanged += new System.EventHandler(this.radioButtonOneDate_CheckedChanged);
            // 
            // checkedListBoxGroup
            // 
            this.checkedListBoxGroup.FormattingEnabled = true;
            this.checkedListBoxGroup.Location = new System.Drawing.Point(10, 118);
            this.checkedListBoxGroup.Name = "checkedListBoxGroup";
            this.checkedListBoxGroup.Size = new System.Drawing.Size(147, 94);
            this.checkedListBoxGroup.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Группы";
            // 
            // ReportBestPlayer
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(389, 366);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportBestPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лучшие по номинациям";
            this.Load += new System.EventHandler(this.ReportBestPlayer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxTypeGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxLimitFt;
        private System.Windows.Forms.TextBox textBoxLimit3;
        private System.Windows.Forms.TextBox textBoxLimit2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCntPlayer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPCG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateBegin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonPeriodDate;
        private System.Windows.Forms.RadioButton radioButtonOneDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox checkedListBoxGroup;
    }
}