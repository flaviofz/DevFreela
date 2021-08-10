﻿using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
            UserSkills = new List<UserSkill>();
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserSkill> UserSkills { get; set; }
    }
}
