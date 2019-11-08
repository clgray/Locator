using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.HttpServer.QuestionsProviders
{
    public abstract class BaseQuestionProvider
    {
        internal HtmlStore _htmlStore;

        public virtual bool SendAnswersToClient
        {
            get
            {
                return false;
            }
        }

        public BaseQuestionProvider(HtmlStore htmlStore)
        {
            _htmlStore = htmlStore;
        }

        public List<string> GetValueList(Dictionary<string, List<string>> _requestParams, string paramName, ref string questAnswer)
        {
            questAnswer = string.Empty;
            List<string> retValue = null;
            if (!_requestParams.ContainsKey(paramName))
                return null;
            retValue = _requestParams[paramName];
            foreach (var str in retValue)
                questAnswer += str + ";";
            return retValue;
        }

        public List<int> GetAnsIds(Dictionary<string, List<string>> _requestParams, string paramName, ref string questAnswer)
        {
            List<string> answers = GetValueList(_requestParams, paramName, ref questAnswer);
            if (answers == null)
                return null;
            if (answers.Count == 0)
                return null;
            List<int> ansIds = new List<int>();
            foreach (var str in answers)
            {
                int ans = -1;
                if (int.TryParse(str, out ans))
                    ansIds.Add(ans);
            }
            return ansIds;
        }

        public int[] GetStudentAnswersIds()
        {
            List<int> retValue = new List<int>();
            if (_htmlStore.IsAppeal && !String.IsNullOrEmpty(_htmlStore.Answer))
            {
                string[] ans = _htmlStore.Answer.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var c in ans)
                    retValue.Add(int.Parse(c));
            }
            return retValue.ToArray();
        }

        public string GetAnswerColor(bool contains, bool isTrue)
        {
            string retValue = "black";
            if (contains && isTrue)
                retValue = "green";
            else if (contains && !isTrue)
                retValue = "red";
            else if (!contains && isTrue)
                retValue = "blue";
            return retValue;
        }

        public abstract string ProcessHtml();
        public abstract bool? IsRightAnswer(Dictionary<string, List<string>> requestParams, ref string message, ref string answer);
    }
}
