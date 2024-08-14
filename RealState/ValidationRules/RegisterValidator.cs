using FluentValidation;
using RealState.ViewModels.AuthViewModels;

namespace RealState.ValidationRules;

public class RegisterValidator : AbstractValidator<RegisterViewModel>
{
    public RegisterValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Lütfen adı kısmını boş geçmeyin")
            .MinimumLength(3).WithMessage("Ad en az 3 karakter olabilir")
            .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Lütfen soyadı kısmını boş geçmeyin")
            .MinimumLength(3).WithMessage("Soyad en az 3 karakter olabilir")
            .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir");

        RuleFor(x => x.PhoneNumber)
           .NotEmpty().WithMessage("Lütfen telefon kısmını boş geçmeyin");

        RuleFor(x => x.Mail)
          .NotEmpty().WithMessage("Lütfen mail kısmını boş geçmeyin")
          .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin");


        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.")
            .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.")
            .Matches("^[a-zA-Z0-9_.-]*$").WithMessage("Kullanıcı adı yalnızca harf, rakam, nokta, alt çizgi ve tire içerebilir.");


        RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("Lütfen şifre kısmını boş geçmeyin")
                 .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır")
                 .MaximumLength(30).WithMessage("Şifre en fazla 30 karakter olabilir")
                 .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
                 .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir")
                 .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
                 .Matches(@"[\!\?\*\.]").WithMessage("Şifre en az bir özel karakter içermelidir");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Lütfen şifreyi onaylayın")
            .Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor");
        RuleFor(x => x.IsConfirmed)
    .Equal(true).WithMessage("Şartları kabul etmelisiniz.");

    }
}
