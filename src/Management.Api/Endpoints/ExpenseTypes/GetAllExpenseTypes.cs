using Management.Api.Common.Api;

namespace Management.Api.Endpoints.ExpenseTypes;

public class GetAllExpenseTypes : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("", () => "teste");
    
}