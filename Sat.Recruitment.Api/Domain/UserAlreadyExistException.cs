namespace Sat.Recruitment.Api.Domain
{
    // TODO: Change exception for Railway Oriented Pattern
    [System.Serializable]
    internal class UserAlreadyExistException : System.Exception
    {
        public UserAlreadyExistException(User user)
        {
            this.User = user;
        }

        protected UserAlreadyExistException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public User User { get; } = default!;
    }
}
