using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wedeliver.Application.Contracts.Persisternce;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodItem
{
    public class AddFoodItemCommandValidator:AbstractValidator<AddFoodItemCommand>
    {
        private readonly IApplicationDbContext _dbContext;
     
        public AddFoodItemCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("please name is required")
                .NotNull()
                .MaximumLength(100).WithMessage("name should have less than 100 characters");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("price is required")
                .GreaterThan(10);

            RuleFor(p => p.ImageUrl)
              .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.Discription)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.FoodCategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.RestaurantId)
                .NotEmpty().WithMessage("Restaurant Id is required")
                .MustAsync(ISRestaurantAvailable).WithMessage("{PropertyName} not exists.");

        }

        private async Task<bool> ISRestaurantAvailable(int RestaurantId, CancellationToken cancellationToken)
        {
            var restaurant = await _dbContext.Restaurants.Where(p => p.Id == RestaurantId).FirstOrDefaultAsync();

            if (restaurant != null)
            {
                return true;
            }
            return false;
        }
    }
}
