using MediatR;
using Microsoft.AspNetCore.Identity;
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
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.Admin.Queries.GetNewlyRegisterdUser
{
    public class GetNewlyRegisterdUsersQuery:IRequest<IEnumerable<UserVmForAdmin>>
    {

    }

    public class GetNewlyRegisterdUsersQueryHandler : IRequestHandler<GetNewlyRegisterdUsersQuery,IEnumerable<UserVmForAdmin>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        protected readonly IApplicationDbContext _dbContext;
        private ILogger logger;
       
        public GetNewlyRegisterdUsersQueryHandler(UserManager<IdentityUser> userManager, IApplicationDbContext dbContext, ILogger<GetNewlyRegisterdUsersQueryHandler> logger)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<IEnumerable<UserVmForAdmin>> Handle(GetNewlyRegisterdUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserVmForAdmin> users = new();
            var nonActiverRestaurants = await GetNonActiveRestaurantUsers();
            var nonActiverRiders = await GetNonActiveRiderAccount();
            var nonActiverPharmacies = await GetNonActivePharmacyUsers();

            foreach (var item in nonActiverRestaurants)
            {
                var user = await _userManager.FindByIdAsync(item.UserId);
                var userRole = await _userManager.GetRolesAsync(user);
                users.Add(new UserVmForAdmin { Email = user.Email, Id = item.Id, UserId = user.Id, Role = userRole[0], Name = item.OwnerName, SignupDate = item.CreateDate.ToString() });
            }

            foreach (var item in nonActiverRiders)
            {
                var user = await _userManager.FindByIdAsync(item.UserId);
                var userRole = await _userManager.GetRolesAsync(user);
                users.Add(new UserVmForAdmin { Email = user.Email, Id = item.Id, UserId = user.Id, Role = userRole[0], Name = item.FName + " " + item.LName, SignupDate = item.CreateDate.ToString() });
            }


            foreach (var item in nonActiverPharmacies)
            {
                var user = await _userManager.FindByIdAsync(item.UserId);
                var userRole = await _userManager.GetRolesAsync(user);
                users.Add(new UserVmForAdmin { Email = user.Email, Id = item.Id, UserId = user.Id, Role = userRole[0], Name = item.OwnerName, SignupDate = item.CreateDate.ToString() });
            }

            return users;



        }
        private async Task<IEnumerable<Restaurant>> GetNonActiveRestaurantUsers()
        {
            Expression<Func<Restaurant, bool>> predicate = o => o.Active == false;
            var query = _dbContext.Restaurants.Where(predicate);

            await query.Include(x => x.Location).LoadAsync();

            return await query.ToListAsync();
        }

        private async Task<IEnumerable<Rider>> GetNonActiveRiderAccount()
        {
            Expression<Func<Rider, bool>> predicate = o => o.Active == false;
            var query = _dbContext.Riders.Where(predicate);

            await query.Include(x => x.Location).LoadAsync();

            return await query.ToListAsync();
        }


        private async Task<IEnumerable<Pharmacy>> GetNonActivePharmacyUsers()
        {
            Expression<Func<Pharmacy, bool>> predicate = o => o.Active == false;
            var query = _dbContext.Pharmacies.Where(predicate);

            await query.Include(x => x.Location).LoadAsync();

            return await query.ToListAsync();
        }
    }
}
