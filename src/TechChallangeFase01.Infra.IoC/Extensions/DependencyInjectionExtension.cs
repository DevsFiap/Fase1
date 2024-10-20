using Microsoft.Extensions.DependencyInjection;
using TechChallangeFase01.Application.Interfaces;
using TechChallangeFase01.Application.Services;
using TechChallangeFase01.Domain.Interfaces.Repositories;
using TechChallangeFase01.Domain.Interfaces.Services;
using TechChallangeFase01.Domain.Services;
using TechChallangeFase01.Infra.Data.Repository;

namespace TechChallangeFase01.Infra.IoC.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        //Application Layer
        services.AddScoped<IContatosAppService, ContatosAppService>();

        //Domain Layer
        services.AddScoped<IContatoDomainService, ContatoDomainService>();

        //Infrastructure Layer
        services.AddScoped<IContatosRepository, ContatoRepository>();

        return services;
    }
}