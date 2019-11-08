using System;
using System.Web;
using Cnit.Testor.Core.HttpServer;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.Server.Services;
using System.Web.SessionState;
using System.IO;

namespace CoreWebClient
{
    public class ImageHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["id"] == null)
                return;
            WebServerProvider webServerProvider = new WebServerProvider(context);
            string id = context.Request["id"].ToLower();
            string imageId = Path.GetFileNameWithoutExtension(id);
            byte[] retValue = null;
            context.Response.ContentType = "image/png";
            if (imageId == "-1")
            {
                StartTestParams startParams = webServerProvider.TestClient.GetNotCommitedSessions(0, true);
                if (startParams == null)
                    return;
                var coreTest = startParams.TestSettings.CoreTests[0];
                if (coreTest.ShowTestResult)
                    retValue = HttpHandler.GetResultsImage(startParams.MaxScore, startParams.CurrentScore, coreTest.PassingScore);
                else
                    return;
            }
            else
                retValue = webServerProvider.TestClient.GetImage(imageId);
            context.Response.OutputStream.Write(retValue, 0, retValue.Length);
        }
    }
}
