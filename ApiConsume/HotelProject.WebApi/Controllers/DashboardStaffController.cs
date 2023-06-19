using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardStaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public DashboardStaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet("GetLast4StaffList")]
        public IActionResult GetLast4StaffList()
        {
            var values = _staffService.TGetLast4StaffList();
            return Ok(values);
        }
    }
}
