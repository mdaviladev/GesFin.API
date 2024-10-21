using System.Reflection;
using GesFin.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GesFin.Api.Data;

public class AppDBContext: DbContext {
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

