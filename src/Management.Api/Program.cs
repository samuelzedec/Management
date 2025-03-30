using Management.Api.Common.Api;
using Management.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddDataContext();
builder.AddLogs();
builder.AddSecurity();
builder.AddServices();
builder.AddDevelopmentMode();

var app = builder.Build();
app.UsePipeline();
app.Run();
