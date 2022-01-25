using Domain.DomainEvents;

namespace Entities.Domain.Users.Events
{
    internal class CreateUser : IDomainEvent
    {
        public User User { get; private set; }
        public CreateUser(User user)
        {
            User = user;
        }
    }
}
