using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Query.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillsViewModel>>
    {
    }
}
