using Microsoft.EntityFrameworkCore;
using hero_csharp.Models;

namespace hero_csharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Source=LAPTOP-MEVMBK22\\MSSQLSERVER02;Initial Catalog=hero;Integrated Security=True;Encrypt=False");
        }


    }
}
