using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Cnit.Testor.Core.Parsing.DocProcessing
{
    internal sealed class Rtf2HTML
    {
        private bool _isBold = false, _isItalic = false, _isUnderline = false;
        private bool _isBullet = false, _isTable = false;
        private int _charOffset = 0;
        private string _colorName = "Black";
        private RichTextBox _rtfCom = new RichTextBox();
        private HtmlStore _htmlStore;
        private bool ENABLE_TABLES = false;

        private HtmlStore HtmlStore
        {
            get
            {
                if (String.IsNullOrEmpty(_htmlStore.Html))
                    ConvertRtf();
                return _htmlStore;
            }
        }

        public static HtmlStore GetHtml(string rtf)
        {
            Rtf2HTML rtf2Html = new Rtf2HTML(rtf);
            return rtf2Html.HtmlStore;
        }

        public static void GetHtml(string rtf, ref HtmlStore store)
        {
            Rtf2HTML rtf2Html = new Rtf2HTML(rtf, ref store);
        }

        private Rtf2HTML(string rtf)
        {
            _rtfCom.Rtf = rtf;
            _htmlStore = new HtmlStore();
        }

        private Rtf2HTML(string rtf, ref HtmlStore store)
        {
            _rtfCom.Rtf = rtf;
            _htmlStore = store;
            ConvertRtf();
        }

        private void ConvertRtf()
        {
            int count = 0;
            string st = String.Empty;
            for (int i = 0; i < _rtfCom.Lines.Length; i++)
                for (int j = 0; j < _rtfCom.Lines[i].Length + 1; j++)
                {
                    _rtfCom.Select(count, 1);
                    if (ENABLE_TABLES)
                        st += TableProcess(_rtfCom.SelectionTabs.Length > 0);
                    if (_isTable && _rtfCom.SelectedText.Contains("\t"))
                    {
                        if (ENABLE_TABLES && _rtfCom.SelectedText.Contains("\n"))
                        {
                            st += "</tr>";
                            _rtfCom.Select(count + 1, 1);
                            if (_rtfCom.SelectionTabs.Length > 0)
                                st += "<tr><td>";
                            _rtfCom.Select(count, 1);
                        }
                        else
                        {
                            _rtfCom.Select(count + 1, 1);
                            if (_rtfCom.SelectionType != (RichTextBoxSelectionTypes.Text
                                | RichTextBoxSelectionTypes.MultiChar) &&
                                _rtfCom.SelectionType != (RichTextBoxSelectionTypes.Text
                                | RichTextBoxSelectionTypes.MultiChar | RichTextBoxSelectionTypes.Object) &&
                                _rtfCom.SelectionType != (RichTextBoxSelectionTypes.Text | RichTextBoxSelectionTypes.Object
                                | RichTextBoxSelectionTypes.MultiChar | RichTextBoxSelectionTypes.MultiObject))
                            {
                                CloseTags(ref st);
                                st += "</td><td>";
                            }
                            _rtfCom.Select(count, 1);
                        }
                    }
                    if (_rtfCom.SelectionType == RichTextBoxSelectionTypes.Text)
                    {
                        st += BoldProcess(_rtfCom.SelectionFont.Bold);
                        st += ItalicProcess(_rtfCom.SelectionFont.Italic);
                        st += UnderlineProcess(_rtfCom.SelectionFont.Underline);
                        st += CharOffsetProcess(_rtfCom.SelectionCharOffset);
                        st += BulletProcess(_rtfCom.SelectionBullet);
                        if (_rtfCom.SelectedRtf.IndexOf("\\super") > 0)
                            st += CharOffsetProcess(3);
                        if (_rtfCom.SelectedRtf.IndexOf("\\sub") > 0)
                            st += CharOffsetProcess(-3);
                        st += ColorProcess(_rtfCom.SelectionColor);
                        if (_rtfCom.SelectedText == "\n")
                        {
                            if (_isBullet)
                            {
                                _rtfCom.Select(count + 1, 1);
                                if (_rtfCom.SelectionBullet)
                                    st += "<li>";
                                _rtfCom.Select(count, 1);
                            }
                            else
                                st += "<br/>";
                        }
                        else
                        {
                            char[] ch = _rtfCom.SelectedText.ToCharArray();
                            foreach (char c in ch)
                            {
                                string st1 = String.Format("&#{0};", ((UInt16)c).ToString(CultureInfo.InvariantCulture));
                                if ((UInt16)c > 1104)
                                    st += st1;
                                else
                                    st += HttpUtility.HtmlEncode(_rtfCom.SelectedText);
                            }
                        }
                    }
                    else if (_rtfCom.SelectionType == RichTextBoxSelectionTypes.Object)
                    {
                        _rtfCom.Copy();
                        byte[] pngImage = null;
                        if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
                        {
                            Bitmap bitmap = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitmap.Save(ms, ImageFormat.Png);
                                pngImage = ms.ToArray();
                                ms.Close();
                            }
                        }
                        else
                        {
                            if (ClipboardAPI.OpenClipboard(_rtfCom.Handle))
                                if (ClipboardAPI.IsClipboardFormatAvailable(ClipboardAPI.CF_ENHMETAFILE))
                                {
                                    IntPtr henmetafile = ClipboardAPI.GetClipboardData(ClipboardAPI.CF_ENHMETAFILE);
                                    Metafile metaFile = new Metafile(henmetafile, true);
                                    ClipboardAPI.CloseClipboard();
                                    int w = FindSize(_rtfCom.SelectedRtf, "picwgoal");
                                    int h = FindSize(_rtfCom.SelectedRtf, "pichgoal");

                                    pngImage = RtfImage.GetMetafile(metaFile, w, h);

                                    Marshal.Release(henmetafile);
                                }
                        }
                        if (pngImage == null)
                        {
                            count++;
                            continue;
                        }
                        Guid unid = _htmlStore.AddImage(pngImage);
                        st = String.Format("{0}<img src=\"#${1}.png\"/>", st, unid.ToString());
                    }
                    else if (_rtfCom.SelectionType == RichTextBoxSelectionTypes.Object)
                    {
                        byte[] pngImage = RtfImage.GetBitmap(_rtfCom.SelectedRtf);
                        if (pngImage == null)
                        {
                            count++;
                            continue;
                        }
                        Guid unid = _htmlStore.AddImage(pngImage);
                        st = String.Format("{0}<img src=\"#${1}.png\"/>", st, unid.ToString());
                    }

                    count++;
                }
            CloseTags(ref st);
            _htmlStore.Html = st;
        }

        private void CloseTags(ref string st)
        {
            st += BoldProcess(false);
            st += ItalicProcess(false);
            st += UnderlineProcess(false);
            st += BulletProcess(false);
            st += ColorProcess(_rtfCom.SelectionColor);
            if (_charOffset > 0) st += "</sup>";
            if (_charOffset < 0) st += "</sub>";
        }

        private string BoldProcess(bool isBold)
        {
            if (_isBold == isBold) return (String.Empty);
            if ((!_isBold) && (isBold)) { _isBold = isBold; return ("<b>"); }
            if ((_isBold) && (!isBold)) { _isBold = isBold; return ("</b>"); }
            return (String.Empty);
        }

        private string UnderlineProcess(bool isUnderline)
        {
            if (_isUnderline == isUnderline) return (String.Empty);
            if ((!_isUnderline) && (isUnderline)) { _isUnderline = isUnderline; return ("<u>"); }
            if ((_isUnderline) && (!isUnderline)) { _isUnderline = isUnderline; return ("</u>"); }
            return (String.Empty);
        }

        private string ItalicProcess(bool isItalic)
        {
            if (_isItalic == isItalic) return (String.Empty);
            if ((!_isItalic) && (isItalic)) { _isItalic = isItalic; return ("<i>"); }
            if ((_isItalic) && (!isItalic)) { _isItalic = isItalic; return ("</i>"); }
            return (String.Empty);
        }

        private string BulletProcess(bool isBullet)
        {
            if (_isBullet == isBullet) return (String.Empty);
            if ((!_isBullet) && (isBullet)) { _isBullet = isBullet; return ("<ul><li>"); }
            if ((_isBullet) && (!isBullet)) { _isBullet = isBullet; return ("</ul>"); }
            return (String.Empty);
        }

        private string TableProcess(bool isTable)
        {
            if (_isTable == isTable) return (String.Empty);
            if ((!_isTable) && (isTable)) { _isTable = isTable; return ("<table border=\"1\"><tr><td>"); }
            if ((_isTable) && (!isTable)) { _isTable = isTable; return ("</table>"); }
            return (String.Empty);
        }

        private string CharOffsetProcess(int charOffset)
        {
            if (charOffset == _charOffset) return (String.Empty);
            if ((charOffset > 0) && (_charOffset == 0)) { _charOffset = charOffset; return ("<sup>"); }
            if ((charOffset < 0) && (_charOffset == 0)) { _charOffset = charOffset; return ("<sub>"); }
            if ((charOffset == 0) && (_charOffset > 0)) { _charOffset = charOffset; return ("</sup>"); }
            if ((charOffset == 0) && (_charOffset < 0)) { _charOffset = charOffset; return ("</sub>"); }
            if ((charOffset > 0) && (_charOffset < 0)) { _charOffset = charOffset; return ("</sub><sup>"); }
            if ((charOffset < 0) && (_charOffset > 0)) { _charOffset = charOffset; return ("</sup><sub>"); }
            return ("");
        }

        private string ColorProcess(Color cl_color)
        {
            string color = ColorTranslator.ToHtml(cl_color);
            if (_colorName == color) return (String.Empty);
            if ((_colorName == "Black") && (color != "Black")) { _colorName = color; return ("<font color=\"" + color + "\">"); }
            if ((_colorName != "Black") && (color == "Black")) { _colorName = color; return ("</font>"); }
            if ((_colorName != "Black") && (color != "Black")) { _colorName = color; return ("</font><font color=\"" + color + "\">"); }
            return (String.Empty);
        }

        private int FindSize(string st, string sub)
        {
            int i = 0;
            string str = String.Empty;
            string s = String.Empty;
            int pos;//= sub.Length;
            pos = st.IndexOf(sub);
            if (st.IndexOf(sub) > 0)
            {
                pos = pos + sub.Length;
                s = st.Substring(pos, 1);
                while ((s != "\\") && (s != " "))
                {
                    str += s;
                    pos++;
                    s = st.Substring(pos, 1);
                }
                try
                {
                    i = Convert.ToInt32(str) / 15;
                }
                catch
                {
                    i = 0;
                }
            }
            return i;
        }
    }
}