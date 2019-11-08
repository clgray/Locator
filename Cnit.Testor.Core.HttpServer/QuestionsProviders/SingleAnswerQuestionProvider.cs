using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.HttpServer.QuestionsProviders
{
	public sealed class SingleAnswerQuestionProvider : BaseQuestionProvider
	{
		public SingleAnswerQuestionProvider(HtmlStore htmlStore)
			: base(htmlStore)
		{
		}

		public override bool SendAnswersToClient
		{
			get
			{
				return true;
			}
		}

		public override string ProcessHtml()
		{
			StringBuilder sb = new StringBuilder();
			int[] answers = GetStudentAnswersIds();
			sb.Append("<table border=\"0\" cellpadding=\"0px\" cellspacing=\"1px\" id=\"mainInputTable\">");
			foreach (var quest in _htmlStore.RandomSubItems)
			{
				if (_htmlStore.IsAppeal)
				{
					string color = GetAnswerColor(answers.Contains(quest.QuestIndex), quest.IsTrue);
					string bColor = color == "black" ? "white" : color;
					if (answers.Contains(quest.QuestIndex))
						sb.AppendFormat(
							"<tr><td><input type=\"radio\" name=\"tcv_testorradio\" value=\"{0}\"  checked=\"yes\" disabled style=\"background : {1};\"></td><td>",
							quest.QuestIndex, bColor);
					else
						sb.AppendFormat(
							"<tr><td><input type=\"radio\" name=\"tcv_testorradio\" value=\"{0}\" disabled style=\"background : {1};\"></td><td>", quest.QuestIndex,
							bColor);
					sb.AppendFormat("<font color=\"{0}\">&nbsp;", color);
					sb.Append(quest.NoBrHtml);
					if (quest.IsTrue)
						sb.Append("</font>");
					sb.Append("</td></tr>");
				}
				else
				{
					sb.AppendFormat(
						"<tr><td><input type=\"radio\" name=\"tcv_testorradio\" id=\"{1}\" value=\"{0}\"></td><td>", quest.QuestIndex, "qwe" + quest.QuestIndex);
					sb.AppendFormat("<label for=\"{1}\">{0}</label>", quest.NoBrHtml, "qwe" + quest.QuestIndex);
					sb.Append("</td></tr>");
				}
			}
			sb.Append("</table>");
			return sb.ToString();
		}

		public override bool? IsRightAnswer(Dictionary<string, List<string>> _requestParams, ref string message, ref string questAnswer)
		{
			List<int> ansIds = GetAnsIds(_requestParams, "tcv_testorradio", ref questAnswer);
			if (ansIds == null || ansIds.Count == 0)
				return false;
			var rightAns = _htmlStore.SubItems.Where(c => c.IsTrue == true);
			if (rightAns.Count() == 0)
				return false;
			int rightId = rightAns.First().QuestIndex;
			if (ansIds[0] == rightId)
				return true;
			return false;
		}
	}
}
