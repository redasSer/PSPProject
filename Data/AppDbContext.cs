using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PSP.Models;
using System;

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
    public DbSet<Location> Locations { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CatalogueItem> CatalogueItems { get; set; }
    public DbSet<Inventory> Inventory { get; set; }
    public DbSet<InventoryUsage> InventoryUsages { get; set; }
    public DbSet<Modifier> Modifiers { get; set; }
    public DbSet<OrderedItemModification> OrderedItemModifications { get; set; }
    public DbSet<CollectedLoyaltyReward> CollectedLoyaltyRewards { get; set; }
    public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<DiscountCode> DiscountCodes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderedItem> OrderedItems { get; set; }
    public DbSet<Subscriptions> Subscriptions { get; set; }
    public DbSet<SubscriptionsType> SubscriptionsType { get; set; }


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

        modelBuilder.Entity<Permission>().HasOne(v => v.permissionType).WithMany().HasForeignKey(v => v.PermissionTypeId);
        modelBuilder.Entity<Permission>().HasOne(v => v.client).WithMany().HasForeignKey(v => v.ClientId);
        modelBuilder.Entity<Permission>().HasOne(v => v.role).WithMany().HasForeignKey(v => v.RoleId);

        modelBuilder.Entity<Role>().HasOne(v => v.client).WithMany().HasForeignKey(v => v.ClientId);

        modelBuilder.Entity<Employee>().HasOne(v => v.role).WithMany().HasForeignKey(v => v.RoleId);
        modelBuilder.Entity<Employee>().HasOne(v => v.location).WithMany().HasForeignKey(v => v.LocationId);

        modelBuilder.Entity<EmployeeCard>().HasOne(v => v.location).WithMany().HasForeignKey(v => v.LocationId);
        modelBuilder.Entity<EmployeeCard>().HasOne(v => v.employee).WithMany().HasForeignKey(v => v.EmployeeId);


        modelBuilder.Entity<EmployeeShift>().HasOne(v => v.employee).WithMany().HasForeignKey(v => v.EmployeeId);
        modelBuilder.Entity<EmployeeShift>().HasOne(v => v.shift).WithMany().HasForeignKey(v => v.ShiftId);

        modelBuilder.Entity<CatalogueItem>().HasOne(v => v.Client).WithMany().HasForeignKey(v => v.ClientId);

        modelBuilder.Entity<Inventory>().HasOne(v => v.Location).WithMany().HasForeignKey(v => v.LocationId);

        modelBuilder.Entity<InventoryUsage>().HasOne(v => v.CatalogueItem).WithMany().HasForeignKey(v => v.CatalogueItemId);
        modelBuilder.Entity<InventoryUsage>().HasOne(v => v.Client).WithMany().HasForeignKey(v => v.ClientId);
        modelBuilder.Entity<InventoryUsage>().HasOne(v => v.Item).WithMany().HasForeignKey(v => v.ItemId);

        modelBuilder.Entity<Modifier>().HasOne(v => v.CatalogueItem).WithMany().HasForeignKey(v => v.CatalogueItemId);
        modelBuilder.Entity<Modifier>().HasOne(v => v.Client).WithMany().HasForeignKey(v => v.ClientId);
        modelBuilder.Entity<Modifier>().HasOne(v => v.Item).WithMany().HasForeignKey(v => v.ItemId);

        modelBuilder.Entity<OrderedItemModification>().HasOne(v => v.OrderedItem).WithMany().HasForeignKey(v => v.OrderedItemId);
        modelBuilder.Entity<OrderedItemModification>().HasOne(v => v.Modifier).WithMany().HasForeignKey(v => v.ModifierId);

        modelBuilder.Entity<DiscountCode>().HasOne(v => v.Client).WithMany().HasForeignKey(v => v.ClientId);

        modelBuilder.Entity<UsedDiscountCode>().HasOne(v => v.DiscountCode).WithMany().HasForeignKey(v => new { v.Code, v.ClientId });
        modelBuilder.Entity<UsedDiscountCode>().HasOne(v => v.Order).WithMany().HasForeignKey(v => v.OrderId);

        modelBuilder.Entity<Order>().HasOne(v => v.Customer).WithMany().HasForeignKey(v => v.CustomerId);
        modelBuilder.Entity<Order>().HasOne(v => v.Employee).WithMany().HasForeignKey(v => v.EmployeeId);

        modelBuilder.Entity<OrderedItem>().HasOne(v => v.Location).WithMany().HasForeignKey(v => v.LocationId);
        modelBuilder.Entity<OrderedItem>().HasOne(v => v.Order).WithMany().HasForeignKey(v => v.OrderId);
        modelBuilder.Entity<OrderedItem>().HasOne(v => v.CatalogueItem).WithMany().HasForeignKey(v => v.CatalogueItemId);
    }
}
