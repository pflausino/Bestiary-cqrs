using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Core.Utils;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Handlers
{
    public class CreateWeaponHandler : ICreateWeaponHandler
    {
        private readonly IWeaponRepository repository;
        private readonly NotificationContext notificationContext;

        public CreateWeaponHandler(IWeaponRepository repository, NotificationContext notificationContext)
        {
            this.repository = repository;
            this.notificationContext = notificationContext;
        }

        public async Task<Weapon> Handle(CreateWeaponCommand command)
        {

            var weapon = new Weapon(
                command.Name,
                command.Strength,
                command.Magic,
                command.RangeType
            );

            if (weapon.Invalid)
            {
                notificationContext.AddNotifications(weapon.ValidationResult);
                return null;
            }

            await this.repository.AddAsync(weapon);

            return weapon;
        }
    }
}