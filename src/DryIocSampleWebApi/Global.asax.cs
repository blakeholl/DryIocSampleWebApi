using System;
using System.Diagnostics;
using System.Web;
using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;
using DryIocSampleWebApi.Domain;

namespace DryIocSampleWebApi
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            IContainer container = new Container();

            container.Register<IProductRepository, FakeProductRepository>(Reuse.InWebRequest);

            container.RegisterDelegate<ILogger>(
                resolver => new Logger(s => Debug.WriteLine(s)),
                Reuse.Singleton);

            container.WithWebApi(GlobalConfiguration.Configuration);
        }
    }
}