using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Query.GetUser
{
    public class GetUserQueryHandler 
        : IRequestHandler<GetUserQuery, GetUserViewModel>
    {
        public Task<GetUserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserViewModel(1, "", new List<UserSkillViewModel>()));
        }
    }
}
