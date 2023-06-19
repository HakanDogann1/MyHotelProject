using HotelProject.EntityLayer;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoleUserController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleUserController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var users=_userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"]=id;
            var roleList = _roleManager.Roles.ToList();
            var userRole = await _userManager.GetRolesAsync(user);

            List<UserRoleListViewModel> listViewModels = new List<UserRoleListViewModel>();
            foreach (var role in roleList)
            {
                UserRoleListViewModel roleListViewModel = new UserRoleListViewModel();
                roleListViewModel.Id = role.Id;
                roleListViewModel.Name = role.Name;
                roleListViewModel.Exist = userRole.Contains(role.Name);
                listViewModels.Add(roleListViewModel);
            }
            return View(listViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> GetRole(List<UserRoleListViewModel> userRoleListViewModels)
        {
            var id =(int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
           foreach (var role in userRoleListViewModels)
            {
                if(role.Exist)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
           return RedirectToAction("Index","AdminRoleUser");
        }
    }
}
