using FluentValidation;
using RealState.ViewModels.PortfolioViewModels;

namespace RealState.ValidationRules;

public class PortfolioValidator : AbstractValidator<CreatePortfolioViewModel>
{
    public PortfolioValidator()
    {
        // Title alanı boş olamaz ve maksimum 100 karakter olabilir.
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık alanı zorunludur.")
            .MaximumLength(100).WithMessage("Başlık 100 karakterden uzun olamaz.");

        // Description alanı maksimum 500 karakter olabilir.
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz.");
    }
}
