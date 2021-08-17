using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using DevFreela.Infrastructure.Persistense.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistense.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Skill skill)
        {
            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Skill>> GetAll()
        {
            return await _dbContext.Skills.AsNoTracking().ToListAsync();
        }
    }
}
