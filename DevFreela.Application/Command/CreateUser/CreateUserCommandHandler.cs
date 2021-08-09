using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserViewModel>
    {
        public Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.Name, 
                request.Email, 
                request.BirthDate
            );

            return Task.FromResult(new CreateUserViewModel(1, user.Name, user.Email, user.BithDate));
        }
    }
}
