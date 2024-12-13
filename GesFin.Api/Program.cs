using GesFin.Api;
using GesFin.Api.Common.Api;
using GesFin.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
//app.UseCors("CorsPolicy");
app.UseSecurity();
app.MapEndpoints();

app.Run();


