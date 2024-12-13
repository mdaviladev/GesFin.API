using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GesFin.Api.Data.Mappings.Identity
{
    public class IdentityUserRoleMapping
    : IEntityTypeConfiguration<IdentityUserRole<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
        {
            builder.ToTable("UserRole","Identity");
            builder.HasKey(r => new { r.UserId, r.RoleId });
        }
    }
}