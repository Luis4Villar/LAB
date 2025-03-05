using Personas.Application.Interfaces;
using Personas.Application.Services;
using Personas.Domain.Interfaces;
using Personas.infrastructure.Repository;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Personas
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
            container.Register<PersonaContext>(Lifestyle.Scoped);
            container.Register<IPersonaService, PersonaService>(Lifestyle.Scoped);
            container.Register<IPersonaRepository, PersonaRepository>(Lifestyle.Scoped);

        }
    }
}
