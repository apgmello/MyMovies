using Microsoft.EntityFrameworkCore;
using MyMovies.Entities;

namespace MyMovies.Repositories.Database.Context
{
    public class SQLiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=movies.db;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToWatch>()
              .HasKey(p => new { p.Id });

            modelBuilder.Entity<Watched>()
              .HasKey(p => new { p.Id });

            modelBuilder.Entity<Watched>()
              .Property<DateTime>("Date");
        }

        public DbSet<ToWatch>? ToWatch { get; set; }
        public DbSet<Watched>? Watched { get; set; }
    }
}
