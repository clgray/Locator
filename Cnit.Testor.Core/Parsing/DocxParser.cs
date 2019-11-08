using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Packaging;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Text.RegularExpressions;

namespace Cnit.Testor.Core.Parsing
{
	internal sealed class DocxParser
	{
		private List<HtmlStore> _questions = new List<HtmlStore>();

		private Package _package;
		private static PackageRelationshipCollection _docRels;

		private StringBuilder _sb;
		private int _qIndex = 1;

        private HtmlStore _currentQuestion = new HtmlStore();
		private char _currentChar = 'a';
		private bool _isAnswerMode = false;

		private const string _wNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
		private const string _vmlNamespace = "urn:schemas-microsoft-com:vml";
		//private const string _relNamespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
		private const string _drawNamespace = "http://schemas.openxmlformats.org/drawingml/2006/main";

		private XName _xBody = XName.Get("body", _wNamespace);
		private XName _xP = XName.Get("p", _wNamespace);
		private XName _xR = XName.Get("r", _wNamespace);
		private XName _xT = XName.Get("t", _wNamespace);
		private XName _xCr = XName.Get("cr", _wNamespace);
		private XName _xRPr = XName.Get("rPr", _wNamespace);
		private XName _xDrawing = XName.Get("drawing", _wNamespace);
		private XName _xObject = XName.Get("object", _wNamespace);
		private XName _xPict = XName.Get("pict", _wNamespace);

		private XName _xBold = XName.Get("b", _wNamespace);
		private XName _xItalic = XName.Get("i", _wNamespace);
		private XName _xUnderline = XName.Get("u", _wNamespace);
		private XName _xColor = XName.Get("color", _wNamespace);
		private XName _xValAttr = XName.Get("val", _wNamespace);
		private XName _xTab = XName.Get("tab", _wNamespace);

		private DocxParser()
		{
		}

		private List<HtmlStore> ParseDocx(string fileName)
		{
			using (_package = Package.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				PackageRelationship rel = _package.GetRelationships().Where(c => c.RelationshipType == "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument").First();
				PackagePart docPart = _package.GetPart(PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative), rel.TargetUri));
				_docRels = docPart.GetRelationships();

