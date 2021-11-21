using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.ViewModels;

namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByIdClient
{
    public class GetFoodOrderByIdClientQuery : IRequest<FoodOrderVM>
    {
        public int ClientId { get; set; }
        public int OrderId { get; set; }
       
    }
}
