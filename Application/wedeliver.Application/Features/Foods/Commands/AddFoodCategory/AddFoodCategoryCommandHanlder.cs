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
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodCategory
{
    public class AddFoodCategoryCommandHanlder : IRequestHandler<AddFoodCategoryCommand, FoodCategoryVM>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AddFoodCategoryCommandHanlder> _logger;
        private readonly IApplicationDbContext _dbContext;
        public AddFoodCategoryCommandHanlder(IMapper mapper, ILogger<AddFoodCategoryCommandHanlder> 
            logger,IApplicationDbContext dbContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = dbContext;

        }
        public async Task<FoodCategoryVM> Handle(AddFoodCategoryCommand request, CancellationToken cancellationToken)
        {

            var foodCategory = _mapper.Map<FoodCategory>(request);
            var createNewFoodCategory = await _dbContext.FoodCategory.AddAsync(foodCategory);
            await _dbContext.SaveChangesAsync();
            var foodCategoryVM = _mapper.Map<FoodCategoryVM>(createNewFoodCategory);
            return foodCategoryVM;
  
        }
    }
}
