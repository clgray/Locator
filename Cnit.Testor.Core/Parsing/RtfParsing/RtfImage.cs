using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Cnit.Testor.Core.Parsing.DocProcessing
{
    internal static class RtfImage
    {
        public static byte[] GetBitmap(string rtf)
        {
            int pictIndex = rtf.IndexOf(@"\pict", 0,
                rtf.Length, StringComparison.InvariantCulture);
            bool isObject = rtf.IndexOf(@"\object", 0,
                rtf.Length, StringComparison.InvariantCulture) == -1 ? false : true;
            if (pictIndex < 0)
                return null;
            int start = 0;
            int end = 0;
            for (int x = pictIndex; x < rtf.Length; x++)
            {
                if (rtf[x] == ' ')
                {
                    start = x + 1;
                }
                if (rtf[x] == '}')
                {
                    end = x;
                    break;
                }
            }
            string imageHeader = rtf.Substring(pictIndex, start - pictIndex);
            int rtfWidth = GetRtfAttributeIntValue("picwgoal", imageHeader);
            int rtfHeight = GetRtfAttributeIntValue("pichgoal", imageHeader);
            string imageString = rtf.Substring(start, end - start).Replace("\r\n", String.Empty);
            byte[] imageByteArray = new byte[imageString.Length / 2];
            int r = 0;
            for (int q = 0; q < imageString.Length; q += 2)
            {
                imageByteArray[r] = Byte.Parse(
                    imageString[q].ToString(CultureInfo.InvariantCulture) + imageString[q + 1].ToString(CultureInfo.InvariantCulture), NumberStyles.HexNumber);
                r++;
            }
            byte[] retValue;
            using (Image img = GetBitmap(rtfWidth, rtfHeight, imageByteArray, isObject))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);
                    retValue = ms.ToArray();
                    ms.Close();
                }
				img.Dispose();
            }
            return retValue;
        }

		private static Image GetBitmap(int rtfWidth, int rtfHeight, byte[] imageByteArray, bool isObject)
		{
			int width = rtfWidth, height = rtfHeight;
			if (isObject)
			{
				width = (int)(rtfWidth * 1.6);
				height = (int)(rtfHeight * 1.6);
			}
			int newWidth = width / 15, newHeight = height / 15;
			Bitmap rtfBitmap;
			if (!isObject)
			{
				using (MemoryStream ms = new MemoryStream(imageByteArray, false))
				{
					Image img = Image.FromStream(ms);
					ms.Close();
					rtfBitmap = new Bitmap(img);
				}
			}
			else
			{
				rtfBitmap = new Bitmap(width, height);
				using (Graphics g = Graphics.FromImage(rtfBitmap))
				{
					IntPtr hdc = g.GetHdc();
					IntPtr ptr = NativeMethods.SetMetaFileBitsEx(imageByteArray.Length, ref imageByteArray[0]);
					NativeMethods.PlayMetaFile(hdc, ptr);
					g.ReleaseHdc();
					Marshal.Release(ptr);
					Marshal.Release(hdc);
				}
			}
			Bitmap retValue = new Bitmap(newWidth, newHeight);
			using (Graphics gx = Graphics.FromImage((Image)retValue))
				gx.DrawImage(rtfBitmap, 0, 0, newWidth, newHeight);
			rtfBitmap.Dispose();
			return retValue;
		}

        private static int GetRtfAttributeIntValue(string attr, string rtf)
        {
            int retValue;
            if (!int.TryParse(GetRtfAttributeValue(attr, rtf), out retValue))
                return 0;
            else
                return retValue;
        }

        private static string GetRtfAttributeValue(string attr, string rtf)
        {
            int attrIndex = rtf.IndexOf(String.Format(@"\{0}", attr), 0,
                rtf.Length, StringComparison.InvariantCulture);
            attrIndex += attr.Length + 1;
            StringBuilder sb = new StringBuilder();
            while (rtf[attrIndex] != '\\' && rtf[attrIndex] != ' ')
            {
                sb.Append(rtf[attrIndex]);
                attrIndex++;
            }
            return sb.ToString();
        }

        public static byte[] GetMetafile(Metafile metafile, int picw, int pich)
        {
            byte[] retValue = null;

            //if (picw<20 || pich < 20)
            //{
                picw = (int)(picw * 1.6);
                pich = (int)(pich * 1.6);
           // }

            Bitmap tmbBitmap;
            if ((picw != 0) && (pich != 0))
                tmbBitmap = new Bitmap(metafile, picw, pich);
            else
                tmbBitmap = new Bitmap(metafile);

            using (MemoryStream ms = new MemoryStream())
            {
                tmbBitmap.Save(ms, ImageFormat.Png);
                retValue = ms.ToArray();
                ms.Close();
            }

            tmbBitmap.Dispose();
            metafile.Dispose();

            return retValue;
        }
    }
}
