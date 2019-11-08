using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Cnit.Testor.Core.Parsing.DocProcessing;
using System.Globalization;

namespace Cnit.Testor.Core.Parsing
{
    internal sealed class RtfParser
    {
        private RichTextBox _richTextBox;
        private List<HtmlStore> _htmlStoreList;
        private List<WaitHandle> _handles;
        private delegate object[] GetTestDeligate(FileInfo rtfFile, Cnit.Testor.Core.Parsing.TestConverter.ParsingFinishDelegate callback);
        private delegate object[] GetTestStringDeligate(string rtf, Cnit.Testor.Core.Parsing.TestConverter.ParsingFinishDelegate callback);

        public static HtmlStore[] Parse(string fileName)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.LoadFile(fileName);
            RtfParser parser = new RtfParser(richTextBox);
            return parser.GetTest();
        }

        private RtfParser(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
            _htmlStoreList = new List<HtmlStore>();
            _handles = new List<WaitHandle>();
        }

        private static HtmlStore[] GetTest(string rtf)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Rtf = rtf;
            RtfParser parser = new RtfParser(richTextBox);
            return parser.GetTest();
        }

        private static void GetTestAsync(string rtf, Cnit.Testor.Core.Parsing.TestConverter.ParsingFinishDelegate callback)
        {
            GetTestStringDeligate gettest = GetTestAsyncEx;
            gettest.BeginInvoke(rtf, callback, GetAsyncResult, gettest);
        }

        private static object[] GetTestAsyncEx(string rtf, Cnit.Testor.Core.Parsing.TestConverter.ParsingFinishDelegate callback)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Rtf = rtf;
            RtfParser parser = new RtfParser(richTextBox);
            object[] retValue = new object[] { null, parser.GetTest(), callback };
            return retValue;
        }

        private static void GetAsyncResult(IAsyncResult ar)
        {
            object[] arr;
            if (ar.AsyncState is GetTestDeligate)
            {
                GetTestDeligate deligate = (GetTestDeligate)ar.AsyncState;
                arr = deligate.EndInvoke(ar);
            }
            else if (ar.AsyncState is GetTestStringDeligate)
            {
                GetTestStringDeligate deligate = (GetTestStringDeligate)ar.AsyncState;
                arr = deligate.EndInvoke(ar);
            }
            else
                return;
            Cnit.Testor.Core.Parsing.TestConverter.ParsingFinishDelegate callback = (Cnit.Testor.Core.Parsing.TestConverter.ParsingFinishDelegate)arr[2];
            callback.Invoke((arr[0] as FileInfo), (arr[1] as HtmlStore[]));
        }

        private HtmlStore[] GetTest()
        {
            _richTextBox.AppendText("►");
            int start = _richTextBox.Find("1.");
            RichTextBox rtb2 = new RichTextBox();
            bool b = true;
            string st = "2.";
            int questionIndex = 2;
            int end = _richTextBox.Find(st, start + st.Length, RichTextBoxFinds.MatchCase);
            if (end == -1)
            {
                end = _richTextBox.Find("►", start + 2, RichTextBoxFinds.MatchCase);
                b = false;
            }
            while (end != -1)
            {
                _richTextBox.Select(start + ((questionIndex - 1).ToString(CultureInfo.InvariantCulture) + ".").Length, end - start - ((questionIndex - 1).ToString(CultureInfo.InvariantCulture) + ".").Length);
                rtb2.Rtf = _richTextBox.SelectedRtf;
                start = end;
                questionIndex++;
                st = questionIndex.ToString(CultureInfo.InvariantCulture) + ".";
                if (b) end = _richTextBox.Find(st, start + ((questionIndex - 1).ToString(CultureInfo.InvariantCulture) + ".").Length, RichTextBoxFinds.MatchCase);
                else end = -1;
                if ((end == -1) && (b))
                {
                    end = _richTextBox.Find("►", start + ((questionIndex - 1).ToString(CultureInfo.InvariantCulture) + ".").Length, RichTextBoxFinds.MatchCase);
                    b = false;
                }
                try
                {
                    QuestionProsess(rtb2, questionIndex);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            foreach (var handle in _handles)
            {
                handle.WaitOne();
                handle.Close();
            }
            return _htmlStoreList.ToArray();
        }

        private void QuestionProsess(RichTextBox rtq, int questionIndex)
        {
            int end = rtq.Find("a)");
            if (end == -1)
                rtq.SelectAll();
            else
                rtq.Select(0, end - 1);
            ManualResetEvent mre = new ManualResetEvent(false);
            _handles.Add(mre);
            QuestionProsessAsync(new object[] { rtq.SelectedRtf, rtq.Rtf, mre, questionIndex });
        }

        private void QuestionProsessAsync(object param)
        {
            object[] paramArr = (object[])param;
            string rtf = (string)paramArr[0];
            string rtfAnswers = (string)paramArr[1];
            ManualResetEvent mre = (ManualResetEvent)paramArr[2];
            int questionIndex = (int)paramArr[3] - 2;
            HtmlStore quest = new HtmlStore();
            quest.QuestIndex = questionIndex;
            lock (_htmlStoreList)
                _htmlStoreList.Add(quest);
            Rtf2HTML.GetHtml(rtf, ref quest);
            AnsversProsess(rtfAnswers, quest);
            quest.QuestionType = QuestionTypeHelper.GetQuestionType(quest);
            mre.Set();
        }

        private void AnsversProsess(string rtf, HtmlStore quest)
        {
            using (RichTextBox rtq = new RichTextBox())
            {
                rtq.Rtf = rtf;
                rtq.AppendText("►");
                int start = rtq.Find("a)");
                string st = "b)";
                bool b = true;
                int n = 98;
                using (RichTextBox Rta = new RichTextBox())
                {
                    int end = rtq.Find(st, start + 2, RichTextBoxFinds.MatchCase);
                    if (end == -1)
                    {
                        end = rtq.Find("►", start + 2, RichTextBoxFinds.MatchCase);
                        b = false; ;
                    }
                    while (end != -1)
                    {
                        bool isTrue = false;
                        rtq.Select(start + 2, end - start - 2);
                        Rta.Rtf = rtq.SelectedRtf;
                        start = end;
                        n++;
                        st = (char)n + ")";
                        if (b) end = rtq.Find(st, start + 2, RichTextBoxFinds.MatchCase);
                        else end = -1;
                        if ((end == -1) && (b))
                        {
                            end = rtq.Find("►", start + 2, RichTextBoxFinds.MatchCase);
                            b = false; ;
                        }
                        if (Rta.Find("!!!", RichTextBoxFinds.MatchCase) > -1)
                        {
                            Rta.Select(Rta.Find("!!!", RichTextBoxFinds.MatchCase), 3);
                            Rta.SelectedText = String.Empty;
                            isTrue = true;
                        }
                        HtmlStore answer = Rtf2HTML.GetHtml(Rta.Rtf);
                        answer.IsTrue = isTrue;
                        quest.SubItems.Add(answer);
                    }
                }
            }
        }
    }
}
