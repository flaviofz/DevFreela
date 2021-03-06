using DevFreela.Infrastructure.Persistense.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Query.GetUser
{
    public class GetUserQueryHandler 
        : IRequestHandler<GetUserQuery, GetUserViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetUserQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetUserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.IdUser);

            if (user == null) return null;

            var userViewModel = new GetUserViewModel(user.Id, user.Name, new List<UserSkillViewModel>());

            return userViewModel;
        }
    }
}
