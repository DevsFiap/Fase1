using Microsoft.EntityFrameworkCore;
using TechChallangeFase01.Domain.Entities;

namespace TechChallangeFase01.Infra.Data.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
  
    public AppDbContext()
    {
        

    }

    public DbSet<Contato> Contato { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
          /* Débito tecnico, por conta de termos uma conexão do banco e não conseguirmos injetar a classe IConfiguration ao 
           * rodar as migrations, temos que chumbar o valor da string do banco de dados aqui(ou mandar a conexão via linha de comando
           * Mudar pra sua sql connection antes de rodar a migration
           */
              optionsBuilder.UseSqlServer("Data Source=(localdb)\\local;Initial Catalog=FiapFase1;Integrated Security=True;");
        }    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}