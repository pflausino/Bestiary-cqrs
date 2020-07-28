using BestiaryCQRS.Domain.Core.Entities;

namespace BestiaryCQRS.Domain.Entities
{
    public class Weapon : Entity
    {
        public Weapon()
        {

        }
        public Weapon(string name, int strength, int magic)
        {
            Name = name;
            Strength = strength;
            Magic = magic;

        }
        public virtual string Name { get; protected set; }
        public virtual int Strength { get; protected set; }
        public virtual int Magic { get; protected set; }
        // public virtual ElementeType ElementType { get; protect set; }

    }

}