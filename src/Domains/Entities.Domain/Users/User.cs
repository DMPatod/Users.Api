using Domain.Commons;

namespace Entities.Domain.Users
{
    public class User : Agregate
    {
        public int Id { get; set; }
        public Guid Identity { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    }
}
