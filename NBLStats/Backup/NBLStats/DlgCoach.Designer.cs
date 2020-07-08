namespace NBLStats
{
    partial class DlgCoach
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNameFoto = new System.Windows.Forms.Label();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.contextMenuStripFoto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemSelectFoto = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDeleteFoto = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogFoto = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDescript = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.textBoxPersonalNum = new System.Windows.Forms.TextBox();
            this.dateTimePickerDateBirth = new System.Windows.Forms.DateTimePicker();
            this.textBoxSecondName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxFamily = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.contextMenuStripFoto.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNameFoto);
            this.groupBox1.Controls.Add(this.pictureBoxFoto);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 225);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фото";
            // 
            // labelNameFoto
            // 
            this.labelNameFoto.AutoSize = true;
            this.labelNameFoto.ForeColor = System.Drawing.Color.Maroon;
            this.labelNameFoto.Location = new System.Drawing.Point(6, 202);
            this.labelNameFoto.Name = "labelNameFoto";
            this.labelNameFoto.Size = new System.Drawing.Size(0, 13);
            this.labelNameFoto.TabIndex = 1;
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.ContextMenuStrip = this.contextMenuStripFoto;
            this.pictureBoxFoto.Location = new System.Drawing.Point(9, 15);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(161, 181);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFoto.TabIndex = 0;
            this.pictureBoxFoto.TabStop = false;
            // 
            // contextMenuStripFoto
            // 
            this.contextMenuStripFoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSelectFoto,
            this.ToolStripMenuItemDeleteFoto});
            this.contextMenuStripFoto.Name = "contextMenuStripFoto";
            this.contextMenuStripFoto.Size = new System.Drawing.Size(157, 48);
            // 
            // ToolStripMenuItemSelectFoto
            // 
            this.ToolStripMenuItemSelectFoto.Name = "ToolStripMenuItemSelectFoto";
            this.ToolStripMenuItemSelectFoto.Size = new System.Drawing.Size(156, 22);
            this.ToolStripMenuItemSelectFoto.Text = "Выбрать фото";
            this.ToolStripMenuItemSelectFoto.Click += new System.EventHandler(this.ToolStripMenuItemSelectFoto_Click);
            // 
            // ToolStripMenuItemDeleteFoto
            // 
            this.ToolStripMenuItemDeleteFoto.Name = "ToolStripMenuItemDeleteFoto";
            this.ToolStripMenuItemDeleteFoto.Size = new System.Drawing.Size(156, 22);
            this.ToolStripMenuItemDeleteFoto.Text = "Удалить фото";
            this.ToolStripMenuItemDeleteFoto.Click += new System.EventHandler(this.ToolStripMenuItemDeleteFoto_Click);
            // 
            // openFileDialogFoto
            // 
            this.openFileDialogFoto.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDescript);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxId);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBoxCountry);
            this.groupBox2.Controls.Add(this.textBoxPersonalNum);
            this.groupBox2.Controls.Add(this.dateTimePickerDateBirth);
            this.groupBox2.Controls.Add(this.textBoxSecondName);
            this.groupBox2.Controls.Add(this.textBoxName);
            this.groupBox2.Controls.Add(this.textBoxFamily);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(206, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 225);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные игрока";
            // 
            // textBoxDescript
            // 
            this.textBoxDescript.Location = new System.Drawing.Point(10, 199);
            this.textBoxDescript.MaxLength = 256;
            this.textBoxDescript.Name = "textBoxDescript";
            this.textBoxDescript.Size = new System.Drawing.Size(252, 20);
            this.textBoxDescript.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Описание";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(13, 37);
            this.textBoxId.MaxLength = 64;
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(47, 20);
            this.textBoxId.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Id";
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.ItemHeight = 13;
            this.comboBoxCountry.Location = new System.Drawing.Point(153, 159);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(109, 21);
            this.comboBoxCountry.TabIndex = 6;
            // 
            // textBoxPersonalNum
            // 
            this.textBoxPersonalNum.Location = new System.Drawing.Point(10, 160);
            this.textBoxPersonalNum.MaxLength = 14;
            this.textBoxPersonalNum.Name = "textBoxPersonalNum";
            this.textBoxPersonalNum.Size = new System.Drawing.Size(120, 20);
            this.textBoxPersonalNum.TabIndex = 5;
            // 
            // dateTimePickerDateBirth
            // 
            this.dateTimePickerDateBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateBirth.Location = new System.Drawing.Point(10, 120);
            this.dateTimePickerDateBirth.Name = "dateTimePickerDateBirth";
            this.dateTimePickerDateBirth.Size = new System.Drawing.Size(97, 20);
            this.dateTimePickerDateBirth.TabIndex = 4;
            // 
            // textBoxSecondName
            // 
            this.textBoxSecondName.Location = new System.Drawing.Point(111, 76);
            this.textBoxSecondName.MaxLength = 64;
            this.textBoxSecondName.Name = "textBoxSecondName";
            this.textBoxSecondName.Size = new System.Drawing.Size(151, 20);
            this.textBoxSecondName.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(10, 76);
            this.textBoxName.MaxLength = 32;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(95, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxFamily
            // 
            this.textBoxFamily.Location = new System.Drawing.Point(81, 37);
            this.textBoxFamily.MaxLength = 64;
            this.textBoxFamily.Name = "textBoxFamily";
            this.textBoxFamily.Size = new System.Drawing.Size(181, 20);
            this.textBoxFamily.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Гражданство";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата рождения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Перс. номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(399, 237);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(10, 237);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // DlgCoach
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(484, 267);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgCoach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DlgCoach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.contextMenuStripFoto.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNameFoto;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFoto;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSelectFoto;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDeleteFoto;
        private System.Windows.Forms.OpenFileDialog openFileDialogFoto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDescript;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.TextBox textBoxPersonalNum;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateBirth;
        private System.Windows.Forms.TextBox textBoxSecondName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxFamily;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}