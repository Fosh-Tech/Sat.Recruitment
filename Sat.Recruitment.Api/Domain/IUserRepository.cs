using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Domain
{
    /// <summary>
    /// Defines operations to operate with persisted users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Persist the specified user into the repository.
        /// </summary>
        /// <param name="user">The user to be added.</param>
        /// <returns>The insertion promise.</returns>
        /// <exception cref="UserAlreadyExistException">Thrown if the user is already persisted.</exception>
        ValueTask Insert(User user);
    }
}
