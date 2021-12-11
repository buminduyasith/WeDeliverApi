using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Templates.Renderer
{
    public class RenderTemplate : IRenderTemplate
    {
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
    }
}
