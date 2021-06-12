using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Model.Validators
{
    /// <summary>
    /// Checks whether a string property of an user is not null.
    /// </summary>
    internal sealed class StringNotNullValidationRule : IValidationRule
    {
        private readonly Func<User, string?> getValue;

        private readonly string errorMessage;

        /// <summary>
        /// Creates a new instance of <see cref="StringNotNullValidationRule"/>.
        /// </summary>
        /// <param name="accessor">The expression used to extract the string value to be validated.</param>
        /// <param name="errorMessage">The message to be sent if value were null.</param>
        public StringNotNullValidationRule(Func<User, string?> accessor, string errorMessage)
        {
            this.getValue = accessor;
            this.errorMessage = errorMessage;
        }

        /// <inheritdoc />
        public IEnumerable<string> Validate(User user)
        {
            if (string.IsNullOrEmpty(this.getValue(user)))
            {
                yield return this.errorMessage;
            }
        }

    }
}
