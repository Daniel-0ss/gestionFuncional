using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using MediatR;
using RecetasService.Models;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // ⛓️ Infraestructura
        container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());
        container.RegisterType<IRecetaRepository, RecetaRepository>();


        // 🔧 Servicios
        container.RegisterType<IRecetaService, RecetaServices>();

        // 🧠 AutoMapper
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        container.RegisterInstance<IMapper>(config.CreateMapper());

        // 💬 MediatR
        container.RegisterInstance<ServiceFactory>(t => ServiceResolver(container, t));
        container.RegisterType<IMediator, Mediator>(new HierarchicalLifetimeManager());

        // ✅ Queries Handlers
        container.RegisterType<IRequestHandler<GetAllRecetasQuery, IEnumerable<RecetaDto>>, GetAllRecetasHandler>();
        container.RegisterType<IRequestHandler<GetRecetaByCodigoQuery, RecetaDto>, GetRecetaByCodigoHandler>();
        container.RegisterType<IRequestHandler<GetRecetasByPacienteIdQuery, IEnumerable<RecetaDto>>, GetRecetasByPacienteIdHandler>();


        // ✅ Commands Handlers
        container.RegisterType<IRequestHandler<CreateRecetaCommand, RecetaDto>, CreateRecetaHandler>();
        container.RegisterType<IRequestHandler<UpdateRecetaCommand, RecetaDto>, UpdateRecetaHandler>();
        container.RegisterType<IRequestHandler<DeleteRecetaCommand, bool>, DeleteRecetaHandler>();

        // 📦 Web API Dependency Resolver
        GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }

    private static object ServiceResolver(IUnityContainer container, Type type)
    {
        return container.Resolve(type);
    }
}
