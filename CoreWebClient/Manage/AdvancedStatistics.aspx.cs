using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core;
using CoreWebClient.Code;
using System.Text;

namespace CoreWebClient.Manage
{
	public partial class AdvancedStatistics : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Context.User.Identity.IsAuthenticated)
				Response.Redirect("~/Default.aspx");
			if (LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Teacher &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Laboratorian &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
				Response.Redirect("~/Default.aspx");
			try
			{
				InitStgatistics();
			}
			catch
			{
				Response.Redirect("~/Default.aspx");
			}
		}

		private void InitStgatistics()
		{
			var statistics = StatisticsHelper.GetStatistics(ScoreType.PassingScore, 0, 0, 0, 0);
			StringBuilder sb = new StringBuilder();
			int i = 0;
			foreach (var stat in statistics)
			{
				i++;
				sb.Append("<hr/><div style=\"background-color:Silver;padding:5px;\">");
				sb.AppendFormat("№{3} Пользователь: <b>{0} {1} {2}</b><br/>", stat.LastName, stat.FirstName, stat.SecondName, i.ToString());
				sb.AppendFormat("Набранный Балл: <b>{0}</b><br/>", stat.Score.HasValue ? stat.Score.Value.ToString() : String.Empty);
				sb.AppendFormat("Тест: <i>\"{0}\"</i><br/>", stat.TestName);
				sb.AppendFormat("Время начала тестирования: {0}<br/>", stat.StartTime.ToString());
				sb.Append("</div><br/>");
				string statHtml = LocalUser.TestClient.GetAppealHtml(stat.TestSessionId);
				sb.Append(statHtml);
			}
			htmlContent.Text = sb.ToString();
		}
	}
}
