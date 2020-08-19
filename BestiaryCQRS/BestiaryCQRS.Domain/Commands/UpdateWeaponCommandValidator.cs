using BestiaryCQRS.BestiaryCQRS.Domain.Commands;
using FluentValidation;

namespace BestiaryCQRS.Domain.Commands
{
    public class UpdateWeaponCommandValidator : AbstractValidator<UpdateWeaponCommand>
    {
        public UpdateWeaponCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Nao pode ser Vazio");

            RuleFor(u => u.Magic)
                .InclusiveBetween(0, 200)
                .WithMessage("Magic Deve estar entre 0 e 200");


            RuleFor(u => u.Strength)
                .InclusiveBetween(0, 200)
                .WithMessage("Strength Deve estar entre 0 e 200");

            RuleFor(w => w.RangeType)
                .IsInEnum()
                .WithMessage("O Range Type é Invalido");
        }

    }
}