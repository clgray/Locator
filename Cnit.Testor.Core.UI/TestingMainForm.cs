using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.UI.Server.Login;
using System.Threading;
using Cnit.Testor.Core;
using System.ServiceModel;
using Cnit.Testor.Core.UI;

namespace Cnit.Testor.Core.UI
{
    public partial class TestingMainForm : Form
    {
        private string _formText = String.Format("Система тестирования {0} {1}", TestingSystem.DisplayName, TestingSystem.LocatorVersion);
        private static FirstTestForm _selectUserForm = new FirstTestForm();
        private static SplashScreenForm _splash = new SplashScreenForm();
        private delegate void InitCredintailsDelegate();
        private static TestingMainForm _mainForm;

        public static TestingMainForm CurrentForm
        {
            get
            {
                return _mainForm;
            }
        }

        public void ShowMainForm()
        {
            _mainForm.WindowState = FormWindowState.Maximized;
            _mainForm.ShowInTaskbar = true;
            _mainForm.Opacity = 1;
        }

        public TestingMainForm()
        {
            InitializeComponent();
            this.Text = _formText;
            LoginHelper.Splash = _splash;
            LoginHelper.FirstTF = _selectUserForm;
            SystemStateManager.IsEnable = false;
            _mainForm = this;
            lblTestSystem.Text = String.Format("{0} {1}", TestingSystem.DisplayName, TestingSystem.LocatorVersion);
            InitDate();
            if (LoginHelper.NeedOpen != null)
            {
                ShowMainForm();
                FileTestingForm ftf = new FileTestingForm();
                ftf.MdiParent = _mainForm;
                ftf.Show();
            }
            else
            {
                this.Opacity = 0;
                _splash.Show();
                LoginHelper.AnonymousLogin();
            }
        }

        private void InitDate()
        {
            toolStripLabelDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripLabelTime.Text = DateTime.Now.ToString("hh:mm:ss");
            if (DateTime.Now.TimeOfDay.TotalSeconds < 5)
                InitDate();
        }
    }
}
