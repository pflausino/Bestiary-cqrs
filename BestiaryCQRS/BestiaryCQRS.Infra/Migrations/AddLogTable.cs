using FluentMigrator;

namespace BestiaryCQRS.BestiaryCQRS.Infra.Migrations
{
    [Migration(202025070008)]
    public class AddLogTable : Migration
    {
        public override void Up()
        {
            Create.Table("LogBestiary")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }
        public override void Down()
        {
            Delete.Table("LogBestiary");
        }

    }
}