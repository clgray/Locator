using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Cnit.Testor.Core.HttpServer.QuestionsProviders
{
    public sealed class DigitAnswerQuestionProvider : BaseQuestionProvider
    {
        public DigitAnswerQuestionProvider(HtmlStore htmlStore)
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
                sb.Append("<br/>&nbsp;&nbsp;Введите ответ:&nbsp;&nbsp;");
                sb.Append("<input type=\"text\" name=\"tcv_testortext\" id=\"defaultCalc\" size=\"50\" maxlength=\"100\" onkeydown=\"if(window.event.keyCode==13)return false;\" autocomplete=\"off\"/><br/><br/>");
            }
            return sb.ToString();
        }

        public override bool? IsRightAnswer(Dictionary<string, List<string>> _requestParams, ref string message, ref string questAnswer)
        {
            List<string> ans = GetValueList(_requestParams, "tcv_testortext", ref questAnswer);
            if (ans == null || ans.Count == 0)
                return false;
            string answer = questAnswer.Replace(';', '.');
            if (answer.EndsWith("."))
                answer = answer.Remove(answer.Length - 1, 1);
            var rightAns = _htmlStore.SubItems.Where(c => c.IsTrue == true);

            if (rightAns.Count() == 0)
                return false;

            string right = rightAns.First().Html.Trim();

            string sep = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            if (sep == ".")
            {
                answer = answer.Replace(",", ".");
                right = right.Replace(",", ".");
            }
            else
            {
                answer = answer.Replace(".", ",");
                right = right.Replace(".", ",");
            }
            int pos = right.IndexOf("±");
            if (pos < 0)
                return false;

            string stTrue = right.Substring(0, pos);
            string stDelta = right.Substring(pos + 1, right.Length - pos - 1);

            double flTrue = 0;
            double flDelta = 0;
            double flUserAnsver = 0;

            try
            {
                flTrue = double.Parse(stTrue, NumberStyles.Any, CultureInfo.CurrentCulture.NumberFormat);
                flDelta = double.Parse(stDelta, NumberStyles.Any, CultureInfo.CurrentCulture.NumberFormat);
                if (flDelta == 0)
                    flDelta = 0.0001;
                flUserAnsver = 0.0f;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }

            try
            {
                double? fractionValue = HtmlStore.GetFractionValue(answer);
                if (fractionValue.HasValue)
                {
                    flUserAnsver = fractionValue.Value;
                    answer = flUserAnsver.ToString();
                }
                else
                    flUserAnsver = double.Parse(answer, NumberStyles.Any, CultureInfo.CurrentCulture.NumberFormat);
            }
            catch
            {
                message = "Ответом должно быть десятичное число например \"-3.1415926\".";
                return null;
            }

            if ((flUserAnsver <= flTrue + flDelta) && (flUserAnsver >= flTrue - flDelta))
                return true;
            else
            {
                var tv = stTrue.Split(new string[] { sep }, StringSplitOptions.RemoveEmptyEntries);
                if (tv.Length != 2)
                    return false;
                int fractionLength = tv[1].Length;
                flUserAnsver = Math.Round(flUserAnsver, fractionLength);
                if ((flUserAnsver <= flTrue + flDelta) && (flUserAnsver >= flTrue - flDelta))
                    return true;
            }
            return false;
        }
    }
}
