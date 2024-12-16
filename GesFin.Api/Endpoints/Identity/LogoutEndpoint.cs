using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GesFin.Api.Common.Api;
using GesFin.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace GesFin.Api.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app
            .MapPost("/logout", HandleAsync)
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}
}