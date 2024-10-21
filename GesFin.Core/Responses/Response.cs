using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GesFin.Core.Responses
{
    public class Response<T> 
    {
       private readonly int _code;
 
        [JsonConstructor]
        public Response()
        {
            _code = Configurations.DefaultStatusCode;
        }

        public Response(T? data, int code = 200, string? message = null)
        {
            Data = data;
            Message = message;
            _code = Configurations.DefaultStatusCode;
        }

        public T? Data { get; set; }
        public string? Message { get; set;} 

        [JsonIgnore]
        public bool IsSuccess => _code >= 200 && _code <= 299;
    }
}