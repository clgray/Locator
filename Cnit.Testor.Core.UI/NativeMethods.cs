using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Cnit.Testor.Core.UI
{
    public static class NativeMethods
    {
        /// <summary>
        /// The struct used to pass the Glass margins to the Win32 API
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }
        /// <summary>
        /// The API used to extend the GLass margins into the client area
        /// </summary>
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        /// <summary>
        /// Determins whether the Desktop Windows Manager is enabled
        /// and can therefore display Aero 
        /// </summary>
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();

        // consts for wndproc
        internal const int WM_NCHITTEST = 0x84;
        internal const int HTCLIENT = 1;
        internal const int HTCAPTION = 2;

        [DllImport("kernel32.dll")]
        public static extern Int32 AllocConsole();
    }
}
