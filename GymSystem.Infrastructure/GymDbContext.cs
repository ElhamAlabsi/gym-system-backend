using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GymSystem.Domain.Enums;

namespace GymSystem.Infrastructure
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<String>();

           modelBuilder.Entity<Subscription>()
                .HasOne(s=>s.Member)
                .WithMany()
                .HasForeignKey(s=>s.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                .HasOne(s=>s.Coach)
                .WithMany()
                .HasForeignKey(s=>s.CoachId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
