using MediatR;

namespace DevFreela.Application.Query.GetUser
{
    public class GetUserQuery : IRequest<GetUserViewModel>
    {
        public GetUserQuery(int idUser)
        {
            IdUser = idUser;
        }

        public int IdUser { get; private set; }
    }
}
