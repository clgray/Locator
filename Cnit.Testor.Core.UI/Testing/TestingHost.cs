using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cnit.Testor.Core.HttpServer;
using System.Threading;
using Cnit.Testor.Core.UI.Server;

namespace Cnit.Testor.Core.UI.Testing
{
    public partial class TestingHost : UserControl
    {
        private TestingProvider _provider;
        private System.Windows.Forms.Timer _timer;

        public TestingHost()
        {
            InitializeComponent();
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Interval = 2000;
            SystemStateManager.StateChanged += new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            bool state = SystemStateManager.State;
            btnExit.Enabled = !state;
            btnSubmit.Enabled = !state;
            if (_provider.State == ProviderState.PreTesting)
                btnNext.Enabled = !state && _provider.IsTestActive;
            else if (_provider.State == ProviderState.Testing)
                btnNext.Enabled = !state && _provider.AllowAdmitQuestions;
            _timer.Stop();
        }

        ~TestingHost()
        {
            SystemStateManager.StateChanged -= new EventHandler<EventArgs>(SystemStateManager_StateChanged);
        }

        void SystemStateManager_StateChanged(object sender, EventArgs e)
        {
            if ((this.TopLevelControl as Form).IsHandleCreated)
            {
                this.Invoke((Action)(() =>
                {
                    if (SystemStateManager.State)
                        _timer.Enabled = true;
                    else
                    {
                        _timer.Enabled = false;
                        btnExit.Enabled = true;
                        btnSubmit.Enabled = true;
                        if (_provider.State == ProviderState.PreTesting)
                            btnNext.Enabled = _provider.IsTestActive;
                        else if (_provider.State == ProviderState.Testing)
                            btnNext.Enabled = _provider.AllowAdmitQuestions;
                    }
                }));
            }
        }

        public void StartServer(TestingProvider provider)
        {
            _provider = provider;
            _provider.TimeChanged += new EventHandler<EventArgs>(_provider_TimeChanged);
            _provider.ScoreChanged += new EventHandler<EventArgs>(_provider_ScoreChanged);
            _provider.StateChanged += new EventHandler<EventArgs>(_provider_StateChanged);
            _provider.WarningMessage += new EventHandler<EventArgs>(_provider_WarningMessage);
            TestingHttpServer.StartServer(_provider);
            TestingHttpServer.ServerNotStarted.WaitOne();
            lblTestName.Text = String.Format("Тест: \"{0}\"", _provider.TestName);
            _provider_StateChanged(this, new EventArgs());
            webBrowser.Navigate(TestingHttpServer.BaseUrl);
        }

        void _provider_TimeChanged(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                this.Invoke((Action)(() =>
                {
                    SetTestingState();
                }));
                timer.Start();
                timer_Tick(sender, e);
            }
        }

