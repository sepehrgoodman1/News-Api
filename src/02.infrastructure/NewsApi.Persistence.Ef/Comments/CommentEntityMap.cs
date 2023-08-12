using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Persistence.Ef.Comments
{
    public class CommentEntityMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> _)
        {
            _.ToTable("Comments");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name).IsRequired();
            _.Property(_ => _.Text).IsRequired();
            _.Property(_ => _.CommentStatus).IsRequired();
            _.HasOne(_=>_.News).WithMany(_ => _.Comments).HasForeignKey(_ => _.NewsId);
        }
    }
}
