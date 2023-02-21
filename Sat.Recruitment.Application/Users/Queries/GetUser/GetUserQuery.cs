using Sat.Recruitment.Application.Models.DTOs;
using Sat.Recruitment.Shared.MediatR.Extensions;

namespace Sat.Recruitment.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequestWrapper<UserDTO>
    {

        public GetUserQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; private set; }
    }
}
