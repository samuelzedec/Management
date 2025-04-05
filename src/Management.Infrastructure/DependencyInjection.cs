using Managment.Domain.Abstractions.Interfaces;
using Managment.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Managment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        return service;
    }
}