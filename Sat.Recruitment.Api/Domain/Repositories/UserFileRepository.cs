using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Domain.Repositories
{
    internal sealed class UserFileRepository : IUserRepository
    {
        private readonly SemaphoreSlim gate = new SemaphoreSlim(1, 1);

        private readonly string path;

        /// <summary>
        /// Creates a new instance of <see cref="UserFileRepository"/>.
        /// </summary>
        /// <param name="path">The path of the file used as repository.</param>
        public UserFileRepository(string path) => this.path = path;

        /// <inheritdoc />
        public async ValueTask Insert(User user)
        {
            await (this.gate.WaitAsync());
            try
            {
                if (await this.Contains(user))
                {
                    throw new UserAlreadyExistException(user);
                }

                // TODO: Insert, but is not present on original source
            }
            finally
            {
                this.gate.Release();
            }
        }

        private static User ParseUser(string line)
        {
            string[] parts = line.Split(',');
            return new User
            {
                Name = parts[0],
                Email = parts[1],
                Phone = parts[2],
                Address = parts[3],
                UserType = parts[4],
                Money = decimal.TryParse(parts[5], out decimal money) ? money : 0m
            };
        }

        private static bool AreSame(User x, User y) => x.Email == y.Email || x.Phone == y.Phone || (x.Name == y.Name && x.Address == y.Address);

        private async Task<bool> Contains(User user)
        {
            await foreach (User existing in this.ReadUsers())
            {
                if (AreSame(user, existing))
                {
                    return true;
                }
            }

            return false;
        }

        private async IAsyncEnumerable<User> ReadUsers()
        {
            using var fileStream = new FileStream(this.path, FileMode.Open);
            using var reader = new StreamReader(fileStream, leaveOpen: true);
            while (!reader.EndOfStream)
            {
                string? line = await reader.ReadLineAsync();
                if (line == null)
                {
                    continue;
                }

                yield return ParseUser(line);
            }
        }
    }
}
