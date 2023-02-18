using Sat.Recruitment.Domain;

namespace Sat.Recruitment.Infrastructure;

public class DataContext : IDisposable
{
    private readonly Stream _users;
    private readonly Object _usersLock = new();
    public DataContext(Stream users)
    {
        _users = users;
    }

    public IEnumerable<User> GetUsers()
    {
        List<User> users = new();
        lock (_usersLock)
        {
            _users.Position = 0;
            StreamReader reader = new(_users);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()!;
                var fields = line.Split(',', StringSplitOptions.TrimEntries);
                users.Add(new User()
                {
                    Name = fields[0],
                    Email = fields[1],
                    Phone = fields[2],
                    Address = fields[3],
                    UserType = fields[4],
                    Money = decimal.Parse(fields[5])
                });
            }
        }
        return users;
    }

    public void Dispose()
    {
        _users.Dispose();
    }
}