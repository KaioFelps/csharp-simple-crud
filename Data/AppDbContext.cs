namespace ApiCrud.Data;

using Estudantes;
using Microsoft.EntityFrameworkCore;

// context é um nome utilizado
// pra tudo que tem uma representação de um conjunto
public class AppDbContext : DbContext
{
    public DbSet<Estudante> Estudantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=docker;Database=csharp");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        base.OnConfiguring(optionsBuilder);
    }
}