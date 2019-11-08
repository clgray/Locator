using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.HttpServer.QuestionsProviders
{
	public sealed class EstablishConformityеnswerQuestionProvider : BaseQuestionProvider
	{
		public EstablishConformityеnswerQuestionProvider(HtmlStore htmlStore)
			: base(htmlStore)
		{
		}

		public override string ProcessHtml()
		{
			throw new NotImplementedException();
		}

        public override bool? IsRightAnswer(Dictionary<string, List<string>> _requestParams, ref string message, ref string questAnswer)
        {
            throw new NotImplementedException();
        }
	}
}
