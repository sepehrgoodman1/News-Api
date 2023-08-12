using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Migrations.Migrations
{
    [Migration(202308081440)]
    public class _202308081440AddTables : Migration
    {
        public override void Up()
        {
            CreateCity();
            CreateComment();
            CreateGroup();
            CreateNews();
            CreateTag();
            CreateNewsTag();

        }
        public override void Down()
        {
            Delete.Table("NewsTags");
            Delete.Table("Tags");
            Delete.Table("News");
            Delete.Table("Groups");
            Delete.Table("Comments");
            Delete.Table("Cities");

        }



        void CreateCity()
        {
            Create.Table("Cities").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                                  .WithColumn("Name").AsString().NotNullable();
        }
        void CreateComment()
        {
            Create.Table("Comments").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                                  .WithColumn("Name").AsString().NotNullable()
                                  .WithColumn("Text").AsString()
                                  .WithColumn("CommentStatus").AsInt32().NotNullable();
        }
        void CreateGroup()
        {
            Create.Table("Groups").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                               .WithColumn("Name").AsString().NotNullable();
        }
     
        void CreateNews()
        {
            Create.Table("News").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                             .WithColumn("Title").AsString().NotNullable()
                             .WithColumn("Text").AsString()
                             .WithColumn("IsSlider").AsBoolean()
                             .WithColumn("CountViews").AsInt32()
                             .WithColumn("GroupId").AsInt32()
                             .ForeignKey("FK_News_Groups", "Groups", "Id")
                             .WithColumn("CityId").AsInt32()
                             .ForeignKey("FK_News_Cities", "Cities", "Id")
                             .WithColumn("CommentId").AsInt32()
                             .ForeignKey("FK_News_Comments", "Comments", "Id");

        }
        void CreateTag()
        {
            Create.Table("Tags").WithColumn("Id").AsInt32().PrimaryKey().Identity()
                         .WithColumn("Name").AsString().NotNullable();
              
        }
        void CreateNewsTag()
        {
            Create.Table("NewsTags")
                                    .WithColumn("TagsId").AsInt32().PrimaryKey()
                                    .ForeignKey("FK_NewsTags_Tags", "Tags", "Id")
                                    .WithColumn("NewsId").AsInt32().PrimaryKey()
                                    .ForeignKey("FK_NewsTags_News", "News", "Id");
        }

    }
}
