using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Domain;
using Sat.Recruitment.Api.Model;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IValidationRule userValidationRule;

        private readonly IPromotion promotions;

        private readonly IUserRepository userRepository;

        public UsersController(IValidationRule userValidator, IPromotion promotions, IUserRepository userRepository)
        {
            this.userValidationRule = userValidator;
            this.promotions = promotions;
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string? name, string? email, string? address, string? phone, string? userType, string? money)
        {
            try
            {
                return ValidateUser(name, email, address, phone, userType, money) switch
                {
                    (Model.User user, null) => await this.CreateUser(this.ApplyPromotions(user, money)),
                    (_, string errors) => new Result(false, errors)
                };
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());
                return new Result(false, "Unhandled error");
            }
        }

        public async Task<Result> CreateUser(Domain.User user)
        {
            try
            {
                await this.userRepository.Insert(user);
                return new Result(true, "User Created");
            }
            catch (UserAlreadyExistException)
            {
                return new Result(false, "The user is duplicated");
            }
        }

        private Domain.User ApplyPromotions(Model.User user, string? money)
        {
            var validatedUser = new Domain.User
            {
                Address = user.Address ?? string.Empty,
                Email = user.Email ?? string.Empty,
                Name = user.Name ?? string.Empty,
                Phone = user.Phone ?? string.Empty,
                UserType = user.UserType ?? string.Empty,
                Money = decimal.TryParse(money, out decimal r) ? r : 0m
            };
            return this.promotions.Apply(validatedUser);
        }

        private (Model.User user, string? Errors) ValidateUser(string? name, string? email, string? address, string? phone, string? userType, string? money)
        {
            var user = Model.User.Create(name, email, address, phone, userType);
            string errors = string.Join(' ', this.userValidationRule.Validate(user));
            return (user, (errors.Length > 0) ? errors : null);
        }

        //            var errors = "";

        //ValidateErrors(name, email, address, phone, ref errors);

        //if (errors != null && errors != "")
        //    return new Result()
        //    {
        //        IsSuccess = false,
        //        Errors = errors
        //    };

        //var newUser = new User
        //{
        //    Name = name,
        //    Email = email,
        //    Address = address,
        //    Phone = phone,
        //    UserType = userType,
        //    Money = decimal.Parse(money)
        //};

        //if (newUser.UserType == "Normal")
        //{
        //    if (decimal.Parse(money) > 100)
        //    {
        //        var percentage = Convert.ToDecimal(0.12);
        //        //If new user is normal and has more than USD100
        //        var gif = decimal.Parse(money) * percentage;
        //        newUser.Money = newUser.Money + gif;
        //    }
        //    if (decimal.Parse(money) < 100)
        //    {
        //        if (decimal.Parse(money) > 10)
        //        {
        //            var percentage = Convert.ToDecimal(0.8);
        //            var gif = decimal.Parse(money) * percentage;
        //            newUser.Money = newUser.Money + gif;
        //        }
        //    }
        //}
        //if (newUser.UserType == "SuperUser")
        //{
        //    if (decimal.Parse(money) > 100)
        //    {
        //        var percentage = Convert.ToDecimal(0.20);
        //        var gif = decimal.Parse(money) * percentage;
        //        newUser.Money = newUser.Money + gif;
        //    }
        //}
        //if (newUser.UserType == "Premium")
        //{
        //    if (decimal.Parse(money) > 100)
        //    {
        //        var gif = decimal.Parse(money) * 2;
        //        newUser.Money = newUser.Money + gif;
        //    }
        //}


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
}
