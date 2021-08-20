using DevFreela.Application.Command.LoginUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.Name, 
                request.Email, 
                request.BirthDate,
                LoginService.ComputeSha256Hash(request.Password),
                request.Role
            );

            await _userRepository.Add(user);

            return new CreateUserViewModel(1, user.Name, user.Email, user.BithDate);
        }
    }
}
