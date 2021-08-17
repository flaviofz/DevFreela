using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Interfaces.Repositories
{
    public interface ISkillRepository
    {
        Task Add(Skill skill);
        Task<List<Skill>> GetAll();
    }
}
