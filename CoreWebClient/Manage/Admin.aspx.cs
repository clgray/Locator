using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core;
using System.Configuration;
using System.Web.Configuration;
using Cnit.Testor.Core.Server;

namespace CoreWebClient
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/Default.aspx");
            if (LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
                Response.Redirect("~/Default.aspx");
            changesIndicator.Visible = false;
            aspErrorMessage.Visible = false;
            if (!Page.IsPostBack)
                TreeViewMain_SelectedNodeChanged(sender, e);
        }

        protected void TreeViewMain_SelectedNodeChanged(object sender, EventArgs e)
        {
            MultiViewMain.ActiveViewIndex = int.Parse(TreeViewMain.SelectedValue);
            var activeView = MultiViewMain.GetActiveView();
            if (activeView == ViewLogin)
            {
                LoadLoginView();
                postButton.Visible = true;
            }
            else if (activeView == ViewAnonym)
            {
                InitAnonymouseView();
                postButton.Visible = true;
            }
            else if (activeView == ViewUsers)
            {
                InitUsersView();
                postButton.Visible = false;
            }
        }

        private void InitUsersView()
        {
            BtnUserSearch_Click(null, new EventArgs());
        }

        protected void BtnUserSearch_Click(object sender, EventArgs e)
        {
            TestorCoreUser[] users = UserSearchHelper.FindUsers(userName.Text, TestorUserRole.NotDefined, TestorUserStatus.Any, 0, false);

            GridViewUsers.EmptyDataText = String.Format("Поиск: <b>{0}*</b>. Пользователи не найдены.", userName.Text);
            GridViewUsers.DataKeyNames = new string[] { "UserId" };
            GridViewUsers.DataSource = users;
            GridViewUsers.DataBind();

            GridViewUsers_SelectedIndexChanged(sender, e);
        }

        protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewUsers.SelectedValue != null)
            {
                selUser.Text = String.Format("[{0}] {1} {2} {3}", GridViewUsers.SelectedRow.Cells[1].Text,
                    GridViewUsers.SelectedRow.Cells[2].Text, GridViewUsers.SelectedRow.Cells[3].Text,
                    GridViewUsers.SelectedRow.Cells[4].Text);
                selUserPlace.Visible = true;
            }
            else
                selUserPlace.Visible = false;

        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsers.PageIndex = e.NewPageIndex;
            BtnUserSearch_Click(sender, new EventArgs());
            GridViewUsers.SelectedIndex = -1;
            GridViewUsers_SelectedIndexChanged(sender, e);
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            userName.Text = String.Empty;
            GridViewUsers.SelectedIndex = -1;
            BtnUserSearch_Click(null, new EventArgs());
        }

        private void InitAnonymouseView()
        {
            TreeViewTests.Nodes.Clear();
            TreeNode rootNode = new TreeNode("Все тесты", "tests", "~/Images/computer.png");
            TreeViewTests.Nodes.Add(rootNode);
            var items = LocalUser.TestEdit.GetServerTree(0, 0, TestingServerItemType.FolderTree);
            AddTreeNodes(items, rootNode);
            rootNode.Expand();

            string policy = LocalUser.HelperService.GetPropertyValue(SystemProperties.ANONYMOUS_POLICY);
            if (policy == "-1")
                radioButtonNone.Checked = true;
            else if (policy == "0")
                radioButtonAll.Checked = true;
            else
            {
                radioButtonFolder.Checked = true;
                var folders = LocalUser.TestEdit.GetTestParents(int.Parse(policy));
                if (folders.Length == 0)
                    radioButtonNone.Checked = true;
                else
                {
                    TestorTreeItem selectedFolder = folders[0];
                    while (selectedFolder.SubItems != null && selectedFolder.SubItems.Length != 0)
                        selectedFolder = selectedFolder.SubItems[0];
                    lbSelectedFolder.Text = selectedFolder.ItemName;
                    ViewState["SelectedFolder"] = selectedFolder;
                }
            }
        }

        private void AddTreeNodes(TestorTreeItem[] items, TreeNode parent)
        {
            foreach (var newItem in items)
            {
                TreeNode newNode = new TreeNode();
                newNode.Value = newItem.ItemId.ToString();
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

        private void LoadLoginView()
        {
            CheckBoxAllowIntranet.Checked = LocalUser.GetPropertyValue(SystemProperties.SESSION_ALLOW_INTRANET) == SystemProperties.SESSION_TRUE;
            CheckBoxAllowPublic.Checked = LocalUser.GetPropertyValue(SystemProperties.SESSION_ALLOW_PUBLIC) == SystemProperties.SESSION_TRUE;
            TextBoxFrom.Text = LocalUser.GetPropertyValue(SystemProperties.SMTP_FROM);
            TextBoxSmtpServer.Text = LocalUser.GetPropertyValue(SystemProperties.SMTP_SERVER);
            TextBoxSmtpLogin.Text = LocalUser.GetPropertyValue(SystemProperties.SMTP_LOGIN);
            TextBoxLocalNetworks.Text = LocalUser.GetPropertyValue(SystemProperties.SESSION_LOCAL_NETWORKS);

            TextBoxRegMailContext.Text = LocalUser.GetPropertyValue(SystemProperties.REGISTER_MAIL);
            TextBoxRegRestore.Text = LocalUser.GetPropertyValue(SystemProperties.RESTORE_MAIL);
        }

        protected void postButton_Click(object sender, EventArgs e)
        {
            var activeView = MultiViewMain.GetActiveView();
            if (activeView == ViewLogin)
            {
                LocalUser.SetPropertyValue(SystemProperties.SESSION_ALLOW_INTRANET, CheckBoxAllowIntranet.Checked ? SystemProperties.SESSION_TRUE : SystemProperties.SESSION_FALSE);
                LocalUser.SetPropertyValue(SystemProperties.SESSION_ALLOW_PUBLIC, CheckBoxAllowPublic.Checked ? SystemProperties.SESSION_TRUE : SystemProperties.SESSION_FALSE);

                LocalUser.SetPropertyValue(SystemProperties.SMTP_FROM, TextBoxFrom.Text.Trim());
                LocalUser.SetPropertyValue(SystemProperties.SMTP_SERVER, TextBoxSmtpServer.Text.Trim());
                LocalUser.SetPropertyValue(SystemProperties.SMTP_LOGIN, TextBoxSmtpLogin.Text.Trim());
                if (TextBoxSmtpPassword.Text.Trim() != String.Empty)
                    LocalUser.SetPropertyValue(SystemProperties.SMTP_PASSWORD, TextBoxSmtpPassword.Text);
                if (LocalUser.GetPropertyValue(SystemProperties.SESSION_LOCAL_NETWORKS) != TextBoxLocalNetworks.Text.Trim())
                    LocalUser.SetPropertyValue(SystemProperties.SESSION_LOCAL_NETWORKS, TextBoxLocalNetworks.Text.Trim());

                LocalUser.SetPropertyValue(SystemProperties.REGISTER_MAIL, TextBoxRegMailContext.Text.Trim());
                LocalUser.SetPropertyValue(SystemProperties.RESTORE_MAIL, TextBoxRegRestore.Text.Trim());
            }
            else if (activeView == ViewAnonym)
            {
                string value = String.Empty;
                if (radioButtonNone.Checked)
                    value = "-1";
                else if (radioButtonAll.Checked)
                    value = "0";
                else
                {
                    TestorTreeItem selFolder = (ViewState["SelectedFolder"] as TestorTreeItem);
                    if (selFolder == null)
                        value = "-1";
                    else
                        value = selFolder.ItemId.ToString();
                }
                LocalUser.HelperService.SetPropertyValue(SystemProperties.ANONYMOUS_POLICY, value);
            }
            else if (activeView == ViewUserDetails)
            {
                if (TextBoxPassword.Text != String.Empty || TextBoxSecondPassword.Text != String.Empty)
                {
                    if (TextBoxPassword.Text != TextBoxSecondPassword.Text)
                    {
                        aspErrorMessage.Text = "Пароли не совпадают";
                        aspErrorMessage.Visible = true;
                        return;
                    }
                    else
                    {
                        using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
                        {
                            var user = dataContext.Users.Where(c => c.UserId == (int)GridViewUsers.SelectedValue).FirstOrDefault();
                            if (user == null || user.UserRole != (short)TestorUserRole.Student)
                            {
                                aspErrorMessage.Text = "Ошибка. Не выбран пользователь";
                                aspErrorMessage.Visible = true;
                                return;
                            }
                            user.Password = TextBoxPassword.Text;
                            dataContext.SubmitChanges();
                        }
                    }
                }
            }
            changesIndicator.Text = String.Format(" Изменения сохранены [{0}]", DateTime.Now.ToShortTimeString());
            changesIndicator.Visible = true;
        }

        protected void TreeViewTests_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (TreeViewTests.SelectedNode.Parent != null)
            {
                TestorTreeItem tti = new TestorTreeItem();
                tti.ItemId = int.Parse(TreeViewTests.SelectedNode.Value);
                ViewState["SelectedFolder"] = tti;
                lbSelectedFolder.Text = TreeViewTests.SelectedNode.Text;
            }
        }

        protected void LinkButtonChangePassword_Click(object sender, EventArgs e)
        {
            int userId = (int)GridViewUsers.SelectedValue;
            LabelUserName.Text = selUser.Text;
            MultiViewMain.ActiveViewIndex = 3;
            postButton.Visible = true;
        }

        protected void LinkButtonBack_Click(object sender, EventArgs e)
        {
            MultiViewMain.ActiveViewIndex = 2;
            postButton.Visible = false;
        }
    }
}
