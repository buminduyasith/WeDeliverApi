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
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.MedicineOrders.Commands.UpdateMedicineOrderStatus
{
    public class UpdateMedicineOrderStatusCommand : IRequest
    {
        public int? PharmacyId { get; set; }
        public int OrderId { get; set; }
        public int? ClientId { get; set; }
        public int? RiderId { get; set; }
        public MedicineOrderStatus Status { get; set; }

    }

    public class UpdateFoodOrderStatusCommandHandler : IRequestHandler<UpdateMedicineOrderStatusCommand, Unit>
    {
      
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFoodOrderStatusCommandHandler> _logger;
        private readonly IMedicineOrderStatusService _orderStatusService;

        public UpdateFoodOrderStatusCommandHandler(IMedicineOrderStatusService orderStatusService,
             IMapper mapper, ILogger<UpdateFoodOrderStatusCommandHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _orderStatusService = orderStatusService;
        }

       
        public async Task<Unit> Handle(UpdateMedicineOrderStatusCommand request, CancellationToken cancellationToken)
        {
           

            if (request.PharmacyId != null)
            {
                return await _orderStatusService.updateOrderStatusFromPharmacy(request);
            }

            else if (request.RiderId != null)
            {
                return await _orderStatusService.updateOrderStatusFromRider(request);
            }

            else if(request.ClientId != null)
            {
                return await _orderStatusService.updateOrderStatusFromClient(request);
            }


            return await Task.FromResult(Unit.Value);

        }






    }

}
