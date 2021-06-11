using System.Collections.Generic;

namespace Sat.Recruitment.Api.Model
{
    /// <summary>
    /// Defines a validation rule strategy to be applied to an incoming user.
    /// </summary>
    public interface IValidationRule
    {
        /// <summary>
        /// Validate the specified used applying the current rule strategy.
        /// </summary>
        /// <param name="user">The user to be validated.</param>
        /// <returns>A sequence of error messages or empty if valid user.</returns>
        IEnumerable<string> Validate(User user);
    }
}
