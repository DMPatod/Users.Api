using Entities.Domain.Users;
using Entities.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;

namespace Entities.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly EntitiesDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public UserRepository(EntitiesDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public Task<User> DeleteAsync(User entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByGUIDAsync(Guid guid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(User entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task PatchAsync<TValue>(User entity, string propertieName, TValue value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
