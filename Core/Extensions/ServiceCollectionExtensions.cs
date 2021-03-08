using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //extension metodu yapabilmek için sınıf static olmalı!!!

        //IServiceCollection AspNet uygulamamızın(API) servis bağımlılıklarını ya da 
        //girmesini istediğimiz servisleri eklediğimiz koleksiyomdur!!
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection,ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
