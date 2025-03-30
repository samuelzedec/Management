using System.Text;
using Managment.Infrastructure;
using Managment.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;

namespace Management.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddPipeline(this WebApplicationBuilder builder)
    {
        builder.AddDataContext();
        builder.AddLogs();
        builder.AddSecurity();
        builder.AddServices();
        builder.AddDevelopmentEnvironment();
    }
    private static void AddLogs(this WebApplicationBuilder builder)
    {
        var output = "{Timestamp:dd-MM-yyyy HH:mm:ss} [{Level}] {Message} {Properties:j}{NewLine}{Exception}";
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information() 
            .WriteTo.Console(outputTemplate: output)
            .WriteTo.File("Logs/logger.txt", restrictedToMinimumLevel: LogEventLevel.Warning, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        builder.Logging.AddSerilog();
    }
    
    private static void AddDataContext(this WebApplicationBuilder builder)
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

    private static void AddSecurity(this WebApplicationBuilder builder)
    {
        /* ========================================================================================================================================
         * Cria um logger usando o LoggerFactory, configurando o Serilog como o provedor de logs
         * O "AddSerilog" adiciona o Serilog à cadeia de provedores de logging, permitindo que logs sejam gravados através dele.
         * "CreateLogger" cria o logger com o nome "Authentication" para ser utilizado para registrar logs específicos relacionados à autenticação.
         * ======================================================================================================================================== */
        var logger = LoggerFactory.Create(loggingBuilder => loggingBuilder.AddSerilog()).CreateLogger("Authentication");
        var key = Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:Token")!);
        
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
                ValidateAudience = true,
                ValidAudience = builder.Configuration.GetValue<string>("Jwt:Audience")
            };

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    logger.LogError(context.Exception.Message);
                    return Task.CompletedTask;
                }
            };
        });
        builder.Services.AddAuthorization();
    }

    private static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure();

        builder.Services
            .AddIdentityCore<IdentityUser<Guid>>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        
        /* ========================================================================================================================================
         * AddDefaultTokenProviders: Adiciona os provedores de token padrão do Identity
         *
         * - Permite a geração de tokens para funcionalidades específicas como:
         *   - Redefinição de senha
         *   - Confirmação de email
         *   - Autenticação de dois fatores (2FA)
         *   - Alteração de email
         *   - Autenticação de telefone
         *
         * - Esses tokens são diferentes dos JWT usados para autenticação principal
         * - São necessários mesmo usando JWT, pois servem para fluxos específicos de gerenciamento de usuário
         * - Implementam algoritmos seguros para geração e validação de tokens temporários
         * ======================================================================================================================================== */

    }

    private static void AddDevelopmentEnvironment(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}