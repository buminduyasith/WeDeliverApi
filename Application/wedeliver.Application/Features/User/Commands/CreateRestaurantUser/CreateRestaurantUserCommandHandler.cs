﻿using AutoMapper;
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

namespace wedeliver.Application.Features.User.Commands.CreateRestaurantUser
{
    public class CreateRestaurantUserCommandHandler : IRequestHandler<CreateRestaurantUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateRestaurantUserCommandHandler> _logger;
      
        public CreateRestaurantUserCommandHandler(IUserRepository userRepository,
           
            IMapper mapper, ILogger<CreateRestaurantUserCommandHandler> logger)

        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(CreateRestaurantUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateRestaurantUser(request);
            // var u = _mapper.Map<RestaurantUserVM>(user);
            return await Task.FromResult(Unit.Value);
        }
    }
}
