﻿namespace NBLStats
{
    partial class Symbol5
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxFlaf = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDateE = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateB = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkedListBoxGroup = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(6, 375);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Создать";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(297, 375);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkedListBoxGroup);
            this.groupBox1.Controls.Add(this.checkBoxAll);
            this.groupBox1.Controls.Add(this.checkBoxFlaf);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerDateE);
            this.groupBox1.Controls.Add(this.dateTimePickerDateB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 353);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(19, 307);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(59, 17);
            this.checkBoxAll.TabIndex = 6;
            this.checkBoxAll.Text = "общий";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxFlaf
            // 
            this.checkBoxFlaf.AutoSize = true;
            this.checkBoxFlaf.Location = new System.Drawing.Point(19, 330);
            this.checkBoxFlaf.Name = "checkBoxFlaf";
            this.checkBoxFlaf.Size = new System.Drawing.Size(115, 17);
            this.checkBoxFlaf.TabIndex = 5;
            this.checkBoxFlaf.Text = "только стыковые";
            this.checkBoxFlaf.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "по";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "c";
            // 
            // dateTimePickerDateE
            // 
            this.dateTimePickerDateE.Location = new System.Drawing.Point(229, 40);
            this.dateTimePickerDateE.Name = "dateTimePickerDateE";
            this.dateTimePickerDateE.Size = new System.Drawing.Size(125, 20);
            this.dateTimePickerDateE.TabIndex = 2;
            // 
            // dateTimePickerDateB
            // 
            this.dateTimePickerDateB.Location = new System.Drawing.Point(55, 40);
            this.dateTimePickerDateB.Name = "dateTimePickerDateB";
            this.dateTimePickerDateB.Size = new System.Drawing.Size(127, 20);
            this.dateTimePickerDateB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Группы";
            // 
            // checkedListBoxGroup
            // 
            this.checkedListBoxGroup.FormattingEnabled = true;
            this.checkedListBoxGroup.Location = new System.Drawing.Point(19, 135);
            this.checkedListBoxGroup.Name = "checkedListBoxGroup";
            this.checkedListBoxGroup.Size = new System.Drawing.Size(324, 154);
            this.checkedListBoxGroup.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(19, 93);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(195, 21);
            this.comboBoxDivision.TabIndex = 14;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // Symbol5
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(378, 406);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Symbol5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Символические пятерки";
            this.Load += new System.EventHandler(this.Symbol5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateE;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxFlaf;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox checkedListBoxGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDivision;
    }
}