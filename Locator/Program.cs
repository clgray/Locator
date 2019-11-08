using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Cnit.Testor.Core.UI;
using System.Configuration;
using Cnit.Testor.Core;
using Cnit.Testor.Core.Server;
using System.ServiceProcess;
using System.Reflection;
using System.Threading;

namespace Locator
{
    static class Program
    {
        public static int Port
        {
            get
            {
                int retValue = 30488;
                int.TryParse(ConfigurationManager.AppSettings["port"], out retValue);
                return retValue;
            }
        }

        public static string DnsIdentity
        {
            get
            {
                return ConfigurationManager.AppSettings["dnsIdentity"];
            }
        }

        public static bool IsHttp
        {
            get
            {
                bool retValue = false;
                bool.TryParse(ConfigurationManager.AppSettings["isHttp"], out retValue);
                return retValue;
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            string runningMode = null;
            if (args.Length > 0)
            {
                string fileName = args[0];
                string arg = fileName.ToLower();
                if (arg == "-mode" || arg == "/mode")
                {
                    if (args.Length > 1)
                        runningMode = args[1].ToLower();
                }
                else
                {
                    FileInfo fi = new FileInfo(fileName);
                    if (fi.Exists && fi.Extension.ToLower() == ".ctfx")
                        LoginHelper.NeedOpen = fi;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (String.IsNullOrEmpty(runningMode))
                runningMode = ConfigurationManager.AppSettings["mode"].ToLower();
            if (runningMode == "edithor")
                Application.Run(new EditMainForm());
            else if (runningMode == "client")
                Application.Run(new TestingMainForm());
            else if (runningMode == "service")
            {
                NativeMethods.AllocConsole();
                bool isService = false;
                bool.TryParse(ConfigurationManager.AppSettings["isService"], out isService);
                if (!isService)
                {
                    ServerHostProvider.StartServer(Program.Port, Program.DnsIdentity, Program.IsHttp);
                    Console.WriteLine(String.Format("[{0}]: Starting server.", DateTime.Now));
                    Console.WriteLine(String.Format("DnsIdentity: {0}; Port: {1}; IsHttp: {2};",
                        Program.DnsIdentity, Program.Port, Program.IsHttp));
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
                else
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] { new TestingService() };
                    ServiceBase.Run(ServicesToRun);
                }
            }
            else
                SystemMessage.ShowErrorMessage("Режим запуска не определён");
        }

		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ex)
		{
			Form fm = new Form();
			fm.Text = "Ошибка";
			fm.StartPosition = FormStartPosition.CenterScreen;
			fm.Width = 640;
			fm.Height = 480;
			fm.FormBorderStyle = FormBorderStyle.Fixed3D;
			fm.MaximizeBox = false;
			fm.MinimizeBox = false;
			TextBox tb = new TextBox();
			tb.ReadOnly = true;
			tb.Multiline = true;
			tb.Text = ex.ExceptionObject.GetType() + System.Environment.NewLine +
			  (ex.ExceptionObject as Exception).Message + System.Environment.NewLine +
			  (ex.ExceptionObject as Exception).StackTrace;
			tb.Dock = DockStyle.Fill;
			fm.Controls.Add(tb);
			fm.ShowDialog();
		}

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string asmName=args.Name.ToLower();
            bool isUi=asmName.StartsWith("cnit.testor.core.ui");
            if (asmName.StartsWith("cnit"))
            {
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    AssemblyName assemblyName = assembly.GetName();
                    if (assemblyName.Name == "Cnit.Testor.Core.UI" && isUi)
                    {
                        return (assembly);
                    }
                    if (assemblyName.Name == "Cnit.Testor.Core" && !isUi)
                    {
                        return (assembly);
                    }
                }
            }
            return null;
        }
    }
}
