using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core;
using Cnit.Testor.Core.Server;

namespace CoreWebClient
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/Default.aspx");
            if (!IsPostBack)
                InitAppointedTests();
            var currentUser = LocalUser.SecurityProvider.CurrentUser;
            string userName = String.Format(":: {0} {1} {2}", HtmlStore.GetString(currentUser.LastName),
                 HtmlStore.GetString(currentUser.FirstName), HtmlStore.GetString(currentUser.SecondName));
            Label lbl = (this.Master.FindControl("userName") as Label);
            if (String.IsNullOrEmpty(userName.Trim()))
                lbl.Text = currentUser.Login;
            else
                lbl.Text = userName;
            TestorCoreUser user = LocalUser.SecurityProvider.CurrentUser;
            if (LocalUser.IsIntranet)
                user.Email = "скрыт";
            user.UserGroups = LocalUser.UserManagement.GetUserGroups(user.UserId);
            userForm.DataSource = new TestorCoreUser[] { user };
            userForm.DataBind();

            List<TestSessionStatistics> statistics = new List<TestSessionStatistics>();
            statistics.AddRange(LocalUser.TestClient.GetStatistics(new DateTime(1900, 1, 1), DateTime.MaxValue,
                0, 0, LocalUser.SecurityProvider.CurrentUser.UserId));
            GridViewSessions.DataSource = statistics;
            GridViewSessions.DataBind();
        }

        private void InitAppointedTests()
        {
            TestorTreeItem[] appTests = LocalUser.TestClient.GetAppointedTests();
            appointedTests.Visible = appTests.Length > 0;
            appointedTests.DataSource = appTests;
            appointedTests.DataBind();
        }

        protected void userForm_Load(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            if (LocalUser.SecurityProvider.CurrentUser.Sex == true)
                ddl.SelectedIndex = 0;
            else
                ddl.SelectedIndex = 1;
        }
    }
}
