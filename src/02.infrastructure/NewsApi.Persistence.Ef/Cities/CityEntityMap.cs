using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.Cities
{
    public class CityEntityMap :IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> _)
        {
            _.ToTable("Cities");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name).IsRequired();
        }
    }
}
