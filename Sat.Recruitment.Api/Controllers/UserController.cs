using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Services;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/user")]
    public partial class UserController : ControllerBase
    {
        readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        #region Actions
        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateUser(UserShared userShared)
        {
            await userService.CreateAsync(userShared);
            return Created($"api/user/{userShared.Name}", userShared); //HTTP201 Resource created
        }

        //TODO: GET PUT DELETE
        #endregion
    }
}
