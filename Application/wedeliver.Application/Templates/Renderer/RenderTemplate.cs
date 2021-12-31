using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wedeliver.Application.Templates.Renderer
{
    public class RenderTemplate : IRenderTemplate
    {
        static readonly Regex regex = new Regex(@"\{(\w+)\}", RegexOptions.Compiled);
        public async Task<string> Render(string viewPath, object[] model)
        {
            var template = string.Empty;

            using (var sr = new StreamReader(viewPath, Encoding.UTF8))
            {
                var content = await sr.ReadToEndAsync();
                template = string.Format(content, model);
            }

            return template;
        }

        public string ReplaceContent(string content, Dictionary<string, string> dict)
        {
            return regex.Replace(content, match => { return dict.ContainsKey(match.Groups[1].Value) ? dict[match.Groups[1].Value] : match.Groups[1].Value; });
        }

        public string GenerateTemplate(string templateTag, Dictionary<string, string> data)
        {
            try
            {
                var path =  GetTemplatePath(templateTag);

               
                string template = string.Empty;

                using (var sr = new StreamReader(path))
                {
                    template = sr.ReadToEnd();
                }

                if (template == string.Empty)
                {

                    throw new InvalidOperationException($"Invalid template {templateTag}");
                }

                template = ReplaceContent(template, data);

                return template;

            }
            catch (Exception ex)
            {

            }

            return "";
        }

        private string GetTemplatePath(string templateTag)
        {
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //var content = "Templates/Invoice/WedeliverInvoice.html";

            return Path.Combine(basePath, templateTag);
        }

       
    }
}
