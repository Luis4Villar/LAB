using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Citas.Application.Intefaces;
using Citas.Application.Services;
using Citas.Domain.Interfaces;
using Citas.Infraestructura.Repository;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using Citas.Infraestructura.Controller;


namespace Citas
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //Registro de dependencias
            RegisterDepencies(container);

            //Registro controladores
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //Verificar la configuracion
            container.Verify();

            //Configurar Web Api
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
        private void RegisterDepencies(Container container)
        {
            container.Register<CitasContext>(Lifestyle.Scoped);
            container.Register<ICitasService, CitasService>(Lifestyle.Scoped);
            container.Register<ICitasRepository, CitasRepository>(Lifestyle.Scoped);
           
        }

    }
}
