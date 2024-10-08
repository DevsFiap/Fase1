﻿using Microsoft.Extensions.DependencyInjection;
using TechChallangeFase01.Application.Mappings;

namespace TechChallangeFase01.Infra.IoC.Extensions;

public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoToEntityMap));
        return services;
    }
}