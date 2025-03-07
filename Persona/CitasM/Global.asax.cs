using AutoMapper;
using MediatR;
using Personas.Application.Interfaces;
using Personas.Application.Mapper;
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
            container.Register<IPersonaRepository, PersonaRepository>(Lifestyle.Scoped);
            container.Register<IPersonaService, PersonaService>(Lifestyle.Scoped);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonaMapping>(); // Agrega tu perfil de mapeo
            });
            container.RegisterInstance(config);
            container.RegisterInstance<IMapper>(config.CreateMapper());
            //Meditor
            // Registrar ServiceFactory como Singleton
            container.RegisterSingleton<ServiceFactory>(() => type => container.GetInstance(type));

            // Registrar IMediator correctamente
            container.RegisterSingleton<IMediator>(() =>
                new Mediator(container.GetInstance<ServiceFactory>()));
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var requestHandlers = assemblies.SelectMany(a => a.GetTypes())
                                    .Where(t => !t.IsAbstract && !t.IsInterface) // Solo clases concretas
                                    .Where(t => t.GetInterfaces()
                                                 .Any(i => i.IsGenericType &&
                                                           i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

            foreach (var handler in requestHandlers)
            {
                var handlerInterface = handler.GetInterfaces()
                                              .First(i => i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                container.Register(handlerInterface, handler, Lifestyle.Transient);
            }
            // 📌 REGISTRAR LOS NOTIFICATION HANDLERS
            container.Collection.Register(typeof(INotificationHandler<>), assemblies);

            // 🚀 REGISTRAR PIPELINE BEHAVIORS
            container.Collection.Register(typeof(IPipelineBehavior<,>), assemblies);


        }
    }
}
