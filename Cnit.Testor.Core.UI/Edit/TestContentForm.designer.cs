namespace Cnit.Testor.Core.UI.Edit
{
    partial class TestContentForm
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
			  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestContentForm));
			  this.toolStrip = new System.Windows.Forms.ToolStrip();
			  this.tsbBackTest = new System.Windows.Forms.ToolStripButton();
			  this.tsbForwardTest = new System.Windows.Forms.ToolStripButton();
			  this.tscbTests = new System.Windows.Forms.ToolStripComboBox();
			  this.tslQuestCount = new System.Windows.Forms.ToolStripLabel();
			  this.tsbUpdateTest = new System.Windows.Forms.ToolStripButton();
			  this.tsbOpenFile = new System.Windows.Forms.ToolStripButton();
			  this.tsbTools = new System.Windows.Forms.ToolStripSplitButton();
			  this.tsmClearBR = new System.Windows.Forms.ToolStripMenuItem();
			  this.statusStrip = new System.Windows.Forms.StatusStrip();
			  this.dataGridView1 = new System.Windows.Forms.DataGridView();
			  this.bindingSourceQuest = new System.Windows.Forms.BindingSource(this.components);
			  this.bindingSourceFKQuest = new System.Windows.Forms.BindingSource(this.components);
			  this.panel4 = new System.Windows.Forms.Panel();
			  this.dgwFK = new System.Windows.Forms.DataGridView();
			  this.panel = new System.Windows.Forms.Panel();
			  this.panelWeb = new System.Windows.Forms.Panel();
			  this.webBrowserQuestion = new System.Windows.Forms.WebBrowser();
			  this.tsQuestion = new System.Windows.Forms.ToolStrip();
			  this.toolStripLabelQ = new System.Windows.Forms.ToolStripLabel();
			  this.tscbMark = new System.Windows.Forms.ToolStripComboBox();
			  this.splitter1 = new System.Windows.Forms.Splitter();
			  this.panelHTML = new System.Windows.Forms.Panel();
			  this.gbAnswers = new System.Windows.Forms.GroupBox();
			  this.gbQuestions = new System.Windows.Forms.GroupBox();
			  this.panel3 = new System.Windows.Forms.Panel();
			  this.dgwQuest = new System.Windows.Forms.DataGridView();
			  this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.rtfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.istrueDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			  this.htmlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			  this.dataSetMainTest = new Cnit.Testor.Core.TestorData();
			  this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.questrtfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.guesthtmlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			  this.toolStrip.SuspendLayout();
			  ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize) (this.bindingSourceQuest)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize) (this.bindingSourceFKQuest)).BeginInit();
			  this.panel4.SuspendLayout();
			  ((System.ComponentModel.ISupportInitialize) (this.dgwFK)).BeginInit();
			  this.panel.SuspendLayout();
			  this.panelWeb.SuspendLayout();
			  this.tsQuestion.SuspendLayout();
			  this.panelHTML.SuspendLayout();
			  this.gbAnswers.SuspendLayout();
			  this.gbQuestions.SuspendLayout();
			  this.panel3.SuspendLayout();
			  ((System.ComponentModel.ISupportInitialize) (this.dgwQuest)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize) (this.bindingSource)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize) (this.dataSetMainTest)).BeginInit();
			  this.SuspendLayout();
			  // 
			  // toolStrip
			  // 
			  this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBackTest,
            this.tsbForwardTest,
            this.tscbTests,
            this.tslQuestCount,
            this.tsbUpdateTest,
            this.tsbOpenFile,
            this.tsbTools});
			  this.toolStrip.Location = new System.Drawing.Point(0, 0);
			  this.toolStrip.Name = "toolStrip";
			  this.toolStrip.Size = new System.Drawing.Size(1038, 25);
			  this.toolStrip.TabIndex = 0;
			  this.toolStrip.Text = "toolStrip1";
			  // 
			  // tsbBackTest
			  // 
			  this.tsbBackTest.Image = ((System.Drawing.Image) (resources.GetObject("tsbBackTest.Image")));
			  this.tsbBackTest.ImageTransparentColor = System.Drawing.Color.Magenta;
			  this.tsbBackTest.Name = "tsbBackTest";
			  this.tsbBackTest.Size = new System.Drawing.Size(126, 22);
			  this.tsbBackTest.Text = "Предыдущий тест";
			  this.tsbBackTest.Click += new System.EventHandler(this.tsbBack_Click);
			  // 
			  // tsbForwardTest
			  // 
			  this.tsbForwardTest.Image = ((System.Drawing.Image) (resources.GetObject("tsbForwardTest.Image")));
			  this.tsbForwardTest.ImageTransparentColor = System.Drawing.Color.Magenta;
			  this.tsbForwardTest.Name = "tsbForwardTest";
			  this.tsbForwardTest.Size = new System.Drawing.Size(120, 22);
			  this.tsbForwardTest.Text = "Следующий тест";
			  this.tsbForwardTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			  this.tsbForwardTest.Click += new System.EventHandler(this.tsbForward_Click);
			  // 
			  // tscbTests
			  // 
			  this.tscbTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			  this.tscbTests.Name = "tscbTests";
			  this.tscbTests.Size = new System.Drawing.Size(350, 25);
			  this.tscbTests.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxTests_SelectedIndexChanged);
			  // 
			  // tslQuestCount
			  // 
			  this.tslQuestCount.Name = "tslQuestCount";
			  this.tslQuestCount.Size = new System.Drawing.Size(67, 22);
			  this.tslQuestCount.Text = "Вопросов: ";
			  // 
			  // tsbUpdateTest
			  // 
			  this.tsbUpdateTest.Image = global::Cnit.Testor.Core.UI.Properties.Resources.star_half;
			  this.tsbUpdateTest.ImageTransparentColor = System.Drawing.Color.Magenta;
			  this.tsbUpdateTest.Name = "tsbUpdateTest";
			  this.tsbUpdateTest.Size = new System.Drawing.Size(125, 22);
			  this.tsbUpdateTest.Text = "Переконвертация";
			  this.tsbUpdateTest.Click += new System.EventHandler(this.tsbUpdateTest_Click);
			  // 
			  // tsbOpenFile
			  // 
			  this.tsbOpenFile.Image = global::Cnit.Testor.Core.UI.Properties.Resources.file_edit;
			  this.tsbOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			  this.tsbOpenFile.Name = "tsbOpenFile";
			  this.tsbOpenFile.Size = new System.Drawing.Size(115, 22);
			  this.tsbOpenFile.Text = "Открыть в Word";
			  this.tsbOpenFile.Click += new System.EventHandler(this.tsbOpenFile_Click);
			  // 
			  // tsbTools
			  // 
			  this.tsbTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmClearBR});
			  this.tsbTools.Image = global::Cnit.Testor.Core.UI.Properties.Resources.application;
			  this.tsbTools.ImageTransparentColor = System.Drawing.Color.Magenta;
			  this.tsbTools.Name = "tsbTools";
			  this.tsbTools.Size = new System.Drawing.Size(86, 22);
			  this.tsbTools.Text = "Утилиты";
			  // 
			  // tsmClearBR
			  // 
			  this.tsmClearBR.Name = "tsmClearBR";
			  this.tsmClearBR.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
			  this.tsmClearBR.Size = new System.Drawing.Size(217, 22);
			  this.tsmClearBR.Text = "Очистить пробелы";
			  this.tsmClearBR.Click += new System.EventHandler(this.tsmClearBR_Click);
			  // 
			  // statusStrip
			  // 
			  this.statusStrip.Location = new System.Drawing.Point(0, 542);
			  this.statusStrip.Name = "statusStrip";
			  this.statusStrip.Size = new System.Drawing.Size(1038, 22);
			  this.statusStrip.TabIndex = 1;
			  this.statusStrip.Text = "statusStrip1";
			  // 
			  // dataGridView1
			  // 
			  this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			  this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.dataGridView1.Location = new System.Drawing.Point(0, 25);
			  this.dataGridView1.Name = "dataGridView1";
			  this.dataGridView1.Size = new System.Drawing.Size(1038, 517);
			  this.dataGridView1.TabIndex = 2;
			  // 
			  // bindingSourceQuest
			  // 
			  this.bindingSourceQuest.AllowNew = false;
			  this.bindingSourceQuest.DataMember = "CoreQuestions";
			  this.bindingSourceQuest.DataSource = this.bindingSource;
			  this.bindingSourceQuest.CurrentItemChanged += new System.EventHandler(this.bindingSourceQuest_CurrentItemChanged);
			  // 
			  // bindingSourceFKQuest
			  // 
			  this.bindingSourceFKQuest.DataMember = "FK_CoreAnswers_CoreQuestions";
			  this.bindingSourceFKQuest.DataSource = this.bindingSourceQuest;
			  // 
			  // panel4
			  // 
			  this.panel4.Controls.Add(this.dgwFK);
			  this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.panel4.Location = new System.Drawing.Point(3, 16);
			  this.panel4.Name = "panel4";
			  this.panel4.Size = new System.Drawing.Size(583, 310);
			  this.panel4.TabIndex = 7;
			  // 
			  // dgwFK
			  // 
			  this.dgwFK.AllowUserToAddRows = false;
			  this.dgwFK.AllowUserToDeleteRows = false;
			  this.dgwFK.AutoGenerateColumns = false;
			  this.dgwFK.BorderStyle = System.Windows.Forms.BorderStyle.None;
			  this.dgwFK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			  this.dgwFK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.rtfDataGridViewTextBoxColumn,
            this.istrueDataGridViewCheckBoxColumn,
            this.htmlDataGridViewTextBoxColumn});
			  this.dgwFK.DataSource = this.bindingSourceFKQuest;
			  this.dgwFK.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.dgwFK.Location = new System.Drawing.Point(0, 0);
			  this.dgwFK.MultiSelect = false;
			  this.dgwFK.Name = "dgwFK";
			  this.dgwFK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			  this.dgwFK.Size = new System.Drawing.Size(583, 310);
			  this.dgwFK.TabIndex = 2;
			  this.dgwFK.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwFK_CellValueChanged);
			  this.dgwFK.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwFK_CellEndEdit);
			  // 
			  // panel
			  // 
			  this.panel.Controls.Add(this.panelWeb);
			  this.panel.Controls.Add(this.tsQuestion);
			  this.panel.Controls.Add(this.splitter1);
			  this.panel.Controls.Add(this.panelHTML);
			  this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.panel.Location = new System.Drawing.Point(0, 25);
			  this.panel.Name = "panel";
			  this.panel.Size = new System.Drawing.Size(1038, 517);
			  this.panel.TabIndex = 3;
			  // 
			  // panelWeb
			  // 
			  this.panelWeb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			  this.panelWeb.Controls.Add(this.webBrowserQuestion);
			  this.panelWeb.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.panelWeb.Location = new System.Drawing.Point(0, 357);
			  this.panelWeb.Name = "panelWeb";
			  this.panelWeb.Size = new System.Drawing.Size(1038, 160);
			  this.panelWeb.TabIndex = 4;
			  // 
			  // webBrowserQuestion
			  // 
			  this.webBrowserQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.webBrowserQuestion.Location = new System.Drawing.Point(0, 0);
			  this.webBrowserQuestion.MinimumSize = new System.Drawing.Size(20, 20);
			  this.webBrowserQuestion.Name = "webBrowserQuestion";
			  this.webBrowserQuestion.Size = new System.Drawing.Size(1034, 156);
			  this.webBrowserQuestion.TabIndex = 0;
			  // 
			  // tsQuestion
			  // 
			  this.tsQuestion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelQ,
            this.tscbMark});
			  this.tsQuestion.Location = new System.Drawing.Point(0, 332);
			  this.tsQuestion.Name = "tsQuestion";
			  this.tsQuestion.Size = new System.Drawing.Size(1038, 25);
			  this.tsQuestion.TabIndex = 2;
			  this.tsQuestion.Text = "toolStrip1";
			  // 
			  // toolStripLabelQ
			  // 
			  this.toolStripLabelQ.Name = "toolStripLabelQ";
			  this.toolStripLabelQ.Size = new System.Drawing.Size(51, 22);
			  this.toolStripLabelQ.Text = "Вопрос:";
			  // 
			  // tscbMark
			  // 
			  this.tscbMark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			  this.tscbMark.Items.AddRange(new object[] {
            "1 Балл",
            "2 Балла",
            "3 Балла",
            "4 Балла",
            "5 Баллов"});
			  this.tscbMark.Name = "tscbMark";
			  this.tscbMark.Size = new System.Drawing.Size(121, 25);
			  this.tscbMark.SelectedIndexChanged += new System.EventHandler(this.tscbMark_SelectedIndexChanged);
			  // 
			  // splitter1
			  // 
			  this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			  this.splitter1.Location = new System.Drawing.Point(0, 329);
			  this.splitter1.Name = "splitter1";
			  this.splitter1.Size = new System.Drawing.Size(1038, 3);
			  this.splitter1.TabIndex = 6;
			  this.splitter1.TabStop = false;
			  // 
			  // panelHTML
			  // 
			  this.panelHTML.Controls.Add(this.gbAnswers);
			  this.panelHTML.Controls.Add(this.gbQuestions);
			  this.panelHTML.Dock = System.Windows.Forms.DockStyle.Top;
			  this.panelHTML.Location = new System.Drawing.Point(0, 0);
			  this.panelHTML.Name = "panelHTML";
			  this.panelHTML.Size = new System.Drawing.Size(1038, 329);
			  this.panelHTML.TabIndex = 5;
			  // 
			  // gbAnswers
			  // 
			  this.gbAnswers.Controls.Add(this.panel4);
			  this.gbAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.gbAnswers.Location = new System.Drawing.Point(449, 0);
			  this.gbAnswers.Name = "gbAnswers";
			  this.gbAnswers.Size = new System.Drawing.Size(589, 329);
			  this.gbAnswers.TabIndex = 1;
			  this.gbAnswers.TabStop = false;
			  this.gbAnswers.Text = "Ответы";
			  // 
			  // gbQuestions
			  // 
			  this.gbQuestions.Controls.Add(this.panel3);
			  this.gbQuestions.Dock = System.Windows.Forms.DockStyle.Left;
			  this.gbQuestions.Location = new System.Drawing.Point(0, 0);
			  this.gbQuestions.Name = "gbQuestions";
			  this.gbQuestions.Size = new System.Drawing.Size(449, 329);
			  this.gbQuestions.TabIndex = 2;
			  this.gbQuestions.TabStop = false;
			  this.gbQuestions.Text = "Вопросы";
			  // 
			  // panel3
			  // 
			  this.panel3.Controls.Add(this.dgwQuest);
			  this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.panel3.Location = new System.Drawing.Point(3, 16);
			  this.panel3.Name = "panel3";
			  this.panel3.Size = new System.Drawing.Size(443, 310);
			  this.panel3.TabIndex = 5;
			  // 
			  // dgwQuest
			  // 
			  this.dgwQuest.AllowUserToAddRows = false;
			  this.dgwQuest.AllowUserToDeleteRows = false;
			  this.dgwQuest.AutoGenerateColumns = false;
			  this.dgwQuest.BorderStyle = System.Windows.Forms.BorderStyle.None;
			  this.dgwQuest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			  this.dgwQuest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.questrtfDataGridViewTextBoxColumn,
            this.guesthtmlDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn});
			  this.dgwQuest.DataSource = this.bindingSourceQuest;
			  this.dgwQuest.Dock = System.Windows.Forms.DockStyle.Fill;
			  this.dgwQuest.Location = new System.Drawing.Point(0, 0);
			  this.dgwQuest.MultiSelect = false;
			  this.dgwQuest.Name = "dgwQuest";
			  this.dgwQuest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			  this.dgwQuest.Size = new System.Drawing.Size(443, 310);
			  this.dgwQuest.TabIndex = 1;
			  this.dgwQuest.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwFK_CellValueChanged);
			  this.dgwQuest.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwFK_CellEndEdit);
			  // 
			  // idDataGridViewTextBoxColumn1
			  // 
			  this.idDataGridViewTextBoxColumn1.DataPropertyName = "AnswerId";
			  this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
			  this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
			  this.idDataGridViewTextBoxColumn1.ReadOnly = true;
			  this.idDataGridViewTextBoxColumn1.Visible = false;
			  this.idDataGridViewTextBoxColumn1.Width = 43;
			  // 
			  // rtfDataGridViewTextBoxColumn
			  // 
			  this.rtfDataGridViewTextBoxColumn.DataPropertyName = "AnswerRtf";
			  this.rtfDataGridViewTextBoxColumn.HeaderText = "rtf";
			  this.rtfDataGridViewTextBoxColumn.Name = "rtfDataGridViewTextBoxColumn";
			  this.rtfDataGridViewTextBoxColumn.Visible = false;
			  // 
			  // istrueDataGridViewCheckBoxColumn
			  // 
			  this.istrueDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			  this.istrueDataGridViewCheckBoxColumn.DataPropertyName = "IsTrue";
			  this.istrueDataGridViewCheckBoxColumn.HeaderText = "Верно?";
			  this.istrueDataGridViewCheckBoxColumn.Name = "istrueDataGridViewCheckBoxColumn";
			  this.istrueDataGridViewCheckBoxColumn.Width = 50;
			  // 
			  // htmlDataGridViewTextBoxColumn
			  // 
			  this.htmlDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			  this.htmlDataGridViewTextBoxColumn.DataPropertyName = "Answer";
			  this.htmlDataGridViewTextBoxColumn.HeaderText = "Ответ";
			  this.htmlDataGridViewTextBoxColumn.Name = "htmlDataGridViewTextBoxColumn";
			  // 
			  // bindingSource
			  // 
			  this.bindingSource.AllowNew = false;
			  this.bindingSource.DataSource = this.dataSetMainTest;
			  this.bindingSource.Position = 0;
			  // 
			  // dataSetMainTest
			  // 
			  this.dataSetMainTest.DataSetName = "TestorData";
			  this.dataSetMainTest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			  // 
			  // idDataGridViewTextBoxColumn
			  // 
			  this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			  this.idDataGridViewTextBoxColumn.DataPropertyName = "QuestionId";
			  this.idDataGridViewTextBoxColumn.HeaderText = "№";
			  this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			  this.idDataGridViewTextBoxColumn.ReadOnly = true;
			  this.idDataGridViewTextBoxColumn.Width = 43;
			  // 
			  // questrtfDataGridViewTextBoxColumn
			  // 
			  this.questrtfDataGridViewTextBoxColumn.DataPropertyName = "QuestionRtf";
			  this.questrtfDataGridViewTextBoxColumn.HeaderText = "quest_rtf";
			  this.questrtfDataGridViewTextBoxColumn.Name = "questrtfDataGridViewTextBoxColumn";
			  this.questrtfDataGridViewTextBoxColumn.ReadOnly = true;
			  this.questrtfDataGridViewTextBoxColumn.Visible = false;
			  // 
			  // guesthtmlDataGridViewTextBoxColumn
			  // 
			  this.guesthtmlDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			  this.guesthtmlDataGridViewTextBoxColumn.DataPropertyName = "Question";
			  this.guesthtmlDataGridViewTextBoxColumn.HeaderText = "Вопрос";
			  this.guesthtmlDataGridViewTextBoxColumn.Name = "guesthtmlDataGridViewTextBoxColumn";
			  // 
			  // typeDataGridViewTextBoxColumn
			  // 
			  this.typeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			  this.typeDataGridViewTextBoxColumn.DataPropertyName = "QuestionType";
			  this.typeDataGridViewTextBoxColumn.HeaderText = "Тип";
			  this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			  this.typeDataGridViewTextBoxColumn.ReadOnly = true;
			  this.typeDataGridViewTextBoxColumn.Width = 30;
			  // 
			  // TestContentForm
			  // 
			  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			  this.ClientSize = new System.Drawing.Size(1038, 564);
			  this.Controls.Add(this.panel);
			  this.Controls.Add(this.dataGridView1);
			  this.Controls.Add(this.statusStrip);
			  this.Controls.Add(this.toolStrip);
			  this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			  this.MinimizeBox = false;
			  this.Name = "TestContentForm";
			  this.ShowInTaskbar = false;
			  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			  this.Text = "Просмотр тестов";
			  this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			  this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestContentForm_FormClosing);
			  this.toolStrip.ResumeLayout(false);
			  this.toolStrip.PerformLayout();
			  ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
			  ((System.ComponentModel.ISupportInitialize) (this.bindingSourceQuest)).EndInit();
			  ((System.ComponentModel.ISupportInitialize) (this.bindingSourceFKQuest)).EndInit();
			  this.panel4.ResumeLayout(false);
			  ((System.ComponentModel.ISupportInitialize) (this.dgwFK)).EndInit();
			  this.panel.ResumeLayout(false);
			  this.panel.PerformLayout();
			  this.panelWeb.ResumeLayout(false);
			  this.tsQuestion.ResumeLayout(false);
			  this.tsQuestion.PerformLayout();
			  this.panelHTML.ResumeLayout(false);
			  this.gbAnswers.ResumeLayout(false);
			  this.gbQuestions.ResumeLayout(false);
			  this.panel3.ResumeLayout(false);
			  ((System.ComponentModel.ISupportInitialize) (this.dgwQuest)).EndInit();
			  ((System.ComponentModel.ISupportInitialize) (this.bindingSource)).EndInit();
			  ((System.ComponentModel.ISupportInitialize) (this.dataSetMainTest)).EndInit();
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton tsbBackTest;
        private System.Windows.Forms.ToolStripButton tsbForwardTest;
        private System.Windows.Forms.ToolStripComboBox tscbTests;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSourceQuest;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource bindingSourceFKQuest;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox gbAnswers;
        private System.Windows.Forms.GroupBox gbQuestions;
        private TestorData dataSetMainTest;
        private System.Windows.Forms.ToolStripButton tsbUpdateTest;
        private System.Windows.Forms.ToolStripLabel tslQuestCount;
        private System.Windows.Forms.ToolStripButton tsbOpenFile;
        private System.Windows.Forms.ToolStripSplitButton tsbTools;
        private System.Windows.Forms.ToolStripMenuItem tsmClearBR;
        private System.Windows.Forms.WebBrowser webBrowserQuestion;
        private System.Windows.Forms.ToolStrip tsQuestion;
        private System.Windows.Forms.ToolStripLabel toolStripLabelQ;
        private System.Windows.Forms.ToolStripComboBox tscbMark;
        private System.Windows.Forms.Panel panelWeb;
        private System.Windows.Forms.DataGridView dgwFK;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rtfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn istrueDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn htmlDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panelHTML;
        private System.Windows.Forms.Panel panel3;
		  private System.Windows.Forms.DataGridView dgwQuest;
        private System.Windows.Forms.Splitter splitter1;
		  private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		  private System.Windows.Forms.DataGridViewTextBoxColumn questrtfDataGridViewTextBoxColumn;
		  private System.Windows.Forms.DataGridViewTextBoxColumn guesthtmlDataGridViewTextBoxColumn;
		  private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    }
}