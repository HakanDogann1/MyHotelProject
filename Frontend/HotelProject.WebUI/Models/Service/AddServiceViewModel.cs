using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Models.Service
{
    public class AddServiceViewModel
    {
        [Required(ErrorMessage = "Başlık giriniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "İçerik giriniz.")]
        [StringLength(400, ErrorMessage = "Maksimum 400 karakter olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "İkon giriniz.")]
        public string Icon { get; set; }
    }
}
