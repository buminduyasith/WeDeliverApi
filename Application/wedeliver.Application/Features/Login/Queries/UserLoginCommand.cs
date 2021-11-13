﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Features.Login.Queries
{
    public class UserLoginCommand:IRequest<UserVM>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
