using Infrastructure.Commons;

namespace Entities.Domain.Users
{
    public interface IUserDbContext : IDbContext<User>
    {
    }
}
