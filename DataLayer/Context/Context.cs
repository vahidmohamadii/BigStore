

using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class BigStoreContext:DbContext
    {
        public BigStoreContext(DbContextOptions options):base(options)
        {
                    
        }

        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }

    }
}
