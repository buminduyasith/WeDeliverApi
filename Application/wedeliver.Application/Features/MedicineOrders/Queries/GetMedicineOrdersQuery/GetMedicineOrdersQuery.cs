using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Threading;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;
using wedeliver.Application.Exceptions;

namespace wedeliver.Application.Features.MedicineOrders.Queries.GetMedicineOrdersQuery
{
    public class GetMedicineOrdersQuery:IRequest<IEnumerable<MedicineOrderVM>>
    {
        public int? PharmacyId { get; set; }
        public int? RiderId { get; set; }
        public bool FilterByStatus { get; set; }
        public Entity Entity { get; set; }
        public MedicineOrderStatus Status { get; set; }
        public Districts DistrictId { get; set; }
    }

    public class GetMedicineOrdersForPharmacyQueryQueryHandler : IRequestHandler<GetMedicineOrdersQuery, IEnumerable<MedicineOrderVM>>
    {
        private IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMedicineOrdersForPharmacyQueryQueryHandler> _logger;

        public GetMedicineOrdersForPharmacyQueryQueryHandler(
           IMapper mapper, ILogger<GetMedicineOrdersForPharmacyQueryQueryHandler> logger,
           IApplicationDbContext context)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = context;
        }
        public async Task<IEnumerable<MedicineOrderVM>> Handle(GetMedicineOrdersQuery request, CancellationToken cancellationToken)
        {

            if(request.PharmacyId !=null && request.Entity == Entity.PHARMACY) {

                var user = await _dbContext.Pharmacies.FindAsync(request.PharmacyId);

                Expression<Func<MedicineOrder, bool>> predicate = o => o.MedicineOrderStatus == request.Status
                && o.ShippingDetails.District == request.DistrictId;
                var orders = await GetMedicineOrder(predicate);
                var orderDTO = _mapper.Map<IEnumerable<MedicineOrderVM>>(orders);
                return orderDTO;
            }

            else if(request.RiderId != null && request.Entity == Entity.RIDER)
            {
                var user = await _dbContext.Riders.FindAsync(request.PharmacyId);

                Expression<Func<MedicineOrder, bool>> predicate = o => o.MedicineOrderStatus == request.Status
                  && o.ShippingDetails.District == request.DistrictId;

                var orders = await GetMedicineOrder(predicate);
                var orderDTO = _mapper.Map<IEnumerable<MedicineOrderVM>>(orders);
                return orderDTO;
            }

            throw new BadRequestException("something went wrong");





        }

        public async Task<IEnumerable<MedicineOrder>> GetMedicineOrder(Expression<Func<MedicineOrder, bool>> predicate)
        {
            var query = _dbContext.MedicineOrders.Where(predicate);

            await query.Include(x => x.Pharmacy).LoadAsync();
            await query.Include(x => x.Rider).LoadAsync();
            await query.Include(x => x.Client).LoadAsync();
            await query.Include(x => x.ShippingDetails).LoadAsync();

            return await query.ToListAsync();
        }
    }


}
