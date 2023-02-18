using System;
using System.IO;
using Sat.Recruitment.Infrastructure;

namespace Sat.Recruitment.Test;

// Single test context shared among all the tests
// https://xunit.net/docs/shared-context

/// <remarks>
/// Best practices:
/// Try not to introduce dependencies on infrastructure when writing unit tests.
/// https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
/// </remarks>
public class DataFixture : IDisposable
{
    private readonly DataContext _data;
    public DataFixture()
    {
        Stream users = new MemoryStream();
        users.Write("Juan,Juan@marmol.com,+5491154762312,Peru 2464,Normal,1234\n"u8);
        users.Write("Franco,Franco.Perez@gmail.com,+534645213542,Alvear y Colombres,Premium,112234\n"u8);
        users.Write("Agustina,Agustina@gmail.com,+534645213542,Garay y Otra Calle,SuperUser,112234"u8);
        users.Position = 0;
        _data = new DataContext(users);
    }

    public DataContext Data => _data;

    public void Dispose() => _data.Dispose();
}