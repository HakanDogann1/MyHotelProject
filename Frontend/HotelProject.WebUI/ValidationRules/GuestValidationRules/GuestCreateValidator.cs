using FluentValidation;
using HotelProject.EntityLayer;
using HotelProject.WebUI.Models.Guest;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class GuestCreateValidator:AbstractValidator<AddGuestViewModel>
    {
        public GuestCreateValidator()
        {
            RuleFor(x => x.GuestCity).NotEmpty().WithMessage("Şehir Alanı Boş Geçilemez");
            RuleFor(x => x.GuestName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.GuestSurname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.GuestName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz.");
            RuleFor(x => x.GuestSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz.");
            RuleFor(x => x.GuestCity).MinimumLength(3).WithMessage("Lütfen En Az 2 Karakter Giriniz.");
            RuleFor(x => x.GuestName).MaximumLength(20).WithMessage("Lütfen En Fazla 20 Karakter Giriniz.");
            RuleFor(x => x.GuestSurname).MaximumLength(30).WithMessage("Lütfen En Fazla 30 Karakter Giriniz.");
            RuleFor(x => x.GuestCity).MaximumLength(20).WithMessage("Lütfen En Fazla 20 Karakter Giriniz.");
        }
    }

    
}
