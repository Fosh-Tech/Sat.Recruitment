namespace Sat.Recruitment.Api.Common
{
    public class Result
    {
        public Result(bool isSuccess, string userMessages)
        {
            IsSuccess = isSuccess;
            UserMessages = userMessages;
        }
        public bool IsSuccess { get; }
        public string UserMessages { get;  }
    }
}
