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


    }
}
