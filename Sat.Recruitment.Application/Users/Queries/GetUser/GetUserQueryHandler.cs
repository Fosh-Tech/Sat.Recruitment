using Mapster;
using MapsterMapper;
using Sat.Recruitment.Application.Data;
using Sat.Recruitment.Application.Models.DTOs;
using Sat.Recruitment.Shared.MediatR.Extensions;
using Sat.Recruitment.Shared.Models.ResponseWrappers;

namespace Sat.Recruitment.Application.Users.Queries.GetUser
{
    internal class GetUserQueryHandler : IRequestHandlerWrapper<GetUserQuery, UserDTO>
    {
        private readonly IMyDataSource _myDataSource;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IMyDataSource myDataSource, IMapper mapper)
        {
            _myDataSource = myDataSource;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserDTO>> Handle(GetUserQuery getUserQuery, CancellationToken cancellationToken)
        {
            var result = (await _myDataSource.GetAllUsersAsync()).
                FirstOrDefault(x => x.Name == getUserQuery.UserName);

            return result == default ? ServiceResult.Failed<UserDTO>(ServiceError.NotFound) : ServiceResult.Success(result.Adapt<UserDTO>());
        }
    }
}
