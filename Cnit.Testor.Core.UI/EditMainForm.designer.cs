namespace Cnit.Testor.Core.UI
{
    partial class EditMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbCreate = new System.Windows.Forms.ToolStripDropDownButton();
            this.projectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectFromWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddTest = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveTest = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdateTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTestContent = new System.Windows.Forms.ToolStripButton();
            this.tsbLogIn = new System.Windows.Forms.ToolStripButton();
            this.tslUserName = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectFormWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.masterTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTestFromProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.removeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.testContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionsBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anonymousTestSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.groupEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslHasChanges = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslReady = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelContent = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreate,
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator,
            this.tsbAddTest,
            this.tsbRemoveTest,
            this.tsbUpdateTest,
            this.toolStripSeparator1,
            this.tsbTestContent,
            this.tsbLogIn,
            this.tslUserName});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(963, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // tsbCreate
            // 
            this.tsbCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem1,
            this.masterTestToolStripMenuItem});
            this.tsbCreate.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreate.Image")));
            this.tsbCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreate.Name = "tsbCreate";
            this.tsbCreate.Size = new System.Drawing.Size(79, 22);
            this.tsbCreate.Text = "Создать";
            // 
            // projectToolStripMenuItem1
            // 
            this.projectToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.newProjectFromWordToolStripMenuItem});
            this.projectToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("projectToolStripMenuItem1.Image")));
            this.projectToolStripMenuItem1.Name = "projectToolStripMenuItem1";
            this.projectToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.projectToolStripMenuItem1.Text = "Проект";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProjectToolStripMenuItem.Image")));
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.newProjectToolStripMenuItem.Text = "Проект...";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.projectToolStripMenuItem_Click);
            // 
            // newProjectFromWordToolStripMenuItem
            // 
            this.newProjectFromWordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProjectFromWordToolStripMenuItem.Image")));
            this.newProjectFromWordToolStripMenuItem.Name = "newProjectFromWordToolStripMenuItem";
            this.newProjectFromWordToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.newProjectFromWordToolStripMenuItem.Text = "Проект из Word документов...";
            this.newProjectFromWordToolStripMenuItem.Click += new System.EventHandler(this.projectFormWordToolStripMenuItem_Click);
            // 
            // masterTestToolStripMenuItem
            // 
            this.masterTestToolStripMenuItem.Enabled = false;
            this.masterTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("masterTestToolStripMenuItem.Image")));
            this.masterTestToolStripMenuItem.Name = "masterTestToolStripMenuItem";
            this.masterTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.masterTestToolStripMenuItem.Text = "Мастер тест...";
            this.masterTestToolStripMenuItem.Click += new System.EventHandler(this.masterTestToolStripMenuItem_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(74, 22);
            this.tsbOpen.Text = "Открыть";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(85, 22);
            this.tsbSave.Text = "Сохранить";
            this.tsbSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAddTest
            // 
            this.tsbAddTest.Enabled = false;
            this.tsbAddTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddTest.Image")));
            this.tsbAddTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddTest.Name = "tsbAddTest";
            this.tsbAddTest.Size = new System.Drawing.Size(104, 22);
            this.tsbAddTest.Text = "Добавить тест";
            this.tsbAddTest.Click += new System.EventHandler(this.toolStripButtonAddTest_Click);
            // 
            // tsbRemoveTest
            // 
            this.tsbRemoveTest.Enabled = false;
            this.tsbRemoveTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveTest.Image")));
            this.tsbRemoveTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveTest.Name = "tsbRemoveTest";
            this.tsbRemoveTest.Size = new System.Drawing.Size(71, 22);
            this.tsbRemoveTest.Text = "Удалить";
            this.tsbRemoveTest.Click += new System.EventHandler(this.tsbRemoveTest_Click);
            // 
            // tsbUpdateTest
            // 
            this.tsbUpdateTest.Enabled = false;
            this.tsbUpdateTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateTest.Image")));
            this.tsbUpdateTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdateTest.Name = "tsbUpdateTest";
            this.tsbUpdateTest.Size = new System.Drawing.Size(125, 22);
            this.tsbUpdateTest.Text = "Переконвертация";
            this.tsbUpdateTest.Click += new System.EventHandler(this.tsbUpdateTest_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbTestContent
            // 
            this.tsbTestContent.Enabled = false;
            this.tsbTestContent.Image = ((System.Drawing.Image)(resources.GetObject("tsbTestContent.Image")));
            this.tsbTestContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTestContent.Name = "tsbTestContent";
            this.tsbTestContent.Size = new System.Drawing.Size(115, 22);
            this.tsbTestContent.Text = "Просмотр теста";
            this.tsbTestContent.Click += new System.EventHandler(this.tsbTestContent_Click);
            // 
            // tsbLogIn
            // 
            this.tsbLogIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbLogIn.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogIn.Image")));
            this.tsbLogIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogIn.Name = "tsbLogIn";
            this.tsbLogIn.Size = new System.Drawing.Size(52, 22);
            this.tsbLogIn.Text = "Вход";
            this.tsbLogIn.Click += new System.EventHandler(this.tsbLogIn_Click);
            // 
            // tslUserName
            // 
            this.tslUserName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslUserName.Name = "tslUserName";
            this.tslUserName.Size = new System.Drawing.Size(70, 22);
            this.tslUserName.Text = "[UserName]";
            this.tslUserName.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(963, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.projectFormWordToolStripMenuItem,
            this.toolStripMenuItem5,
            this.masterTestToolStripMenuItem1});
            this.createToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createToolStripMenuItem.Image")));
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.createToolStripMenuItem.Text = "Создать";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("projectToolStripMenuItem.Image")));
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.projectToolStripMenuItem.Text = "Проект...";
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.projectToolStripMenuItem_Click);
            // 
            // projectFormWordToolStripMenuItem
            // 
            this.projectFormWordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("projectFormWordToolStripMenuItem.Image")));
            this.projectFormWordToolStripMenuItem.Name = "projectFormWordToolStripMenuItem";
            this.projectFormWordToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.projectFormWordToolStripMenuItem.Text = "Проект из Word документов...";
            this.projectFormWordToolStripMenuItem.Click += new System.EventHandler(this.projectFormWordToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(235, 6);
            // 
            // masterTestToolStripMenuItem1
            // 
            this.masterTestToolStripMenuItem1.Enabled = false;
            this.masterTestToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("masterTestToolStripMenuItem1.Image")));
            this.masterTestToolStripMenuItem1.Name = "masterTestToolStripMenuItem1";
            this.masterTestToolStripMenuItem1.Size = new System.Drawing.Size(238, 22);
            this.masterTestToolStripMenuItem1.Text = "Мастер тест...";
            this.masterTestToolStripMenuItem1.Click += new System.EventHandler(this.masterTestToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "Открыть...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.closeToolStripMenuItem.Text = "Закрыть проект";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTestToolStripMenuItem,
            this.addTestFromProjectToolStripMenuItem,
            this.toolStripMenuItem6,
            this.removeTestToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.toolStripMenuItem4,
            this.testContentToolStripMenuItem,
            this.questionsBrowserToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewToolStripMenuItem.Text = "Вид";
            // 
            // addTestToolStripMenuItem
            // 
            this.addTestToolStripMenuItem.Enabled = false;
            this.addTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTestToolStripMenuItem.Image")));
            this.addTestToolStripMenuItem.Name = "addTestToolStripMenuItem";
            this.addTestToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.addTestToolStripMenuItem.Text = "Добавить тест...";
            this.addTestToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonAddTest_Click);
            // 
            // addTestFromProjectToolStripMenuItem
            // 
            this.addTestFromProjectToolStripMenuItem.Enabled = false;
            this.addTestFromProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTestFromProjectToolStripMenuItem.Image")));
            this.addTestFromProjectToolStripMenuItem.Name = "addTestFromProjectToolStripMenuItem";
            this.addTestFromProjectToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.addTestFromProjectToolStripMenuItem.Text = "Добавить тест из другого проекта...";
            this.addTestFromProjectToolStripMenuItem.Click += new System.EventHandler(this.addTestFromProjectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(265, 6);
            // 
            // removeTestToolStripMenuItem
            // 
            this.removeTestToolStripMenuItem.Enabled = false;
            this.removeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeTestToolStripMenuItem.Image")));
            this.removeTestToolStripMenuItem.Name = "removeTestToolStripMenuItem";
            this.removeTestToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.removeTestToolStripMenuItem.Text = "Удалить";
            this.removeTestToolStripMenuItem.Click += new System.EventHandler(this.tsbRemoveTest_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Enabled = false;
            this.updateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateToolStripMenuItem.Image")));
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.updateToolStripMenuItem.Text = "Переконвертация";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.tsbUpdateTest_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(265, 6);
            // 
            // testContentToolStripMenuItem
            // 
            this.testContentToolStripMenuItem.Enabled = false;
            this.testContentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testContentToolStripMenuItem.Image")));
            this.testContentToolStripMenuItem.Name = "testContentToolStripMenuItem";
            this.testContentToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.testContentToolStripMenuItem.Text = "Просмотр теста...";
            this.testContentToolStripMenuItem.Click += new System.EventHandler(this.tsbTestContent_Click);
            // 
            // questionsBrowserToolStripMenuItem
            // 
            this.questionsBrowserToolStripMenuItem.Enabled = false;
            this.questionsBrowserToolStripMenuItem.Name = "questionsBrowserToolStripMenuItem";
            this.questionsBrowserToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.questionsBrowserToolStripMenuItem.Text = "Пройти тест...";
            this.questionsBrowserToolStripMenuItem.Click += new System.EventHandler(this.questionsBrowserToolStripMenuItem_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendTestsToolStripMenuItem,
            this.manageTestsToolStripMenuItem,
            this.anonymousTestSettingsToolStripMenuItem,
            this.toolStripMenuItem7,
            this.groupEditToolStripMenuItem,
            this.toolStripMenuItem8,
            this.userManagementToolStripMenuItem,
            this.testingStatisticsToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.serverToolStripMenuItem.Text = "Сервер";
            // 
            // sendTestsToolStripMenuItem
            // 
            this.sendTestsToolStripMenuItem.Enabled = false;
            this.sendTestsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendTestsToolStripMenuItem.Image")));
            this.sendTestsToolStripMenuItem.Name = "sendTestsToolStripMenuItem";
            this.sendTestsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.sendTestsToolStripMenuItem.Text = "Отправка тестов...";
            this.sendTestsToolStripMenuItem.Click += new System.EventHandler(this.sendTestsToolStripMenuItem_Click);
            // 
            // manageTestsToolStripMenuItem
            // 
            this.manageTestsToolStripMenuItem.Name = "manageTestsToolStripMenuItem";
            this.manageTestsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.manageTestsToolStripMenuItem.Text = "Управление тестами...";
            this.manageTestsToolStripMenuItem.Click += new System.EventHandler(this.manageTestsToolStripMenuItem_Click);
            // 
            // anonymousTestSettingsToolStripMenuItem
            // 
            this.anonymousTestSettingsToolStripMenuItem.Name = "anonymousTestSettingsToolStripMenuItem";
            this.anonymousTestSettingsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.anonymousTestSettingsToolStripMenuItem.Text = "Настройка анонимных тестов...";
            this.anonymousTestSettingsToolStripMenuItem.Click += new System.EventHandler(this.anonymousTestSettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(244, 6);
            // 
            // groupEditToolStripMenuItem
            // 
            this.groupEditToolStripMenuItem.Name = "groupEditToolStripMenuItem";
            this.groupEditToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.groupEditToolStripMenuItem.Text = "Редактор групп...";
            this.groupEditToolStripMenuItem.Click += new System.EventHandler(this.groupEditToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(244, 6);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.userManagementToolStripMenuItem.Text = "Управление пользователями...";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // testingStatisticsToolStripMenuItem
            // 
            this.testingStatisticsToolStripMenuItem.Name = "testingStatisticsToolStripMenuItem";
            this.testingStatisticsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.testingStatisticsToolStripMenuItem.Text = "Статистика тестирования...";
            this.testingStatisticsToolStripMenuItem.Click += new System.EventHandler(this.testingStatisticsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.aboutToolStripMenuItem.Text = "О Программе...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslHasChanges,
            this.tsslReady});
            this.statusStrip.Location = new System.Drawing.Point(0, 665);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(963, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // tsslHasChanges
            // 
            this.tsslHasChanges.Name = "tsslHasChanges";
            this.tsslHasChanges.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslReady
            // 
            this.tsslReady.Name = "tsslReady";
            this.tsslReady.Size = new System.Drawing.Size(38, 17);
            this.tsslReady.Text = "Готов";
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 49);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(963, 616);
            this.panelContent.TabIndex = 4;
            // 
            // EditMainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 687);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(780, 600);
            this.Name = "EditMainForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestEdit Core";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditMainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripButton tsbAddTest;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbRemoveTest;
        private System.Windows.Forms.ToolStripButton tsbUpdateTest;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ToolStripStatusLabel tsslHasChanges;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectFormWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbTestContent;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem testContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbCreate;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectFromWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem masterTestToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tsbLogIn;
        private System.Windows.Forms.ToolStripLabel tslUserName;
		private System.Windows.Forms.ToolStripMenuItem addTestFromProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripStatusLabel tsslReady;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionsBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem groupEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anonymousTestSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingStatisticsToolStripMenuItem;
    }
}

