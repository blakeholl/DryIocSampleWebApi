using System;
using System.Diagnostics;
using System.Web;
using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;
using DryIocSampleWebApi.Controllers;
using DryIocSampleWebApi.Domain;

using Reuse = DryIoc.Reuse;
using WebReuse = DryIoc.WebApi.Reuse;

namespace DryIocSampleWebApi
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            IContainer container = new Container();

            container.Register<IProductRepository, FakeProductRepository>(WebReuse.InRequest);

            container.RegisterDelegate<ILogger>(
                resolver => new Logger(s => Debug.WriteLine(s)),
                Reuse.Singleton);

            container.Register<ProductsController>(WebReuse.InRequest);

            container.WithWebApi(GlobalConfiguration.Configuration);
        }
    }
}