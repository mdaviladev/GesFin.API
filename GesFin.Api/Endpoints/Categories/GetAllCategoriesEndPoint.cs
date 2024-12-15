using System.Security.Claims;
using GesFin.Api.Common.Api;
using GesFin.Core;
using GesFin.Core.Handles;
using GesFin.Core.Models;
using GesFin.Core.Requests.Categories;
using GesFin.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GesFin.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Recupera todas as categorias")
            .WithDescription("Recupera todas as categorias")
            .WithOrder(5)
            .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        [FromQuery] int pageNumber = Configurations.DefaultPageNumber,
        [FromQuery] int pageSize = Configurations.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}