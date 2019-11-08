using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;

namespace CoreWebClient
{
    public class UserSearchHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";
            if (string.IsNullOrEmpty(context.Request["q"]))
                return;

            foreach (var user in UserSearchHelper.FindTenLocalStudents(context.Request["q"]))
            {
                context.Response.Write(string.Format("{0} {1} {2}\n", user.LastName, user.FirstName, user.SecondName));
            }
        }
    }
}
