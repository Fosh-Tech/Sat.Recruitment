using System.IO;

namespace Sat.Recruitment.Api.Domain.Repositories
{
    internal static class Default
    {
        public static IUserRepository Create() => new UserFileRepository(RepositoryPath);

        private static string RepositoryPath
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Files/Users.txt");
            }
        }
    }
}
