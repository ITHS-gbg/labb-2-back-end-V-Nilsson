using Microsoft.EntityFrameworkCore;
using WestCoast_Education.DAL.Models;

namespace WestCoast_Education.DAL
{
    public class WCEContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        

        public WCEContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(c => c.Level).HasConversion<int>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
