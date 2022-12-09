using Microsoft.EntityFrameworkCore;
using PSP.Models;

namespace PSP.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=MyDb.db");
        }
    }
}