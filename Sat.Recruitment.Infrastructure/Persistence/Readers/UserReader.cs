using Sat.Recruitment.Application.Common.Interfaces.Readers;
using Sat.Recruitment.Domain.Users;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Persistence.Readers
{
    public class UserReader : IUserReader
    {
        private readonly string Path;

        public UserReader (string path)
        {
            this.Path = path;
        }

        public async Task<List<User>> ReadUsersFromFileAsync()
        {
            var streamReader = this.GetStreamReader(this.Path);

            var users = new List<User>();

            while (streamReader.Peek() >= 0)
            {
                var line = await streamReader.ReadLineAsync();

                users.Add(this.GetUserFromLine(line));
            }

            streamReader.Close();

            return users;
        }

        private StreamReader GetStreamReader(string path)
        {
            var fileStream = new FileStream(path, FileMode.Open);

            return new StreamReader(fileStream);
        }

        private User GetUserFromLine(string line)
        {
            var splittedLine = line.Split(',');

            var user = new User
            {
                Name = splittedLine[0],
                Email = splittedLine[1],
                Phone = splittedLine[2],
                Address = splittedLine[3],
                UserType = splittedLine[4],
                Money = decimal.Parse(splittedLine[5]),
            };

            return user;
        }
    }
}
