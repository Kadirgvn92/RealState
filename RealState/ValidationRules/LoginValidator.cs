using FluentValidation;
using RealState.ViewModels.AuthViewModels;

public class LoginValidator : AbstractValidator<LoginViewModel>
{
    public LoginValidator()
    {
        // Kullanıcı adı için validasyon
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Kullanıcı adı gerekli.")
            .MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakter olabilir.");

        // Şifre için validasyon
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre gerekli.")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Şifre en fazla 100 karakter olabilir.");
    }
}
