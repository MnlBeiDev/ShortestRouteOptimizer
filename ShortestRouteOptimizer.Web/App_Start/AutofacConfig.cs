using System.Reflection;
using System.Web.Mvc;
using ShortestRouteOptimizer.Core;
using ShortestRouteOptimizer.Services;
using ShortestRouteOptimizer.Core.Interfaces;
using Autofac.Integration.Mvc;
using Autofac;

public static class AutofacConfig
{
    public static void RegisterDependencies()
    {
        var builder = new ContainerBuilder();

        // Register MVC controllers
        builder.RegisterControllers(Assembly.GetExecutingAssembly());

        // Register types
        builder.RegisterType<RouteCalculatorService>()
               .As<IRouteCalculatorService>()
               .InstancePerRequest(); // Or .SingleInstance(), depending on your need

        // You can also register GraphProvider or other services here if needed

        var container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
}
