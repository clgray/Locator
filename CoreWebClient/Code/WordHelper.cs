using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace CoreWebClient.Code
{
	public static class WordHelper
	{
		public static Footer GenerateFooter()
		{
			Footer footer1 = new Footer()
			{
				MCAttributes = new MarkupCompatibilityAttributes()
				{
					Ignorable = "w14 wp14"
				}
			};

			footer1.SetAttribute(new OpenXmlAttribute("xmlns", "wpi", "http://www.w3.org/2000/xmlns/", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk"));

			SdtBlock sdtBlock1 = new SdtBlock();

			SdtProperties sdtProperties1 = new SdtProperties();
			SdtId sdtId1 = new SdtId()
			{
				Val = -2004816677
			};

			SdtContentDocPartObject sdtContentDocPartObject1 = new SdtContentDocPartObject();
			DocPartGallery docPartGallery1 = new DocPartGallery()
			{
				Val = "Page Numbers (Bottom of Page)"
			};
			DocPartUnique docPartUnique1 = new DocPartUnique();

			sdtContentDocPartObject1.Append(docPartGallery1);
			sdtContentDocPartObject1.Append(docPartUnique1);

			sdtProperties1.Append(sdtId1);
			sdtProperties1.Append(sdtContentDocPartObject1);

			SdtContentBlock sdtContentBlock1 = new SdtContentBlock();

			SdtBlock sdtBlock2 = new SdtBlock();

			SdtProperties sdtProperties2 = new SdtProperties();
			SdtId sdtId2 = new SdtId()
			{
				Val = 262557138
			};

			SdtContentDocPartObject sdtContentDocPartObject2 = new SdtContentDocPartObject();
			DocPartGallery docPartGallery2 = new DocPartGallery()
			{
				Val = "Page Numbers (Top of Page)"
			};
			DocPartUnique docPartUnique2 = new DocPartUnique();

			sdtContentDocPartObject2.Append(docPartGallery2);
			sdtContentDocPartObject2.Append(docPartUnique2);

			sdtProperties2.Append(sdtId2);
			sdtProperties2.Append(sdtContentDocPartObject2);

			SdtContentBlock sdtContentBlock2 = new SdtContentBlock();

			Paragraph paragraph1 = new Paragraph()
			{
				RsidParagraphAddition = "000A3202",
				RsidRunAdditionDefault = "000A3202",
				ParagraphId = "450F18F9",
				TextId = "3669B4E6"
			};

			ParagraphProperties paragraphProperties1 = new ParagraphProperties();
			ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId()
			{
				Val = "a6"
			};
			Justification justification1 = new Justification()
			{
				Val = JustificationValues.Center
			};

			paragraphProperties1.Append(paragraphStyleId1);
			paragraphProperties1.Append(justification1);

			Run run1 = new Run();
			Text text1 = new Text()
			{
				Space = SpaceProcessingModeValues.Preserve
			};
			text1.Text = "Страница ";

			run1.Append(text1);

			Run run2 = new Run();

			RunProperties runProperties1 = new RunProperties();
			Bold bold1 = new Bold();
			FontSize fontSize1 = new FontSize()
			{
				Val = "24"
			};
			FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript()
			{
				Val = "24"
			};

			runProperties1.Append(bold1);
			runProperties1.Append(fontSize1);
			runProperties1.Append(fontSizeComplexScript1);
			FieldChar fieldChar1 = new FieldChar()
			{
				FieldCharType = FieldCharValues.Begin
			};

			run2.Append(runProperties1);
			run2.Append(fieldChar1);

			Run run3 = new Run();

			RunProperties runProperties2 = new RunProperties();
			Bold bold2 = new Bold();

			runProperties2.Append(bold2);
			FieldCode fieldCode1 = new FieldCode();
			fieldCode1.Text = "PAGE";

			run3.Append(runProperties2);
			run3.Append(fieldCode1);

			Run run4 = new Run();

			RunProperties runProperties3 = new RunProperties();
			Bold bold3 = new Bold();
			FontSize fontSize2 = new FontSize()
			{
				Val = "24"
			};
			FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript()
			{
				Val = "24"
			};

			runProperties3.Append(bold3);
			runProperties3.Append(fontSize2);
			runProperties3.Append(fontSizeComplexScript2);
			FieldChar fieldChar2 = new FieldChar()
			{
				FieldCharType = FieldCharValues.Separate
			};

			run4.Append(runProperties3);
			run4.Append(fieldChar2);

			Run run5 = new Run();

			RunProperties runProperties4 = new RunProperties();
			Bold bold4 = new Bold();
			NoProof noProof1 = new NoProof();

			runProperties4.Append(bold4);
			runProperties4.Append(noProof1);
			Text text2 = new Text();
			text2.Text = "2";

			run5.Append(runProperties4);
			run5.Append(text2);

			Run run6 = new Run();

			RunProperties runProperties5 = new RunProperties();
			Bold bold5 = new Bold();
			FontSize fontSize3 = new FontSize()
			{
				Val = "24"
			};
			FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript()
			{
				Val = "24"
			};

			runProperties5.Append(bold5);
			runProperties5.Append(fontSize3);
			runProperties5.Append(fontSizeComplexScript3);
			FieldChar fieldChar3 = new FieldChar()
			{
				FieldCharType = FieldCharValues.End
			};

			run6.Append(runProperties5);
			run6.Append(fieldChar3);

			Run run7 = new Run();
			Text text3 = new Text()
			{
				Space = SpaceProcessingModeValues.Preserve
			};
			text3.Text = " из ";

			run7.Append(text3);

			Run run8 = new Run();

			RunProperties runProperties6 = new RunProperties();
			Bold bold6 = new Bold();
			FontSize fontSize4 = new FontSize()
			{
				Val = "24"
			};
			FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript()
			{
				Val = "24"
			};

			runProperties6.Append(bold6);
			runProperties6.Append(fontSize4);
			runProperties6.Append(fontSizeComplexScript4);
			FieldChar fieldChar4 = new FieldChar()
			{
				FieldCharType = FieldCharValues.Begin
			};

			run8.Append(runProperties6);
			run8.Append(fieldChar4);

			Run run9 = new Run();

			RunProperties runProperties7 = new RunProperties();
			Bold bold7 = new Bold();

			runProperties7.Append(bold7);
			FieldCode fieldCode2 = new FieldCode();
			fieldCode2.Text = "NUMPAGES";

			run9.Append(runProperties7);
			run9.Append(fieldCode2);

			Run run10 = new Run();

			RunProperties runProperties8 = new RunProperties();
			Bold bold8 = new Bold();
			FontSize fontSize5 = new FontSize()
			{
				Val = "24"
			};
			FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript()
			{
				Val = "24"
			};

			runProperties8.Append(bold8);
			runProperties8.Append(fontSize5);
			runProperties8.Append(fontSizeComplexScript5);
			FieldChar fieldChar5 = new FieldChar()
			{
				FieldCharType = FieldCharValues.Separate
			};

			run10.Append(runProperties8);
			run10.Append(fieldChar5);

			Run run11 = new Run();

			RunProperties runProperties9 = new RunProperties();
			Bold bold9 = new Bold();
			NoProof noProof2 = new NoProof();

			runProperties9.Append(bold9);
			runProperties9.Append(noProof2);
			Text text4 = new Text();
			text4.Text = "2";

			run11.Append(runProperties9);
			run11.Append(text4);

			Run run12 = new Run();

			RunProperties runProperties10 = new RunProperties();
			Bold bold10 = new Bold();
			FontSize fontSize6 = new FontSize()
			{
				Val = "24"
			};
			FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript()
			{
				Val = "24"
			};

			runProperties10.Append(bold10);
			runProperties10.Append(fontSize6);
			runProperties10.Append(fontSizeComplexScript6);
			FieldChar fieldChar6 = new FieldChar()
			{
				FieldCharType = FieldCharValues.End
			};

			run12.Append(runProperties10);
			run12.Append(fieldChar6);

			paragraph1.Append(paragraphProperties1);
			paragraph1.Append(run1);
			paragraph1.Append(run2);
			paragraph1.Append(run3);
			paragraph1.Append(run4);
			paragraph1.Append(run5);
			paragraph1.Append(run6);
			paragraph1.Append(run7);
			paragraph1.Append(run8);
			paragraph1.Append(run9);
			paragraph1.Append(run10);
			paragraph1.Append(run11);
			paragraph1.Append(run12);

			sdtContentBlock2.Append(paragraph1);

			sdtBlock2.Append(sdtProperties2);
			sdtBlock2.Append(sdtContentBlock2);

			sdtContentBlock1.Append(sdtBlock2);

			sdtBlock1.Append(sdtProperties1);
			sdtBlock1.Append(sdtContentBlock1);

			Paragraph paragraph2 = new Paragraph()
			{
				RsidParagraphAddition = "000A3202",
				RsidRunAdditionDefault = "000A3202",
				ParagraphId = "7CCB7F19",
				TextId = "77777777"
			};

			ParagraphProperties paragraphProperties2 = new ParagraphProperties();
			ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId()
			{
				Val = "a6"
			};

			paragraphProperties2.Append(paragraphStyleId2);

			paragraph2.Append(paragraphProperties2);

			footer1.Append(sdtBlock1);
			footer1.Append(paragraph2);
			return footer1;
		}
	}
}
