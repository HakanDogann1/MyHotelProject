using HotelProject.EntityLayer;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserSettingsViewModel model = new UserSettingsViewModel()
            {
                Email = user.Email,
                Surname = user.Surname,
                Name = user.Name,
                UserName = user.UserName,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSettingsViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userInfo=_userManager.Users.FirstOrDefault(x=>x.Id == user.Id);
            userInfo.Surname = model.Surname;
            userInfo.Name = model.Name;
            userInfo.UserName = model.UserName;
            userInfo.Email = model.Email;
            await _userManager.UpdateAsync(userInfo);
            return View();
        }
    }
}
