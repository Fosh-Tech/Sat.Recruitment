using Mapster;
using MapsterMapper;
using Sat.Recruitment.Application.Data;
using Sat.Recruitment.Application.Models.DTOs;
using Sat.Recruitment.Shared.MediatR.Extensions;
using Sat.Recruitment.Shared.Models.ResponseWrappers;

namespace Sat.Recruitment.Application.Users.Queries.GetAllUsers
{
    internal class GetAllUsersQueryHandler : IRequestHandlerWrapper<GetAllUsersQuery, List<UserDTO>>
    {
        private readonly IMyDataSource _myDataSource;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IMyDataSource myDataSource, IMapper mapper)
        {
            _myDataSource = myDataSource;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<UserDTO>>> Handle(GetAllUsersQuery getAllUsersQuery, CancellationToken cancellationToken)
        {
            var result = (await _myDataSource.GetAllUsersAsync())
            .ProjectToType<UserDTO>(_mapper.Config)
            .ToList();

            return ServiceResult.Success(result);
        }
    }
}
