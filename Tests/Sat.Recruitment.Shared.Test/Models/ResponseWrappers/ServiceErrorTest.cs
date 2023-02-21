using Sat.Recruitment.Shared.Models.ResponseWrappers;

namespace Sat.Recruitment.Shared.Test.Models.ResponseWrappers
{
    public class ServiceErrorTest
    {
        [Fact]
        public void Test_Constructor_Should_Be_Initialized()
        {
            var error = new { message = "test message", code = 1 };
            var serviceError = new ServiceError(error.message, error.code);

            Assert.NotNull(serviceError);
            Assert.NotNull(serviceError.Message);
            Assert.NotEmpty(serviceError.Message);
            Assert.Equal(error.code, serviceError.Code);
            Assert.IsType<ServiceError>(serviceError);
        }
    }
}
