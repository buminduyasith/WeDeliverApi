using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;

namespace wedeliver.Application.Features.User.Commands.CreateRiderUser
{
    public class CreateRestaurantUserCommandValidator:AbstractValidator<CreateRestaurantUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateRestaurantUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MustAsync(IsUniqueUserName).WithMessage("{PropertyName} already exists.");



            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("price is required")
                .Must(ValidatePassword).WithMessage("not valid password");
                

        }


        private async Task<bool> IsUniqueUserName(string email, CancellationToken cancellationToken)
        {
            var userObject = await _userRepository.FindByEmailAsync(email);
            if (userObject != null)
            {
                return false;
            }
            return true;
        }

        private bool ValidatePassword(string password)
        {
            var input = password;
            

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
           // var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
               
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                
                return false;
            }

           
            else
            {
                return true;
            }
        }
    }
}
