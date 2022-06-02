using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false)
            .UseNpgsql("User ID=gdcualuevexhby;Password=31a311eef49d3309e1a09b08b1356e2976ebd7ea44a07b93fba49a2da786ecd8;Host=ec2-52-48-159-67.eu-west-1.compute.amazonaws.com;Port=5432;Database=d1i4rcr0trbo99;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasOne(t => t.Category).WithMany(b => b.Tickets).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Ticket>().HasOne(t => t.Salon).WithMany(b => b.Tickets).HasForeignKey(t => t.SalonId);
            modelBuilder.Entity<Seat>().HasOne(t => t.Salon).WithMany(b => b.Seats).HasForeignKey(t => t.SalonId);
            modelBuilder.Entity<Salon>().Navigation(t => t.Seats).HasField("_Seats").UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<TicketFile>().HasOne(t => t.Ticket).WithMany(b => b.TicketFiles).HasForeignKey(t => t.TicketId);
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFile> TicketFiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
