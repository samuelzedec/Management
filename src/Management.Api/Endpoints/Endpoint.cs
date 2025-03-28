using Management.Api.Common.Api;
using Managment.Domain.Abstractions.Base;

namespace Management.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints
            .MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => Results.Ok(Result<dynamic>
                .Success(new { Status = "Healthy", Time = DateTime.UtcNow }, "Health Check (OK)")));
        
    }

    private static IEndpointRouteBuilder MapEndpoint<TEnpoint>(this IEndpointRouteBuilder app)
        where TEnpoint : IEndpoint
    {
        TEnpoint.Map(app);
        return app;
    }
}