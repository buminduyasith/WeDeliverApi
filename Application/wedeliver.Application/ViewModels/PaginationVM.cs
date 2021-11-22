using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wedeliver.Application.ViewModels
{
    public class PaginationVM<T>
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int TotalItems { get; set; }
        public List<T> Results { get; set; }
        public int NumberOfPages { get; set; }
        public int DisplayStart { get; set; }
        public int DisplayEnd { get; set; }
        public int DisplayCount { get; set; }
    }
}
