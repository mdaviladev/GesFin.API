using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesFin.Core.Requests
{
    public abstract class PagedRequest: Request
    {
        public int PageNumber { get; set; }  = Configurations.DefaultPageNumber;
        public int PageSize { get; set; }    = Configurations.DefaultPageSize;   
    }
}