using Microsoft.Extensions.DependencyInjection;
using TechChallangeFase01.Application.Interfaces;
using TechChallangeFase01.Application.Services;
using TechChallangeFase01.Infra.Data.Interfaces;
using TechChallangeFase01.Infra.Data.Repository;

namespace TechChallangeFase01.Infra.IoC.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        #region Application Layer

        services.AddScoped<IContatosService, ContatosService>();
        #endregion

        #region Domain Layer

        #endregion

        #region InfraStructure Layer
        services.AddScoped<IContatosRepository,ContatosRepository>();

        #endregion

        return services;
    }
}