using AutoMapper;
using Domain.Commons;
using Entities.Domain.Users;
using Entities.Domain.Users.Dtos;
using Microsoft.AspNetCore.Identity;

namespace AdminClient.UserEntity
{
    public class CreateUserCommand : ICommand<UserDto>
    {
        public CreateUserCommand(CreateUserDto dto)
        {
            Dto = dto;
        }
        public CreateUserDto Dto { get; }
    }
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        private readonly IMapper mapper;
        private readonly IUserDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateUserCommandHandler(IMapper mapper, IUserDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await User.CreateUserAsync(request.Dto, userManager);
            var repository = dbContext.repository;
            await repository.InsertAsync(user, cancellationToken);
            await dbContext.SaveAsync(cancellationToken);
            return mapper.Map<UserDto>(user);
        }
    }
}
