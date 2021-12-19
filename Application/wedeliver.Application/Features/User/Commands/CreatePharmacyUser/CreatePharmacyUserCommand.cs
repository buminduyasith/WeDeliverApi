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
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.User.Commands.CreatePharmacyUser
{
    public class CreatePharmacyUserCommand:IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string? Discription { get; set; }
        public string TelphoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string No { get; set; }
        public Provinces ProvinceId { get; set; }
        public Districts DistrictsId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }

    public class CreatePharmacyUserCommandHandler : IRequestHandler<CreatePharmacyUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePharmacyUserCommandHandler> _logger;

        public CreatePharmacyUserCommandHandler(IUserRepository userRepository,

            IMapper mapper, ILogger<CreatePharmacyUserCommandHandler> logger)

        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(CreatePharmacyUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreatePharmacyUser(request);

            return await Task.FromResult(Unit.Value);
        }
    }
}
