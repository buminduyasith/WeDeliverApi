using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Extensions
{
    public static class ResturantExtension
    {
        public static async Task<RestaurantVM> GetResturantVMAsync(this Restaurant restaurant, IMapper mapper, IApplicationDbContext applicationDbContext)
        {
            var restaurantVM = mapper.Map<RestaurantVM>(restaurant);

            //var assignee = await workItem.GetAssigneeAsync(identityUserService, mapper);

            //workItemVM.AssignTo = assignee;
            //workItemVM.SubmittedBy = await workItem.GetSubmittedAsync(identityService, mapper, applicationDbContext);
            //workItemVM.SubmittedDate = workItem.GetStartDate();
            //workItemVM.Department = Department.RD;
            return restaurantVM;
        }
    }
}
