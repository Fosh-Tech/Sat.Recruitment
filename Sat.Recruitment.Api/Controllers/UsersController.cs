using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/create-user")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromQuery]UserDto dto)
        {
            var result = await _service.CreateAsync(dto);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
