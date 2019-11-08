using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Cnit.Testor.Core.Parsing
{
    internal static class NativeMethods
    {
        [DllImport("gdi32")]
        public static extern IntPtr PlayMetaFile(IntPtr hDC, IntPtr hMF);
        [DllImport("gdi32")]
        public static extern IntPtr SetMetaFileBitsEx(int nSize, ref byte lpData);
    }
}
