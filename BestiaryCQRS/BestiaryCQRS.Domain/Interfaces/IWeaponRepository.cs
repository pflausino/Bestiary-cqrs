using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Interfaces;
using BestiaryCQRS.Domain.Entities;

namespace BestiaryCQRS.Domain.Interfaces
{
    public interface IWeaponRepository : IRepository<Weapon>
    {

    }
}