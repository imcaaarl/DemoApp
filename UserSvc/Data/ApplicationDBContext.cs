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
    }
}