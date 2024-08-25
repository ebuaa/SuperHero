using Microsoft.EntityFrameworkCore;
using hero_csharp.Models;

namespace hero_csharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Ajoutez cette ligne pour inclure le DbSet de Hero
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-MEVMBK22\\MSSQLSERVER02;Database=hero;Integrated Security=True;Encrypt=False"
            );
        }
    }
}