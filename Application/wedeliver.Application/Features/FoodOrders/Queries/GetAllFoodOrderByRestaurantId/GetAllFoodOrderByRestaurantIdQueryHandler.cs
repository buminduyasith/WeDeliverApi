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

namespace wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrderByRestaurantId
{
    public class GetAllFoodOrderByRestaurantIdQueryHandler : IRequestHandler<GetAllFoodOrderByRestaurantIdQuery, IEnumerable<FoodOrderRestaurantVM>>
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IFoodOrderDetailsRepository _foodOrderDetailsRepository;
        private readonly IApplicationDbContext _context;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllFoodOrderByRestaurantIdQueryHandler> _logger;

        public GetAllFoodOrderByRestaurantIdQueryHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<GetAllFoodOrderByRestaurantIdQueryHandler> logger,
            IApplicationDbContext context,
        IFoodOrderDetailsRepository foodOrderDetailsRepository)


        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;

        }

        public async Task<IEnumerable<FoodOrderRestaurantVM>> Handle(GetAllFoodOrderByRestaurantIdQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<FoodOrder, bool>> predicate = o => o.RestaurantId == request.RestaurantId ;


            var orders =await GetFoodOrder(predicate);
            var foodOrderDTO = _mapper.Map<IEnumerable<FoodOrderRestaurantVM>>(orders);
            return foodOrderDTO;
        }

        public async Task<IEnumerable<FoodOrder>> GetFoodOrder(Expression<Func<FoodOrder, bool>> predicate)
        {
            var query = _context.FoodOrder.Where(predicate);

            //await query.Include(x => x.ApplicationForm)
            //   .ThenInclude(o => o.ApplicationReturn)
            //           .LoadAsync();
            //await query.Include(x => x.WorkItemActions)
            // .ThenInclude(x => x.WorkItemActionReasons)
            // .ThenInclude(x => x.Reason)
            //         .LoadAsync();

            //return await query.ToListAsync();

            await query.Include(x => x.Client)
                .ThenInclude(x=>x.Location)
                .LoadAsync();
            await query.Include(x => x.Restaurant).LoadAsync();
            await query.Include(x => x.ItemList)
                .ThenInclude(x => x.Food)
                .LoadAsync();
                
               

            return await query.ToListAsync();
        }
    }
}
