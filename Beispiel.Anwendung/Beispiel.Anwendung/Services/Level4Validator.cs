using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using FluentValidation;

namespace Beispiel.Anwendung.Services;

public class Level4Validator : AbstractValidator<Level4Model>
{
    public Level4Validator(ITranslation translation)
    {
        RuleFor(e => e.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(_ => translation.NotEmptyMessage)
            .MaximumLength(50).WithMessage(_ => translation.MaxLengthMessage(50));
    }
}