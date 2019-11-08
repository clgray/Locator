using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.HttpServer
{
    public class Response
    {
        public string ResponseType { get; set; }

        public byte[] ResponseArr { get; set; }

        public string ResponseValue
        {
            set
            {
                if (value == null)
                    ResponseArr = null;
                else
                    ResponseArr = Encoding.UTF8.GetBytes(value);
            }
        }
        
        public Response()
        {}
    }
}
