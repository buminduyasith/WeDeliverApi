using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.Templates.Renderer
{
    public interface IRenderTemplate
    {
        Task<string> Render(string viewPath, object[] model);
    }
}
