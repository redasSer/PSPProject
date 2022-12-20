﻿using Microsoft.EntityFrameworkCore;
using PSP.entity;
using PSP.Models;

namespace PSP.Data;
    public class AppDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCard> EmployeeCards { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<CatalogueItem> CatalogueItems { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryUsage> InventoryUsages { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<OrderedItemModification> OrderedItemModifications { get; set; }

        public DbSet<CollectedLoyaltyReward> CollectedLoyaltyRewards { get; set; }
        
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        
        public DbSet<Payment> Payments { get; set; }



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

        modelBuilder.Entity<Shift>().Property(e => e.StartTimeTS).HasColumnName("StartTime") ;
        modelBuilder.Entity<Shift>().Property(e => e.EndTimeTS).HasColumnName("EndTime");

    }
}
