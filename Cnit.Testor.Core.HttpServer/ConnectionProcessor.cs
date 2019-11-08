using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace Cnit.Testor.Core.HttpServer
{
    internal sealed class ConnectionProcessor
    {
        private byte[] _buffer;
        private Socket _socket;
        private NetworkStream _netStream;
        private AsyncCallback _cbRead;
        private AsyncCallback _cbWrite;

        public ConnectionProcessor(Socket socket)
        {
            _socket = socket;
            _buffer = new byte[15560];
            _netStream = new NetworkStream(_socket);
            _cbRead = new AsyncCallback(OnReadComplete);
            _cbWrite = new AsyncCallback(OnWriteComplete);
        }

        public void StartRead()
        {
            try
            {
                _netStream.BeginRead(_buffer, 0, _buffer.Length, _cbRead, null);
            }
            catch (IOException)
            {
                CloseSocket();
            }
        }

        private void OnReadComplete(IAsyncResult ar)
        {
            int bytesRead = 0;
            try
            {
                bytesRead = _netStream.EndRead(ar);
            }
            catch (IOException)
            {
                CloseSocket();
                return;
            }
            if (bytesRead > 0)
            {
                string request = Encoding.ASCII.GetString(_buffer,
                     0, bytesRead);
                byte[] response = HttpProcessor.GetResponse(request);
                try
                {
                    _netStream.BeginWrite(response, 0, response.Length, _cbWrite, null);
                }
                catch
                {
                    CloseSocket();
                }
            }
            else
            {
                CloseSocket();
            }
            SystemStateManager.State = false;
        }

        public void CloseSocket()
        {
            _netStream.Close();
            _socket.Close();
            _netStream = null;
            _socket = null;
        }

        private void OnWriteComplete(IAsyncResult ar)
        {
            _netStream.EndWrite(ar);
            CloseSocket();
        }
    }
}
