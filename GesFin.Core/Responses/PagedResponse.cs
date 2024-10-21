using System.Text.Json.Serialization;

namespace GesFin.Core.Responses
{
    public class PagedResponse<T> : Response<T>
    {
        [JsonConstructor]
        public PagedResponse(T? data, 
                            int totalCount, 
                            int currentPage = 1, 
                            int pageSize = Configurations.DefaultPageSize) : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public PagedResponse(T? data, 
                            int code = Configurations.DefaultStatusCode, 
                            string? message = null) : base(data, code, message) {

                            }
            
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / (double)PageSize);
        public int PageSize { get; set; } = Configurations.DefaultPageSize;
        public int TotalCount { get; set; }

    }
}