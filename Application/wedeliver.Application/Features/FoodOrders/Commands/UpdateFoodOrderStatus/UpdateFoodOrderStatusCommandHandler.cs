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
using wedeliver.Application.Exceptions;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.FoodOrders.Commands.UpdateFoodOrderStatus
{
    public class UpdateFoodOrderStatusCommandHandler : IRequestHandler<UpdateFoodOrderStatusCommand, Unit>
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IApplicationDbContext _context;
        private readonly IFoodOrderDetailsRepository _foodOrderDetailsRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFoodOrderStatusCommandHandler> _logger;
        private readonly IOrderStatusService _orderStatusService;

        public UpdateFoodOrderStatusCommandHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<UpdateFoodOrderStatusCommandHandler> logger,
             IApplicationDbContext applicationDbContext,
        IFoodOrderDetailsRepository foodOrderDetailsRepository, IOrderStatusService orderStatusService)


        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;
            _context = applicationDbContext;
            _orderStatusService = orderStatusService;

        }
        public async Task<Unit> Handle(UpdateFoodOrderStatusCommand request, CancellationToken cancellationToken)
        {
          // var order = await _context.FoodOrder.Where(item => item.Id == request.OrderId).FirstOrDefaultAsync();
           
           if(request.RestaurantId != null)
            {
               return await _orderStatusService.updateOrderStatusFromRestaurant(request);
            }

           else if(request.RiderId != null)
            {
                return await _orderStatusService.updateOrderStatusFromRider(request);
            }
           

            return await Task.FromResult(Unit.Value);

        }


        

           

    }


}
