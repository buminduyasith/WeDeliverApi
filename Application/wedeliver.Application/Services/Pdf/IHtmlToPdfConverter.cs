using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Services.Pdf
{
    public interface IHtmlToPdfConverter
    {
        Task<byte[]> GetPDF(string content);
    }
}
