using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Cnit.Testor.Core.Parsing
{
    public static class WordAdapter
    {
        private static ApplicationClass _app = null;
        private static int _majorVersion;

        public static bool IsWordOpened
        {
            get
            {
                return _app != null;
            }
        }


        public static bool HasDocxSupport
        {
            get
            {
                return _majorVersion >= 12;
            }
        }

        public static string AppPath
        {
            get
            {
                string appDataPath =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appDataPath, "TestEditCore");
            }
        }

        public static void OpenWord()
        {
            if (_app != null)
                return;

            _app = new Microsoft.Office.Interop.Word.ApplicationClass();
            _app.WindowState = WdWindowState.wdWindowStateMinimize;
            _app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            _app.Visible = false;

            _majorVersion = new System.Version(_app.Version).Major;
        }

        private static bool TryOpenWord()
        {
            try
            {
                OpenWord();
            }
            catch
            {
                MessageBox.Show("Microsoft Word не найден.");
                return false;
            }

            return true;
        }

        public static void CloseWord()
        {
            if (_app == null)
                return;
            object SaveChanges = WdSaveOptions.wdDoNotSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            try
            {
                _app.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            }
            catch { }
            _app = null;

			try
			{
				foreach (var file in Directory.GetFiles(AppPath))
				{
					try
					{
						File.Delete(file);
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
        }

        public static Document OpenDocument(string fileName)
        {
            if (!TryOpenWord())
                return null;

            FileInfo fi = new FileInfo(fileName);
            string xFile = Path.Combine(AppPath, String.Format("{0}{1}", Guid.NewGuid().ToString(), fi.Extension));
            File.Copy(fileName, xFile);
            string firstFile = fileName;
            fileName = xFile;

            Document retValue = null;

            object oVisible = false;
            object ofalse = false;
            object otrue = false;
            object onil = String.Empty;
            object FileName = fileName;
            object ReadOnly = true;
            object DocumentType = WdOpenFormat.wdOpenFormatAuto;
            object DocumentDirection = WdDocumentDirection.wdLeftToRight;

            try
            {
                retValue = _app.Documents.Open(ref FileName, ref ofalse, ref ReadOnly, ref ofalse, ref onil, ref onil, ref ofalse, ref onil, ref onil, ref DocumentType, ref ofalse, ref oVisible, ref otrue, ref DocumentDirection, ref otrue, ref onil);
            }
            catch
            {
                try
                {
                    retValue = _app.Documents.Open2002(ref FileName, ref ofalse, ref ReadOnly, ref ofalse, ref onil, ref onil, ref ofalse, ref onil, ref onil, ref DocumentType, ref ofalse, ref oVisible, ref otrue, ref DocumentDirection, ref otrue);
                }
                catch
                {
                    try
                    {
                        retValue = _app.Documents.Open2000(ref FileName, ref ofalse, ref ReadOnly, ref ofalse, ref onil, ref onil, ref ofalse, ref onil, ref onil, ref DocumentType, ref ofalse, ref oVisible);
                    }
                    catch
                    {
                        try
                        {
                            retValue = _app.Documents.OpenOld(ref FileName, ref ofalse, ref ReadOnly, ref ofalse, ref onil, ref onil, ref ofalse, ref onil, ref onil, ref DocumentType);
                        }
                        catch (Exception)
                        {
                            CloseWord();
                            OpenWord();
                            return OpenDocument(firstFile);
                            //throw (new Exception("Невозможно открыть документ ", e));
                        }
                    }
                }
            }

            retValue.Activate();

            return retValue;
        }

        public static void CloseDocument(Document doc)
        {
            object SaveChanges = WdSaveOptions.wdDoNotSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;

            try
            {
                doc.Activate();
                _app.RecentFiles[1].Delete();
                (doc as _Document).Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
                doc = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось закрыть документ MSWord автоматически \n\r" + ex.Message + "\n\r Пожалуйста, попробуйте закрыть его вручную. ");
            }
        }

        public static string SaveDocument(string fileName)
        {
            string retValue = String.Empty;

            if (!TryOpenWord())
                return null;

            object missing = Type.Missing;
            object saveFormat = null;

            if (HasDocxSupport)
                saveFormat = WdSaveFormat.wdFormatXMLDocument;
            else
                saveFormat = WdSaveFormat.wdFormatRTF;

            string appPath = AppPath;
            if (!Directory.Exists(appPath))
                Directory.CreateDirectory(appPath);
            object file = null;

            if (HasDocxSupport)
                file = Path.Combine(appPath, String.Format("{0}.docx", Guid.NewGuid().ToString()));
            else
                file = Path.Combine(appPath, String.Format("{0}.rtf", Guid.NewGuid().ToString()));

            Document doc = OpenDocument(fileName);

            retValue = (string)file;

            doc.SaveAs(ref file, ref saveFormat, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing,
              ref missing, ref missing, ref missing, ref missing);

            CloseDocument(doc);

            return retValue;
        }
    }
}
