using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Cnit.Testor.Core.UI;
using Cnit.Testor.Core.UI.Edit;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.UI.UI;
using Cnit.Testor.Core.UI.Server;
using Cnit.Testor.Core.UI.Users;
using System.Diagnostics;
using Cnit.Testor.Core.Parsing;

namespace Cnit.Testor.Core.UI
{
    public partial class EditMainForm : Form
    {
        private string _formText = String.Format("Редактор тестов {0} {1}", TestingSystem.DisplayName, TestingSystem.LocatorVersion);
        private StartForm _startForm;
        private LoginForm _loginForm;

        public EditMainForm()
        {
            InitializeComponent();

            this.Text = _formText;
            _startForm = new StartForm();
            _loginForm = new LoginForm();
            ProjectState.ProjectOpend += new EventHandler(Commands_ProjectOpend);
            ProjectState.StateChanged += new EventHandler(Commands_StateChanged);
            ProjectState.ProjectClosed += new EventHandler(ProjectState_ProjectClosed);

            try
            {
                WordAdapter.OpenWord();
            }
            catch { }
        }

        void Commands_StateChanged(object sender, EventArgs e)
        {
            tsbSave.Enabled = ProjectState.HasChanges;
            saveToolStripMenuItem.Enabled = ProjectState.HasChanges;
            saveAsToolStripMenuItem.Enabled = true;
            tsbAddTest.Enabled = ProjectState.CanAddTests;
            sendTestsToolStripMenuItem.Enabled = ProjectState.CanAddTests;
            masterTestToolStripMenuItem.Enabled = ProjectState.CanAddTests;
            masterTestToolStripMenuItem1.Enabled = masterTestToolStripMenuItem.Enabled;
            tsbRemoveTest.Enabled = ProjectState.CanDelete;
            bool canUpdate = false;
            if (ProjectState.SelectedTestHelper != null)
                canUpdate = ProjectState.CanDelete && ProjectState.SelectedTestHelper.IsMasterTest == false;
            tsbUpdateTest.Enabled = canUpdate;
            tsbTestContent.Enabled = ProjectState.CanDelete;
            testContentToolStripMenuItem.Enabled = ProjectState.CanDelete;
            addTestToolStripMenuItem.Enabled = ProjectState.CanAddTests;
            addTestFromProjectToolStripMenuItem.Enabled = ProjectState.CanAddTests;
            removeTestToolStripMenuItem.Enabled = ProjectState.CanDelete;
            updateToolStripMenuItem.Enabled = canUpdate;
            questionsBrowserToolStripMenuItem.Enabled = ProjectState.SelectedTestHelper != null;
            if (ProjectState.HasChanges)
            {
                this.Text = String.Format("{0} - {1} *", _formText, ProjectState.FullFileName);
                tsslHasChanges.Text = "Изменения не сохранены";
            }
            else
            {
                this.Text = String.Format("{0} - {1}", _formText, ProjectState.FullFileName);
                tsslHasChanges.Text = String.Empty;
            }
        }

        void Commands_ProjectOpend(object sender, EventArgs e)
        {
            AddFormToPanel(ProjectState.ProjectForm);
            this.Text = String.Format("{0} - {1}", _formText, ProjectState.FullFileName);
            closeToolStripMenuItem.Enabled = true;
        }

        void ProjectState_ProjectClosed(object sender, EventArgs e)
        {
            closeToolStripMenuItem.Enabled = false;
            this.Text = _formText;
            tsbAddTest.Enabled = false;
            tsbRemoveTest.Enabled = false;
            tsbUpdateTest.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            addTestToolStripMenuItem.Enabled = false;
            addTestFromProjectToolStripMenuItem.Enabled = false;
            removeTestToolStripMenuItem.Enabled = false;
            updateToolStripMenuItem.Enabled = false;
            tsbTestContent.Enabled = false;
            testContentToolStripMenuItem.Enabled = false;
            masterTestToolStripMenuItem.Enabled = false;
            masterTestToolStripMenuItem1.Enabled = false;
            sendTestsToolStripMenuItem.Enabled = false;
            questionsBrowserToolStripMenuItem.Enabled = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity + 0.07 >= 1.0)
            {
                this.Opacity = 1.0;
                timer.Enabled = false;
            }
            else
            {
                this.Opacity += 0.07;
            }
        }

        private void AddFormToPanel(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            foreach (Control control in panelContent.Controls)
            {
                if (!(control is StartForm))
                    panelContent.Controls.Remove(control);
            };
            panelContent.Controls.Add(form);
            form.BringToFront();
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            AddFormToPanel(_startForm);
            if (LoginHelper.NeedOpen != null)
                ProjectState.OpenProject(LoginHelper.NeedOpen.FullName, false);
            if (SystemInformation.TerminalServerSession)
                this.Opacity = 1;
            else
                timer.Enabled = true;
        }

        private void toolStripButtonAddTest_Click(object sender, EventArgs e)
        {
            ProjectState.AddTests();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            ProjectState.SaveProject();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ProjectState.TryCloseProject();
        }
        private void tsbRemoveTest_Click(object sender, EventArgs e)
        {
            ProjectState.DeleteTest();
        }

