using System.Collections.Generic;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Core.Dto;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Interfaces
{
    public interface ICreateWeaponHandler
    {
        Task<IList<NotificationDto>> Handle(CreateWeaponCommand command);
    }
}