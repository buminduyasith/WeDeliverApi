using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Features.Foods.Queries.GetAllFoodCategory
{
    public class GetAllFoodCategoryQuery:IRequest<IEnumerable<FoodCategoryVM>>
    {

    }
}
