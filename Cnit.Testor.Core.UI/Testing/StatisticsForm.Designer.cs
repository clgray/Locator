namespace Cnit.Testor.Core.UI
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxAutoupdate = new System.Windows.Forms.ComboBox();
            this.groupBoxStudent = new System.Windows.Forms.GroupBox();
            this.linkLabelSelectStudent = new System.Windows.Forms.LinkLabel();
            this.textBoxStudent = new System.Windows.Forms.TextBox();
            this.groupBoxGroup = new System.Windows.Forms.GroupBox();
            this.linkLabelTest = new System.Windows.Forms.LinkLabel();
            this.linkLabelGroup = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxDate = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBoxMarks = new System.Windows.Forms.GroupBox();
            this.mtb3 = new System.Windows.Forms.NumericUpDown();
            this.mtb4 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.mtb5 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxPass = new System.Windows.Forms.GroupBox();
            this.mtbPass = new System.Windows.Forms.NumericUpDown();
            this.labelScore = new System.Windows.Forms.Label();
            this.buttonAppeal = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelClient = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestSessionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassingScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxStudent.SuspendLayout();
            this.groupBoxGroup.SuspendLayout();
            this.groupBoxDate.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBoxMarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtb5)).BeginInit();
            this.groupBoxPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtbPass)).BeginInit();
            this.panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.groupBox2);
            this.panelTop.Controls.Add(this.groupBoxStudent);
            this.panelTop.Controls.Add(this.groupBoxGroup);
            this.panelTop.Controls.Add(this.groupBoxDate);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 80);
            this.panelTop.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxAutoupdate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(675, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 80);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Автообновление";
            // 
            // comboBoxAutoupdate
            // 
            this.comboBoxAutoupdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutoupdate.FormattingEnabled = true;
            this.comboBoxAutoupdate.Items.AddRange(new object[] {
            "Не автообновлять",
            "Обновлять каждые 10 секунд",
            "Обновлять каждые 30 секунд",
            "Обновлять каждые 60 секунд"});
            this.comboBoxAutoupdate.Location = new System.Drawing.Point(6, 22);
            this.comboBoxAutoupdate.Name = "comboBoxAutoupdate";
            this.comboBoxAutoupdate.Size = new System.Drawing.Size(210, 21);
            this.comboBoxAutoupdate.TabIndex = 0;
            this.comboBoxAutoupdate.SelectedIndexChanged += new System.EventHandler(this.comboBoxAutoupdate_SelectedIndexChanged);
            // 
            // groupBoxStudent
            // 
            this.groupBoxStudent.Controls.Add(this.linkLabelSelectStudent);
            this.groupBoxStudent.Controls.Add(this.textBoxStudent);
            this.groupBoxStudent.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxStudent.Location = new System.Drawing.Point(477, 0);
            this.groupBoxStudent.Name = "groupBoxStudent";
            this.groupBoxStudent.Size = new System.Drawing.Size(198, 80);
            this.groupBoxStudent.TabIndex = 2;
            this.groupBoxStudent.TabStop = false;
            this.groupBoxStudent.Text = "Фильтрация по студенту";
            // 
            // linkLabelSelectStudent
            // 
            this.linkLabelSelectStudent.AutoSize = true;
            this.linkLabelSelectStudent.Location = new System.Drawing.Point(3, 49);
            this.linkLabelSelectStudent.Name = "linkLabelSelectStudent";
            this.linkLabelSelectStudent.Size = new System.Drawing.Size(99, 13);
            this.linkLabelSelectStudent.TabIndex = 1;
            this.linkLabelSelectStudent.TabStop = true;
            this.linkLabelSelectStudent.Text = "Выбрать студента";
            this.linkLabelSelectStudent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSelectStudent_LinkClicked);
            // 
            // textBoxStudent
            // 
            this.textBoxStudent.Location = new System.Drawing.Point(6, 23);
            this.textBoxStudent.Name = "textBoxStudent";
            this.textBoxStudent.ReadOnly = true;
            this.textBoxStudent.Size = new System.Drawing.Size(186, 20);
            this.textBoxStudent.TabIndex = 0;
            // 
            // groupBoxGroup
            // 
            this.groupBoxGroup.Controls.Add(this.linkLabelTest);
            this.groupBoxGroup.Controls.Add(this.linkLabelGroup);
            this.groupBoxGroup.Controls.Add(this.label3);
            this.groupBoxGroup.Controls.Add(this.label5);
            this.groupBoxGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxGroup.Location = new System.Drawing.Point(263, 0);
            this.groupBoxGroup.Name = "groupBoxGroup";
            this.groupBoxGroup.Size = new System.Drawing.Size(214, 80);
            this.groupBoxGroup.TabIndex = 1;
            this.groupBoxGroup.TabStop = false;
            this.groupBoxGroup.Text = "Фильрация по группе и тесту";
            // 
            // linkLabelTest
            // 
            this.linkLabelTest.AutoSize = true;
            this.linkLabelTest.Location = new System.Drawing.Point(57, 49);
            this.linkLabelTest.Name = "linkLabelTest";
            this.linkLabelTest.Size = new System.Drawing.Size(60, 13);
            this.linkLabelTest.TabIndex = 3;
            this.linkLabelTest.TabStop = true;
            this.linkLabelTest.Text = "не выбран";
            this.linkLabelTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTest_LinkClicked);
            // 
            // linkLabelGroup
            // 
            this.linkLabelGroup.AutoSize = true;
            this.linkLabelGroup.Location = new System.Drawing.Point(57, 23);
            this.linkLabelGroup.Name = "linkLabelGroup";
            this.linkLabelGroup.Size = new System.Drawing.Size(66, 13);
            this.linkLabelGroup.TabIndex = 2;
            this.linkLabelGroup.TabStop = true;
            this.linkLabelGroup.Text = "не выбрана";
            this.linkLabelGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGroup_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Тест:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Группа:";
            // 
            // groupBoxDate
            // 
            this.groupBoxDate.Controls.Add(this.label2);
            this.groupBoxDate.Controls.Add(this.label1);
            this.groupBoxDate.Controls.Add(this.dateTimePickerEnd);
            this.groupBoxDate.Controls.Add(this.dateTimePickerStart);
            this.groupBoxDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxDate.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDate.Name = "groupBoxDate";
            this.groupBoxDate.Size = new System.Drawing.Size(263, 80);
            this.groupBoxDate.TabIndex = 0;
            this.groupBoxDate.TabStop = false;
            this.groupBoxDate.Text = "Фильтрация по дате тестирования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "c";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd MMMM yyyy HH:mm";
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(31, 49);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowUpDown = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(222, 20);
            this.dateTimePickerEnd.TabIndex = 1;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "dd MMMM yyyy HH:mm";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(31, 23);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(222, 20);
            this.dateTimePickerStart.TabIndex = 0;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBottom.Controls.Add(this.groupBoxMarks);
            this.panelBottom.Controls.Add(this.groupBoxPass);
            this.panelBottom.Controls.Add(this.buttonAppeal);
            this.panelBottom.Controls.Add(this.buttonPrint);
            this.panelBottom.Controls.Add(this.buttonOK);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 432);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 61);
            this.panelBottom.TabIndex = 0;
            // 
            // groupBoxMarks
            // 
            this.groupBoxMarks.Controls.Add(this.mtb3);
            this.groupBoxMarks.Controls.Add(this.mtb4);
            this.groupBoxMarks.Controls.Add(this.label7);
            this.groupBoxMarks.Controls.Add(this.mtb5);
            this.groupBoxMarks.Controls.Add(this.label6);
            this.groupBoxMarks.Controls.Add(this.label4);
            this.groupBoxMarks.Location = new System.Drawing.Point(417, 6);
            this.groupBoxMarks.Name = "groupBoxMarks";
            this.groupBoxMarks.Size = new System.Drawing.Size(277, 44);
            this.groupBoxMarks.TabIndex = 8;
            this.groupBoxMarks.TabStop = false;
            this.groupBoxMarks.Text = "Оценки";
            // 
            // mtb3
            // 
            this.mtb3.Location = new System.Drawing.Point(208, 16);
            this.mtb3.Name = "mtb3";
            this.mtb3.Size = new System.Drawing.Size(63, 20);
            this.mtb3.TabIndex = 3;
            // 
            // mtb4
            // 
            this.mtb4.Location = new System.Drawing.Point(118, 16);
            this.mtb4.Name = "mtb4";
            this.mtb4.Size = new System.Drawing.Size(62, 20);
            this.mtb4.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "3:";
            // 
            // mtb5
            // 
            this.mtb5.Location = new System.Drawing.Point(28, 16);
            this.mtb5.Name = "mtb5";
            this.mtb5.Size = new System.Drawing.Size(62, 20);
            this.mtb5.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "4:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "5:";
            // 
            // groupBoxPass
            // 
            this.groupBoxPass.Controls.Add(this.mtbPass);
            this.groupBoxPass.Controls.Add(this.labelScore);
            this.groupBoxPass.Location = new System.Drawing.Point(281, 6);
            this.groupBoxPass.Name = "groupBoxPass";
            this.groupBoxPass.Size = new System.Drawing.Size(130, 44);
            this.groupBoxPass.TabIndex = 7;
            this.groupBoxPass.TabStop = false;
            this.groupBoxPass.Text = "Зачёт";
            // 
            // mtbPass
            // 
            this.mtbPass.Location = new System.Drawing.Point(6, 16);
            this.mtbPass.Name = "mtbPass";
            this.mtbPass.Size = new System.Drawing.Size(69, 20);
            this.mtbPass.TabIndex = 1;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(81, 18);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(43, 13);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Баллов";
            // 
            // buttonAppeal
            // 
            this.buttonAppeal.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAppeal.Enabled = false;
            this.buttonAppeal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAppeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAppeal.Location = new System.Drawing.Point(7, 6);
            this.buttonAppeal.Name = "buttonAppeal";
            this.buttonAppeal.Size = new System.Drawing.Size(131, 44);
            this.buttonAppeal.TabIndex = 5;
            this.buttonAppeal.Text = "Апелляция ";
            this.buttonAppeal.UseVisualStyleBackColor = true;
            this.buttonAppeal.Click += new System.EventHandler(this.buttonAppeal_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonPrint.Enabled = false;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPrint.Location = new System.Drawing.Point(144, 6);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(131, 44);
            this.buttonPrint.TabIndex = 6;
            this.buttonPrint.Text = "Печать";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(755, 6);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(131, 44);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "Закрыть";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelClient.Controls.Add(this.dataGridView);
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelClient.Location = new System.Drawing.Point(0, 80);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(900, 352);
            this.panelClient.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.LastName,
            this.TestSessionId,
            this.UserId,
            this.TestId,
            this.FirstName,
            this.SecondName,
            this.GroupName,
            this.TestName,
            this.StudNumber,
            this.TestTime,
            this.StartTime,
            this.MaxScore,
            this.PassingScore,
            this.Score});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(896, 348);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.DataPropertyName = "RowNumber";
            this.ColumnNumber.HeaderText = "№";
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            this.ColumnNumber.Width = 40;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LastName.DataPropertyName = "LastName";
            dataGridViewCellStyle1.Format = "hh:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.LastName.DefaultCellStyle = dataGridViewCellStyle1;
            this.LastName.HeaderText = "Фамилия";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 81;
            // 
            // TestSessionId
            // 
            this.TestSessionId.DataPropertyName = "TestSessionId";
            this.TestSessionId.HeaderText = "TestSessionId";
            this.TestSessionId.Name = "TestSessionId";
            this.TestSessionId.ReadOnly = true;
            this.TestSessionId.Visible = false;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            // 
            // TestId
            // 
            this.TestId.DataPropertyName = "TestId";
            this.TestId.HeaderText = "TestId";
            this.TestId.Name = "TestId";
            this.TestId.ReadOnly = true;
            this.TestId.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "Имя";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 54;
            // 
            // SecondName
            // 
            this.SecondName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SecondName.DataPropertyName = "SecondName";
            this.SecondName.HeaderText = "Отчество";
            this.SecondName.Name = "SecondName";
            this.SecondName.ReadOnly = true;
            this.SecondName.Width = 79;
            // 
            // GroupName
            // 
            this.GroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Группа";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 67;
            // 
            // TestName
            // 
            this.TestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TestName.DataPropertyName = "TestName";
            this.TestName.HeaderText = "Тест";
            this.TestName.MinimumWidth = 80;
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            this.TestName.Width = 80;
            // 
            // StudNumber
            // 
            this.StudNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudNumber.DataPropertyName = "StudNumber";
            this.StudNumber.HeaderText = "№ студенческого";
            this.StudNumber.Name = "StudNumber";
            this.StudNumber.ReadOnly = true;
            this.StudNumber.Width = 110;
            // 
            // TestTime
            // 
            this.TestTime.DataPropertyName = "StrTestTime";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.TestTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.TestTime.HeaderText = "Время тестирования";
            this.TestTime.Name = "TestTime";
            this.TestTime.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.StartTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.StartTime.HeaderText = "Время начала";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // MaxScore
            // 
            this.MaxScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaxScore.DataPropertyName = "MaxScore";
            this.MaxScore.HeaderText = "Макс.";
            this.MaxScore.Name = "MaxScore";
            this.MaxScore.ReadOnly = true;
            this.MaxScore.Width = 62;
            // 
            // PassingScore
            // 
            this.PassingScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PassingScore.DataPropertyName = "PassingScore";
            this.PassingScore.HeaderText = "Проходной";
            this.PassingScore.Name = "PassingScore";
            this.PassingScore.ReadOnly = true;
            this.PassingScore.Width = 87;
            // 
            // Score
            // 
            this.Score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Score.DataPropertyName = "Score";
            this.Score.HeaderText = "Балл";
            this.Score.Name = "Score";
            this.Score.Width = 51;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 493);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "StatisticsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика тестирования";
            this.panelTop.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBoxStudent.ResumeLayout(false);
            this.groupBoxStudent.PerformLayout();
            this.groupBoxGroup.ResumeLayout(false);
            this.groupBoxGroup.PerformLayout();
            this.groupBoxDate.ResumeLayout(false);
            this.groupBoxDate.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.groupBoxMarks.ResumeLayout(false);
            this.groupBoxMarks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtb5)).EndInit();
            this.groupBoxPass.ResumeLayout(false);
            this.groupBoxPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtbPass)).EndInit();
            this.panelClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBoxDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.GroupBox groupBoxGroup;
        private System.Windows.Forms.GroupBox groupBoxStudent;
        private System.Windows.Forms.LinkLabel linkLabelTest;
        private System.Windows.Forms.LinkLabel linkLabelGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxAutoupdate;
        private System.Windows.Forms.LinkLabel linkLabelSelectStudent;
        private System.Windows.Forms.TextBox textBoxStudent;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonAppeal;
        private System.Windows.Forms.GroupBox groupBoxMarks;
        private System.Windows.Forms.GroupBox groupBoxPass;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown mtbPass;
        private System.Windows.Forms.NumericUpDown mtb3;
        private System.Windows.Forms.NumericUpDown mtb4;
        private System.Windows.Forms.NumericUpDown mtb5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestSessionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassingScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
    }
}