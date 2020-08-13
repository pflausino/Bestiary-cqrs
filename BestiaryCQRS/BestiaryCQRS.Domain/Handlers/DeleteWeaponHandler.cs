using System;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Utils;
using BestiaryCQRS.Domain.Interfaces;

namespace BestiaryCQRS.Domain.Handlers
{
    public class DeleteWeaponHandler : IDeleteWeaponHandler
    {
        private readonly IWeaponRepository repository;
        private readonly NotificationContext notificationContext;

        public DeleteWeaponHandler(IWeaponRepository repository, NotificationContext notificationContext)
        {
            this.repository = repository;
            this.notificationContext = notificationContext;
        }
        public async Task Handle(Guid id)
        {
            var weapon = await this.repository.GetByIdAsync(id);
            if (weapon == null)
            {
                notificationContext.AddNotification(id.ToString(), "Non Existe");
                return;
            }

            await this.repository.RemoveAsync(weapon);
        }
    }
}