using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Exceptions;
using wedeliver.Application.Services.EmailSenderServices;
using wedeliver.Application.Services.Notification;
using wedeliver.Application.Templates.Renderer;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Services.Pdf.FoodOrderInvoice
{
    public class FoodOrderInvoice : IFoodOrderInvoice
    {
        private const string FOOD_ORDER_INVOICE_TEMPLATE_PATH= "Templates/Invoice/WedeliverInvoice.html";
       private readonly IPdfGenerateService _pdfservice;

        private readonly ILogger _logger;

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IEmailSenderService _emailSenderService;
        public FoodOrderInvoice(IPdfGenerateService pdfservice,
            ILogger<FoodOrderInvoice> logger, 
            IMapper mapper, IApplicationDbContext dbContext,IUserRepository userRepository,IEmailSenderService emailSenderService)
        {
           
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _pdfservice = pdfservice;
            _userRepository = userRepository;
            _emailSenderService = emailSenderService;
        }
        public async Task<bool> process(int foodOrderId)
        {

            var data = new Dictionary<string, string>();
            StringBuilder htmlContent = new StringBuilder("");

            Expression<Func<FoodOrder, bool>> predicate = o => o.Id == foodOrderId;


            var foodOrder = await GetFoodOrder(predicate);

            if (foodOrder == null) throw new NotFoundException("order not found",foodOrder);

            foreach (var order in foodOrder.ItemList)
            {
                htmlContent.AppendFormat("<td class=\"article basetd red\">{0}</td>", order.Food.Name);
                //htmlContent.AppendFormat("<td class=\"basetd\"><small>{0} </small></td>", order.Food.Name);
                htmlContent.AppendFormat("<td class=\"basetd aligncenter \">{0}</td>", order.Qty);
                htmlContent.AppendFormat("<td class=\"basetd alignright \">{0}</td>", order.Price.ToString("F"));
                htmlContent.AppendFormat("<tr><td height = \"1\" colspan = \"4\" style = \"border-bottom:1px solid #e4e4e4\"></td></tr>");
                
            }
            
            data.Add("total", foodOrder.Total.ToString("F"));
            data.Add("OrderNo", foodOrder.OrderNo);
            data.Add("fisrtName", foodOrder.Client.FName);
            data.Add("lastName", foodOrder.Client.LName);
            data.Add("restaurantName", foodOrder.Restaurant.Name);
            data.Add("resturantTelNumber", foodOrder.Restaurant.TelphoneNumber);
            data.Add("HouseNo", foodOrder.ShippingDetails.HouseNo);
            data.Add("Street", foodOrder.ShippingDetails.Street);
            data.Add("PostalCode", foodOrder.ShippingDetails.PostalCode);
            data.Add("City", foodOrder.ShippingDetails.City);
            data.Add("Province", foodOrder.ShippingDetails.Province.ToString());
            data.Add("District", foodOrder.ShippingDetails.District.ToString());
            data.Add("OrderCreatedDate", foodOrder.OrderCreatedDate.ToString());
            data.Add("EstimatedDate", foodOrder.EstimatedDate.ToString());
            data.Add("orderType", "Cash on delivery");
            data.Add("deliveryFee", "300.00");

            double grandTotal = foodOrder.Total + 300.00;
            data.Add("grandTotal", grandTotal.ToString("F"));

            data.Add("items", htmlContent.ToString());

            
            var renderer = new RenderTemplate();

            var content = renderer.GenerateTemplate(FOOD_ORDER_INVOICE_TEMPLATE_PATH, data);

            string email = await _userRepository.GetUserEmail(foodOrder.Client.Id);
              
            var html = new NotificationMessage(new string[] { email}, "Food Order Placed", content);

            await _emailSenderService.SendEmailAsync(html);

           await _pdfservice.Create("Templates/Invoice/WedeliverInvoice.html", data, foodOrderId);

            return true;

            //return await _pdfservice.Create("ww", data, 5);

        }

        public async Task<FoodOrder> GetFoodOrder(Expression<Func<FoodOrder, bool>> predicate)
        {
            var query = _dbContext.FoodOrder.Where(predicate);

            await query.Include(x => x.Client)
                .ThenInclude(x => x.Location)
                .LoadAsync();
            await query.Include(x => x.Restaurant).LoadAsync();
            await query.Include(x => x.ItemList)
                .ThenInclude(x => x.Food)
                .LoadAsync();
            await query.Include(x => x.ShippingDetails)
                .LoadAsync();


            return await query.FirstOrDefaultAsync();
        }
    }
}
