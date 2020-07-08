namespace NBLStats
{
    partial class DlgDraft
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDateOut = new System.Windows.Forms.DateTimePicker();
            this.checkBoxOut = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxAF = new System.Windows.Forms.CheckBox();
            this.checkBoxAC = new System.Windows.Forms.CheckBox();
            this.checkBoxAD = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.dateTimePickerDateIn = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGrowing = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelIsDemind = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxIdLastTeam = new System.Windows.Forms.ComboBox();
            this.comboBoxIdNextTeam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxIdNextTeam);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dateTimePickerDateOut);
            this.groupBox3.Controls.Add(this.checkBoxOut);
            this.groupBox3.Location = new System.Drawing.Point(8, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 72);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Выход";
            // 
            // dateTimePickerDateOut
            // 
            this.dateTimePickerDateOut.Location = new System.Drawing.Point(11, 42);
            this.dateTimePickerDateOut.Name = "dateTimePickerDateOut";
            this.dateTimePickerDateOut.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerDateOut.TabIndex = 10;
            // 
            // checkBoxOut
            // 
            this.checkBoxOut.AutoSize = true;
            this.checkBoxOut.Location = new System.Drawing.Point(10, 21);
            this.checkBoxOut.Name = "checkBoxOut";
            this.checkBoxOut.Size = new System.Drawing.Size(138, 17);
            this.checkBoxOut.TabIndex = 0;
            this.checkBoxOut.Text = "дата выхода с драфта";
            this.checkBoxOut.UseVisualStyleBackColor = true;
            this.checkBoxOut.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxIdLastTeam);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.checkBoxAF);
            this.groupBox4.Controls.Add(this.checkBoxAC);
            this.groupBox4.Controls.Add(this.checkBoxAD);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBoxWeight);
            this.groupBox4.Controls.Add(this.dateTimePickerDateIn);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBoxGrowing);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(8, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(364, 138);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Драфт";
            // 
            // checkBoxAF
            // 
            this.checkBoxAF.AutoSize = true;
            this.checkBoxAF.Location = new System.Drawing.Point(113, 112);
            this.checkBoxAF.Name = "checkBoxAF";
            this.checkBoxAF.Size = new System.Drawing.Size(70, 17);
            this.checkBoxAF.TabIndex = 15;
            this.checkBoxAF.Text = "форвард";
            this.checkBoxAF.UseVisualStyleBackColor = true;
            // 
            // checkBoxAC
            // 
            this.checkBoxAC.AutoSize = true;
            this.checkBoxAC.Location = new System.Drawing.Point(206, 112);
            this.checkBoxAC.Name = "checkBoxAC";
            this.checkBoxAC.Size = new System.Drawing.Size(79, 17);
            this.checkBoxAC.TabIndex = 15;
            this.checkBoxAC.Text = "центровой";
            this.checkBoxAC.UseVisualStyleBackColor = true;
            // 
            // checkBoxAD
            // 
            this.checkBoxAD.AutoSize = true;
            this.checkBoxAD.Location = new System.Drawing.Point(11, 112);
            this.checkBoxAD.Name = "checkBoxAD";
            this.checkBoxAD.Size = new System.Drawing.Size(76, 17);
            this.checkBoxAD.TabIndex = 14;
            this.checkBoxAD.Text = "защитник";
            this.checkBoxAD.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Амплуа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дата выхода на драфт";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(117, 67);
            this.textBoxWeight.MaxLength = 3;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(34, 20);
            this.textBoxWeight.TabIndex = 5;
            this.textBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePickerDateIn
            // 
            this.dateTimePickerDateIn.Location = new System.Drawing.Point(9, 36);
            this.dateTimePickerDateIn.Name = "dateTimePickerDateIn";
            this.dateTimePickerDateIn.Size = new System.Drawing.Size(146, 20);
            this.dateTimePickerDateIn.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Вес";
            // 
            // textBoxGrowing
            // 
            this.textBoxGrowing.Location = new System.Drawing.Point(45, 67);
            this.textBoxGrowing.MaxLength = 3;
            this.textBoxGrowing.Name = "textBoxGrowing";
            this.textBoxGrowing.Size = new System.Drawing.Size(34, 20);
            this.textBoxGrowing.TabIndex = 4;
            this.textBoxGrowing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Рост";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelIsDemind);
            this.groupBox1.Controls.Add(this.comboBoxName);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 71);
            this.groupBox1.TabIndex = 10;
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
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(8, 308);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(297, 308);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(178, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Откуда";
            // 
            // comboBoxIdLastTeam
            // 
            this.comboBoxIdLastTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdLastTeam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxIdLastTeam.FormattingEnabled = true;
            this.comboBoxIdLastTeam.ItemHeight = 13;
            this.comboBoxIdLastTeam.Location = new System.Drawing.Point(181, 35);
            this.comboBoxIdLastTeam.MaxDropDownItems = 30;
            this.comboBoxIdLastTeam.Name = "comboBoxIdLastTeam";
            this.comboBoxIdLastTeam.Size = new System.Drawing.Size(177, 21);
            this.comboBoxIdLastTeam.TabIndex = 2;
            // 
            // comboBoxIdNextTeam
            // 
            this.comboBoxIdNextTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdNextTeam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxIdNextTeam.FormattingEnabled = true;
            this.comboBoxIdNextTeam.ItemHeight = 13;
            this.comboBoxIdNextTeam.Location = new System.Drawing.Point(181, 43);
            this.comboBoxIdNextTeam.MaxDropDownItems = 30;
            this.comboBoxIdNextTeam.Name = "comboBoxIdNextTeam";
            this.comboBoxIdNextTeam.Size = new System.Drawing.Size(177, 21);
            this.comboBoxIdNextTeam.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(178, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Куда";
            // 
            // DlgDraft
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(379, 341);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgDraft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DlgDraft_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOut;
        private System.Windows.Forms.CheckBox checkBoxOut;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGrowing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelIsDemind;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxAF;
        private System.Windows.Forms.CheckBox checkBoxAC;
        private System.Windows.Forms.CheckBox checkBoxAD;
        private System.Windows.Forms.ComboBox comboBoxIdNextTeam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxIdLastTeam;
        private System.Windows.Forms.Label label2;
    }
}