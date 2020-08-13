using FluentValidation;

namespace BestiaryCQRS.Domain.Queries
{
    public class FilterByNameQueryValidator : AbstractValidator<FilterByNameQuery>
    {
        public FilterByNameQueryValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("A Busca deve conter mais de 3 digitos");
        }

    }
}