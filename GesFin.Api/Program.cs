using GesFin.Api.Data;
using GesFin.Api.Handlers;
using GesFin.Core.Handles;
using GesFin.Core.Models;
using GesFin.Core.Requests.Categories;
using GesFin.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var ConnDbStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDBContext>(x => { x.UseSqlServer(ConnDbStr); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
    {
        // Endpoints diferentes para diferentes versões
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");

        // Define a rota customizada
        c.RoutePrefix = "documentacao";
    });

app.MapPost("/v1/categories",
           async (CreateCategoryRequest request, ICategoryHandler handler)
           => await handler.CreateAsync(request))
           .WithName("Categorias: Criar ")
           .WithSummary("Cria uma nova Categoria")
           .Produces<Response<Category?>>();

app.MapPut("/v1/categories/{id}",
           async (int id, UpdateCategoryRequest request, ICategoryHandler handler)
           =>
           {
               request.Id = id;
               return await handler.UpdateAsync(request);
           })
           .WithName("Categorias: Alterar ")
           .WithSummary("Alterar a Categoria")
           .Produces<Response<Category?>>();

app.MapDelete("/v1/categories/{id}",
           async (int id, ICategoryHandler handler)
           =>
           {
               var request = new DeleteCategoryRequest { Id = id };
               return await handler.DeleteAsync(request);
           })
           .WithName("Categorias: Excluir ")
           .WithSummary("Excluir a Categoria")
           .Produces<Response<Category?>>();

app.MapGet("/v1/categories/{id}",
           async (int id, ICategoryHandler handler)
           =>
           {
               var request = new GetCategoryByIdRequest { Id = id };
               return await handler.GetByIdAsync(request);
           })
           .WithName("Categorias: Obter ")
           .WithSummary("Recuperar uma categoria.")
           .Produces<Response<Category?>>();


app.Run();

public class Request
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

