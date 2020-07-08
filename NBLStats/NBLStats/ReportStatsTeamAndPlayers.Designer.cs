namespace NBLStats
{
    partial class ReportStatsTeamAndPlayers
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
            this.groupBoxParam = new System.Windows.Forms.GroupBox();
            this.radioButtonHandTeam = new System.Windows.Forms.RadioButton();
            this.radioButtonUsTeam = new System.Windows.Forms.RadioButton();
            this.radioButtonAllTeam = new System.Windows.Forms.RadioButton();
            this.groupBoxUs = new System.Windows.Forms.GroupBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxTeam = new System.Windows.Forms.CheckedListBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.groupBoxParam.SuspendLayout();
            this.groupBoxUs.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(11, 448);
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
            this.buttonCancel.Location = new System.Drawing.Point(434, 448);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxParam
            // 
            this.groupBoxParam.Controls.Add(this.checkBoxAll);
            this.groupBoxParam.Controls.Add(this.radioButtonHandTeam);
            this.groupBoxParam.Controls.Add(this.radioButtonUsTeam);
            this.groupBoxParam.Controls.Add(this.radioButtonAllTeam);
            this.groupBoxParam.Controls.Add(this.groupBoxUs);
            this.groupBoxParam.Controls.Add(this.checkedListBoxTeam);
            this.groupBoxParam.Location = new System.Drawing.Point(11, 6);
            this.groupBoxParam.Name = "groupBoxParam";
            this.groupBoxParam.Size = new System.Drawing.Size(498, 436);
            this.groupBoxParam.TabIndex = 6;
            this.groupBoxParam.TabStop = false;
            this.groupBoxParam.Text = "Параметры отчёта";
            // 
            // radioButtonHandTeam
            // 
            this.radioButtonHandTeam.AutoSize = true;
            this.radioButtonHandTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonHandTeam.Location = new System.Drawing.Point(10, 196);
            this.radioButtonHandTeam.Name = "radioButtonHandTeam";
            this.radioButtonHandTeam.Size = new System.Drawing.Size(127, 17);
            this.radioButtonHandTeam.TabIndex = 10;
            this.radioButtonHandTeam.TabStop = true;
            this.radioButtonHandTeam.Text = "выбрать вручную";
            this.radioButtonHandTeam.UseVisualStyleBackColor = true;
            this.radioButtonHandTeam.CheckedChanged += new System.EventHandler(this.radioButtonHandTeam_CheckedChanged);
            // 
            // radioButtonUsTeam
            // 
            this.radioButtonUsTeam.AutoSize = true;
            this.radioButtonUsTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonUsTeam.Location = new System.Drawing.Point(10, 44);
            this.radioButtonUsTeam.Name = "radioButtonUsTeam";
            this.radioButtonUsTeam.Size = new System.Drawing.Size(93, 17);
            this.radioButtonUsTeam.TabIndex = 9;
            this.radioButtonUsTeam.TabStop = true;
            this.radioButtonUsTeam.Text = "по условию";
            this.radioButtonUsTeam.UseVisualStyleBackColor = true;
            this.radioButtonUsTeam.CheckedChanged += new System.EventHandler(this.radioButtonUsTeam_CheckedChanged);
            // 
            // radioButtonAllTeam
            // 
            this.radioButtonAllTeam.AutoSize = true;
            this.radioButtonAllTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAllTeam.Location = new System.Drawing.Point(10, 21);
            this.radioButtonAllTeam.Name = "radioButtonAllTeam";
            this.radioButtonAllTeam.Size = new System.Drawing.Size(103, 17);
            this.radioButtonAllTeam.TabIndex = 8;
            this.radioButtonAllTeam.TabStop = true;
            this.radioButtonAllTeam.Text = "все команды";
            this.radioButtonAllTeam.UseVisualStyleBackColor = true;
            this.radioButtonAllTeam.CheckedChanged += new System.EventHandler(this.radioButtonAllTeam_CheckedChanged);
            // 
            // groupBoxUs
            // 
            this.groupBoxUs.Controls.Add(this.comboBoxGroup);
            this.groupBoxUs.Controls.Add(this.label2);
            this.groupBoxUs.Controls.Add(this.comboBoxDivision);
            this.groupBoxUs.Controls.Add(this.label1);
            this.groupBoxUs.Location = new System.Drawing.Point(27, 67);
            this.groupBoxUs.Name = "groupBoxUs";
            this.groupBoxUs.Size = new System.Drawing.Size(208, 123);
            this.groupBoxUs.TabIndex = 7;
            this.groupBoxUs.TabStop = false;
            this.groupBoxUs.Text = "Условия";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(6, 91);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(183, 21);
            this.comboBoxGroup.TabIndex = 8;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Группа";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(6, 39);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(183, 21);
            this.comboBoxDivision.TabIndex = 1;
            this.comboBoxDivision.SelectedIndexChanged += new System.EventHandler(this.comboBoxDivision_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Дивизион";
            // 
            // checkedListBoxTeam
            // 
            this.checkedListBoxTeam.FormattingEnabled = true;
            this.checkedListBoxTeam.Location = new System.Drawing.Point(241, 16);
            this.checkedListBoxTeam.Name = "checkedListBoxTeam";
            this.checkedListBoxTeam.Size = new System.Drawing.Size(241, 394);
            this.checkedListBoxTeam.TabIndex = 3;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(10, 393);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(183, 17);
            this.checkBoxAll.TabIndex = 11;
            this.checkBoxAll.Text = "учитывать игры  других этапов";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // ReportStatsTeamAndPlayers
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(518, 483);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxParam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportStatsTeamAndPlayers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Статистика команд и игроков";
            this.Load += new System.EventHandler(this.ReportStatsTeamAndPlayers_Load);
            this.groupBoxParam.ResumeLayout(false);
            this.groupBoxParam.PerformLayout();
            this.groupBoxUs.ResumeLayout(false);
            this.groupBoxUs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxParam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxTeam;
        private System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.RadioButton radioButtonHandTeam;
        private System.Windows.Forms.RadioButton radioButtonUsTeam;
        private System.Windows.Forms.RadioButton radioButtonAllTeam;
        private System.Windows.Forms.GroupBox groupBoxUs;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxAll;
    }
}