        private void tsbUpdateTest_Click(object sender, EventArgs e)
        {
            ProjectState.UpdateTest();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.OpenProject();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.CreateProject();
        }

        private void projectFormWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.CreateProjectFromWord();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.SaveProject();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.TryCloseProject();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.SaveProjectAs();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            ProjectState.OpenProject();
        }

        private void tsbTestContent_Click(object sender, EventArgs e)
        {
            ProjectState.ShowTestContent();
        }

        private void questionsBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.ShowTestBrowser();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                FileInfo[] fi = GetDragDropFile(e);
                if (fi.Length == 0)
                    return;
                string fileExt = fi[0].Extension.ToLower();
                if (ProjectState.IsProjectOpen)
                {
                    if (fileExt == ".ctfx")
                    {
                        e.Effect = DragDropEffects.All;
                        return;
                    }
                    else
                    {
                        foreach (var file in fi)
                        {
                            fileExt = file.Extension.ToLower();
                            if (fileExt != ".doc" && fileExt != ".docx"
                                && fileExt != ".rtf" && fileExt != ".txt")
                                return;
                        }
                        e.Effect = DragDropEffects.All;
                    }

                }
                else
                {
                    if (fileExt == ".ctfx")
                        e.Effect = DragDropEffects.All;
                }
            }
        }

        private FileInfo[] GetDragDropFile(DragEventArgs e)
        {
            List<FileInfo> retValue = new List<FileInfo>();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0)
                return null;
            foreach (var file in files)
                retValue.Add(new FileInfo(file));
            return retValue.ToArray();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            FileInfo[] fi = GetDragDropFile(e);
            if (fi.Length == 0)
                return;
            if (fi[0].Extension.ToLower() == ".ctfx")
            {
                ProjectState.OpenProject(fi[0].FullName, true);
            }
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ProjectState.AddTests(files);
            }
        }

        private void masterTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.CreateMasterTest();
        }

        private void tsbLogIn_Click(object sender, EventArgs e)
        {
            if (StaticServerProvider.IsLogin)
            {
                StaticServerProvider.Logout();
                tslUserName.Visible = StaticServerProvider.IsLogin;
                tsbLogIn.Text = "Вход";
            }
            else
            {
                InitLogin();
            }
        }

        public bool InitLogin()
        {
            _loginForm.InitForm();
            _loginForm.ShowDialog();
            if (StaticServerProvider.IsLogin)
            {
                tslUserName.Visible = true;
                tslUserName.Text = String.Format("Здравствуйте, {0}!", LoginForm.UserName);
                tsbLogIn.Text = "Выход";
            }
            return StaticServerProvider.IsLogin;
        }

        private void addTestFromProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectState.AddTestsFromProject();
        }

        private void sendTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StaticServerProvider.IsLogin)
                if (!InitLogin())
                    return;
            if (TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian))
            {
                SendTestsForm sendForm = new SendTestsForm();
                sendForm.ShowDialog();
                StaticServerProvider.NullClients();
            }
        }

        private void manageTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StaticServerProvider.IsLogin)
                if (!InitLogin())
                    return;
            if (TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian))
            {
                ManageTestsForm manageForm = new ManageTestsForm();
                manageForm.ShowDialog();
                StaticServerProvider.NullClients();
            }
        }

        private void groupEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StaticServerProvider.IsLogin)
                if (!InitLogin())
                    return;
            if (TestRoles(TestorUserRole.Administrator))
            {
                GroupEditForm groupEdit = new GroupEditForm();
                groupEdit.ShowDialog();
                StaticServerProvider.NullClients();
            }
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StaticServerProvider.IsLogin)
                if (!InitLogin())
                    return;
            if (TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian))
            {
                UserManagementForm userManagement = new UserManagementForm();
                userManagement.ShowDialog();
                StaticServerProvider.NullClients();
            }
        }

        private void anonymousTestSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StaticServerProvider.IsLogin)
                if (!InitLogin())
                    return;
            if (TestRoles(TestorUserRole.Administrator))
            {
                AnonymousTestSettingsForm af = new AnonymousTestSettingsForm();
                af.ShowDialog();
                StaticServerProvider.NullClients();
            }
        }

        public bool TestRoles(params TestorUserRole[] roles)
        {
            foreach (var role in roles)
                if (StaticServerProvider.CurrentUser.UserRole == role)
                    return true;
            SystemMessage.ShowErrorMessage("Нет доступа. Если доступ необходим, обратитесь к администратору.");
            return false;
        }

        private void testingStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!StaticServerProvider.IsLogin)
                if (!InitLogin())
                    return;
            if (TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian))
            {
                StatisticsForm statistics = new StatisticsForm(true);
                statistics.FormBorderStyle = FormBorderStyle.Sizable;
                statistics.WindowState = FormWindowState.Maximized;
                statistics.ShowInTaskbar = true;
                statistics.Show();
                StaticServerProvider.NullClients();
            }
        }

        private void EditMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WordAdapter.IsWordOpened)
            {
                WordAdapter.CloseWord();
            }
        }
    }
}
