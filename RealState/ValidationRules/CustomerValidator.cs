using FluentValidation;
using RealState.DTOs.CustomerDTOs;

namespace RealState.ValidationRules;

public class CustomerValidator : AbstractValidator<CustomerAddDTO>
{
    public CustomerValidator()
    {
        RuleFor(x => x.CustomerFullName)
            .NotEmpty().WithMessage("Lütfen Ad Soyad kısmını boş geçmeyin")
            .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir");

        RuleFor(x => x.CustomerPhone)
            .NotEmpty().WithMessage("Lütfen telefon kısmını boş geçmeyiniz");

        RuleFor(x => x.CustomerPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Fiyat 0 veya daha büyük olmalıdır")
            .When(x => x.CustomerPrice.HasValue);

        RuleFor(x => x.ListingDate)
            .NotEmpty().WithMessage("Lütfen ilan tarihini boş geçmeyiniz")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("İlan tarihi bugünden ileri olamaz");

        RuleFor(x => x.FSBODate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("FSBO tarihi bugünden ileri olamaz")
            .When(x => x.FSBODate.HasValue);



    }
}
