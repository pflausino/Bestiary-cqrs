using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Enums;
using FluentNHibernate.Mapping;

namespace BestiaryCQRS.Infra.Mappings
{
    public class WeaponMap : ClassMap<Weapon>
    {
        public WeaponMap()
        {
            Id(x => x.Id).Column("WeaponId").GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.Strength);
            Map(x => x.Magic);
            Map(x => x.RangeType).CustomType<RangeEnum>();
            Table("Weapon");
        }

    }

}