using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Services.Pdf
{
    public interface IPdfGenerateService
    {
         Task<bool> Create(string templateTag,
            Dictionary<string, string> data,
            int userId);

        Task<bool> Create(string templateTag,
            Dictionary<string, string> data,
            int userId,
            string headerHtmlPath,
            string footerHtmlPath);

     
    }
}
