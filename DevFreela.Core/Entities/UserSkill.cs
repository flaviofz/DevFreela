﻿using System;

namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
            CreatedAt = DateTime.Now;
        }

        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
