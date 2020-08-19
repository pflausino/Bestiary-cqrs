using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Core.Dto;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Core.Utils;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Handlers
{
    public class UpdateWeaponHandler : IUpdateWeaponHandler
    {
        private readonly IWeaponRepository repository;
        private readonly NotificationContext notification;
        public UpdateWeaponHandler(IWeaponRepository repository, NotificationContext notification)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.notification = notification ?? throw new ArgumentNullException(nameof(notification));
        }

        public async Task<Weapon> Handle(Guid id, UpdateWeaponCommand command)
        {
            var originalWeapon = await this.repository.GetByIdAsync(id);
            if (originalWeapon == null)
            {
                notification.AddNotification(id.ToString(), "Non Existe");
                return null;
            }
            originalWeapon.UpdateWeapon(command.Name, command.Magic, command.Strength, command.RangeType);
            if (originalWeapon.Invalid)
            {
                notification.AddNotifications(originalWeapon.ValidationResult);
                return null;
            }


            await this.repository.UpdateAsync(originalWeapon);
            return originalWeapon;

        }
    }
}