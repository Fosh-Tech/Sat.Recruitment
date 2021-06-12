namespace Sat.Recruitment.Api.Domain
{
    /// <summary>
    /// Defines promotion rules to apply to an user's money if proceed.
    /// </summary>
    public interface IPromotion
    {
        /// <summary>
        /// Applies the promotion to the user.
        /// </summary>
        /// <param name="user">The user to check whether this discount applies to.</param>
        /// <returns>The user with the discount applied.</returns>
        User Apply(User user);
    }
}
