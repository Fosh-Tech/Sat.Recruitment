using Sat.Recruitment.Application.Models.DTOs;
using Sat.Recruitment.Shared.MediatR.Extensions;

namespace Sat.Recruitment.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequestWrapper<List<UserDTO>> { }
}
