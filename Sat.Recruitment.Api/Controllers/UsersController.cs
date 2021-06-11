using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IValidationRule userValidator;

        private readonly IPromotion promotion;

        public UsersController(IValidationRule userValidator, IPromotion promotion)
        {
            this.userValidator = userValidator;
            this.promotion = promotion;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string? name, string? email, string? address, string? phone, string? userType, string? money)
        {
            User user = ConstructUser(name, email, address, phone, userType, money);
            Result result = this.Validate(user);
            if (!result.IsSuccess)
            {
                return result;
            }

            user = this.promotion.Apply(user);

            return new Result(true, "User Created");

            //var reader = ReadUsersFromFile();

            ////Normalize email
            //var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            //var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            //aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            //newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });

            //while (reader.Peek() >= 0)
            //{
            //    var line = reader.ReadLineAsync().Result;
            //    var user = new User
            //    {
            //        Name = line.Split(',')[0].ToString(),
            //        Email = line.Split(',')[1].ToString(),
            //        Phone = line.Split(',')[2].ToString(),
            //        Address = line.Split(',')[3].ToString(),
            //        UserType = line.Split(',')[4].ToString(),
            //        Money = decimal.Parse(line.Split(',')[5].ToString()),
            //    };
            //    _users.Add(user);
            //}
            //reader.Close();
            //try
            //{
            //    var isDuplicated = false;
            //    foreach (var user in _users)
            //    {
            //        if (user.Email == newUser.Email
            //            ||
            //            user.Phone == newUser.Phone)
            //        {
            //            isDuplicated = true;
            //        }
            //        else if (user.Name == newUser.Name)
            //        {
            //            if (user.Address == newUser.Address)
            //            {
            //                isDuplicated = true;
            //                throw new Exception("User is duplicated");
            //            }

            //        }
            //    }

            //    if (!isDuplicated)
            //    {
            //        Debug.WriteLine("User Created");

            //        return new Result()
            //        {
            //            IsSuccess = true,
            //            Errors = "User Created"
            //        };
            //    }
            //    else
            //    {
            //        Debug.WriteLine("The user is duplicated");

            //        return new Result()
            //        {
            //            IsSuccess = false,
            //            Errors = "The user is duplicated"
            //        };
            //    }
            //}
            //catch
            //{
            //    Debug.WriteLine("The user is duplicated");
            //    return new Result()
            //    {
            //        IsSuccess = false,
            //        Errors = "The user is duplicated"
            //    };
            //}

            //return new Result()
            //{
            //    IsSuccess = true,
            //    Errors = "User Created"
            //};
        }

        private static Model.User ConstructUser(string? name, string? email, string? address, string? phone, string? userType, string? money) =>
            new Model.User
            {
                Address = address,
                Email = email,
                Money = decimal.TryParse(money, out decimal amount) ? amount : 0m, // should handle ParseExceptions
                Name = name,
                Phone = phone,
                UserType = userType
            };

        private Result Validate(User user)
        {
            string errors = string.Join(" ", this.userValidator.Validate(user));
            return new Result(!string.IsNullOrEmpty(errors), errors);
        }
    }
}
