using FluentValidation;
using RealState.ViewModels.BuyerViewModels;

namespace RealState.ValidationRules;

public class SellerValidator : AbstractValidator<CreateBuyerViewModel>
{
    public SellerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Lütfen Satıcı adı kısmını boş geçmeyin")
            .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir");


    }
}
