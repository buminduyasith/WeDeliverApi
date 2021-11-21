using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Features.FoodOrders.ViewModels;

namespace wedeliver.Application.Features.FoodOrders.Commands.RiderAcceptOrder
{
    public class RiderAcceptOrderCommandHandler : IRequestHandler<RiderAcceptOrderCommand, Boolean>
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IFoodOrderDetailsRepository _foodOrderDetailsRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RiderAcceptOrderCommandHandler> _logger;
        private readonly IApplicationDbContext _context;
        private readonly IOrderStatusService _orderStatusService;

        public RiderAcceptOrderCommandHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<RiderAcceptOrderCommandHandler> logger,IApplicationDbContext context,
            IOrderStatusService orderStatusService,
            IFoodOrderDetailsRepository foodOrderDetailsRepository)


        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;
            _context = context;
            _orderStatusService = orderStatusService;


        }

        public async Task<Boolean> Handle(RiderAcceptOrderCommand request, CancellationToken cancellationToken)
        {
            return await  _orderStatusService.RiderOrderAcceptToDeliver(request);
        }
    }
}
