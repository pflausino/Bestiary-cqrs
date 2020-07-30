using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Core.Dto;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Interfaces
{
    public interface IUpdateWeaponHandler
    {
        Task<IList<NotificationDto>> Handle(Guid id, UpdateWeaponCommand command);

    }
}