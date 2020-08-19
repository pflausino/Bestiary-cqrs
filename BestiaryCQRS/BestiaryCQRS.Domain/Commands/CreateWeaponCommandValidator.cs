using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using FluentValidation;

namespace BestiaryCQRS.Domain.Commands
{
    public class CreateWeaponCommandValidator : AbstractValidator<CreateWeaponCommand>
    {
        public CreateWeaponCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo");

            RuleFor(c => c.Strength)
                .InclusiveBetween(1, 99)
                .WithMessage("Strenght deve ser entre 1 e 99");

            RuleFor(c => c.Magic)
                .InclusiveBetween(1, 99)
                .WithMessage("Magic deve ser entre 1 e 99");

            RuleFor(w => w.RangeType)
               .IsInEnum()
               .WithMessage("O Range Type é Invalido");
        }
    }
}
