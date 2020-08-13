using System;
using System.Threading.Tasks;

namespace BestiaryCQRS.Domain.Interfaces
{
    public interface IDeleteWeaponHandler
    {
        Task Handle(Guid id);

    }
}