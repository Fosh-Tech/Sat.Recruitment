using Sat.Recruitment.Dto.Dtos;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
    public interface IUserService
    {
        Task<ResultDto> CreateAsync(UserDto dto);
    }
}