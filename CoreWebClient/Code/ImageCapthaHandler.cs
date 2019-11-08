using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Drawing.Imaging;
using System.IO;

namespace CoreWebClient
{
    public class ImageCapthaHandler: IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            CaptchaImage ci = new CaptchaImage(context.Session["CaptchaImageText"].ToString(), 200, 50, "Century Schoolbook");
            context.Response.ContentType = "image/png";
            using (MemoryStream ms = new MemoryStream())
            {
                ci.Image.Save(ms, ImageFormat.Png);
                byte[] image = ms.ToArray();
                context.Response.OutputStream.Write(image, 0, image.Length);
                ci.Dispose();
            }
        }
    }
}
