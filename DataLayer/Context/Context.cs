using DataLayer.Entities;
using DataLayer.Entities.Course;
using DataLayer.Entities.Wallet;
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
        public DbSet<Wallet> wallets { get; set; }
        public DbSet<WalletType> walletTypes { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<CourseLevel> courseLevels { get; set; }
        public DbSet<CourseStatus> courseStatuses { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Episode> episodes { get; set; }

    }
}
