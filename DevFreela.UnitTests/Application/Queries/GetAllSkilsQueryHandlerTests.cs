using DevFreela.Application.Query.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkilsQueryHandlerTests
    {
        [Fact]
        public async Task ExistThreeSkills_Executed_ThreeSkilViewModel()
        {
            // Arrange
            var skills = new List<Skill>
            {
                new Skill(".Net"),
                new Skill("Angular"),
                new Skill("Sql Server")
            };

            var skillRepository = new Mock<ISkillRepository>();
            skillRepository.Setup(x => x.GetAll()).Returns(Task.FromResult(skills));

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepository.Object);

            // Act
            var skillsViewModel = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(skillsViewModel);
            Assert.Equal(skills.Count, skillsViewModel.Count);

            foreach (var skill in skills)
            {
                var skillViewModel = skillsViewModel.SingleOrDefault(x => x.Description == skill.Description);
                Assert.NotNull(skillViewModel);
            }

            skillRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
