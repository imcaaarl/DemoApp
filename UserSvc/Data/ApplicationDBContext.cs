using Microsoft.EntityFrameworkCore;
using UserSvc.Models;

namespace UserSvc.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> tblusers { get; set; }
        public DbSet<UserRole> tbluserroles { get; set; }
        public DbSet<UserType> tblusertypes { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasOne(u => u.tblusertypes)
        //        .WithOne(ut => ut.tblusers)
        //        .HasForeignKey<User>(u => u.UserTypeId);
        //}
    }
}