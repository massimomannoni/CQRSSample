using Microsoft.Extensions.DependencyInjection;
using Simple.Infrastructure.Database;
using System;
using CommonServiceLocator;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Core;
using Simple.Infrastructure.Processing;

namespace Simple.Infrastructure
{
    public class ApplicationStartup
    {
        public static IServiceProvider Initialize(IServiceCollection services, string connectionString)
        {
            return RegisterAutofacServiceProvider(services, connectionString);
        }

        private static IServiceProvider RegisterAutofacServiceProvider(IServiceCollection services, string connectionString)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new MediatorModule());

            var containerBuilded = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(containerBuilded));

            var autofacServiceProvider = new AutofacServiceProvider(containerBuilded);

            CompositionRoot.SetContainer(containerBuilded);

            return autofacServiceProvider;
        }
    }

}
