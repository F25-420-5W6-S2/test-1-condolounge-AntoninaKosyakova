using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CondoLounge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>().
                HasKey(b => b.BuildingId);

            modelBuilder.Entity<Condo>().
                HasKey(c => c.CondoNumber);

            modelBuilder.Entity<Condo>()
                .HasOne(c => c.Building)
                .WithMany(b => b.Condos)
                .HasForeignKey(c => c.BuildingId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Condos)
                .WithMany(c => c.Users)
                .UsingEntity(j => j.ToTable("UserCondos"));
                
        }

        public DbSet<Condo> Condos { get; set; }
        public DbSet<Building> Buildings { get; set; }
    }
}
