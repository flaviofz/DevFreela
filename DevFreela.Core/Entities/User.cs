using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(
            string name, 
            string email, 
            DateTime bithDate, 
            string password, 
            string role
        )
        {
            Name = name;
            Email = email;
            BithDate = bithDate;
            CreatedAt = DateTime.Now;
            UserSkils = new List<UserSkill>();
            ProvidedServices = new List<ProvidedService>();
            OwningProvidedServices = new List<ProvidedService>();
            Active = true;
            Password = password;
            Role = role;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BithDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        // Relacionamentos
        public List<UserSkill> UserSkils { get; private set; }
        public List<ProvidedService> ProvidedServices{ get; private set; }
        public List<ProvidedService> OwningProvidedServices { get; private set; }
    }
}
