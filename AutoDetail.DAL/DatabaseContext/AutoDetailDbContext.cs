using AutoDetail.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDetail.DAL.DatabaseContext
{
    public class AutoDetailDbContext : DbContext
    {
        public DbSet<UserDb> Users { get; set; }

        public AutoDetailDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
