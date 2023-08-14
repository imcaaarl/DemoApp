using Microsoft.EntityFrameworkCore;
using AuthSvc.Models;

namespace AuthSvc.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<UserAccount> tblusers { get; set; }
    }
}