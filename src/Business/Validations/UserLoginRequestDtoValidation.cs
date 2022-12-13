using DataAccess.Dtos;
using FluentValidation;

namespace Business.Validations
{
    public class UserLoginRequestDtoValidation : AbstractValidator<UserLoginRequestDto>
    {
        public UserLoginRequestDtoValidation()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username cannot be left !");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password cannot be left !");
        }
    }
}
