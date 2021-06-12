using System.Collections;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Domain.Promotions
{
    /// <summary>
    /// Defines operations to create a complex promotion composition.
    /// </summary>
    internal sealed class CompositePromotion : IPromotion, IEnumerable<IPromotion>
    {
        private readonly List<IPromotion> promotions = new List<IPromotion>();

        /// <inheritdoc />
        public User Apply(User user)
        {
            User current = user;
            for (int i = 0, n = this.promotions.Count; i < n; i++)
            {
                current = this.promotions[i].Apply(current);
            }

            return current;
        }

        /// <summary>
        /// Adds the specified promotion to the current composition.
        /// </summary>
        /// <param name="promotion">The promotion to be added.</param>
        /// <returns>The modified promotion composition.</returns>
        public CompositePromotion Add(IPromotion promotion)
        {
            this.promotions.Add(promotion);
            return this;
        }

        /// <inheritdoc />
        public IEnumerator<IPromotion> GetEnumerator() => this.promotions.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
