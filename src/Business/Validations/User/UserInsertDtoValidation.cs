using DataAccess.Consts;
using DataAccess.Dtos.User;
using FluentValidation;

namespace Business.Validations.User
{
    public class UserInsertDtoValidation : AbstractValidator<UserInsertDto>
    {
        public UserInsertDtoValidation()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username cannot be left")
                .Length(UserConsts.UserNameMinLength, UserConsts.UserNameMaxLength)
                .WithMessage($"Username must be between {UserConsts.UserNameMinLength}-{UserConsts.UserNameMaxLength} characters !");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password cannot be left")
                .Length(UserConsts.PasswordMinLength, UserConsts.PasswordMaxLength)
                .WithMessage($"Your password name must be between {UserConsts.PasswordMinLength}-{UserConsts.PasswordMaxLength} characters !")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one capital letter !")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter !")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one digit !");
        }
    }
}
