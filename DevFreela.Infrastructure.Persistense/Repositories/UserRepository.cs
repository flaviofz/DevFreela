using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using DevFreela.Infrastructure.Persistense.Context;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistense.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
