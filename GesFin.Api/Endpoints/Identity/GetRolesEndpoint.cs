using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GesFin.Api.Common.Api;
using GesFin.Core.Models.Account;

namespace GesFin.Api.Endpoints.Identity
{
    public class GetRolesEndpoint: IEndpoint 
    {
         public static void Map(IEndpointRouteBuilder app)
        => app
            .MapGet("/roles", Handle)
            .RequireAuthorization();

    private static Task<IResult> Handle(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Task.FromResult(Results.Unauthorized());

        var identity = (ClaimsIdentity)user.Identity;
        var roles = identity
            .FindAll(identity.RoleClaimType)
            .Select(c => new RoleClaim
            {
                Issuer = c.Issuer,
                OriginalIssuer = c.OriginalIssuer,
                Type = c.Type,
                Value = c.Value,
                ValueType = c.ValueType
            });

        return Task.FromResult<IResult>(TypedResults.Json(roles));
    }
    }
}