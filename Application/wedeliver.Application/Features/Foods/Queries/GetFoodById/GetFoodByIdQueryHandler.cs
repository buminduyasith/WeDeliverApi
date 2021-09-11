
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Features.Foods.ViewModels;

namespace wedeliver.Application.Features.Foods.Queries.GetFoodById
{
    class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, FoodVM>
    {
        //private readonly IOrderRepository _orderRepository;
        //private readonly IMapper _mapper;

        //public GetFoodByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        //{
        //    _orderRepository = orderRepository;
        //    _mapper = mapper;
        //}
        //public Task<FoodVM> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        //{
            
        //}
    }
}
