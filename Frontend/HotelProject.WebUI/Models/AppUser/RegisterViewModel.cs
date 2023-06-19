using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.AppUser
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Ad Alanı Gereklidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Alanı Gereklidir.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Gereklidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mail Alanı Gereklidir.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
        public string Password { get; set; }
    }
}
