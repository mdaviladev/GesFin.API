using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure;
using GesFin.Api.Common.Api;
using GesFin.Core.Handles;
using GesFin.Core.Models;
using GesFin.Core.Requests.Categories;

namespace GesFin.Api.Endpoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) 
                    => app.MapPut("/{id}", HandleAsync)
                    .WithName("Category: Update")
                    .WithSummary("Atualiza uma categoria")
                    .WithDescription("Atualiza uma categoria")
                    .WithOrder(2)
                    .Produces<Response<Category>>();
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICategoryHandler handler,
            UpdateCategoryRequest request,
            int id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;
            var result = await handler.UpdateAsync(request);
            return result.IsSuccess 
                    ? TypedResults.Ok(result) 
                    : TypedResults.BadRequest(result);
        }
    }
}