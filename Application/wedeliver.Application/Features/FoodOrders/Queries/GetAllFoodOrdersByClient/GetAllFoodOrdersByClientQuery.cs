using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.ViewModels;

namespace wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrdersByClient
{
    public class GetAllFoodOrdersByClientQuery :IRequest<IEnumerable<FoodOrderVM>>
    {
        public int ClientId { get; set; }
}
}
