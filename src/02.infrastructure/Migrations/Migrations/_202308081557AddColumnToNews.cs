using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Migrations.Migrations
{
    [Migration(202308081557)]
    public class _202308081557AddColumnToNews : Migration
    {
        public override void Up()
        {
            Create.Column("Date").OnTable("News").AsDateTime().NotNullable();

        }
        public override void Down()
        {
            Delete.Column("Date").FromTable("News");
        }

     
    }
}
