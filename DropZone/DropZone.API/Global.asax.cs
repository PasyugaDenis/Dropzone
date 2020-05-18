using AutoMapper;
using DropZone.Core;
using Ninject;
using Ninject.Web.WebApi;
using System.Web;
using System.Web.Http;

namespace DropZone.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new AutoMappingProfile());
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
