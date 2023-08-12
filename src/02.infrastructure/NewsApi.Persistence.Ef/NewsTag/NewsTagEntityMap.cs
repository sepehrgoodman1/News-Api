using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.NewsTags
{
    public class NewsTagEntityMap : IEntityTypeConfiguration<NewsTag>
    {
        public void Configure(EntityTypeBuilder<NewsTag> _)
        {
            _.ToTable("NewsTag");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.NewsId).IsRequired(false);
            _.Property(_ => _.TagsId).IsRequired(false);
            _.HasOne(_ => _.Newss).WithMany(_ => _.NewsTags).HasForeignKey(x => x.NewsId);
            _.HasOne(_ => _.Tags).WithMany(_ => _.NewsTags).HasForeignKey(x => x.TagsId);

        }
    }
}
