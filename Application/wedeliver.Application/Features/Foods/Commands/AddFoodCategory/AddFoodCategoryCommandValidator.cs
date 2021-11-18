using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodCategory
{
    public class AddFoodCategoryCommandValidator: AbstractValidator<AddFoodCategoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public AddFoodCategoryCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .MustAsync(IsUniqueName).WithMessage("{PropertyName} already exists.");

        }

        private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
        {
            var category = await _dbContext.FoodCategory
                   .Where(b => b.Name == name)
                   .FirstOrDefaultAsync();

            if (category != null)
            {
                return false;
            }
            return true;
        }

    }
}
