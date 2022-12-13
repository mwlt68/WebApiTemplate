using DataAccess.Consts;
using DataAccess.Dtos;
using FluentValidation;

namespace Business.Validations
{
    internal class UserInsertDtoValidation :  AbstractValidator<UserInsertDto>
    {
        public UserInsertDtoValidation()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username cannot be left")
                .Length(UserConsts.UserNameMinLength, UserConsts.UserNameMaxLength)
                .WithErrorCode($"Username must be between {UserConsts.UserNameMinLength}-{UserConsts.UserNameMaxLength} characters !");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password cannot be left")
                .Length(UserConsts.PasswordMinLength,UserConsts.PasswordMaxLength)
                .WithMessage($"Your password name must be between {UserConsts.PasswordMinLength}-{UserConsts.PasswordMaxLength} characters !")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one capital letter !")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter !")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one digit !");
        }
    }
}
