using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Working_With_Domain_Events
{
   public static class ServiceCollectionExtension
    {
        public static void AddServiceCollectionTypes(this IServiceCollection serviceCollection, params Assembly[] assemblies)
        {
            serviceCollection.AddTransient<IDispatcher, Dispatcher>();

            serviceCollection.Scan(scan =>
            {
                if (assemblies?.Length > 0)
                {
                    scan.FromAssemblies(assemblies).AddTypes();
                }
                else
                {
                    scan.FromEntryAssembly().AddTypes();
                }
            });
        }
        private static void AddTypes(this IImplementationTypeSelector selector)
        {
            selector
                .AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime();
        }
    }
}
