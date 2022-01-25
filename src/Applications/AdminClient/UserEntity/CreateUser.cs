using MediatR;

namespace AdminClient.UserEntity
{
    public class CreateUser : IRequest<int>
    {
    }

    public class CreateUserHandler : IRequestHandler<CreateUser, int>
    {
        public Task<int> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
