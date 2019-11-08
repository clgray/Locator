using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Cnit.Testor.Core.Server;

namespace Locator
{
    partial class TestingService : ServiceBase
    {
        public TestingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServerHostProvider.StartServer(Program.Port, Program.DnsIdentity, Program.IsHttp);
        }

        protected override void OnStop()
        {
            ServerHostProvider.StopServer();
        }
    }
}
