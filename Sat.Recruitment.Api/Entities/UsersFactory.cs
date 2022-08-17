using System.Security.Policy;
using System;

namespace Sat.Recruitment.Api.Entities
{
    /// <summary>
    /// Different available user types.
    /// </summary>
    public enum UsersType
    {
        Normal,
        SuperUser,
        Premium
    }

    /// <summary>
    /// Class which inherits all the fields of the User class.
    /// </summary>
    public class UsersCreationParameters : User { }

    /// <summary>
    /// Factory class which returns a new user given a type and some UsersCreationParameters.
    /// </summary>
    public class UsersFactory
    {
        public static User newUser(UsersCreationParameters parameters)
        {
            Enum.TryParse(parameters.UserType, out UsersType myUserType);
            return newUser(myUserType, parameters);
        }

        public static User newUser(string type, UsersCreationParameters parameters)
        {
            Enum.TryParse(type, out UsersType myUserType);
            return newUser(myUserType, parameters);
        }

        public static User newUser(UsersType type, UsersCreationParameters parameters)
        {
            switch (type)
            {
                case UsersType.Normal:
                    return new UserNormal(parameters);
                case UsersType.SuperUser:
                    return new UserSuperUser(parameters);
                case UsersType.Premium:
                    return new UserPremium(parameters);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}