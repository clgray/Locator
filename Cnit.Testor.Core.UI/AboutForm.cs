using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.IO;

namespace Cnit.Testor.Core.UI
{
    public partial class AboutForm : Form
    {
        private string _version;
        private NativeMethods.MARGINS _margins;
        private Image _image;
		private int _osVer;

        public AboutForm()
        {
            InitializeComponent();
            SetGlassRegion();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            _version = "v. " + Cnit.Testor.Core.TestingSystem.LocatorVersion + "." + version.Build;
            ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            _image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.Refresh();
        }

		private void SetGlassRegion()
		{
			this.Paint += new PaintEventHandler(AboutForm_Paint);
			_osVer = Environment.OSVersion.Version.Major;
			if (_osVer >= 6)
			{
				if (NativeMethods.DwmIsCompositionEnabled())
				{
					_margins = new NativeMethods.MARGINS();
					_margins.Top = this.ClientSize.Height;
					_margins.Left = this.Width;
					_margins.Bottom = this.Height;
					_margins.Right = this.Width;
					NativeMethods.DwmExtendFrameIntoClientArea(this.Handle, ref _margins);
				}
			}
		}

        void AboutForm_Paint(object sender, PaintEventArgs e)
        {
			if (_osVer >= 6)
			{
				if (NativeMethods.DwmIsCompositionEnabled())
				{
					e.Graphics.Clear(Color.Black);
					Rectangle clientArea = new Rectangle(0, 0,
					this.ClientRectangle.Width,
					this.ClientRectangle.Height);
					Brush b = new SolidBrush(this.BackColor);
					e.Graphics.FillRectangle(b, clientArea);
					e.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);
				}
			}
            e.Graphics.DrawImage(_image, 154, 105);
            Font currFont = new Font(FontFamily.GenericSerif, 15);
            SizeF size = e.Graphics.MeasureString(_version, currFont);
            e.Graphics.DrawString(_version, currFont, new SolidBrush(Color.Black),
                new PointF((_image.Width / 2) + 140, (_image.Height / 2 - size.Height / 2) + 85));
            e.Graphics.DrawString(
                "Copyright © 2005 - 2009 ЦНИТ /", Font, new SolidBrush(Color.Black),
                new PointF(288, 202));
            e.Graphics.DrawString(
                "Copyright © 2007 - 2009 ", Font, new SolidBrush(Color.Black),
                new PointF(288, 215));
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
			if (_osVer >= 6)
			{
				if (NativeMethods.DwmIsCompositionEnabled())
				{
					if (m.Msg == NativeMethods.WM_NCHITTEST
					  && m.Result.ToInt32() == NativeMethods.HTCLIENT)
					{
						m.Result = new IntPtr(NativeMethods.HTCAPTION);
					}
				}
			}
        }
    }
}
