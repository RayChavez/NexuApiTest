using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ApiTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
