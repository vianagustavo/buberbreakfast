using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Database
{
    public class BreakfastContext : DbContext
    {
        public DbSet<Breakfast> Breakfasts { get; set; }
        public DbSet<User> Users { get; set; }

        public BreakfastContext(DbContextOptions<BreakfastContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=breakfasts;User ID=postgres;Password=docker;");
        }
    }
}