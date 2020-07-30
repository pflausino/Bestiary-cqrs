using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Core.Dto;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Interfaces;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Handlers
{
    public class UpdateWeaponHendler : IUpdateWeaponHandler
    {
        private readonly IWeaponRepository repository;
        private IList<NotificationDto> notification;
        public UpdateWeaponHendler(IWeaponRepository repository)
        {
            this.repository = repository;
            notification = new List<NotificationDto>();
        }
        public async Task<IList<NotificationDto>> Handle(Guid id, UpdateWeaponCommand command)
        {
            if (await this.repository.GetByIdAsync(id) == null)
            {
                notification.Add(new NotificationDto("Essa Arma Nao Esta Cadastrada", command));
                return notification;
            }

            return this.notification;

        }
    }
}