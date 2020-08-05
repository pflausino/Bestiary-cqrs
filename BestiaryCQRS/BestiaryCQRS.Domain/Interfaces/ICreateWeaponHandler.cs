using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.Domain.Entities;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Interfaces
{
    public interface ICreateWeaponHandler
    {
        Task<Weapon> Handle(CreateWeaponCommand command);
    }
}