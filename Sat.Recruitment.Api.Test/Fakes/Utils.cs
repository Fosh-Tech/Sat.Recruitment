using Microsoft.AspNetCore.Mvc;

namespace Sat.Recruitment.Api.Test.Fakes
{
    public static class Utils
    {
        public static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
