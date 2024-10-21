using GesFin.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GesFin.Api.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(100);
        builder.Property(x => x.Type).IsRequired().HasColumnType("SMALLINT");
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.Amount).HasColumnType("MONEY");
        builder.Property(x => x.CreatedAt).IsRequired(true).HasColumnType("DATETIME");
        builder.Property(x => x.PaidOrReceivedAt).IsRequired(false);
        builder.Property(x => x.UserId)
                        .IsRequired(true)
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(160);
    }
}

