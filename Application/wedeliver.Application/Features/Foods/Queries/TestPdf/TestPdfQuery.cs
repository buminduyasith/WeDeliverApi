using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Services.Pdf;
using wedeliver.Application.ViewModels;
using Wkhtmltopdf.NetCore;

namespace wedeliver.Application.Features.Foods.Queries.TestPdf
{
    public class TestPdfQuery:IRequest<string>
    {
    }

    public class TestPdfQueryHandler : IRequestHandler<TestPdfQuery, string>
    {
        private readonly IGeneratePdf _generatePdf;

        private readonly IPdfGenerateService _pdfservice;

        private readonly ILogger _logger;

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public TestPdfQueryHandler(IPdfGenerateService pdfservice,IGeneratePdf generatePdf, ILogger<TestPdfQueryHandler> logger,IMapper mapper,IApplicationDbContext dbContext)
        {
            _generatePdf = generatePdf;
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _pdfservice = pdfservice;
        }
        public async Task<string> Handle(TestPdfQuery request, CancellationToken cancellationToken)
        {
            var data = new Dictionary<string, string>();

            var foodCategoryList = await _dbContext.FoodCategory.ToListAsync();

            var foodCategoryVMList = _mapper.Map<IEnumerable<FoodCategoryVM>>(foodCategoryList);

            string t = "";

            StringBuilder sb = new StringBuilder("");

            foreach (var category in foodCategoryVMList)
            {
                sb.AppendFormat("<td class=\"article basetd red\">{0}</td>", category.Name);
                sb.AppendFormat("<td class=\"basetd\"><small>{0} </small></td>", category.slug);
                sb.AppendFormat("<td class=\"basetd aligncenter \">{0}</td>", category.Id);
                sb.AppendFormat("<td class=\"basetd alignright \">{0}</td>", "100.25");
                sb.AppendFormat("<tr><td height = \"1\" colspan = \"4\" style = \"border-bottom:1px solid #e4e4e4\"></td></tr>");
                break;
            }

            data.Add("total", "456.25");
            data.Add("items", sb.ToString());

            return "";// await _pdfservice.Create("ww", data, 5);
        }
    }
}
