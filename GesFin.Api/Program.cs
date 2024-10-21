using GesFin.Api.Data;
using GesFin.Core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var ConnDbStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDBContext>(x => { x.UseSqlServer(ConnDbStr); } );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddTransient<Handler>();

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
           (Request request, Handler handler) 
           =>  handler.Handle(request))
.WithName("Categories: Create ")
.WithSummary("Cria uma nova category")
.Produces<Response>();

app.Run();

// public class Request
// {
//     public string Title { get; set; }  = string.Empty;
//     public DateTime CreatedAt   { get; set; } = DateTime.Now;
//     public int Type { get; set; }
//     public decimal Amount { get; set; } 
//     public long CategoryId { get; set; }    
//     public string UserId { get; set; } = string.Empty;

// }

public class Request
{
    public string Title { get; set; }  = string.Empty;
    public string Description { get; set;} = string.Empty;  

}

public class Response
{
    public long Id { get; set; }
    public string Title { get; set;} = string.Empty;
}

public class Handler(AppDBContext context ) {
    public Response Handle (Request request)   {
        var category = new Category 
        { 
            Title = request.Title,
            Description = request.Description
         };

        context.Categories.Add(category);
        context.SaveChanges();
 
        return new Response {
            Id = category.Id,
            Title = category.Title
        };
    }
}