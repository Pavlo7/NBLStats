namespace NBLStats
{
    partial class DlgEntryPlayer
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
            this.labelIsDemind = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelPersNum = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGrowing = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxAmplua = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerTimeIn = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerTimeOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateOut = new System.Windows.Forms.DateTimePicker();
            this.checkBoxOut = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPriority = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(454, 230);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(12, 230);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelIsDemind);
            this.groupBox1.Controls.Add(this.comboBoxName);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор игрока";
            // 
            // labelIsDemind
            // 
            this.labelIsDemind.AutoSize = true;
            this.labelIsDemind.ForeColor = System.Drawing.Color.Black;
            this.labelIsDemind.Location = new System.Drawing.Point(6, 44);
            this.labelIsDemind.Name = "labelIsDemind";
            this.labelIsDemind.Size = new System.Drawing.Size(0, 13);
            this.labelIsDemind.TabIndex = 1;
            // 
            // comboBoxName
            // 
            this.comboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.ItemHeight = 13;
            this.comboBoxName.Location = new System.Drawing.Point(9, 19);
            this.comboBoxName.MaxDropDownItems = 30;
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(235, 21);
            this.comboBoxName.TabIndex = 1;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelPersNum);
            this.groupBox2.Controls.Add(this.labelDate);
            this.groupBox2.Controls.Add(this.labelFIO);
            this.groupBox2.Location = new System.Drawing.Point(12, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 140);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные игрока";
            // 
            // labelPersNum
            // 
            this.labelPersNum.AutoSize = true;
            this.labelPersNum.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelPersNum.Location = new System.Drawing.Point(6, 71);
            this.labelPersNum.Name = "labelPersNum";
            this.labelPersNum.Size = new System.Drawing.Size(0, 13);
            this.labelPersNum.TabIndex = 2;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelDate.Location = new System.Drawing.Point(6, 48);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(0, 13);
            this.labelDate.TabIndex = 1;
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelFIO.Location = new System.Drawing.Point(6, 26);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(0, 13);
            this.labelFIO.TabIndex = 0;
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(216, 87);
            this.textBoxWeight.MaxLength = 3;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(34, 20);
            this.textBoxWeight.TabIndex = 5;
            this.textBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Вес";
            // 
            // textBoxGrowing
            // 
            this.textBoxGrowing.Location = new System.Drawing.Point(144, 87);
            this.textBoxGrowing.MaxLength = 3;
            this.textBoxGrowing.Name = "textBoxGrowing";
            this.textBoxGrowing.Size = new System.Drawing.Size(34, 20);
            this.textBoxGrowing.TabIndex = 4;
            this.textBoxGrowing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Рост";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(31, 60);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дата заявки";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(55, 87);
            this.textBoxNumber.MaxLength = 3;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(34, 20);
            this.textBoxNumber.TabIndex = 3;
            this.textBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxPriority);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.comboBoxAmplua);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.dateTimePickerTimeIn);
            this.groupBox4.Controls.Add(this.comboBoxTeam);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBoxWeight);
            this.groupBox4.Controls.Add(this.dateTimePickerDate);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.textBoxGrowing);
            this.groupBox4.Controls.Add(this.textBoxNumber);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(273, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 138);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Заявка";
            // 
            // comboBoxAmplua
            // 
            this.comboBoxAmplua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAmplua.FormattingEnabled = true;
            this.comboBoxAmplua.ItemHeight = 13;
            this.comboBoxAmplua.Items.AddRange(new object[] {
            "",
            "защитник",
            "форвард",
            "центровой"});
            this.comboBoxAmplua.Location = new System.Drawing.Point(58, 112);
            this.comboBoxAmplua.MaxDropDownItems = 30;
            this.comboBoxAmplua.Name = "comboBoxAmplua";
            this.comboBoxAmplua.Size = new System.Drawing.Size(119, 21);
            this.comboBoxAmplua.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Амплуа";
            // 
            // dateTimePickerTimeIn
            // 
            this.dateTimePickerTimeIn.CustomFormat = "HH:mm";
            this.dateTimePickerTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTimeIn.Location = new System.Drawing.Point(182, 60);
            this.dateTimePickerTimeIn.Name = "dateTimePickerTimeIn";
            this.dateTimePickerTimeIn.Size = new System.Drawing.Size(68, 20);
            this.dateTimePickerTimeIn.TabIndex = 12;
            this.dateTimePickerTimeIn.Value = new System.DateTime(2011, 9, 16, 0, 0, 0, 0);
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.ItemHeight = 13;
            this.comboBoxTeam.Location = new System.Drawing.Point(71, 19);
            this.comboBoxTeam.MaxDropDownItems = 30;
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(179, 21);
            this.comboBoxTeam.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Команда";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePickerTimeOut);
            this.groupBox3.Controls.Add(this.dateTimePickerDateOut);
            this.groupBox3.Controls.Add(this.checkBoxOut);
            this.groupBox3.Location = new System.Drawing.Point(273, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 72);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Отзаявка";
            // 
            // dateTimePickerTimeOut
            // 
            this.dateTimePickerTimeOut.CustomFormat = "HH:mm";
            this.dateTimePickerTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTimeOut.Location = new System.Drawing.Point(182, 44);
            this.dateTimePickerTimeOut.Name = "dateTimePickerTimeOut";
            this.dateTimePickerTimeOut.Size = new System.Drawing.Size(68, 20);
            this.dateTimePickerTimeOut.TabIndex = 11;
            // 
            // dateTimePickerDateOut
            // 
            this.dateTimePickerDateOut.Location = new System.Drawing.Point(31, 44);
            this.dateTimePickerDateOut.Name = "dateTimePickerDateOut";
            this.dateTimePickerDateOut.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerDateOut.TabIndex = 10;
            // 
            // checkBoxOut
            // 
            this.checkBoxOut.AutoSize = true;
            this.checkBoxOut.Location = new System.Drawing.Point(10, 21);
            this.checkBoxOut.Name = "checkBoxOut";
            this.checkBoxOut.Size = new System.Drawing.Size(118, 17);
            this.checkBoxOut.TabIndex = 0;
            this.checkBoxOut.Text = "отзаявить на дату";
            this.checkBoxOut.UseVisualStyleBackColor = true;
            this.checkBoxOut.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Пр";
            // 
            // textBoxPriority
            // 
            this.textBoxPriority.Location = new System.Drawing.Point(216, 112);
            this.textBoxPriority.MaxLength = 3;
            this.textBoxPriority.Name = "textBoxPriority";
            this.textBoxPriority.Size = new System.Drawing.Size(34, 20);
            this.textBoxPriority.TabIndex = 16;
            this.textBoxPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DlgEntryPlayer
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(541, 259);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DlgEntryPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DlgTeamsPlayer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPersNum;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGrowing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelIsDemind;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOut;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeIn;
        private System.Windows.Forms.ComboBox comboBoxAmplua;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPriority;
        private System.Windows.Forms.Label label7;
    }
}