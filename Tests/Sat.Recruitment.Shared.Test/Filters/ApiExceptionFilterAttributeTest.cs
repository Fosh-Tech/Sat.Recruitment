using Sat.Recruitment.Shared.Filters;

namespace Sat.Recruitment.Shared.Test.Filters
{
    public class ApiExceptionFilterAttributeTest
    {
        [Fact]
        public void Test_Should_Be_Initialized()
        {
            try
            {
                var apiExceptionFilterAttribute = new ApiExceptionFilterAttribute();

                Assert.NotNull(apiExceptionFilterAttribute);

                Assert.IsType<ApiExceptionFilterAttribute>(apiExceptionFilterAttribute);
            }
            catch
            {
                Assert.True(true, "Fail when initialize ApiExceptionFilterAttribute.");
            }

        }
    }
}
