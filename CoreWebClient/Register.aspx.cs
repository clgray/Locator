using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;
using System.Web.Security;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace CoreWebClient
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private Random _random = new Random();
        private string[] _pathStrings = new string[] { };
        private int _selectedGroupId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.FindControl("helloPanel").Visible = false;
            if (Context.User.Identity.IsAuthenticated)
                Response.Redirect("Default.aspx");

            string postBackerID = Request.Form.Get("__EVENTTARGET");

            if (postBackerID == "TreeViewClick")
            {
                string[] postBackerArg = Request.Form.Get("__EVENTARGUMENT").Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                _pathStrings = postBackerArg[0].Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                if (_pathStrings[_pathStrings.Length - 1] != "0")
                    groupName.Text = postBackerArg[1];
                else
                    groupName.Text = String.Empty;
                ViewState["SelectedNode"] = _pathStrings[_pathStrings.Length - 1];
                _selectedGroupId = int.Parse(_pathStrings[_pathStrings.Length - 1]);
                TextBoxPassword.Attributes["Value"] = TextBoxPassword.Text;
                TextBoxSecondPassword.Attributes["Value"] = TextBoxSecondPassword.Text;
            }

            if (!this.IsPostBack && LocalUser.IsIntranet)
            {
                MultiViewGroup.ActiveViewIndex = 1;
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                RequiredFieldValidatorLogin.Enabled = false;
                emailPlace.Visible = false;
                loginPlace.Visible = false;
				loginPasswordText.Text = "Пароль и секретный код";
            }
            if(LocalUser.IsIntranet)
                InitGroupTree();
            if (Request["Activate"] != null)
            {
                string activateKey = Request["Activate"];
                using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
                {
                    var key = dataContext.ActivationKeys.Where(c => c.ActivationKey1 == activateKey).FirstOrDefault();
                    if (key == null)
                        Response.Redirect("Default.aspx");
                    if (key.User.Status != (short)TestorUserStatus.NotActivated)
                    {
                        LabelSetNewPasswordError.Visible = false;
                        if (!this.IsPostBack)
                            MultiView1.ActiveViewIndex = 4;
                    }
                    else
                    {
                        key.User.Status = (short)TestorUserStatus.InetUser;
                        string userLogin = key.User.Login;
                        dataContext.ActivationKeys.DeleteOnSubmit(key);
                        dataContext.SubmitChanges();
                        FormsAuthentication.RedirectFromLoginPage(userLogin, false);
                    }
                }
                return;
            }
            else if (Request["Restore"] != null)
            {
                if (!this.IsPostBack)
                {
                    MultiView1.ActiveViewIndex = 2;
                    this.Session["CaptchaImageText"] = GenerateRandomCode();
                }
                LabelRestoreError.Visible = false;
                return;
            }
            else
            {
                if (!this.IsPostBack)
                    this.Session["CaptchaImageText"] = GenerateRandomCode();
                aspErrorMessage.Visible = false;
            }
        }

        protected void ButtonRestore_Click(object sender, EventArgs e)
        {
            if (TextBoxRestoreCaptcha.Text.ToLower() != this.Session["CaptchaImageText"].ToString().ToLower())
            {
                LabelRestoreError.Visible = true;
                LabelRestoreError.Text = "Введён неправильный секретный код";
                TextBoxRestoreCaptcha.Text = String.Empty;
                this.Session["CaptchaImageText"] = GenerateRandomCode();
                return;
            }
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var user = dataContext.Users.Where(c => c.Email == TextBoxRestore.Text.Trim().ToLower()).FirstOrDefault();
                if (user == null)
                {
                    LabelRestoreError.Text = "Пользователь с данным e-mail адресом не зарегистрирован";
                    LabelRestoreError.Visible = true;
                    return;
                }
                else
                {
                    ActivationKey key = new ActivationKey();
                    key.ActivationKey1 = Guid.NewGuid().ToString();
                    key.UserId = user.UserId;
                    dataContext.ActivationKeys.InsertOnSubmit(key);
                    dataContext.SubmitChanges();
                    SendRestoreMail(user.Email, key.ActivationKey1, user.Login);
                    MultiView1.ActiveViewIndex = 3;
                }
            }
        }

        protected void ButtonSetNewPassword_Click(object sender, EventArgs e)
        {
            if (Request["Activate"] == null)
                Response.Redirect("Default.aspx");
            if (TextBoxNewPassword.Text != TextBoxNewPasswordSecond.Text)
            {
                LabelSetNewPasswordError.Text = "Пароли не совпадают";
                LabelSetNewPasswordError.Visible = true;
                return;
            }
            string activateKey = Request["Activate"];
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var key = dataContext.ActivationKeys.Where(c => c.ActivationKey1 == activateKey).FirstOrDefault();
                if (key == null)
                    Response.Redirect("Default.aspx");
                key.User.Password = TextBoxNewPassword.Text;
                dataContext.ActivationKeys.DeleteAllOnSubmit(dataContext.ActivationKeys.Where(c => c.UserId == key.User.UserId));
                dataContext.SubmitChanges();
            }
            MultiView1.ActiveViewIndex = 5;
        }

        private string GenerateRandomCode()
        {
            string s = String.Empty;
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, this._random.Next(10).ToString());
            captchaImage.ImageUrl = String.Format("ImageCapthaHandler.aspx?id={0}", Guid.NewGuid());
            restoreCaptchaImage.ImageUrl = String.Format("ImageCapthaHandler.aspx?id={0}", Guid.NewGuid());
            return s;
        }

        private void SendRestoreMail(string mailTo, string code, string userName)
        {
            MailMessage msg = new MailMessage(LocalUser.GetPropertyValue(SystemProperties.SMTP_FROM), mailTo);
            msg.Subject = "Восстановление пароля";
            string url = Request.Url + "?Activate=" + code;
            string href = String.Format("<a href=\"{0}\">{0}</a>", url);
            AlternateView av = AlternateView.CreateAlternateViewFromString(String.Format(LocalUser.GetPropertyValue(SystemProperties.RESTORE_MAIL), userName, url),
               null, MediaTypeNames.Text.Html);
            msg.AlternateViews.Add(av);
            msg.IsBodyHtml = true;
            SendMail(msg);
        }

        private void SendActivationMail(string mailTo, string code, string userName)
        {
            MailMessage msg = new MailMessage(LocalUser.GetPropertyValue(SystemProperties.SMTP_FROM), mailTo);

            msg.Subject = "Активация аккаунта";
            string url=Request.Url + "?Activate=" + code;
            string href = String.Format("<a href=\"{0}\">{0}</a>", url);
            AlternateView av = AlternateView.CreateAlternateViewFromString(String.Format(LocalUser.GetPropertyValue(SystemProperties.REGISTER_MAIL), userName, href),
                null, MediaTypeNames.Text.Html);
            msg.AlternateViews.Add(av);
            msg.IsBodyHtml = true;
            SendMail(msg);
        }

        private void SendMail(MailMessage msg)
        {
            SmtpClient client = new SmtpClient(LocalUser.GetPropertyValue(SystemProperties.SMTP_SERVER));
            client.Credentials = new NetworkCredential(LocalUser.GetPropertyValue(SystemProperties.SMTP_LOGIN),
                 LocalUser.GetPropertyValue(SystemProperties.SMTP_PASSWORD));
            client.Send(msg);
        }

        private void InitGroupTree()
        {
			TestorTreeItem[] items = LocalUser.TestEdit.GetServerTree(0, 0, TestingServerItemType.GroupTree);

            StringBuilder sb = new StringBuilder();

            sb.Append("<ul id=\"groupTreeMainUl\" class=\"filetree\">");
            sb.Append("<li><span class=\"group\" value=\"0\" id=\"groupNode\">Группы</span><ul>");
            AddTreeNodes(items, sb, "0", 1);
            sb.Append("</ul></li></ul>");

            grpTree.Text = sb.ToString();
        }

        public void AddTreeNodes(TestorTreeItem[] items, StringBuilder sb, string path, int level)
        {
            foreach (var newItem in items)
            {
                string classStr = " class=\"closed\"";
                if (level < 2 || _pathStrings.Contains(newItem.ItemId.ToString()))
                    classStr = String.Empty;

                if (newItem.SubItems.Length > 0)
                {
                    sb.AppendFormat("<li{2}><span class=\"folder\" value=\"{1}\">{0}</span>", newItem.ItemName, newItem.ItemId.ToString(), classStr);
                    sb.Append("<ul>");
                    AddTreeNodes(newItem.SubItems, sb, path + "::" + newItem.ItemId.ToString(), level + 1);
                    sb.Append("</ul>");
                }
                else
                {
                    string stypeStr = String.Empty;
                    if (newItem.ItemId == _selectedGroupId)
                        stypeStr = " style=\"color:red;\"";
                    sb.AppendFormat("<li {3}><span class=\"folder\"><a href=\"javascript:__doPostBack('TreeViewClick','{2}::{1}@{0}');\"{4}>{0}</a></span>", newItem.ItemName, newItem.ItemId.ToString(), path, classStr, stypeStr);
                }
                sb.Append("</li>");
            }
        }

        protected void Btn_Reg_Click(object sender, EventArgs e)
        {
            int groupId = 0;
            TextBoxPassword.Attributes["Value"] = TextBoxPassword.Text;
            TextBoxSecondPassword.Attributes["Value"] = TextBoxSecondPassword.Text;
            if (LocalUser.IsIntranet)
            {
                if (ViewState["SelectedNode"] != null)
                    int.TryParse((string)ViewState["SelectedNode"], out groupId);

                if (groupId == 0 || ViewState["SelectedNode"] == null)
                {
                    aspErrorMessage.Visible = true;
                    aspErrorMessage.Text = "Выберите группу (Факультет -> Кафедра -> Группа).";
                    return;
                }
            }
            if (TextBoxCaptcha.Text.ToLower() != this.Session["CaptchaImageText"].ToString().ToLower())
            {
                aspErrorMessage.Visible = true;
                aspErrorMessage.Text = "Введён неправильный секретный код";
                TextBoxCaptcha.Text = String.Empty;
                this.Session["CaptchaImageText"] = GenerateRandomCode();
                return;
            }
            else
            {
                TextBoxCaptcha.Text = String.Empty;
                this.Session["CaptchaImageText"] = GenerateRandomCode();
                aspErrorMessage.Visible = false;
            }
            if (TextBoxLogin.Text.Trim().Contains(' ') || TextBoxPassword.Text.Contains(' '))
            {
                aspErrorMessage.Visible = true;
                aspErrorMessage.Text = "Логин и пароль не могут содержать пробелы";
                return;
            }
            if (TextBoxPassword.Text != TextBoxSecondPassword.Text)
            {
                aspErrorMessage.Visible = true;
                aspErrorMessage.Text = "Пароли не совпадают";
                return;
            }
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                string eMail = TextBoxEmail.Text.Trim().ToLower();
                if (!String.IsNullOrEmpty(eMail) && dataContext.Users.Where(c => c.Email == eMail).Count() > 0)
                {
                    aspErrorMessage.Visible = true;
                    aspErrorMessage.Text = "Данный e-mail уже используется";
                    return;
                }
                if (!LocalUser.IsIntranet)
                {
                    if (TextBoxGroup.Text.Trim() != String.Empty)
                    {
                        groupId = dataContext.GetGroupIdByCode(TextBoxGroup.Text.Trim());
                        if (groupId == 0)
                        {
                            aspErrorMessage.Visible = true;
                            aspErrorMessage.Text = "Неверный код группы";
                            return;
                        }
                    }
                }
                TestorTreeItem[] groups = new TestorTreeItem[] { };
                if (groupId != 0)
                {
                    TestorTreeItem group = new TestorTreeItem(groupId, 0, String.Empty, TestorItemType.Group, new TestorTreeItem[] { });
                    groups = new TestorTreeItem[] { group };
                }
                string password = TextBoxPassword.Text.Trim();
                if (String.IsNullOrEmpty(password))
                    password = "{@#emptypassword#}";
                TestorCoreUser user = new TestorCoreUser()
                {
                    LastName = TextBoxLastName.Text.Trim(),
                    FirstName = TextBoxName.Text.Trim(),
                    SecondName = TextBoxSecondName.Text.Trim(),
                    Password = password,
                    Sex = DropDownListGender.SelectedIndex == 0 ? true : false,
                    UserGroups = groups,
                    UserRole = TestorUserRole.Student,
                    Status = LocalUser.IsIntranet ? TestorUserStatus.LocalNetUser : TestorUserStatus.NotActivated,
                    StudNumber = TextBoxStudNumber.Text.Trim()
                };
                if (LocalUser.IsIntranet)
                {
                    user.Login = Guid.NewGuid().ToString();
                    user.IsLocalUser = true;
                    user.Email = String.Format("{0}@{1}.testor.ru", user.Login, Guid.NewGuid().ToString());
                }
                else
                {
                    user.Login = TextBoxLogin.Text.Trim();
                    user.Email = TextBoxEmail.Text.Trim().ToLower();
                }
                try
                {
                    TestorCoreUser coreUser = LocalUser.UserManagement.CreateUser(user);
                    ActivationKey key = new ActivationKey();
                    key.ActivationKey1 = Guid.NewGuid().ToString();
                    key.UserId = coreUser.UserId;
                    dataContext.ActivationKeys.InsertOnSubmit(key);
                    if (LocalUser.IsIntranet)
                    {
                        dataContext.SubmitChanges();
                        FormsAuthentication.RedirectFromLoginPage(coreUser.Login, false);
                        return;
                    }
                    else
                    {
                        dataContext.SubmitChanges();
                        SendActivationMail(coreUser.Email, key.ActivationKey1, coreUser.Login);
                    }
                }
                catch (Exception ex)
                {
                    aspErrorMessage.Visible = true;
                    aspErrorMessage.Text = ex.Message;
                    return;
                }
                MultiView1.ActiveViewIndex = 1;
            }
        }
    }
}
