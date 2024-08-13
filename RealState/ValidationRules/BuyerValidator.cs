using FluentValidation;
using RealState.DTOs.CustomerDTOs;
using RealState.ViewModels.BuyerViewModels;

namespace RealState.ValidationRules;

public class BuyerValidator : AbstractValidator<CreateBuyerViewModel>
{
    public BuyerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Lütfen Alıcı adı kısmını boş geçmeyin")
            .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir");


    }
}
