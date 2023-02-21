using FluentValidation;
using Sat.Recruitment.Application.Data;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Users.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IMyDataSource _myDataSource;

        public CreateUserCommandValidator(IMyDataSource myDataSource)
        {
            _myDataSource = myDataSource;

            RuleFor(x => x.CreateUserRequest.Name)
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
                .MustAsync(BeUniqueByNameAsync).WithMessage("The specified Name already exists.")
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.CreateUserRequest.Email)
                .MaximumLength(200).WithMessage("Email must not exceed 200 characters.")
                .MustAsync(BeUniqueByEmailAsync).WithMessage("The specified Email already exists.")
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(x => x.CreateUserRequest.Address)
                .NotEmpty()
                .NotNull().WithMessage("Address is required.");

            RuleFor(x => x.CreateUserRequest.Phone)
                .NotEmpty()
                .NotNull().WithMessage("Phone is required.");

            RuleFor(x => x.CreateUserRequest.UserType)
                .Must(BeValidEnum).WithMessage("Invalid value for UserType.")
                .NotNull().WithMessage("UserType is required.");
        }

        internal async Task<bool> BeUniqueByNameAsync(string name, CancellationToken cancellationToken) =>
            !(await _myDataSource.GetAllUsersAsync()).Any(x => x.Name == name);

        internal async Task<bool> BeUniqueByEmailAsync(string email, CancellationToken cancellationToken) =>
            !(await _myDataSource.GetAllUsersAsync()).Any(x => x.Email == email);

        internal bool BeValidEnum(UserTypeEnum userType)
        {
            try
            {
                if (int.TryParse(userType.ToString(), out int a))
                    return false;

                if (!Enum.TryParse<UserTypeEnum>(userType.ToString(), out UserTypeEnum b))
                    return false;
            }
            catch { return false; }

            return true;
        }
    }
}
