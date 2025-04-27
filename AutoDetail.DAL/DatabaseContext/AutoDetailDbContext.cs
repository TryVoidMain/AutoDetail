using AutoDetail.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDetail.DAL.DatabaseContext
{
    public class AutoDetailDbContext : DbContext
    {
        public DbSet<UserDb> Users { get; set; }
        public DbSet<AddressDb> Adresses { get; set; }

        public AutoDetailDbContext(DbContextOptions<AutoDetailDbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>(entity =>
            {
                entity.ToTable(nameof(Users));

                entity.HasKey(u => u.Id);
                entity.Property(p => p.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(p => p.Address)
                    .WithOne(e => e.User)
                    .HasForeignKey<AddressDb>(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AddressDb>(entity =>
            {
                entity.ToTable(nameof(Adresses));
                entity.HasKey(u => u.Id);

                entity.Property(p => p.Country)
                    .HasMaxLength(50);

                entity.Property(p => p.City)
                    .HasMaxLength(50);

                entity.Property(p => p.Street)
                    .HasMaxLength(50);

                entity.Property(p => p.Appartments)
                    .HasMaxLength(10);
            });
        }
    }
}
