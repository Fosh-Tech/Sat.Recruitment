using Sat.Recruitment.Shared.Models.ResponseWrappers;

namespace Sat.Recruitment.Shared.Test.Models.ResponseWrappers
{

    public class ServiceResultTest
    {
        [Fact]
        public void Test_Constructor_Should_Be_Initialized()
        {
            var error = new ServiceError(message: "test message", code: 1);
            var serviceResult = new ServiceResult(error);

            Assert.NotNull(serviceResult);
            Assert.NotNull(serviceResult.Error);
            Assert.IsType<ServiceResult>(serviceResult);
            Assert.IsType<ServiceError>(serviceResult.Error);
        }

        [Fact]
        public void Test_Suceeded_False()
        {
            var error = new ServiceError(message: "test message", code: 1);
            var serviceResult = new ServiceResult(error);

            Assert.False(serviceResult.Succeeded);
        }
    }
}

