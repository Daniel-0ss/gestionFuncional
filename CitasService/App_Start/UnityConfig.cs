using System;
using System.Web.Http;
using AutoMapper;
using MediatR;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

using CitasService.Application.Commands;
using CitasService.Application.Queries;
using CitasService.Application.Interfaces;
using CitasService.Application.Services;
using CitasService.Infrastructure.Data;
using CitasService.Infrastructure.Repositories;
using CitasService.Mappings;
using CitasService.Models;
using System.Collections.Generic;


public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // DbContext
        container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());

        // Application & Domain services
        container.RegisterType<ICitaService, CitaService>();
        container.RegisterType<ICitaRepository, CitaRepository>();

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
        container.RegisterType<IRequestHandler<GetAllCitasQuery, IEnumerable<CitaDto>>, GetAllCitasHandler>();
        container.RegisterType<IRequestHandler<CreateCitaCommand, CitaDto>, CreateCitaHandler>();
        container.RegisterType<IRequestHandler<UpdateCitaCommand, CitaDto>, UpdateCitaHandler>();
        container.RegisterType<IRequestHandler<GetCitaByIdQuery, CitaDto>, GetCitaByIdHandler>();
        container.RegisterType<IRequestHandler<DeleteCitaCommand, bool>, DeleteCitaHandler>();

        // Resolver para Web API
        GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
    // Método auxiliar para resolver tipos
    private static object ServiceResolver(IUnityContainer container, Type type)
    {
        return container.Resolve(type);
    }
}
