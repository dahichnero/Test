using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ServicesBot.Models
{
    public class ServicesSubsContext : DbContext
    {

        public ServicesSubsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ServiceSubs> Services { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<UserPeriod> UserPeriods { get; set; }
    }
}
