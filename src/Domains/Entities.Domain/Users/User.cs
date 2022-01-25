using Domain.Commons;
using Entities.Domain.Users.Dtos;
using Entities.Domain.Users.Events;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Entities.Domain.Users
{
    public class User : Agregate
    {
        public int Id { get; set; }
        public Guid Identity { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
        public static async Task<User> CreateUserAsync(CreateUserDto dto, UserManager<ApplicationUser> userManager)
        {
            var user = new User();
            user.Identity = Guid.NewGuid();
            user.ApplicationUser = await RegisterUserIdentityAsync(dto, userManager);
            user.ApplicationUserId = user.ApplicationUser.Id;

            user.AddDomainEvent(new CreateUser(user));
            return user;
        }
        private static async Task<ApplicationUser> RegisterUserIdentityAsync(CreateUserDto dto, UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                EmailConfirmed = true,
            };
            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            result = await userManager.AddClaimsAsync(user,
                new Claim[]
                {
                    new Claim(JwtClaimTypes.Email,dto.Email),
                });

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            return user;
        }
    }
}
