using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.HttpServer.QuestionsProviders;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.HttpServer
{
    [Serializable]
    public class HttpHandler
    {
        protected TestingProvider _provider;

        public HttpHandler(TestingProvider provider)
        {
            _provider = provider;
        }

        public string GetQuestionHtml()
        {
            string retValue = QuestionsHtmlFactory.GetQuestionHtml(
                _provider.CurrentQuestion, _provider.ProviderMode);
            if (_provider.ProviderMode == ProviderMode.LocalMode)
                return GetQuestHtml(retValue);
            else
                return retValue;
        }

		public string GetPreTestingHtml()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<table style=\"font-family:verdana,arial,sans-serif;border-right: #7177bb 1px solid; border-top: #7177bb 1px solid; border-left: #7177bb 1px solid;");
			sb.Append("border-bottom: #7177bb 1px solid\" cellspacing=\"0\" cellpadding=\"2\"");
			sb.Append("width=\"100%\" bgcolor=\"#bcd0ef\"><tr><td style=\"height: 20px\">");
			sb.AppendFormat("<span style=\"font-family:Tahoma;font-size:9pt;\"><b>Тест: \"{0}\"</b></span>",
				_provider.TestName);
			sb.Append("</td></tr><tr><td bgcolor=\"#ffffff\" style=\"height: 32px\">");
			sb.Append("<table>");
			if (!String.IsNullOrEmpty(_provider.Description))
				sb.AppendFormat("<tr><td>Аннотация к тесту:</td><td><b>{0}</b></td></tr>", _provider.Description);
			else
				sb.AppendFormat("<tr><td>Аннотация к тесту:</td><td><b>{0}</b></td></tr>", "нет");
			sb.AppendFormat("<tr><td>Число вопросов в тесте:</td><td><b>{0}</b></td></tr>", _provider.QuestCount);
			if (_provider.TimeLimit != 0)
				sb.AppendFormat("<tr><td>Ограничение по времени:</td><td><b>{0} мин.</b></td></tr>", _provider.TimeLimit);
			else
				sb.AppendFormat("<tr><td>Ограничение по времени:</td><td><b>{0}</b></td></tr>", "нет");
			if (_provider.PassagesNumber != 0)
				sb.AppendFormat("<tr><td>Число разрешенных прохождений:</td><td><b>{0}</b></td></tr>",
					_provider.PassagesNumber);
			else
				sb.AppendFormat("<tr><td>Число разрешенных прохождений:</td><td><b>{0}</b></td></tr>","не ограничено");
			if(_provider.BeginTime!=DateTime.MinValue)
				sb.AppendFormat("<tr><td>Тест доступен c:</td><td><b>{0}</b></td></tr>", _provider.BeginTime);
			else
				sb.AppendFormat("<tr><td>Тест доступен c:</td><td><b>{0}</b></td></tr>", "не ограничено");
			if (_provider.EndTime != DateTime.MinValue)
				sb.AppendFormat("<tr><td>Тест доступен до:</td><td><b>{0}</b></td></tr>", _provider.EndTime);
			else
				sb.AppendFormat("<tr><td>Тест доступен до:</td><td><b>{0}</b></td></tr>", "не ограничено");
			if (_provider.ShowTestResult)
			{
				if (_provider.PassingScore != 0)
					sb.AppendFormat("<tr><td>Проходной Балл:</td><td><b>{0}</b></td></tr>", _provider.PassingScore);
				else
					sb.AppendFormat("<tr><td>Проходной Балл:</td><td><b>{0}</b></td></tr>", "не задан");
			}
			sb.Append("</table></td></tr></table>");
			return GetHtml(sb.ToString());
		}

        public static string GetPreTestingHtml(TestorData.CoreTestsRow coreTest)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            if (!String.IsNullOrEmpty(coreTest.Description))
                sb.AppendFormat("<tr><td>Аннотация к тесту:</td><td><b>{0}</b></td></tr>", coreTest.Description);
            else
                sb.AppendFormat("<tr><td>Аннотация к тесту:</td><td><b>{0}</b></td></tr>", "нет");
            sb.AppendFormat("<tr><td>Число вопросов в тесте:</td><td><b>{0}</b></td></tr>", coreTest.QuestionsNumber);
            if (coreTest.TimeLimit != 0)
                sb.AppendFormat("<tr><td>Ограничение по времени:</td><td><b>{0} мин.</b></td></tr>", coreTest.TimeLimit);
            else
                sb.AppendFormat("<tr><td>Ограничение по времени:</td><td><b>{0}</b></td></tr>", "нет");
            if (coreTest.PassagesNumber != 0)
                sb.AppendFormat("<tr><td>Число разрешенных прохождений:</td><td><b>{0}</b></td></tr>",
                    coreTest.PassagesNumber);
            else
                sb.AppendFormat("<tr><td>Число разрешенных прохождений:</td><td><b>{0}</b></td></tr>", "не ограничено");
            if (coreTest.BeginTime != DateTime.MinValue)
                sb.AppendFormat("<tr><td>Тест доступен c:</td><td><b>{0}</b></td></tr>", coreTest.BeginTime);
            else
                sb.AppendFormat("<tr><td>Тест доступен c:</td><td><b>{0}</b></td></tr>", "не ограничено");
            if (coreTest.EndTime != DateTime.MinValue)
                sb.AppendFormat("<tr><td>Тест доступен до:</td><td><b>{0}</b></td></tr>", coreTest.EndTime);
            else
                sb.AppendFormat("<tr><td>Тест доступен до:</td><td><b>{0}</b></td></tr>", "не ограничено");
            if (coreTest.ShowTestResult)
            {
                if (coreTest.PassingScore != 0)
                    sb.AppendFormat("<tr><td>Проходной Балл:</td><td><b>{0}</b></td></tr>", coreTest.PassingScore);
                else
                    sb.AppendFormat("<tr><td>Проходной Балл:</td><td><b>{0}</b></td></tr>", "не задан");
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        public string GetResultsHtml()
        {
            string body = null;
            if (_provider.ShowTestResult)
                body = GetShowResults();
            else
                body = GetShowNoResults();
            if (_provider.ProviderMode == ProviderMode.WebMode || _provider.ProviderMode == ProviderMode.EditMode)
                return body;
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style=\"font-family:verdana,arial,sans-serif;border-right: #7177bb 1px solid; border-top: #7177bb 1px solid; border-left: #7177bb 1px solid;");
            sb.Append("border-bottom: #7177bb 1px solid\" cellspacing=\"0\" cellpadding=\"2\"");
            sb.Append("width=\"100%\" bgcolor=\"#bcd0ef\"><tr><td style=\"height: 20px\">");
            sb.Append("<span style=\"font-family:Tahoma;font-size:9pt;\"><b>Результаты тестирования</b></span>");
            sb.Append("</td></tr><tr><td bgcolor=\"#ffffff\" style=\"height: 32px\">");
            sb.Append("<table>");
            sb.Append("</td></tr><tr><td bgcolor=\"#ffffff\" style=\"height: 32px\">");
            sb.Append(body);
            sb.Append("</td></tr></table>");
            return GetHtml(sb.ToString());
        }

        private string GetShowNoResults()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<i>Просмотр результатов для данного теста недоступен.</i>");
            return sb.ToString();
        }

        private string GetShowResults()
        {
            StringBuilder sb = new StringBuilder();
            var time = (_provider.TestEndTime - _provider.TestStartTime);
            sb.Append("<table>");
            sb.AppendFormat("<tr><td>Набрано Баллов:</td><td><b>{0}</b></td></tr>", _provider.Score);
            if (_provider.PassingScore != 0)
                sb.AppendFormat("<tr><td>Проходной Балл:</td><td><b>{0}</b></td></tr>", _provider.PassingScore);
            else
                sb.AppendFormat("<tr><td>Проходной Балл:</td><td><b>{0}</b></td></tr>", "не задан");
            sb.AppendFormat("<tr><td>Максимальный Балл:</td><td><b>{0}</b></td></tr>", _provider.MaxScore);
            sb.AppendFormat("<tr><td>Затраченное время:</td><td><b>{0} мин.</b></td></tr>", (int)time.TotalMinutes);
            if (_provider.PassingScore != 0)
            {
                string color = "red";
                string text = "тест не пройден";
                if (_provider.Score >= _provider.PassingScore)
                {
                    color = "green";
                    text = "тест пройден";
                }
                sb.AppendFormat("<tr><td>Результат:</td><td><b><font color=\"{0}\">{1}</font></b></td></tr>",
                    color, text);
            }
            sb.Append("</table>");
            string resultsUri = String.Empty;
            if (_provider.ProviderMode == ProviderMode.WebMode)
                resultsUri = String.Format("/ImageHandler.aspx?id=-1&pid={0}", Guid.NewGuid().ToString());
            else
                resultsUri = TestingHttpServer.GetUrl("images/results.png");
            sb.AppendFormat("<br/><img src=\"{0}\"/>", resultsUri);
            sb.Append("<div>");
            sb.Append(_provider.GetAppealHtml());
            sb.Append("</div>");
            return sb.ToString();
        }

        public byte[] GetImage(string imageId)
        {
            if (imageId == "results.png")
                return GetResultsImage(_provider.MaxScore, _provider.Score, _provider.PassingScore);
            Guid image;
            try
            {
                image = new Guid(imageId.Replace(".png", String.Empty));
            }
            catch
            {
                return null;
            }
            var images = _provider.CurrentQuestion.Images.Where(c => c.Key == image);
            if (images.Count() == 0)
                return null;
            var imageArr = images.FirstOrDefault();
            return imageArr.Value;
        }

        public static byte[] GetResultsImage(double maxScore, double score, double passingScore)
        {
            byte[] retValue = null;
            double max = maxScore;
            if (max == 0)
                return null;
            double current = score;
            double passing = passingScore;
            if (passing > max)
                passing = max;
            int h = 250;
            double factor = h / max;
            int xfactor = 75;
            int xplusfactor = 9;
            int x = xplusfactor;
            int min = 5;
            Pen blackPen = new Pen(Brushes.Black, 2);
            int gwidth = 500, gheight = h + 4 * min + 50;
            Bitmap bmp = new Bitmap(gwidth, gheight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(Brushes.White, 0, 0, gwidth, gheight);
                g.TranslateTransform(0, min * 2);
                Brush currentBrush = Brushes.LightBlue;
                Brush maxBrush = Brushes.LightYellow;
                Brush passingBrush = Brushes.LightGray;
                //---------------------------------------------------------------------------
                int height = (int)(max * factor) + min;
                DrawString(g, max.ToString(), x, (h - height) - 3, 12);
                Rectangle maxRect = new Rectangle(x, h - height + 20, xfactor, height);
                g.DrawRectangle(blackPen, maxRect);
                g.FillRectangle(maxBrush, maxRect);
                //---------------------------------------------------------------------------
                x += xfactor + xplusfactor;
                height = (int)(current * factor) + min;
                DrawString(g, current.ToString(), x, (h - height) - 3, 12);
                Rectangle currentRect = new Rectangle(x, h - height + 20, xfactor, height);
                g.DrawRectangle(blackPen, currentRect);
                if (passingScore != 0)
                {
                    if (score >= passingScore)
                        currentBrush = Brushes.LawnGreen;
                    if (score < passingScore)
                        currentBrush = Brushes.LightPink;
                }
                g.FillRectangle(currentBrush, currentRect);
                //---------------------------------------------------------------------------
                x += xfactor + xplusfactor;
                height = (int)(passing * factor) + min;
                DrawString(g, passing.ToString(), x, (h - height) - 3, 12);
                Rectangle passingRect = new Rectangle(x, h - height + 20, xfactor, height);
                g.DrawRectangle(blackPen, passingRect);
                g.FillRectangle(passingBrush, passingRect);
                //---------------------------------------------------------------------------
                x += xfactor + xplusfactor + 30;
                int y = 7;
                int rw = 20, rh = 20;
                int strx = x + rw + 3;
                int rx, ry;
                rx = x - 7; ry = y - 7;
                Rectangle x1 = new Rectangle(x, y, rw, rh);
                g.DrawRectangle(blackPen, x1);
                g.FillRectangle(maxBrush, x1);
                DrawString(g, "Максимальный Балл", strx, y, 10);
                y += rh + 4;
                Rectangle x2 = new Rectangle(x, y, rw, rh);
                g.DrawRectangle(blackPen, x2);
                g.FillRectangle(currentBrush, x2);
                DrawString(g, "Набранный Балл", strx, y, 10);
                y += rh + 4;
                Rectangle x3 = new Rectangle(x, y, rw, rh);
                g.DrawRectangle(blackPen, x3);
                g.FillRectangle(passingBrush, x3);
                DrawString(g, "Проходной Балл", strx, y, 10);
                y += rh + 6;
                g.DrawRectangle(new Pen(Brushes.Black, 1), new Rectangle(rx, ry, 200, y));
                //---------------------------------------------------------------------------
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);
                    retValue = ms.ToArray();
                    ms.Close();
                }
            }
            return retValue;
        }

        private static void DrawString(Graphics g,string s,int x,int y, int font)
        {
			g.DrawString(s, new Font("Arial", font, FontStyle.Regular), Brushes.Black, x, y);
        }

        public string GetHtml(string body)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head><meta http-equiv=Content-Type content=\"text/html; charset=UTF-8\">");
            sb.Append("<style type=\"text/css\">");
            sb.Append("html {cursor:default}");
            sb.Append("</style>");
            sb.Append("</head>");
            sb.Append("<body onselectstart=\"return false\">");
            sb.Append(body);
            sb.Append("</body></html>");
            return sb.ToString();
        }

        public string GetQuestHtml(string body)
        {
            if (_provider.CurrentQuestion == null)
                return null;
            StringBuilder sb = new StringBuilder();
            if (_provider.ShowSecurityAlert)
            {
                sb.Append("<div style=\"padding:5px;background-color:#E00000;border-style:dotted;border-width:1px;border-color:Blue;color:White;\">Прохождение теста параллельно открыто на двух компьютерах. Сведения об этом зафиксированы в базе данных. В случае если это произошло случайно и Вы открыли чужой тест, просто закройте окно браузера.");
                sb.AppendFormat("<br />IP адрес второго компьютера: {0}", _provider.SecondComputerAddress);
                sb.Append("</div><br />");
            }
            sb.AppendFormat("<form action=\"{0}\" method=\"get\">", TestingHttpServer.GetUrl("answer"));
            sb.Append("<table style=\"font-family:verdana,arial,sans-serif;border-right: #7177bb 1px solid; border-top: #7177bb 1px solid; border-left: #7177bb 1px solid;");
            sb.Append("border-bottom: #7177bb 1px solid\" cellspacing=\"0\" cellpadding=\"2\"");
            sb.Append("width=\"100%\" bgcolor=\"#bcd0ef\"><tr><td style=\"height: 20px\">");
            sb.AppendFormat("<span style=\"font-family:Tahoma;font-size:9pt;\"><b>Вопрос {0}</b> из {1} ({2})</span>",
                _provider.CurrentQuestNumber, _provider.QuestCount, (_provider.QuestCount - _provider.AnsQuestCount).ToString());
            sb.Append("</td></tr><tr><td bgcolor=\"#ffffff\" style=\"height: 32px\">");
            sb.Append(body);
            sb.Append("</td></tr></table>");
            sb.Append("<input type=\"hidden\" id=\"hid\" name=\"hid\" value=\"0\" />");
            sb.AppendFormat("<input type=\"hidden\" id=\"questId\" name=\"questId\" value=\"{0}\" />",
                _provider.CurrentQuestion.QuestIndex);
            sb.Append("</form>");
            return GetHtml(sb.ToString());
        }
    }
}
