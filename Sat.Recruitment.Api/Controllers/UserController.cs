using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.DTOs.User;
using Sat.Recruitment.Service.Services;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/user")]
    public partial class UserController : ControllerBase
    {
        readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        #region Actions
        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest createUserRequest)
        {
            var userBL = createUserRequest.ToDomain(createUserRequest);

            var newUser = await userService.CreateAsync(userBL);

            var response = CreateUserResponse.FromContext(newUser);
            
            return CreatedAtRoute($"api/user/{newUser.Id}", response);
        }

        //TODO: GET PUT DELETE
        #endregion
    }
}
