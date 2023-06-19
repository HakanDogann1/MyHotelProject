using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IGuestService guestService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _guestService = guestService;
            _roomService = roomService;
        }

        [HttpGet("GetStaffCount")]
        public IActionResult GetStaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }
        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }
        [HttpGet("GetGuestCount")]
        public IActionResult GetGuestCount()
        {
            var value = _guestService.TGetGuestCount();
            return Ok(value);
        }
        [HttpGet("GetRoomCount")]
        public IActionResult GetRoomCount()
        {
            var value = _roomService.TGetRoomCount();
            return Ok(value);
        }

    }
}
