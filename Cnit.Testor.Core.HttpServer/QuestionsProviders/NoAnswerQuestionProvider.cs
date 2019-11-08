using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.HttpServer.QuestionsProviders
{
	public sealed class NoAnswerQuestionProvider : BaseQuestionProvider
	{
		public NoAnswerQuestionProvider(HtmlStore htmlStore)
			: base(htmlStore)
		{
		}

		public override string ProcessHtml()
		{
			return "<i>Вариантов ответов не найдено.</i>";
		}

        public override bool? IsRightAnswer(Dictionary<string, List<string>> _requestParams, ref string message, ref string questAnswer)
        {
            return false;
        }
	}
}
