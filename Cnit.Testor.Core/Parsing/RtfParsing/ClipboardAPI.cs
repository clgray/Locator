using System;
using System.Runtime.InteropServices;

namespace Cnit.Testor.Core.Parsing.DocProcessing
{
    /// <summary>
    /// Summary description for ClipboardAPI.
    /// </summary>
    public class ClipboardAPI
    {
        [DllImport("user32.dll")]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll")]
        static extern bool EmptyClipboard();
        [DllImport("user32.dll")]
        static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport("user32.dll")]
        public static extern IntPtr GetClipboardData(uint uFormat);
        [DllImport("user32.dll")]
        public static extern bool CloseClipboard();
        [DllImport("gdi32.dll")]
        static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, IntPtr hNULL);
        [DllImport("gdi32.dll")]
        static extern bool DeleteEnhMetaFile(IntPtr hemf);

        [DllImport("user32.dll")]
        public static extern bool IsClipboardFormatAvailable(uint format);

        public const int CF_ENHMETAFILE = 14;

    }
}
