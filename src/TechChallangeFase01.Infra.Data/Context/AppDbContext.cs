using Microsoft.EntityFrameworkCore;
using TechChallangeFase01.Domain.Entities;

namespace TechChallangeFase01.Infra.Data.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Contato> Contato { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}