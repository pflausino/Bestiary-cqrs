using BestiaryCQRS.Domain.Core.Interfaces;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;

namespace BestiaryCQRS.Infra.MongoRepositories
{
    public class WeaponMongoRepository : MongoRepository<Weapon>, IWeaponMongoRepository
    {
        public WeaponMongoRepository(IMongoContext context) : base(context)
        {

        }

    }
}