using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardGuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public DashboardGuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        [HttpGet("GetLast6GuestList")]
        public IActionResult GetLast6GuestList()
        {
            var values = _guestService.TGetLast6GuestList();
            return Ok(values);
        }
    }
}
