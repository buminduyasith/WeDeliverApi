using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;

namespace wedeliver.Application.Features.User.Commands.CreateRiderUser
{
    public class CreateRiderUserCommandHandler : IRequestHandler<CreateRiderUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRiderUserCommandHandler> _logger;

        public CreateRiderUserCommandHandler(IUserRepository userRepository,

            IMapper mapper, ILogger<CreateRiderUserCommandHandler> logger)

        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(CreateRiderUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateRiderrUser(request);

            return await Task.FromResult(Unit.Value);
        }
    }
}
