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
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxStage = new System.Windows.Forms.ComboBox();
            this.textBoxRound = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(7, 196);
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
            this.buttonCancel.Location = new System.Drawing.Point(303, 196);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxStage);
            this.groupBox1.Controls.Add(this.textBoxRound);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxTypeGame);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxDivision);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 182);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Условия отчёта";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Стадия";
            // 
            // comboBoxStage
            // 
            this.comboBoxStage.FormattingEnabled = true;
            this.comboBoxStage.Location = new System.Drawing.Point(10, 129);
            this.comboBoxStage.Name = "comboBoxStage";
            this.comboBoxStage.Size = new System.Drawing.Size(147, 21);
            this.comboBoxStage.TabIndex = 17;
            // 
            // textBoxRound
            // 
            this.textBoxRound.Location = new System.Drawing.Point(117, 156);
            this.textBoxRound.Name = "textBoxRound";
            this.textBoxRound.Size = new System.Drawing.Size(40, 20);
            this.textBoxRound.TabIndex = 16;
            this.textBoxRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Максимальный тур";
            // 
            // comboBoxTypeGame
            // 
            this.comboBoxTypeGame.FormattingEnabled = true;
            this.comboBoxTypeGame.Location = new System.Drawing.Point(10, 82);
            this.comboBoxTypeGame.Name = "comboBoxTypeGame";
            this.comboBoxTypeGame.Size = new System.Drawing.Size(147, 21);
            this.comboBoxTypeGame.TabIndex = 1;
            this.comboBoxTypeGame.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeGame_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Игры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(10, 37);
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
            this.groupBox3.Size = new System.Drawing.Size(193, 182);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Лимит расчетов";
            // 
            // textBoxCntPlayer
            // 
            this.textBoxCntPlayer.Location = new System.Drawing.Point(105, 139);
            this.textBoxCntPlayer.Name = "textBoxCntPlayer";
            this.textBoxCntPlayer.Size = new System.Drawing.Size(40, 20);
            this.textBoxCntPlayer.TabIndex = 7;
            this.textBoxCntPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "выводить лучших ";
            // 
            // textBoxPCG
            // 
            this.textBoxPCG.Location = new System.Drawing.Point(145, 100);
            this.textBoxPCG.Name = "textBoxPCG";
            this.textBoxPCG.Size = new System.Drawing.Size(40, 20);
            this.textBoxPCG.TabIndex = 6;
            this.textBoxPCG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 107);
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
            // ReportBestPlayer
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(386, 225);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.TextBox textBoxRound;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxStage;
    }
}