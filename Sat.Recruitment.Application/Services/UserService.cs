using AutoMapper;
using Sat.Recruitment.Data.Services;
using Sat.Recruitment.Dto.Dtos;
using Sat.Recruitment.ExtensionMethods;
using Sat.Recruitment.Model.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserReaderService _userReaderService;

        public UserService(IMapper mapper, IUserReaderService userReaderService)
        {
            _mapper = mapper;
            _userReaderService = userReaderService;
        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResultDto> CreateAsync(UserDto dto)
        {
            // Asign to Model
            var newUser = _mapper.Map<User>(dto);

            #region Validation
            var result = ValidateUser(newUser);

            if (!result.IsSuccess)
                return result;
            #endregion

            // Adjust money of the user
            newUser.Money = GetFinalMoney(newUser);

            // Get existing users
            var users = await _userReaderService.GetAllAsync();

            #region Check if new user exists and creation
            if (users.Any( u => 
                u.Email == newUser.Email ||
                u.Phone == newUser.Phone ||
                (u.Name == newUser.Name && u.Address == newUser.Address)))
            {
                result.IsSuccess = false;
                result.Messages.Add("The user is duplicated");
            }
            else
            {
                result.IsSuccess = true;
                result.Messages.Add("User Created");
            }
            #endregion

            return result;

        }

        /// <summary>
        /// Get the final amount of money for the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The final money for the user</returns>
        private decimal GetFinalMoney(User user)
        {
            decimal percentage;

            // If the user has less or equals than USD100, i do nothing
            if (user.Money <= 100)
                return user.Money;
            else
                switch (user.UserType)
                {
                    case "Normal":
                        percentage = 0.12M;
                        break;
                    case "SuperUser":
                        percentage = 0.20M;
                        break;
                    case "Premium":
                        percentage = 2;
                        break;
                    default:
                        // If the user is of another type, i do nothing
                        percentage = 1;
                        break;
                }

            return user.Money * percentage;
        }

        /// <summary>
        /// Validation for user model
        /// </summary>
        /// <param name="user"></param>
        /// <returns>IsSuccess as true if it's valid, false otherwise</returns>
        private ResultDto ValidateUser(User user)
        {
            var output = new ResultDto();

            //Validate if Name is null
            if (string.IsNullOrEmpty(user.Name))
                output.Messages.Add("The name is required");
            //Validate if Email is null
            if (string.IsNullOrEmpty(user.Email))
                output.Messages.Add("The email is required");
            // Validate if Email is valid
            if (!user.Email.IsMail())
                output.Messages.Add("The email is not valid");
            //Validate if Address is null
            if (string.IsNullOrEmpty(user.Address))
                output.Messages.Add("The address is required");
            //Validate if Phone is null
            if (string.IsNullOrEmpty(user.Phone))
                output.Messages.Add("The phone is required");

            // All messages at this method are errors, so i check if i have any messages
            output.IsSuccess = !output.Messages.Any();

            return output;
        }
    }
}
