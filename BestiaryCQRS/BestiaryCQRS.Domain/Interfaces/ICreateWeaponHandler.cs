using BestiaryCQRS.BestiaryCQRS.Domain.Commands;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Interfaces
{
    public interface ICreateWeaponHandler
    {
        void Handle(CreateWeaponCommand command);
    }
}