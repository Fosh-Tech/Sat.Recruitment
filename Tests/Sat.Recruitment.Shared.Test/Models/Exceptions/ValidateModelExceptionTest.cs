using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sat.Recruitment.Shared.Models.Exceptions;

namespace Sat.Recruitment.Shared.Test.Models.Exceptions
{
    public class ValidateModelExceptionTest
    {
        [Fact]
        public void Test_Constructor_Should_Be_Initialized()
        {
            var validateModelException = new ValidateModelException();

            Assert.NotNull(validateModelException);

            Assert.NotNull(validateModelException.Errors);

            Assert.IsType<ValidateModelException>(validateModelException);
        }

        [Fact]
        public void Test_Constructor_Should_Be_Initialized_WithParameters()
        {
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("1", "Error test");

            var validateModelException = new ValidateModelException(modelState);

            Assert.NotNull(validateModelException);

            Assert.NotNull(validateModelException.Errors);

            Assert.True(validateModelException.Errors.Count == 1);

            Assert.IsType<ValidateModelException>(validateModelException);
        }
    }
}
