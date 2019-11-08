using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using System.Text;

namespace CoreWebClient
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private int _sessioId;
        private TestSessionStatistics _statistics;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
                Response.Redirect("~/Default.aspx");
            if (LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Teacher &&
                LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Laboratorian &&
                LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
                Response.Redirect("~/Default.aspx");
            if (!int.TryParse(Request["sessionId"], out _sessioId))
                Response.Redirect("~/Default.aspx");

            _statistics = LocalUser.TestClient.GetSessionStatistics(_sessioId);
            if(_statistics==null)
                Response.Redirect("~/Default.aspx");

            if (!IsPostBack)
            {
                lblAppeal.Text = LocalUser.TestClient.GetAppealHtml(_sessioId);

                lblTest.Text = _statistics.TestName;
                lblUser.Text = String.Format("{0} {1} {2}", _statistics.LastName, _statistics.FirstName, _statistics.SecondName);
                lblLogin.Text = _statistics.Login;
                lblScore.Text = _statistics.Score.HasValue ? _statistics.Score.Value.ToString() : String.Empty;
                lblIPAddress.Text = _statistics.IPAddress;
            }

            scoreError.Visible = false;
            mvDelSession.Visible = LocalUser.SecurityProvider.CurrentUser.UserRole == TestorUserRole.Administrator;
        }

        protected void lbChangeScore_Click(object sender, EventArgs e)
        {
            if (lblScore.Visible == false)
            {
                short score = -1;
                if (short.TryParse(txtScore.Text, out score))
                {
                    if (score >= 0)
                    {
                        LocalUser.TestClient.ChangeSessionScore(_sessioId, score);
                        lblScore.Text = score.ToString();
                    }
                    else
                    {
                        scoreError.Visible = true;
                        return;
                    }
                    lbCancel_Click(sender, e);
                }
                else
                    scoreError.Visible = true;
            }
            else
            {
                lblScore.Visible = false;
                txtScore.Visible = true;
                lbCancel.Visible = true;
                txtScore.Text = _statistics.Score.HasValue ? _statistics.Score.Value.ToString() : String.Empty;
            }   
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            lblScore.Visible = true;
            txtScore.Visible = false;
            lbCancel.Visible = false;
        }

        protected void lbDeleteSession_Click(object sender, EventArgs e)
        {
            mvDelSession.ActiveViewIndex = 1;
        }

        protected void lbDelNo_Click(object sender, EventArgs e)
        {
            mvDelSession.ActiveViewIndex = 0;
        }

        protected void lbDelYes_Click(object sender, EventArgs e)
        {
            LocalUser.TestClient.DeleteSession(_sessioId);
            Server.Transfer("~/Default.aspx");
        }
    }
}
