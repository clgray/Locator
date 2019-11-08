using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;
using Cnit.Testor.Core.Packaging;
using CoreWebClient.Code;

namespace CoreWebClient
{
	public partial class StatisticsForm : System.Web.UI.Page
	{
		private List<TestSessionStatistics> _statistics = new List<TestSessionStatistics>();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Context.User.Identity.IsAuthenticated)
				Response.Redirect("~/Default.aspx");
			if (LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Teacher &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Laboratorian &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
				Response.Redirect("~/Default.aspx");
			if (!Page.IsPostBack)
			{
				CalendarStart.SelectedDate = DateTime.Now.Date;
				CalendarEnd.SelectedDate = DateTime.Now.Date;
				ViewState["SelectedTest"] = null;
				ViewState["SelectedGroup"] = null;
				ViewState["SelectedUser"] = null;
				ViewState["sUser"] = null;
				ViewState["sGroup"] = null;
				ViewState["sTest"] = null;

				DateTime sDate = CalendarStart.SelectedDate;
				DateTime eDate = CalendarEnd.SelectedDate;

				ViewState["StartTime"] = new DateTime(sDate.Year, sDate.Month, sDate.Day, 0, 0, 0);
				ViewState["EndTime"] = new DateTime(eDate.Year, eDate.Month, eDate.Day, 23, 59, 0);
			}

			InitSettings();

			if (!IsPostBack)
				GetStatistics();
			// Если выбран  MultiView с фильтром по пользователю, то грузим скрипт AutoComplete-а 
			if (MultiView1.ActiveViewIndex == 1)
			{
				ScriptManager.RegisterClientScriptBlock(this, typeof(StatisticsForm), "Users_autocomplete", GetAutoCompleteScript(), true);
			}
		}

		private void InitSettings()
		{
			if (ViewState["StartTime"] == null)
			{
				DateTime sDate = CalendarStart.SelectedDate;
				ViewState["StartTime"] = new DateTime(sDate.Year, sDate.Month, sDate.Day, 0, 0, 0);
			}

			if (ViewState["EndTime"] == null)
			{
				DateTime eDate = CalendarEnd.SelectedDate;
				ViewState["EndTime"] = new DateTime(eDate.Year, eDate.Month, eDate.Day, 23, 59, 0);
			}

			if (ViewState["SelectedTest"] == null)
			{
				if (Request["testId"] == null)
					ViewState["SelectedTest"] = "0";
				else
				{
					ViewState["SelectedTest"] = Request["testId"];
					int testId = 0;
					if (!int.TryParse(ViewState["SelectedTest"].ToString(), out testId))
						Response.Redirect("~/Default.aspx");
					var testData = DataCompressor.DecompressData<TestorData>(LocalUser.TestEdit.GetTestSettings(testId));
					ViewState["sTest"] = testData.CoreTests[0].TestName;
				}
			}
			if (ViewState["SelectedGroup"] == null)
				ViewState["SelectedGroup"] = "0";
			if (ViewState["SelectedUser"] == null)
				ViewState["SelectedUser"] = 0;
			if (ViewState["sUser"] == null)
			{
				ViewState["sUser"] = String.Empty;
				ViewState["sGroup"] = String.Empty;
				if (ViewState["sTest"] == null)
					ViewState["sTest"] = String.Empty;
			}
		}