        void _provider_WarningMessage(object sender, EventArgs e)
        {
            if (!(sender is string) || sender == null)
                return;
            MessageBox.Show((string)sender, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void _provider_ScoreChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    lblScore.Text = String.Format("Набранный Балл: {0}", _provider.Score);
                }));
            }
            else
                lblScore.Text = String.Format("Набранный Балл: {0}", _provider.Score);
        }

        void _provider_StateChanged(object sender, EventArgs e)
        {
            if (_provider.State == ProviderState.PreTesting)
            {
                btnNext.Text = "Начать тест";
                btnNext.Enabled = _provider.IsTestActive;
                if (!_provider.IsTestActive)
                {
                    lblTestName.Text = _provider.NotActiveMessage;
                    lblTestName.ForeColor = Color.Red;
                    if (_provider.RequirementsTests != null)
                    {
                        string message = _provider.NotActiveMessage + ":";
                        foreach (var test in _provider.RequirementsTests)
                            message += "\n-" + test.ItemName;
                        SystemMessage.ShowWarningMessage(message);
                    }
                }
            }
            else if (_provider.State == ProviderState.Testing)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((Action)(() =>
                    {
                        SetTestingState();
                    }));
                }
                else
                {
                    SetTestingState();
                }
            }
            else if (_provider.State == ProviderState.Results)
            {
                this.Invoke((Action)(() =>
                {
                    btnNext.Text = "Выход";
                    btnNext.Enabled = true;
                    btnSubmit.Visible = false;
                    toolStrip.Visible = false;
                }));
            }
        }

        private void SetTestingState()
        {
            btnNext.Text = "Пропустить";
            btnNext.Enabled = _provider.AllowAdmitQuestions;
            toolStripSeparator.Visible = _provider.ShowRightAnswersCount;
            lblScore.Visible = _provider.ShowRightAnswersCount;
            btnSubmit.Visible = true;
            if (_provider.TimeLimit != 0)
            {
                lblTimeLimit.Visible = true;
                timer.Enabled = true;
                timer_Tick(this, new EventArgs());
            }
            pbCalc.Visible = true;
            labelStudent.Visible = true;
            labelStudentName.Visible = true;
            labelStudentName.Text = _provider.StudentDisplayName;
            _provider_ScoreChanged(this, new EventArgs());
        }

        public void StopServer()
        {
            TestingHttpServer.StopServer();
            _provider.ScoreChanged -= new EventHandler<EventArgs>(_provider_ScoreChanged);
            _provider.StateChanged -= new EventHandler<EventArgs>(_provider_StateChanged);
            _provider.TimeChanged -= new EventHandler<EventArgs>(_provider_TimeChanged);
            _provider.WarningMessage -= new EventHandler<EventArgs>(_provider_WarningMessage);
            timer.Stop();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            TestingHttpServer.Hid = Guid.NewGuid().ToString();
            if (webBrowser.Document.Forms.Count == 0)
                return;
            TestingHttpServer.AllowConnections = true;
            try
            {
                webBrowser.Document.Forms[0].Children["hid"].SetAttribute("value", TestingHttpServer.Hid);
                webBrowser.Document.Forms[0].InvokeMember("submit");
            }
            catch
            {
                foreach (HtmlElement form in webBrowser.Document.Forms)
                    GetChildElems(form.Children, form);
            }
        }

        private void GetChildElems(HtmlElementCollection elem, HtmlElement form)
        {
            foreach (HtmlElement children in elem)
            {
                if (children.Id == "hid" || children.Name == "hid")
                {
                    children.SetAttribute("value", TestingHttpServer.Hid);
                    form.InvokeMember("submit");
                    return;
                }
                else
                    GetChildElems(children.Children, form);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            TestingHttpServer.AllowConnections = true;
            if (_provider.State == ProviderState.PreTesting)
                webBrowser.Navigate(TestingHttpServer.GetUrl("start"));
            else if (_provider.State == ProviderState.Testing)
                webBrowser.Navigate(TestingHttpServer.BaseUrl);
            else if (_provider.State == ProviderState.Results)
            {
                if (this.Parent is Form)
                    (this.Parent as Form).Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_provider.State != ProviderState.Testing)
                timer.Stop();
            var time = _provider.RemaningTime;
            if (time.TotalSeconds <= 0)
            {
                timer.Stop();
                btnSubmit.Visible = false;
                lblTimeLimit.Text = "Время истекло";
                MessageBox.Show("Время, отведённое для прохождения теста, истекло.", "Время истекло", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                TestingHttpServer.AllowConnections = true;
                webBrowser.Navigate(TestingHttpServer.BaseUrl);

                return;
            }
            _provider.RemaningTime = TimeSpan.FromSeconds(_provider.RemaningTime.TotalSeconds - 1);
            lblTimeLimit.Text = String.Format("Осталось {0} мин. {1} сек.", (int)time.TotalMinutes, time.Seconds);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (SystemStateManager.TestState())
                return;
            if (_provider.State == ProviderState.Testing)
            {
                if (MessageBox.Show("Вы действительно хотите завершить тестирование?",
                    "Завершение тестирования", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                EndTest();
                return;
            }
            if (this.Parent is Form)
                (this.Parent as Form).Close();
        }

        private void EndTest()
        {
            TestingHttpServer.AllowConnections = true;
            webBrowser.Navigate(TestingHttpServer.BaseUrl + "/endTest");
        }

        private void pbCalc_Click(object sender, EventArgs e)
        {
            CalculatorForm cf = new CalculatorForm();
            cf.ShowDialog();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            TestingHttpServer.AllowConnections = false;
        }

        private void btnNext_Enter(object sender, EventArgs e)
        {
            webBrowser.Focus();
        }
    }
}
