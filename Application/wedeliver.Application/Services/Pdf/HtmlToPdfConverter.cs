using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace wedeliver.Application.Services.Pdf
{
    public class HtmlToPdfConverter : IHtmlToPdfConverter
    {

        public async Task<byte[]> GetPDF(string content)
        {
            var targetHtmlFileName = $"{Thread.CurrentThread.ManagedThreadId}.html";
            var targetPdfFileName = $"{Thread.CurrentThread.ManagedThreadId}.pdf";

            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var exeFilePath = Path.Combine(basePath, "Rotativa", "Mac", "wkhtmltopdf");

            var htmlFilePath = Path.Combine(basePath, targetHtmlFileName);
            var pdfFilePath = Path.Combine(basePath, targetPdfFileName);

            var htmlWriter = new StreamWriter(htmlFilePath);
            await htmlWriter.WriteAsync(content);
            await htmlWriter.FlushAsync();
            htmlWriter.Close();

            var pi = new ProcessStartInfo(exeFilePath);
            pi.CreateNoWindow = true;
            pi.UseShellExecute = false;
            pi.WorkingDirectory = basePath;//@"c:\wkhtmltopdf\";
            pi.Arguments = $"{targetHtmlFileName} {targetPdfFileName}";//"sample2.html sample2.pdf";

            using (var process = Process.Start(pi))
            {
                process.WaitForExit(99999);
                Debug.WriteLine(process.ExitCode);
            }

            var data = File.ReadAllBytes(pdfFilePath);

            File.Delete(htmlFilePath);
            File.Delete(pdfFilePath);

            return data;
        }
    }
}
