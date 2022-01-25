namespace Entities.Domain.Users.Dtos
{
    public class UserDto
    {
        public Guid Identity { get; set; }
        public string ApplicationUserId { get; set; } = String.Empty;
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
        public string GitHub { get; set; } = String.Empty;
        public string Pluralsight { get; set; } = String.Empty;
    }
}
