namespace NBLStats
{
    partial class DlgDiscvalification
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDescript = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCntGame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.radioButtonCoach = new System.Windows.Forms.RadioButton();
            this.radioButtonPlayer = new System.Windows.Forms.RadioButton();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(7, 219);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSave.Location = new System.Drawing.Point(299, 219);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerDateEnd);
            this.groupBox1.Controls.Add(this.dateTimePickerDateBegin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxDescript);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCntGame);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPart);
            this.groupBox1.Controls.Add(this.radioButtonCoach);
            this.groupBox1.Controls.Add(this.radioButtonPlayer);
            this.groupBox1.Controls.Add(this.comboBoxTeam);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 208);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // dateTimePickerDateEnd
            // 
            this.dateTimePickerDateEnd.Location = new System.Drawing.Point(232, 131);
            this.dateTimePickerDateEnd.Name = "dateTimePickerDateEnd";
            this.dateTimePickerDateEnd.Size = new System.Drawing.Size(126, 20);
            this.dateTimePickerDateEnd.TabIndex = 15;
            // 
            // dateTimePickerDateBegin
            // 
            this.dateTimePickerDateBegin.Location = new System.Drawing.Point(100, 131);
            this.dateTimePickerDateBegin.Name = "dateTimePickerDateBegin";
            this.dateTimePickerDateBegin.Size = new System.Drawing.Size(126, 20);
            this.dateTimePickerDateBegin.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Дата окончания";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дата начала";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(298, 38);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(49, 20);
            this.textBoxId.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Id";
            // 
            // textBoxDescript
            // 
            this.textBoxDescript.Location = new System.Drawing.Point(11, 180);
            this.textBoxDescript.Name = "textBoxDescript";
            this.textBoxDescript.Size = new System.Drawing.Size(336, 20);
            this.textBoxDescript.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Основание";
            // 
            // textBoxCntGame
            // 
            this.textBoxCntGame.Location = new System.Drawing.Point(11, 132);
            this.textBoxCntGame.Name = "textBoxCntGame";
            this.textBoxCntGame.Size = new System.Drawing.Size(49, 20);
            this.textBoxCntGame.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество игр";
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.Location = new System.Drawing.Point(11, 87);
            this.comboBoxPart.MaxDropDownItems = 34;
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(266, 21);
            this.comboBoxPart.TabIndex = 4;
            // 
            // radioButtonCoach
            // 
            this.radioButtonCoach.AutoSize = true;
            this.radioButtonCoach.Location = new System.Drawing.Point(98, 68);
            this.radioButtonCoach.Name = "radioButtonCoach";
            this.radioButtonCoach.Size = new System.Drawing.Size(60, 17);
            this.radioButtonCoach.TabIndex = 3;
            this.radioButtonCoach.TabStop = true;
            this.radioButtonCoach.Text = "тренер";
            this.radioButtonCoach.UseVisualStyleBackColor = true;
            this.radioButtonCoach.CheckedChanged += new System.EventHandler(this.radioButtonCoach_CheckedChanged);
            // 
            // radioButtonPlayer
            // 
            this.radioButtonPlayer.AutoSize = true;
            this.radioButtonPlayer.Location = new System.Drawing.Point(11, 68);
            this.radioButtonPlayer.Name = "radioButtonPlayer";
            this.radioButtonPlayer.Size = new System.Drawing.Size(54, 17);
            this.radioButtonPlayer.TabIndex = 2;
            this.radioButtonPlayer.TabStop = true;
            this.radioButtonPlayer.Text = "игрок";
            this.radioButtonPlayer.UseVisualStyleBackColor = true;
            this.radioButtonPlayer.CheckedChanged += new System.EventHandler(this.radioButtonPlayer_CheckedChanged);
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(11, 38);
            this.comboBoxTeam.MaxDropDownItems = 34;
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(185, 21);
            this.comboBoxTeam.TabIndex = 1;
            this.comboBoxTeam.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeam_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Команда";
            // 
            // DlgDiscvalification
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(379, 248);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgDiscvalification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DlgDiscvalification_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateBegin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescript;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCntGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.RadioButton radioButtonCoach;
        private System.Windows.Forms.RadioButton radioButtonPlayer;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.Label label1;
    }
}