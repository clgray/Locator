using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using Cnit.Testor.Core.UI.Testing;

namespace Cnit.Testor.Core.UI.Edit
{
    public sealed class ProjectState
    {
        private ProjectForm _projectForm;
        private string _currentFileName = String.Empty;
        private DataPackageManager _dataPackageManager;
        private TestHelper _selectedTestHelper;
        private List<TestHelper> _testHelpers = new List<TestHelper>();
        private List<TestHelper> _delArray = new List<TestHelper>();

        private static ProjectState _currentSingleton;

        private static OpenFileDialog openFileDialogTests = new OpenFileDialog();
        private static OpenFileDialog openFileDialog = new OpenFileDialog();
        private static SaveFileDialog saveFileDialog = new SaveFileDialog();

        private static bool _hasChanges;
        private static bool _canAddTests;
        private static bool _canDelete;

        public static bool HasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnStateChanged();
                }
            }
        }

        public static TestorData FullTestorDataSet
        {
            get
            {
                return DataCreator.CreateFullTestorDataSet(TestHelpers);
            }
        }

        public static bool CanAddTests
        {
            get
            {
                return _canAddTests;
            }
            set
            {
                if (_canAddTests != value)
                {
                    _canAddTests = value;
                    OnStateChanged();
                }
            }
        }

        public static bool CanDelete
        {
            get
            {
                return _canDelete;
            }
            set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    OnStateChanged();
                }
            }
        }

        public static bool IsProjectOpen
        {
            get
            {
                return !(_currentSingleton == null);
            }
        }

        public static DataPackageManager DataPackageManager
        {
            get
            {
                return _currentSingleton._dataPackageManager;
            }
        }

        public static TestManager TestManager
        {
            get
            {
                return _currentSingleton._dataPackageManager.TestManager;
            }
        }

        public static List<TestHelper> TestHelpers
        {
            get
            {
                return _currentSingleton._testHelpers;
            }
        }

        public static TestHelper SelectedTestHelper
        {
            get
            {
                return _currentSingleton._selectedTestHelper;
            }
            set
            {
                if (_currentSingleton._selectedTestHelper != value)
                {
                    _currentSingleton._selectedTestHelper = value;
                    OnStateChanged();
                }
            }
        }

        public static ProjectForm ProjectForm
        {
            get
            {
                return _currentSingleton._projectForm;
            }
        }

        public static string FileName
        {
            get
            {
                return new FileInfo(_currentSingleton._currentFileName).Name;
            }
        }

        public static string FullFileName
        {
            get
            {
                return _currentSingleton._currentFileName;
            }
        }

        public static event EventHandler TestHelpersChanged;
        public static event EventHandler TestHelperUpdated;
        public static event EventHandler TestHelperDeleted;
        public static event EventHandler ProjectOpend;
        public static event EventHandler ProjectClosed;
        public static event EventHandler ProjectSaving;
        public static event EventHandler StateChanged;

        static ProjectState()
        {
            openFileDialogTests.Filter = "Документы|*.doc;*docx;*.rtf;*.txt;";
            openFileDialogTests.Multiselect = true;
            openFileDialog.Filter = "Набор тестов|*.ctfx";
            saveFileDialog.Filter = openFileDialog.Filter;
        }

        private ProjectState(string fileName)
        {
            _currentFileName = fileName;
            _dataPackageManager = new DataPackageManager(_currentFileName);
            _dataPackageManager.Open();
            Dictionary<string, TestConfig> tests = _dataPackageManager.TestManager.GetTestObjects();
            foreach (var test in tests)
            {
                TestHelper testHelper = new TestHelper(_dataPackageManager, test.Value);
                _testHelpers.Add(testHelper);
            }
            _dataPackageManager.Close();
        }

        public static void OpenProject()
        {
            OnProjectSaving();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!TryCloseProject())
                    return;
            }
            else
                return;
            OpenProject(openFileDialog.FileName, false);
        }

        public static void OpenProject(string fileName, bool tryClose)
        {
            try
            {
                if (tryClose)
                    if (!TryCloseProject())
                        return;
                _currentSingleton = new ProjectState(fileName);
                _currentSingleton._projectForm = new ProjectForm();
                CanAddTests = true;
                HasChanges = false;
                OnProjectOpend();
                OnStateChanged();
            }
            catch (Exception ex)
            {
                SystemMessage.ShowErrorMessage(ex.Message);
            }
        }

        public static void CloseProject()
        {
            _currentSingleton._projectForm.Close();
            _currentSingleton._projectForm = null;
            _currentSingleton = null;
            _canAddTests = false;
            OnProjectClosed();
        }

        public static void CreateProject()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!TryCloseProject())
                    return;
                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
            }
            else
                return;
            OpenProject(saveFileDialog.FileName, false);
        }

        public static void CreateProjectFromWord()
        {
            if (openFileDialogTests.ShowDialog() == DialogResult.OK)
            {
                if (!TryCloseProject())
                    return;
                int i = 1;
                string fileName = String.Format("{0}.ctfx", openFileDialogTests.FileNames[0]);
                if (File.Exists(fileName))
                {
                    while (File.Exists(
                        fileName = String.Format("{0}_{1}.ctfx", openFileDialogTests.FileNames[0], i.ToString())))
                        i++;
                }
                if (IsProjectOpen)
                    CloseProject();
                OpenProject(fileName, false);
                AddTests(openFileDialogTests.FileNames);
                SaveProject();
            }
        }

        public static void CreateMasterTest()
        {
            InputBox ib = new InputBox("Имя мастер теста", "Введите имя мастер теста:");
            if (ib.ShowDialog() != DialogResult.OK)
                return;
            if (ProjectState.TestHelpers.Where(c => c.TestName == ib.Input).Count() > 0)
            {
                SystemMessage.ShowWarningMessage("Данное имя теста уже используется.");
                return;
            }
            TestorData td = new TestorData();
            TestorData.CoreTestsRow testRow = HtmlStore.CreateCoreTest(td, ib.Input);
            testRow.IsMasterTest = true;
            td.CoreTests.AddCoreTestsRow(testRow);
            TestHelper testHelper = new TestHelper(ProjectState.DataPackageManager);
            testHelper.TestKey = testRow.TestKey.ToString();
            testHelper.ConvTime = DateTime.Now;
            testHelper.FullFileName = String.Empty;
            testHelper.TestorData = td;
            testHelper.TestName = ib.Input;
            testHelper.QuestCount = 0;
            testHelper.IsMasterTest = true;
            List<TestHelper> helperList = new List<TestHelper>();
            helperList.Add(testHelper);
            ProjectState.AddTests(helperList);
        }

        public static bool TryCloseProject()
        {
            OnProjectSaving();
            bool retValue = true;
            if (IsProjectOpen)
            {
                if (HasChanges)
                {
                    DialogResult result = MessageBox.Show(String.Format("Сохранить изменения в \"{0}\"?", FileName), "Редактор тестов",
                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Cancel)
                        return false;
                    else if (result == DialogResult.Yes)
                        SaveProject();
                }
                CloseProject();
            }
            return retValue;
        }

        public static void SaveProject()
        {
            try
            {
                OnProjectSaving();
                DataPackageManager.Open();
                foreach (var testHelper in TestHelpers)
                    if (testHelper.IsTestorDataLoaded)
                        TestManager.SaveTestorData(testHelper.TestorData,
                            testHelper.TestConfig);
                foreach (var testHelper in _currentSingleton._delArray)
                    if (testHelper.Uri != null)
                        DataPackageManager.DeletePart(testHelper.Uri);
                _currentSingleton._delArray.Clear();
                DataPackageManager.Close();
                HasChanges = false;
            }
            catch (Exception ex)
            {
                SystemMessage.ShowErrorMessage(ex.Message);
            }
        }

        public static void SaveProjectAs()
        {
            try
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                if (File.Exists(saveFileDialog.FileName))
                    File.Delete(saveFileDialog.FileName);
                foreach (var helper in TestHelpers)
                {
                    bool hasErrors = helper.TestorData.HasErrors;
                }
                _currentSingleton._dataPackageManager = new DataPackageManager(saveFileDialog.FileName);
                _currentSingleton._currentFileName = saveFileDialog.FileName;
                _currentSingleton._dataPackageManager.Open();
                foreach (var testHelper in TestHelpers)
                    TestManager.SaveTestorData(testHelper.TestorData,
                        testHelper.TestConfig);
                foreach (var testHelper in _currentSingleton._delArray)
                    if (testHelper.Uri != null)
                        DataPackageManager.DeletePart(testHelper.Uri);
                _currentSingleton._delArray.Clear();
                DataPackageManager.Close();
                HasChanges = false;
                OnProjectOpend();
            }
            catch (Exception ex)
            {
                SystemMessage.ShowErrorMessage(ex.Message);
            }
        }

        public static void AddTests()
        {
            if (openFileDialogTests.ShowDialog() != DialogResult.OK)
                return;
            AddTests(openFileDialogTests.FileNames);
        }

        public static void AddTestsFromProject()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName == FullFileName)
                {
                    SystemMessage.ShowErrorMessage("Выбор текущего проекта запрещён. Выберите другой файл.");
                    return;
                }
                try
                {
                    ProjectState state = new ProjectState(openFileDialog.FileName);
                    AddTestsFromProjectForm addForm = new AddTestsFromProjectForm(state._testHelpers);
                    addForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    SystemMessage.ShowErrorMessage(ex.Message);
                }
            }
        }

        public static void AddTests(string[] fileNames)
        {
            List<string> nFileNames = new List<string>();
            foreach (var fileName in fileNames)
            {
                if (TestHelpers.Where(c => c.FullFileName == fileName).Count() > 0)
                {
                    MessageBox.Show(String.Format("Файл \"{0}\" уже сожержется в проекте.", fileName));
                }
                else
                {
                    nFileNames.Add(fileName);
                }
            }
            if (nFileNames.Count > 0)
            {
                ConvertingForm convertingForm = new ConvertingForm(nFileNames.ToArray(), false);
                convertingForm.ShowDialog();
                OnTestHelpersChanged();
            }
        }

        public static void DeleteTest()
        {
            if (SelectedTestHelper == null)
                return;
            if (MessageBox.Show(String.Format("Вы действительно хотите удалить тест \"{0}\"?",
                SelectedTestHelper.TestName),
                    "Удаление теста", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!TestHelpers.Contains(SelectedTestHelper))
                    return;
                string delHelperKey = SelectedTestHelper.TestKey;
                TestHelpers.Remove(SelectedTestHelper);
                _currentSingleton._delArray.Add(SelectedTestHelper);
                HasChanges = true;
                foreach (var helper in TestHelpers)
                {
                    if (helper.TestRequirements.Contains(delHelperKey))
                        helper.TestRequirements.Remove(delHelperKey);
                    if (helper.SubTests.ContainsKey(delHelperKey))
                        helper.SubTests.Remove(delHelperKey);
                }
                OnTestHelperDeleted(SelectedTestHelper);
                foreach (var helper in TestHelpers.Where(c => c.IsMasterTest))
                    helper.OnHelperUpdated();
            }
        }

        public static void UpdateTest()
        {
            UpdateTest(SelectedTestHelper);
        }

        public static bool UpdateTestFileRefresh(TestHelper helper)
        {
            FileInfo fi = new FileInfo(helper.FullFileName);
            if (!fi.Exists)
            {
                openFileDialogTests.Multiselect = false;
                DialogResult dr = openFileDialogTests.ShowDialog();
                openFileDialogTests.Multiselect = true;
                if (dr == DialogResult.OK)
                {
                    helper.FullFileName = openFileDialogTests.FileName;
                    return true;
                }
                else
                    return false;
            }
            return true;
        }

        public static void UpdateTest(TestHelper helper)
        {
            FileInfo fi = new FileInfo(helper.FullFileName);
            if (!fi.Exists)
            {
                if (!UpdateTestFileRefresh(helper))
                    return;
            }
            else
            {
                if (fi.LastWriteTime <= helper.ConvTime)
                {
                    if (MessageBox.Show("Файл был сконвертирован позже последнего изменения.\nПереконвертировать заново?", "Редактор тестов",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        return;
                }
            }
            ConvertingForm cf = new ConvertingForm(new string[] { helper.FullFileName }, true);
            cf.ShowDialog();
            OnTestHelperUpdated(SelectedTestHelper);
        }

        public static void ShowTestContent()
        {
            if (SelectedTestHelper == null)
                return;
            if (!SelectedTestHelper.IsMasterTest)
            {
                TestContentForm contentForm = new TestContentForm(SelectedTestHelper.TestorData);
                contentForm.ShowDialog();
            }
            else
            {
                MasterTestContentForm masterContentForm = new MasterTestContentForm(false, -1);
                masterContentForm.ShowDialog();
            }
        }

        public static void ShowTestBrowser()
        {
            LocalTestingProvider provider = null;
            if (ProjectState.SelectedTestHelper.IsMasterTest)
                provider = new LocalTestingProvider(ProjectState.FullTestorDataSet,
                            ProjectState.SelectedTestHelper);
            else
                provider = new LocalTestingProvider(ProjectState.SelectedTestHelper.TestorData,
                            ProjectState.SelectedTestHelper);
            TestForm testForm = new TestForm(provider);
            testForm.ShowDialog();
        }

        public static void OnTestHelpersChanged()
        {
            if (TestHelpersChanged != null)
                TestHelpersChanged(null, new EventArgs());
        }

        public static void OnStateChanged()
        {
            if (StateChanged != null)
                StateChanged(null, new EventArgs());
        }

        private static void OnProjectOpend()
        {
            if (ProjectOpend != null)
                ProjectOpend(null, new EventArgs());
        }

        private static void OnProjectClosed()
        {
            if (ProjectClosed != null)
                ProjectClosed(null, new EventArgs());
        }

        private static void OnTestHelperUpdated(TestHelper testHelper)
        {
            if (TestHelperUpdated != null)
                TestHelperUpdated(testHelper, new EventArgs());
        }

        private static void OnTestHelperDeleted(TestHelper testHelper)
        {
            CanDelete = false;
            if (TestHelperDeleted != null)
                TestHelperDeleted(testHelper, new EventArgs());
        }

        private static void OnProjectSaving()
        {
            if (ProjectSaving != null)
                ProjectSaving(null, new EventArgs());
        }

        public static void UpdateTest(string fileName, HtmlStore[] store)
        {
            TestHelper helper = TestHelpers.Where(c => c.FullFileName == fileName).First();
            FileInfo fi = new FileInfo(fileName);
            helper.ConvTime = fi.LastWriteTime;
            helper.TestorData.CoreBLOBs.Clear();
            int qCount = helper.TestorData.CoreQuestions.Count();
            double[] marks = new double[helper.TestorData.CoreQuestions.Count()];
            for (int i = 0; i < qCount; i++)
                marks[i] = helper.TestorData.CoreQuestions[i].QuestionMark;
            helper.TestorData.CoreAnswers.Clear();
            helper.TestorData.CoreQuestions.Clear();
            HtmlStore.AddToDataset(helper.TestorData, helper.TestorData.CoreTests[0], store);
            helper.QuestCount = helper.TestorData.CoreQuestions.Count();
            for (int i = 0; i < helper.TestorData.CoreQuestions.Count(); i++)
            {
                if (i >= qCount)
                    break;
                helper.TestorData.CoreQuestions[i].QuestionMark = (short)marks[i];
            }
            HasChanges = true;
            OnTestHelpersChanged();
        }

        public static void AddTests(List<TestHelper> testHelpers)
        {
            if (testHelpers.Count == 0)
                return;
            HasChanges = true;
            TestHelpers.AddRange(testHelpers);
            OnTestHelpersChanged();
        }
    }
}
