using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Service.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [ApiVersion("v1.0.0")]
    [Route("api/user")]
    public partial class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        #region Actions
        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateUser([Required] UserShared user) //TODO: [FromBody] agrego?
        {
            //if (user == null)
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await userService.CreateAsync(user);
            return Created($"api/user/{user.Name}", user); //HTTP201 Resource created
        }

        //TODO: hacer el get?
        #endregion
    }
}
