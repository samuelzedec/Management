using Managment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Management.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Management.Api"));

                options.ConfigureWarnings(w =>
                {
                    w.Ignore(RelationalEventId.PendingModelChangesWarning); // Fará com que os ID`s da seeders possam ser dinâmicos
                    w.Ignore(CoreEventId.DetachedLazyLoadingWarning);// Fará com que as datas da seeders possam ser dinâmicas
                });
            });
    }
}