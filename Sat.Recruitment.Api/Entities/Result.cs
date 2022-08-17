namespace Sat.Recruitment.Api.Entities
{
    /// <summary>
    /// Result class to be returned by the ApiControllers.
    /// </summary>
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
