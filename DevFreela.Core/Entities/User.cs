﻿using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, DateTime bithDate)
        {
            Name = name;
            Email = email;
            BithDate = bithDate;
            CreatedAt = DateTime.Now;
            UserSkils = new List<UserSkill>();
            ProvidedServices = new List<ProvidedService>();
            OwningProvidedServices = new List<ProvidedService>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BithDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // Relacionamentos
        public List<UserSkill> UserSkils { get; private set; }
        public List<ProvidedService> ProvidedServices{ get; private set; }
        public List<ProvidedService> OwningProvidedServices { get; private set; }
    }
}
