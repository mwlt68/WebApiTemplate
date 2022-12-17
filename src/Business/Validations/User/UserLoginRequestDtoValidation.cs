using DataAccess.Dtos.User;
using FluentValidation;

namespace Business.Validations.User
{
    public class UserLoginRequestDtoValidation : AbstractValidator<UserLoginRequestDto>
    {
        public UserLoginRequestDtoValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .WithMessage("Username cannot be left !");
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password cannot be left !");
        }
    }
}
