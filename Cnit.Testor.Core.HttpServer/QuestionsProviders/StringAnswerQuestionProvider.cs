using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.HttpServer.QuestionsProviders
{
	public sealed class StringAnswerQuestionProvider : BaseQuestionProvider
	{
		public StringAnswerQuestionProvider(HtmlStore htmlStore)
			: base(htmlStore)
		{
		}

		public override string ProcessHtml()
		{
            StringBuilder sb = new StringBuilder();
            if (_htmlStore.IsAppeal)
            {
                bool isTrue = false;
                if (_htmlStore.SubItems.Count > 0)
                    isTrue = _htmlStore.AppealIsRight;

                string answer = HtmlStore.GetString(_htmlStore.Answer).Replace(";", String.Empty);

                sb.Append("&nbsp;&nbsp;Верный ответ:&nbsp;&nbsp;");
                sb.Append(_htmlStore.SubItems[0].Html);

                if (isTrue)
                    sb.Append("<br/><font color=\"green\">");
                else if (answer.Length == 0)
                    sb.Append("<br/><font color=\"blue\">");
                else
                    sb.Append("<br/><font color=\"red\">");

				sb.Append("&nbsp;&nbsp;Данный ответ:&nbsp;&nbsp;");
                sb.Append(answer);
                sb.Append("</font>");
				sb.Append("<br/>");
            }
            else
            {
                sb.Append("<br/>&nbsp;&nbsp;Введите ответ:&nbsp;&nbsp");
                sb.Append("<input type=\"text\" name=\"tcv_testortext\" size=\"50\" maxlength=\"100\" onkeydown=\"if(window.event.keyCode==13)return false;\" autocomplete=\"off\"/><br/><br/>");

            }
            return sb.ToString();
		}

        public override bool? IsRightAnswer(Dictionary<string, List<string>> _requestParams, ref string message, ref string questAnswer)
        {
            List<string> ans = GetValueList(_requestParams, "tcv_testortext", ref questAnswer);
            if (ans == null || ans.Count == 0)
                return false;
            string answer = ans[0].Trim();
            var rightAns = _htmlStore.SubItems.Where(c => c.IsTrue == true);
            if (rightAns.Count() == 0)
                return false;
            string right = rightAns.First().Html.Trim();
            if (right == answer)
                return true;
            return false;
        }
	}
}
