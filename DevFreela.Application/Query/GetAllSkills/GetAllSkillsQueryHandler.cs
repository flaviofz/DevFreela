using DevFreela.Core.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Query.GetAllSkills
{
    public class GetAllSkillsQueryHandler
        : IRequestHandler<GetAllSkillsQuery, List<SkillsViewModel>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillsViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAll();

            var skillsViewModel = skills
                .Select(x => new SkillsViewModel(x.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
