using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Services.DocumentUplaod
{
    public interface IDocumentStorageService
    {
        Task<string> UploadDocument(byte[] file);
    }
}
