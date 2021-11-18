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
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrdersAvailableForRiders
{
    public class GetAllFoodOrdersAvailableForRidersQuery:IRequest<IEnumerable<FoodOrderVM>>
    {

    }

    public class GetAllFoodOrdersAvailableForRidersQueryHandler : IRequestHandler<GetAllFoodOrdersAvailableForRidersQuery, IEnumerable<FoodOrderVM>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        private readonly IOrderStatusService _orderStatusService;

        private readonly ILogger<GetAllFoodOrdersAvailableForRidersQueryHandler> _logger;

        public GetAllFoodOrdersAvailableForRidersQueryHandler(IMapper mapper, ILogger<GetAllFoodOrdersAvailableForRidersQueryHandler> logger,
            IApplicationDbContext context, IOrderStatusService orderStatusService)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
            _orderStatusService = orderStatusService;


        }
     
        public async Task<IEnumerable<FoodOrderVM>> Handle(GetAllFoodOrdersAvailableForRidersQuery request, CancellationToken cancellationToken)
        {

            return  await _orderStatusService.GetAllAvailableOrdersForRider();
           
        }

    }
}
