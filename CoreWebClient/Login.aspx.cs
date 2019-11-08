using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;

namespace CoreWebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["stat"] == "logOut")
            {
                SignOut();
                Response.Redirect("Login.aspx");
            }
            if (Context.User.Identity.IsAuthenticated)
                Response.Redirect("Default.aspx");
            PanelLoginContent.Visible = true;
            lblWrongPassword.Visible = false;
            this.Master.FindControl("helloPanel").Visible = false;
            if (LocalUser.IsIntranet && Request["mode"] == null)
            {
                MultiView1.ActiveViewIndex = 1;
                BtnUserSearch_Click(this, new EventArgs());
            }
            else
                MultiView1.ActiveViewIndex = 0;
        }

        protected void Btn_enter_Click(object sender, EventArgs e)
        {
            User user = TestorUserNameValidator.WebValidate(TextboxLogin.Text, TextboxPassword.Text);
            if (user != null)
            {
                if (user.Status == (short)TestorUserStatus.Removed || user.Status == (short)TestorUserStatus.LocalNetUser || 
                    user.Status == (short)TestorUserStatus.Any)
                {
                    LabelWrongUserNamePassword.Text = "Неверное имя пользователя и/или пароль";
                    LabelWrongUserNamePassword.Visible = true;
                }
                else if (user.Status == (short)TestorUserStatus.NotActivated)
                {
                    LabelWrongUserNamePassword.Text = "Пользователь не активирован";
                    LabelWrongUserNamePassword.Visible = true;
                }
                else
                {
                    LabelWrongUserNamePassword.Visible = false;
                    FormsAuthentication.RedirectFromLoginPage(TextboxLogin.Text, ChRememberMe.Checked);
                }
            }
            else
            {
                LabelWrongUserNamePassword.Text = "Неверное имя пользователя и/или пароль";
                LabelWrongUserNamePassword.Visible = true;
            }
        }

        private void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        protected void BtnUserSearch_Click(object sender, EventArgs e)
        {
            TestorCoreUser[] users = UserSearchHelper.FindAllLocalStudents(userName.Text);

            GridViewUsers.EmptyDataText = String.Format("Поиск: <b>{0}*</b>. Пользователи не найдены.", userName.Text);
            GridViewUsers.DataKeyNames = new string[] { "UserId" };
            GridViewUsers.DataSource = users;
            GridViewUsers.DataBind();
            if (users.Count() == 1)
            {
                GridViewUsers.SelectedIndex = 0;
                GridViewUsers_SelectedIndexChanged(sender, e);
            }
        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsers.PageIndex = e.NewPageIndex;
            BtnUserSearch_Click(sender, new EventArgs());
            GridViewUsers.SelectedIndex = -1;
            GridViewUsers_SelectedIndexChanged(sender, e);
        }

        protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewUsers.SelectedValue != null)
            {
                selUser.Text = String.Format("<font size=\"6pt\">{0} {1} {2}</font>", GridViewUsers.SelectedRow.Cells[1].Text,
                    GridViewUsers.SelectedRow.Cells[2].Text, GridViewUsers.SelectedRow.Cells[3].Text);
                selUserPlace.Visible = true;
            }
            else
                selUserPlace.Visible = false;
        }

        protected void postButton_Click(object sender, EventArgs e)
        {
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                if (GridViewUsers.SelectedValue != null)
                {
                    var user = dataContext.Users.Where(c => c.UserId == (int)GridViewUsers.SelectedValue).First();
                    if (user.Status != (short)TestorUserStatus.LocalNetUser)
                    {
                        lblWrongPassword.Visible = true;
                        return;
                    }
                    string password = selUserPassword.Text;
                    if (String.IsNullOrEmpty(password))
                        password = "{@#emptypassword#}";
                    if (user.Password != password)
                    {
                        lblWrongPassword.Visible = true;
                        return;
                    }
                    else
                        FormsAuthentication.RedirectFromLoginPage(user.Login, false);
                }
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            userName.Text = String.Empty;
            GridViewUsers.SelectedIndex = -1;
            GridViewUsers_SelectedIndexChanged(sender, e);
            BtnUserSearch_Click(sender, e);
        }
    }
}
