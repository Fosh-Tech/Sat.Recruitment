using Microsoft.AspNetCore.Http;

namespace Sat.Recruitment.Api.Common
{
    public static class Constants
    {
        public static string NAME_IS_MANDATORY = "The name is required";
        public static string EMAIL_IS_MANDATORY = "The email is required";
        public static string ADDRESS_IS_MANDATORY = "The address is required";
        public static string PHONE_IS_MANDATORY = "The phone is required";

        public static string DUPLICATED_USER = "The user is duplicated";
        public static string CREATED_USER = "The user has been created";
        public static string FILE_PATH = "/Files/Users.txt";

        public const string FIELD_SEPARATOR = ",";

        public const string IOC_EXCEPTION = "Component not registered";
    }
}