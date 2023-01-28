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

            var newUser = await userService.CreateAsync(userBL);

            //create GetUserResponse with GET... then return CreatedAtRoute(newUser); --> TODO: With GET route

            return Created($"api/user/{newUser.Id}", newUser); //HTTP201 Resource created
        }

        //TODO: GET PUT DELETE
        #endregion
    }
}
