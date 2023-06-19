using HotelProject.EntityLayer;
using HotelProject.WebUI.Models.AppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            AppUser appUser = new AppUser()
            {
                Email = registerViewModel.Mail,
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                UserName = registerViewModel.UserName,

            };
            var value =await _userManager.CreateAsync(appUser,registerViewModel.Password);
            if (value.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
