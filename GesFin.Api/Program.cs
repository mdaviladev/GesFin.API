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

// app.UseSwagger();

// app.UseSwaggerUI(c =>
//     {
//         // Endpoints diferentes para diferentes versões
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");

//         // Define a rota customizada
//         c.RoutePrefix = "documentacao";
//     });

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();
app.MapEndpoints();

app.Run();


