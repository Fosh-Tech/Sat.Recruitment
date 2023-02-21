using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Sat.Recruitment.Api.Controllers.V1
{
    [Route($"api/{Routing.Version}/{Routing.Resources.Probe}")]
    [ApiVersion("1.0")]
    [ApiController]
    [AllowAnonymous]
    public class ProbeController : ControllerBase
    {
        /// <summary>
        /// Probe Controller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(DateTime), StatusCodes.Status200OK)]
        public ActionResult<DateTime> Get() =>
            Ok(DateTime.UtcNow);

    }
}