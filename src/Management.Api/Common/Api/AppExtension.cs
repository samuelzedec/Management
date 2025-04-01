using Management.Api.Endpoints;

namespace Management.Api.Common.Api;

public static class AppExtension
{
    public static void UsePipeline(this WebApplication app)
    {
        app.UseDevelopmentEnvironment();
        app.UseSecurity();
        app.MapEndpoints();
    }
    
    private static void UseDevelopmentEnvironment(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapSwagger().RequireAuthorization();
    }

    private static void UseSecurity(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}