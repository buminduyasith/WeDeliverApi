using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder
{
    public class CreateFoodOrderCommandValidator: AbstractValidator<CreateFoodOrderCommand>
    {
        public CreateFoodOrderCommandValidator()
        {
            RuleForEach(x => x.ItemList).ChildRules(item =>
            {
                item.RuleFor(x => x.FoodId).NotEmpty().GreaterThan(0).WithMessage("food id required");
                item.RuleFor(x => x.Qty).GreaterThan(0).WithMessage("item count required");
            });

            RuleFor(x => x.ClientID)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(x => x.RestaurantId)
                .NotEmpty().NotNull().WithMessage("{PropertyName} is required");


            RuleFor(x => x.ShippingDetails.Name)
            .NotEmpty().NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ShippingDetails.PhoneNumber)
           .NotEmpty().NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ShippingDetails.HouseNo)
           .NotEmpty().NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ShippingDetails.Province)
               .NotEmpty().NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ShippingDetails.District)
              .NotEmpty().NotNull().WithMessage("{PropertyName} is required");

           
        }
    }
}
