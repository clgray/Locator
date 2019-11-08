using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core.HttpServer;
using System.Text;
using Cnit.Testor.Core.HttpServer.TestingProviders;

namespace CoreWebClient
{
	public partial class TestingUserControl : System.Web.UI.UserControl
	{
		private const string SESSIONCURRENTQUESTION = "CurrentQuestion";

		private TestingProvider _provider;
		private ClientScriptManager _clientScript;

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		private void InitQuestionHTML()
		{
			Response response = _provider.ProcessReuqest(new string[] { }, new Dictionary<string, List<string>>());
			InitQuestionHTML(response);
		}

		private void InitQuestionHTML(Response response)
		{
			postButton.Visible = true;
			nextButton.Text = "Пропустить";
			nextButton.Visible = _provider.AllowAdmitQuestions;
			scoreLabel.Visible = true;
			MultiViewHeader.ActiveViewIndex = 0;
			endTestPanel.Visible = true;
			if (_provider.State == ProviderState.Testing)
			{
				CurrentQuestNumber.Text = _provider.CurrentQuestNumber.ToString();
				QuestCount.Text = _provider.QuestCount.ToString();
				lblAnsQuestCount.Text = (_provider.QuestCount - _provider.AnsQuestCount).ToString();
				if (_provider.ShowRightAnswersCount)
					scoreLabel.Text = String.Format("Набранный Балл: {0}", _provider.Score);
				else
					scoreLabel.Text = "Набранный Балл: -";
			}
			else if (_provider.State == ProviderState.Results)
			{
				MultiViewHeader.ActiveViewIndex = 1;
				postButton.Visible = false;
				nextButton.Visible = true;
				nextButton.Text = "Завершить тестирование";
				scoreLabel.Visible = false;
				endTestPanel.Visible = false;
			}

			htmlContent.Text = Encoding.UTF8.GetString(response.ResponseArr);
		}

		private bool InitTimeLimit()
		{
			if (_provider.TimeLimit == 0)
				return false;
			double timeLimit = _provider.TimeLimit * 60;
			double currentTime = (DateTime.Now - _provider.TestStartTime).TotalSeconds;
			double remainingTime = timeLimit - currentTime;
            if (remainingTime <= 0)
            {
                _provider.EndTest();
                InitQuestionHTML();
                return true;
            }
            else
            {
                int tlMin = (int)remainingTime / 60;
                int tlSec = (int)remainingTime % 60;
                LabelShowTime.Visible = true;
                if (!Page.IsPostBack)
                {
                    _clientScript.RegisterStartupScript(Page.GetType(), "ShowTime", @"<script type='text/javascript'>
                    var st=" + tlMin.ToString() + ";var ss=" + tlSec.ToString() + ";showTime();</script>");
                }
                LabelShowTime.Text = String.Format("<div id=\"tm\" style=\"text-align:right;font-family:Tahoma;font-size:9pt;display:inline\">{0}:{1}</div>",
                     tlMin, tlSec.ToString("00"));
            }
			return false;
		}

		public void InitTestingProcess(TestingProvider provider, ClientScriptManager clientScript)
		{
			_provider = provider;
			_clientScript = clientScript;
			if (Request["isEnd"] != null && Request["isEnd"] == "true")
			{
				_provider.EndTest();
				InitQuestionHTML();
				return;
			}
			if (InitTimeLimit())
				return;
			if (!this.IsPostBack)
			{
				InitQuestionHTML();
				if (provider.CurrentQuestion == null)
					Response.Redirect("/Default.aspx");
				Session[SESSIONCURRENTQUESTION] = provider.CurrentQuestion.QuestIndex;
			}
			if (Session[SESSIONCURRENTQUESTION] != null)
				_provider.SetQuestId((int)Session[SESSIONCURRENTQUESTION]);
		}

		protected void nextButton_Click(object sender, EventArgs e)
		{
			InitQuestionHTML();
			if (_provider.State != ProviderState.Results)
				Session[SESSIONCURRENTQUESTION] = _provider.CurrentQuestId;
		}

		protected void postButton_Click(object sender, EventArgs e)
		{
			if (_provider.State == ProviderState.Results)
				return;
			string message = String.Empty;
			var requestParams = new Dictionary<string, List<string>>();
			foreach (var key in Request.Form)
			{
				string currentKey = key.ToString();
				List<string> values = new List<string>();

				if (currentKey != "tcv_testortext")
				{
					string[] sv = Request[currentKey].Split(',');
					values.AddRange(sv);
				}
				else
					values.Add(Request[currentKey]);
				requestParams.Add(currentKey, values);
			}
			List<string> questIdList = new List<string>();
			questIdList.Add(Session[SESSIONCURRENTQUESTION].ToString());
			requestParams.Add("questid", questIdList);
			Response response = _provider.ProcessReuqest(new string[] { "system", "answer" }, requestParams);
			InitQuestionHTML(response);
			Session[SESSIONCURRENTQUESTION] = _provider.CurrentQuestId;
		}
	}
}