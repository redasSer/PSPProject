using Microsoft.EntityFrameworkCore;
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
<<<<<<< Updated upstream
=======
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }


>>>>>>> Stashed changes



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
