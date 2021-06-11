using System.Collections.Generic;

using FluentAssertions;

using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Validators;

using Xunit;

namespace Sat.Recruitment.Test.Model.Validators
{
    public class StringNotNullValidationRuleTests
    {
        [Fact]
        public void GivenAnyUser_whenValueIsNotNull_EmptyExpected()
        {
            var user = new User
            {
                Name = "OK"
            };
            var sut = new StringNotNullValidationRule(x => x.Name, "SHOULD NOT HAPPEN");

            IEnumerable<string> errors = sut.Validate(user);

            errors.Should().BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GivenAnyUser_whenValueIsNullOrEmpty_ErrorExpected(string name)
        {
            const string Error = "SHOULD HAPPEN";
            var user = new User
            {
                Name = name
            };
            var sut = new StringNotNullValidationRule(x => x.Name, Error);

            IEnumerable<string> errors = sut.Validate(user);

            errors.Should().ContainSingle(Error);
        }
    }
}
