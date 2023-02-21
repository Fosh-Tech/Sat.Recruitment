using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers.V1;

namespace Sat.Recruitment.API.Test.Controllers.V1
{
    public class ProbeControllerTest
    {
        [Fact]
        public void Test_Get_Returns_NotNull_Ok_DateTime() {
            var controller = new ProbeController();

            ActionResult<DateTime> result = controller.Get();

            Assert.NotNull(result);
           
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<DateTime>(result.Value);           
        }
    }
}
