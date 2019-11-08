using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Cnit.Testor.Core;

namespace CoreWebClient
{
    public partial class TestingMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Teacher ||
                LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Laboratorian ||
                LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Administrator)
                PlaceHolderStat.Visible = true;
            PlaceHolderAdmin.Visible = LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Administrator;
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
                Response.Redirect("/Login.aspx?ReturnUrl=Default.aspx");
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect("/Default.aspx");
            }
        }
    }
}