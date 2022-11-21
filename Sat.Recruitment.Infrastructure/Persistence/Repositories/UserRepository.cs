using AutoMapper;
using Sat.Recruitment.Application.Common.Interfaces.Readers;
using Sat.Recruitment.Application.Common.Interfaces.Repositories;
using Sat.Recruitment.Application.Common.ViewModels;
using Sat.Recruitment.Domain.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserReader userReader;
        private readonly IMapper mapper;

        public UserRepository(IUserReader userReader, IMapper mapper)
        {
            this.userReader = userReader;
            this.mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            return (await this.userReader.ReadUsersFromFileAsync())
                .Select(t => mapper.Map<User, UserViewModel>(t))
                .ToList();
        }
    }
}