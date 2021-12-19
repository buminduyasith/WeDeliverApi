using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.RiderOrders.Queries
{
    public class RiderOrderQuery:IRequest<OrdersToBeDeliverdVM>
    {
        public Districts Id { get; set; }
       
    }

    public class RiderOrderQueryHandler : IRequestHandler<RiderOrderQuery, OrdersToBeDeliverdVM>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        private readonly ILogger<RiderOrderQueryHandler> _logger;

        private IOrderStatusService _orderStatusService;

        public RiderOrderQueryHandler(IMapper mapper, ILogger<RiderOrderQueryHandler> logger,
            IApplicationDbContext context, IOrderStatusService orderStatusService)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
            _orderStatusService = orderStatusService;

        }
        public async Task<OrdersToBeDeliverdVM> Handle(RiderOrderQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FoodOrder, bool>> activePredicateFoodOrder = o => o.FoodOrderStatus == Domain.Enums.FoodOrderStatus.ReadyToPickedUpForRider
                                                   && o.ShippingDetails.District == request.Id;
            Expression<Func<MedicineOrder, bool>> activePredicateMedOrder = o => o.MedicineOrderStatus == Domain.Enums.MedicineOrderStatus.ReadyToPickedUpForRider
                                                    && o.ShippingDetails.District == request.Id;

            var queryFoodOrder = _context.FoodOrder
                .Include(x => x.Client)
                .Include(x => x.Restaurant)
                .Include(x => x.ItemList)
                 .Include(x => x.ShippingDetails)
                .Where(activePredicateFoodOrder);

            var queryMedOrder = _context.MedicineOrders
                .Include(x => x.Client)
                  .Include(x => x.Pharmacy)
                    .Include(x => x.ShippingDetails)
                    .Where(activePredicateMedOrder);


            var foodOrderList = await queryFoodOrder.ToListAsync();
            var medOrderList = await queryMedOrder.ToListAsync();

            var fdto = _mapper.Map<List<FoodOrderRestaurantVM>>(foodOrderList);
            var mdto = _mapper.Map<List<MedicineOrderVM>>(medOrderList);

            //var foodOrderDTO = _mapper.Map<IEnumerable<FoodOrderRestaurantVM>>(orders);
            var ordersToBeDeliverdVM = new OrdersToBeDeliverdVM
            {
                FoodOrderDetails = fdto,
                MedicineOrders = mdto
            };

            return ordersToBeDeliverdVM;


            //testing query
            // query.OrderByDescending(x => x.Id);
            // return query;

        }
    }

}
