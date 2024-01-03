using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;

namespace wedeliver.Domain.Entities
{
    public class BookItem
    {
        public string BookId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public virtual Author Author { get; set; }

    }
}
