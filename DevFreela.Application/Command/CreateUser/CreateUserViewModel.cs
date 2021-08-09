using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Command.CreateUser
{
    public class CreateUserViewModel
    {
        public CreateUserViewModel(
            int id, 
            string name, 
            string email, 
            DateTime birthDate
        )
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
