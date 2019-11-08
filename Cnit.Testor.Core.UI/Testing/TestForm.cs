using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.HttpServer;

namespace Cnit.Testor.Core.UI.Testing
{
    public partial class TestForm : Form
    {
        public TestForm(TestingProvider provider)
        {
            InitializeComponent();
            #if DEBUG
            this.TopMost = false;
            #endif
            testingHost.StartServer(provider);
			this.Width = Screen.PrimaryScreen.WorkingArea.Width;
			this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

		private void TestHtmlContentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			testingHost.StopServer();
		}
    }
}
