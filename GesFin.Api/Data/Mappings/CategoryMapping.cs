using GesFin.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GesFin.Api.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(x => x.Id);  
        builder.Property(x => x.Description)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);
        builder.Property(x => x.Title)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);
        builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
                

    }
}
