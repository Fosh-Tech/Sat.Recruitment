using Microsoft.AspNetCore.Http;

namespace Sat.Recruitment.Shared.Models.ResponseWrappers
{
    /// <summary>
    /// All errors contained in ServiceResult objects must return an error of this type
    /// Error codes allow the caller to easily identify the received error and take action.
    /// Error messages allow the caller to easily show error messages to the end user.
    /// </summary>
    [Serializable]
    public class ServiceError
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ServiceError(string message, int code)
        {
            Message = message;
            Code = code;
        }

        public ServiceError() { }

        /// <summary>
        /// Human readable error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Machine readable error code
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Default error for when we receive an exception
        /// </summary>
        public static ServiceError DefaultError => new("An exception occured.", StatusCodes.Status400BadRequest);

        /// <summary>
        /// Default validation error. Use this for invalid parameters in controller actions and service methods.
        /// </summary>
        public static ServiceError ModelStateError(string validationError)
        {
            return new ServiceError(validationError, StatusCodes.Status417ExpectationFailed);
        }

        /// <summary>
        /// Use this for unauthorized responses.
        /// </summary>
        public static ServiceError ForbiddenError => new("You are not authorized to call this action.", StatusCodes.Status403Forbidden);

        /// <summary>
        /// Use this to send a custom error message
        /// </summary>
        public static ServiceError CustomMessage(string errorMessage, int statusCodes)
        {
            return new ServiceError(errorMessage, statusCodes);
        }

        public static ServiceError UserNotFound => new("User with this id does not exist", StatusCodes.Status404NotFound);

        public static ServiceError UserFailedToCreate => new("Failed to create User.", StatusCodes.Status417ExpectationFailed);

        public static ServiceError Canceled => new("The request canceled successfully!", StatusCodes.Status410Gone);

        public static ServiceError NotFound => new("The specified resource was not found.", StatusCodes.Status404NotFound);

        public static ServiceError ValidationFormat => new("Request object format is not true.", StatusCodes.Status400BadRequest);
        
        public static ServiceError Validation => new("One or more validation errors occurred.", StatusCodes.Status400BadRequest);

        public static ServiceError SearchAtLeastOneCharacter => new("Search parameter must have at least one character!", StatusCodes.Status411LengthRequired);

        /// <summary>
        /// Default error for when we receive an exception
        /// </summary>
        public static ServiceError ServiceProviderNotFound => new("Service Provider with this name does not exist.", StatusCodes.Status404NotFound);

        public static ServiceError ServiceProvider => new("Service Provider failed to return as expected.", StatusCodes.Status400BadRequest);

        public static ServiceError DateTimeFormatError => new("Date format is not true. Date format must be like yyyy-MM-dd (2019-07-19)", StatusCodes.Status400BadRequest);

        #region Override Equals Operator

        /// <summary>
        /// Use this to compare if two errors are equal
        /// Ref: https://msdn.microsoft.com/ru-ru/library/ms173147(v=vs.80).aspx
        /// </summary>
        public override bool Equals(object obj)
        {
            // If parameter cannot be cast to ServiceError or is null return false.
            var error = obj as ServiceError;

            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public bool Equals(ServiceError error)
        {
            // Return true if the error codes match. False if the object we're comparing to is null
            // or if it has a different code.
            return Code == error?.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(ServiceError a, ServiceError b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(ServiceError a, ServiceError b)
        {
            return !(a == b);
        }

        #endregion
    }

}
