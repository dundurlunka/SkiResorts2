namespace SkiResorts.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using SkiResorts.Services;
    using System.Linq;
    using System.Reflection;

    public static class ServiceCollcetionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Inteface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Inteface, s.Implementation));

            return services;
        }
    }
}
