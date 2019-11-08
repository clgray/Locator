using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;
using CoreWebClient.Code;
using System.IO;
using System.Text;
using System.Globalization;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml;

namespace CoreWebClient.Manage
{
	public partial class StatisticsPrint : System.Web.UI.Page
	{
		private ScoreType _scoreType = ScoreType.PassingScore;
		private int _score;
		private int _five, _four, _three;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Context.User.Identity.IsAuthenticated)
				Response.Redirect("~/Default.aspx");

			if (LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Teacher &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Laboratorian &&
				LocalUser.SecurityProvider.CurrentUser.UserRole != TestorUserRole.Administrator)
				Response.Redirect("~/Default.aspx");

			int st = 0;
			int.TryParse(Request["scoreType"], out st);
			_scoreType = (ScoreType)st;

			if (_scoreType == ScoreType.Score)
			{
				int.TryParse(Request["score"], out _score);
			}
			else if (_scoreType == ScoreType.Mark)
			{
				int.TryParse(Request["five"], out _five);
				int.TryParse(Request["four"], out _four);
				int.TryParse(Request["three"], out _three);
			}

			if (Request["type"] != null && Request["type"].ToLower() == "html")
				GetHtmlStatistics();
			else
				GetDocxStatistics();
		}

		public void GetDocxStatistics()
		{
			Response.Clear();
			Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
			Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.docx", DateTime.Now.ToString("dd-MM-yyyy-HH-mm")));

			using (MemoryStream ms = new MemoryStream())
			{
				using (WordprocessingDocument package = WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document))
				{
					MainDocumentPart mainDocumentPart = package.AddMainDocumentPart();
					mainDocumentPart.Document = new Document();
					//-------------------------------------------------------------------------------------------
					Body documentBody = new Body(new SectionProperties(
							new FooterReference()
							{
								Type = HeaderFooterValues.Default,
								Id = "rId7"
							}
						));
					mainDocumentPart.Document.Append(documentBody);
					//-------------------------------------------------------------------------------------------
					FillDocBody(documentBody, mainDocumentPart);
					mainDocumentPart.Document.Save();
					//-------------------------------------------------------------------------------------------
					var oddPageFooterPart =
						mainDocumentPart.AddNewPart<FooterPart>("rId7");
					WordHelper.GenerateFooter().Save(oddPageFooterPart);

					package.Close();
				}
				byte[] arr = ms.ToArray();
				Response.OutputStream.Write(arr, 0, arr.Length);
			}

			Response.Flush();
			Response.Close();
		}

		private void FillDocBody(Body documentBody, MainDocumentPart mainDocumentPart)
		{
			var stats = StatisticsHelper.GetStatistics(_scoreType, _score, _five, _four, _three);

			Table statTable = new Table();
			//-------------------------------------------------------------------------------------------
			TableProperties tblProp = new TableProperties(
			   new TableBorders(
				   new TopBorder()
				   {
					   Val = new EnumValue<BorderValues>(BorderValues.Single),
					   Size = 2
				   },
				   new BottomBorder()
				   {
					   Val = new EnumValue<BorderValues>(BorderValues.Single),
					   Size = 2
				   },
				   new LeftBorder()
				   {
					   Val = new EnumValue<BorderValues>(BorderValues.Single),
					   Size = 2
				   },
				   new RightBorder()
				   {
					   Val = new EnumValue<BorderValues>(BorderValues.Single),
					   Size = 2
				   },
				   new InsideHorizontalBorder()
				   {
					   Val = new EnumValue<BorderValues>(BorderValues.Single),
					   Size = 2
				   },
				   new InsideVerticalBorder()
				   {
					   Val = new EnumValue<BorderValues>(BorderValues.Single),
					   Size = 2
				   }
			   )
			);

			documentBody.Append(new Paragraph(new ParagraphProperties(new Justification()
			{
				Val = JustificationValues.Center
			}), new Run(new RunProperties(new Bold(), new FontSize()
			{
				Val = "36"
			}, new FontSizeComplexScript()
			{
				Val = "36"
			}), new Text("МОСКОВСКИЙ ГОСУДАРСТВЕННЫЙ УНИВЕРСИТЕТ"))));

			documentBody.Append(new Paragraph(new ParagraphProperties(new Justification()
			{
				Val = JustificationValues.Center
			}), new Run(new RunProperties(new Bold(), new FontSize()
			{
				Val = "36"
			}, new FontSizeComplexScript()
			{
				Val = "36"
			}), new Text("ПРИБОРОСТРОЕНИЯ И ИНФОРМАТИКИ"))));

			documentBody.Append(new Paragraph(new ParagraphProperties(new Justification()
			{
				Val = JustificationValues.Center
			}), new Run(new RunProperties(new Bold(), new FontSize()
			{
				Val = "32"
			}, new FontSizeComplexScript()
			{
				Val = "32"
			}), new Text("ВЕДОМОСТЬ ПО ТЕСТИРОВАНИЮ"))));

			string[] txts = new string[] { DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("ru-Ru")), "Ответственный за проведение тестирования", "/______________________/",
			"Преподаватель","/______________________/"};
			foreach (var text in txts)
			{
				documentBody.Append(new Paragraph(new ParagraphProperties(new Justification()
				{
					Val = JustificationValues.Right
				}), new Run(new RunProperties(new FontSize()
				{
					Val = "24"
				}, new FontSizeComplexScript()
				{
					Val = "24"
				}), new Text(text))));
			}

			statTable.AppendChild<TableProperties>(tblProp);
			//-------------------------------------------------------------------------------------------
			TableRow rowHeader = new TableRow();
			rowHeader.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text("№"), new TableCellProperties(new TableCellWidth()
			{
				Type = TableWidthUnitValues.Dxa,
				Width = "2400"
			})))));
			rowHeader.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text("Ф.И.О.")))));
			rowHeader.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text("Тест")))));
			rowHeader.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text("Группа")))));
			rowHeader.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text("№ студ.")))));
			rowHeader.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text("Дата")))));
			rowHeader.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text("Макс./проходной Балл")))));
			if (_scoreType != ScoreType.Percent && _scoreType != ScoreType.Mark)
			{
				rowHeader.Append(new TableCell(new Paragraph(new Run(new Text("Балл")))));
			}
			if (_scoreType == ScoreType.Percent)
			{
				rowHeader.Append(new TableCell(new Paragraph(new Run(new Text("%")))));
			}
			else if (_scoreType == ScoreType.Mark)
			{
				rowHeader.Append(new TableCell(new Paragraph(new Run(new Text("Оценка")))));
			}
			else
			{
				rowHeader.Append(new TableCell(new Paragraph(new Run(new Text("Пройден")))));
			}
			statTable.Append(rowHeader);
			//-------------------------------------------------------------------------------------------
			for (int i = 0; i < stats.Count; i++)
			{
				var stat = stats[i];
				TableRow newRow = new TableRow();

				newRow.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text((i + 1).ToString())))));
				newRow.Append(new TableCell(new Paragraph(new Run(new Text(String.Format("{0} {1} {2}", stat.LastName, stat.FirstName, stat.SecondName))))));
				newRow.Append(new TableCell(new Paragraph(new Run(new Text(stat.TestName)))));
				newRow.Append(new TableCell(new Paragraph(new Run(new Text(stat.GroupName)))));
				newRow.Append(new TableCell(new Paragraph(new Run(new Text(stat.StudNumber)))));
				newRow.Append(new TableCell(new Paragraph(new Run(new Text(stat.StartTime.ToString("dd.MM.yyyy HH:mm"))))));
				newRow.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text(String.Format("{0}/{1}", stat.MaxScore, stat.PassingScore))))));
				if (_scoreType != ScoreType.Percent && _scoreType != ScoreType.Mark)
				{
					newRow.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new RunProperties(new Bold()), new Text(stat.Score.ToString())))));
				}
				if (_scoreType == ScoreType.Percent)
					newRow.Append(new TableCell(new Paragraph(new Run(new Text(stat.Percent.HasValue ? stat.Percent.Value.ToString("0.0") : "0")))));
				else if (_scoreType == ScoreType.Mark)
					newRow.Append(new TableCell(new Paragraph(new Run(new Text(stat.Mark != 0 ? stat.Mark.ToString() : String.Empty)))));
				else
				{
					newRow.Append(new TableCell(new Paragraph(new ParagraphProperties(
				new Justification()
				{
					Val = JustificationValues.Center
				}), new Run(new Text(stat.IsPassed ? "да" : String.Empty)))));
				}

				statTable.Append(newRow);
			}

			documentBody.Append(statTable);
		}

		public void GetHtmlStatistics()
		{
			try
			{
				if (_scoreType == ScoreType.Percent)
				{
					GridViewMain.Columns[11].Visible = true;
					GridViewMain.Columns[10].Visible = false;
					GridViewMain.Columns[8].Visible = false;
				}
				else if (_scoreType == ScoreType.Mark)
				{
					GridViewMain.Columns[12].Visible = true;
					GridViewMain.Columns[10].Visible = false;
					GridViewMain.Columns[9].Visible = false;
					GridViewMain.Columns[8].Visible = false;
					GridViewMain.Columns[7].Visible = false;
				}
				GridViewMain.DataSource = StatisticsHelper.GetStatistics(_scoreType, _score, _five, _four, _three);
				GridViewMain.DataBind();
			}
			catch
			{
				Response.Redirect("~/Default.aspx");
			}
		}
	}
}
