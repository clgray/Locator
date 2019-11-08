using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cnit.Testor.Core.Server
{
    [Serializable]
    public class TestorServiceBase
    {
        [NonSerialized]
        protected TestorSecurityProvider _provider;

        protected TestorSecurityProvider Provider
        {
            get
            {
                if (_provider == null)
                    _provider = new TestorSecurityProvider(HttpContext.Current);
                return _provider;
            }
        }

        protected ServerHelper Helper
        {
            get
            {
                return new ServerHelper();
            }
        }

        public void SetProvider(TestorSecurityProvider provider)
        {
            _provider = provider;
        }
    }
}
