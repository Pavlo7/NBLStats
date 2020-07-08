namespace NBLStats
{
    partial class Mode
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
            this.radioButtonView = new System.Windows.Forms.RadioButton();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.radioButtonEdit = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonEdit);
            this.groupBox1.Controls.Add(this.textBoxPwd);
            this.groupBox1.Controls.Add(this.radioButtonView);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(111, 93);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // radioButtonView
            // 
            this.radioButtonView.AutoSize = true;
            this.radioButtonView.Location = new System.Drawing.Point(7, 13);
            this.radioButtonView.Name = "radioButtonView";
            this.radioButtonView.Size = new System.Drawing.Size(117, 17);
            this.radioButtonView.TabIndex = 0;
            this.radioButtonView.TabStop = true;
            this.radioButtonView.Text = "режим просмотра";
            this.radioButtonView.UseVisualStyleBackColor = true;
            this.radioButtonView.CheckedChanged += new System.EventHandler(this.radioButtonView_CheckedChanged);
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Enabled = false;
            this.textBoxPwd.Location = new System.Drawing.Point(149, 53);
            this.textBoxPwd.MaxLength = 16;
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.PasswordChar = '*';
            this.textBoxPwd.Size = new System.Drawing.Size(124, 20);
            this.textBoxPwd.TabIndex = 1;
            // 
            // radioButtonEdit
            // 
            this.radioButtonEdit.AutoSize = true;
            this.radioButtonEdit.Location = new System.Drawing.Point(130, 13);
            this.radioButtonEdit.Name = "radioButtonEdit";
            this.radioButtonEdit.Size = new System.Drawing.Size(145, 17);
            this.radioButtonEdit.TabIndex = 2;
            this.radioButtonEdit.TabStop = true;
            this.radioButtonEdit.Text = "режим редактирования";
            this.radioButtonEdit.UseVisualStyleBackColor = true;
            this.radioButtonEdit.CheckedChanged += new System.EventHandler(this.radioButtonEdit_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "пароль";
            // 
            // Mode
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 123);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим программы";
            this.Load += new System.EventHandler(this.Mode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonEdit;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.RadioButton radioButtonView;
        private System.Windows.Forms.Button buttonOK;
    }
}