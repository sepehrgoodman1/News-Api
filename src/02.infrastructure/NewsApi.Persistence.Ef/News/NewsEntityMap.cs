using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApi.Persistence.Ef.New
{
    public class NewsEntityMap : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> _)
        {
            _.ToTable("News");
            _.HasKey(x => x.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_=> _.Title).IsRequired(false);
            _.Property(_=> _.Text).IsRequired(false);
            _.Property(_=> _.IsSlider).IsRequired(false);
            _.Property(_=> _.Date).IsRequired(false);
            _.Property(_=> _.CountViews).IsRequired(false);
            _.HasOne(_=> _.City).WithMany(_ => _.News).HasForeignKey(x => x.CityId);
            _.HasOne(_=> _.Group).WithMany(_ => _.News).HasForeignKey(x => x.GroupId);
        }
    }
}
