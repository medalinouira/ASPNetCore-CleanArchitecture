/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using ASPNetCore.CleanArchitecture.Interfaces;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNetCore.CleanArchitecture.Setup
{
    public static class DependenciesInjector
    {
        #region Methods
        public static void AddIInjectableDependencies(this IServiceCollection services, Type ObjectType)
        {
            var types = (from t in ObjectType.Assembly.GetTypes()
                         where t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && t.GetTypeInfo().ImplementedInterfaces.Any(i => i == typeof(IInjectable))
                         select (t)).OrderBy(p => p.Name).ToList();

            foreach (var type in types)
            {
                int max = 0;
                Type interfaceType = null;
                foreach (var it in type.GetInterfaces())
                {
                    int nombreInterfaceImplIService = it.GetInterfaces().Length;
                    if (it.GetInterfaces().Any(i => i == typeof(IInjectable)) && max < nombreInterfaceImplIService)
                    {
                        max = nombreInterfaceImplIService;
                        interfaceType = it;
                    }
                }
                services.AddTransient(interfaceType, type);
            }
        }
        #endregion
    }
}
