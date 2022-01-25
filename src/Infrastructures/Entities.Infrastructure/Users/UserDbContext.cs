using Domain.DomainEvents;
using Entities.Domain.Users;
using Entities.Infrastructure.DatabaseContext;
using Infrastructure.Commons;
using Microsoft.AspNetCore.Identity;

namespace Entities.Infrastructure.Users
{
    public class UserDbContext : IUserDbContext
    {
        private readonly EntitiesDbContext entitiesDbContext;
        private readonly IDomainMessageHandler messageHandler;
        private readonly UserManager<ApplicationUser> userManager;
        public UserDbContext(EntitiesDbContext entitiesDbContext, IDomainMessageHandler messageHandler, UserManager<ApplicationUser> userManager)
        {
            this.entitiesDbContext = entitiesDbContext;
            this.messageHandler = messageHandler;
            this.userManager = userManager;
        }
        public IRepository<User> repository => new UserRepository(entitiesDbContext, userManager);

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            var eventHolders = entitiesDbContext.ChangeTracker.Entries()
                .Where(x => x.Entity is DomainEventHolder)
                .Select(x => x.Entity as DomainEventHolder)
                .ToList();

            foreach (var eventHolder in eventHolders)
            {
                _ = eventHolder ?? throw new ArgumentNullException(nameof(eventHolder));

                while (eventHolder.TyrRemoveDomainEvent(out var domainEvent))
                {
                    await messageHandler.PublishAsync(domainEvent, cancellationToken);
                }
            }
            await entitiesDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
