using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Api.Model.Validators
{
    /// <summary>
    /// Defines a validation rule that is composed of other rules.
    /// </summary>
    internal sealed class CompositeValidationRule : IValidationRule, IEnumerable<IValidationRule>
    {
        private readonly List<IValidationRule> rules = new List<IValidationRule>();

        /// <summary>
        /// Adds the specified validation rule to the current composition.
        /// </summary>
        /// <param name="rule">The validation rule to be added.</param>
        /// <returns>The modified composition (because functional rocks!).</returns>
        public CompositeValidationRule Add(IValidationRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException(nameof(rule));
            }

            this.rules.Add(rule);
            return this;
        }

        /// <inheritdoc />
        public IEnumerator<IValidationRule> GetEnumerator() => this.rules.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc />
        public IEnumerable<string> Validate(User user) => this.rules.SelectMany(r => r.Validate(user));
    }
}
