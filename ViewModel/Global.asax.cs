using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace ViewModel
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Para poder usar ASP Requerid field validator
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "https://code.jquery.com/jquery-3.6.0.min.js",
                DebugPath = "https://code.jquery.com/jquery-3.6.0.js",
                CdnSupportsSecureConnection = true
            });
        }
    }
}