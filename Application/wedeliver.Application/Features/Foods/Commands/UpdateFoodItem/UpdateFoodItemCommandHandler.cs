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
using wedeliver.Domain;

namespace wedeliver.Application.Features.Foods.Commands.UpdateFoodItem
{
    public class UpdateFoodItemCommandHandler : IRequestHandler<UpdateFoodItemCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFoodItemCommandHandler> _logger;
        public UpdateFoodItemCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<UpdateFoodItemCommandHandler> logger)

        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Unit> Handle(UpdateFoodItemCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {

            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateFoodItemCommand), typeof(Food));
            await _orderRepository.UpdateAsync(orderToUpdate);
            return Unit.Value;

        }
    }
}
