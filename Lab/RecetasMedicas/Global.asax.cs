using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RecetasMedicas.Infrastructure.Repository;
using RecetasMedicas.Application.Services;
using RecetasMedicas.Domain.Interfaces;
using RecetasMedicas.Infrastructure.Messaging;
using System.Threading.Tasks;
using Microsoft.Win32;
using CitasMedicas.Application.Services;
using CitasMedicas.Infrastructure.Messaging;
using CitasMedicas.Domain.Interfaces;
using CitasMedicas.Infrastructure.Repository;
using System.Net.Http;
using RabbitMQ.Client;

namespace RecetasMedicas
{
    public class WebApiApplication : System.Web.HttpApplication
    {
         protected void Application_Start()
            {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //registro de dependencias
            RegisterDependencies(container);
            //registro de controladores
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //Verifica la configuracion
            container.Verify();
            // COnfigurar web api
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterDependencies(Container container)
        {
            // Registra la fábrica de conexiones primero
            container.Register<IConnectionFactory>(() => new ConnectionFactory
            {
                HostName = "localhost", // Ajusta esto según tu configuración
                UserName = "guest",
                Password = "guest"
            }, Lifestyle.Singleton);

            // Registra RabbitMQProduce con la fábrica de conexiones
            container.Register(() =>
                new RabbitMQProduce(container.GetInstance<IConnectionFactory>()),
                Lifestyle.Scoped);

            // Resto de los registros
            container.Register<IFormulaMedicaServices, FormulaMedicaServices>(Lifestyle.Scoped);
            container.Register<IFormulaMedicaRepository, FormulaMedicaRepository>(Lifestyle.Scoped);
            container.Register<FormulaMedicaContext>(Lifestyle.Scoped);

            container.Register<ICitaMedicaServices, CitaMedicaServices>(Lifestyle.Singleton);
            container.Register<ICitaMedicaRepository, CitaMedicaRepository>(Lifestyle.Singleton);
            container.Register<CitaMedicaContext>(Lifestyle.Scoped);

            container.Register(() => new PersonaClient(new HttpClient()), Lifestyle.Singleton);
        }

    }


}

