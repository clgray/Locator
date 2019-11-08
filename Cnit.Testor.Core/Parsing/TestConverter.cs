using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Cnit.Testor.Core.Parsing
{
    public static class TestConverter
    {
        public delegate void ParsingFinishDelegate(FileInfo file, HtmlStore[] htmlStore);

        public static void GetTest(string inputFile, ParsingFinishDelegate callback)
        {
            GetTest(new FileInfo(inputFile), callback);
        }

        private static void GetSavedDocument(object obj)
        {
            object[] arr = (obj as object[]);
            FileInfo inputFile = (FileInfo)arr[0];
            HtmlStore[] retValue = null;

            string fileName = WordAdapter.SaveDocument(inputFile.FullName);

            retValue = DocxParser.Parse(fileName);

            try
            {
                if (!String.IsNullOrEmpty(fileName))
                    File.Delete(fileName);
            }
            catch { }


            ParsingFinishDelegate callback = (ParsingFinishDelegate)arr[1];
            callback.Invoke(inputFile, retValue);
        }

        private static void GetTestAsync(object obj)
        {
            object[] arr = (obj as object[]);
            FileInfo inputFile = (FileInfo)arr[0];

            HtmlStore[] retValue = null;
            ParsingFinishDelegate callback = (ParsingFinishDelegate)arr[1];

            try
            {
                retValue = DocxParser.Parse(inputFile.FullName);
            }
            catch (IOException ex)
            {
                SystemMessage.ShowErrorMessage(ex);
                callback.Invoke(inputFile, null);
                return;
            }

            callback.Invoke(inputFile, retValue);
        }

        public static void GetTest(FileInfo inputFile, ParsingFinishDelegate callback)
        {
            string ext = inputFile.Extension.ToLower();

            try
            {
                if (ext == ".docx")
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(GetTestAsync));
                    thread.Start(new object[] { inputFile, callback });
                    return;
                }
                else if (ext == ".doc" || ext == ".rtf" || ext == ".txt")
                {
                    try
                    {
                        WordAdapter.OpenWord();
                    }
                    catch
                    {
                        MessageBox.Show("Microsoft Word не найден.");
                        return;
                    }

                    if (WordAdapter.HasDocxSupport)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(GetSavedDocument));
                        thread.Start(new object[] { inputFile, callback });
                    }
                    else
                    {
                        string fileName = WordAdapter.SaveDocument(inputFile.FullName);

                        HtmlStore[] retValue = RtfParser.Parse(fileName);

                        try
                        {
                            if (!String.IsNullOrEmpty(fileName))
                                File.Delete(fileName);
                        }
                        catch { }

                        callback(inputFile, retValue);
                    }
                }
            }
            catch (IOException ex)
            {
                SystemMessage.ShowErrorMessage(ex);
                callback(inputFile, null);
                return;
            }
        }
    }
}
