using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.HttpServer.QuestionsProviders
{
    public sealed class QuestionsHtmlFactory
    {
        public static string GetQuestionHtml(HtmlStore store, ProviderMode mode)
        {
            if (store == null)
                return null;
            StringBuilder sb = new StringBuilder();
            sb.Append(ConvertImageUris(store.Html, store.QuestIndex, mode));
            sb.Append("<table width=\"100%\" style=\"border:0px;border-collapse:collapse;margin:8px 0px 8px 0px;\" cellspacing=\"0\"><tr><td style=\"height:1px;background-color:#7d9acb;padding:0px;margin:0px;\"></td></tr></table>");
            BaseQuestionProvider questProvider = GetQuestionProvider(store);
            if (questProvider == null)
                questProvider = new NoAnswerQuestionProvider(store);
            sb.Append(ConvertImageUris(questProvider.ProcessHtml(), store.QuestIndex, mode));
            return sb.ToString();
        }

        public static BaseQuestionProvider GetQuestionProvider(HtmlStore htmlStore)
        {
            return GetQuestionProvider(htmlStore.QuestionType, htmlStore);
        }

        public static BaseQuestionProvider GetQuestionProvider(QuestionType questionType, HtmlStore htmlStore)
        {
            BaseQuestionProvider retValue = null;
            switch (questionType)
            {
                case (QuestionType.SingleAnswerQuestion):
                    {
                        retValue = new SingleAnswerQuestionProvider(htmlStore);
                    }
                    break;
                case (QuestionType.MultiAnswerQuestion):
                    {
                        retValue = new MultiAnswerQuestionProvider(htmlStore);
                    }
                    break;
                case (QuestionType.DigitAnswerQuestion):
                    {
                        retValue = new DigitAnswerQuestionProvider(htmlStore);
                    }
                    break;
                case (QuestionType.StringAnswerQuestion):
                    {
                        retValue = new StringAnswerQuestionProvider(htmlStore);
                    }
                    break;
                case (QuestionType.EstablishSequenceAnswerQuestion):
                    {
                        retValue = new EstablishSequenceAnswerQuestionProvider(htmlStore);
                    }
                    break;
                case (QuestionType.EstablishConformityеnswerQuestion):
                    {
                        retValue = new EstablishConformityеnswerQuestionProvider(htmlStore);
                    }
                    break;
                case (QuestionType.MultiWordAnswerQuestion):
                    {
                        retValue = new MultiWordAnswerQuestionProvider(htmlStore);
                    }
                    break;
                default:
                    {
                        retValue = new NoAnswerQuestionProvider(htmlStore);
                    }
                    break;
            }
            return retValue;
        }


        private static string ConvertImageUris(string html, int index, ProviderMode mode)
        {
            if (mode == ProviderMode.LocalMode || mode == ProviderMode.EditMode)
                return html.Replace("#$", TestingHttpServer.GetUrl("images")).Replace("#%", ".");
            else
                return html.Replace("#$", "/ImageHandler.aspx?id=").Replace("#%", ".");
        }
    }
}
