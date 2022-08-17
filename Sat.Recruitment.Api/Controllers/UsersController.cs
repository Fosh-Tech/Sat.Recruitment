using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Policy;

using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Persistence;

namespace Sat.Recruitment.Api.Controllers
{
    //TODO extract every hardcoded message to a proper message manager.

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly List<User> _users = new List<User>(); //TODO move this to a better place when persistence is implemented.

        public UsersController()
        {
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            //Validate the input data.
            var errors = ValidateErrorsOnCreateUserInputs(name, email, address, phone, money);
            if (!string.IsNullOrEmpty(errors))
                return NonSucessfulResult(errors);


            //Try to normalize the email.
            try
            {
                email = NormalizeEmailOnCreateUser(email);
            }
            catch
            {
                return NonSucessfulResult("The email cannot be normalized");
            }
            //TODO the phone should be also normalized.


            //Create the new User instance.
            var newUserParameters = new UsersCreationParameters()
            {
                Name = name, Email = email, Address = address, Phone = phone, UserType = userType, Money = decimal.Parse(money)
            };
            var newUser = UsersFactory.newUser(userType, newUserParameters);


            //Read the entire users db to look for duplicate users.
            //Check if the user is duplicated and return the result.
            try
            {
                _users.AddRange(UsersReader.readUsersFromTextFile());

                if (_users.Any(_ => IsUserDuplicated(_, newUser)))
                {
                    Debug.WriteLine("The user is duplicated");
                    return NonSucessfulResult("The user is duplicated");
                }

                //Success!
                return new Result()
                {
                    IsSuccess = true,
                    Errors = "User Created" //TODO fix the concept. This is not an error so the message should not be in that field.
                };
            }
            catch
            {
                Debug.WriteLine("Error reading the users text file");
                return NonSucessfulResult("Error reading the users text file");
            }
        }

        /// <summary>
        /// Critera to compare if one given user is the duplicated of another given user.
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        private static bool IsUserDuplicated(User u1, User u2)
        {
            return u1.Email == u2.Email || u1.Phone == u2.Phone || (u1.Name == u2.Name && u1.Address == u2.Address);
        }

        /// <summary>
        /// Validate the the inputs of the CreateUser method.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        private string ValidateErrorsOnCreateUserInputs(string name, string email, string address, string phone, string money)
        {
            List<string> errorsList = new List<string>();

            //Validate if Name is null
            if (name == null)
                errorsList.Add("The name is required");

            //Validate if Email is null
            if (email == null)
                errorsList.Add("The email is required");

            //Validate if Address is null
            if (address == null)
                errorsList.Add("The address is required");

            //Validate if Phone is null
            if (phone == null)
                errorsList.Add("The phone is required");

            //Validate Money value
            try
            {
                decimal.Parse(money);
            }
            catch
            {
                errorsList.Add("The money value is not parseable");
            }

            return String.Join(Environment.NewLine, errorsList);
        }

        /// <summary>
        /// Normalize the email of the User to be created by the CreateUser method.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string NormalizeEmailOnCreateUser(string input)
        {
            var aux = input.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            aux[0] = aux[0].Replace(".", "");
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            if (atIndex >= 0) aux[0] = aux[0].Remove(atIndex);
            return string.Format("{0}@{1}", aux[0], aux[1]);
        }

        /// <summary>
        /// Method which retuns a Result object with the IsSucess set as false and a given error message.
        /// </summary>
        /// <param name="errorText"></param>
        /// <returns></returns>
        private static Result NonSucessfulResult(string errorText)
        {
            return new Result() { IsSuccess = false, Errors = errorText };
        }
    }
}
