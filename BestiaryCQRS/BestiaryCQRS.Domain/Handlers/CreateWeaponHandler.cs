using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Core.Dto;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Handlers
{
    public class CreateWeaponHandler : ICreateWeaponHandler
    {
        private readonly IWeaponRepository repository;
        private IList<NotificationDto> notification;
        public CreateWeaponHandler(IWeaponRepository repository)
        {
            this.repository = repository;
            notification = new List<NotificationDto>();
        }

        public async Task<IList<NotificationDto>> Handle(CreateWeaponCommand command)
        {
            if (this.repository.GetAll().Any(w => w.Name == command.Name))
            {
                notification.Add(new NotificationDto("Ja Existe Uma Arma Com esse Nome", command));
                return notification;
            }

            var weapon = new Weapon(
                command.Name,
                command.Strength,
                command.Magic
            );

            var result = await this.repository.AddAsync(weapon);

            notification.Add(new NotificationDto(result));

            return notification;
        }
    }
}