namespace NBLStats
{
    partial class DlgBookOut
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxBook = new System.Windows.Forms.CheckBox();
            this.checkBoxGames = new System.Windows.Forms.CheckBox();
            this.groupBoxGames = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGamesBegin = new System.Windows.Forms.TextBox();
            this.textBoxGamesEnd = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxGames.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxGames);
            this.groupBox1.Controls.Add(this.checkBoxGames);
            this.groupBox1.Controls.Add(this.checkBoxBook);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры выгрузки";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(129, 149);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "Выполнить";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(5, 149);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxBook
            // 
            this.checkBoxBook.AutoSize = true;
            this.checkBoxBook.Location = new System.Drawing.Point(17, 27);
            this.checkBoxBook.Name = "checkBoxBook";
            this.checkBoxBook.Size = new System.Drawing.Size(91, 17);
            this.checkBoxBook.TabIndex = 0;
            this.checkBoxBook.Text = "справочники";
            this.checkBoxBook.UseVisualStyleBackColor = true;
            // 
            // checkBoxGames
            // 
            this.checkBoxGames.AutoSize = true;
            this.checkBoxGames.Location = new System.Drawing.Point(17, 60);
            this.checkBoxGames.Name = "checkBoxGames";
            this.checkBoxGames.Size = new System.Drawing.Size(51, 17);
            this.checkBoxGames.TabIndex = 1;
            this.checkBoxGames.Text = "игры";
            this.checkBoxGames.UseVisualStyleBackColor = true;
            this.checkBoxGames.CheckedChanged += new System.EventHandler(this.checkBoxGames_CheckedChanged);
            // 
            // groupBoxGames
            // 
            this.groupBoxGames.Controls.Add(this.textBoxGamesEnd);
            this.groupBoxGames.Controls.Add(this.textBoxGamesBegin);
            this.groupBoxGames.Controls.Add(this.label2);
            this.groupBoxGames.Controls.Add(this.label1);
            this.groupBoxGames.Location = new System.Drawing.Point(17, 83);
            this.groupBoxGames.Name = "groupBoxGames";
            this.groupBoxGames.Size = new System.Drawing.Size(171, 46);
            this.groupBoxGames.TabIndex = 2;
            this.groupBoxGames.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "по";
            // 
            // textBoxGamesBegin
            // 
            this.textBoxGamesBegin.Location = new System.Drawing.Point(24, 17);
            this.textBoxGamesBegin.Name = "textBoxGamesBegin";
            this.textBoxGamesBegin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxGamesBegin.Size = new System.Drawing.Size(43, 20);
            this.textBoxGamesBegin.TabIndex = 2;
            // 
            // textBoxGamesEnd
            // 
            this.textBoxGamesEnd.Location = new System.Drawing.Point(115, 17);
            this.textBoxGamesEnd.Name = "textBoxGamesEnd";
            this.textBoxGamesEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxGamesEnd.Size = new System.Drawing.Size(43, 20);
            this.textBoxGamesEnd.TabIndex = 3;
            // 
            // DlgBookOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 180);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgBookOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выгрузка данных для SmartStats";
            this.Load += new System.EventHandler(this.DlgBookOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxGames.ResumeLayout(false);
            this.groupBoxGames.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxBook;
        private System.Windows.Forms.GroupBox groupBoxGames;
        private System.Windows.Forms.TextBox textBoxGamesEnd;
        private System.Windows.Forms.TextBox textBoxGamesBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxGames;
    }
}