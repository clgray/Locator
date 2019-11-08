using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Cnit.Testor.Core.HttpServer
{
    internal class HttpProcessor
    {
        private Dictionary<string, List<string>> _requestParams;
        private string[] _requestUriParts;
        private const string NOT_FOUND_404 = "404 Not Found";
        private const string OK_200 = "200 Ok";

        public static byte[] GetResponse(string request)
        {
            HttpProcessor httpProcessor = new HttpProcessor(request);
            return httpProcessor.GetResponse();
        }

        public byte[] GetResponse()
        {
            if (_requestUriParts.Length == 0)
                return null;
            if (_requestUriParts[0] != TestingHttpServer.SecureId)
                return null;
            Response response = null;
            try
            {
                response = TestingHttpServer.TestingProvider.ProcessReuqest(_requestUriParts,
                   _requestParams);
            }
            catch (TimeoutException)
            {
                response = null;
            }
            if (response == null)
                return Get404Response();
            return GetByteResponse(response.ResponseArr, response.ResponseType);
        }

        private HttpProcessor(string request)
        {
            _requestParams = new Dictionary<string, List<string>>();
            string[] requestLines = request.Split(new string[] { "\r\n", "\n" }, 
                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < requestLines.Length; i++)
            {
                string[] requestParamsParts = requestLines[i].Split(':');
                if (requestParamsParts.Length == 2)
                    AddRequestParam(requestParamsParts[0].Trim(), requestParamsParts[1].Trim());
            }
            string getString = null;
            if (requestLines.Length > 1)
                getString = requestLines[0];
            else
                getString = "GET / HTTP/1.1";
            string[] getStringParts = getString.ToLower().Split((char)32);
            string getValue = null;
            if (getStringParts.Length > 2)
                getValue = getStringParts[1];
            else
                getValue = "/";
            GetGetParams(getValue);
            _requestUriParts = getValue.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void AddRequestParam(string paramName, string value)
        {
            if (!_requestParams.ContainsKey(paramName))
                _requestParams.Add(paramName, new List<string>());
            _requestParams[paramName].Add(value);
        }

        public void GetGetParams(string getValue)
        {
            getValue = HttpUtility.UrlDecode(getValue);
            string[] get = getValue.Split('?');
            if (get.Length <= 1)
                return;
            string[] getParams = get[1].Split('&');
            foreach (var param in getParams)
            {
                string[] parts = param.Split('=');
                if (parts.Length > 1)
                    AddRequestParam(parts[0], parts[1]);
                else
                    AddRequestParam("REQUEST_ERROR", param);
            }
        }

        public byte[] Get404Response()
        {
            string responseContent = "<html><body><br/><br/><br/><center><h2>Ошибка подключения к серверу</h2>Попробуйте нажать кнопку &laquo;Пропустить&raquo; через несколько минут</center></body></html>";
            return GetHtmlResponse(responseContent, NOT_FOUND_404);
        }

        public byte[] GetHtmlResponse(string responseContent, string responseType)
        {
            byte[] responseContentArr = Encoding.UTF8.GetBytes(responseContent);
            return GetByteResponse(responseContentArr, "text/html");
        }

        public byte[] GetByteResponse(byte[] responseContent, string contentType)
        {
            if (responseContent == null)
                return Get404Response();
            byte[] retValue = null;
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] responseHeader = Encoding.ASCII.GetBytes(GetHeaders(OK_200, contentType,
                    responseContent.Length));
                ms.Write(responseHeader, 0, responseHeader.Length);
                if (responseContent != null)
                    ms.Write(responseContent, 0, responseContent.Length);
                retValue = ms.ToArray();
                ms.Close();
            }
            return retValue;
        }

        private string GetHeaders(string responseType, string contentType,
            int contentLength)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("HTTP/1.1 {0}\r\n", responseType);
            sb.Append("Cache-Control: no-cache\r\n");
            if (contentLength != 0)
                sb.AppendFormat("Content-Length: {0}\r\n", contentLength);
            sb.AppendFormat("Date: {0}\r\n", DateTime.Now.ToString());
            sb.Append("Server: TestorHTTPServer/2.1\r\n");
            if (!String.IsNullOrEmpty(contentType))
                sb.AppendFormat("Content-type: {0}", contentType);
            sb.Append(";charset=utf-8");
            sb.Append("\r\n\r\n");
            return sb.ToString();
        }
    }
}
