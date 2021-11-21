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
using wedeliver.Application.ViewModels;
using wedeliver.Domain;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodItem
{
    public class AddFoodItemCommandHandler : IRequestHandler<AddFoodItemCommand, FoodVM>

    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddFoodItemCommandHandler> _logger;
        public AddFoodItemCommandHandler(IFoodRepository foodRepository, IMapper mapper, ILogger<AddFoodItemCommandHandler> logger)
        
        {
            _foodRepository = foodRepository ?? throw new ArgumentNullException(nameof(foodRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           
        }

        public async Task<FoodVM> Handle(AddFoodItemCommand request, CancellationToken cancellationToken)
        {
            var fooditem = _mapper.Map<Food>(request);
            var item =  await _foodRepository.AddAsync(fooditem);
            var response = _mapper.Map<FoodVM>(item);
            return response;
           

        }
    }
}
