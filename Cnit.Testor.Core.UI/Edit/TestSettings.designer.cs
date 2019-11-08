namespace Cnit.Testor.Core.UI.Edit
{
    partial class TestSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.gbSettings = new System.Windows.Forms.GroupBox();
			this.cbShowDetailsTestResults = new System.Windows.Forms.CheckBox();
			this.llAdditionalSettings = new System.Windows.Forms.LinkLabel();
			this.gbBasicSettings = new System.Windows.Forms.GroupBox();
			this.txtPassingScore = new System.Windows.Forms.TextBox();
			this.cbHasTimeLimit = new System.Windows.Forms.CheckBox();
			this.lbMinute = new System.Windows.Forms.Label();
			this.nudTimeLimit = new System.Windows.Forms.NumericUpDown();
			this.cbQuestionsNumber = new System.Windows.Forms.CheckBox();
			this.cbPassagesNumber = new System.Windows.Forms.CheckBox();
			this.nudPassagesNumber = new System.Windows.Forms.NumericUpDown();
			this.nudQuestionsNumber = new System.Windows.Forms.NumericUpDown();
			this.cbPassingScore = new System.Windows.Forms.CheckBox();
			this.cbVariantsMode = new System.Windows.Forms.ComboBox();
			this.lbVariantsMode = new System.Windows.Forms.Label();
			this.cbShowRightAnswersCount = new System.Windows.Forms.CheckBox();
			this.cbShowTestResult = new System.Windows.Forms.CheckBox();
			this.cbAllowAdmitQuestions = new System.Windows.Forms.CheckBox();
			this.gbTestActivity = new System.Windows.Forms.GroupBox();
			this.lbTimeEnd = new System.Windows.Forms.Label();
			this.lbTimeStart = new System.Windows.Forms.Label();
			this.cbIsLimitedActive = new System.Windows.Forms.CheckBox();
			this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
			this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
			this.cbIsActive = new System.Windows.Forms.CheckBox();
			this.tbTestName = new System.Windows.Forms.TextBox();
			this.lbDescription = new System.Windows.Forms.Label();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.lbTestName = new System.Windows.Forms.Label();
			this.gbSettings.SuspendLayout();
			this.gbBasicSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPassagesNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudQuestionsNumber)).BeginInit();
			this.gbTestActivity.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbSettings
			// 
			this.gbSettings.Controls.Add(this.cbShowDetailsTestResults);
			this.gbSettings.Controls.Add(this.llAdditionalSettings);
			this.gbSettings.Controls.Add(this.gbBasicSettings);
			this.gbSettings.Controls.Add(this.cbVariantsMode);
			this.gbSettings.Controls.Add(this.lbVariantsMode);
			this.gbSettings.Controls.Add(this.cbShowRightAnswersCount);
			this.gbSettings.Controls.Add(this.cbShowTestResult);
			this.gbSettings.Controls.Add(this.cbAllowAdmitQuestions);
			this.gbSettings.Controls.Add(this.gbTestActivity);
			this.gbSettings.Controls.Add(this.tbTestName);
			this.gbSettings.Controls.Add(this.lbDescription);
			this.gbSettings.Controls.Add(this.tbDescription);
			this.gbSettings.Controls.Add(this.lbTestName);
			this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbSettings.Location = new System.Drawing.Point(0, 0);
			this.gbSettings.MinimumSize = new System.Drawing.Size(421, 502);
			this.gbSettings.Name = "gbSettings";
			this.gbSettings.Size = new System.Drawing.Size(421, 539);
			this.gbSettings.TabIndex = 35;
			this.gbSettings.TabStop = false;
			this.gbSettings.Text = "Настройки";
			// 
			// cbShowDetailsTestResults
			// 
			this.cbShowDetailsTestResults.AutoSize = true;
			this.cbShowDetailsTestResults.Location = new System.Drawing.Point(6, 386);
			this.cbShowDetailsTestResults.Name = "cbShowDetailsTestResults";
			this.cbShowDetailsTestResults.Size = new System.Drawing.Size(316, 17);
			this.cbShowDetailsTestResults.TabIndex = 43;
			this.cbShowDetailsTestResults.Text = "Показывать верные ответы в результатах тестирования";
			this.cbShowDetailsTestResults.CheckedChanged += new System.EventHandler(this.cbShowDetailsTestResults_CheckedChanged);
			// 
			// llAdditionalSettings
			// 
			this.llAdditionalSettings.AutoSize = true;
			this.llAdditionalSettings.Location = new System.Drawing.Point(6, 513);
			this.llAdditionalSettings.Name = "llAdditionalSettings";
			this.llAdditionalSettings.Size = new System.Drawing.Size(151, 13);
			this.llAdditionalSettings.TabIndex = 36;
			this.llAdditionalSettings.TabStop = true;
			this.llAdditionalSettings.Text = "Дополнительные настройки";
			this.llAdditionalSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAdditionalSettings_LinkClicked);
			// 
			// gbBasicSettings
			// 
			this.gbBasicSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbBasicSettings.Controls.Add(this.txtPassingScore);
			this.gbBasicSettings.Controls.Add(this.cbHasTimeLimit);
			this.gbBasicSettings.Controls.Add(this.lbMinute);
			this.gbBasicSettings.Controls.Add(this.nudTimeLimit);
			this.gbBasicSettings.Controls.Add(this.cbQuestionsNumber);
			this.gbBasicSettings.Controls.Add(this.cbPassagesNumber);
			this.gbBasicSettings.Controls.Add(this.nudPassagesNumber);
			this.gbBasicSettings.Controls.Add(this.nudQuestionsNumber);
			this.gbBasicSettings.Controls.Add(this.cbPassingScore);
			this.gbBasicSettings.Location = new System.Drawing.Point(6, 193);
			this.gbBasicSettings.Name = "gbBasicSettings";
			this.gbBasicSettings.Size = new System.Drawing.Size(409, 118);
			this.gbBasicSettings.TabIndex = 2;
			this.gbBasicSettings.TabStop = false;
			// 
			// txtPassingScore
			// 
			this.txtPassingScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassingScore.Enabled = false;
			this.txtPassingScore.Location = new System.Drawing.Point(237, 88);
			this.txtPassingScore.Name = "txtPassingScore";
			this.txtPassingScore.Size = new System.Drawing.Size(124, 20);
			this.txtPassingScore.TabIndex = 23;
			this.txtPassingScore.TextChanged += new System.EventHandler(this.nudPassingScore_TextChanged);
			// 
			// cbHasTimeLimit
			// 
			this.cbHasTimeLimit.AutoSize = true;
			this.cbHasTimeLimit.Location = new System.Drawing.Point(6, 19);
			this.cbHasTimeLimit.Name = "cbHasTimeLimit";
			this.cbHasTimeLimit.Size = new System.Drawing.Size(221, 17);
			this.cbHasTimeLimit.TabIndex = 3;
			this.cbHasTimeLimit.Text = "Ограничить время прохождения теста";
			this.cbHasTimeLimit.CheckedChanged += new System.EventHandler(this.cbHasTimeLimit_CheckedChanged);
			// 
			// lbMinute
			// 
			this.lbMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbMinute.AutoSize = true;
			this.lbMinute.Enabled = false;
			this.lbMinute.Location = new System.Drawing.Point(366, 21);
			this.lbMinute.Name = "lbMinute";
			this.lbMinute.Size = new System.Drawing.Size(37, 13);
			this.lbMinute.TabIndex = 22;
			this.lbMinute.Text = "минут";
			// 
			// nudTimeLimit
			// 
			this.nudTimeLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudTimeLimit.Enabled = false;
			this.nudTimeLimit.Location = new System.Drawing.Point(237, 19);
			this.nudTimeLimit.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.nudTimeLimit.Name = "nudTimeLimit";
			this.nudTimeLimit.Size = new System.Drawing.Size(124, 20);
			this.nudTimeLimit.TabIndex = 4;
			this.nudTimeLimit.ValueChanged += new System.EventHandler(this.nudTimeLimit_ValueChanged);
			// 
			// cbQuestionsNumber
			// 
			this.cbQuestionsNumber.AutoSize = true;
			this.cbQuestionsNumber.Location = new System.Drawing.Point(6, 67);
			this.cbQuestionsNumber.Name = "cbQuestionsNumber";
			this.cbQuestionsNumber.Size = new System.Drawing.Size(213, 17);
			this.cbQuestionsNumber.TabIndex = 7;
			this.cbQuestionsNumber.Text = "Установить кол-во вопросов в тесте";
			this.cbQuestionsNumber.CheckedChanged += new System.EventHandler(this.cbHasTimeLimit_CheckedChanged);
			// 
			// cbPassagesNumber
			// 
			this.cbPassagesNumber.AutoSize = true;
			this.cbPassagesNumber.Location = new System.Drawing.Point(6, 43);
			this.cbPassagesNumber.Name = "cbPassagesNumber";
			this.cbPassagesNumber.Size = new System.Drawing.Size(167, 17);
			this.cbPassagesNumber.TabIndex = 5;
			this.cbPassagesNumber.Text = "Ограничить кол-во попыток";
			this.cbPassagesNumber.CheckedChanged += new System.EventHandler(this.cbHasTimeLimit_CheckedChanged);
			// 
			// nudPassagesNumber
			// 
			this.nudPassagesNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudPassagesNumber.Enabled = false;
			this.nudPassagesNumber.Location = new System.Drawing.Point(237, 42);
			this.nudPassagesNumber.Name = "nudPassagesNumber";
			this.nudPassagesNumber.Size = new System.Drawing.Size(124, 20);
			this.nudPassagesNumber.TabIndex = 6;
			this.nudPassagesNumber.ValueChanged += new System.EventHandler(this.nudPassagesNumber_ValueChanged);
			// 
			// nudQuestionsNumber
			// 
			this.nudQuestionsNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nudQuestionsNumber.Enabled = false;
			this.nudQuestionsNumber.Location = new System.Drawing.Point(237, 66);
			this.nudQuestionsNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudQuestionsNumber.Name = "nudQuestionsNumber";
			this.nudQuestionsNumber.Size = new System.Drawing.Size(124, 20);
			this.nudQuestionsNumber.TabIndex = 8;
			this.nudQuestionsNumber.ValueChanged += new System.EventHandler(this.nudQuestionsNumber_ValueChanged);
			// 
			// cbPassingScore
			// 
			this.cbPassingScore.AutoSize = true;
			this.cbPassingScore.Location = new System.Drawing.Point(6, 90);
			this.cbPassingScore.Name = "cbPassingScore";
			this.cbPassingScore.Size = new System.Drawing.Size(170, 17);
			this.cbPassingScore.TabIndex = 9;
			this.cbPassingScore.Text = "Установить проходной Балл";
			this.cbPassingScore.CheckedChanged += new System.EventHandler(this.cbHasTimeLimit_CheckedChanged);
			// 
			// cbVariantsMode
			// 
			this.cbVariantsMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbVariantsMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbVariantsMode.FormattingEnabled = true;
			this.cbVariantsMode.Items.AddRange(new object[] {
            "Вопросы из тем перемешаны",
            "Последовательные темы"});
			this.cbVariantsMode.Location = new System.Drawing.Point(163, 313);
			this.cbVariantsMode.Name = "cbVariantsMode";
			this.cbVariantsMode.Size = new System.Drawing.Size(203, 21);
			this.cbVariantsMode.TabIndex = 11;
			this.cbVariantsMode.SelectedIndexChanged += new System.EventHandler(this.cbVariantsMode_SelectedIndexChanged);
			// 
			// lbVariantsMode
			// 
			this.lbVariantsMode.AutoSize = true;
			this.lbVariantsMode.Location = new System.Drawing.Point(3, 316);
			this.lbVariantsMode.Name = "lbVariantsMode";
			this.lbVariantsMode.Size = new System.Drawing.Size(154, 13);
			this.lbVariantsMode.TabIndex = 42;
			this.lbVariantsMode.Text = "Режим генерации вариантов";
			// 
			// cbShowRightAnswersCount
			// 
			this.cbShowRightAnswersCount.AutoSize = true;
			this.cbShowRightAnswersCount.Checked = true;
			this.cbShowRightAnswersCount.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowRightAnswersCount.Location = new System.Drawing.Point(6, 363);
			this.cbShowRightAnswersCount.Name = "cbShowRightAnswersCount";
			this.cbShowRightAnswersCount.Size = new System.Drawing.Size(341, 17);
			this.cbShowRightAnswersCount.TabIndex = 14;
			this.cbShowRightAnswersCount.Text = "Показывать кол-во верных ответов в процессе тестирования";
			this.cbShowRightAnswersCount.CheckedChanged += new System.EventHandler(this.cbShowRightAnswersCount_CheckedChanged);
			// 
			// cbShowTestResult
			// 
			this.cbShowTestResult.AutoSize = true;
			this.cbShowTestResult.Checked = true;
			this.cbShowTestResult.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowTestResult.Location = new System.Drawing.Point(193, 340);
			this.cbShowTestResult.Name = "cbShowTestResult";
			this.cbShowTestResult.Size = new System.Drawing.Size(224, 17);
			this.cbShowTestResult.TabIndex = 13;
			this.cbShowTestResult.Text = "Показывать результаты тестирования";
			this.cbShowTestResult.CheckedChanged += new System.EventHandler(this.cbShowTestResult_CheckedChanged);
			// 
			// cbAllowAdmitQuestions
			// 
			this.cbAllowAdmitQuestions.AutoSize = true;
			this.cbAllowAdmitQuestions.Checked = true;
			this.cbAllowAdmitQuestions.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbAllowAdmitQuestions.Location = new System.Drawing.Point(6, 340);
			this.cbAllowAdmitQuestions.Name = "cbAllowAdmitQuestions";
			this.cbAllowAdmitQuestions.Size = new System.Drawing.Size(190, 17);
			this.cbAllowAdmitQuestions.TabIndex = 12;
			this.cbAllowAdmitQuestions.Text = "Разрешить пропускать вопросы";
			this.cbAllowAdmitQuestions.CheckedChanged += new System.EventHandler(this.cbAllowAdmitQuestions_CheckedChanged);
			// 
			// gbTestActivity
			// 
			this.gbTestActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbTestActivity.Controls.Add(this.lbTimeEnd);
			this.gbTestActivity.Controls.Add(this.lbTimeStart);
			this.gbTestActivity.Controls.Add(this.cbIsLimitedActive);
			this.gbTestActivity.Controls.Add(this.dtpTimeEnd);
			this.gbTestActivity.Controls.Add(this.dtpTimeStart);
			this.gbTestActivity.Controls.Add(this.cbIsActive);
			this.gbTestActivity.Location = new System.Drawing.Point(6, 404);
			this.gbTestActivity.Name = "gbTestActivity";
			this.gbTestActivity.Size = new System.Drawing.Size(406, 106);
			this.gbTestActivity.TabIndex = 15;
			this.gbTestActivity.TabStop = false;
			this.gbTestActivity.Text = "Активность теста";
			// 
			// lbTimeEnd
			// 
			this.lbTimeEnd.AutoSize = true;
			this.lbTimeEnd.Location = new System.Drawing.Point(2, 83);
			this.lbTimeEnd.Name = "lbTimeEnd";
			this.lbTimeEnd.Size = new System.Drawing.Size(19, 13);
			this.lbTimeEnd.TabIndex = 23;
			this.lbTimeEnd.Text = "по";
			// 
			// lbTimeStart
			// 
			this.lbTimeStart.AutoSize = true;
			this.lbTimeStart.Location = new System.Drawing.Point(2, 54);
			this.lbTimeStart.Name = "lbTimeStart";
			this.lbTimeStart.Size = new System.Drawing.Size(13, 13);
			this.lbTimeStart.TabIndex = 22;
			this.lbTimeStart.Text = "с";
			// 
			// cbIsLimitedActive
			// 
			this.cbIsLimitedActive.AutoSize = true;
			this.cbIsLimitedActive.Location = new System.Drawing.Point(83, 19);
			this.cbIsLimitedActive.Name = "cbIsLimitedActive";
			this.cbIsLimitedActive.Size = new System.Drawing.Size(121, 17);
			this.cbIsLimitedActive.TabIndex = 17;
			this.cbIsLimitedActive.Text = "Временно активен";
			this.cbIsLimitedActive.CheckedChanged += new System.EventHandler(this.cbIsLimitedActive_CheckedChanged);
			// 
			// dtpTimeEnd
			// 
			this.dtpTimeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpTimeEnd.CustomFormat = "HH:mm; ddMMM.yyyy ";
			this.dtpTimeEnd.Enabled = false;
			this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeEnd.Location = new System.Drawing.Point(23, 79);
			this.dtpTimeEnd.Name = "dtpTimeEnd";
			this.dtpTimeEnd.Size = new System.Drawing.Size(377, 20);
			this.dtpTimeEnd.TabIndex = 19;
			this.dtpTimeEnd.ValueChanged += new System.EventHandler(this.dtpTimeEnd_ValueChanged);
			// 
			// dtpTimeStart
			// 
			this.dtpTimeStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpTimeStart.CustomFormat = "HH:mm; ddMMM.yyyy ";
			this.dtpTimeStart.Enabled = false;
			this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTimeStart.Location = new System.Drawing.Point(23, 50);
			this.dtpTimeStart.Name = "dtpTimeStart";
			this.dtpTimeStart.Size = new System.Drawing.Size(377, 20);
			this.dtpTimeStart.TabIndex = 18;
			this.dtpTimeStart.Value = new System.DateTime(2005, 8, 4, 0, 0, 0, 0);
			this.dtpTimeStart.ValueChanged += new System.EventHandler(this.dtpTimeStart_ValueChanged);
			// 
			// cbIsActive
			// 
			this.cbIsActive.AutoSize = true;
			this.cbIsActive.Location = new System.Drawing.Point(9, 19);
			this.cbIsActive.Name = "cbIsActive";
			this.cbIsActive.Size = new System.Drawing.Size(68, 17);
			this.cbIsActive.TabIndex = 16;
			this.cbIsActive.Text = "Активен";
			this.cbIsActive.CheckedChanged += new System.EventHandler(this.cbIsActive_CheckedChanged);
			// 
			// tbTestName
			// 
			this.tbTestName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTestName.Location = new System.Drawing.Point(72, 19);
			this.tbTestName.Name = "tbTestName";
			this.tbTestName.Size = new System.Drawing.Size(343, 20);
			this.tbTestName.TabIndex = 0;
			this.tbTestName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTestName_KeyPress);
			this.tbTestName.Leave += new System.EventHandler(this.tbTestName_Leave);
			// 
			// lbDescription
			// 
			this.lbDescription.AutoSize = true;
			this.lbDescription.Location = new System.Drawing.Point(6, 46);
			this.lbDescription.Name = "lbDescription";
			this.lbDescription.Size = new System.Drawing.Size(114, 13);
			this.lbDescription.TabIndex = 11;
			this.lbDescription.Text = "Руководство к тесту:";
			// 
			// tbDescription
			// 
			this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDescription.Location = new System.Drawing.Point(6, 68);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDescription.Size = new System.Drawing.Size(409, 119);
			this.tbDescription.TabIndex = 1;
			this.tbDescription.TextChanged += new System.EventHandler(this.tbDescription_TextChanged);
			// 
			// lbTestName
			// 
			this.lbTestName.AutoSize = true;
			this.lbTestName.Location = new System.Drawing.Point(6, 24);
			this.lbTestName.Name = "lbTestName";
			this.lbTestName.Size = new System.Drawing.Size(60, 13);
			this.lbTestName.TabIndex = 7;
			this.lbTestName.Text = "Название:";
			// 
			// TestSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbSettings);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(419, 502);
			this.Name = "TestSettings";
			this.Size = new System.Drawing.Size(419, 539);
			this.gbSettings.ResumeLayout(false);
			this.gbSettings.PerformLayout();
			this.gbBasicSettings.ResumeLayout(false);
			this.gbBasicSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudPassagesNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudQuestionsNumber)).EndInit();
			this.gbTestActivity.ResumeLayout(false);
			this.gbTestActivity.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.CheckBox cbShowRightAnswersCount;
        private System.Windows.Forms.CheckBox cbShowTestResult;
        private System.Windows.Forms.CheckBox cbAllowAdmitQuestions;
        private System.Windows.Forms.CheckBox cbPassingScore;
        private System.Windows.Forms.NumericUpDown nudQuestionsNumber;
        private System.Windows.Forms.CheckBox cbPassagesNumber;
        private System.Windows.Forms.NumericUpDown nudTimeLimit;
        private System.Windows.Forms.Label lbMinute;
        private System.Windows.Forms.GroupBox gbTestActivity;
        private System.Windows.Forms.Label lbTimeEnd;
        private System.Windows.Forms.Label lbTimeStart;
        private System.Windows.Forms.CheckBox cbIsLimitedActive;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.CheckBox cbHasTimeLimit;
        private System.Windows.Forms.TextBox tbTestName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbTestName;
        private System.Windows.Forms.CheckBox cbQuestionsNumber;
        private System.Windows.Forms.NumericUpDown nudPassagesNumber;
        private System.Windows.Forms.ComboBox cbVariantsMode;
        private System.Windows.Forms.Label lbVariantsMode;
        private System.Windows.Forms.GroupBox gbBasicSettings;
        private System.Windows.Forms.LinkLabel llAdditionalSettings;
        private System.Windows.Forms.CheckBox cbShowDetailsTestResults;
        private System.Windows.Forms.TextBox txtPassingScore;

    }
}
