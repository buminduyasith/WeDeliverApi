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

namespace wedeliver.Application.Features.User.Commands.CreateCustomerUser
{
    public class CreateCustomerUserCommandHandler : IRequestHandler<CreateCustomerUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerUserCommandHandler> _logger;
        public CreateCustomerUserCommandHandler(IUserRepository userRepository,

         IMapper mapper, ILogger<CreateCustomerUserCommandHandler> logger)

        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CreateCustomerUserCommand request, CancellationToken cancellationToken)
        {
            await  _userRepository.CreateCustomerUser(request);
            return true;
            //return await Task.FromResult(Unit.Value);
        }
    }
}
