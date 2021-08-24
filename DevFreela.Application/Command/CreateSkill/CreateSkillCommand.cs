using MediatR;

namespace DevFreela.Application.Command.CreateSkill
{
    public class CreateSkillCommand : IRequest<Unit>
    {
        public string Description { get;  set; }
    }
}
