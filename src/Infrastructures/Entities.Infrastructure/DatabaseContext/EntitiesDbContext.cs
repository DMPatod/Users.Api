using Entities.Domain.Users;
using Entities.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace Entities.Infrastructure.DatabaseContext
{
    public class EntitiesDbContext : DbContext
    {
        public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
}
