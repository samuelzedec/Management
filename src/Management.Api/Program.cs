using Management.Api.Common.Api;
using Management.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddDataContext();

var app = builder.Build();
app.MapEndpoints();
app.Run();
