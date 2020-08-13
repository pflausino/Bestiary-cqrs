using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Queries;

namespace BestiaryCQRS.Domain.Interfaces
{
    public interface IFilterByNameWeaponHandler
    {
        Task<IQueryable<Weapon>> Handler(FilterByNameQuery name);
    }
}