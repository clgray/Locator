using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using Cnit.Testor.Core.HttpServer;
using Cnit.Testor.Core;

namespace Cnit.Testor.Core.UI
{
    public partial class AppealForm : Form
    {
        private TestSessionStatistics _currentSession;
        private AppealProvider _provider;
        private int[] _questions;

        public AppealForm(TestSessionStatistics currentSession)
        {
            InitializeComponent();
            _currentSession = currentSession;
            this.Text += String.Format(" - {0} {1} {2}", HtmlStore.GetString(_currentSession.LastName),
                    HtmlStore.GetString(_currentSession.FirstName), HtmlStore.GetString(_currentSession.SecondName));
            _questions = StaticServerProvider.TestClient.GetSessionQuestions(_currentSession.TestSessionId);
            _provider = new AppealProvider(_currentSession, _questions, null);
            TestingHttpServer.StartServer(_provider);
            TestingHttpServer.ServerNotStarted.WaitOne();
            webBrowser.Navigate(TestingHttpServer.BaseUrl);
        }

        private void tsbForwardQuest_Click(object sender, EventArgs e)
        {
            TestingHttpServer.AllowConnections = true;
            webBrowser.Navigate(TestingHttpServer.BaseUrl);
        }

        private void tsbBackQuest_Click(object sender, EventArgs e)
        {
            _provider.GoBack();
            webBrowser.Navigate(TestingHttpServer.BaseUrl);
        }

        private void AppealForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TestingHttpServer.StopServer();
        }
    }
}
