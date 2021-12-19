using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Features.User.ViewModels;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.User.Commands.CreateAdminUser
{
    //public class CreateRestaurantUserCommand : IRequest<IdentityUser>
    public class CreateAdminUserCommand:IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class CreateAdminUserCommandHandler : IRequestHandler<CreateAdminUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAdminUserCommandHandler> _logger;

        public CreateAdminUserCommandHandler(IUserRepository userRepository,

            IMapper mapper, ILogger<CreateAdminUserCommandHandler> logger)

        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(CreateAdminUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateAdminUser(request);
          
            return await Task.FromResult(Unit.Value);
        }
    }
}
