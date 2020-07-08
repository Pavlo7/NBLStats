namespace NBLStats
{
    partial class ReportRatingsTeam
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
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.comboBoxStage = new System.Windows.Forms.ComboBox();
            this.checkBoxStage = new System.Windows.Forms.CheckBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.checkBoxType = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkedListBoxGroup = new System.Windows.Forms.CheckedListBox();
            this.groupBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.label10);
            this.groupBoxData.Controls.Add(this.checkedListBoxGroup);
            this.groupBoxData.Controls.Add(this.comboBoxStage);
            this.groupBoxData.Controls.Add(this.checkBoxStage);
            this.groupBoxData.Controls.Add(this.comboBoxType);
            this.groupBoxData.Controls.Add(this.checkBoxType);
            this.groupBoxData.Controls.Add(this.label1);
            this.groupBoxData.Controls.Add(this.comboBoxDivision);
            this.groupBoxData.Location = new System.Drawing.Point(7, 12);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(217, 336);
            this.groupBoxData.TabIndex = 13;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Параметры отчёта";
            // 
            // comboBoxStage
            // 
            this.comboBoxStage.FormattingEnabled = true;
            this.comboBoxStage.Location = new System.Drawing.Point(79, 297);
            this.comboBoxStage.Name = "comboBoxStage";
            this.comboBoxStage.Size = new System.Drawing.Size(126, 21);
            this.comboBoxStage.TabIndex = 5;
            this.comboBoxStage.SelectedIndexChanged += new System.EventHandler(this.comboBoxStage_SelectedIndexChanged);
            // 
            // checkBoxStage
            // 
            this.checkBoxStage.AutoSize = true;
            this.checkBoxStage.Location = new System.Drawing.Point(10, 301);
            this.checkBoxStage.Name = "checkBoxStage";
            this.checkBoxStage.Size = new System.Drawing.Size(61, 17);
            this.checkBoxStage.TabIndex = 4;
            this.checkBoxStage.Text = "стадия";
            this.checkBoxStage.UseVisualStyleBackColor = true;
            this.checkBoxStage.CheckedChanged += new System.EventHandler(this.checkBoxStage_CheckedChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(79, 265);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(126, 21);
            this.comboBoxType.TabIndex = 3;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // checkBoxType
            // 
            this.checkBoxType.AutoSize = true;
            this.checkBoxType.Location = new System.Drawing.Point(10, 267);
            this.checkBoxType.Name = "checkBoxType";
            this.checkBoxType.Size = new System.Drawing.Size(63, 17);
            this.checkBoxType.TabIndex = 2;
            this.checkBoxType.Text = "тип игр";
            this.checkBoxType.UseVisualStyleBackColor = true;
            this.checkBoxType.CheckedChanged += new System.EventHandler(this.checkBoxType_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дивизион";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(10, 35);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(195, 21);
            this.comboBoxDivision.TabIndex = 0;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(149, 354);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 12;
            this.buttonOk.Text = "Создать";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(7, 354);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Группы";
            // 
            // checkedListBoxGroup
            // 
            this.checkedListBoxGroup.FormattingEnabled = true;
            this.checkedListBoxGroup.Location = new System.Drawing.Point(10, 77);
            this.checkedListBoxGroup.Name = "checkedListBoxGroup";
            this.checkedListBoxGroup.Size = new System.Drawing.Size(195, 169);
            this.checkedListBoxGroup.TabIndex = 10;
            // 
            // ReportRatingsTeam
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(233, 383);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportRatingsTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Рейтинги команд";
            this.Load += new System.EventHandler(this.RatingsTeam_Load);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxStage;
        private System.Windows.Forms.CheckBox checkBoxStage;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.CheckBox checkBoxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox checkedListBoxGroup;
    }
}