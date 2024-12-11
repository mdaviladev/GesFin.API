using Microsoft.AspNetCore.Identity;

namespace GesFin.Api.Models
{
    public class User : IdentityUser<long>
    {
        public List<IdentityRole<long>>? Roles { get; set; }
    }
}