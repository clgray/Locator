using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Cnit.Testor.Core.HttpServer
{
    public static class TestingHttpServer
    {
        private static TestingProvider _testingProvider;
        private static Thread _servetThread;
        private static TcpListener _tcpListener;
        private static int _port;
        private static bool _isStarted;
        private static string _secureId;
        private static string _hid;
        private static ManualResetEvent _serverNotStarted;
        private static bool _allowConnections = true;

        public static event EventHandler AllowConnectionsChanged;

        public static int Port
        {
            get
            {
                return _port;
            }
        }

        public static bool AllowConnections
        {
            get
            {
                return _allowConnections;
            }
            set
            {
                if (_allowConnections != value)
                {
                    _allowConnections = value;
                    if (AllowConnectionsChanged != null)
                        AllowConnectionsChanged(null, new EventArgs());
                }
            }
        }

        public static TestingProvider TestingProvider
        {
            get
            {
                return _testingProvider;
            }
        }

        public static bool IsStarted
        {
            get
            {
                return _isStarted;
            }
        }

        public static string Hid
        {
            get
            {
                return _hid;
            }
            set
            {
                _hid = value;
            }
        }

        public static string SecureId
        {
            get
            {
                return _secureId;
            }
        }

        public static string BaseUrl
        {
            get
            {
                return String.Format("http://localhost:{0}/{1}", _port, _secureId);
            }
        }


        public static ManualResetEvent ServerNotStarted
        {
            get
            {
                return _serverNotStarted;
            }
        }

        public static string GetUrl(string subUrl)
        {
            return String.Format("{0}/{1}/", BaseUrl, subUrl);
        }

        public static void StartServer(TestingProvider provider)
        {
            _allowConnections = true;
            _serverNotStarted = new ManualResetEvent(true);
            _testingProvider = provider;
            _port = GetRandomPort();
            _secureId = Guid.NewGuid().ToString();
            _servetThread = new Thread(new ThreadStart(() =>
            {
                StartTcpListener();
                _isStarted = true;
                _serverNotStarted.Set();
                while (true)
                {
                    try
                    {
                        Socket clientSocket = _tcpListener.AcceptSocket();
                        if (clientSocket.Connected)
                        {
                            if (!_allowConnections)
                            {
                                clientSocket.Close();
                                clientSocket = null;
                                continue;
                            }
                            SystemStateManager.State = true;
                            ConnectionProcessor server = new ConnectionProcessor(clientSocket);
                            server.StartRead();
                        }
                    }
                    catch (SocketException)
                    { StopServer();}
                }
            }));
            _servetThread.Start();
        }

        public static void StopServer()
        {
            try
            {
                _testingProvider = null;
                _tcpListener.Stop();
                _servetThread.Abort();
                _isStarted = false;
                _servetThread.Join();
                _servetThread = null;
                _testingProvider = null;
                _tcpListener = null;
            }
            catch { }
            GC.Collect();
        }

        public static int GetRandomPort()
        {
            Random rnd = new Random((int)DateTime.Now.Millisecond + (int)DateTime.Now.Ticks * 2);
            return rnd.Next(15000, 40000);
        }

        private static void StartTcpListener()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Loopback, _port);
                _tcpListener.Start();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                _port = GetRandomPort();
                StartTcpListener();
            }
        }
    }
}
