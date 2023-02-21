

using FluentValidation.Results;
using Sat.Recruitment.Shared.Models.Exceptions;

namespace Sat.Recruitment.Shared.Test.Models.Exceptions
{
    public class ValidationExceptionTest
    {
        [Fact]
        public void Test_Constructor_Should_Be_Initialized()
        {
            var validateException = new ValidationException();

            Assert.NotNull(validateException);

            Assert.NotNull(validateException.Errors);

            Assert.IsType<ValidationException>(validateException);
        }

        [Fact]
        public void Test_Constructor_Should_Be_Initialized_WithParameters()
        {
            var validatios = new List<ValidationFailure>();
            validatios.Add(new ValidationFailure("1", "Error test"));

            var ValidationException = new ValidationException(validatios);

            Assert.NotNull(ValidationException);

            Assert.NotNull(ValidationException.Errors);

            Assert.True(ValidationException.Errors.Count() == 1);

            Assert.IsType<ValidationException>(ValidationException);
        }
    }
}
