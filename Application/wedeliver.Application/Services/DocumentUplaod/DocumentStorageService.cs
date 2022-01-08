using Firebase.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Configurations;

namespace wedeliver.Application.Services.DocumentUplaod
{
    public class DocumentStorageService : IDocumentStorageService
    {
        private readonly FirebaseStorageConfiguration _firebaseStorageConfiguration;
        private readonly ILogger _logger;

        public DocumentStorageService(FirebaseStorageConfiguration firebaseStorageConfiguration, ILogger<DocumentStorageService> logger)
        {
            _firebaseStorageConfiguration = firebaseStorageConfiguration;
            _logger = logger;
        }

        public async Task<string> UploadDocument(byte[] file)
        {

            Stream stream = new MemoryStream(file);

            string fileName = DateTime.Now.ToString("yyyyddMMhmm") + ".pdf";

            var task = new FirebaseStorage(_firebaseStorageConfiguration.Bucket)
                    .Child("data")
                    .Child("random")
                    .Child(fileName)
                    .PutAsync(stream);

            task.Progress.ProgressChanged += (s, e) => _logger.LogInformation($"Progress: {e.Percentage} %");
            //Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url

            try
            {
                var downloadUrl = await task;
                _logger.LogInformation($"downloadUrl: {downloadUrl} ");
                return downloadUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError($"log error : {ex.Message} : {ex.ToString()} ");
                return String.Empty;
            }
        }
    }
}
