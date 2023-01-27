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
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            var userBL = createUserRequest.ToDomain(createUserRequest);
            await userService.CreateAsync(userBL);
            return Created($"api/user/{userBL.Name}", userBL); //HTTP201 Resource created
        }

        //TODO: GET PUT DELETE
        #endregion
    }
}
