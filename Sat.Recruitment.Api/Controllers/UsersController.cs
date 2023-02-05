using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Infrastructure;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _data;
        private readonly ILogger _logger;

        public UsersController(DataContext data, ILogger<UsersController> logger)
        {
            _data = data;
            _logger = logger;
        }

        [HttpPost]
        [Route("/create-user")]
        public ActionResult<Result> CreateUser(string name, string email, string address, string phone, string userType,
            string money)
        {
            var user = new User()
            {
                Name = name,
                Email = email,
                Address = address,
                Phone = phone,
                UserType = userType,
                Money = decimal.Parse(money)
            };

            Notification notification = new();
            var validUserData = new ValidUserDataSpecification();
            if (!validUserData.IsSatisfiedBy(user, notification))
            {
                return BadRequest(new Result()
                {
                    IsSuccess = false,
                    Errors = string.Join(' ', notification.GetErrors())
                });
            }

            var notDuplicatedUser = new NotDuplicateUserSpecification(_data.GetUsers());
            if (!notDuplicatedUser.IsSatisfiedBy(user, notification))
            {
                return BadRequest(new Result()
                {
                    IsSuccess = false,
                    Errors = notification.GetErrors()[0]
                });
            }

            user.ApplyNewUserGif();
            user.NormalizeEmail();
            
            _logger.LogError("La implementación del método 'CreateUser' no es completa: ¡falta añadir el usuario al fichero!");

            return Ok(new Result()
                {
                    IsSuccess = true,
                    Errors = "User Created"
                }
            );
        }
    }
}