		public void GetStatistics()
		{
			InitSettings();

			TestSessionStatistics[] result = LocalUser.TestClient.GetStatistics((DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"],
				int.Parse((string)ViewState["SelectedGroup"]), int.Parse((string)ViewState["SelectedTest"]),
				(int)ViewState["SelectedUser"]);

			result = StatisticsHelper.SortStatistics(result, ViewState["SortExpression"], ViewState["SortDirection"]);

			_statistics.Clear();
			_statistics.AddRange(result);

			GridViewMain.DataSource = _statistics;
			GridViewMain.DataBind();
			selectedDate.Text = String.Format("{0} &ndash; {1}", CalendarStart.SelectedDate.ToString("dd MMMM yyyy"), CalendarEnd.SelectedDate.ToString("dd MMMM yyyy"));
			selectedUser.Text = (int)ViewState["SelectedUser"] == 0 ? "не выбран" : (string)ViewState["sUser"];
			if ((string)ViewState["SelectedTest"] == "0")
			{
				selectedTest.Text = "не выбран";
				phSelTestDetails.Visible = false;
			}
			else
			{
				selectedTest.Text = (string)ViewState["sTest"];
				phSelTestDetails.Visible = true;
				selTestDetails.NavigateUrl = String.Format("~/Manage/TestStatistics.aspx?testId={0}&groupId={1}",
					ViewState["SelectedTest"], ViewState["SelectedGroup"]);

			}
			selectedGroup.Text = (string)ViewState["SelectedGroup"] == "0" ? "не выбрана" : (string)ViewState["sGroup"];

			InitPringUrl();
		}

		protected void CalendarStart_SelectionChanged(object sender, EventArgs e)
		{
			applyTime_Click(sender, e);
		}

		protected void GridViewMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			GetStatistics();
			GridViewMain.PageIndex = e.NewPageIndex;
			GridViewMain.DataBind();
		}

		protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			BtnUserSearch_Click(sender, new EventArgs());
			GridViewUsers.PageIndex = e.NewPageIndex;
			GridViewUsers.DataBind();
		}

		protected void LinkButtonUser_Click(object sender, EventArgs e)
		{
			LinkButtonDate.Font.Bold = false;
			LinkButtonUser.Font.Bold = false;
			LinkButtonTest.Font.Bold = false;
			LinkButtonGroup.Font.Bold = false;
			LinkButtonAddTime.Font.Bold = false;
			lbPrint.Font.Bold = false;
			if (sender == LinkButtonDate)
			{
				MultiView1.ActiveViewIndex = 0;
				LinkButtonDate.Font.Bold = true;
			}
			else if (sender == LinkButtonUser)
			{
				MultiView1.ActiveViewIndex = 1;
				LinkButtonUser.Font.Bold = true;
				ScriptManager.RegisterClientScriptBlock(this, typeof(StatisticsForm), "Users_autocomplete", GetAutoCompleteScript(), true);
			}
			else if (sender == LinkButtonTest)
			{
				MultiView1.ActiveViewIndex = 2;
				LinkButtonTest.Font.Bold = true;
				if (TreeViewTest.Nodes.Count == 0)
					InitTree();
			}
			else if (sender == LinkButtonGroup)
			{
				MultiView1.ActiveViewIndex = 3;
				LinkButtonGroup.Font.Bold = true;
				if (TreeViewGroup.Nodes.Count == 0)
					InitGroupTree();
			}
			else if (sender == LinkButtonAddTime)
			{
				MultiView1.ActiveViewIndex = 4;
				LinkButtonAddTime.Font.Bold = true;
				addMessage.Visible = false;
			}
			else if (sender == lbPrint)
			{
				MultiView1.ActiveViewIndex = 5;
				lbPrint.Font.Bold = true;
			}
		}

		protected void BtnUserSearch_Click(object sender, EventArgs e)
		{
			TestorCoreUser[] users = UserSearchHelper.FindUsers(userName.Text, TestorUserRole.NotDefined, TestorUserStatus.Any, 0, false);

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

		protected void GridViewUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			ViewState["SelectedUser"] = (int)GridViewUsers.SelectedValue;
			ViewState["sUser"] = String.Format("{0} {1} {2}", GridViewUsers.SelectedRow.Cells[1].Text,
					GridViewUsers.SelectedRow.Cells[2].Text, GridViewUsers.SelectedRow.Cells[3].Text);
			GetStatistics();
		}

		private void InitGroupTree()
		{
			TreeViewGroup.Nodes.Clear();
			TreeNode rootNode = new TreeNode("Группы", "0", "~/Images/computer.png");
			TreeViewGroup.Nodes.Add(rootNode);
			var items = LocalUser.TestEdit.GetServerTree(0, 0, TestingServerItemType.GroupTree);
			if (items.Length == 1)
				AddTreeNodes(items[0].SubItems, rootNode, true);
			else
				AddTreeNodes(items, rootNode, true);
			rootNode.Expand();
		}

		private void InitTree()
		{
			TreeViewTest.Nodes.Clear();
			TreeNode rootNode = new TreeNode("Все тесты", "0", "~/Images/computer.png");
			TreeViewTest.Nodes.Add(rootNode);
			var items = LocalUser.TestEdit.GetServerTree(0, 0, TestingServerItemType.TestTree);
			if (items.Length == 1)
				AddTreeNodes(items[0].SubItems, rootNode, false);
			else
				AddTreeNodes(items, rootNode, false);
			rootNode.Expand();
		}

		public void AddTreeNodes(TestorTreeItem[] items, TreeNode parent, bool isGroupTree)
		{
			foreach (var newItem in items)
			{
				TreeNode newNode = new TreeNode();
				switch (newItem.ItemType)
				{
					case TestorItemType.Folder:
						{
							newNode.ImageUrl = "~/Images/imgFolder.png";
						}
						break;
					case TestorItemType.Test:
						{
							newNode.ImageUrl = "~/Images/imgTest.png";
						}
						break;
					case TestorItemType.MasterTest:
						{
							newNode.ImageUrl = "~/Images/imgTest.png";
						}
						break;
					case TestorItemType.Group:
						{
							newNode.ImageUrl = "~/Images/imgFolder.png";
						}
						break;
				}
				if (isGroupTree)
					newNode.Value = newItem.ItemId.ToString();
				else
					newNode.Value = newItem.TestId.ToString();
				newNode.Text = newItem.ItemName;
				parent.ChildNodes.Add(newNode);
				AddTreeNodes(newItem.SubItems, newNode, isGroupTree);
			}
		}

		protected void TreeViewTest_SelectedNodeChanged(object sender, EventArgs e)
		{
			ViewState["SelectedTest"] = TreeViewTest.SelectedValue;
			ViewState["sTest"] = TreeViewTest.SelectedNode.Text;
			GetStatistics();
		}

		protected void TreeViewGroup_SelectedNodeChanged(object sender, EventArgs e)
		{
			ViewState["SelectedGroup"] = TreeViewGroup.SelectedValue;
			ViewState["sGroup"] = TreeViewGroup.SelectedNode.Text;
			GetStatistics();
		}

		protected void ButtonClear_Click(object sender, EventArgs e)
		{
			userName.Text = String.Empty;
			GridViewUsers.SelectedIndex = -1;
			ViewState["SelectedUser"] = 0;
			GetStatistics();
		}

		protected void LinkButtonRefresh_Click(object sender, EventArgs e)
		{
			GetStatistics();
		}

		protected void InitPringUrl()
		{
			hlPrint.NavigateUrl = String.Format("StatisticsPrint.aspx?{0}", GerRequestStr());
			hlPrint.Target = rblFormat.SelectedValue == "html" ? "_blank" : "_self";
		}

		private string GerRequestStr()
		{
			string retValue = String.Format(
				"StartTime={0}&EndTime={1}&SelectedGroup={2}&SelectedTest={3}&SelectedUser={4}&SortExpression={5}&SortDirection={6}&type={7}",
				ViewState["StartTime"].ToString(),
				ViewState["EndTime"].ToString(),
				ViewState["SelectedGroup"].ToString(),
				ViewState["SelectedTest"].ToString(),
				ViewState["SelectedUser"].ToString(),
				ViewState["SortExpression"],
				ViewState["SortDirection"],
				rblFormat.SelectedValue);

			string add = String.Empty;
			ScoreType st = ScoreType.PassingScore;
			if (rbScore.Checked)
			{
				st = ScoreType.Score;
				add = "&score=" + (String.IsNullOrEmpty(tbScore.Text.Trim()) ? "0" : tbScore.Text.Trim());
			}
			else if (rbMark.Checked)
			{
				st = ScoreType.Mark;
				add = String.Format("&five={0}&four={1}&three={2}",
					String.IsNullOrEmpty(tbMark5.Text.Trim()) ? "0" : tbMark5.Text.Trim(),
					String.IsNullOrEmpty(tbMark4.Text.Trim()) ? "0" : tbMark4.Text.Trim(),
					String.IsNullOrEmpty(tbMark3.Text.Trim()) ? "0" : tbMark3.Text.Trim());
			}
			else if (rbPercent.Checked)
			{
				st = ScoreType.Percent;
			}

			retValue += String.Format("&scoreType={0}{1}", ((int)st).ToString(), add);
			return retValue;
		}

		protected void GridViewMain_Sorting(object sender, GridViewSortEventArgs e)
		{
			string oldExpr = ViewState["SortExpression"] == null ? String.Empty : (string)ViewState["SortExpression"];
			string sortExpression = e.SortExpression;
			ViewState["SortExpression"] = sortExpression;
			if (ViewState["SortDirection"] == null || sortExpression != oldExpr)
				ViewState["SortDirection"] = SortDirection.Ascending;
			else
			{
				if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
					ViewState["SortDirection"] = SortDirection.Descending;
				else
					ViewState["SortDirection"] = SortDirection.Ascending;
			}
			GetStatistics();
		}

		protected void applyTime_Click(object sender, EventArgs e)
		{
			string[] sTimeStr = StartTime.Text.Trim().Split(':');
			string[] eTimeStr = EndTime.Text.Trim().Split(':');

			int sTime1 = int.Parse(sTimeStr[0]);
			int sTime2 = int.Parse(sTimeStr[1]);

			int eTime1 = int.Parse(eTimeStr[0]);
			int eTime2 = int.Parse(eTimeStr[1]);


			if (sTime1 > 23)
			{
				StartTime.Text = "00:00";
				return;
			}
			if (eTime1 > 23)
			{
				EndTime.Text = "23:59";
				return;
			}
			if (sTime2 > 59)
			{
				StartTime.Text = "00:00";
				return;
			}
			if (eTime2 > 59)
			{
				EndTime.Text = "23:59";
				return;
			}

			DateTime sDate = CalendarStart.SelectedDate;
			DateTime eDate = CalendarEnd.SelectedDate;

			DateTime startTime = new DateTime(sDate.Year, sDate.Month, sDate.Day, sTime1, sTime2, 0);
			DateTime endTime = new DateTime(eDate.Year, eDate.Month, eDate.Day, eTime1, eTime2, 0);

			ViewState["StartTime"] = startTime;
			ViewState["EndTime"] = endTime;

			GetStatistics();
		}

		string GetAutoCompleteScript()
		{
			string st = @"
    $(document).ready(function() {
    $(""#" + userName.ClientID + @""").autocomplete(""../UserSearchHandler.aspx"", {
        delay: 200,
        minChars: 2,
        matchSubset: 1,
        autoFill: false,
        matchContains: 1,
        cacheLength: 10,
        matchSubset: 10,
        selectFirst: true,
        maxItemsToShow: 10,
        onItemSelect: selectItem
    });
});
function selectItem(li) {
    document.getElementById('" + BtnUserSearch.ClientID + @"').click();    
}";
			return st;

		}

		protected void LinkButtonPrintAdvanced_Click(object sender, EventArgs e)
		{
			Response.Redirect(String.Format("AdvancedStatistics.aspx?{0}", GerRequestStr()));
		}

		protected void btnAddTime_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(txtAddTime.Text))
			{
				addMessage.Visible = true;
				addMessage.Text = String.Format("Введите добавляесое время.");
				return;
			}

			short minutes = short.Parse(txtAddTime.Text);

			int count = LocalUser.TestClient.AddAdditionalTime(minutes, (DateTime)ViewState["StartTime"], (DateTime)ViewState["EndTime"],
			int.Parse((string)ViewState["SelectedGroup"]), int.Parse((string)ViewState["SelectedTest"]),
			(int)ViewState["SelectedUser"]);

			addMessage.Visible = true;
			addMessage.Text = String.Format("Добавлено {0} минут(а). Обновлено сессий: {1}", minutes, count);
		}

		protected void rblFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			InitPringUrl();
		}

		protected void lbApplyPrint_Click(object sender, EventArgs e)
		{
			InitPringUrl();
		}
	}
}
