using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Data
{
    public interface IMyDataSource
    {
        Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);
        Task<IQueryable<User>> GetAllUsersAsync();
    }
}
