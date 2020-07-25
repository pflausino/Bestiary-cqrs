using BestiaryCQRS.Domain.Core.Entities;

namespace BestiaryCQRS.Domain.Entities
{
    public class Weapon : Entity
    {
        public virtual string Name { get; set; }
        public virtual int Strength { get; set; }
        public virtual int Magic { get; set; }
        // public virtual ElementeType ElementType { get; set; }


    }

}