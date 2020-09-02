using BestiaryCQRS.Domain.Core.Interfaces;
using BestiaryCQRS.Domain.Entities;

namespace BestiaryCQRS.Domain.Interfaces
{
    public interface IWeaponMongoRepository : IMongoRepository<Weapon>
    {

    }
}