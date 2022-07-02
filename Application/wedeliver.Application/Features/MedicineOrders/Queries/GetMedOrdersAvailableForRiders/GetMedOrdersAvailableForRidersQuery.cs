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
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.MedicineOrders.Queries.GetMedOrdersAvailableForRiders
{

    public class GetMedOrdersAvailableForRidersQuery : IRequest<IEnumerable<MedicineOrderVM>>
    {
        public Districts DistrictId { get; set; }
    }

    public class GetMedOrdersAvailableForRidersQueryHandler : IRequestHandler<GetMedOrdersAvailableForRidersQuery, IEnumerable<MedicineOrderVM>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        private readonly IOrderStatusService _orderStatusService;

        private readonly ILogger _logger;

        public GetMedOrdersAvailableForRidersQueryHandler(IMapper mapper, ILogger<GetMedOrdersAvailableForRidersQueryHandler> logger,
            IApplicationDbContext context, IOrderStatusService orderStatusService)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
            _orderStatusService = orderStatusService;


        }

        public async Task<IEnumerable<MedicineOrderVM>> Handle(GetMedOrdersAvailableForRidersQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<MedicineOrder, bool>> predicate = o => o.MedicineOrderStatus == Domain.Enums.MedicineOrderStatus.ReadyToPickedUpForRider
            && o.ShippingDetails.District == request.DistrictId;



            var query = _context.MedicineOrders.Where(predicate);

            await query.Include(x => x.Client)
              .ThenInclude(x => x.Location)
              .LoadAsync();
            await query.Include(x => x.ShippingDetails).LoadAsync();
          

            var result = await query.ToListAsync();

            var foodOrderDTO = _mapper.Map<IEnumerable<MedicineOrderVM>>(result);
            return foodOrderDTO;


        }

    }
}
