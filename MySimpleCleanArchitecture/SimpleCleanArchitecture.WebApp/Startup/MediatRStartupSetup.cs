using System.Reflection;
using MediatR;
using SimpleCleanArchitecture.Application.Base;
using SimpleCleanArchitecture.Domain.Order;
using SimpleCleanArchitecture.Infrastructure;

namespace SimpleCleanArchitecture.WebApp.Startup
{
    public static class MediatRStartupSetup
    {
     
        public static void AddMediatRServices(this IServiceCollection services)
        {
            List<Assembly> assemblies = new List<Assembly>();

            var domainAssembly = Assembly.GetAssembly(typeof(Order)); 
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
            var applicationAssembly = Assembly.GetAssembly(typeof(IReadRepositoryBase<>));
            var webAppAssembly = Assembly.GetAssembly(typeof(Services));
            if (domainAssembly != null)
            {
                assemblies.Add(domainAssembly);
            }

            if (infrastructureAssembly != null)
            {
                assemblies.Add(infrastructureAssembly);
            }  
            if (applicationAssembly != null)
            {
                assemblies.Add(applicationAssembly);
            }

            if (webAppAssembly != null)
            {
                assemblies.Add(webAppAssembly);
            }
           
            foreach (var assembly in assemblies)
            {
                 services.AddMediatR(assembly);
            }
        }
    }
}
