using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SportsContext
{
    public class SportsContext : DbContext
    {
        public DbSet<SportsTeam> Teams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SportDB;Trusted_Connection=True;"
);
        }
    }
}