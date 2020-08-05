using FluentValidation;

namespace BestiaryCQRS.Domain.Entities
{
    public class WeaponValidator : AbstractValidator<Weapon>
    {
        public WeaponValidator()
        {
            RuleFor(w => w.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo");
        }
    }
}