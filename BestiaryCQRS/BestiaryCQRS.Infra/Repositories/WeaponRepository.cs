using System.Threading.Tasks;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;
using NHibernate;

namespace BestiaryCQRS.Infra.Repositories
{
    public class WeaponRepository : Repository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(ISession session) : base(session)
        {

        }
    }

}