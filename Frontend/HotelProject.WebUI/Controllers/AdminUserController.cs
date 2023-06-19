using HotelProject.EntityLayer;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class AdminUserController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AdminUserController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AppRole appRole)
        {
            var values = await _roleManager.CreateAsync(appRole);
            if(values.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppRole appRole)
        {
           var value1 = _roleManager.Roles.FirstOrDefault(x=>x.Id==appRole.Id);
            value1.Name = appRole.Name;
            var value2 = await _roleManager.UpdateAsync(value1);
            if (value2.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }
    }
}
