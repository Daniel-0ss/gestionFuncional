using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using AutoMapper;
using PersonasService.Application.Interfaces;
using PersonasService.Application.Services;
using PersonasService.Domain.Interfaces;
using PersonasService.Infrastructure.Data;
using PersonasService.Infrastructure.Repositories;
using PersonasService.Mappings;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // Register context
        container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());

        // Application Layer
        container.RegisterType<IPersonaService, PersonaService>();

        // Infrastructure Layer
        container.RegisterType<IPersonaRepository, PersonaRepository>();

        // AutoMapper
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });

        container.RegisterInstance<IMapper>(config.CreateMapper());

        GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
}
