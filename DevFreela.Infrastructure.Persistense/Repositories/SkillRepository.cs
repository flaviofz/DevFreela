using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using DevFreela.Infrastructure.Persistense.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistense.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
            _connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
        }

        public async Task Add(Skill skill)
        {
            // EF Core
            //await _dbContext.Skills.AddAsync(skill);
            //await _dbContext.SaveChangesAsync();

            // Dapper
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Skills (Description, CreatedAt) VALUES (@description, GETDATE())";
                // Utilizando parâmetro evita o SQl Injection

                await sqlConnection.ExecuteAsync(sql, new { description = skill.Description });
            }
        }

        public async Task<List<Skill>> GetAll()
        {
            // return await _dbContext.Skills.AsNoTracking().ToListAsync();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT Id, Description, CreatedAt FROM Skills";

                var result = await sqlConnection.QueryAsync<Skill>(sql);

                return result.ToList();
            }
        }
    }
}
