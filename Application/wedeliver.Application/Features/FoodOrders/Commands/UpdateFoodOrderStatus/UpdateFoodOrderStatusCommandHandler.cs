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

        public UpdateFoodOrderStatusCommandHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<UpdateFoodOrderStatusCommandHandler> logger,
             IApplicationDbContext applicationDbContext,
        IFoodOrderDetailsRepository foodOrderDetailsRepository)


        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;
            _context = applicationDbContext;

        }
        public async Task<Unit> Handle(UpdateFoodOrderStatusCommand request, CancellationToken cancellationToken)
        {
          // var order = await _context.FoodOrder.Where(item => item.Id == request.OrderId).FirstOrDefaultAsync();
           
          

            Expression<Func<FoodOrder, bool>> predicate = o => o.Id == request.OrderId && o.RestaurantId==request.RestaurantId;

            var FoodOrderResult = await GetWorkItem(predicate);

            if (FoodOrderResult is null)
            {
                throw new NotFoundException("order not found", FoodOrderResult);
            }

            _logger.LogInformation("UpdateFoodOrderStatusCommand", FoodOrderResult.ToString());


            return await Task.FromResult(Unit.Value);

        }


        public async Task<FoodOrder> GetWorkItem(Expression<Func<FoodOrder, bool>> predicate)
        {
            var query = _context.FoodOrder.Where(predicate);

            await query.Include(x => x.Restaurant)
                        .LoadAsync();
            await query.Include(x => x.Client)
                        .LoadAsync();

            await query.Include(x => x.ItemList)
                       .LoadAsync();

            return await query.FirstOrDefaultAsync();
        }

    }


}
