using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.HttpServer;

namespace CoreWebClient.Manage
{
	public partial class TestStatisticsPage : System.Web.UI.Page
	{
		private int _testId = 0;
		private int _groupId = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Title = "Статистика теста";

			if (!Context.User.Identity.IsAuthenticated)
				Response.Redirect("~/Default.aspx");

			if (LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Teacher &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Laboratorian &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
				Response.Redirect("~/Default.aspx");

			string tid = Request["testId"];
			if (!int.TryParse(tid, out _testId))
				Response.Redirect("~/Default.aspx");

			int.TryParse(Request["groupId"], out _groupId);
			if (_groupId != 0)
			{
				var tti = LocalUser.TestEdit.GetServerTree(_groupId, 1, TestingServerItemType.GroupTree);
				if (tti.Length > 0)
					lblGroup.Text = tti[0].ItemName;
			}
			phGroup.Visible = _groupId != 0;
			GetTestStatistics();
		}

		public void GetTestStatistics()
		{
			TestorData td = DataCompressor.DecompressData<TestorData>(
					   LocalUser.TestEdit.GetTestSettings(_testId));
			var test = td.CoreTests[0];

			lblTest.Text = test.TestName;
			lblQuestionsNumber.Text = test.QuestionsNumber.ToString();
			lblPassingScore.Text = test.PassingScore.ToString();

			var tStat = LocalUser.TestClient.GetTestStatistics(_testId, _groupId);
			if (tStat.AverageScore.HasValue)
				lblAverageScore.Text = tStat.AverageScore.Value.ToString("0.00");
			else
				lblAverageScore.Text = "-";
			lblPassedPercent.Text = tStat.PassedPercent.ToString("0.00");

			if (tStat.TestStatistics.Length > 20)
			{
				List<TestStatistics> stat1 = new List<TestStatistics>();
				List<TestStatistics> stat2 = new List<TestStatistics>();

				int x = tStat.TestStatistics.Length / 2;

				if (tStat.TestStatistics.Length % 2 > 0)
					x++;

				for (int i = 0; i < tStat.TestStatistics.Count(); i++)
				{
					if (i < x && x > 5)
						stat1.Add(tStat.TestStatistics[i]);
					else
						stat2.Add(tStat.TestStatistics[i]);
				}

				rpScore.DataSource = stat1;
				rpScoreCount.DataSource = stat1;
				rpScore.DataBind();
				rpScoreCount.DataBind();

				rpScore1.DataSource = stat2;
				rpScoreCount1.DataSource = stat2;
				rpScore1.DataBind();
				rpScoreCount1.DataBind();

				phScores.Visible = true;
			}
			else
			{
				rpScore.DataSource = tStat.TestStatistics;
				rpScoreCount.DataSource = tStat.TestStatistics;
				rpScore.DataBind();
				rpScoreCount.DataBind();

				phScores.Visible = false;
			}

			testChart.DataSource = tStat.TestStatistics;
			testChart.DataBind();
		}
	}
}
