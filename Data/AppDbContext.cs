using Microsoft.EntityFrameworkCore;
using PSP.entity;
using PSP.Models;

namespace PSP.Data;
    public class AppDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=MyDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<EmployeeShiftsModel>()
            //        .HasOne < Employee>()
            //        .WithMany()
            //        .HasForeignKey(x => x.EmployeeId); ;


        }
    }
