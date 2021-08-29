using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Features.Foods.Commands.UpdateFoodItem
{
    public class UpdateFoodItemCommandValidator:AbstractValidator<UpdateFoodItemCommand>
    {
        public UpdateFoodItemCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("please name is required")
                .NotNull()
                .MaximumLength(20).WithMessage("name should have less than 20 characters");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("price is required")
                .GreaterThan(10);


        }
    }
}
