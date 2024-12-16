using GesFin.Core.Requests.Account;
using GesFin.Core.Responses;

namespace GesFin.Core.Handles
{
    public interface IAccountHandler
    {
        Task<Response<string>> LoginAsync(LoginRequest request);
        Task<Response<string>> RegisterAsync(RegisterRequest request);
        Task LogoutAsync();
    }
}