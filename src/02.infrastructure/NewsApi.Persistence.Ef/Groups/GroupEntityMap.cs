using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.Groups
{
    public class GroupEntityMap :IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> _)
        {
            _.ToTable("Groups");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name).IsRequired();
        }
    }
}
