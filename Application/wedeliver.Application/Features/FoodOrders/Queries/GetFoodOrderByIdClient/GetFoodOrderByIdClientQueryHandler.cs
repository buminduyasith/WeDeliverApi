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

namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderByIdClient
{
    public class GetFoodOrderByIdClientQueryHandler : IRequestHandler<GetFoodOrderByIdClientQuery, FoodOrderVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFoodOrderByIdClientQueryHandler> _logger;

        public GetFoodOrderByIdClientQueryHandler(IMapper mapper,
            ILogger<GetFoodOrderByIdClientQueryHandler> logger,
            IApplicationDbContext context)
        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;

        }

        public async Task<FoodOrderVM> Handle(GetFoodOrderByIdClientQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<FoodOrder, bool>> predicate = o => o.ClientID == request.ClientId && o.Id == request.OrderId ;

            var orders = await GetFoodOrder(predicate);
            var foodOrderDTO = _mapper.Map<FoodOrderVM>(orders);
            return foodOrderDTO;
        }

        public async Task<FoodOrder> GetFoodOrder(Expression<Func<FoodOrder, bool>> predicate)
        {
            var query = _context.FoodOrder.Where(predicate);

            await query.Include(x => x.Client)
                .ThenInclude(x => x.Location)
                .LoadAsync();
            await query.Include(x => x.Restaurant).LoadAsync();
            await query.Include(x => x.ItemList)
                .ThenInclude(x => x.Food)
                .LoadAsync();



            return await query.FirstOrDefaultAsync();
        }
    }
}
