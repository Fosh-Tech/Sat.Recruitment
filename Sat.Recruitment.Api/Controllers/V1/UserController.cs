using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Models.DTOs;
using Sat.Recruitment.Application.Models.Responses;
using Sat.Recruitment.Application.Users.Commands.CreateUser;
using Sat.Recruitment.Application.Users.Queries.GetAllUsers;
using Sat.Recruitment.Application.Users.Queries.GetUser;
using Sat.Recruitment.Shared.Models.ResponseWrappers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers.V1
{
    [Route($"api/{Routing.Version}/{Routing.Resources.User}")]
    [ApiVersion("1.0")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult<List<UserDTO>>), StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = Shared.Cache.Profiles.WithUserAgentCacheProfile.CACHERESPONSEPROFILENAME)]
        public async Task<ActionResult<ServiceResult<List<UserDTO>>>> GetAllAsync(CancellationToken cancellationToken = default) =>
            Ok(await _sender.Send(new GetAllUsersQuery(), cancellationToken));

        [HttpGet(Routing.Parameters.UserName)]
        [ProducesResponseType(typeof(ServiceResult<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResult<UserDTO>), StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = Shared.Cache.Profiles.WithUserAgentCacheProfile.CACHERESPONSEPROFILENAME)]
        public async Task<ActionResult<ServiceResult<UserDTO>>> GetAsync(string userName, CancellationToken cancellationToken = default) =>
          Ok(await _sender.Send(new GetUserQuery(userName), cancellationToken));

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult<CreateUserResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResult<CreateUserResponse>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResult<CreateUserResponse>>> CreateAsync([FromBody, Required] CreateUserCommand createUserCommand, CancellationToken cancellationToken = default) =>
            Ok(await _sender.Send(createUserCommand, cancellationToken));
    }
}
