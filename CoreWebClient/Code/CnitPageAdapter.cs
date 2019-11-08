using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.Adapters;
using System.Web.UI;

namespace CoreWebClient
{
    public class CnitPageAdapter : PageAdapter
    {
        public override PageStatePersister GetStatePersister()
        {
            return new SessionPageStatePersister(Page);
        }
    }
}
