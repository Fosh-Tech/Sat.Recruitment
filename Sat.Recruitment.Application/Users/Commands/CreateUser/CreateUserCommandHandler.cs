using FluentValidation;
using MapsterMapper;
using Sat.Recruitment.Application.Data;
using Sat.Recruitment.Application.Models.Responses;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Shared.MediatR.Extensions;
using Sat.Recruitment.Shared.Models.ResponseWrappers;

namespace Sat.Recruitment.Application.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, CreateUserResponse>
    {
        private readonly IMyDataSource _myDataSource;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IMyDataSource myDataSource, IMapper mapper, IValidator<CreateUserCommand> validator)
        {
            _myDataSource = myDataSource;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResult<CreateUserResponse>> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(createUserCommand, cancellationToken);

            var user = new User(
                createUserCommand.CreateUserRequest.Name,
                createUserCommand.CreateUserRequest.Email,
                createUserCommand.CreateUserRequest.Address,
                createUserCommand.CreateUserRequest.Phone,
                createUserCommand.CreateUserRequest.UserType,
                createUserCommand.CreateUserRequest.Money);

            var createUserResult = await _myDataSource.CreateUserAsync(user, cancellationToken);

            var result = ServiceResult.Success(_mapper.Map<CreateUserResponse>(createUserResult));

            return result;


        }
    }
}
