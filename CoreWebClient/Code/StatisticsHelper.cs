using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cnit.Testor.Core.Server;
using System.Web.UI.WebControls;
using Cnit.Testor.Core;

namespace CoreWebClient.Code
{
	public class StatisticsHelper
	{
		public static TestSessionStatistics[] SortStatistics(TestSessionStatistics[] stat, object sortExpression, object sd)
		{
			TestSessionStatistics[] result = stat;
			if (sortExpression != null)
			{
				SortDirection direction = SortDirection.Ascending;
				if (sd != null)
					direction = (SortDirection)sd;
				string exp = (string)sortExpression;
				if (exp == "StartTime")
				{
					if (direction == SortDirection.Ascending)
						result = result.OrderBy(c => c.StartTime).ToArray();
					else
						result = result.OrderByDescending(c => c.StartTime).ToArray();
				}
				else if (exp == "Score")
				{
					if (direction == SortDirection.Ascending)
						result = result.OrderBy(c => c.Score).ToArray();
					else
						result = result.OrderByDescending(c => c.Score).ToArray();
				}
				else if (exp == "LastName")
				{
					if (direction == SortDirection.Ascending)
						result = result.OrderBy(c => c.LastName).ToArray();
					else
						result = result.OrderByDescending(c => c.LastName).ToArray();
				}
				else if (exp == "FirstName")
				{
					if (direction == SortDirection.Ascending)
						result = result.OrderBy(c => c.FirstName).ToArray();
					else
						result = result.OrderByDescending(c => c.FirstName).ToArray();
				}
				else if (exp == "SecondName")
				{
					if (direction == SortDirection.Ascending)
						result = result.OrderBy(c => c.SecondName).ToArray();
					else
						result = result.OrderByDescending(c => c.SecondName).ToArray();
				}
				else if (exp == "GroupName")
				{
					if (direction == SortDirection.Ascending)
						result = result.OrderBy(c => c.GroupName).ToArray();
					else
						result = result.OrderByDescending(c => c.GroupName).ToArray();
				}
				else if (exp == "TestName")
				{
					if (direction == SortDirection.Ascending)
						result = result.OrderBy(c => c.TestName).ToArray();
					else
						result = result.OrderByDescending(c => c.TestName).ToArray();
				}


				for (int i = 1; i <= result.Length; i++)
				{
					result[i - 1].RowNumber = i;
				}
			}
			return result;
		}

		public static List<TestSessionStatistics> GetStatistics(ScoreType scoreType, int score, int five, int four, int three)
		{
			List<TestSessionStatistics> retValue = new List<TestSessionStatistics>();

			TestSessionStatistics[] result = LocalUser.TestClient.GetStatistics(DateTime.Parse(HttpContext.Current.Request["StartTime"]),
				DateTime.Parse(HttpContext.Current.Request["EndTime"]),
			int.Parse(HttpContext.Current.Request["SelectedGroup"]), int.Parse(HttpContext.Current.Request["SelectedTest"]),
			int.Parse(HttpContext.Current.Request["SelectedUser"]));

			string sortExpression = HttpContext.Current.Request["SortExpression"] != String.Empty ? HttpContext.Current.Request["SortExpression"] : null;
			string sortDirection = HttpContext.Current.Request["SortDirection"] != String.Empty ? HttpContext.Current.Request["SortDirection"] : null;

			object sdval = null;
			if (sortDirection != null)
				sdval = sortDirection == "Ascending" ? SortDirection.Ascending : SortDirection.Descending;

			result = StatisticsHelper.SortStatistics(result, sortExpression, sdval);

			result = result.Where(c => c.Score != -1).ToArray();

			for (int i = 1; i <= result.Length; i++)
			{
				result[i - 1].RowNumber = i;
			}

			foreach (var item in result)
			{
				if (scoreType == ScoreType.Score)
				{
					item.PassingScore = score;
					item.IsPassed = item.Score >= score;
				}
				else if (scoreType == ScoreType.Mark)
				{
					var currentScore = item.Score ?? 0;
					if (currentScore >= three)
						item.Mark = 3;
					if (currentScore >= four)
						item.Mark = 4;
					if (currentScore >= five)
						item.Mark = 5;
				}
			}

			retValue.AddRange(result);
			return retValue;
		}
	}
}
