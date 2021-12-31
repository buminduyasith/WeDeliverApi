﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace wedeliver.Application.Services.Pdf
{
    public class PdfGenerateService : IPdfGenerateService
    {
        private readonly IGeneratePdf _generatePdf;

        static readonly Regex regex = new Regex(@"\{(\w+)\}", RegexOptions.Compiled);

        private readonly ILogger _logger;


        public PdfGenerateService(IGeneratePdf generatePdf,ILogger<PdfGenerateService> logger)
        {
            _generatePdf = generatePdf;
            _logger = logger;
        }
        public async Task<bool> Create(string templateTag, Dictionary<string, string> data, int userId)
        {
            return await Create(templateTag,
                data,
                userId,
                string.Empty,
                string.Empty);
        }

        public async Task<bool> Create(string templateTag, Dictionary<string, string> data, int userId, string headerHtmlPath, string footerHtmlPath)
        {
            await GeneratePdf(templateTag, data, headerHtmlPath, footerHtmlPath, userId);

            return true;
        }

        private async Task<bool> GeneratePdf(string templateTag,
           Dictionary<string, string> data,
           string headerHtmlPath,
           string footerHtmlPath,
           int userId)
        {
            try
            {
                var path = await GetTemplatePath(templateTag);

                _logger.LogWarning("path : {0}", path);


                string template = string.Empty;

                using (var sr = new StreamReader(path))
                {
                    template = sr.ReadToEnd();
                }

                if (template == string.Empty)
                {
                   
                    throw new InvalidOperationException($"Invalid template {templateTag}");
                }

                template = Replace(template, data);
                var documentData = _generatePdf.GetPDF(template, headerHtmlPath, footerHtmlPath);

                

                /*   int docTypeId = await _context.AttachmentTypes.Where(x => x.Id == (int)AttachmentTypeEnum.PaymentReceipt).Select(x => x.EnadocDoumentTypeId).FirstOrDefaultAsync();

                   var response = await _uploadService.Upload(documentData, data.GetValueOrDefault("DocumentName"), "application/pdf",
                                                           docTypeId, data.GetValueOrDefault("EntityId"), data.GetValueOrDefault("PayerIdentifierNumber"), data.GetValueOrDefault("YOA"));

                   if (response == null)
                   {
                       _logger.LogWarning("Uploaded-Error-Pdf for entity id : {0}", data["EntityId"]);
                   }
                   else
                   {
                       _logger.LogInformation("Uploaded-Success-Pdf for entity id : {0} and document token : {1}", data["EntityId"], response.documentToken);
                   }
   */




            }
            catch (Exception ex)
            {
                
            }

            return true;
        }

        private string Replace(string content, Dictionary<string, string> dict)
        {
            return regex.Replace(content, match => { return dict.ContainsKey(match.Groups[1].Value) ? dict[match.Groups[1].Value] : match.Groups[1].Value; });
        }

        private async Task<string> GetTemplatePath(string templateTag)
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var content = "Templates/Invoice/WedeliverInvoice.html";

            return Path.Combine(basePath, content);
        }
    }
}
