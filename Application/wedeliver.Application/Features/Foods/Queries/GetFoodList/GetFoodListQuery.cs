using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;


namespace wedeliver.Application.Features.Foods.Queries.GetFoodList
{
    public class GetFoodListQuery:IRequest<List<FoodVM>>
    {
        //public int Id { get; set; }

        //public GetFoodListQuery(int Id)
        //{
        //    this.Id = Id;
        //}
    }
}
