using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Core.Dto;
using BestiaryCQRS.Domain.Entities;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Interfaces
{
    public interface IUpdateWeaponHandler
    {
        Task<Weapon> Handle(Guid id, UpdateWeaponCommand command);

    }
}