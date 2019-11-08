using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.HttpServer;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using Cnit.Testor.Core.Server.Services;
using System.Drawing;
using System.Web.Security;

namespace CoreWebClient
{
    public partial class DefaultWebPage : System.Web.UI.Page
    {
        private const string BUTTON_MODE = "mode";
        private const string BUTTON_VALUE = "btvalue";
        private const string NULL_VALUE = "NULL";
        private const string TESTING_VALUE = "TESTING";
        private const string NTMODE_VALUE = "NT_MODE";

        private int _objectID = 0;
        private TestorTreeItem _currentItem;
        private TestorData _currentTest;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LocalUser.IsIntranet && !Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/Login.aspx");
            StartTestParams ncs = LocalUser.TestClient.GetNotCommitedSessions(0, false);
            if (ncs != null)
                Server.Transfer("~/Testing.aspx");
            MultiViewMain.ActiveViewIndex = 0;
            LabelTestname.Visible = false;
            requirementsPanel.Visible = false;
            if (Context.User.Identity.IsAuthenticated)
            {
                var currentUser = LocalUser.SecurityProvider.CurrentUser;
                if (currentUser == null)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx");
                }
                string userName = String.Format(":: {0} {1} {2}", HtmlStore.GetString(currentUser.LastName),
                     HtmlStore.GetString(currentUser.FirstName), HtmlStore.GetString(currentUser.SecondName));
                Label lbl = (this.Master.FindControl("userName") as Label);
                if (String.IsNullOrEmpty(userName.Trim()))
                    lbl.Text = currentUser.Login;
                else
                    lbl.Text = userName;
            }
            if (InitPageMode())
                InitTree();
            else
            {
                InitTestList();
                InitNavigator();
                if (_currentItem.ItemType == TestorItemType.Test
                    || _currentItem.ItemType == TestorItemType.MasterTest)
                {
                    MultiViewMain.ActiveViewIndex = 2;
                    postButton.Text = "Приступить к тестированию";
                    _currentTest = DataCompressor.DecompressData<TestorData>(
                        LocalUser.TestEdit.GetTestSettings(_currentItem.TestId.Value));
                    testDetails.Text = HttpHandler.GetPreTestingHtml(_currentTest.CoreTests[0]);
                    TestorData.CoreTestsRow test = _currentTest.CoreTests[0];
                    LabelTestname.Visible = true;
                    RemoteTestingProvider _provider = new RemoteTestingProvider(LocalUser.WebServerProvider, _currentItem,
                        _currentTest, null, false);
                    if (!_provider.IsTestActive)
                    {
                        postButton.Enabled = false;
                        LabelTestname.ForeColor = Color.Red;
                        LabelTestname.Text = _provider.NotActiveMessage;
                        if (_provider.RequirementsTests != null)
                        {
                            postButton.Enabled = false;
                            LabelTestname.Text = "Перед прохлждением данного теста необходимо пройти предыдущие тесты";
                            LabelTestname.ForeColor = Color.Red;
                            requirementsPanel.Visible = true;
                            requirementsRepeater.DataSource = _provider.RequirementsTests;
                            requirementsRepeater.DataBind();
                        }
                        return;
                    }
                    if (LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Administrator ||
                        LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Teacher ||
                        LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Laboratorian)
                        LabelTestname.Text = String.Format("Тест: <a href=\"/Manage/Statistics.aspx?testId={0}\">{1}</a>", _currentItem.TestId, _currentItem.ItemName.Trim());
                    else
                        LabelTestname.Text = String.Format("Тест: \"{0}\"", _currentItem.ItemName.Trim());
                    if (postButton.Attributes[BUTTON_MODE] == NULL_VALUE)
                        postButton.Attributes[BUTTON_MODE] = NTMODE_VALUE;
                    else
                        postButton.Attributes[BUTTON_MODE] = TESTING_VALUE;
                    postButton.Attributes[BUTTON_VALUE] = _currentItem.ItemId.ToString();
                }
            }
        }

        protected void postButton_Click(object sender, EventArgs e)
        {
            if (postButton.Attributes[BUTTON_VALUE] == NULL_VALUE || postButton.Attributes[BUTTON_MODE] == NTMODE_VALUE)
                return;
            if (postButton.Attributes[BUTTON_MODE] != TESTING_VALUE)
                return;
            RemoteTestingProvider provider = new RemoteTestingProvider(LocalUser.WebServerProvider, _currentItem, _currentTest, null, false);
            provider.StartTest();
            Session["UniqId"] = provider.UniqId;
            Response.Redirect("~/Testing.aspx");
        }

        private bool InitPageMode()
        {
            if (Convert.ToInt32(Request["pageMode"]) == 1)
            {
                HyperLinkMain.NavigateUrl = "Default.aspx";
                HyperLinkMain.Text = "Скрыть дерево тестов";
                postButton.Visible = false;
                MultiViewMain.ActiveViewIndex = 1;
                return true;
            }
            else
            {
                HyperLinkMain.NavigateUrl = "Default.aspx?pageMode=1";
                HyperLinkMain.Text = "Показать все тесты";
                postButton.Visible = true;
                MultiViewMain.ActiveViewIndex = 0;
                return false;
            }
        }

        private void InitTree()
        {
            TreeViewMain.Nodes.Clear();
            TreeNode rootNode = new TreeNode("Все тесты", "tests", "~/Images/computer.png");
            rootNode.NavigateUrl = "Default.aspx";
            TreeViewMain.Nodes.Add(rootNode);
            var items = LocalUser.TestEdit.GetServerTree(0, 0, TestingServerItemType.ActiveTestTree);
            if (items.Length == 1)
                AddTreeNodes(items[0].SubItems, rootNode);
            else
                AddTreeNodes(items, rootNode);
        }

        private void InitTestList()
        {
            _objectID = GetCurrentObjectID();
            TestorTreeItem[] items = LocalUser.TestEdit.GetServerTree(_objectID, 1,
                TestingServerItemType.ActiveTestTree);
            NoItemsLabel.Visible = items.Length == 0;
            TestRepeater.DataSource = items;
            TestRepeater.DataBind();
            postButton.Text = "Выбрать";
        }

        private void InitNavigator()
        {
            Panel pathPanel = (Panel)this.Master.FindControl("PanelPath");
            TestorTreeItem[] parents = LocalUser.TestEdit.GetTestParents(_objectID);
            if (parents == null)
            {
                Response.Redirect("/");
                return;
            }
            TestorTreeItem rootItem = new TestorTreeItem(0, 0, "Все тесты", TestorItemType.Folder, parents);
            TestorTreeItem currentItem = null;
            do
            {
                if (currentItem == null)
                    currentItem = rootItem;
                else
                    currentItem = currentItem.SubItems[0];
                HyperLink hl = new HyperLink();
                hl.Text = currentItem.ItemName;
                hl.NavigateUrl = "Default.aspx?objectId=" + currentItem.ItemId.ToString();
                Label lb = new Label() { Text = "/" };
                if (currentItem != rootItem)
                    pathPanel.Controls.Add(lb);
                pathPanel.Controls.Add(hl);
            } while (currentItem.SubItems.Length > 0);
            _currentItem = currentItem;
        }

        private int GetCurrentObjectID()
        {
            int retValue = 0;
            if (!Page.IsPostBack)
            {
                try
                {
                    retValue = Convert.ToInt32(Request["objectID"]);
                }
                catch (Exception)
                {
                    retValue = 0;
                }
            }
            else
            {
                if (postButton.Attributes[BUTTON_VALUE] == NULL_VALUE)
                {
                    string idString = Request.Params["RadioButtonList"];
                    if (!String.IsNullOrEmpty(idString))
                        retValue = Convert.ToInt32(idString);
                }
                else
                {
                    int.TryParse(postButton.Attributes[BUTTON_VALUE], out retValue);
                    return retValue;
                }
            }
            return retValue;
        }

        public void AddTreeNodes(TestorTreeItem[] items, TreeNode parent)
        {
            foreach (var newItem in items)
            {
                TreeNode newNode = new TreeNode();
                newNode.NavigateUrl = String.Format("Default.aspx?objectId={0}", newItem.ItemId.ToString());
                switch (newItem.ItemType)
                {
                    case TestorItemType.Folder:
                        {
                            newNode.ImageUrl = "~/Images/imgFolder.png";
                        }
                        break;
                    case TestorItemType.Test:
                        {
                            newNode.ImageUrl = "~/Images/imgTest.png";
                        }
                        break;
                    case TestorItemType.MasterTest:
                        {
                            newNode.ImageUrl = "~/Images/imgTest.png";
                        }
                        break;
                    case TestorItemType.Group:
                        {
                            newNode.ImageUrl = "~/Images/imgFolder.png";
                        }
                        break;
                }
                newNode.Text = newItem.ItemName;
                parent.ChildNodes.Add(newNode);
                AddTreeNodes(newItem.SubItems, newNode);
            }
        }
    }
}
