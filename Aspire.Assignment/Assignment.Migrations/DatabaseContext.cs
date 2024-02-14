using Microsoft.EntityFrameworkCore;
using Assignment.Contracts.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Assignment.Contracts.Data.Entities.Identity;

namespace Assignment.Migrations
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            {
                item.Entity.AddedOn = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Address> Addresses { get; set; }
    }
}