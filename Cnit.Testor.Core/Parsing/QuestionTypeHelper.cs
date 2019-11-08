using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.Parsing
{
    internal static class QuestionTypeHelper
    {
        public static QuestionType GetQuestionType(HtmlStore quest)
        {
            QuestionType retValue = QuestionType.SingleAnswerQuestion;
            if (IsDigitAnswerQuestion(quest)) retValue = QuestionType.DigitAnswerQuestion;
            else
                if (IsMultiAnswerQuestion(quest)) retValue = QuestionType.MultiAnswerQuestion;
                else
                    if (IsStringAnswerQuestion(quest)) retValue = QuestionType.StringAnswerQuestion;
                    else
                        if (IsMultiWordAnswerQuestion(quest)) retValue = QuestionType.MultiWordAnswerQuestion;
            return retValue;
        }

        private static bool IsMultiAnswerQuestion(HtmlStore quest)
        {
            bool retValue = false;
            int trueCount = quest.SubItems.Where(c => c.IsTrue == true).Count();
            if (trueCount > 1)
                retValue = true;
            return retValue;
        }

        private static bool IsMultiWordAnswerQuestion(HtmlStore quest)
        {
            bool retValue = false;
            if (quest.Html.IndexOf("&lt;@") > -1)
                retValue = true;
            return retValue;
        }

        private static bool IsStringAnswerQuestion(HtmlStore quest)
        {
            bool retValue = false;
            if (quest.SubItems.Count == 1)
                retValue = quest.SubItems[0].IsTrue;
            return retValue;
        }

        private static bool IsDigitAnswerQuestion(HtmlStore quest)
        {
            bool retValue = false;
            if (quest.SubItems.Count != 1)
                return retValue;
            HtmlStore answer = quest.SubItems[0];
            bool isTrue = answer.IsTrue;
            if (isTrue)
            {
                string st = answer.Html;
                st = st.Trim();
                st = st.Replace("<br/>", "");
                st = st.Replace(" ", "");
                st = st.Replace("&#177;", "±");
                int pos = st.IndexOf("±");
                if (pos == -1)
                {
                    if (isFloat(st))
                    {
                        retValue = true;
                        st = st.Replace(",", ".");
                        answer.Html = st + "±0";
                    }
                    else
                    {
                        double? dValue = HtmlStore.GetFractionValue(st);
                        if (dValue.HasValue)
                        {
                            retValue = true;
                            st = dValue.Value.ToString().Replace(",", ".");
                            answer.Html = st + "±0";
                        }
                    }
                }
                else
                {
                    string subst1 = st.Substring(0, pos);
                    string subst2 = st.Substring(pos + 1);
                    if (isFloat(subst1) && isFloat(subst2))
                    {
                        retValue = true;
                        answer.Html = st;
                    }
                    else
                    {
                        double? dValue = HtmlStore.GetFractionValue(subst1);
                        if (dValue.HasValue && isFloat(subst2))
                        {
                            retValue = true;
                            st = dValue.Value.ToString().Replace(",", ".");
                            answer.Html = st + "±" + subst2.ToString();
                        }
                    }
                }
            }
            return retValue;
        }

        private static bool isFloat(string st)
        {
            float value;
            return float.TryParse(st, out value);
        }
    }
}
