using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using Cnit.Testor.Core;
using Cnit.Testor.Core.Server.Services;
using Cnit.Testor.Core.HttpServer;
using System.Web.Security;

namespace CoreWebClient
{
    public partial class TestingForm : System.Web.UI.Page
    {
        private const string SESSIONPROVIDER = "provider";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadComplete += new EventHandler(TestingForm_LoadComplete);
            warningMessage.Visible = false;
            RemoteTestingProvider provider = null;
            StartTestParams startParams = LocalUser.TestClient.GetNotCommitedSessions(0, false);
            if (Session[SESSIONPROVIDER] == null)
            {
                if (startParams == null)
                    Response.Redirect("~/Default.aspx");
                var testSettings = startParams.TestSettings;
                TestorData.CoreTestsRow coreTest = testSettings.CoreTests[0];
                TestorTreeItem selectedTest = new TestorTreeItem(0, coreTest.TestId, coreTest.TestName,
                   coreTest.IsMasterTest ? TestorItemType.MasterTest : TestorItemType.Test, null);
                provider = new RemoteTestingProvider(LocalUser.WebServerProvider, selectedTest, testSettings, startParams, false);
                provider.ProviderMode = ProviderMode.WebMode;
                Session[SESSIONPROVIDER] = provider;
            }
            else
            {
                provider = (RemoteTestingProvider)Session[SESSIONPROVIDER];
                if (provider == null || provider.State == ProviderState.Results)
                {
                    Session[SESSIONPROVIDER] = null;
                    if (LocalUser.IsIntranet && provider.CurrentUser.UserRole == TestorUserRole.Student)
                        FormsAuthentication.SignOut();
                    Response.Redirect("~/Default.aspx");
                }
                provider.UnsubscribeWarningMessage();
            }
            provider.CurrentUniqId = (string)Session["UniqId"];
            if (startParams != null && startParams.AdditionalTime.HasValue)
                provider.AdditionalTime = startParams.AdditionalTime.Value;
            if (!IsPostBack)
            {
                string testName = String.Format("&laquo;{0}&raquo;", provider.TestName);
                (this.Master.FindControl("LabelTest") as Label).Text = testName + " :: <i>" + provider.StudentDisplayName + "</i>";
                this.Title = String.Format("Студент - \"{0}\"", provider.StudentDisplayName);
            }
            TestingHost.InitTestingProcess(provider, ClientScript);
        }

        void TestingForm_LoadComplete(object sender, EventArgs e)
        {
            RemoteTestingProvider provider = (RemoteTestingProvider)Session[SESSIONPROVIDER];
            if (!String.IsNullOrEmpty(provider.WarningMessageContent))
            {
                warningMessage.Text = provider.WarningMessageContent;
                warningMessage.Visible = true;
            }
            securityAlert.Visible = provider.ShowSecurityAlert;
            secondComputerAddress.Text = provider.SecondComputerAddress;
        }
    }
}
