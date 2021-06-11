using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NSubstitute;

using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Model.Validators;
using Sat.Recruitment.Api.Validators;

using Xunit;

namespace Sat.Recruitment.Test.Model.Validators
{
    public class CompositeValidationRuleTests
    {
        [Fact]
        public void GivenAnyUser_WhenCompositeIsEmpty_NoErrorsExpected()
        {
            var sut = new CompositeValidationRule();

            IEnumerable<string> errors = sut.Validate(new User());

            errors.Should().BeEmpty();
        }

        [Fact]
        public void GivenAnyUser_WhenCompositeContainsRules_AllAreInvoked()
        {
            var user = new User();
            IValidationRule firstRule = MockRule("FIRST");
            IValidationRule secondRule = MockRule("SECOND");
            var sut = new CompositeValidationRule { firstRule, secondRule };

            var errors = sut.Validate(user).ToArray();

            firstRule.Received().Validate(user);
            secondRule.Received().Validate(user);
            errors.Should().BeEquivalentTo("FIRST", "SECOND");
        }

        private static IValidationRule MockRule(string errorMessage)
        {
            var rule = Substitute.For<IValidationRule>();
            rule.Validate(Arg.Any<User>()).Returns(new[] { errorMessage });
            return rule;
        }
    }
}
