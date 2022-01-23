using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Threading;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.FoodOrders.Queries.GetOrdersForRidersByRiderId
{
   
    public class GetAllOrdersForRiderByRiderIdQuery : IRequest<IEnumerable<FoodOrderVM>>
    {
        public int RiderId { get; set; }
        
    }

    public class GetAllOrdersForRiderByRiderIdQueryHandler : IRequestHandler<GetAllOrdersForRiderByRiderIdQuery, IEnumerable<FoodOrderVM>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        private readonly IOrderStatusService _orderStatusService;

        private readonly ILogger<GetAllOrdersForRiderByRiderIdQueryHandler> _logger;

        public GetAllOrdersForRiderByRiderIdQueryHandler(IMapper mapper, ILogger<GetAllOrdersForRiderByRiderIdQueryHandler> logger,
            IApplicationDbContext context, IOrderStatusService orderStatusService)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
            _orderStatusService = orderStatusService;


        }

        public async Task<IEnumerable<FoodOrderVM>> Handle(GetAllOrdersForRiderByRiderIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FoodOrder, bool>> predicate = o => o.FoodOrderStatus == Domain.Enums.FoodOrderStatus.RiderAccepted && o.RiderId == request.RiderId;

            var query = _context.FoodOrder.Where(predicate);

            await query.Include(x => x.Client)
              .ThenInclude(x => x.Location)
              .LoadAsync();
            await query.Include(x => x.Restaurant).LoadAsync();
            await query.Include(x => x.ItemList)
                .ThenInclude(x => x.Food)
                .LoadAsync();

            var result = await query.ToListAsync();

            var foodOrderDTO = _mapper.Map<IEnumerable<FoodOrderVM>>(result);
            return foodOrderDTO;

        }

    }
}
