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
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.MedicineOrders.Commands.CreateMedicineOrder
{
    public class CreateMedicineOrderCommand:IRequest<Boolean>
    {
        public string? MedsItemIntext { get; set; }
        public string? PrescriptionUrl { get; set; }
        public int ClientID { get; set; }
        public string Note { get; set; }
        public ShippingDetailsVM ShippingDetails { get; set; }
    }

    public class CreateMedicineOrderCommandHandler : IRequestHandler<CreateMedicineOrderCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        private readonly IMapper _mapper;
        private readonly ILogger<CreateMedicineOrderCommandHandler> _logger;

        public CreateMedicineOrderCommandHandler(
            IMapper mapper, ILogger<CreateMedicineOrderCommandHandler> logger,
            IApplicationDbContext context)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = context;
        }
        public async Task<bool> Handle(CreateMedicineOrderCommand request, CancellationToken cancellationToken)
        {

            var shippingDetailsModel = _mapper.Map<ShippingDetails>(request.ShippingDetails);


            var CreatedshippingDetailsModel = await _dbContext.ShippingDetails.AddAsync(shippingDetailsModel);


            var medicineOrder = new MedicineOrder
            {
                ClientID = request.ClientID,
                EstimatedDelivery = DateTime.Now.AddDays(1),
                OrderDate = DateTime.Now,
                MedicineOrderStatus = MedicineOrderStatus.Pending,
                MedsItemIntext = request.MedsItemIntext,
                PrescriptionUrl = request.PrescriptionUrl,
                Note = request.Note,
                OrderType = OrderType.CashONDelivery,
                ShippingDetails = CreatedshippingDetailsModel.Entity
            };


            await _dbContext.MedicineOrders.AddAsync(medicineOrder);

            return true;
        }
    }
}
