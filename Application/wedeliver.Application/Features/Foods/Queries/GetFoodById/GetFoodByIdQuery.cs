using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.Foods.ViewModels;

namespace wedeliver.Application.Features.Foods.Queries.GetFoodById
{
   
    public class GetFoodByIdQuery : IRequest<FoodVM>
    {
        public int Id { get; set; }

        public GetFoodByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
