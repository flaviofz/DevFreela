using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Command.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserViewModel>
    {
        public CreateUserCommand(
            string name, 
            string email, 
            DateTime birthDate
        )
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
