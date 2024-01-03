using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;

namespace wedeliver.Infrastructure.Persistence.Configuration.Book
{
    
    public class BookConfiguration : IEntityTypeConfiguration<BookItem>
    {
        public void Configure(EntityTypeBuilder<BookItem> builder)
        {
            builder.ToTable("BookItems", "bis");
            builder.HasKey(x => x.BookId);
          /*  builder.HasKey(x => x.Id);*/
        }
    }
}
