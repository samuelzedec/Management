using Management.Domain.Abstractions.Interfaces;
using Management.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Management.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        return service;
    }
}