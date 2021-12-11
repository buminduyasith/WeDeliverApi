using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading;
using wedeliver.Application.Contracts.Persisternce;



namespace wedeliver.Application.Features.Login.Queries
{
    public class UserLoginCommand:IRequest<UserVM>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FcmToken { get; set; }

    }

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserVM>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserLoginCommandHandler> _logger;
        public UserLoginCommandHandler(IUserRepository userRepository,

         IMapper mapper, ILogger<UserLoginCommandHandler> logger)

        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UserVM> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UserLogin(request.Email, request.Password);

        }
    }

}
