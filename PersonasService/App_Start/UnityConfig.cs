using System;
using System.Web.Http;
using AutoMapper;
using MediatR;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

using PersonasService.Application.Commands;
using PersonasService.Application.Queries;
using PersonasService.Application.Interfaces;
using PersonasService.Application.Services;
using PersonasService.Infrastructure.Repositories;
using PersonasService.Mappings;
using PersonasService.Models;
using System.Collections.Generic;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // DbContext
        container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());

        // Application & Domain services
        container.RegisterType<IPersonaService, PersonaService>();
        container.RegisterType<IPersonaRepository, PersonaRepository>();
  
        // AutoMapper
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        container.RegisterInstance<IMapper>(config.CreateMapper());

        // ✅ MEDIATR CONFIGURACIÓN CORRECTA
        container.RegisterInstance<ServiceFactory>(t => ServiceResolver(container, t));
        container.RegisterType<IMediator, Mediator>(new HierarchicalLifetimeManager());

        // Handlers
        container.RegisterType<IRequestHandler<GetAllPersonasQuery, IEnumerable<PersonaDto>>, GetAllPersonasHandler>();
        container.RegisterType<IRequestHandler<CreatePersonaCommand, PersonaDto>, CreatePersonaHandler>();
        container.RegisterType<IRequestHandler<UpdatePersonaCommand, PersonaDto>, UpdatePersonaHandler>();
        container.RegisterType<IRequestHandler<GetPersonaByIdQuery, PersonaDto>, GetPersonaByIdHandler>();
        container.RegisterType<IRequestHandler<DeletePersonaCommand, bool>, DeletePersonaHandler>();

        // Resolver para Web API
        GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }

    // Método auxiliar para resolver tipos
    private static object ServiceResolver(IUnityContainer container, Type type)
    {
        return container.Resolve(type);
    }
}
