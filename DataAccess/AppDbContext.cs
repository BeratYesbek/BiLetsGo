using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=BiletsgoDB;Port=5432;Username=postgres;Password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          /*  modelBuilder.Entity<Ticket>().HasOne(t => t.Category).WithMany(b => b.Tickets).HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Ticket>().HasOne(t => t.Salon).WithMany(b => b.Tickets).HasForeignKey(t => t.SalonId);
            modelBuilder.Entity<Seat>().HasOne(t => t.Salon).WithMany(b => b.Seats).HasForeignKey(t => t.SalonId);
            modelBuilder.Entity<Salon>().Navigation(t => t.Seats).HasField("_Seats").UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<TicketFile>().HasOne(t => t.Ticket).WithMany(b => b.TicketFiles).HasForeignKey(t => t.TicketId);*/
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFile> TicketFiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<BookedSeat> BookedSeats { get; set; }

    }
}
