using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesFin.Api.Common.Api
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}