using FluentValidation;
using Forum.Entities;
using Forum.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace Forum.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(ForumDbContext _context)
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.UserName)
                .Custom((value, context) =>
                {
                   var userNameInUse = _context.Users.Any(u => u.UserName == value);
                    if(userNameInUse)
                    {
                        context.AddFailure("UserName", "That userName is taken"); 
                    }
                });
           
        }
    }
}
