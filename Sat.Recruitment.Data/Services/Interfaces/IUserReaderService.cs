using Sat.Recruitment.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Services
{
    public interface IUserReaderService
    {
        Task<List<User>> GetAllAsync();
    }
}