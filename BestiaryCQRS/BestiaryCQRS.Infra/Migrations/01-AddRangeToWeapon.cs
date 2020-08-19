using FluentMigrator;

namespace BestiaryCQRS.Infra.Migrations
{
    [Migration(202008181924)]
    public class _01AddRangeToWeapon : Migration
    {
        public override void Up()
        {
            Alter.Table("Weapon").AddColumn("RangeType").AsInt32().NotNullable().WithDefaultValue(10);
        }
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

    }
}