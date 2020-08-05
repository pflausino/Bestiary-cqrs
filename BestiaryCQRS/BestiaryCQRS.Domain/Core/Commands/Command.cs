using FluentValidation;
using FluentValidation.Results;

namespace BestiaryCQRS.Domain.Core.Commands
{
    public class Command
    {
        public virtual bool Valid { get; private set; }
        public virtual bool Invalid => !Valid;
        public virtual ValidationResult ValidationResult { get; private set; }

        public virtual bool Validate<T>(T model, AbstractValidator<T> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