				XDocument doc = null;
				using (Stream st = docPart.GetStream(FileMode.Open, FileAccess.Read))
				{
					StreamReader sr = new StreamReader(st);
					doc = XDocument.Load(sr, LoadOptions.None);
					ParseDocument(doc);
				}
				if (!_isAnswerMode && _sb.Length > 0)
				{
					string addStr = ReplaceWrongChars(_sb.ToString());
					if (addStr.Length > 0)
						AddQuestion(_sb.ToString());
				}
				else if (_isAnswerMode)
					AddAnswer(_sb.ToString());
			}
			int index = 1;
			foreach (var quest in _questions)
			{
				quest.Html = ReplaceWrongChars(ReplaceWrongChars(quest.Html.Replace(Environment.NewLine, "<br/>")));
				quest.QuestionType = QuestionTypeHelper.GetQuestionType(quest);
				quest.QuestIndex = index;
				index++;
				foreach (var ans in quest.SubItems)
					ans.Html = ReplaceWrongChars(ReplaceWrongChars(ans.Html.Replace(Environment.NewLine, "<br/>")));
			}
			_package.Close();
			return _questions;
		}

		public static HtmlStore[] Parse(string fileName)
		{
			return new DocxParser().ParseDocx(fileName).ToArray();
		}

		private void ParseDocument(XDocument doc)
		{
			_sb = new StringBuilder();
			XElement body = doc.Root.Element(_xBody);

			foreach (var par in body.Elements(_xP))
			{
				foreach (var region in par.Elements())
				{
					foreach (var contentElem in region.Elements())
					{
						if (contentElem.Name == _xT)
							GetQuestions(HttpUtility.HtmlEncode(contentElem.Value));
						else if (contentElem.Name == _xCr)
							_sb.Append(Environment.NewLine);
						else if (contentElem.Name == _xTab)
							_sb.Append("&nbsp;&nbsp;&nbsp;");
						else if (contentElem.Name == _xRPr)
							ProcessFormat(contentElem);
						else if (contentElem.Name == _xDrawing || contentElem.Name == _xPict || contentElem.Name == _xObject)
						{
							var str = contentElem.ToString();
							string embStr = ":embed=\"";
							string embStr2 = "r:id=\"";

							string id = String.Empty;

							int index = str.IndexOf(embStr);
							if (index != -1)
							{
								str = str.Substring(index + embStr.Length);
							}
							else
							{
								index = str.IndexOf(embStr2);
								str = str.Substring(index + embStr2.Length);
							}

							id = str.Substring(0, str.IndexOf("\""));
							_sb.AppendFormat("<img src=\"#${0}#%png\"/>", InitImage(id));
						}
					}
					ProcessFormat(null);
				}
				_sb.Append(Environment.NewLine);
			}
		}

		private bool _isBold = false, _isItalic = false, _isUnderline = false, _isFont = false;
		private List<int> _orderList = new List<int>();
		private void ProcessFormat(XElement contentElem)
		{
			if (contentElem != null)
			{
				if (contentElem.Element(_xBold) != null)
				{
					_isBold = true;
					_sb.Append("<b>");
					_orderList.Add(0);
				}
				if (contentElem.Element(_xItalic) != null)
				{
					_isItalic = true;
					_sb.Append("<i>");
					_orderList.Add(1);
				}
				if (contentElem.Element(_xUnderline) != null)
				{
					_isUnderline = true;
					_sb.Append("<u>");
					_orderList.Add(2);
				}
				XElement color = contentElem.Element(_xColor);
				if (color != null)
				{
					_isFont = true;
					_sb.AppendFormat("<font color=\"#{0}\">", color.Attribute(_xValAttr).Value);
					_orderList.Add(3);
				}
			}
			else
			{
				_orderList.Reverse();
				foreach (var elem in _orderList)
				{
					if (elem == 0 && _isBold)
					{
						_isBold = false;
						_sb.Append("</b>");
					}
					if (elem == 1 && _isItalic)
					{
						_isItalic = false;
						_sb.Append("</i>");
					}
					if (elem == 2 && _isUnderline)
					{
						_isUnderline = false;
						_sb.Append("</u>");
					}
					if (elem == 3 && _isFont)
					{
						_isFont = false;
						_sb.Append("</font>");
					}
				}
				_orderList = new List<int>();
			}
		}

		private string _lastStr = String.Empty;
		private void GetQuestions(string str)
		{
			string qIndexStr = _qIndex + ". ";
			string strSb = _sb.ToString() + str;

			int index = strSb.IndexOf(qIndexStr, StringComparison.InvariantCultureIgnoreCase);

			if (index >= 0)
			{
				_sb = new StringBuilder(strSb.Substring(0, index).TrimStart());

				if (!_isAnswerMode && _sb.Length > 0)
				{
					string addStr = ReplaceWrongChars(ReplaceWrongChars(_sb.ToString()));
					if (addStr.Length > 0)
						AddQuestion(_sb.ToString());
				}
				else if (_isAnswerMode)
					AddAnswer(_sb.ToString());

				InitNextQuestStage();

				GetQuestions(strSb.Substring(index + qIndexStr.Length));
			}
			else
			{
				index = strSb.IndexOf(_currentChar + ")", StringComparison.InvariantCultureIgnoreCase);

				if (index == -1 && _lastStr.Length != 0 && str.Length != 0 && str[0] == ')' && _lastStr[_lastStr.Length - 1] == _currentChar)
				{
					string xStr = ReplaceFont(strSb);
					index = xStr.LastIndexOf(_currentChar);
					strSb = strSb.Substring(0, index) + str;
				}

				if (index >= 0)
				{
					_sb = new StringBuilder(strSb.Substring(0, index).TrimStart());

					if (String.IsNullOrEmpty(_currentQuestion.Html) && _sb.Length > 0)
						AddQuestion(_sb.ToString());

					if (_isAnswerMode)
						AddAnswer(_sb.ToString());

					InitNextAnsStage();

					_sb.Append(strSb.Length > index + 1 ? strSb.Substring(index + 2) : String.Empty);
				}
				else
				{
					_sb.Append(str);
				}
			}
			_lastStr = str;
		}

		private void InitNextQuestStage()
		{
			_sb = new StringBuilder();
			_isAnswerMode = false;
			_currentChar = 'a';
			_currentQuestion = new HtmlStore();
			_qIndex++;
		}

		private void InitNextAnsStage()
		{
			_sb = new StringBuilder();
			_isAnswerMode = true;
			_currentChar++;
		}

		private void AddQuestion(string questionHTML)
		{
			_currentQuestion.Html = questionHTML.Trim();
			_questions.Add(_currentQuestion);
		}

		private void AddAnswer(string answerHTML)
		{
			HtmlStore answer = new HtmlStore();
			if (answerHTML.Contains("!!!"))
			{
				answer.IsTrue = true;
				answerHTML = answerHTML.Replace("!!!", String.Empty);
			}
			else
			{
				string aHTML = ReplaceFont(answerHTML);
				Regex trueRegular = new Regex(@"![#]*![#]*!");
				Match match = trueRegular.Match(aHTML);
				if (match.Success)
				{
					answer.IsTrue = true;
					answerHTML = answerHTML.Remove(match.Index, match.Length);
				}
			}
			answer.Html = answerHTML.Trim();
			_currentQuestion.SubItems.Add(answer);
		}

		private string InitImage(string id)
		{
			Guid retValue;
			var rel = _docRels.Where(c => c.Id == id).First();
			string ext = new FileInfo(rel.TargetUri.ToString()).Extension.ToLower();
			PackagePart part = _package.GetPart(new Uri("/word/" + rel.TargetUri.ToString(), UriKind.Relative));
			using (Stream partStream = part.GetStream())
			{
				Image img = null;
				if (ext == ".wmf" || ext == ".emf")
					img = new Metafile(partStream);
				else
					img = Bitmap.FromStream(partStream);

				using (MemoryStream ms = new MemoryStream())
				{
					img.Save(ms, ImageFormat.Png);
					retValue = _currentQuestion.AddImage(ms.ToArray());
				}
			}
			return retValue.ToString();
		}

		private string ReplaceWrongChars(string str)
		{
			str = str.Replace(char.ConvertFromUtf32(61618), "\"");
			str = str.Replace("<b><u></b></u>", String.Empty);
			str = str.Replace("<b></b>", String.Empty);
			str = str.Replace("<i></i>", String.Empty);
			str = str.Replace("<u></u>", String.Empty);

			Regex fontRegular = new Regex("<font color=\"[#]?[0-1a-zA-Z]*\">(<[/]?[a-z]]?>)?</font>");
			str = fontRegular.Replace(str, String.Empty);
			fontRegular = new Regex("^</font>");
			str = fontRegular.Replace(str, String.Empty);
			fontRegular = new Regex("<font color=\"[#]?[0-1a-zA-Z]*\">$");
			str = fontRegular.Replace(str, String.Empty);

			Regex brRegular = new Regex("<br/>(<br/>)?");
			str = brRegular.Replace(str, "<br/>");
			brRegular = new Regex("<b>$");
			str = brRegular.Replace(str, String.Empty);
			brRegular = new Regex("<i>$");
			str = brRegular.Replace(str, String.Empty);
			brRegular = new Regex("<u>$");
			str = brRegular.Replace(str, String.Empty);
			brRegular = new Regex("<br/>$");
			str = brRegular.Replace(str, String.Empty);
			return str;
		}

		private string ReplaceFont(string str)
		{
			str = str.Replace("b>", "##").Replace("i>", "##").Replace("u>", "##");

			Regex fontRegular = new Regex("<font color=\"[#]?[0-1a-zA-Z]*\"></font>");
			foreach (Match macth in fontRegular.Matches(str))
				str = str.Replace(macth.Value, new String('#', macth.Length));

			fontRegular = new Regex("</font>");
			foreach (Match macth in fontRegular.Matches(str))
				str = str.Replace(macth.Value, new String('#', macth.Length));

			fontRegular = new Regex("<font color=\"[#]?[0-1a-zA-Z]*\">");

			foreach (Match macth in fontRegular.Matches(str))
				str = str.Replace(macth.Value, new String('#', macth.Length));

			return str;
		}
	}
}