using GesFin.Api;
using GesFin.Api.Common.Api;
using GesFin.Api.Data;
using GesFin.Api.Endpoints;
using GesFin.Core;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
    {
        // Endpoints diferentes para diferentes versões
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");

        // Define a rota customizada
        c.RoutePrefix = "documentacao";
    });


app.Run();


