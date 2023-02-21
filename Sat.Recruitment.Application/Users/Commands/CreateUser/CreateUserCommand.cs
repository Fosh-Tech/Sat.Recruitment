using Sat.Recruitment.Application.Models.Requests;
using Sat.Recruitment.Application.Models.Responses;
using Sat.Recruitment.Shared.MediatR.Extensions;

namespace Sat.Recruitment.Application.Users.Commands.CreateUser
{

    public class CreateUserCommand : IRequestWrapper<CreateUserResponse>
    {
        public CreateUserRequest CreateUserRequest { get; set; }
    }
}
