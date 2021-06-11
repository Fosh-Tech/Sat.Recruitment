namespace Sat.Recruitment.Api.Model
{
    public readonly struct Result
    {
        public Result(bool isSuccess, string errors)
        {
            this.IsSuccess = isSuccess;
            this.Errors = errors;
        }

        public readonly bool IsSuccess;

        public readonly string Errors;

        public void Deconstruct(out bool isSuccess, out string errors)
        {
            isSuccess = this.IsSuccess;
            errors = this.Errors;
        }
    }
}
