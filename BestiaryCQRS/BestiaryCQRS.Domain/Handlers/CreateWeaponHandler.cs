using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using BestiaryCQRS.BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;

namespace BestiaryCQRS.BestiaryCQRS.Domain.Handlers
{
    public class CreateWeaponHandler : ICreateWeaponHandler
    {
        private readonly IWeaponRepository repository;
        public CreateWeaponHandler(IWeaponRepository repository)
        {
            this.repository = repository;
        }

        public void Handle(CreateWeaponCommand command)
        {
            if (this.repository.GetAll().Any(w => w.Name == command.Name))
            {

            }

            var weapon = new Weapon(
                command.Name,
                command.Strength,
                command.Magic
            );

            this.repository.Add(weapon);
        }
    }
}