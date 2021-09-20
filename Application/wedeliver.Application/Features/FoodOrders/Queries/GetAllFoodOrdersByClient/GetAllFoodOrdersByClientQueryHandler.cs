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
using wedeliver.Domain.Entities;
using wedeliver.Application.Features.FoodOrders.ViewModels;

namespace wedeliver.Application.Features.FoodOrders.Queries.GetAllFoodOrdersByClient
{
    public class GetAllFoodOrdersByClientQueryHandler : IRequestHandler<GetAllFoodOrdersByClientQuery, IEnumerable<FoodOrderVM>>
    {
     
        private readonly IApplicationDbContext _context;
      
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllFoodOrdersByClientQueryHandler> _logger;

        public GetAllFoodOrdersByClientQueryHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<GetAllFoodOrdersByClientQueryHandler> logger,
            IApplicationDbContext context,
        IFoodOrderDetailsRepository foodOrderDetailsRepository)


        {
          
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
           

        }

        public async Task<IEnumerable<FoodOrderVM>> Handle(GetAllFoodOrdersByClientQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FoodOrder, bool>> predicate = o => o.ClientID == request.ClientId;
            var orders = await GetFoodOrder(predicate);
            var foodOrderDTO = _mapper.Map<IEnumerable<FoodOrderVM>>(orders);
            return foodOrderDTO;
        }

        public async Task<IEnumerable<FoodOrder>> GetFoodOrder(Expression<Func<FoodOrder, bool>> predicate)
        {
            var query = _context.FoodOrder.Where(predicate);


            await query.Include(x => x.Client)
                .ThenInclude(x => x.Location)
                .LoadAsync();
            await query.Include(x => x.Restaurant).LoadAsync();
            await query.Include(x => x.ItemList)
                .ThenInclude(x => x.Food)
                .LoadAsync();



            return await query.ToListAsync();
        }
    }
}
